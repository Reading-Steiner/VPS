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
    public partial class SavePolygon : DevComponents.DotNetBar.Office2007Form
    {
        public SavePolygon()
        {
            InitializeComponent();

            advPropertyGrid1.Tag = advPropertyGrid1.PropertySort;
            advPropertyGrid1.PropertySort = DevComponents.DotNetBar.ePropertySort.Categorized;

            BindingDataSourceBase();
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog fd = new SaveFileDialog())
            {
                //fd.Filter = "KML|*.kml|WorkCoordinates Mission|*.waypoints|Mission|*.waypoints;*.txt";
                fd.Filter = "Google Earth KML(*kml) |*.kml|ShapeFile(*.shp)|*.shp";
                fd.DefaultExt = ".kml";
                fd.InitialDirectory = Settings.Instance["PolygonFileDirectory"];

                DialogResult result = fd.ShowDialog();

                string file = fd.FileName;
                if (file != "" && result == DialogResult.OK)
                {
                    switch (fd.FilterIndex)
                    {
                        case 1:
                            BindingDataSourceKML(file);
                            break;
                        case 2:
                            BindingDataSourceSHP(file);
                            break;

                    }
                }
                else
                {
                    BindingDataSourceBase(file);
                }
            } 
        }

        private void BindingDataSourceBase(string file = "")
        {
            info = new SavePolygonInfo();

            info.fileName = file;
            info.fileType = CustomFile.UniversalMethod.GetFileType(file);

            var list = VPS.CustomData.WP.WPGlobalData.instance.GetPolyList();
            var length = VPS.CustomData.WP.WPGlobalData.GetTotalDist(list);
            var area = VPS.CustomData.WP.WPGlobalData.instance.GetPolygonArea(list);

            info.polygon = new PolygonInfo(list);
            info.area = area.ToString("0.## m^2");
            info.length = length.ToString("0.## m");
            advPropertyGrid1.SelectedObject = info;
        }

        private void BindingDataSourceKML(string file)
        {
            info = new SaveKMLPolygonInfo();

            (info as SaveKMLPolygonInfo).saveFileName = file;

            info.fileName = file;
            info.fileType = "kml";

            var list = VPS.CustomData.WP.WPGlobalData.instance.GetPolyList();
            var length = VPS.CustomData.WP.WPGlobalData.GetTotalDist(list);
            var area = VPS.CustomData.WP.WPGlobalData.instance.GetPolygonArea(list);

            info.polygon = new PolygonInfo(list);
            info.area = area.ToString("0.## m^2");
            info.length = length.ToString("0.## m");
            advPropertyGrid1.SelectedObject = info;
        }

        private void BindingDataSourceSHP(string file)
        {
            info = new SaveSHPPolygonInfo();

            (info as SaveSHPPolygonInfo).saveFileName = file;

            info.fileName = file;
            info.fileType = "shp";

            var list = VPS.CustomData.WP.WPGlobalData.instance.GetPolyList();
            var length = VPS.CustomData.WP.WPGlobalData.GetTotalDist(list);
            var area = VPS.CustomData.WP.WPGlobalData.instance.GetPolygonArea(list);

            info.polygon = new PolygonInfo(list);
            info.area = area.ToString("0.## m^2");
            info.length = length.ToString("0.## m");

            advPropertyGrid1.SelectedObject = info;
        }

        SavePolygonInfo info;

        public void SavePolygonPoints()
        {
            if (!string.IsNullOrEmpty(info.fileName))
            {
                if (info.fileType.Contains("kml"))
                {
                    string file = info.fileName;
                    savePolygonPointsKML(file);
                }
                if (info.fileType.Contains("shp"))
                {
                    string file = info.fileName;
                    savePolygonPointsSHP(file);
                }
            }
        }

        private void savePolygonPointsSHP(string file)
        {
            List<PointLatLngAlt> polygon = VPS.CustomData.WP.WPGlobalData.instance.GetPolyList();
            
            string porgressKey = VPS.Controls.MainInfo.TopMainInfo.instance.CreateProgressEnter("保存为 ShapeFile");
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
                shp.SaveSHP(file, polygon);
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

        private void savePolygonPointsKML(string file)
        {
            string porgressKey = VPS.Controls.MainInfo.TopMainInfo.instance.CreateProgressEnter("保存为 KML");
            string messageKey = VPS.Controls.MainInfo.TopMainInfo.instance.CreateMessageBoxEnter();
            var bar = VPS.Controls.MainInfo.TopMainInfo.instance.GetProgress(porgressKey);
            var box = VPS.Controls.MainInfo.TopMainInfo.instance.GetMessageBox(messageKey);

            List<PointLatLngAlt> polygon = VPS.CustomData.WP.WPGlobalData.instance.GetPolyList();

            try
            {
                FileStream fs = new FileStream(file, FileMode.Create);
                XmlTextWriter w = new XmlTextWriter(fs, System.Text.Encoding.UTF8);
                w.IndentChar = System.Convert.ToChar(" ");
                w.Indentation = 4;
                w.Formatting = System.Xml.Formatting.Indented;

                // Start the document.
                w.WriteStartDocument();
                w.WriteStartElement("kml", "http://www.opengis.net/kml/2.2");
                w.WriteStartElement("Document", "");
                w.WriteStartElement("name");
                w.WriteString(file);
                w.WriteEndElement();//name
                w.WriteStartElement("open");
                w.WriteString("1");
                w.WriteEndElement();//open

                //style
                w.WriteStartElement("Style");
                w.WriteAttributeString("id", "waylineGreenPoly");
                w.WriteStartElement("LineStyle");
                w.WriteStartElement("color");
                w.WriteString("FF0AEE8B");
                w.WriteEndElement();//color
                w.WriteStartElement("width");
                w.WriteString("6");
                w.WriteEndElement();//width
                w.WriteEndElement();//LineStyle
                w.WriteEndElement();//Style

                w.WriteStartElement("Style");
                w.WriteAttributeString("id", "waypointStyle");
                w.WriteStartElement("IconStyle");
                w.WriteStartElement("Icon");
                w.WriteStartElement("href");
                w.WriteString("https://cdnen.dji-flighthub.com/static/app/images/point.png");
                w.WriteEndElement();//href
                w.WriteEndElement();//Icon
                w.WriteEndElement();//IconStyle
                w.WriteEndElement();//Style

                {
                    #region WPLines
                    //MainData Lines
                    w.WriteStartElement("Placemark");
                    // Write Lines element
                    w.WriteStartElement("name");
                    w.WriteString(string.Format("Wayline"));
                    w.WriteEndElement();//name
                    w.WriteStartElement("visibility");
                    w.WriteString("true");
                    w.WriteEndElement();//visibility
                    w.WriteStartElement("description");
                    w.WriteString("Wayline");
                    w.WriteEndElement();//description
                    w.WriteStartElement("styleUrl");
                    w.WriteString("#waylineGreenPoly");
                    w.WriteEndElement();//styleUrl


                    w.WriteStartElement("LineString");
                    w.WriteStartElement("tessellate");
                    w.WriteString("1");
                    w.WriteEndElement();//tessellate
                    w.WriteStartElement("altitudeMode");

                    w.WriteString("clampToGround");

                    w.WriteEndElement();//altitudeMode
                    w.WriteStartElement("coordinates");

                    string pointList = "";

                    for (int index = 0; index < polygon.Count; index++)
                    {
                        if (polygon[index] != null)
                        {
                            var marker = polygon[index];
                            pointList += string.Format("{0},{1},{2} ", marker.Lng, marker.Lat, marker.Alt);
                        }
                        bar.SetProgress((double)(index + 1) / polygon.Count);
                    }

                    w.WriteString(pointList);
                    w.WriteEndElement();//coordinates
                    w.WriteEndElement();//LineString

                    w.WriteEndElement();//Placemark
                    #endregion
                }
                w.WriteEndElement();//document
                w.WriteEndElement();//kml

                // Ends the document.
                w.WriteEndDocument();

                // close writer
                w.Close();
                box.SetInfoMessage(string.Format("【{0}】创建成功", file));
                bar.SetProgressSuccess("KML 创建成功");
            }
            catch (Exception ex)
            {
                box.SetInfoMessage(string.Format("【{0}】创建失败", file));
                bar.SetProgressFailure("KML 创建失败");
            }
            finally
            {
                if (porgressKey != null)
                    VPS.Controls.MainInfo.TopMainInfo.instance.DisposeControlEnter(porgressKey, 2000);
                if (messageKey != null) 
                    VPS.Controls.MainInfo.TopMainInfo.instance.DisposeControlEnter(messageKey, 5000);
            }

        }
    }

    [TypeConverter(typeof(PropertySorter))]
    class SavePolygonInfo
    {
        [Browsable(false)]
        public string fileName = "";

        [Browsable(false)]
        public string fileType = "";

        //[Category("基本信息"), Description("要素类型"), DisplayName("航飞最大倾角"), ReadOnly(true)]
        //public string GradOfWPList { get; set; }
        [Category("区域信息"), Description("区域点的集合"), DisplayName("区域")]
        [PropertyOrder(0b00010001)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Editor(typeof(CustomControls.PositionListUITypeEditor), typeof(UITypeEditor))]
        public PolygonInfo polygon { get; set; }

        [Category("区域信息"), DisplayName("面积"), ReadOnly(true)]
        [PropertyOrder(0b00010010)]
        public string area { set; get; }

        [Category("区域信息"), DisplayName("周长"), ReadOnly(true)]
        [PropertyOrder(0b00010011)]
        public string length { set; get; }
    }

    [TypeConverter(typeof(PropertySorter))]
    class SaveKMLPolygonInfo : SavePolygonInfo
    {
        [Category("保存信息"), DisplayName("文件")]
        [PropertyOrder(0b00000001)]
        [Editor(typeof(CustomControls.ContentUITypeEditor), typeof(UITypeEditor))]
        public string saveFileName { get; set; }

        [Category("保存信息"), DisplayName("文件类型"), ReadOnly(true)]
        [PropertyOrder(0b00000010)]
        public string saveFileType { set; get; } = "Google Earth KML";

        [Category("保存信息"), DisplayName("高度框架"), ReadOnly(true)]
        [PropertyOrder(0b00000011)]
        public string saveAltMode { set; get; } = "clampToGround";
    }

    [TypeConverter(typeof(PropertySorter))]
    class SaveSHPPolygonInfo : SavePolygonInfo
    {
        [Category("保存信息"), DisplayName("文件")]
        [PropertyOrder(0b00000001)]
        [Editor(typeof(CustomControls.ContentUITypeEditor), typeof(UITypeEditor))]
        public string saveFileName { get; set; }

        [Category("保存信息"), DisplayName("文件类型"), ReadOnly(true)]
        [PropertyOrder(0b00000010)]
        public string saveFileType { set; get; } = "ShapeFile";

        [Category("保存信息"), DisplayName("空间参考"), ReadOnly(true)]
        [PropertyOrder(0b00000011)]
        public string saveFileProference { set; get; } = 
            DotSpatial.Projections.KnownCoordinateSystems.Geographic.World.WGS1984.ToString();

    }

    public class PolygonInfo
    {
        public List<PointLatLngAlt> features;

        public PolygonInfo(List<PointLatLngAlt> list)
        {
            features = new List<PointLatLngAlt>(list);
        }

        [Category("区域"), DisplayName("区域点数"), ReadOnly(true)]
        public int Count
        {
            get { return features.Count; }
        }


        public override string ToString()
        {
            string str = features.Count.ToString();
            return str;
        }

        public void AddPolygon(List<PointLatLngAlt> list)
        {
            features = new List<PointLatLngAlt>(list);
        }
    }
}
