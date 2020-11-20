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
using VPS.Utilities;

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
        GMap.NET.RectLatLng LayerRect;
        long FileSize = 0;
        long RasterXSize = 0;
        long RasterYSize = 0;



        #region LayerReader 文件输出状态变化

        #region 转存
        private void ImageSave_CheckedChanged(object sender, EventArgs e)
        {
            if (ImageTile.Checked && !this.ImageSave.Checked)
            {
                this.ImageSave.Checked = true;
            }
            this.SaveFileBox.Visible = this.ImageSave.Checked;
        }
        #endregion

        #region 切片
        private void ImageTile_CheckedChanged(object sender, EventArgs e)
        {
            ImageSave.Checked = ImageTile.Checked;
            SaveFileBox.Visible = ImageTile.Checked;
            TileNameBox.Visible = ImageTile.Checked;
            DefaultSavePath_Click(null, null);
        }
        #endregion

        #endregion

        #region LayerReader 获取文件输出参数

        #region 获取转存地址
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
                        string saveFile = "";
                        if (this.SaveFilePath.Text.EndsWith(".tif"))
                        {
                            savePath = this.SaveFilePath.Text.Substring(0, this.SaveFilePath.Text.LastIndexOf('\\') + 1);
                            saveFile = this.SaveFilePath.Text;
                        }
                        else
                        {
                            if (this.SaveFilePath.Text.EndsWith("\\"))
                                savePath = this.SaveFilePath.Text;
                            else
                                savePath = this.SaveFilePath.Text + "\\";
                            saveFile = savePath + FileName;
                        }
                        if (Directory.Exists(savePath))
                            return saveFile;
                        else
                        {
                            try
                            {
                                Directory.CreateDirectory(savePath);
                                return saveFile;
                            }
                            catch
                            {
                                return ".\\" + saveFile;
                            }
                        }
                    }
                }
            }
            else
                return "";
        }
        #endregion

        #region 获取切片名称
        private string GetTileName(int xIndex, int yIndex)
        {
            string TileFormat = this.TileName.Text.ToLower();
            TileFormat = TileFormat.Replace("{name}", FileName);
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
        #endregion

        #endregion

        #region LayerReader 文件参数生成操作

        #region 还原默认转存地址
        private void DefaultSavePath_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(this.OpenFilePath.Text))
            {
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
        #endregion

        #region 还原默认切片命名
        private void DefaultTileName_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(this.OpenFilePath.Text))
            {
                this.TileName.Text = "{name}.{x}_{y}";
            }
        }
        #endregion

        #region 获取转存位置
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
        #endregion

        #endregion

        #region LayerReader 全局操作

        #region 清空参数
        private void Clear()
        {
            FileName = "";
            FullFileName = "";
            FileExtend = "";
            LayerRect = new GMap.NET.RectLatLng();
            FileSize = 0;
            RasterXSize = 0;
            RasterYSize = 0;
            this.BoundLeftText.Text = "";
            this.BoundRightText.Text = "";
            this.BoundTopText.Text = "";
            this.BoundBottomText.Text = "";
            this.Projection.Text = "";
            bitmap = null;
            ShowGeoBitmap();
        }
        #endregion

        #endregion

        #region LayerReader 文件类型切换

        #region Tiff
        private void FromFile_CheckedChanged(object sender, EventArgs e)
        {
            this.FileReaderBox.Visible = this.FromFile.Checked || this.FromTile.Checked;
            if (this.FromFile.Checked)
                OpenFile.Click += OpenFileFromTiff_Click;
            else
                OpenFile.Click -= OpenFileFromTiff_Click;
            if (!OpenFilePath.Text.EndsWith(".tif"))
            {
                OpenFilePath.Text = "";
                Clear();
            }
        }
        #endregion

        #region VRT Tile
        private void FromTile_CheckedChanged(object sender, EventArgs e)
        {
            this.FileReaderBox.Visible = this.FromTile.Checked || this.FromFile.Checked;
            if (this.FromTile.Checked)
                OpenFile.Click += OpenFileFromVRT_Click;
            else
                OpenFile.Click -= OpenFileFromVRT_Click;
            if (!OpenFilePath.Text.EndsWith(".vrt"))
            {
                OpenFilePath.Text = "";
                Clear();
            }
        }
        #endregion

        #endregion

        #region 打开文件

        #region 响应
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
        #endregion

        #region Tiff
        private void OpenFileFromTiff_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                if (FromFile.Checked)
                {
                    openFile.Filter = "TIFF地理影像(*.tif)|*.tif";
                    openFile.ShowDialog();
                }else if (FromTile.Checked)
                {
                    openFile.Filter = "TIFF切片地理影像(*.vrt)|*.vrt";
                    openFile.ShowDialog();
                }
                if (System.IO.File.Exists(openFile.FileName))
                {
                    this.OpenFilePath.Text = openFile.FileName;
                    try
                    {
                        var info = GDAL.GDAL.LoadImageInfo(openFile.FileName);
                        {
                            this.BoundLeftText.Text = info.Rect.Left.ToString("0.000000");
                            this.BoundRightText.Text = info.Rect.Right.ToString("0.000000");
                            this.BoundTopText.Text = info.Rect.Top.ToString("0.000000");
                            this.BoundBottomText.Text = info.Rect.Bottom.ToString("0.000000");
                            RasterXSize = info.RasterXSize;
                            RasterYSize = info.RasterYSize;
                            LayerRect = info.Rect;

                            PointLatLngAlt PointHome = info.Rect.LocationTopLeft;
                            PointHome.Tag = CustomData.WP.WPCommands.HomeCommand;
                            PointHome.Tag2 = "Terrain";
                            OriginPosition.WGS84Position = PointHome; 
                        }
                    }
                    catch (Exception ex) {

                    }
                    try
                    {
                        using (var ds = OSGeo.GDAL.Gdal.Open(openFile.FileName, OSGeo.GDAL.Access.GA_ReadOnly))
                        {
                            this.Projection.Text = ds.GetProjectionRef();
                        }
                    }
                    catch (Exception ex) {
                        this.Projection.Text = ex.Message;
                    }
                    FileInfo fileInfo = new FileInfo(openFile.FileName);
                    {
                        FileName = fileInfo.Name;
                        FullFileName = fileInfo.FullName;
                        FileExtend = fileInfo.Extension;
                        FileSize = fileInfo.Length;

                    }
                    DefaultSavePath_Click(null, null);
                    bitmap = null;
                    ShowGeoBitmapHandle?.Invoke();
                }
            }
        }
        #endregion

        #region VRT Tile
        private void OpenFileFromVRT_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Filter = "TIFF切片地理影像(*.vrt)|*.vrt";
                openFile.ShowDialog();
                if (System.IO.File.Exists(openFile.FileName))
                {
                    this.OpenFilePath.Text = openFile.FileName;
                    try
                    {
                        var info = GDAL.GDAL.LoadImageInfo(openFile.FileName);
                        {
                            this.BoundLeftText.Text = info.Rect.Left.ToString("0.000000");
                            this.BoundRightText.Text = info.Rect.Right.ToString("0.000000");
                            this.BoundTopText.Text = info.Rect.Top.ToString("0.000000");
                            this.BoundBottomText.Text = info.Rect.Bottom.ToString("0.000000");
                            RasterXSize = info.RasterXSize;
                            RasterYSize = info.RasterYSize;
                            LayerRect = info.Rect;
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    try
                    {
                        using (var ds = OSGeo.GDAL.Gdal.Open(openFile.FileName, OSGeo.GDAL.Access.GA_ReadOnly))
                        {
                            this.Projection.Text = ds.GetProjectionRef();
                        }
                    }
                    catch (Exception ex)
                    {
                        this.Projection.Text = ex.Message;
                    }
                    FileInfo fileInfo = new FileInfo(openFile.FileName);
                    {
                        FileName = fileInfo.Name;
                        FullFileName = fileInfo.FullName;
                        FileExtend = fileInfo.Extension;
                        FileSize = fileInfo.Length;

                    }
                    DefaultSavePath_Click(null, null);
                    bitmap = null;
                    ShowGeoBitmapHandle?.Invoke();
                }
            }
        }
        #endregion

        #endregion

        #region LayerReader 确认

        #region Tiff
        #region Tiff 入口函数
        private void Accept_Click(object sender, EventArgs e)
        {
            if (ImageTile.Checked)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(TileAndLoadTiff));
            }
            else
            {
                if (ImageSave.Checked)
                {
                    SaveAndLoadTiff();
                }
                else
                {
                    LoadTiff();
                }
            }
        }
        #endregion

        #region Tiff 切片
        private void TileAndLoadTiff(object obj)
        {
            string openPath = OpenFilePath.Text;

            string savePath = GetSaveFilePath();

            int tileXSize = TileXSize.Value;
            int tileYSize = TileYSize.Value;
            int tileXCount = (int)(RasterXSize / tileXSize) + (RasterXSize % tileXSize == 0 ? 0 : 1);
            int tileYCount = (int)(RasterYSize / tileYSize) + (RasterYSize % tileYSize == 0 ? 0 : 1);
            string vrtFileName = savePath + FileName + ".tif.vrt";
            List<string> tiffFileNames = new List<string>();

            string key = MainInfo.TopMainInfo.instance.CreateProgress("影像切片：" + FileName, tileXCount * tileYCount + 1);
            try
            {

                for (int i = 0; i < tileYCount; i++)
                {
                    for (int j = 0; j < tileXCount; j++)
                    {
                        string saveFullName = savePath + GetTileName(j, i) + ".tif";
                        tiffFileNames.Add(saveFullName);
                        GDAL.GDAL.SaveTiffTile(openPath, saveFullName,
                            j * tileXSize, i * tileYSize, tileXSize, tileYSize);

                        MainInfo.TopMainInfo.instance.GetProgress(key).SetProgress(i * tileXCount + j);
                    }
                }
                MainInfo.TopMainInfo.instance.GetProgress(key).SetProgressStageInfo("创建VRT文件", Color.Orange, 1, 1);
                GDAL.GDAL.CreateVRT(vrtFileName, tiffFileNames);
                MainInfo.TopMainInfo.instance.GetProgress(key).SetProgressSuccessful("切片成功");
            }
            catch
            {
                MainInfo.TopMainInfo.instance.GetProgress(key).SetProgressFailure("切片失败");
            }
            finally
            {
                VPS.Controls.MainInfo.TopMainInfo.instance.DisposeControlEnter(key, 2000);
            }
            //LoadTile();
        }
        #endregion

        #region Tiff 转存
        private void SaveAndLoadTiff()
        {
            string openPath = OpenFilePath.Text;

            string savePath = GetSaveFilePath();
            try
            {
                GDAL.GDAL.SaveTiffTile(openPath, savePath, 0, 0, (int)RasterXSize, (int)RasterYSize);
            }
            catch
            {

            }
            finally
            {
                LoadTiff();
            }
        }
        #endregion

        #region Tiff 加载
        private void LoadTiff()
        {
            string openPath = "";
            if (ImageSave.Checked)
                //openPath = GetSaveFilePath();
                openPath = SaveFilePath.Text;
            else
                openPath = OpenFilePath.Text;
            if (UsingTransparent.Checked)
            {
                CustomData.Layer.LayerInfo layerInfo =
                    new CustomData.Layer.TiffLayerInfo(openPath, OriginPosition.WGS84Position, ColorPickerButton.SelectedColor);
                MainV2.instance.AddLayerOverlay(layerInfo);
            }
            else
            {
                CustomData.Layer.LayerInfo layerInfo =
                    new CustomData.Layer.TiffLayerInfo(openPath, OriginPosition.WGS84Position, Color.FromArgb(0, 255, 255, 255));
                MainV2.instance.AddLayerOverlay(layerInfo);
            }
            if (SettingDefaultMap.Checked)
            {
                CustomData.WP.WPGlobalData.instance.SetLayer(openPath, SettingDefaultMap.Checked);
                CustomData.WP.WPGlobalData.instance.SetLayerLimit(this.LayerRect, OriginPosition.WGS84Position, SettingDefaultMap.Checked);
            }
        }
        #endregion

        #endregion

        #endregion

        #region LayerReader 参数调整

        #region 使用透明色状态更改
        private void UsingTransparent_CheckedChanged(object sender, EventArgs e)
        {
            this.TransparentBox.Visible = UsingTransparent.Checked;
        }
        #endregion

        #region 透明色更改
        private void ColorPickerButton_SelectedColorChanged(object sender, EventArgs e)
        {
            TransparentDisplay.BackColor = this.ColorPickerButton.SelectedColor;
            ShowGeoBitmapHandle?.Invoke();
        }
        #endregion

        #region 默认地图状态更改
        private void SettingDefaultMap_CheckedChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region 显示地理参数
        private void ShowCoordinates_CheckedChanged(object sender, EventArgs e)
        {
            this.BoundBox.Visible = this.ShowCoordinates.Checked;
        }
        #endregion

        #endregion

        #region LayerReader 预览模块

        #region 入口函数
        private void Preview_Click(object sender, EventArgs e)
        {
            IsShowPreview = !IsShowPreview;
        }
        #endregion

        #region 显示预览图象
        Bitmap bitmap = null;
        private void ShowGeoBitmap()
        {
            if (bitmap == null)
            {
                bitmap = CreateBitMap();
                if (bitmap == null)
                {
                    PreviewBox.Visible = false;
                    return;
                }
            }
            PreviewBox.Visible = true;
            Image img = Image.FromHbitmap(bitmap.GetHbitmap());
            DisplayImagePanel.BackgroundImage = img;

        }
        #endregion

        #region 预览状态
        private delegate void delegateHandle();
        private delegateHandle ShowGeoBitmapHandle;

        bool isShowPreview = false;
        bool IsShowPreview
        {
            get { return isShowPreview; }
            set
            {
                isShowPreview = value;
                if (isShowPreview)
                {
                    ShowGeoBitmapHandle -= ShowGeoBitmap;
                    ShowGeoBitmapHandle += ShowGeoBitmap;
                    ShowGeoBitmapHandle?.Invoke();
                }
                else
                {
                    ShowGeoBitmapHandle -= ShowGeoBitmap;
                    PreviewBox.Visible = false;
                }
            }
        }
        #endregion

        #region 获取预览图象
        Bitmap CreateBitMap()
        {
            if (!File.Exists(OpenFilePath.Text))
                return null;
            try
            {
                var info = GDAL.GDAL.LoadImageInfo(OpenFilePath.Text);
                if (UsingTransparent.Checked)
                    info.PreviewBitmap.MakeTransparent(ColorPickerButton.SelectedColor);
                else
                    info.PreviewBitmap.MakeTransparent();
                return info.PreviewBitmap;
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #endregion
    }
}
