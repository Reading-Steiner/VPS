using DevComponents.DotNetBar;
using DotSpatial.Projections;
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
using System.Xml;
using VPS.Utilities;

namespace VPS.Controls.LoadAndSave
{
    public partial class LoadWP : DevComponents.DotNetBar.Office2007Form
    {

        public LoadWP()
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
            info = new LoadSHPWPInfo();
            (info as LoadSHPWPInfo).coordinates = data.coordinates;
            (info as LoadSHPWPInfo).featureType = data.featureType;
            (info as LoadSHPWPInfo).features = new FeaturesInfo(data.points);
            advPropertyGrid1.SelectedObject = info;
        }

        private void BindingDataSource(CustomFile.KML.KMLDataSet data)
        {
            info = new LoadKMLWPInfo();

            (info as LoadKMLWPInfo).coordinates = data.coordinates;
            (info as LoadKMLWPInfo).features = new FeaturesInfo(data.points);
            advPropertyGrid1.SelectedObject = info;
        }

        LoadWPInfo info;

        public List<PointLatLngAlt> GetWPList()
        {
            if (info is LoadSHPWPInfo) {
                var data = info as LoadSHPWPInfo;
                if(data.features.features.Count > 0 && data.features.Current != -1)
                {
                    return data.features[data.features.Current];
                }
            }

            if (info is LoadKMLWPInfo)
            {
                var data = info as LoadKMLWPInfo;
                if (data.features.features.Count > 0 && data.features.Current != -1)
                {
                    return data.features[data.features.Current];
                }
            }

            return new List<PointLatLngAlt>();
        }
    }

    class LoadWPInfo
    {
    }

    class LoadSHPWPInfo : LoadWPInfo
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

    class LoadKMLWPInfo : LoadWPInfo
    {
        [Category("基本信息"), DisplayName("投影坐标系"),
            Editor(typeof(CustomControls.ContentUITypeEditor), typeof(UITypeEditor))]
        public string coordinates { get; set; }
        [Category("要素信息"), Description("要素信息"), DisplayName("要素集合"),
            TypeConverter(typeof(ExpandableObjectConverter)),
            Editor(typeof(CustomControls.PositionListUITypeEditor), typeof(UITypeEditor))]
        public FeaturesInfo features { get; set; }

    }

    class FeaturesInfo
    {
        public List<List<PointLatLngAlt>> features;
        int current = -1;
        public FeaturesInfo(List<List<PointLatLngAlt>> list)
        {
            features = new List<List<PointLatLngAlt>>();
            for (int i = 0; i < list.Count; i++)
            {
                List<PointLatLngAlt> feature = new List<PointLatLngAlt>(list[i]);
                features.Add(feature);
            }
            if (Count > 0)
                Current = 0;
            else
                Current = -1;
        }

        [TypeConverter(typeof(ExpandableObjectConverter)), Category("要素集合"), DisplayName("要素数量")
            , ReadOnly(true)]
        public int Count
        {
            get { return features.Count; }  
        }

        [TypeConverter(typeof(ExpandableObjectConverter)), Category("要素集合"), DisplayName("选中要素"),
            PropertyIntegerEditor(MinValue = -1, MaxValue = 100),DefaultValue(0)]
        public int Current
        {
            set
            {
                current = Count > 0 ? value % Count : -1;
            }
            get { return current; }
        }

        [TypeConverter(typeof(ExpandableObjectConverter)), Category("要素集合"), DisplayName("要素")]
        public List<PointLatLngAlt> this[int index]
        {
            set
            {
                if (value == null)
                    return;
                if (index >= features.Count)
                    features.Add(new List<PointLatLngAlt>(value));
                else if (index < 0)
                    features.Insert(0, new List<PointLatLngAlt>(value));
                else
                    features[index] = new List<PointLatLngAlt>(value);
                if (value.Count > 0 && Current == -1)
                    Current = 0;

            }
            get
            {
                return index >= 0 && index < features.Count ? features[index] : null;
            }
        }

        public override string ToString()
        {
            string str = features.Count.ToString() + ";";
            for(int i =0; i < features.Count; i++)
                str += i.ToString() + ":" + features[i].Count.ToString();
            return str;
        }
    }
}
