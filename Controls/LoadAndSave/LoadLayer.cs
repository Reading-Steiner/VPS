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
    public partial class LoadLayer : Form
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
            if (IsLocalFile.Checked)
            {
                info = new LoadLayerInfo();
                info.fileName = file;
                info.fileType = CustomFile.UniversalMethod.GetFileType(file);

                advPropertyGrid1.SelectedObject = info;
            }
        }

        private void BindingTiffFileDataSource(string file)
        {
            if (IsLocalFile.Checked)
            {
                info = new LoadTiffLayerInfo();
                if (File.Exists(file)) {
                    info.fileName = file;
                    info.fileType = CustomFile.UniversalMethod.GetFileType(file);
                    (info as LoadTiffLayerInfo).fileSize = CustomFile.UniversalMethod.GetFileSize(file);
                    (info as LoadTiffLayerInfo).createTime = CustomFile.UniversalMethod.GetFileCreate(file);
                    (info as LoadTiffLayerInfo).modifyTime = CustomFile.UniversalMethod.GetFileModify(file);
                } else
                    return;

                using (var ds = OSGeo.GDAL.Gdal.Open(file, OSGeo.GDAL.Access.GA_ReadOnly))
                {
                    (info as LoadTiffLayerInfo).coordinates = ds.GetProjectionRef();
                }

                var imageInfo = GDAL.GDAL.LoadImageInfo(file);
                {
                    (info as LoadTiffLayerInfo).rect = new Rect();
                    (info as LoadTiffLayerInfo).rect.FromLocationRect(imageInfo.Rect);

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
                
                advPropertyGrid1.SelectedObject = info;
            }
        }

        LoadLayerInfo info;

        //public List<PointLatLngAlt> GetWPList()
        //{
        //    if (info is LoadSHPPolygonInfo)
        //    {
        //        var data = info as LoadSHPPolygonInfo;
        //        if (data.features.features.Count > 0 && data.features.Current != -1)
        //        {
        //            return data.features[data.features.Current];
        //        }
        //    }

        //    if (info is LoadKMLPolygonInfo)
        //    {
        //        var data = info as LoadKMLPolygonInfo;
        //        if (data.features.features.Count > 0 && data.features.Current != -1)
        //        {
        //            return data.features[data.features.Current];
        //        }
        //    }

        //    return new List<PointLatLngAlt>();
        //}
    }

    [TypeConverter(typeof(PropertySorter))]
    class LoadLayerInfo
    {
        [Category("打开文件"), DisplayName("文件")]
        [PropertyOrder(0b00000001)]
        [Editor(typeof(CustomControls.ContentUITypeEditor), typeof(UITypeEditor))]
        public string fileName { get; set; } = "";

        [Browsable(false)]
        public string fileType { get; set; } = "";
    }

    [TypeConverter(typeof(PropertySorter))]
    class LoadLayerFileInfo : LoadLayerInfo
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
    class LoadTiffLayerInfo : LoadLayerFileInfo
    {
        [Category("打开文件"), DisplayName("文件类型"), ReadOnly(true)]
        [PropertyOrder(0b00000010)]
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
        [PropertyOrder(0b00100011)]
        [Editor(typeof(CustomControls.PositionUITypeEditor), typeof(UITypeEditor))]
        public Position home { get; set; } = new Position();

        [Category("图像显示"), DisplayName("规模")]
        [PropertyOrder(0b00110001)]
        public Size rasterSize { get; set; } = new Size();

        [Category("图像显示"), DisplayName("切片")]
        [PropertyOrder(0b00110010)]
        public Size tileSize { get; set; } = new Size();

        [Category("图像显示"), DisplayName("使用透明色")]
        [PropertyOrder(0b00110011)]
        public bool IsUseTransparent { get; set; } = false;

        [Category("图像显示"), DisplayName("透明色")]
        [PropertyOrder(0b00110100)]
        public Color Transparent { get; set; } = new Color();
    }
}
