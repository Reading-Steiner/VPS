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
            
            this.Load += LoadWP_Load;

            advPropertyGrid1.Tag = advPropertyGrid1.PropertySort;
            advPropertyGrid1.PropertySort = DevComponents.DotNetBar.ePropertySort.Categorized;
        }

        private void LoadWP_Load(object sender, EventArgs e)
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
                                string porgressKey = VPS.Controls.MainInfo.TopMainInfo.instance.CreateProgressEnter("加载 KML");
                                string messageKey = VPS.Controls.MainInfo.TopMainInfo.instance.CreateMessageBoxEnter();
                                var bar = VPS.Controls.MainInfo.TopMainInfo.instance.GetProgress(porgressKey);
                                var box = VPS.Controls.MainInfo.TopMainInfo.instance.GetMessageBox(messageKey);

                                var kml = new VPS.CustomFile.KML();
                                kml.OnProgressStart += bar.SetProgressText;
                                kml.OnProgressInfo += bar.SetProgressText;
                                kml.OnProgressFailure += bar.SetProgressFailure;
                                kml.OnProgressSuccess += bar.SetProgressSuccess;
                                kml.OnProgress += bar.SetProgress;
                                kml.OnWarnMessage += box.SetWarnMessage;
                                kml.OnInfoMessage += box.SetInfoMessage;

                                try
                                {
                                    var data = kml.ReadKML(file);
                                    BindingDataSource(file, data);
                                }
                                catch (Exception ex) { }
                                finally
                                {
                                    if (porgressKey != null)
                                        VPS.Controls.MainInfo.TopMainInfo.instance.DisposeControlEnter(porgressKey, 2000);
                                    if (messageKey != null)
                                        VPS.Controls.MainInfo.TopMainInfo.instance.DisposeControlEnter(messageKey, 5000);
                                }
                                
                            }
                            break;
                        case 2:
                            {
                                string porgressKey = VPS.Controls.MainInfo.TopMainInfo.instance.CreateProgressEnter("加载 ShapeFile");
                                string messageKey = VPS.Controls.MainInfo.TopMainInfo.instance.CreateMessageBoxEnter();
                                var bar = VPS.Controls.MainInfo.TopMainInfo.instance.GetProgress(porgressKey);
                                var box = VPS.Controls.MainInfo.TopMainInfo.instance.GetMessageBox(messageKey);

                                var shp = new VPS.CustomFile.SHP();
                                shp.OnProgressStart += bar.SetProgressText;
                                shp.OnProgressInfo += bar.SetProgressText;
                                shp.OnProgressFailure += bar.SetProgressFailure;
                                shp.OnProgressSuccess += bar.SetProgressSuccess;
                                shp.OnProgress += bar.SetProgress;
                                shp.OnWarnMessage += box.SetWarnMessage;
                                shp.OnInfoMessage += box.SetInfoMessage;

                                try
                                {
                                    var data = shp.ReadSHP(file);
                                    BindingDataSource(file, data);
                                }
                                catch (Exception ex) { }
                                finally
                                {
                                    if (porgressKey != null)
                                        VPS.Controls.MainInfo.TopMainInfo.instance.DisposeControlEnter(porgressKey, 2000);
                                    if (messageKey != null)
                                        VPS.Controls.MainInfo.TopMainInfo.instance.DisposeControlEnter(messageKey, 5000);
                                }
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
            info = new LoadWPInfo();

            info.fileName = file;
            info.fileType = CustomFile.UniversalMethod.GetFileType(file);

            advPropertyGrid1.SelectedObject = info;
        }

        private void BindingDataSource(string file, CustomFile.SHP.SHPDataSet data)
        {
            info = new LoadSHPWPInfo();

            info.fileName = file;
            info.fileType = CustomFile.UniversalMethod.GetFileType(file);

            (info as LoadSHPWPInfo).fileSize = CustomFile.UniversalMethod.GetFileSize(file);
            (info as LoadSHPWPInfo).createTime = CustomFile.UniversalMethod.GetFileCreate(file);
            (info as LoadSHPWPInfo).modifyTime = CustomFile.UniversalMethod.GetFileModify(file);

            (info as LoadSHPWPInfo).coordinates = data.coordinates;
            (info as LoadSHPWPInfo).featureType = data.featureType;
            (info as LoadSHPWPInfo).features = new FeaturesInfo(data.points);
            advPropertyGrid1.SelectedObject = info;
        }

        private void BindingDataSource(string file, CustomFile.KML.KMLDataSet data)
        {
            info = new LoadKMLWPInfo();

            info.fileName = file;
            info.fileType = CustomFile.UniversalMethod.GetFileType(file);

            (info as LoadKMLWPInfo).fileSize = CustomFile.UniversalMethod.GetFileSize(file);
            (info as LoadKMLWPInfo).createTime = CustomFile.UniversalMethod.GetFileCreate(file);
            (info as LoadKMLWPInfo).modifyTime = CustomFile.UniversalMethod.GetFileModify(file);

            (info as LoadKMLWPInfo).coordinates = data.coordinates;
            (info as LoadKMLWPInfo).features = new FeaturesInfo(data.points);
            advPropertyGrid1.SelectedObject = info;
        }

        LoadWPInfo info;

        public List<CustomData.WP.Position> GetWPList()
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

            return new List<CustomData.WP.Position>();
        }
    }

    [TypeConverter(typeof(PropertySorter))]
    class LoadWPInfo
    {
        [Category("打开文件"), DisplayName("文件")]
        [PropertyOrder(0b00000001)]
        [Editor(typeof(CustomControls.ContentUITypeEditor), typeof(UITypeEditor))]
        public string fileName { get; set; }

        [Browsable(false)]
        public string fileType { get; set; }
    }

    [TypeConverter(typeof(PropertySorter))]
    class LoadWPFileInfo : LoadWPInfo
    {
        [Category("文件信息"), DisplayName("文件大小"), ReadOnly(false)]
        [PropertyOrder(0b00010001)]
        public string fileSize { get; set; }

        [Category("文件信息"), DisplayName("创建时间"), ReadOnly(false)]
        [PropertyOrder(0b00010010)]
        public string createTime { get; set; }

        [Category("文件信息"), DisplayName("修改时间"), ReadOnly(false)]
        [PropertyOrder(0b00010011)]
        public string modifyTime { get; set; }
    }

    [TypeConverter(typeof(PropertySorter))]
    class LoadSHPWPInfo : LoadWPFileInfo
    {
        [Category("打开文件"), DisplayName("文件类型"), ReadOnly(true)]
        [PropertyOrder(0b00000010)]
        public string openFileType { set; get; } = "ShapeFile";

        [Category("要素信息"), DisplayName("要素集合")]
        [PropertyOrder(0b00100001)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Editor(typeof(CustomControls.PositionListUITypeEditor), typeof(UITypeEditor))]
        public FeaturesInfo features { get; set; }

        [Category("要素信息"), DisplayName("投影坐标系")]
        [PropertyOrder(0b00100011)]
        [Editor(typeof(CustomControls.ContentUITypeEditor), typeof(UITypeEditor))]
        public string coordinates { get; set; }

        [Category("要素信息"), DisplayName("要素类型"), ReadOnly(true)]
        [PropertyOrder(0b00100010)]
        public string featureType { get; set; }
    }

    [TypeConverter(typeof(PropertySorter))]
    class LoadKMLWPInfo : LoadWPFileInfo
    {
        [Category("打开文件"), DisplayName("文件类型"), ReadOnly(true)]
        [PropertyOrder(0b00000010)]
        public string openFileType { set; get; } = "Google Earth KML";

        [Category("要素信息"), DisplayName("要素集合")]
        [PropertyOrder(0b00100001)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Editor(typeof(CustomControls.PositionListUITypeEditor), typeof(UITypeEditor))]
        public FeaturesInfo features { get; set; }

        [Category("要素信息"), DisplayName("投影坐标系")]
        [PropertyOrder(0b00100010)]
        [Editor(typeof(CustomControls.ContentUITypeEditor), typeof(UITypeEditor))]
        public string coordinates { get; set; }
    }

    public class FeaturesInfo
    {
        public List<List<CustomData.WP.Position>> features;
        int current = -1;
        public FeaturesInfo(List<List<CustomData.WP.Position>> list)
        {
            features = new List<List<CustomData.WP.Position>>();
            for (int i = 0; i < list.Count; i++)
            {
                var feature = new List<CustomData.WP.Position>(list[i]);
                features.Add(feature);
            }
            if (Count > 0)
                Current = 0;
            else
                Current = -1;
        }

        public FeaturesInfo(List<CustomData.WP.Position> list)
        {
            features = new List<List<CustomData.WP.Position>>();
            var feature = new List<CustomData.WP.Position>(list);
            features.Add(feature);
            if (Count > 0)
                Current = 0;
            else
                Current = -1;
        }

        [Category("要素集合"), DisplayName("要素数量"), ReadOnly(true)]
        public int Count
        {
            get { return features.Count; }  
        }

        [ Category("要素集合"), DisplayName("选中要素"),
            PropertyIntegerEditor(MinValue = -1, MaxValue = 100),DefaultValue(0)]
        public int Current
        {
            set
            {
                current = Count > 0 ? value % Count : -1;
            }
            get { return current; }
        }

        [Category("要素集合"), DisplayName("要素")]
        public List<CustomData.WP.Position> this[int index]
        {
            set
            {
                if (value == null)
                    return;
                if (index >= features.Count)
                    features.Add(new List<CustomData.WP.Position>(value));
                else if (index < 0)
                    features.Insert(0, new List<CustomData.WP.Position>(value));
                else
                    features[index] = new List<CustomData.WP.Position>(value);
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
            string str = features.Count.ToString() + "; ";
            if(Current >= 0 & Current < features.Count)
                str += Current.ToString() + ":" + features[Current].Count.ToString();
            return str;
        }

        public void AddFeature(List<CustomData.WP.Position> list)
        {
            var feature = new List<CustomData.WP.Position>(list);
            features.Add(feature);
            if (Count > 0 && Current == -1)
                Current = 0;
            else if(Count <= 0)
                Current = -1;
        }
    }
}
