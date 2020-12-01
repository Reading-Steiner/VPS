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
using VPS.Utilities;

namespace VPS.Controls.LoadAndSave
{
    public partial class LoadPolygon : Form
    {
        public LoadPolygon()
        {
            InitializeComponent();
            this.Load += LoadPolygon_Load;
            
        }

        private void LoadPolygon_Load(object sender, EventArgs e)
        {
            BindingDataSource();
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fd = new OpenFileDialog())
            {
                fd.Filter = "Google Earth KML(*kml;*.kmz) |*.kml;*.kmz|ShapeFile(*.shp)|*.shp";
                if (Directory.Exists(Settings.Instance["WPFileDirectory"] ?? ""))
                    fd.InitialDirectory = Settings.Instance["WPFileDirectory"];
                var result = fd.ShowDialog();

                string file = fd.FileName;
                if (result == DialogResult.OK && File.Exists(file))
                {
                    Settings.Instance["WPFileDirectory"] = Path.GetDirectoryName(file);
                    switch (fd.FilterIndex)
                    {
                        case 1:
                            {
                                var data = VPS.CustomFile.KML.ReadKML(file);
                                BindingDataSource(file, data);
                            }
                            break;
                        case 2:
                            {
                                var data = VPS.CustomFile.SHP.ReadSHP(file);
                                BindingDataSource(file, data);
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
            info = new LoadPolygonInfo();
            info.fileName = file;
            info.fileType = CustomFile.UniversalMethod.GetFileType(file);
            info.fileSize = CustomFile.UniversalMethod.GetFileSize(file);
            info.createTime = CustomFile.UniversalMethod.GetFileCreate(file);
            info.modifyTime = CustomFile.UniversalMethod.GetFileModify(file);

            info.features = new FeaturesInfo(new List<List<PointLatLngAlt>>());
            advPropertyGrid1.SelectedObject = info;
        }

        private void BindingDataSource(string file, CustomFile.SHP.SHPDataSet data)
        {
            info = new LoadSHPPolygonInfo();
            info.fileName = file;
            info.fileType = CustomFile.UniversalMethod.GetFileType(file);
            info.fileSize = CustomFile.UniversalMethod.GetFileSize(file);
            info.createTime = CustomFile.UniversalMethod.GetFileCreate(file);
            info.modifyTime = CustomFile.UniversalMethod.GetFileModify(file);
            (info as LoadSHPPolygonInfo).coordinates = data.coordinates;
            (info as LoadSHPPolygonInfo).featureType = data.featureType;
            info.features = new FeaturesInfo(data.points);
            advPropertyGrid1.SelectedObject = info;
        }

        private void BindingDataSource(string file, CustomFile.KML.KMLDataSet data)
        {
            info = new LoadKMLPolygonInfo();
            info.fileName = file;
            info.fileType = CustomFile.UniversalMethod.GetFileType(file);
            info.fileSize = CustomFile.UniversalMethod.GetFileSize(file);
            info.createTime = CustomFile.UniversalMethod.GetFileCreate(file);
            info.modifyTime = CustomFile.UniversalMethod.GetFileModify(file);

            (info as LoadKMLPolygonInfo).coordinates = data.coordinates;
            info.features = new FeaturesInfo(data.points);
            advPropertyGrid1.SelectedObject = info;
        }

        LoadPolygonInfo info;

        public List<PointLatLngAlt> GetWPList()
        {
            if (info is LoadSHPPolygonInfo)
            {
                var data = info as LoadSHPPolygonInfo;
                if (data.features.features.Count > 0 && data.features.Current != -1)
                {
                    return data.features[data.features.Current];
                }
            }

            if (info is LoadKMLPolygonInfo)
            {
                var data = info as LoadKMLPolygonInfo;
                if (data.features.features.Count > 0 && data.features.Current != -1)
                {
                    return data.features[data.features.Current];
                }
            }

            return new List<PointLatLngAlt>();
        }
    }

    class LoadPolygonInfo
    {
        [Category("打开文件"), DisplayName("文件")]
        public string fileName { get; set; }

        [Category("打开文件"), DisplayName("文件类型"), ReadOnly(false)]
        public string fileType { get; set; }

        [Category("打开文件"), DisplayName("文件大小"), ReadOnly(false)]
        public string fileSize { get; set; }

        [Category("打开文件"), DisplayName("创建时间"), ReadOnly(false)]
        public string createTime { get; set; }

        [Category("打开文件"), DisplayName("修改时间"), ReadOnly(false)]
        public string modifyTime { get; set; }

        [Category("要素集合"), DisplayName("要素集合"),
            TypeConverter(typeof(ExpandableObjectConverter)),
            Editor(typeof(CustomControls.PositionListUITypeEditor), typeof(UITypeEditor))]
        public FeaturesInfo features { get; set; }
    }

    class LoadSHPPolygonInfo : LoadPolygonInfo
    {
        [Category("要素信息"), DisplayName("投影坐标系"),
            Editor(typeof(CustomControls.ContentUITypeEditor), typeof(UITypeEditor))]
        public string coordinates { get; set; }

        [Category("要素信息"), DisplayName("要素类型"), ReadOnly(true)]
        public string featureType { get; set; } = "";

    }

    class LoadKMLPolygonInfo : LoadPolygonInfo
    {
        [Category("要素信息"), DisplayName("投影坐标系"),
            Editor(typeof(CustomControls.ContentUITypeEditor), typeof(UITypeEditor))]
        public string coordinates { get; set; }

    }
}
