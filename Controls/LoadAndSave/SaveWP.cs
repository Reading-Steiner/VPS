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
    public partial class SaveWP : Office2007Form
    {
        public SaveWP()
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
                fd.InitialDirectory = Settings.Instance["WPFileDirectory"] ?? "";

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
            info = new SaveWPInfo();

            info.fileName = file;
            info.fileType = CustomFile.UniversalMethod.GetFileType(file);

            var list = VPS.CustomData.WP.WPGlobalData.instance.GetWPList();
            var baseAlt = VPS.CustomData.WP.WPGlobalData.GetBaseAlt(list);
            var totalDist = VPS.CustomData.WP.WPGlobalData.GetTotalDist(list);

            info.baseOfWPList = baseAlt.ToString("0.## m");
            info.distanceOfWPList = totalDist.ToString("0.## m");
            info.altMode = (VPS.CustomData.EnumCollect.AltFrame.Mode)Enum.Parse(
                typeof(VPS.CustomData.EnumCollect.AltFrame.Mode),
                VPS.GCSViews.FlightPlanner.instance.GetAltFrame());

            info.feature = new FeatureInfo(list);

            info.saveAllowHome = true;

            advPropertyGrid1.SelectedObject = info;
        }

        private void BindingDataSourceKML(string file)
        {
            info = new SaveKMLWPInfo();

            (info as SaveKMLWPInfo).saveFileName = file;

            info.fileName = file;
            info.fileType = ".kml";

            var list = VPS.CustomData.WP.WPGlobalData.instance.GetWPList();
            var baseAlt = VPS.CustomData.WP.WPGlobalData.GetBaseAlt(list);
            var totalDist = VPS.CustomData.WP.WPGlobalData.GetTotalDist(list);

            info.baseOfWPList = baseAlt.ToString("0.## m");
            info.distanceOfWPList = totalDist.ToString("0.## m");
            info.altMode = (VPS.CustomData.EnumCollect.AltFrame.Mode)Enum.Parse(
                typeof(VPS.CustomData.EnumCollect.AltFrame.Mode),
                VPS.GCSViews.FlightPlanner.instance.GetAltFrame());

            info.feature = new FeatureInfo(list);

            info.saveAllowHome = true;

            advPropertyGrid1.SelectedObject = info;
        }

        private void BindingDataSourceSHP(string file)
        {
            info = new SaveSHPWPInfo();

            (info as SaveSHPWPInfo).saveFileName = file;

            info.fileName = file;
            info.fileType = ".shp";

            var list = VPS.CustomData.WP.WPGlobalData.instance.GetWPList();
            var baseAlt = VPS.CustomData.WP.WPGlobalData.GetBaseAlt(list);
            var totalDist = VPS.CustomData.WP.WPGlobalData.GetTotalDist(list);

            info.baseOfWPList = baseAlt.ToString("0.## m");
            info.distanceOfWPList = totalDist.ToString("0.## m");
            info.altMode = (VPS.CustomData.EnumCollect.AltFrame.Mode)Enum.Parse(
                typeof(VPS.CustomData.EnumCollect.AltFrame.Mode),
                VPS.GCSViews.FlightPlanner.instance.GetAltFrame());

            info.feature = new FeatureInfo(list);
            info.saveAllowHome = true;

            advPropertyGrid1.SelectedObject = info;
        }

        SaveWPInfo info;

        public void SaveWaypoint()
        {
            if (!string.IsNullOrEmpty(info.fileName))
            {
                if (info.fileType.Contains("kml"))
                {
                    string file = info.fileName;
                    saveWaypointsKML(file);
                }
                if (info.fileType.Contains("shp"))
                {
                    string file = info.fileName;
                    saveWaypointsSHP(file);
                }
            }
        }

        private void saveWaypointsKML(string file)
        {
            string porgressKey = VPS.Controls.MainInfo.TopMainInfo.instance.CreateProgressEnter("保存为 KML");
            string messageKey = VPS.Controls.MainInfo.TopMainInfo.instance.CreateMessageBoxEnter();
            var bar = VPS.Controls.MainInfo.TopMainInfo.instance.GetProgress(porgressKey);
            var box = VPS.Controls.MainInfo.TopMainInfo.instance.GetMessageBox(messageKey);

            List<PointLatLngAlt> wpList =
                CustomData.WP.WPGlobalData.WPListChangeAltFrame(
                    CustomData.WP.WPGlobalData.instance.GetWPList(),
                    CustomData.EnumCollect.AltFrame.Terrain);
            PointLatLngAlt home = wpList[0];
            wpList.RemoveAt(0);

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

                //MainData Points
                w.WriteStartElement("Folder");
                w.WriteStartElement("name");
                w.WriteString("Waypoints");
                w.WriteEndElement();//name
                w.WriteStartElement("description");
                w.WriteString("Waypoints in the Mission.");
                w.WriteEndElement();//description
                if ((info as SaveKMLWPInfo).saveAllowHome)
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

                    // Write Point Loc
                    w.WriteStartElement("Point");

                    w.WriteStartElement("altitudeMode");
                    if ((info as SaveKMLWPInfo).saveAltMode == SaveKMLWPInfo.KMLAltMode.absolute)
                        w.WriteString("absolute");
                    else if ((info as SaveKMLWPInfo).saveAltMode == SaveKMLWPInfo.KMLAltMode.relativeToGround)
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
                int pointVisibleIndex = 0; int Counter = 0;
                for (int pointIndex = 0; pointIndex < wpList.Count; pointIndex++)
                {
                    var marker = wpList[pointIndex];

                    bool isVisbility = false;
                    if (CustomData.WP.WPCommands.CoordsWPCommands.Contains(marker.Tag))
                        isVisbility = true;
                    w.WriteStartElement("Placemark");

                    // Write Point element
                    w.WriteStartElement("name");
                    if (isVisbility)
                        w.WriteString(marker.Tag + " " + (pointVisibleIndex).ToString());
                    else
                        w.WriteString(marker.Tag);
                    w.WriteEndElement();//name

                    w.WriteStartElement("visibility");
                    w.WriteString(isVisbility.ToString());
                    w.WriteEndElement();//visibility

                    w.WriteStartElement("description");
                    w.WriteString(marker.Tag);
                    w.WriteEndElement();//description

                    if (isVisbility)
                    {
                        w.WriteStartElement("styleUrl");
                        w.WriteString("#waypointStyle");
                        w.WriteEndElement();//styleUrl
                    }

                    w.WriteStartElement("ExtendedData", "www.dji.com");
                    w.WriteStartElement("param1");
                    w.WriteString(wpList[pointIndex].Param1.ToString());
                    w.WriteEndElement();//param1
                    w.WriteStartElement("param2");
                    w.WriteString(wpList[pointIndex].Param2.ToString());
                    w.WriteEndElement();//param2
                    w.WriteStartElement("param3");
                    w.WriteString(wpList[pointIndex].Param3.ToString());
                    w.WriteEndElement();//param3
                    w.WriteStartElement("param4");
                    w.WriteString(wpList[pointIndex].Param4.ToString());
                    w.WriteEndElement();//param4
                    w.WriteEndElement();//ExtendedData

                    if (isVisbility)
                    {
                        w.WriteStartElement("Point");
                        w.WriteStartElement("altitudeMode");

                        if ((info as SaveKMLWPInfo).saveAltMode == SaveKMLWPInfo.KMLAltMode.absolute)
                            w.WriteString("absolute");
                        else if ((info as SaveKMLWPInfo).saveAltMode == SaveKMLWPInfo.KMLAltMode.relativeToGround)
                            w.WriteString("relativeToGround");
                        else
                            w.WriteString("clampToGround");

                        w.WriteEndElement();//altitudeMode
                        w.WriteStartElement("coordinates");
                        w.WriteString(string.Format("{0},{1},{2}",
                            wpList[pointVisibleIndex].Lng,
                            wpList[pointVisibleIndex].Lat,
                            wpList[pointVisibleIndex].Alt));
                        w.WriteEndElement();//coordinates
                        w.WriteEndElement();//Point
                    }
                    w.WriteEndElement();//Placemark

                    if (isVisbility)
                        pointVisibleIndex++;

                    bar.SetProgress((double)(++Counter) / wpList.Count * 0.5);
                }
                w.WriteEndElement();//Folder
                #endregion
                {
                    if (info.altMode.ToString() == CustomData.EnumCollect.AltFrame.Absolute)
                        wpList = CustomData.WP.WPGlobalData.WPListChangeAltFrame(
                            wpList, CustomData.EnumCollect.AltFrame.Absolute);
                    else if (info.altMode.ToString() == CustomData.EnumCollect.AltFrame.Terrain)
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

                    if ((info as SaveKMLWPInfo).saveAltMode == SaveKMLWPInfo.KMLAltMode.absolute)
                        w.WriteString("absolute");
                    else if ((info as SaveKMLWPInfo).saveAltMode == SaveKMLWPInfo.KMLAltMode.relativeToGround)
                        w.WriteString("relativeToGround");
                    else
                        w.WriteString("clampToGround");

                    w.WriteEndElement();//altitudeMode
                    w.WriteStartElement("coordinates");

                    string pointList = "";


                    for (int pointLineIndex = 0; pointLineIndex < wpList.Count; pointLineIndex++)
                    {
                        var marker = wpList[pointLineIndex];
                        if (marker != null)
                        {
                            if (CustomData.WP.WPCommands.CoordsWPCommands.Contains(marker.Tag))
                            {
                                pointList += string.Format("{0},{1},{2} ", marker.Lng, marker.Lat, marker.Alt);
                            }
                        }
                        bar.SetProgress((double)(++Counter) / wpList.Count * 0.5);
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

        private void saveWaypointsSHP(string file)
        {
            List<PointLatLngAlt> wpList = 
                VPS.CustomData.WP.WPGlobalData.instance.GetWPList();
            wpList = VPS.CustomData.WP.WPGlobalData.WPListChangeAltFrame(
                wpList, VPS.CustomData.EnumCollect.AltFrame.Terrain);
            if (!info.saveAllowHome)
                VPS.CustomData.WP.WPGlobalData.WPListRemoveHome(wpList);

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
                shp.SaveSHP(file, wpList);
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
    }

    [TypeConverter(typeof(PropertySorter))]
    class SaveWPInfo
    {
        [Browsable(false)]
        public string fileName = "";

        [Browsable(false)]
        public string fileType = "";

        [Category("航点信息"), DisplayName("航摄基准"), ReadOnly(true)]
        [PropertyOrder(0b00010001)]
        public string baseOfWPList { get; set; }

        [Category("航点信息"), DisplayName("航飞路程"), ReadOnly(true)]
        [PropertyOrder(0b00010010)]
        public string distanceOfWPList { get; set; }

        [Category("航点信息"), DisplayName("高度框架"), ReadOnly(true)]
        [PropertyOrder(0b00010011)]
        public VPS.CustomData.EnumCollect.AltFrame.Mode altMode { get; set; }

        [Category("航点信息"), Description("要素信息"), DisplayName("航线")]
        [PropertyOrder(0b00010100)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Editor(typeof(CustomControls.PositionListUITypeEditor), typeof(UITypeEditor))]
        public FeatureInfo feature { get; set; }

        [Category("保存信息"), DisplayName("初始位置")]
        [PropertyOrder(0b00001000)]
        public bool saveAllowHome { get; set; }

    }

    [TypeConverter(typeof(PropertySorter))]
    class SaveKMLWPInfo : SaveWPInfo
    {
        public enum KMLAltMode
        {
            clampToGround,
            absolute,
            relativeToGround
        }
        [Category("保存信息"), DisplayName("文件")]
        [PropertyOrder(0b00000001)]
        [Editor(typeof(CustomControls.ContentUITypeEditor), typeof(UITypeEditor))]
        public string saveFileName { get; set; }

        [Category("保存信息"), DisplayName("文件类型"), ReadOnly(true)]
        [PropertyOrder(0b00000010)]
        public string saveFileType { set; get; } = "Google Earth KML";

        [Category("保存信息"), DisplayName("高度框架")]
        [PropertyOrder(0b00000011)]
        public KMLAltMode saveAltMode { get; set; }

    }

    [TypeConverter(typeof(PropertySorter))]
    class SaveSHPWPInfo : SaveWPInfo
    {
        [Category("保存信息"), DisplayName("文件")]
        [PropertyOrder(0b00000001)]
        [Editor(typeof(CustomControls.ContentUITypeEditor), typeof(UITypeEditor))]
        public string saveFileName { get; set; }

        [Category("保存信息"), DisplayName("文件类型"), ReadOnly(true)]
        [PropertyOrder(0b00000010)]
        public string saveFileType { set; get; } = "ShapeFile";

        [Category("保存信息"), DisplayName("空间参考")]
        [PropertyOrder(0b00000011)]
        public string saveFileProference { set; get; } =
            DotSpatial.Projections.KnownCoordinateSystems.Geographic.World.WGS1984.ToString();

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

        [Category("要素集合"), DisplayName("\t\t\t要素数量"), ReadOnly(true)]
        public int Count
        {
            get { return features.Count; }
        }

        double averAbsolute = 0;
        [Category("要素集合"), DisplayName("\t\t平均飞行高度（绝对）"), ReadOnly(true)]
        public double AverAbsolute
        {
            get { return averAbsolute; }
        }

        [Category("要素集合"), DisplayName("\t飞行高度异常点"), ReadOnly(true)]
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
