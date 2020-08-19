using GMap.NET.CacheProviders;
using VPS.ArduPilot;
using VPS.Comms;
using VPS.Controls;
using VPS.Utilities;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

namespace VPS.Controls
{
    public partial class LayerReader : Form
    {
        public LayerReader()
        {
            InitializeComponent();
            this.Latitude.TextChange += GetOriginAlt;
            this.Longitude.TextChange += GetOriginAlt;
            this.RetButton.OnOK += Accept_Click;
            this.RetButton.OnCancel += Cancel_Click;

        }


        private void GetOriginAlt()
        {
            this.Altitude.TextContent = 
                srtm.getAltitude(
                    System.Convert.ToDouble(this.Latitude.TextContent),
                    System.Convert.ToDouble(this.Longitude.TextContent)
                    ).alt.ToString();
        }

        public LayerReader(string path)
        {
            InitializeComponent();
            if (path.ToLower().EndsWith(".tif") && File.Exists(path))
                OpenFile(path);
        }

        private void FileOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "TIFF地理影像(*.tif)|*.tif";
                ofd.ShowDialog();
                if (File.Exists(ofd.FileName))
                    OpenFile(ofd.FileName);
            }
        }

        private void OpenFile(string path)
        {
            this.Latitude.TextChange -= GetOriginAlt;
            this.Longitude.TextChange -= GetOriginAlt;

            this.Longitude.TextContent = 0.ToString();
            this.Latitude.TextContent = 0.ToString();
            this.Altitude.TextContent = 0.ToString();
            this.MapScale.TextContent = "1:200";

            this.FilePath.TextContent = path;

            this.Latitude.TextChange += GetOriginAlt;
            this.Longitude.TextChange += GetOriginAlt;
            Func<string, GDAL.GDAL.GeoBitmap> GetGeoBitmap = (filePath) =>
                {
                    var bitmap = GDAL.GDAL.LoadImageInfo(filePath);
                    Image img = Image.FromHbitmap(bitmap.smallBitmap.GetHbitmap());
                    return bitmap;
                };
            IAsyncResult iarLoadBitmap = GetGeoBitmap.BeginInvoke(path, CallbackWhenLoadBitmapDone, this);
            Func<string, double[]> AnalyzeAlt = (filePath) =>
            {
                var bitmap = GDAL.GDAL.LoadImageInfo(filePath);
                double deltaX = (bitmap.Rect.Right - bitmap.Rect.Left) / 1000;
                double deltaY = (bitmap.Rect.Top - bitmap.Rect.Bottom) / 1000;
                double maxLat = bitmap.Rect.Left;
                double maxLng = bitmap.Rect.Bottom;
                double maxAlt = srtm.getAltitude(bitmap.Rect.Left, bitmap.Rect.Bottom).alt;
                double minLat = bitmap.Rect.Left;
                double minLng = bitmap.Rect.Bottom;
                double minAlt = srtm.getAltitude(bitmap.Rect.Left, bitmap.Rect.Bottom).alt;
                for (int i = 1; i < 1000; i++)
                {
                    for (int j = 1; j < 1000; j++)
                    {
                        double alt = srtm.getAltitude(bitmap.Rect.Left + i * deltaX, bitmap.Rect.Bottom + j * deltaY).alt;
                        if(alt < minAlt)
                        {
                            minAlt = alt;
                            minLat = bitmap.Rect.Bottom + j * deltaY;
                            minLng = bitmap.Rect.Left + i * deltaX;
                        }else if(alt > maxAlt)
                        {
                            maxAlt = alt;
                            maxLat = bitmap.Rect.Bottom + j * deltaY;
                            maxLng = bitmap.Rect.Left + i * deltaX;
                        }
                    }
                }
                return new double[] { minLng, minLat, minAlt, maxLng, maxLat, maxAlt };
            };

            IAsyncResult iar = AnalyzeAlt.BeginInvoke(path, CallbackWhenAnalyzeAltDone, this);
        }

        double _maxLat = 0;
        double _maxLng = 0;
        double _maxAlt = 0;
        double _minLat = 0;
        double _minLng = 0;
        double _minAlt = 0;
        private void CallbackWhenAnalyzeAltDone(IAsyncResult iar)
        {
            AsyncResult ar = (AsyncResult)iar;
            Func<string, double[]> geoFunc = (Func<string, double[]>)ar.AsyncDelegate;
            var data = geoFunc.EndInvoke(iar);

            if (data == null)
            {
                IsLoadInfo = false;
                return;
            }
            else
            {
                IsLoadInfo = true;
                _minLng = data[0]; _minLat = data[1]; _minAlt = data[2];
                _maxLng = data[3]; _maxLat = data[4]; _maxAlt = data[5];
            }
        }


        private void CallbackWhenLoadBitmapDone(IAsyncResult iar)
        {
            AsyncResult ar = (AsyncResult)iar;
            Func<string, GDAL.GDAL.GeoBitmap> geoFunc = (Func<string, GDAL.GDAL.GeoBitmap>)ar.AsyncDelegate;

            geobitmap = geoFunc.EndInvoke(iar);
            if (geobitmap == null)
            {
                IsLoadLayer = false;
                return;
            }
            if (!geobitmap.Rect.IsEmpty)
            {
                IsLoadLayer = true;

                var rect = geobitmap.Rect;
                this.TopLabel.Text = string.Format(TopFormat, rect.Top >= 0 ? rect.Top.ToString("f2") + "N" : (-rect.Top).ToString("f2") + "S");
                this.BottomLabel.Text = string.Format(BottomFormat, rect.Bottom >= 0 ? rect.Bottom.ToString("f2") + "N" : (-rect.Bottom).ToString("f2") + "S");
                this.LeftLabel.Text = string.Format(LeftFormat, rect.Left > 0 ? rect.Left.ToString("f2") + "E" : (-rect.Left).ToString("f2") + "W");
                this.RightLabel.Text = string.Format(RightFormat, rect.Right >= 0 ? rect.Right.ToString("f2") + "E" : (-rect.Right).ToString("f2") + "W");

                this.Longitude.TextContent = rect.Lng.ToString();
                this.Latitude.TextContent = rect.Lat.ToString();

                this.MapScale.TextContent = "1:100";

                this.Transparent.Color = geobitmap.smallBitmap.GetPixel(0, 0);

                
                using (Bitmap bitmap = (Bitmap)geobitmap.smallBitmap.Clone())
                {
                    bitmap.MakeTransparent(this.Transparent.Color);

                    Image img = Image.FromHbitmap(bitmap.GetHbitmap());
                    this.LayerPrevView.Image = img;
                    bitmap.Dispose();
                }
            }
            else
            {
                IsLoadLayer = false;
            }
        }

        private void Transparent_ColorChanged(object sender, EventArgs e)
        {
            if (this.LayerPrevView.Image != null)
            {
                using(Bitmap bitmap = (Bitmap)geobitmap.smallBitmap.Clone())
                {
                    bitmap.MakeTransparent(this.Transparent.Color);

                    Image img = Image.FromHbitmap(bitmap.GetHbitmap());
                    this.LayerPrevView.Image = img;
                    bitmap.Dispose();
                }
            }
        }

        private void Accept_Click()
        {
            if (this.IsLoadLayer)
                this.DialogResult = DialogResult.OK;
            else
                this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }

        private void Cancel_Click()
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }

        public string GetLayer()
        {
            if (IsLoadLayer)
            {
                return this.FilePath.TextContent;
            }
            else
                return null;
        }

        public PointLatLngAlt GetOrigin()
        {
            if (IsLoadLayer)
            {
                return new PointLatLngAlt(
                    System.Convert.ToDouble(this.Latitude.TextContent),
                    System.Convert.ToDouble(this.Longitude.TextContent),
                    System.Convert.ToDouble(this.Altitude.TextContent));
            }
            else
                return null;
        }


        public double GetScale()
        {
            if (IsLoadLayer)
            {
                if (MapScale.TextContent.Contains(":"))
                {
                    string[] data = MapScale.TextContent.Split(':');
                    return System.Convert.ToDouble(data[1]) / System.Convert.ToDouble(data[0]);
                }else if (MapScale.TextContent.Contains("："))
                {
                    string[] data = MapScale.TextContent.Split('：');
                    return System.Convert.ToDouble(data[1]) / System.Convert.ToDouble(data[0]);
                }else
                    return System.Convert.ToDouble(this.MapScale.TextContent);
            }
            else
                return 0.0;
        }


        public Color GetTransparentColor()
        {
            if (IsLoadLayer)
            {
                return this.Transparent.Color;
            }
            else
                return Color.Black;
        }



        string TopFormat = "Top：{0}";
        string BottomFormat = "Bottom：{0}";
        string LeftFormat = "Left：\n\n{0}";
        string RightFormat = "Right：\n\n{0}";
        GDAL.GDAL.GeoBitmap geobitmap;
        bool IsLoadLayer = false;
        bool IsLoadInfo = false;
    }
}
