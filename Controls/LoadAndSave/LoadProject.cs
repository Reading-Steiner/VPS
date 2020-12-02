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

namespace VPS.Controls.LoadAndSave
{
    public partial class LoadProject : Form
    {
        public LoadProject()
        {
            InitializeComponent();
            this.Load += LoadProject_Load;

            advPropertyGrid1.Tag = advPropertyGrid1.PropertySort;
            advPropertyGrid1.PropertySort = DevComponents.DotNetBar.ePropertySort.CategorizedAlphabetical;
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

                if (currentPropEntriesInfo != null)
                {
                    GridItemCollection currentPropEntries = currentPropEntriesInfo.GetValue(advPropertyGrid1) as GridItemCollection;
                    var newarray = currentPropEntries.Cast<GridItem>().OrderBy((t) => categorys.IndexOf(t.Label)).ToArray();
                    currentPropEntries.GetType().GetField("entries", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(currentPropEntries, newarray);
                }
                advPropertyGrid1.ExpandAllGridItems();
                advPropertyGrid1.PropertySort = (DevComponents.DotNetBar.ePropertySort)advPropertyGrid1.Tag;
            }
        }




        private void LoadProject_Load(object sender, EventArgs e)
        {
            info = new LoadProjectedInfo();

            advPropertyGrid1.SelectedObject = info;
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(GCSViews.ProjectData));

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "项目工程(*.vps)|*.vps";
                ofd.ShowDialog();

                if (File.Exists(ofd.FileName))
                {
                    using (StreamReader sr = new StreamReader(ofd.FileName))
                    {
                        var data = (GCSViews.ProjectData)reader.Deserialize(sr);
                        info.wpList = new ProjectListInfo(data.wp);
                        info.polygon = new ProjectListInfo(data.poly);
                        info.layer = data.layer;
                        info.layerRect = data.layerRect;
                        info.homePosition = new Position(data.homePosition);
                        info.isLeftHide = data.isLeftHide;
                        info.isBottomHide = data.isBottomHide;
                        info.isConfigGrid = data.isConfigGridVisible;

                        advPropertyGrid1.SelectedObject = info;
                    }
                }
            }
        }

        public LoadProjectedInfo info;

    }

    public class PropertySorter : ExpandableObjectConverter
    {
        #region Methods
        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            //
            // This override returns a list of properties in order
            //
            PropertyDescriptorCollection pdc = TypeDescriptor.GetProperties(value, attributes);
            var orderedProperties = new System.Collections.ArrayList();
            foreach (PropertyDescriptor pd in pdc)
            {
                Attribute attribute = pd.Attributes[typeof(PropertyOrderAttribute)];
                if (attribute != null)
                {
                    //
                    // If the attribute is found, then create an pair object to hold it
                    //
                    PropertyOrderAttribute poa = (PropertyOrderAttribute)attribute;
                    orderedProperties.Add(new PropertyOrderPair(pd.Name, poa.Order));
                }
                else
                {
                    //
                    // If no order attribute is specifed then given it an order of 0
                    //
                    orderedProperties.Add(new PropertyOrderPair(pd.Name, 0));
                }
            }
            //
            // Perform the actual order using the value PropertyOrderPair classes
            // implementation of IComparable to sort
            //
            orderedProperties.Sort();


            //
            // Build a string list of the ordered names
            //
            var propertyNames = new System.Collections.ArrayList();
            foreach (PropertyOrderPair pop in orderedProperties)
            {
                propertyNames.Add(pop.Name);
            }
            //
            // Pass in the ordered list for the PropertyDescriptorCollection to sort by
            //
            return pdc.Sort((string[])propertyNames.ToArray(typeof(string)));
        }
        #endregion
    }

    public class LoadProjectedInfo
    {
        private List<string> categorys = new List<string>()
        { "航点", "区域", "默认工作区", "区域数据源","区域范围","初始位置","左停靠栏","下停靠栏","自动航点" };

        [Category("要素集合"), DisplayName("航点"),
            TypeConverter(typeof(ExpandableObjectConverter)),
            Editor(typeof(CustomControls.PositionListUITypeEditor), typeof(UITypeEditor))]
        public ProjectListInfo wpList { set; get; } = 
            new ProjectListInfo(new List<Utilities.PointLatLngAlt>());

        [Category("要素集合"), DisplayName("区域"),
            TypeConverter(typeof(ExpandableObjectConverter)),
            Editor(typeof(CustomControls.PositionListUITypeEditor), typeof(UITypeEditor))]
        public ProjectListInfo polygon { set; get; } =
            new ProjectListInfo(new List<Utilities.PointLatLngAlt>());

        [Category("工作区"), DisplayName("默认工作区")]
        public bool defaultLayer { set; get; } = false;

        [Category("工作区"), DisplayName("区域数据源")]
        public string layer { set; get; } = "";

        [Category("工作区"), DisplayName("区域范围")]
        public GMap.NET.RectLatLng layerRect { set; get; } = new GMap.NET.RectLatLng();

        [Category("工作区"), DisplayName("初始位置"),
            TypeConverter(typeof(ExpandableObjectConverter))]
        public Position homePosition { set; get; } = new Position();

        [Category("用户布局"), DisplayName("左停靠栏")]
        public bool isLeftHide { set; get; } = false;

        [Category("用户布局"), DisplayName("下停靠栏")]
        public bool isBottomHide { set; get; } = false;

        [Category("用户布局"), DisplayName("自动航点")]
        public bool isConfigGrid { set; get; } = false;
    }
}
