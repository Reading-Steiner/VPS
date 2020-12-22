using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPS.Controls.LoadAndSave
{
    public partial class LoadLayer : Office2007Form
    {
        public LoadLayer()
        {
            InitializeComponent();

            this.Load += LoadLayer_Load;

            advPropertyGrid1.Tag = advPropertyGrid1.PropertySort;
            advPropertyGrid1.PropertySort = DevComponents.DotNetBar.ePropertySort.Categorized;
        }

        private void LoadLayer_Load(object sender, EventArgs e)
        {
            BindingDataSource();
        }

        public delegate void ProgressMessageOutTime(string message, int time);
        public delegate void ProgressMessage(string message);
        public delegate void Progress(double percent);
        public delegate void Meaasge(string message);

        public static event ProgressMessage OnProgressStart;
        public static event ProgressMessage OnProgressInfo;
        public static event ProgressMessageOutTime OnProgressEnd;
        public static event ProgressMessage OnProgressSuccess;
        public static event ProgressMessage OnProgressFailure;
        public static event Progress OnProgress;
        public static event Meaasge OnInfoMessage;
        public static event Meaasge OnWarnMessage;

        private void OpenFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fd = new OpenFileDialog())
            {
                fd.Filter = "Tag Image File Format(*.tif) |*.tif";
                if (Directory.Exists(Utilities.Settings.Instance["WPFileDirectory"] ?? ""))
                    fd.InitialDirectory = Utilities.Settings.Instance["WPFileDirectory"];
                var result = fd.ShowDialog();

                string file = fd.FileName;
                if (result == DialogResult.OK && File.Exists(file))
                {
                    Utilities.Settings.Instance["WPFileDirectory"] = Path.GetDirectoryName(file);
                    switch (fd.FilterIndex)
                    {
                        case 1:
                            {
                                BindingTiffFileDataSource(file);
                            }
                            break;
                        default:
                            BindingDataSource(file);
                            break;
                    }
                }
            }
        }

        #region 文件解析

        #endregion

        private void BindingDataSource(string file = "")
        {
            if (LocalFile.Checked)
            {
                info = new LoadLayerInfo();

                info.fileName = CustomFile.UniversalMethod.GetFileName(file);
                info.filePath = CustomFile.UniversalMethod.GetFilePath(file);
                info.fileType = CustomFile.UniversalMethod.GetFileType(file);

                advPropertyGrid1.SelectedObject = info;
            }
        }

        private void BindingTiffFileDataSource(string file)
        {
            if (LocalFile.Checked)
            {
                info = new LoadTiffLayerInfo();
                if (File.Exists(file))
                {

                    info.fileName = CustomFile.UniversalMethod.GetFileName(file);
                    info.filePath = CustomFile.UniversalMethod.GetFilePath(file);
                    info.fileType = CustomFile.UniversalMethod.GetFileType(file);
                    (info as LoadTiffLayerInfo).fileSize = CustomFile.UniversalMethod.GetFileSize(file);
                    (info as LoadTiffLayerInfo).createTime = CustomFile.UniversalMethod.GetFileCreate(file);
                    (info as LoadTiffLayerInfo).modifyTime = CustomFile.UniversalMethod.GetFileModify(file);
                }
                else
                    return;

                var imageInfo = GDAL.GDAL.LoadImageInfo(file);
                {
                    (info as LoadTiffLayerInfo).rect = new Rect();
                    (info as LoadTiffLayerInfo).rect.FromWGS84(imageInfo.Rect);

                    Utilities.PointLatLngAlt PointHome = imageInfo.Rect.LocationTopLeft;
                    PointHome.Tag = CustomData.WP.WPCommands.HomeCommand;
                    PointHome.Tag2 = "Terrain";

                    (info as LoadTiffLayerInfo).origin = new Position();
                    (info as LoadTiffLayerInfo).origin.FromLocationPoint(PointHome);

                    (info as LoadTiffLayerInfo).home = new Position();
                    (info as LoadTiffLayerInfo).home.FromLocationPoint(PointHome);

                    (info as LoadTiffLayerInfo).rasterSize = new Size(imageInfo.RasterXSize, imageInfo.RasterYSize);
                    (info as LoadTiffLayerInfo).tileSize = new Size(400, 400);
                }

                using (var ds = OSGeo.GDAL.Gdal.Open(file, OSGeo.GDAL.Access.GA_ReadOnly))
                {
                    (info as LoadTiffLayerInfo).coordinates = ds.GetProjectionRef();
                }
 
                advPropertyGrid1.SelectedObject = info;
            }
        }

        public LoadLayerInfo info;

        #region 获取转存地址
        private string GetSaveFilePath(string fileName)
        {
            string saveFilePath = Utilities.Settings.GetUserDataDirectory() +
                          ((UInt64)(fileName.GetHashCode() + DateTime.Now.ToString().GetHashCode())).
                          GetHashCode().ToString("X") +
                          System.IO.Path.DirectorySeparatorChar;
            if (!string.IsNullOrEmpty(saveFilePath))
            {
                if (File.Exists(saveFilePath))
                    return saveFilePath;
                else
                {
                    string savePath = "";
                    string saveFile = "";
                    if (saveFilePath.EndsWith(".tif"))
                    {
                        savePath = saveFilePath.Substring(0, saveFilePath.LastIndexOf('\\') + 1);
                        saveFile = saveFilePath;
                    }
                    else
                    {
                        if (saveFilePath.EndsWith("\\"))
                            savePath = saveFilePath;
                        else
                            savePath = saveFilePath + "\\";
                        saveFile = savePath + fileName;
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
            else
                return "";
        }

        private string GetTileFilePath(string fileName)
        {
            string saveFilePath = Utilities.Settings.GetUserDataDirectory() +
                ((UInt64)(fileName.GetHashCode() + DateTime.Now.ToString().GetHashCode())).
                GetHashCode().ToString("X") +
                System.IO.Path.DirectorySeparatorChar;
            if (!string.IsNullOrEmpty(saveFilePath))
            {
                string savePath = "";
                if (saveFilePath.EndsWith("\\"))
                    savePath = saveFilePath;
                else
                    savePath = saveFilePath + "\\";

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
                return "";
        }
        #endregion

        public void LoadLayerInfo()
        {
            if (LocalFile.Checked)
            {
                if (info.fileType.Contains("tif"))
                {
                    if (info.isFileTile)
                    {
                        TileAndLoadTiff(
                            info.filePath,
                            GetTileFilePath(info.fileName),
                            info as LoadTiffLayerInfo
                            );
                    }
                    else if (info.isFileSave)
                    {
                        SaveAndLoadTiff(
                            info.filePath,
                            GetSaveFilePath(info.fileName),
                            info as LoadTiffLayerInfo
                            );
                    }
                    else
                    {
                        LoadTiff(
                            info.filePath,
                            info as LoadTiffLayerInfo
                            );
                    }
                }
            }
        }

        #region 本地文件 Tiff

        #region Tiff 切片
        private void TileAndLoadTiff(string openPath, string savePath, LoadTiffLayerInfo info)
        {
            int rasterXSize = info.rasterSize.Width;
            int rasterYSize = info.rasterSize.Height;
            int tileXSize = info.tileSize.Width;
            int tileYSize = info.tileSize.Height;
            int tileXCount = (int)(rasterXSize / tileXSize) + (rasterXSize % tileXSize == 0 ? 0 : 1);
            int tileYCount = (int)(rasterYSize / tileYSize) + (rasterYSize % tileYSize == 0 ? 0 : 1);
            string vrtFileName = savePath + info.fileName + ".tif.vrt";
            List<string> tiffFileNames = new List<string>();

            OnProgressStart?.Invoke("影像切片：" + info.fileName);
            OnProgress?.Invoke(0);
            try
            {

                for (int i = 0; i < tileYCount; i++)
                {
                    for (int j = 0; j < tileXCount; j++)
                    {
                        string saveFullName = savePath + info.fileName + "_" + i + "_" + j + ".tif";
                        tiffFileNames.Add(saveFullName);
                        GDAL.GDAL.SaveTiffTile(openPath, saveFullName,
                            j * tileXSize, i * tileYSize, tileXSize, tileYSize);

                        OnProgress?.Invoke((i * tileXCount + j) / (tileYCount * tileXCount));
                    }
                }
                OnProgressInfo?.Invoke("创建VRT文件");

                GDAL.GDAL.CreateVRT(vrtFileName, tiffFileNames);

                OnInfoMessage?.Invoke(string.Format("【{0}】切片失败", openPath));
                OnProgressSuccess?.Invoke("切片成功");
            }
            catch
            {
                OnInfoMessage?.Invoke(string.Format("【{0}】切片失败", openPath));
                OnProgressFailure?.Invoke("切片失败");
            }
            finally
            {
            }
            LoadTiff(openPath, info);
        }
        #endregion

        #region Tiff 转存
        private void SaveAndLoadTiff(string openPath, string savePath, LoadTiffLayerInfo info)
        {
            try
            {
                int rasterXSize = info.rasterSize.Width;
                int rasterYSize = info.rasterSize.Height;
                GDAL.GDAL.SaveTiffTile(openPath, savePath, 0, 0, (int)rasterXSize, (int)rasterYSize);
            }
            catch
            {

            }
            finally
            {
                LoadTiff(savePath, info);
            }
        }
        #endregion

        #region Tiff 加载
        private void LoadTiff(string openPath, LoadTiffLayerInfo info)
        {
            if (info.isDefaultFile)
            {
                CustomData.WP.WPGlobalData.instance.SetLayer(
                    openPath,
                    info.isDefaultFile);
                CustomData.WP.WPGlobalData.instance.SetLayerLimit(
                    info.rect,
                    info.home,
                    info.isDefaultFile);
            }

            if ((info as LoadTiffLayerInfo).isUseTransparent)
            {
                CustomData.Layer.LayerInfo layerInfo =
                    new CustomData.Layer.TiffLayerInfo(
                        openPath, 
                        info.home, 
                        info.transparent);
                MainV2.instance.AddLayerOverlay(layerInfo);
            }
            else
            {
                CustomData.Layer.LayerInfo layerInfo =
                    new CustomData.Layer.TiffLayerInfo(
                        openPath, 
                        info.home, 
                        Color.FromArgb(0, 255, 255, 255));
                MainV2.instance.AddLayerOverlay(layerInfo);
            }
        }
        #endregion

        #endregion
    }

    [TypeConverter(typeof(PropertySorter))]
    public class LoadLayerInfo
    {
        [Category("打开文件"), DisplayName("文件名")]
        [PropertyOrder(0b00000001)]
        [Editor(typeof(CustomControls.ContentUITypeEditor), typeof(UITypeEditor))]
        public string fileName { get; set; } = "";

        [Category("打开文件"), DisplayName("文件路径")]
        [PropertyOrder(0b00000010)]
        [Editor(typeof(CustomControls.ContentUITypeEditor), typeof(UITypeEditor))]
        public string filePath { get; set; } = "";

        [Browsable(false)]
        public string fileType { get; set; } = "";

        [Category("文件存储"), Description("运行软件时，默认加载"), DisplayName("默认文件")]
        [PropertyOrder(0b01000000)]
        public bool isDefaultFile{ get; set; } = true;

        [Category("文件存储"), DisplayName("文件转存")]
        [PropertyOrder(0b01000001)]
        public bool isFileSave { get; set; } = false;

        [Browsable(false)]
        [Category("文件存储"), DisplayName("文件切片")]
        [PropertyOrder(0b01000010)]
        public bool isFileTile { get; set; } = false;
    }

    [TypeConverter(typeof(PropertySorter))]
    public class LoadLayerFileInfo : LoadLayerInfo
    {
        [Category("文件信息"), DisplayName("文件大小"), ReadOnly(false)]
        [PropertyOrder(0b00010001)]
        public string fileSize { get; set; } = "";

        [Category("文件信息"), DisplayName("创建时间"), ReadOnly(false)]
        [PropertyOrder(0b00010010)]
        public string createTime { get; set; } = "";

        [Category("文件信息"), DisplayName("修改时间"), ReadOnly(false)]
        [PropertyOrder(0b00010011)]
        public string modifyTime { get; set; } = "";
    }

    [TypeConverter(typeof(PropertySorter))]
    public class LoadTiffLayerInfo : LoadLayerFileInfo
    {
        [Category("打开文件"), DisplayName("文件类型"), ReadOnly(true)]
        [PropertyOrder(0b00001000)]
        public string openFileType { set; get; } = "Tag Image File Format";

        [Category("图层信息"), DisplayName("投影坐标系")]
        [PropertyOrder(0b00100001)]
        [Editor(typeof(CustomControls.ContentUITypeEditor), typeof(UITypeEditor))]
        public string coordinates { get; set; } = "";

        [Category("图层信息"), DisplayName("图层边界")]
        [PropertyOrder(0b00100010)]
        [Editor(typeof(CustomControls.RectUITypeEditor), typeof(UITypeEditor))]
        public Rect rect { get; set; } = new Rect();

        [Category("图层信息"), DisplayName("图层原点")]
        [PropertyOrder(0b00100011)]
        [Editor(typeof(CustomControls.PositionUITypeEditor), typeof(UITypeEditor))]
        public Position origin { get; set; } = new Position();

        [Category("图层信息"), DisplayName("初始位置")]
        [PropertyOrder(0b00100100)]
        [Editor(typeof(CustomControls.PositionUITypeEditor), typeof(UITypeEditor))]
        public Position home { get; set; } = new Position();

        [Category("图像显示"), DisplayName("图像大小")]
        [PropertyOrder(0b00110001)]
        public Size rasterSize { get; set; } = new Size();

        [Category("图像显示"), Description("可以显示更真实的图像，但是需要更多的时间加载"), DisplayName("图像切片展示")]
        [PropertyOrder(0b00110010)]
        public bool IsTile { get; set; } = false;

        [Category("图像显示"), DisplayName("切片大小")]
        [PropertyOrder(0b00110011)]
        public Size tileSize { get; set; } = new Size();

        [Category("图像显示"), Description("去除图像格式转换所带来的黑边等无关效果"), DisplayName("使用透明色")]
        [PropertyOrder(0b00110100)]
        public bool isUseTransparent { get; set; } = false;

        [Category("图像显示"), DisplayName("透明色")]
        [PropertyOrder(0b00110101)]
        public Color transparent { get; set; } = new Color();
    }
}
