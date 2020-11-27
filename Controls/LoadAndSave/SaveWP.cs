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
using System.Xml;
using VPS.Utilities;

namespace VPS.Controls.LoadAndSave
{
    public partial class SaveWP : Form
    {
        public SaveWP()
        {
            InitializeComponent();

            BindingDataSourceBase();
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog fd = new SaveFileDialog())
            {
                //fd.Filter = "KML|*.kml|WorkCoordinates Mission|*.waypoints|Mission|*.waypoints;*.txt";
                fd.Filter = "KML|*.kml";
                fd.DefaultExt = ".kml";
                fd.InitialDirectory = Settings.Instance["WPFileDirectory"] ?? "";

                DialogResult result = fd.ShowDialog();

                string file = fd.FileName;
                if (file != "" && result == DialogResult.OK)
                {
                    TXT_FileName.Text = file;
                    switch (fd.FilterIndex)
                    {
                        case 1:
                            TXT_FileType.Text = "文件类型：kml";
                            BindingDataSourceKML();
                            break;
                    }
                }
                else
                {
                    TXT_FileType.Text = "";
                    BindingDataSourceBase();
                }
            }
        }

        private void BindingDataSourceBase()
        {
            info = new SaveWPInfo();

            var list = VPS.CustomData.WP.WPGlobalData.instance.GetWPList();
            var baseAlt = VPS.CustomData.WP.WPGlobalData.GetBaseAlt(list);
            var totalDist = VPS.CustomData.WP.WPGlobalData.GetTotalDist(list);

            info.BaseOfWPList = baseAlt.ToString("0.## m");
            info.DistanceOfWPList = totalDist.ToString("0.## m");
            info.AltMode = (VPS.CustomData.EnumCollect.AltFrame.Mode)Enum.Parse(
                typeof(VPS.CustomData.EnumCollect.AltFrame.Mode),
                VPS.GCSViews.FlightPlanner.instance.GetAltFrame());

            info.feature = new FeatureInfo(list);
            advPropertyGrid1.SelectedObject = info;
        }

        private void BindingDataSourceKML()
        {
            info = new SaveKMLWPInfo();

            var list = VPS.CustomData.WP.WPGlobalData.instance.GetWPList();
            var baseAlt = VPS.CustomData.WP.WPGlobalData.GetBaseAlt(list);
            var totalDist = VPS.CustomData.WP.WPGlobalData.GetTotalDist(list);

            info.BaseOfWPList = baseAlt.ToString("0.## m");
            info.DistanceOfWPList = totalDist.ToString("0.## m");
            info.AltMode = (VPS.CustomData.EnumCollect.AltFrame.Mode)Enum.Parse(
                typeof(VPS.CustomData.EnumCollect.AltFrame.Mode),
                VPS.GCSViews.FlightPlanner.instance.GetAltFrame());

            info.feature = new FeatureInfo(list);

            (info as SaveKMLWPInfo).AllowHome = true;
            (info as SaveKMLWPInfo).SaveAltMode = SaveKMLWPInfo.KMLAltMode.relativeToGround;
            advPropertyGrid1.SelectedObject = info;
        }

        SaveWPInfo info;

        public void SaveWaypoint()
        {
            if (!string.IsNullOrEmpty(TXT_FileName.Text))
            {
                string file = TXT_FileName.Text;
                saveWaypointsKML(file);
            }
        }

        private void saveWaypointsKML(string file)
        {
            List<PointLatLngAlt> wpList =
                CustomData.WP.WPGlobalData.WPListChangeAltFrame(
                    CustomData.WP.WPGlobalData.instance.GetWPList(),
                    CustomData.EnumCollect.AltFrame.Terrain);
            PointLatLngAlt home = wpList[0];
            wpList.RemoveAt(0);

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

            //MainData Points
            w.WriteStartElement("Folder");
            w.WriteStartElement("name");
            w.WriteString("Waypoints");
            w.WriteEndElement();//name
            w.WriteStartElement("description");
            w.WriteString("Waypoints in the Mission.");
            w.WriteEndElement();//description
            if((info as SaveKMLWPInfo).AllowHome)
            {
                #region HomePoint
                w.WriteStartElement("Placemark");

                // Write Point element
                w.WriteStartElement("name");
                w.WriteString(string.Format("Home"));
                w.WriteEndElement();//name
                w.WriteStartElement("visibility");
                w.WriteString("false");
                w.WriteEndElement();//visibility
                w.WriteStartElement("description");
                w.WriteString("HOME");
                w.WriteEndElement();//description
                w.WriteStartElement("styleUrl");
                w.WriteString("#waypointStyle");
                w.WriteEndElement();//styleUrl
                w.WriteStartElement("ExtendedData", "www.dji.com");

                var layerInfo = CustomData.Layer.MemoryLayerCache.GetLayerFromMemoryCache(
                    CustomData.WP.WPGlobalData.instance.GetLayer()
                    );
                if (layerInfo != null)
                {
                    w.WriteStartElement("local");
                    w.WriteStartElement("scale");
                    w.WriteString(layerInfo.Scale.ToString());
                    w.WriteEndElement();//scale

                    w.WriteEndElement();//local
                }
                w.WriteStartElement("param1");
                w.WriteString("0");
                w.WriteEndElement();//param1
                w.WriteStartElement("param2");
                w.WriteString("0");
                w.WriteEndElement();//param2
                w.WriteStartElement("param3");
                w.WriteString("0");
                w.WriteEndElement();//param3
                w.WriteStartElement("param4");
                w.WriteString("0");
                w.WriteEndElement();//param4
                w.WriteEndElement();//ExtendedData

                w.WriteStartElement("Point");

                w.WriteStartElement("altitudeMode");

                if ((info as SaveKMLWPInfo).SaveAltMode == SaveKMLWPInfo.KMLAltMode.absolute)
                    w.WriteString("absolute");
                else if ((info as SaveKMLWPInfo).SaveAltMode == SaveKMLWPInfo.KMLAltMode.relativeToGround)
                    w.WriteString("relativeToGround");
                else
                    w.WriteString("clampToGround");

                w.WriteEndElement();//altitudeMode
                w.WriteStartElement("coordinates");

                w.WriteString(string.Format("{0},{1},{2}", home.Lng, home.Lat, home.Alt));
                w.WriteEndElement();//coordinates
                w.WriteEndElement();//Point
                w.WriteEndElement();//Placemark
                #endregion
            }

            #region WPPoints
            int index = 0;
            for (int i = 0; i < wpList.Count; i++)
            {
                bool isVisbility = false;
                if (CustomData.WP.WPCommands.CoordsWPCommands.Contains(wpList[i].Tag))
                    isVisbility = true;
                w.WriteStartElement("Placemark");

                // Write Point element
                w.WriteStartElement("name");
                if (isVisbility)
                    w.WriteString(wpList[index].Tag + " " + (index).ToString());
                else
                    w.WriteString(wpList[index].Tag);
                w.WriteEndElement();//name

                w.WriteStartElement("visibility");
                w.WriteString(isVisbility.ToString());
                //if (isVisbility)
                //    w.WriteString("true");
                //else
                //    w.WriteString("false");
                w.WriteEndElement();//visibility

                w.WriteStartElement("description");
                w.WriteString(wpList[index].Tag);
                w.WriteEndElement();//description

                if (isVisbility)
                {
                    w.WriteStartElement("styleUrl");
                    w.WriteString("#waypointStyle");
                    w.WriteEndElement();//styleUrl
                }

                w.WriteStartElement("ExtendedData", "www.dji.com");
                w.WriteStartElement("param1");
                w.WriteString(wpList[i].Param1.ToString());
                w.WriteEndElement();//param1
                w.WriteStartElement("param2");
                w.WriteString(wpList[i].Param2.ToString());
                w.WriteEndElement();//param2
                w.WriteStartElement("param3");
                w.WriteString(wpList[i].Param3.ToString());
                w.WriteEndElement();//param3
                w.WriteStartElement("param4");
                w.WriteString(wpList[i].Param4.ToString());
                w.WriteEndElement();//param4
                w.WriteEndElement();//ExtendedData

                if (isVisbility)
                {
                    w.WriteStartElement("Point");
                    w.WriteStartElement("altitudeMode");

                    if ((info as SaveKMLWPInfo).SaveAltMode == SaveKMLWPInfo.KMLAltMode.absolute)
                        w.WriteString("absolute");
                    else if ((info as SaveKMLWPInfo).SaveAltMode == SaveKMLWPInfo.KMLAltMode.relativeToGround)
                        w.WriteString("relativeToGround");
                    else
                        w.WriteString("clampToGround");

                    w.WriteEndElement();//altitudeMode
                    w.WriteStartElement("coordinates");
                    w.WriteString(string.Format("{0},{1},{2}",
                        wpList[index].Lng,
                        wpList[index].Lat,
                        wpList[index].Alt));
                    w.WriteEndElement();//coordinates
                    w.WriteEndElement();//Point
                }
                w.WriteEndElement();//Placemark

                if (isVisbility)
                    index++;
            }
            w.WriteEndElement();//Folder
            #endregion
            {
                if (info.AltMode.ToString() == CustomData.EnumCollect.AltFrame.Absolute)
                    wpList = CustomData.WP.WPGlobalData.WPListChangeAltFrame(
                        wpList, CustomData.EnumCollect.AltFrame.Absolute);
                else if (info.AltMode.ToString() == CustomData.EnumCollect.AltFrame.Terrain)
                    wpList = CustomData.WP.WPGlobalData.WPListChangeAltFrame(
                        wpList, CustomData.EnumCollect.AltFrame.Terrain);
                else
                    wpList = CustomData.WP.WPGlobalData.WPListChangeAltFrame(
                        wpList, CustomData.EnumCollect.AltFrame.Terrain);

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

                if ((info as SaveKMLWPInfo).SaveAltMode == SaveKMLWPInfo.KMLAltMode.absolute)
                    w.WriteString("absolute");
                else if ((info as SaveKMLWPInfo).SaveAltMode == SaveKMLWPInfo.KMLAltMode.relativeToGround)
                    w.WriteString("relativeToGround");
                else
                    w.WriteString("clampToGround");

                w.WriteEndElement();//altitudeMode
                w.WriteStartElement("coordinates");

                string pointList = "";

                foreach (var marker in wpList)
                {
                    if (marker != null)
                    {
                        pointList += string.Format("{0},{1},{2} ", marker.Lng, marker.Lat, marker.Alt);
                    }
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
        }
    }

    class SaveWPInfo
    {
        [Category("航点信息"), DisplayName("航摄基准"), ReadOnly(true)]
        public string BaseOfWPList { get; set; }
        [Category("航点信息"), DisplayName("航飞路程"), ReadOnly(true)]
        public string DistanceOfWPList { get; set; }
        [Category("航点信息"), DisplayName("高度框架"), ReadOnly(true)]
        public VPS.CustomData.EnumCollect.AltFrame.Mode AltMode { get; set; }
        [Category("航点信息"), Description("要素信息"), DisplayName("航线"),
            TypeConverter(typeof(ExpandableObjectConverter)),
            Editor(typeof(CustomControls.PositionListUITypeEditor), typeof(UITypeEditor))]
        public FeatureInfo feature { get; set; }
    }

    class SaveKMLWPInfo : SaveWPInfo
    {
        public enum KMLAltMode
        {
            clampToGround,
            absolute,
            relativeToGround
        }

        [Category("保存信息"), DisplayName("初始位置")]
        public bool AllowHome { get; set; }

        [Category("保存信息"), DisplayName("高度框架")]
        public KMLAltMode SaveAltMode { get; set; }

    }

    class FeatureInfo
    {
        public List<PointLatLngAlt> features;

        public FeatureInfo(List<PointLatLngAlt> list)
        {
            features = new List<PointLatLngAlt>(list);
            averAbsolute = VPS.CustomData.WP.WPGlobalData.GetAverAbsoluteAlt(list);
            ValidTerrain = new ValidAltPoint(
                VPS.CustomData.WP.WPGlobalData.GetValidPoint(list));
        }

        [Category("要素集合"), DisplayName("要素数量"), ReadOnly(true)]
        public int Count
        {
            get { return features.Count; }
        }

        double averAbsolute = 0;
        [Category("要素集合"), DisplayName("平均飞行高度（绝对）"), ReadOnly(true)]
        public double AverAbsolute
        {
            get { return averAbsolute; }
        }

        [Category("要素集合"), DisplayName("飞行高度异常点"), ReadOnly(true)]
        public ValidAltPoint ValidTerrain { set; get; }

        public override string ToString()
        {
            string str = features.Count.ToString();
            return str;
        }
    }

    class ValidAltPoint
    {
        List<int> indexs = new List<int>();
        List<double> terrains = new List<double>();

        public ValidAltPoint()
        {
        }

        public ValidAltPoint(List<double[]> list)
        {
            foreach(var data in list)
            {
                indexs.Add((int)data[0]);
                terrains.Add(data[1]);
            }
        }

        public override string ToString()
        {
            if (indexs.Count > 0)
            {
                string str = "航点高度异常:";
                for (int i = 0; i < indexs.Count; i++)
                {
                    str += " " + indexs[i].ToString() + ";";
                }
                return str;
            }
            else
                return "航点高度无异常";
        }
    }
}
