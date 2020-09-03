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
using CCWin;
using System.Runtime.InteropServices;

namespace VPS.Controls
{
    public partial class LayerReader : CCSkinMain
    {

        public LayerReader()
        {
            InitializeComponent();
            this.Latitude.TextChange += GetOriginAlt;
            this.Longitude.TextChange += GetOriginAlt;
            this.RetButton.OnOK += OnAccept;
            this.RetButton.OnCancel += OnCancel;
        }


        [DllImport("user32.dll", EntryPoint = "AnimateWindow")]
        private static extern bool AnimateWindow(IntPtr handle, int ms, int flags);
        public const Int32 AW_HOR_POSITIVE = 0x00000001;
        public const Int32 AW_HOR_NEGATIVE = 0x00000002;
        public const Int32 AW_VER_POSITIVE = 0x00000004;
        public const Int32 AW_VER_NEGATIVE = 0x00000008;
        public const Int32 AW_CENTER = 0x00000010;
        public const Int32 AW_HIDE = 0x00010000;
        public const Int32 AW_ACTIVATE = 0x00020000;
        public const Int32 AW_SLIDE = 0x00040000;
        public const Int32 AW_BLEND = 0x00080000;

        private void OnAccept()
        {
            if (this.IsLoadLayer)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
                this.DialogResult = DialogResult.Cancel;
        }


        private void OnCancel()
        {
            this.DialogResult = DialogResult.Cancel;
        }


        private void GetOriginAlt()
        {
            this.Altitude.SetTextContent(
                srtm.getAltitude(
                    System.Convert.ToDouble(this.Latitude.GetTextContent()),
                    System.Convert.ToDouble(this.Longitude.GetTextContent())
                    ).alt.ToString());
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

            this.Longitude.SetTextContent(0.ToString());
            this.Latitude.SetTextContent(0.ToString());
            this.Altitude.SetTextContent(0.ToString());
            this.MapScale.SetTextContent("1:200");

            this.FilePath.SetTextContent(path);

            this.Latitude.TextChange += GetOriginAlt;
            this.Longitude.TextChange += GetOriginAlt;
            Func<string, GDAL.GDAL.GeoBitmap> GetGeoBitmap = (filePath) =>
                {
                    var bitmap = GDAL.GDAL.LoadImageInfo(filePath);
                    Image img = Image.FromHbitmap(bitmap.smallBitmap.GetHbitmap());
                    return bitmap;
                };
            IAsyncResult iarLoadBitmap = GetGeoBitmap.BeginInvoke(path, CallbackWhenLoadBitmapDone, this);
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
                SetLimitBox(rect.Top, rect.Bottom, rect.Left, rect.Right);

                this.Longitude.SetTextContent(rect.Lng.ToString());
                this.Latitude.SetTextContent(rect.Lat.ToString());

                this.MapScale.SetTextContent("1:100");

                SetTransparent(geobitmap.smallBitmap.GetPixel(0, 0));


                using (Bitmap bitmap = (Bitmap)geobitmap.smallBitmap.Clone())
                {
                    bitmap.MakeTransparent(GetTransparent());

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

        private delegate void SetTransparentCallback(Color color);
        private void SetTransparent(Color color)
        {
            if (this.InvokeRequired)
            {
                SetTransparentCallback callbak = new SetTransparentCallback(SetTransparent);
                this.Invoke(callbak, new object[] { color });
            }
            else
            {
                this.Transparent.Color = color;
            }
        }

        private delegate Color GetTransparentCallback();
        private Color GetTransparent()
        {
            if (this.InvokeRequired)
            {
                GetTransparentCallback callbak = new GetTransparentCallback(GetTransparent);
                IAsyncResult ir = this.BeginInvoke(callbak);
                return (Color)this.EndInvoke(ir);
            }
            else
            {
                return this.Transparent.Color;
            }
        }

        private delegate void SetLimitBoxCallbak(double top, double bottom, double left, double right);
        private void SetLimitBox(double top, double bottom, double left, double right)
        {
            if (this.InvokeRequired)
            {
                SetLimitBoxCallbak callbak = new SetLimitBoxCallbak(SetLimitBox);
                this.Invoke(callbak, new object[] { top, bottom, left, right });
            }
            else
            {
                this.TopLabel.Text = string.Format(TopFormat,
                    top >= 0 ? top.ToString("f2") + "N" : (-top).ToString("f2") + "S");
                this.BottomLabel.Text = string.Format(BottomFormat,
                    bottom >= 0 ? bottom.ToString("f2") + "N" : (-bottom).ToString("f2") + "S");
                this.LeftLabel.Text = string.Format(LeftFormat,
                    left > 0 ? left.ToString("f2") + "E" : (-left).ToString("f2") + "W");
                this.RightLabel.Text = string.Format(RightFormat,
                    right >= 0 ? right.ToString("f2") + "E" : (-right).ToString("f2") + "W");
            }
        }

        private void Transparent_ColorChanged(object sender, EventArgs e)
        {
            if (this.LayerPrevView.Image != null)
            {
                using(Bitmap bitmap = (Bitmap)geobitmap.smallBitmap.Clone())
                {
                    bitmap.MakeTransparent(GetTransparent());

                    Image img = Image.FromHbitmap(bitmap.GetHbitmap());
                    this.LayerPrevView.Image = img;
                    bitmap.Dispose();
                }
            }
        }

        public string GetLayer()
        {
            if (IsLoadLayer)
            {
                return this.FilePath.GetTextContent();
            }
            else
                return null;
        }

        public PointLatLngAlt GetOrigin()
        {
            if (IsLoadLayer)
            {
                return new PointLatLngAlt(
                    System.Convert.ToDouble(this.Latitude.GetTextContent()),
                    System.Convert.ToDouble(this.Longitude.GetTextContent()),
                    System.Convert.ToDouble(this.Altitude.GetTextContent()));
            }
            else
                return null;
        }


        public double GetScale()
        {
            if (IsLoadLayer)
            {
                if (MapScale.GetTextContent().Contains(":"))
                {
                    string[] data = MapScale.GetTextContent().Split(':');
                    return System.Convert.ToDouble(data[1]) / System.Convert.ToDouble(data[0]);
                }else if (MapScale.GetTextContent().Contains("："))
                {
                    string[] data = MapScale.GetTextContent().Split('：');
                    return System.Convert.ToDouble(data[1]) / System.Convert.ToDouble(data[0]);
                }else
                    return System.Convert.ToDouble(this.MapScale.GetTextContent());
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

        public bool GetApplyTile()
        {
            return this.ImageTileBox.Checked;
        }

        string TopFormat = "Top：{0}";
        string BottomFormat = "Bottom：{0}";
        string LeftFormat = "Left：\n\n{0}";
        string RightFormat = "Right：\n\n{0}";
        GDAL.GDAL.GeoBitmap geobitmap;
        bool IsLoadLayer = false;

    }
}






