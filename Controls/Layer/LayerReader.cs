using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Text.RegularExpressions;
using System.IO;

namespace VPS.Controls.Layer
{
    public partial class LayerReader : UserControl
    {
        public LayerReader()
        {
            InitializeComponent();
            ColorPickerButton.SelectedColor = Color.FromArgb(255, 0, 0, 0);
        }

        string FileName = "";
        string FullFileName = "";
        string FileExtend = "";
        Utilities.PointLatLngAlt PointLeftTop;
        long FileSize = 0;
        long RasterXSize = 0;
        long RasterYSize = 0;



        private void ShowCoordinates_CheckedChanged(object sender, EventArgs e)
        {
            this.BoundBox.Visible = this.ShowCoordinates.Checked;
        }

        private void FromFile_CheckedChanged(object sender, EventArgs e)
        {
            this.FileReaderBox.Visible = this.FromFile.Checked;
        }

        private void ImageSave_CheckedChanged(object sender, EventArgs e)
        {
            if (ImageTile.Checked && !this.ImageSave.Checked)
            {
                this.ImageSave.Checked = true;
            }
            this.SaveFileBox.Visible = this.ImageSave.Checked;
        }

        private void DefaultSavePath_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(this.OpenFilePath.Text)) {
                if (ImageTile.Checked)
                {
                    this.SaveFilePath.Text = Utilities.Settings.GetUserDataDirectory() +
                          ((UInt64)(FileName.GetHashCode() + DateTime.Now.ToString().GetHashCode())).
                          GetHashCode().ToString("X") +
                          System.IO.Path.DirectorySeparatorChar;
                }
                else
                {
                    this.SaveFilePath.Text = Utilities.Settings.GetUserDataDirectory() +
                          ((UInt64)(FileName.GetHashCode() + DateTime.Now.ToString().GetHashCode())).
                          GetHashCode().ToString("X") +
                          System.IO.Path.DirectorySeparatorChar +
                          FileName;
                }
            }
        }

        private void DefaultTileName_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(this.OpenFilePath.Text))
            {
                System.IO.FileInfo info = new System.IO.FileInfo(this.OpenFilePath.Text);
                var FileInfo = new System.IO.FileInfo(this.OpenFilePath.Text);
                this.TileName.Text = info.Name + "{x}_{y}";
            }
        }

        private void SaveFile_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFile = new SaveFileDialog())
            {
                saveFile.Filter = "TIFF地理影像(*.tif)|*.tif";
                saveFile.ShowDialog();
                if (System.IO.File.Exists(saveFile.FileName))
                {
                    this.SaveFilePath.Text = saveFile.FileName;
                }
            }
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Filter = "TIFF地理影像(*.tif)|*.tif";
                openFile.ShowDialog();
                if (System.IO.File.Exists(openFile.FileName))
                {
                    this.OpenFilePath.Text = openFile.FileName;
                    using (var ds = OSGeo.GDAL.Gdal.Open(openFile.FileName, OSGeo.GDAL.Access.GA_ReadOnly))
                    {
                        this.Projection.Text = ds.GetProjectionRef();
                    }
                    var info = GDAL.GDAL.LoadImageInfo(openFile.FileName);
                    {
                        this.BoundLeftText.Text = info.Rect.Left.ToString("0.000000");
                        this.BoundRightText.Text = info.Rect.Right.ToString("0.000000");
                        this.BoundTopText.Text = info.Rect.Top.ToString("0.000000");
                        this.BoundBottomText.Text = info.Rect.Bottom.ToString("0.000000");
                        RasterXSize = info.RasterXSize;
                        RasterYSize = info.RasterYSize;
                        PointLeftTop = info.Rect.LocationTopLeft;
                    }
                    FileInfo fileInfo = new FileInfo(openFile.FileName);
                    {
                        FileName = fileInfo.Name;
                        FullFileName = fileInfo.FullName;
                        FileExtend = fileInfo.Extension;
                        FileSize = fileInfo.Length;

                    }
                    DefaultSavePath_Click(null, null);
                }
            }
        }

        private void ImageTile_CheckedChanged(object sender, EventArgs e)
        {
            ImageSave.Checked = ImageTile.Checked;
            SaveFileBox.Visible = ImageTile.Checked;
            TileNameBox.Visible = ImageTile.Checked;
            DefaultSavePath_Click(null, null);
        }

        private void Accept_Click(object sender, EventArgs e)
        {
            if (ImageTile.Checked)
            {
                SaveTile();
            }
            else
            {
                if (ImageSave.Checked) {
                    SaveAndLoadImage();
                }
                else
                {
                    LoadImage();
                }
            }
        }

        private void SaveTile()
        {
            string openPath = OpenFilePath.Text;

            string savePath = GetSaveFilePath();

            int tileXSize = 400;
            int tileYSize = 400;
            int tileXCount = (int)(RasterXSize / tileXSize);
            int tileYCount = (int)(RasterYSize / tileYSize);

            for (int i = 0; i <= tileYCount; i++)
            {
                for (int j = 0; j <= tileXCount; j++)
                {
                    string saveFullName = savePath + GetTileName(j, i) + ".tif.tif";
                    GDAL.GDAL.SaveTiffTile(openPath, saveFullName,
                        j * tileXSize, i * tileYSize, tileXSize, tileYSize);
                }
            }
            LoadTile();
        }
        

        private void LoadTile()
        {
            string openPath = OpenFilePath.Text;
            
        }

        private void SaveAndLoadImage()
        {
            string openPath = OpenFilePath.Text;

            string savePath = GetSaveFilePath();
            GDAL.GDAL.SaveTiffTile(openPath, savePath, 0, 0, (int)RasterXSize, (int)RasterYSize);

            LoadImage();
        }
        

        private void LoadImage()
        {
            string openPath = OpenFilePath.Text;
            if (UsingTransparent.Checked)
            {
                MainV2.instance.AddLayerOverlay(openPath, PointLeftTop, ColorPickerButton.SelectedColor);
            }
            else
            {
                MainV2.instance.AddLayerOverlay(openPath, PointLeftTop, Color.Transparent);
            }
        }

        private string GetSaveFilePath()
        {
            if (ImageSave.Checked && !string.IsNullOrEmpty(this.SaveFilePath.Text))
            {
                if (ImageTile.Checked)
                {
                    string savePath = "";
                    if (this.SaveFilePath.Text.EndsWith("\\"))
                        savePath = this.SaveFilePath.Text;
                    else
                        savePath = this.SaveFilePath.Text + "\\";

                    if (Directory.Exists(savePath))
                        return savePath;
                    try
                    {
                        Directory.CreateDirectory(savePath);
                        return savePath;
                    }
                    catch
                    {
                        return "";
                    }
                }
                else
                {
                    if (File.Exists(this.SaveFilePath.Text))
                        return this.SaveFilePath.Text;
                    else
                    {
                        string savePath = "";
                        if (this.SaveFilePath.Text.EndsWith("\\"))
                            savePath = this.SaveFilePath.Text;
                        else
                            savePath = this.SaveFilePath.Text + "\\";
                        if (Directory.Exists(this.SaveFilePath.Text))
                            return savePath + FileName;
                        else
                        {
                            try
                            {
                                Directory.CreateDirectory(savePath);
                                return savePath + FileName;
                            }
                            catch
                            {
                                return "";
                            }
                        }
                    }
                }
            }
            else
                return "";
        }

        private string GetTileName(int xIndex, int yIndex)
        {
            string TileFormat = this.TileName.Text;
            var res = Regex.Matches(TileFormat, "[{][^{}]*[}]");
            foreach (Match data in res)
            {
                string str = data.Value;
                string newStr = str.Replace("{", "").
                    Replace("}", "").
                    Replace("x", xIndex.ToString()).
                    Replace("y", yIndex.ToString());
                int a = (int)new DataTable().Compute(newStr, "");
                TileFormat = TileFormat.Replace(str, a.ToString());
            }
            return TileFormat;
        }

        private void UsingTransparent_CheckedChanged(object sender, EventArgs e)
        {
            this.TransparentBox.Visible = UsingTransparent.Checked;
        }

        private void OpenFilePath_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(this.OpenFilePath.Text))
            {
                Accept.Enabled = true;
            }
            else
            {
                Accept.Enabled = false;
            }
        }

        private void ColorPickerButton_SelectedColorChanged(object sender, EventArgs e)
        {
            TransparentDisplay.BackColor = this.ColorPickerButton.SelectedColor;
        }
    }
}
