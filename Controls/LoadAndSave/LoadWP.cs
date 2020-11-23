using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
                fd.Filter = "Default WPFile(*kml)|*.kml|Google Earth KML(*kml;*.kmz) |*.kml;*.kmz|ShapeFile(*.shp)|*.shp";
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
                            break;
                        case 2:
                            break;
                        case 3:
                            TXT_FileType.Text = "文件类型：shp";
                            var data = VPS.CustomFile.SHP.ReadSHP(file);
                            BindingDataSource(data);
                            break;
                    }
                }
            }
        }

        #region 文件解析

        #endregion

        private void BindingDataSource(CustomFile.SHP.ShpDataSet data)
        {
            LoadWPInfo info = new LoadWPInfo();
            info.coordinates = data.coordinates;
            info.featureType = data.featureType;
            info.featureCount = data.points.Count;
            info.features = new FeaturesInfo(data.points);
            advPropertyGrid1.SelectedObject = info;
        }
    }

    class LoadWPInfo
    {
        [Category("基本信息"), Description("投影信息"), DisplayName("投影")]
        public string coordinates { get; set; }
        [Category("要素信息"), Description("要素类型"), DisplayName("类型")]
        public string featureType { get; set; }
        [Category("要素信息"), Description("要素数量"), DisplayName("数量")]
        public int featureCount { get; set; }
        [Category("要素信息"), Description("要素信息"), DisplayName("要素")]
        public FeaturesInfo features { get; set; }

    }

    class FeaturesInfo
    {
        public List<FeatureInfo> features;

        public FeaturesInfo(List<List<PointLatLngAlt>> list)
        {
            features = new List<FeatureInfo>();
            for(int i = 0; i < list.Count; i++)
            {
                FeatureInfo feature = new FeatureInfo(list[i]);
                features.Add(feature);
            }
        }

        public FeatureInfo this[int index]
        {
            set
            {
                if (value == null)
                    return;
                if (index >= features.Count)
                    features.Add(new FeatureInfo(value.Value));
                else if (index < 0)
                    features.Insert(0, new FeatureInfo(value.Value));
                else
                    features[index].Value = value.Value;
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
                str += i.ToString() + ":" + features[i].Value.Count.ToString();
            return str;
        }
    }

    public class FeatureInfo
    {
        public FeatureInfo(List<PointLatLngAlt> list)
        {
            feature = new List<PointLatLngAlt>(list);
        }

        public FeatureInfo(FeatureInfo feature)
        {
            this.Value = feature.Value;
        }

        List<PointLatLngAlt> feature = new List<PointLatLngAlt>();
        public List<PointLatLngAlt> Value
        {
            set
            {
                feature = new List<PointLatLngAlt>(value);
            }
            get
            {
                return new List<PointLatLngAlt>(feature);
            }
        }

        public override string ToString()
        {
            return feature.Count.ToString();
        }

    }
}
