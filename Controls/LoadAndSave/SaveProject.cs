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
        }

        private void SaveProject_Load(object sender, EventArgs e)
        {
            info = new SaveProjectedInfo();
            info.wpList = new ProjectListInfo(VPS.CustomData.WP.WPGlobalData.instance.GetWPList());
            info.polygon= new ProjectListInfo(VPS.CustomData.WP.WPGlobalData.instance.GetPolyList());
            info.layer = VPS.CustomData.WP.WPGlobalData.instance.GetLayer();
            info.layerRect = new Rect(
                VPS.CustomData.WP.WPGlobalData.instance.GetLayerRect());
            info.homePosition = new Position(
                VPS.CustomData.WP.WPGlobalData.instance.GetLayerHome());

            info.isLeftHide = VPS.MainV2.instance.IsLeftBarHide();
            info.isBottomHide = VPS.MainV2.instance.IsBottomBarHide();
            info.isConfigGrid = VPS.MainV2.instance.IsConfigGridVisible();

            advPropertyGrid1.SelectedObject = info;
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
            data.layerRect = info.layerRect.ToLocationRect();
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


    [TypeConverter(typeof(PropertySorter))]
    public class SaveProjectedInfo
    {
        [Category("要素集合"), DisplayName("航点")]
        [PropertyOrder(0b00000001)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Editor(typeof(CustomControls.PositionListUITypeEditor), typeof(UITypeEditor))]
        public ProjectListInfo wpList { set; get; }
            = new ProjectListInfo(new List<Utilities.PointLatLngAlt>());

        [Category("要素集合"), DisplayName("区域")]
        [PropertyOrder(0b00000010)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Editor(typeof(CustomControls.PositionListUITypeEditor), typeof(UITypeEditor))]
        public ProjectListInfo polygon { set; get; }
            = new ProjectListInfo(new List<Utilities.PointLatLngAlt>());

        [Category("工作区"), DisplayName("区域数据源")]
        [PropertyOrder(0b00010001)]
        public string layer { set; get; } = "";

        [Category("工作区"), DisplayName("区域范围")]
        [PropertyOrder(0b00010010)]
        public Rect layerRect { set; get; } = new Rect();

        [Category("工作区"), DisplayName("初始位置")]
        [PropertyOrder(0b00010011)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Editor(typeof(CustomControls.PositionUITypeEditor), typeof(UITypeEditor))]
        public Position homePosition { set; get; } = new Position();

        [Category("用户布局"), DisplayName("左停靠栏")]
        [PropertyOrder(0b00100001)]
        public bool isLeftHide { set; get; } = false;

        [Category("用户布局"), DisplayName("下停靠栏")]
        [PropertyOrder(0b00100010)]
        public bool isBottomHide { set; get; } = false;

        [Category("用户布局"), DisplayName("自动航点")]
        [PropertyOrder(0b00100011)]
        public bool isConfigGrid { set; get; } = false;
    }

    public class ProjectListInfo
    {
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
        [Category("位置"), DisplayName("\t\t\t\t\t维度")]
        [NotifyParentProperty(true)]
        public double Lat { get; set; } = 0;

        [Category("位置"), DisplayName("\t\t\t\t经度")]
        [NotifyParentProperty(true)]
        public double Lng { get; set; } = 0;

        [Category("位置"), DisplayName("\t\t\t高度")]
        [NotifyParentProperty(true)]
        public double Alt { get; set; } = 0;

        [Category("位置"), DisplayName("\t\t高度模块")]
        [NotifyParentProperty(true)]
        public string AltMode { get; set; } = "";

        [Category("位置"), DisplayName("\t类型")]
        [NotifyParentProperty(true)]
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
            return Math.Abs(Lng).ToString("0.##") + (Lng >= 0 ? "E; " : "W") + "; " +
                Math.Abs(Lat).ToString("0.##") + (Lat >= 0 ? "N;" : "S") + "; " +
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

    public class Rect
    {
        [Category("区域"), DisplayName("\t\t\t\t上")]
        double Top { get; set; } = 0;

        [Category("区域"), DisplayName("\t\t\t下")]
        double Bottom { get; set; } = 0;

        [Category("区域"), DisplayName("\t\t左")]
        double Left { get; set; } = 0;

        [Category("区域"), DisplayName("\t右")]
        double Right { get; set; } = 0;


        public Rect()
        {
        }

        public Rect(GMap.NET.RectLatLng rect)
        {
            Top = rect.Top;
            Bottom = rect.Bottom;
            Left = rect.Left;
            Right = rect.Right;
        }

        public override string ToString()
        {
            return 
                Math.Abs(Left).ToString("0.##") + (Left > 0 ? "E" : "W") + "-" +
                Math.Abs(Right).ToString("0.##") + (Left > 0 ? "E" : "W") + "; " +
                Math.Abs(Bottom).ToString("0.##") + (Bottom > 0 ? "N" : "S") + "-" +
                Math.Abs(Top).ToString("0.##") + (Top > 0 ? "N" : "S") + "; ";
        }

        public GMap.NET.RectLatLng ToLocationRect()
        {
            GMap.NET.RectLatLng rect = GMap.NET.RectLatLng.FromLTRB(Left, Top, Right, Bottom);

            return rect;
        }

        public void FromLocationRect(GMap.NET.RectLatLng rect)
        {
            Top = rect.Top;
            Bottom = rect.Bottom;
            Left = rect.Left;
            Right = rect.Right;
        }
    }
}
