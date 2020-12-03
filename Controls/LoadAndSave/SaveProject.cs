using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VPS.Utilities;

namespace VPS.Controls.LoadAndSave
{
    public partial class SaveProject : DevComponents.DotNetBar.Office2007Form
    {
        public SaveProject()
        {
            InitializeComponent();
            this.Load += SaveProject_Load;

            advPropertyGrid1.Tag = advPropertyGrid1.PropertySort;
            advPropertyGrid1.PropertySort = DevComponents.DotNetBar.ePropertySort.Categorized;
            advPropertyGrid1.Paint += AdvPropertyGrid1_Paint;
        }

        private void AdvPropertyGrid1_Paint(object sender, PaintEventArgs e)
        {
            var categorysinfo = advPropertyGrid1.SelectedObject.GetType().GetField("categorys", BindingFlags.NonPublic | BindingFlags.Instance);
            if (categorysinfo != null)
            {
                var categorys = categorysinfo.GetValue(advPropertyGrid1.SelectedObject) as List<String>;
                advPropertyGrid1.CollapseAllGridItems();

                var currentPropEntriesInfo = advPropertyGrid1.GetType().GetField("currentPropEntries", BindingFlags.NonPublic | BindingFlags.Instance);

                if (currentPropEntriesInfo != null) {
                    GridItemCollection currentPropEntries = currentPropEntriesInfo.GetValue(advPropertyGrid1) as GridItemCollection;
                    var newarray = currentPropEntries.Cast<GridItem>().OrderBy((t) => categorys.IndexOf(t.Label)).ToArray();
                    currentPropEntries.GetType().GetField("entries", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(currentPropEntries, newarray);
                }
                advPropertyGrid1.ExpandAllGridItems();
                advPropertyGrid1.PropertySort = (DevComponents.DotNetBar.ePropertySort)advPropertyGrid1.Tag;
            }

            var order = advPropertyGrid1.SelectedObject.GetType().GetField("PropertyOrder", BindingFlags.NonPublic | BindingFlags.Instance);

        }

        private void SaveProject_Load(object sender, EventArgs e)
        {
            info = new SaveProjectedInfo();
            info.wpList = new ProjectListInfo(VPS.CustomData.WP.WPGlobalData.instance.GetWPList());
            info.polygon= new ProjectListInfo(VPS.CustomData.WP.WPGlobalData.instance.GetPolyList());
            info.layer = VPS.CustomData.WP.WPGlobalData.instance.GetLayer();
            info.layerRect = VPS.CustomData.WP.WPGlobalData.instance.GetLayerRect();
            info.homePosition = new Position(
                VPS.CustomData.WP.WPGlobalData.instance.GetLayerHome());

            info.isLeftHide = VPS.MainV2.instance.IsLeftBarHide();
            info.isBottomHide = VPS.MainV2.instance.IsBottomBarHide();
            info.isConfigGrid = VPS.MainV2.instance.IsConfigGridVisible();



            advPropertyGrid1.SelectedObject = info;

            AdvPropertyGrid1_Paint(this, null);
        }
        SaveProjectedInfo info;

        private void OpenFile_Click(object sender, EventArgs e)
        {
        }

        public void SaveProjectToFile()
        {
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(GCSViews.ProjectData));

            var data = new GCSViews.ProjectData();
            data.wp = info.wpList.features;
            data.poly = info.polygon.features;
            data.layer = info.layer;
            data.layerRect = info.layerRect;
            data.homePosition = info.homePosition.ToLocationPoint();
            data.isLeftHide = info.isLeftHide;
            data.isBottomHide = info.isBottomHide;
            data.isConfigGridVisible = info.isConfigGrid;

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "项目工程(*.vps)|*.vps";
                var result = sfd.ShowDialog();

                if (sfd.FileName != "" && result == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName))
                    {
                        writer.Serialize(sw, data);
                    }
                }
            }
        }
    }



    public class SaveProjectedInfo
    {
        private List<string> categorys = new List<string>()
        { "航点","区域","区域数据源","区域范围","初始位置","左停靠栏","下停靠栏","自动航点"};

        [Category("要素集合"), DisplayName("航点")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Editor(typeof(CustomControls.PositionListUITypeEditor), typeof(UITypeEditor))]
        public ProjectListInfo wpList { set; get; }
            = new ProjectListInfo(new List<Utilities.PointLatLngAlt>());

        [Category("要素集合"), DisplayName("区域")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Editor(typeof(CustomControls.PositionListUITypeEditor), typeof(UITypeEditor))]
        public ProjectListInfo polygon { set; get; }
            = new ProjectListInfo(new List<Utilities.PointLatLngAlt>());

        [Category("工作区"), DisplayName("区域数据源")]
        public string layer { set; get; } = "";

        [Category("工作区"), DisplayName("区域范围")]
        public GMap.NET.RectLatLng layerRect { set; get; } = new GMap.NET.RectLatLng();

        [Category("工作区"), DisplayName("初始位置")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Editor(typeof(CustomControls.PositionUITypeEditor), typeof(UITypeEditor))]
        public Position homePosition { set; get; } = new Position();

        [Category("用户布局"), DisplayName("左停靠栏")]
        public bool isLeftHide { set; get; } = false;

        [Category("用户布局"), DisplayName("自动航点")]
        public bool isConfigGrid { set; get; } = false;

        [Category("用户布局"), DisplayName("下停靠栏")]
        public bool isBottomHide { set; get; } = false;
    }

    public class ProjectListInfo
    {
        private List<string> categorys = new List<string>()
        { "要素集合" };

        public List<Utilities.PointLatLngAlt> features = new List<Utilities.PointLatLngAlt>();


        public ProjectListInfo(List<Utilities.PointLatLngAlt> list)
        {
            features = new List<Utilities.PointLatLngAlt>(list);
        }

        [Category("要素集合"), DisplayName("要素数量"), ReadOnly(true)]
        public int Count
        {
            get { return features.Count; }
        }

        public override string ToString()
        {
            string str = features.Count.ToString();
            return str;
        }

        public void AddList(List<Utilities.PointLatLngAlt> list)
        {
            features = new List<Utilities.PointLatLngAlt>(list);
        }
    }

    public class Position
    {
        private List<string> categorys = new List<string>()
        { "维度", "经度", "高度", "高度模块","类型"};

        [Category("位置"), DisplayName("维度"), PropertyOrder(0)]
        public double Lat { get; set; } = 0;

        [Category("位置"), DisplayName("经度"), PropertyOrder(1)]
        public double Lng { get; set; } = 0;

        [Category("位置"), DisplayName("高度"), PropertyOrder(2)]
        public double Alt { get; set; } = 0;

        [Category("位置"), DisplayName("高度模块"), PropertyOrder(3)]
        public string AltMode { get; set; } = "";

        [Category("位置"), DisplayName("类型"), PropertyOrder(4)]
        public string Command { get; set; } = "";

        public Position()
        {
        }

        public Position(PointLatLngAlt point)
        {
            Lng = point.Lng;
            Lat = point.Lat;
            Alt = point.Alt;
            Command = point.Tag;
            AltMode = point.Tag2;
        }

        public override string ToString()
        {
            return Math.Abs(Lng).ToString("0.##") + (Lng >= 0 ? " E; " : " W; ") +
                Math.Abs(Lat).ToString("0.##") + (Lat >= 0 ? " N; " : " S; ") +
                (Alt).ToString("0.##");
        }

        public PointLatLngAlt ToLocationPoint()
        {
            PointLatLngAlt point = new PointLatLngAlt();
            point.Lng = Lng;
            point.Lat = Lat;
            point.Alt = Alt;
            point.Tag = Command;
            point.Tag2 = AltMode;

            return point;
        }

        public void FromLocationPoint(PointLatLngAlt point)
        {
            Lng = point.Lng;
            Lat = point.Lat;
            Alt = point.Alt;
            Command = point.Tag;
            AltMode = point.Tag2;
        }
    }

    //public class Rect
    //{
    //    [Category("区域"), DisplayName("0-上")]
    //    double Top { get; set; } = 0;

    //    [Category("区域"), DisplayName("1-下")]
    //    double Bottom { get; set; } = 0;

    //    [Category("区域"), DisplayName("2-左")]
    //    double Left { get; set; } = 0;

    //    [Category("区域"), DisplayName("3-右")]
    //    double Right { get; set; } = 0;


    //    public Rect()
    //    {
    //    }

    //    public Position(PointLatLngAlt point)
    //    {
    //        Lng = point.Lng;
    //        Lat = point.Lat;
    //        Alt = point.Alt;
    //        Command = point.Tag;
    //        AltMode = point.Tag2;
    //    }

    //    public override string ToString()
    //    {
    //        return Math.Abs(Lng).ToString("0.##") + (Lng > 0 ? " E" : " W") +
    //            Math.Abs(Lat).ToString("0.##") + (Lat > 0 ? " N" : " S") +
    //            (Alt).ToString("0.##");
    //    }

    //    public PointLatLngAlt ToLocationPoint()
    //    {
    //        PointLatLngAlt point = new PointLatLngAlt();
    //        point.Lng = Lng;
    //        point.Lat = Lat;
    //        point.Alt = Alt;
    //        point.Tag = Command;
    //        point.Tag2 = AltMode;

    //        return point;
    //    }

    //    public void FromLocationPoint(PointLatLngAlt point)
    //    {
    //        Lng = point.Lng;
    //        Lat = point.Lat;
    //        Alt = point.Alt;
    //        Command = point.Tag;
    //        AltMode = point.Tag2;
    //    }
    //}
}
