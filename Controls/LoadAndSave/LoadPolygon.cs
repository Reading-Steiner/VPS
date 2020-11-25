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
                    TXT_FileName.Text = file;
                    switch (fd.FilterIndex)
                    {
                        case 1:
                            {
                                TXT_FileType.Text = "文件类型：kml";
                                List<List<PointLatLngAlt>> wpLists = new List<List<PointLatLngAlt>>();

                                var data = VPS.CustomFile.KML.ReadKML(file);
                                BindingDataSource(data);
                            }
                            break;
                        case 2:
                            {
                                TXT_FileType.Text = "文件类型：shp";
                                var data = VPS.CustomFile.SHP.ReadSHP(file);
                                BindingDataSource(data);
                            }
                            break;
                    }
                }
            }
        }

        #region 文件解析

        #endregion

        private void BindingDataSource(CustomFile.SHP.SHPDataSet data)
        {
            info = new LoadSHPPolygonInfo();
            (info as LoadSHPPolygonInfo).coordinates = data.coordinates;
            (info as LoadSHPPolygonInfo).featureType = data.featureType;
            (info as LoadSHPPolygonInfo).features = new FeaturesInfo(data.points);
            advPropertyGrid1.SelectedObject = info;
        }

        private void BindingDataSource(CustomFile.KML.KMLDataSet data)
        {
            info = new LoadKMLPolygonInfo();

            (info as LoadKMLPolygonInfo).coordinates = data.coordinates;
            (info as LoadKMLPolygonInfo).features = new FeaturesInfo(data.points);
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
    }

    class LoadSHPPolygonInfo : LoadPolygonInfo
    {
        [Category("基本信息"), DisplayName("投影坐标系"),
            Editor(typeof(CustomControls.ContentUITypeEditor), typeof(UITypeEditor))]
        public string coordinates { get; set; }
        [Category("要素信息"), Description("要素类型"), DisplayName("要素类型"), ReadOnly(true)]
        public string featureType { get; set; }
        [Category("要素信息"), Description("要素信息"), DisplayName("要素集合"),
            TypeConverter(typeof(ExpandableObjectConverter)),
            Editor(typeof(CustomControls.PositionListUITypeEditor), typeof(UITypeEditor))]
        public FeaturesInfo features { get; set; }

    }

    class LoadKMLPolygonInfo : LoadPolygonInfo
    {
        [Category("基本信息"), DisplayName("投影坐标系"),
            Editor(typeof(CustomControls.ContentUITypeEditor), typeof(UITypeEditor))]
        public string coordinates { get; set; }
        [Category("要素信息"), Description("要素信息"), DisplayName("要素集合"),
            TypeConverter(typeof(ExpandableObjectConverter)),
            Editor(typeof(CustomControls.PositionListUITypeEditor), typeof(UITypeEditor))]
        public FeaturesInfo features { get; set; }

    }
}
