﻿using DotSpatial.Data;
using DotSpatial.Projections;
using GDAL;
using GeoUtility.GeoSystem;
using GeoUtility.GeoSystem.Base;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Ionic.Zip;
using log4net;
using VPS.ArduPilot;
using VPS.Controls;
using VPS.Grid;
using VPS.Maps;
using VPS.Plugin;
using VPS.Properties;
using VPS.Utilities;
using ProjNet.CoordinateSystems;
using ProjNet.CoordinateSystems.Transformations;
using SharpKml.Base;
using SharpKml.Dom;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using GeoAPI.CoordinateSystems;
using GeoAPI.CoordinateSystems.Transformations;
using Feature = SharpKml.Dom.Feature;
using Formatting = Newtonsoft.Json.Formatting;
using ILog = log4net.ILog;
using Placemark = SharpKml.Dom.Placemark;
using Point = System.Drawing.Point;

namespace VPS.GCSViews
{
    public partial class FlightPlanner : MyUserControl, IDeactivate, IActivate
    {
        public FlightPlanner()
        {
            InitializeComponent();
            //System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            Init();
        }


        static public Controls.myGMAP myMap;
        static public Object thisLock = new Object();
        
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static Propagation prop;
        //public static GMapOverlay airportsoverlay;
        public static GMapOverlay objectsoverlay;
        public static GMapOverlay poioverlay = new GMapOverlay("POI");
        public static GMapOverlay polygonsoverlay;
        public static GMapOverlay routesoverlay;
        private static GMapOverlay rallypointoverlay;
        private static GMapOverlay layerPolygonsOverlay;
        internal GMapPolygon drawnpolygon;
        private static string zone = "50s";
        private readonly Random rnd = new Random();
        public GMapMarker center = new GMarkerGoogle(new PointLatLng(0.0, 0.0), GMarkerGoogleType.none);
        private Dictionary<string, string[]> cmdParamNames = new Dictionary<string, string[]>();
        private GMapMarkerRect CurentRectMarker;
        private GMapMarker CurrentGMapMarker;
        public GMapMarker currentMarker;
        private GMapMarkerPOI CurrentPOIMarker;
        private GMapMarkerRallyPt CurrentRallyPt;
        public GMapOverlay drawnpolygonsoverlay;
        private bool fetchpathrip;
        public GMapOverlay geofenceoverlay;
        public GMapPolygon geofencepolygon;
        private bool grid;

        #region 选中列表
        private List<int> wpMarkersGroup = new List<int>();
        private List<int> polyMarkersGroup = new List<int>();
        #endregion

        #region 鼠标事件响应

        #region 右键菜单消失标记
        private bool IsMouseClickOffMenu = false;
        #endregion

        #region 鼠标按下标记
        private bool IsMouseDown = false;
        #endregion

        #region 标记可被添加
        private bool IsMarkerAddable = false;
        #endregion

        #region 地图可被拖动
        private bool IsWndDroppable = false;
        #endregion

        #region 地图被拖动
        private bool isWndDroping = false;
        private bool IsWndDroping
        {
            get { return isWndDroping; }
            set
            {
                isWndDroping = value;
                if (isWndDroping)
                {
                    if (MouseDownCurrentPoint.X != MouseDownStartPoint.X)
                    {
                        double tanQ = (double)(MouseDownStartPoint.Y - MouseDownCurrentPoint.Y) /
                            (double)(MouseDownCurrentPoint.X - MouseDownStartPoint.X);
                        if (tanQ < 0.5 && tanQ > -0.5)
                        {
                            if (MouseDownCurrentPoint.X > MouseDownStartPoint.X)
                                this.MainMap.Cursor = Cursors.PanEast;
                            else if (MouseDownCurrentPoint.X < MouseDownStartPoint.X)
                                this.MainMap.Cursor = Cursors.PanWest;
                            else
                                this.MainMap.Cursor = Cursors.NoMove2D;
                        }
                        else if (tanQ > 2 || tanQ < -2)
                        {
                            if (MouseDownCurrentPoint.Y > MouseDownStartPoint.Y)
                                this.MainMap.Cursor = Cursors.PanSouth;
                            else if (MouseDownCurrentPoint.Y < MouseDownStartPoint.Y)
                                this.MainMap.Cursor = Cursors.PanNorth;
                            else
                                this.MainMap.Cursor = Cursors.NoMove2D;
                        }
                        else
                        {
                            if (MouseDownCurrentPoint.X > MouseDownStartPoint.X &&
                                MouseDownCurrentPoint.Y < MouseDownStartPoint.Y)
                                this.MainMap.Cursor = Cursors.PanNE;
                            else if (MouseDownCurrentPoint.X < MouseDownStartPoint.X &&
                                MouseDownCurrentPoint.Y < MouseDownStartPoint.Y)
                                this.MainMap.Cursor = Cursors.PanNW;
                            else if (MouseDownCurrentPoint.X > MouseDownStartPoint.X &&
                                MouseDownCurrentPoint.Y > MouseDownStartPoint.Y)
                                this.MainMap.Cursor = Cursors.PanSE;
                            else if (MouseDownCurrentPoint.X < MouseDownStartPoint.X &&
                                MouseDownCurrentPoint.Y > MouseDownStartPoint.Y)
                                this.MainMap.Cursor = Cursors.PanSW;
                            else
                                this.MainMap.Cursor = Cursors.NoMove2D;
                        }
                    }
                    else if (MouseDownCurrentPoint.Y > MouseDownStartPoint.Y)
                        this.MainMap.Cursor = Cursors.PanSouth;
                    else if (MouseDownCurrentPoint.Y < MouseDownStartPoint.Y)
                        this.MainMap.Cursor = Cursors.PanNorth;
                    else
                        this.MainMap.Cursor = Cursors.NoMove2D;
                }
                else
                {
                    if (IsDrawPolygongridMode || IsDrawWPMode)
                        this.MainMap.Cursor = Cursors.Cross;
                    else
                        this.MainMap.Cursor = Cursors.Default;
                }
            }
        }
        #endregion

        #region 标记可被拖动
        private bool IsMarkerDroppable = false;
        #endregion

        #region 标记被拖动
        private bool isMarkerDroping = false;
        private bool IsMarkerDroping
        {
            get { return isMarkerDroping; }
            set
            {
                isMarkerDroping = value;
                if (isMarkerDroping)
                {
                    this.MainMap.Cursor = Cursors.Hand;
                }
                else
                {
                    if (IsDrawPolygongridMode || IsDrawWPMode)
                        this.MainMap.Cursor = Cursors.Cross;
                    else
                        this.MainMap.Cursor = Cursors.Default;
                }
            }
        }
        #endregion

        #region 标记可被选择
        private bool IsMarkerPickable;
        #endregion

        #endregion
        public GMapOverlay kmlpolygonsoverlay;

        private WPOverlay overlay;
        /// <summary>
        /// Try to reduce the number of map position changes generated by the code
        /// </summary>
        private DateTime lastmapposchange = DateTime.MinValue;

        private DateTime mapupdate = DateTime.MinValue;
        private string mobileGpsLog = string.Empty;

        private ComponentResourceManager rm = new ComponentResourceManager(typeof(FlightPlanner));
        private int selectedrow;
        private bool sethome;

        private PointLatLng startmeasure;
        public GMapOverlay top;
        public GMapPolygon wppolygon;
        private GMapMarker CurrentMidLine;


        public void Init()
        {
            instance = this;

            myMap = MainMap;

            // config map             
            MainMap.CacheLocation = Settings.GetDataDirectory() +
                                                   "gmapcache" + Path.DirectorySeparatorChar;

            MainMap.OnPositionChanged += MainMap_OnCurrentPositionChanged;
            MainMap.OnTileLoadStart += MainMap_OnTileLoadStart;
            MainMap.OnTileLoadComplete += MainMap_OnTileLoadComplete;
            MainMap.OnMarkerClick += MainMap_OnMarkerClick;
            MainMap.OnMapZoomChanged += MainMap_OnMapZoomChanged;
            MainMap.OnMapTypeChanged += MainMap_OnMapTypeChanged;
            MainMap.MouseMove += MainMap_MouseMove;
            MainMap.MouseDown += MainMap_MouseDown;
            MainMap.MouseUp += MainMap_MouseUp;
            MainMap.OnMarkerEnter += MainMap_OnMarkerEnter;
            MainMap.OnMarkerLeave += MainMap_OnMarkerLeave;

            MainMap.MapScaleInfoEnabled = false;
            MainMap.ScalePen = new Pen(Color.Red);

            MainMap.DisableFocusOnMouseEnter = true;

            MainMap.ForceDoubleBuffer = false;

            //WebRequest.DefaultWebProxy.Credentials = System.Net.CredentialCache.DefaultCredentials;

            // get map type
            comboBoxMapType.ValueMember = "Name";
            comboBoxMapType.DataSource = GMapProviders.List.ToArray();
            comboBoxMapType.SelectedItem = MainMap.MapProvider;

            comboBoxMapType.SelectedValueChanged += comboBoxMapType_SelectedValueChanged;

            MainMap.RoutesEnabled = true;

            //MainMap.MaxZoom = 18;

            // get zoom  
            MainMap.MinZoom = 0;
            MainMap.MaxZoom = 24;

            // draw this layer first
            layerPolygonsOverlay = new GMapOverlay("layerpolygons");
            MainMap.Overlays.Add(layerPolygonsOverlay);

            kmlpolygonsoverlay = new GMapOverlay("kmlpolygons");
            MainMap.Overlays.Add(kmlpolygonsoverlay);

            geofenceoverlay = new GMapOverlay("geofence");
            MainMap.Overlays.Add(geofenceoverlay);

            rallypointoverlay = new GMapOverlay("rallypoints");
            MainMap.Overlays.Add(rallypointoverlay);

            routesoverlay = new GMapOverlay("routes");
            MainMap.Overlays.Add(routesoverlay);

            polygonsoverlay = new GMapOverlay("polygons");
            MainMap.Overlays.Add(polygonsoverlay);

            //airportsoverlay = new GMapOverlay("airports");
            //MainMap.Overlays.Add(airportsoverlay);

            objectsoverlay = new GMapOverlay("objects");
            MainMap.Overlays.Add(objectsoverlay);

            drawnpolygonsoverlay = new GMapOverlay("drawnpolygons");
            MainMap.Overlays.Add(drawnpolygonsoverlay);

            MainMap.Overlays.Add(poioverlay);

            prop = new Propagation(MainMap);

            top = new GMapOverlay("top");
            //MainMap.Overlays.Add(top);

            objectsoverlay.Markers.Clear();

            // set current marker
            currentMarker = new GMarkerGoogle(MainMap.Position, GMarkerGoogleType.red);
            //top.Markers.Add(currentMarker);

            // map center
            center = new GMarkerGoogle(MainMap.Position, GMarkerGoogleType.none);
            top.Markers.Add(center);

            MainMap.Zoom = 3;

            updateCMDParams();


            updateMapType(null, null);

            // hide the map to prevent redraws when its loaded
            panelMap.Visible = false;


            // setup geofence
            List<PointLatLng> polygonPoints = new List<PointLatLng>();
            geofencepolygon = new GMapPolygon(polygonPoints, "geofence");
            geofencepolygon.Stroke = new Pen(Color.Pink, 5);
            geofencepolygon.Fill = Brushes.Transparent;

            //setup drawnpolgon
            List<PointLatLng> polygonPoints2 = new List<PointLatLng>();
            drawnpolygon = new GMapPolygon(polygonPoints2, "drawnpoly");
            drawnpolygon.Stroke = new Pen(Color.Red, 2);
            drawnpolygon.Fill = Brushes.Transparent;

            SetInitState();
            /*
            var timer = new System.Timers.Timer();

            // 2 second
            timer.Interval = 2000;
            timer.Elapsed += updateMapType;

            timer.Start();
            */
        }







        private void SetInitState()
        {
            LeaveDrawPolygonState();
            this.DrawPolygonHandle += this.DrawPolygonState;
            this.LeaveDrawPolygonHandle += this.LeaveDrawPolygonState;
            LeaveDrawWPState();
            this.DrawWPHandle += this.DrawWPState;
            this.LeaveDrawWPHandle += this.LeaveDrawWPState;

            SetNoneLayerState();
            MainV2.instance.LoadLayerHandle += this.SetLaodLayerState;
            MainV2.instance.NoneLayerHandle += this.SetNoneLayerState;
        }

        private void DrawPolygonState()
        {
            this.MainMap.Cursor = Cursors.Cross;
            this.polyicon.IsSelected = true;
            this.WPicon.IsSelected = false;
            this.addPolygonToolStripMenuItem.Checked = true;
            this.addWPToolStripMenuItem.Checked = false;
            writeKML();
            redrawPolygonSurvey();
        }

        private void LeaveDrawPolygonState()
        {
            this.MainMap.Cursor = Cursors.Default;
            this.polyicon.IsSelected = false;
            this.addPolygonToolStripMenuItem.Checked = false;
            redrawPolygonSurvey();
        }

        private void DrawWPState()
        {
            this.MainMap.Cursor = Cursors.Cross;
            this.addWPToolStripMenuItem.Checked = true;
            this.WPicon.IsSelected = true;
            this.polyicon.IsSelected = false;
            this.addPolygonToolStripMenuItem.Checked = false;
            writeKML();
            redrawPolygonSurvey();
        }

        private void LeaveDrawWPState()
        {
            this.MainMap.Cursor = Cursors.Default;
            this.WPicon.IsSelected = false;
            this.addWPToolStripMenuItem.Checked = false;
            writeKML();
        }


        private void SetLaodLayerState()
        {
            this.zoomicon.IsSelected = true;
        }

        private void SetNoneLayerState()
        {
            this.zoomicon.IsSelected = false;
        }

        public static FlightPlanner instance { get; set; }

        public List<PointLatLngAlt> pointlist { get; set; } = new List<PointLatLngAlt>();


        public void Activate()
        {
            timer1.Start();

            updateHome();

            setWPParams();

            updateCMDParams();

            updateDisplayView();
        }

        public void Deactivate()
        {
            config(true);
            timer1.Stop();
        }

        public static RectLatLng GetBoundingLayer(GMapOverlay o)
        {
            RectLatLng ret = RectLatLng.Empty;

            double left = double.MaxValue;
            double top = double.MinValue;
            double right = double.MinValue;
            double bottom = double.MaxValue;

            if (o.IsVisibile)
            {
                foreach (var m in o.Markers)
                {
                    if (m.IsVisible)
                    {
                        // left
                        if (m.Position.Lng < left)
                        {
                            left = m.Position.Lng;
                        }

                        // top
                        if (m.Position.Lat > top)
                        {
                            top = m.Position.Lat;
                        }

                        // right
                        if (m.Position.Lng > right)
                        {
                            right = m.Position.Lng;
                        }

                        // bottom
                        if (m.Position.Lat < bottom)
                        {
                            bottom = m.Position.Lat;
                        }
                    }
                }
                foreach (GMapRoute route in o.Routes)
                {
                    if (route.IsVisible && route.From.HasValue && route.To.HasValue)
                    {
                        foreach (PointLatLng p in route.Points)
                        {
                            // left
                            if (p.Lng < left)
                            {
                                left = p.Lng;
                            }

                            // top
                            if (p.Lat > top)
                            {
                                top = p.Lat;
                            }

                            // right
                            if (p.Lng > right)
                            {
                                right = p.Lng;
                            }

                            // bottom
                            if (p.Lat < bottom)
                            {
                                bottom = p.Lat;
                            }
                        }
                    }
                }
                foreach (GMapPolygon polygon in o.Polygons)
                {
                    if (polygon.IsVisible)
                    {
                        foreach (PointLatLng p in polygon.Points)
                        {
                            // left
                            if (p.Lng < left)
                            {
                                left = p.Lng;
                            }

                            // top
                            if (p.Lat > top)
                            {
                                top = p.Lat;
                            }

                            // right
                            if (p.Lng > right)
                            {
                                right = p.Lng;
                            }

                            // bottom
                            if (p.Lat < bottom)
                            {
                                bottom = p.Lat;
                            }
                        }
                    }
                }
            }

            if (left != double.MaxValue && right != double.MinValue && top != double.MinValue && bottom != double.MaxValue)
            {
                ret = RectLatLng.FromLTRB(left, top, right, bottom);
            }

            return ret;
        }


        /// <summary>
        /// used to adjust existing point in the datagrid including "H"
        /// </summary>
        /// <param name="pointno"></param>
        /// <param name="lat"></param>
        /// <param name="lng"></param>
        /// <param name="alt"></param>
        public void CallMeDrag(string pointno, double lat, double lng, int alt)
        {
            if (pointno == "")
            {
                return;
            }

            // dragging a WP
            if (pointno == CustomData.WP.WPCommands.HomeCommand)
            {
                // auto update home alt
                var home = CustomData.WP.WPGlobalData.instance.GetHomePosition();
                if (home != null)
                {
                    home.Lat = lat;
                    home.Lng = lng;
                }
                else
                {
                    home = new VPS.CustomData.WP.VPSPosition(lat, lng);
                    home.Alt = 0;
                    home.Command = CustomData.WP.WPCommands.HomeCommand;
                    home.AltMode = CustomData.EnumCollect.AltFrame.Terrain;
                }

                CustomData.WP.WPGlobalData.instance.SetHomePosition(home);
                return;
            }

            if (pointno == "Tracker Home")
            {
                MainV2.comPort.MAV.cs.TrackerLocation = new PointLatLngAlt(lat, lng, alt, "Tracker Home");
                return;
            }

            try
            {
                SetWPPoint(int.Parse(pointno),lat, lng, alt);
            }
            catch
            {
                return;
            }
        }

        public T DeepClone<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();

                formatter.Serialize(ms, obj);

                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }

        /// <summary>
        /// from http://stackoverflow.com/questions/1119451/how-to-tell-if-a-line-intersects-a-polygon-in-c
        /// </summary>
        /// <param name="start1"></param>
        /// <param name="end1"></param>
        /// <param name="start2"></param>
        /// <param name="end2"></param>
        /// <returns></returns>
        public PointLatLng FindLineIntersection(PointLatLng start1, PointLatLng end1, PointLatLng start2,
            PointLatLng end2)
        {
            double denom = ((end1.Lng - start1.Lng) * (end2.Lat - start2.Lat)) -
                           ((end1.Lat - start1.Lat) * (end2.Lng - start2.Lng));
            //  AB & CD are parallel         
            if (denom == 0)
                return PointLatLng.Empty;
            double numer = ((start1.Lat - start2.Lat) * (end2.Lng - start2.Lng)) -
                           ((start1.Lng - start2.Lng) * (end2.Lat - start2.Lat));
            double r = numer / denom;
            double numer2 = ((start1.Lat - start2.Lat) * (end1.Lng - start1.Lng)) -
                            ((start1.Lng - start2.Lng) * (end1.Lat - start1.Lat));
            double s = numer2 / denom;
            if ((r < 0 || r > 1) || (s < 0 || s > 1))
                return PointLatLng.Empty;
            // Find intersection point      
            PointLatLng result = new PointLatLng();
            result.Lng = start1.Lng + (r * (end1.Lng - start1.Lng));
            result.Lat = start1.Lat + (r * (end1.Lat - start1.Lat));
            return result;
        }

        public void GeoFencedownloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addPolygonMode = false;
            int count = 1;

            if ((MainV2.comPort.MAV.cs.capabilities & (uint)MAVLink.MAV_PROTOCOL_CAPABILITY.MISSION_FENCE) > 0)
            {
                if (!MainV2.comPort.BaseStream.IsOpen)
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show(Strings.PleaseConnect);
                    return;
                }
                try
                {
                    mav_mission.download(MainV2.comPort, MainV2.comPort.MAV.sysid, MainV2.comPort.MAV.compid, MAVLink.MAV_MISSION_TYPE.FENCE).AwaitSync();
                }
                catch
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("获取栅栏点失败", Strings.ERROR);
                }
                return;
            }

            if (MainV2.comPort.MAV.param["FENCE_ACTION"] == null || MainV2.comPort.MAV.param["FENCE_TOTAL"] == null)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Not Supported");
                return;
            }

            if (int.Parse(MainV2.comPort.MAV.param["FENCE_TOTAL"].ToString()) <= 1)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Fence points - Nothing to download");
                return;
            }

            geofenceoverlay.Polygons.Clear();
            geofenceoverlay.Markers.Clear();
            geofencepolygon.Points.Clear();

            for (int a = 0; a < count; a++)
            {
                try
                {
                    var plla = MainV2.comPort.getFencePoint(a).AwaitSync();
                    count = plla.total;
                    geofencepolygon.Points.Add(new PointLatLng(plla.plla.Lat, plla.plla.Lng));
                }
                catch
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("获取栅栏点失败", Strings.ERROR);
                    return;
                }
            }

            // do return location
            geofenceoverlay.Markers.Add(
                new GMarkerGoogle(new PointLatLng(geofencepolygon.Points[0].Lat, geofencepolygon.Points[0].Lng),
                    GMarkerGoogleType.red)
                {
                    ToolTipMode = MarkerTooltipMode.OnMouseOver,
                    ToolTipText = "GeoFence Return"
                });
            geofencepolygon.Points.RemoveAt(0);

            // add now - so local points are calced
            geofenceoverlay.Polygons.Add(geofencepolygon);

            MainMap.UpdatePolygonLocalPosition(geofencepolygon);
            MainMap.UpdateMarkerLocalPosition(geofenceoverlay.Markers[0]);

            MainMap.Invalidate();
        }

        public void getRallyPointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((MainV2.comPort.MAV.cs.capabilities & (uint)MAVLink.MAV_PROTOCOL_CAPABILITY.MISSION_RALLY) >= 0)
            {
                if (!MainV2.comPort.BaseStream.IsOpen)
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show(Strings.PleaseConnect);
                    return;
                }
                mav_mission.download(MainV2.comPort, MainV2.comPort.MAV.sysid, MainV2.comPort.MAV.compid, MAVLink.MAV_MISSION_TYPE.RALLY).AwaitSync();
                return;
            }

            if (MainV2.comPort.MAV.param["RALLY_TOTAL"] == null)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Not Supported");
                return;
            }

            if (int.Parse(MainV2.comPort.MAV.param["RALLY_TOTAL"].ToString()) < 1)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Rally points - Nothing to download");
                return;
            }

            rallypointoverlay.Markers.Clear();

            int count = int.Parse(MainV2.comPort.MAV.param["RALLY_TOTAL"].ToString());

            for (int a = 0; a < (count); a++)
            {
                try
                {
                    var plla = MainV2.comPort.getRallyPoint(a).AwaitSync();
                    count = plla.total;
                    rallypointoverlay.Markers.Add(new GMapMarkerRallyPt(new PointLatLng(plla.plla.Lat, plla.plla.Lng))
                    {
                        Alt = (int)plla.plla.Alt,
                        ToolTipMode = MarkerTooltipMode.OnMouseOver,
                        ToolTipText = "Rally Point" + "\nAlt: " + (plla.plla.Alt * CurrentState.multiplieralt)
                    });
                }
                catch
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("获取集结点失败", Strings.ERROR);
                    return;
                }
            }

            MainMap.UpdateMarkerLocalPosition(rallypointoverlay.Markers[0]);

            MainMap.Invalidate();
        }


        private void Addpolygonmarkergrid(string tag, double lng, double lat, int alt)
        {
            try
            {
                PointLatLng point = new PointLatLng(lat, lng);
                GMapMarkerPolygon m = new GMapMarkerPolygon(point, tag);
                //m.ToolTipMode = MarkerTooltipMode.Never;
                
                if (polyMarkersGroup.Contains(System.Convert.ToInt32(tag)))
                {
                    m.selected = true;
                }

                //MissionPlanner.GMapMarkerRectWPRad mBorders = new MissionPlanner.GMapMarkerRectWPRad(point, (int)float.Parse(TXT_WPRad.Text), MainMap);
                GMapMarkerRect mBorders = new GMapMarkerRect(point);
                {
                    mBorders.InnerMarker = m;
                }

                drawnpolygonsoverlay.Markers.Add(m);
                drawnpolygonsoverlay.Markers.Add(mBorders);
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        public void updateDisplayView()
        {
            //rallyPointsToolStripMenuItem.Visible = MainV2.DisplayConfiguration.displayRallyPointsMenu;
            //geoFenceToolStripMenuItem.Visible = MainV2.DisplayConfiguration.displayGeoFenceMenu;
            //createSplineCircleToolStripMenuItem.Visible = MainV2.DisplayConfiguration.displaySplineCircleAutoWp;
            //textToolStripMenuItem.Visible = MainV2.DisplayConfiguration.displayTextAutoWp;
            //createCircleSurveyToolStripMenuItem.Visible = MainV2.DisplayConfiguration.displayCircleSurveyAutoWp;
            //pOIToolStripMenuItem.Visible = MainV2.DisplayConfiguration.displayPoiMenu;
            //trackerHomeToolStripMenuItem.Visible = MainV2.DisplayConfiguration.displayTrackerHomeMenu;

            //hide dynamically generated toolstrip items in the auto WP dropdown (these do not have name objects populated)
            foreach (ToolStripItem item in planningWPToolStripMenuItem.DropDownItems)
            {
                if (item.Name.Equals(""))
                {
                    item.Visible = MainV2.DisplayConfiguration.displayPluginAutoWp;
                }
            }
        }

        public void updateHome()
        {
            EnterQuickADD();
            updateHomeText();
            LeaveQuickADD();
        }


        public class midline
        {
            public PointLatLngAlt now { get; set; }
            public PointLatLngAlt next { get; set; }
        }



        internal IList<Locationwp> GetFlightPlanLocations()
        {
            return GetCommandList(CustomData.WP.WPGlobalData.instance.GetWPList()).AsReadOnly();
        }


        private void addpolygonmarker(string tag, double lng, double lat, int alt, Color? color, GMapOverlay overlay)
        {
            try
            {
                PointLatLng point = new PointLatLng(lat, lng);
                GMarkerGoogle m = new GMarkerGoogle(point, GMarkerGoogleType.green);
                m.ToolTipMode = MarkerTooltipMode.Always;
                m.ToolTipText = tag;
                m.Tag = tag;

                GMapMarkerRect mBorders = new GMapMarkerRect(point);
                {
                    mBorders.InnerMarker = m;
                    try
                    {
                        mBorders.wprad =
                            (int)(Settings.Instance.GetFloat("TXT_WPRad") / CurrentState.multiplieralt);
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                    }
                    if (color.HasValue)
                    {
                        mBorders.Color = color.Value;
                    }
                }

                overlay.Markers.Add(m);
                overlay.Markers.Add(mBorders);
            }
            catch (Exception)
            {
            }
        }

        private void addpolygonmarkergrid(string tag, double lng, double lat, int alt)
        {
            try
            {
                PointLatLng point = new PointLatLng(lat, lng);
                GMarkerGoogle m = new GMarkerGoogle(point, GMarkerGoogleType.red);
                m.ToolTipMode = MarkerTooltipMode.Never;
                m.ToolTipText = "grid" + tag;
                m.Tag = "grid" + tag;

                //MissionPlanner.GMapMarkerRectWPRad mBorders = new MissionPlanner.GMapMarkerRectWPRad(point, (int)float.Parse(TXT_WPRad.Text), MainMap);
                GMapMarkerRect mBorders = new GMapMarkerRect(point);
                {
                    mBorders.InnerMarker = m;
                }

                drawnpolygonsoverlay.Markers.Add(m);
                drawnpolygonsoverlay.Markers.Add(mBorders);
            }
            catch (Exception ex)
            {
                log.Info(ex.ToString());
            }
        }

        public void areaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double aream2 = Math.Abs((double)calcpolygonarea(drawnpolygon.Points));

            double areaa = aream2 * 0.000247105;

            double areaha = aream2 * 1e-4;

            double areasqf = aream2 * 10.7639;

            DevComponents.DotNetBar.MessageBoxEx.Show(
                "Area: " + aream2.ToString("0") + " m2\n\t" + areaa.ToString("0.00") + " Acre\n\t" +
                areaha.ToString("0.00") + " Hectare\n\t" + areasqf.ToString("0") + " sqf", "Area");
        }



        private double calcpolygonarea(List<PointLatLng> polygon)
        {
            // should be a closed polygon
            // coords are in lat long
            // need utm to calc area

            if (polygon.Count == 0)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("请划定区域!");
                return 0;
            }

            // close the polygon
            if (polygon[0] != polygon[polygon.Count - 1])
                polygon.Add(polygon[0]); // make a full loop

            CoordinateTransformationFactory ctfac = new CoordinateTransformationFactory();

            IGeographicCoordinateSystem wgs84 = GeographicCoordinateSystem.WGS84;

            int utmzone = (int)((polygon[0].Lng - -186.0) / 6.0);

            IProjectedCoordinateSystem utm = ProjectedCoordinateSystem.WGS84_UTM(utmzone,
                polygon[0].Lat < 0 ? false : true);

            ICoordinateTransformation trans = ctfac.CreateFromCoordinateSystems(wgs84, utm);

            double prod1 = 0;
            double prod2 = 0;

            for (int a = 0; a < (polygon.Count - 1); a++)
            {
                double[] pll1 = { polygon[a].Lng, polygon[a].Lat };
                double[] pll2 = { polygon[a + 1].Lng, polygon[a + 1].Lat };

                double[] p1 = trans.MathTransform.Transform(pll1);
                double[] p2 = trans.MathTransform.Transform(pll2);

                prod1 += p1[0] * p2[1];
                prod2 += p1[1] * p2[0];
            }

            double answer = (prod1 - prod2) / 2;

            if (polygon[0] == polygon[polygon.Count - 1])
                polygon.RemoveAt(polygon.Count - 1); // unmake a full loop

            return answer;
        }

        public void Chk_grid_CheckedChanged(object sender, EventArgs e)
        {
            grid = chk_grid.Checked;
        }

        private void comboBoxMapType_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                // check if we are setting the initial state
                if (MainMap.MapProvider != GMapProviders.EmptyProvider && (GMapProvider)comboBoxMapType.SelectedItem == MapboxUser.Instance)
                {
                    var url = Settings.Instance["MapBoxURL", ""];
                    InputBox.Show("Enter MapBox Share URL", "Enter MapBox Share URL", ref url);
                    var match = Regex.Matches(url, @"\/styles\/[^\/]+\/([^\/]+)\/([^\/\.]+).*access_token=([^#&=]+)");
                    if (match != null)
                    {
                        MapboxUser.Instance.UserName = match[0].Groups[1].Value;
                        MapboxUser.Instance.StyleId = match[0].Groups[2].Value;
                        MapboxUser.Instance.MapKey = match[0].Groups[3].Value;
                        Settings.Instance["MapBoxURL"] = url;
                    }
                    else
                    {
                        DevComponents.DotNetBar.MessageBoxEx.Show(Strings.InvalidField, Strings.ERROR);
                        return;
                    }
                }

                MainMap.MapProvider = (GMapProvider)comboBoxMapType.SelectedItem;
                Settings.Instance["MapType"] = comboBoxMapType.Text;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                DevComponents.DotNetBar.MessageBoxEx.Show("Map change failed. try zooming out first.");
            }
        }

        /// <summary>
        /// Saves this forms config to MAIN, where it is written in a global config
        /// </summary>
        /// <param name="write">true/false</param>
        private void config(bool write)
        {
            if (write)
            {
                Settings.Instance["FP_WPRad"] = wpRad.ToString();

                Settings.Instance["FP_LoiterRad"] = loiterRad.ToString();

                Settings.Instance["FP_DefaultAlt"] = defaultAlt.ToString();

                Settings.Instance["FP_AltMode"] = altFrame.ToString();

                Settings.Instance["FP_AltWarn"] = warnAlt.ToString();

                Settings.Instance["FP_CoordSystem"] = coordSystem.ToString();
            }
            else
            {
                foreach (string key in Settings.Instance.Keys)
                {
                    switch (key)
                    {
                        case "FP_WPRad":
                            {
                                if (int.TryParse(Settings.Instance[key], out int rad))
                                    SetWPRadHandle(rad);
                            }
                            break;
                        case "FP_LoiterRad":
                            {
                                if (int.TryParse(Settings.Instance[key], out int rad))
                                    SetLoiterRadHandle(rad);
                            }
                            break;
                        case "FP_DefaultAlt":
                            {
                                if (int.TryParse(Settings.Instance[key], out int alt))
                                    SetDefaultAltHandle(alt);
                            }
                            break;
                        case "FP_AltWarn":
                            {
                                if (int.TryParse(Settings.Instance[key], out int alt))
                                    SetWarnAltHandle(alt);
                            }
                            break;
                        case "FP_AltMode":
                            SetAltFrameHandle("" + Settings.Instance[key]);
                            break;
                        case "FP_CoordSystem":
                            SetCoordSystemHandle("" + Settings.Instance[key]);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public void ContextMeasure_Click(object sender, EventArgs e)
        {
            if (startmeasure.IsEmpty)
            {
                startmeasure = MouseDownStart;
                polygonsoverlay.Markers.Add(new GMarkerGoogle(MouseDownStart, GMarkerGoogleType.red));
                MainMap.Invalidate();
                DevComponents.DotNetBar.MessageBoxEx.Show("Measure Dist",
                    "You can now pan/zoom around.\nClick this option again to get the distance.");
            }
            else
            {
                List<PointLatLng> polygonPoints = new List<PointLatLng>
                {
                    startmeasure,
                    MouseDownStart
                };

                GMapPolygon line = new GMapPolygon(polygonPoints, "measure dist");
                line.Stroke.Color = Color.Green;

                polygonsoverlay.Polygons.Add(line);

                polygonsoverlay.Markers.Add(new GMarkerGoogle(MouseDownStart, GMarkerGoogleType.red));
                MainMap.Invalidate();
                DevComponents.DotNetBar.MessageBoxEx.Show("Distance: " +
                                      FormatDistance(MainMap.MapProvider.Projection.GetDistance(startmeasure, MouseDownStart), true) +
                                      " AZ: " +
                                      (MainMap.MapProvider.Projection.GetBearing(startmeasure, MouseDownStart)
                                          .ToString("0")));
                polygonsoverlay.Polygons.Remove(line);
                polygonsoverlay.Markers.Clear();
                startmeasure = new PointLatLng();
            }
        }

        public void ContextMenuStripMain_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            //if (e.CloseReason.ToString() == "AppClicked" || e.CloseReason.ToString() == "AppFocusChange")
            IsMouseClickOffMenu = true;
        }

        public void ContextMenuStripMain_Opening(object sender, CancelEventArgs e)
        {
            if (CurentRectMarker == null && CurrentRallyPt == null && wpMarkersGroup.Count == 0 && polyMarkersGroup.Count == 0)
            {
                deleteMarkerToolStripMenuItem.Enabled = false;
            }
            else
            {
                deleteMarkerToolStripMenuItem.Enabled = true;
            }

            //if (MainV2.comPort != null && MainV2.comPort.MAV != null)
            //{
            //    if ((MainV2.comPort.MAV.cs.capabilities & (int)MAVLink.MAV_PROTOCOL_CAPABILITY.MISSION_FENCE) > 0)
            //    {
            //        geoFenceToolStripMenuItem.Visible = false;
            //        rallyPointsToolStripMenuItem.Visible = false;
            //    }
            //    else
            //    {
            //        geoFenceToolStripMenuItem.Visible = true;
            //        rallyPointsToolStripMenuItem.Visible = true;
            //    }
            //}

            IsMouseClickOffMenu = true; // Just incase
        }

        public void ContextMenuStripPoly_Opening(object sender, CancelEventArgs e)
        {
            // update the displayed items
            //if ((MAVLink.MAV_MISSION_TYPE)cmb_missiontype.SelectedValue == MAVLink.MAV_MISSION_TYPE.RALLY)
            //{
            //    fenceInclusionToolStripMenuItem.Visible = false;
            //    fenceExclusionToolStripMenuItem.Visible = false;
            //}
            //else if ((MAVLink.MAV_MISSION_TYPE)cmb_missiontype.SelectedValue == MAVLink.MAV_MISSION_TYPE.FENCE)
            //{
            //    fenceInclusionToolStripMenuItem.Visible = true;
            //    fenceExclusionToolStripMenuItem.Visible = true;
            //}
            //else
            //{
            //    fenceInclusionToolStripMenuItem.Visible = false;
            //    fenceExclusionToolStripMenuItem.Visible = false;
            //}
            IsMouseClickOffMenu = false; // Just incase
        }

        public void ContextMenuStripPoly_Close(object sender, ToolStripDropDownClosedEventArgs e)
        {
            //if (e.CloseReason.ToString() == "AppClicked" || e.CloseReason.ToString() == "AppFocusChange")
            //    isMouseClickOffMenu = true;
        }

        private void ConvertUTMCoords(GMapRoute route, int zone = -9999)
        {
            for (int i = 0; i < route.Points.Count; i++)
            {
                var pnt = route.Points[i];
                // load input
                utmpos pos = new utmpos(pnt.Lng, pnt.Lat, zone);
                // convert to geo
                var llh = pos.ToLLA();
                // save it back
                route.Points[i] = llh;
                //route.Points[i].Lng = llh.Lng;
            }
        }

        private void Dxf_newLine(dxf sender, netDxf.Entities.Line line)
        {
            var route = new GMapRoute(line.Handle);
            route.Points.Add(new PointLatLng(line.StartPoint.Y, line.StartPoint.X));
            route.Points.Add(new PointLatLng(line.EndPoint.Y, line.EndPoint.X));

            route.Stroke = new Pen(Color.FromArgb(line.Color.R, line.Color.G, line.Color.B));

            if (sender.Tag != null)
                ConvertUTMCoords(route, int.Parse(sender.Tag.ToString()));

            kmlpolygonsoverlay.Routes.Add(route);
        }

        private void Dxf_newLwPolyline(dxf sender, netDxf.Entities.LwPolyline pline)
        {
            var route = new GMapRoute(pline.Handle);
            foreach (var item in pline.Vertexes)
            {
                route.Points.Add(new PointLatLng(item.Position.Y, item.Position.X));
            }

            route.Stroke = new Pen(Color.FromArgb(pline.Color.R, pline.Color.G, pline.Color.B));

            if (sender.Tag != null)
                ConvertUTMCoords(route, int.Parse(sender.Tag.ToString()));

            kmlpolygonsoverlay.Routes.Add(route);
        }

        private void Dxf_newMLine(dxf sender, netDxf.Entities.MLine pline)
        {
            var route = new GMapRoute(pline.Handle);
            foreach (var item in pline.Vertexes)
            {
                route.Points.Add(new PointLatLng(item.Location.Y, item.Location.X));
            }

            route.Stroke = new Pen(Color.FromArgb(pline.Color.R, pline.Color.G, pline.Color.B));

            if (sender.Tag != null)
                ConvertUTMCoords(route, int.Parse(sender.Tag.ToString()));

            kmlpolygonsoverlay.Routes.Add(route);
        }

        private void Dxf_newPolyLine(dxf sender, netDxf.Entities.Polyline pline)
        {
            var route = new GMapRoute(pline.Handle);
            foreach (var item in pline.Vertexes)
            {
                route.Points.Add(new PointLatLng(item.Position.Y, item.Position.X));
            }

            route.Stroke = new Pen(Color.FromArgb(pline.Color.R, pline.Color.G, pline.Color.B));

            if (sender.Tag != null)
                ConvertUTMCoords(route, int.Parse(sender.Tag.ToString()));

            kmlpolygonsoverlay.Routes.Add(route);
        }


        private void FetchPath()
        {
            PointLatLngAlt lastpnt = null;

            string maxzoomstring = "20";
            if (InputBox.Show("max zoom", "Enter the max zoom to prefetch to.", ref maxzoomstring) != DialogResult.OK)
                return;

            int maxzoom = 20;
            if (!int.TryParse(maxzoomstring, out maxzoom))
            {
                DevComponents.DotNetBar.MessageBoxEx.Show(Strings.InvalidNumberEntered, Strings.ERROR);
                return;
            }

            fetchpathrip = true;

            maxzoom = Math.Min(maxzoom, MainMap.MaxZoom);

            // zoom
            for (int i = 1; i <= maxzoom; i++)
            {
                // exit if reqested
                if (!fetchpathrip)
                    break;

                lastpnt = null;
                // location
                foreach (var pnt in pointlist)
                {
                    if (pnt == null)
                        continue;

                    // exit if reqested
                    if (!fetchpathrip)
                        break;

                    // setup initial enviroment
                    if (lastpnt == null)
                    {
                        lastpnt = pnt;
                        continue;
                    }

                    RectLatLng area = new RectLatLng();
                    double top = Math.Max(lastpnt.Lat, pnt.Lat);
                    double left = Math.Min(lastpnt.Lng, pnt.Lng);
                    double bottom = Math.Min(lastpnt.Lat, pnt.Lat);
                    double right = Math.Max(lastpnt.Lng, pnt.Lng);

                    area.LocationTopLeft = new PointLatLng(top, left);
                    area.HeightLat = top - bottom;
                    area.WidthLng = right - left;

                    TilePrefetcher obj = new TilePrefetcher();
                    ThemeManager.ApplyThemeTo(obj);
                    obj.KeyDown += obj_KeyDown;
                    obj.ShowCompleteMessage = false;
                    obj.Start(area, i, MainMap.MapProvider, 0, 0);

                    if (obj.UserAborted)
                    {
                        fetchpathrip = false;
                        break;
                    }

                    lastpnt = pnt;
                }
            }
        }


        public void FlightPlanner_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
        }

        public void FlightPlanner_Load(object sender, EventArgs e)
        {
            EnterQuickADD();

            Visible = false;

            config(false);

            LeaveQuickADD();

            POI.POIModified += POI_POIModified;

            if (Settings.Instance["WMSserver"] != null)
            {
                WMSProvider.CustomWMSURL = Settings.Instance["WMSserver"];
                WMSProvider.szWmsLayer = Settings.Instance["WMSLayer"];
            }

            trackBar1.Value = (int)MainMap.Zoom;

            updateCMDParams();

            panelMap.Visible = false;

            // mono
            panelMap.Dock = DockStyle.None;
            panelMap.Dock = DockStyle.Fill;
            panelMap_Resize(null, null);

            //set home
            try
            {
                VPS.CustomData.WP.VPSPosition home = CustomData.WP.WPGlobalData.instance.GetHomePosition();
                if (home != null)
                {
                    MainMap.Position = new PointLatLng(home.Lat, home.Lng);
                    //MainMap.Zoom = 16;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

            panelMap.Refresh();

            panelMap.Visible = true;

            writeKML();

            // switch the action and wp table

            Visible = true;

            timer1.Start();
        }

        /// <summary>
        /// Format distance according to prefer distance unit
        /// </summary>
        /// <param name="distInKM">distance in kilometers</param>
        /// <param name="toMeterOrFeet">convert distance to meter or feet if true, covert to km or miles if false</param>
        /// <returns>formatted distance with unit</returns>
        private string FormatDistance(double distInKM, bool toMeterOrFeet)
        {
            string sunits = Settings.Instance["distunits"];
            distances units = distances.Meters;

            if (sunits != null)
                try
                {
                    units = (distances)Enum.Parse(typeof(distances), sunits);
                }
                catch (Exception)
                {
                }

            switch (units)
            {
                case distances.Feet:
                    return toMeterOrFeet
                        ? string.Format((distInKM * 3280.8399).ToString("0.00 ft"))
                        : string.Format((distInKM * 0.621371).ToString("0.0000 miles"));
                case distances.Meters:
                default:
                    return toMeterOrFeet
                        ? string.Format((distInKM * 1000).ToString("0.00 m"))
                        : string.Format(distInKM.ToString("0.0000 km"));
            }
        }



        /// <summary>
        /// Get the Google earth ALT for a given coord
        /// </summary>
        /// <param name="lat"></param>
        /// <param name="lng"></param>
        /// <returns>Altitude</returns>
        private double getGEAlt(double lat, double lng)
        {
            double alt = 0;
            //http://maps.google.com/maps/api/elevation/xml

            try
            {
                using (
                    XmlTextReader xmlreader =
                        new XmlTextReader("http://maps.google.com/maps/api/elevation/xml?locations=" +
                                          lat.ToString(new CultureInfo("en-US")) + "," +
                                          lng.ToString(new CultureInfo("en-US")) + "&sensor=true"))
                {
                    while (xmlreader.Read())
                    {
                        xmlreader.MoveToElement();
                        switch (xmlreader.Name)
                        {
                            case "elevation":
                                alt = double.Parse(xmlreader.ReadString(), new CultureInfo("en-US"));
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

            return alt * CurrentState.multiplieralt;
        }

        private RectLatLng getPolyMinMax(GMapPolygon poly)
        {
            if (poly.Points.Count == 0)
                return new RectLatLng();

            double minx, miny, maxx, maxy;

            minx = maxx = poly.Points[0].Lng;
            miny = maxy = poly.Points[0].Lat;

            foreach (PointLatLng pnt in poly.Points)
            {
                //Console.WriteLine(pnt.ToString());
                minx = Math.Min(minx, pnt.Lng);
                maxx = Math.Max(maxx, pnt.Lng);

                miny = Math.Min(miny, pnt.Lat);
                maxy = Math.Max(maxy, pnt.Lat);
            }

            return new RectLatLng(maxy, minx, Math.Abs(maxx - minx), Math.Abs(miny - maxy));
        }

        //private void getWPs(IProgressReporterDialogue sender)
        //{
        //    var type = (MAVLink.MAV_MISSION_TYPE)Invoke((Func<MAVLink.MAV_MISSION_TYPE>)delegate
        //    {
        //        return (MAVLink.MAV_MISSION_TYPE)cmb_missiontype.SelectedValue;
        //    });

        //    List<Locationwp> cmds = Task.Run(async () => await mav_mission.download(MainV2.comPort, MainV2.comPort.MAV.sysid,
        //        MainV2.comPort.MAV.compid,
        //        type,
        //        (percent, status) =>
        //        {
        //            if (sender.doWorkArgs.CancelRequested)
        //            {
        //                sender.doWorkArgs.CancelAcknowledged = true;
        //                sender.doWorkArgs.ErrorMessage = "User Canceled";
        //                throw new Exception("User Canceled");
        //            }

        //            sender.UpdateProgressAndStatus(percent, status);
        //        }).ConfigureAwait(false)).Result;

        //    WPtoScreen(cmds);
        //}




        private void TiffOverlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainV2.instance.LoadTiffLayer();
        }


        private void TiffManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainV2.instance.ManagerTiffLayer();
        }

        public void kMLOverlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fd = new OpenFileDialog())
            {
                fd.Filter = "All Supported|*.kml;*.kmz;*.dxf;*.gpkg|Google Earth KML|*.kml;*.kmz|AutoCad DXF|*.dxf|GeoPackage|*.gpkg";
                DialogResult result = fd.ShowDialog();
                string file = fd.FileName;
                if (file != "")
                {
                    kmlpolygonsoverlay.Polygons.Clear();
                    kmlpolygonsoverlay.Routes.Clear();

                    if (file.ToLower().EndsWith("gpkg"))
                    {
                        using (var ogr = OGR.Open(file))
                        {
                            ogr.NewPoint += pnt =>
                            {
                                var mark = new GMarkerGoogle(new PointLatLngAlt(pnt), GMarkerGoogleType.brown_small);
                                kmlpolygonsoverlay.Markers.Add(mark);
                            };
                            ogr.NewLineString += ls =>
                            {
                                var route =
                                    new GMapRoute(ls.Select(a => new PointLatLngAlt(a.y, a.x, a.z).Point()), "")
                                    {
                                        IsHitTestVisible = false,
                                        Stroke = new Pen(Color.Red)
                                    };
                                kmlpolygonsoverlay.Routes.Add(route);
                            };
                            ogr.NewPolygon += ls =>
                            {
                                var polygon =
                                    new GMapPolygon(ls.Select(a => new PointLatLngAlt(a.y, a.x, a.z).Point()).ToList(), "")
                                    {
                                        Fill = Brushes.Transparent,
                                        IsHitTestVisible = false,
                                        Stroke = new Pen(Color.Red)
                                    };
                                kmlpolygonsoverlay.Polygons.Add(polygon);
                            };

                            ogr.Process();
                        }
                    }
                    else if (file.ToLower().EndsWith("dxf"))
                    {
                        string zone = "-99";
                        InputBox.Show("Zone", "请输入 UTM zone，或放弃更改", ref zone);

                        dxf dxf = new dxf();
                        if (zone != "-99")
                            dxf.Tag = zone;

                        dxf.newLine += Dxf_newLine;
                        dxf.newPolyLine += Dxf_newPolyLine;
                        dxf.newLwPolyline += Dxf_newLwPolyline;
                        dxf.newMLine += Dxf_newMLine;
                        dxf.Read(file);
                    }
                    else
                    {
                        try
                        {
                            string kml = "";
                            string tempdir = "";
                            if (file.ToLower().EndsWith("kmz"))
                            {
                                ZipFile input = new ZipFile(file);

                                tempdir = Path.GetTempPath() + Path.DirectorySeparatorChar + Path.GetRandomFileName();
                                input.ExtractAll(tempdir, ExtractExistingFileAction.OverwriteSilently);

                                string[] kmls = Directory.GetFiles(tempdir, "*.kml");

                                if (kmls.Length > 0)
                                {
                                    file = kmls[0];

                                    input.Dispose();
                                }
                                else
                                {
                                    input.Dispose();
                                    return;
                                }
                            }

                            var sr = new StreamReader(File.OpenRead(file));
                            kml = sr.ReadToEnd();
                            sr.Close();

                            // cleanup after out
                            if (tempdir != "")
                                Directory.Delete(tempdir, true);

                            kml = kml.Replace("<Snippet/>", "");

                            var parser = new Parser();

                            parser.ElementAdded += parser_ElementAdded;
                            parser.ParseString(kml, false);


                            if (
                                DevComponents.DotNetBar.MessageBoxEx.Show(Strings.Zoom_To, Strings.Zoom_to_the_center_or_the_loaded_file, MessageBoxButtons.YesNo) ==
                                DialogResult.Yes)
                            {
                                MainMap.SetZoomToFitRect(GetBoundingLayer(kmlpolygonsoverlay));
                            }
                        }
                        catch (Exception ex)
                        {
                            DevComponents.DotNetBar.MessageBoxEx.Show(Strings.Bad_KML_File + ex);
                        }
                    }
                }
            }
        }

        public void lnk_kml_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start("http://127.0.0.1:56781/network.kml");
            }
            catch
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("打开 url http://127.0.0.1:56781/network.kml 失败");
            }
        }

        public void MainMap_Paint(object sender, PaintEventArgs e)
        {
            // draw utm grid
            if (grid)
            {
                if (MainMap.Zoom < 10)
                    return;

                var rect = MainMap.ViewArea;

                var plla1 = new PointLatLngAlt(rect.LocationTopLeft);
                var plla2 = new PointLatLngAlt(rect.LocationRightBottom);

                var center = new PointLatLngAlt(rect.LocationMiddle);

                var zone = center.GetUTMZone();

                var utm1 = plla1.ToUTM(zone);
                var utm2 = plla2.ToUTM(zone);

                var deltax = utm1[0] - utm2[0];
                var deltay = utm1[1] - utm2[1];

                //if (deltax)

                var gridsize = 1000.0;


                if (Math.Abs(deltax) / 100000 < 40)
                    gridsize = 100000;

                if (Math.Abs(deltax) / 10000 < 40)
                    gridsize = 10000;

                if (Math.Abs(deltax) / 1000 < 40)
                    gridsize = 1000;

                if (Math.Abs(deltax) / 100 < 40)
                    gridsize = 100;

                if (Math.Abs(deltax) / 10 < 40)
                    gridsize = 10;

                if (Math.Abs(deltax) / 1 < 40)
                    gridsize = 1;

                // round it - x
                utm1[0] = utm1[0] - (utm1[0] % gridsize);
                // y
                utm2[1] = utm2[1] - (utm2[1] % gridsize);

                // x's
                for (double x = utm1[0]; x < utm2[0]; x += gridsize)
                {
                    var p1 = MainMap.FromLatLngToLocal(PointLatLngAlt.FromUTM(zone, x, utm1[1]));
                    var p2 = MainMap.FromLatLngToLocal(PointLatLngAlt.FromUTM(zone, x, utm2[1]));

                    int x1 = (int)p1.X;
                    int y1 = (int)p1.Y;
                    int x2 = (int)p2.X;
                    int y2 = (int)p2.Y;

                    e.Graphics.DrawLine(new Pen(MainMap.SelectionPen.Color, 1), x1, y1, x2, y2);
                }

                // y's
                for (double y = utm2[1]; y < utm1[1]; y += gridsize)
                {
                    var p1 = MainMap.FromLatLngToLocal(PointLatLngAlt.FromUTM(zone, utm1[0], y));
                    var p2 = MainMap.FromLatLngToLocal(PointLatLngAlt.FromUTM(zone, utm2[0], y));

                    int x1 = (int)p1.X;
                    int y1 = (int)p1.Y;
                    int x2 = (int)p2.X;
                    int y2 = (int)p2.Y;

                    e.Graphics.DrawLine(new Pen(MainMap.SelectionPen.Color, 1), x1, y1, x2, y2);
                }
            }

            e.Graphics.ResetTransform();

            polyicon.Location = new Point(10, 100);
            polyicon.Paint(e.Graphics);

            e.Graphics.ResetTransform();

            WPicon.Location = new Point(10, polyicon.Location.Y + polyicon.Height + 5);
            WPicon.Paint(e.Graphics);

            e.Graphics.ResetTransform();
            zoomicon.Location = new Point(10, WPicon.Location.Y + WPicon.Height + 5);
            zoomicon.Paint(e.Graphics);

            e.Graphics.ResetTransform();
        }

        private void MainMap_Resize(object sender, EventArgs e)
        {
            MainMap.Zoom = MainMap.Zoom + 0.01;
        }


        private void obj_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                fetchpathrip = false;
            }
        }

        public void panelMap_Resize(object sender, EventArgs e)
        {
            // this is a mono fix for the zoom bar
            //Console.WriteLine("panelmap "+panelMap.Size.ToString());
            MainMap.Size = new Size(panelMap.Size.Width - 50, panelMap.Size.Height);
            trackBar1.Location = new Point(panelMap.Size.Width - 50, trackBar1.Location.Y);
            trackBar1.Size = new Size(trackBar1.Size.Width, panelMap.Size.Height - trackBar1.Location.Y);
            label11.Location = new Point(panelMap.Size.Width - 50, label11.Location.Y);
        }


        private void parser_ElementAdded(object sender, ElementEventArgs e)
        {
            processKML(e.Element);
        }

        public void Planner_Resize(object sender, EventArgs e)
        {
            MainMap.Zoom = trackBar1.Value;
        }

        /// <summary>
        /// from http://www.ecse.rpi.edu/Homepages/wrf/Research/Short_Notes/pnpoly.html
        /// </summary>
        /// <param name="array"> a closed polygon</param>
        /// <param name="testx"></param>
        /// <param name="testy"></param>
        /// <returns> true = outside</returns>
        private bool pnpoly(PointLatLng[] array, double testx, double testy)
        {
            int nvert = array.Length;
            int i, j = 0;
            bool c = false;
            for (i = 0, j = nvert - 1; i < nvert; j = i++)
            {
                if (((array[i].Lng > testy) != (array[j].Lng > testy)) &&
                    (testx <
                     (array[j].Lat - array[i].Lat) * (testy - array[i].Lng) / (array[j].Lng - array[i].Lng) + array[i].Lat))
                    c = !c;
            }
            return c;
        }

        private void POI_POIModified(object sender, EventArgs e)
        {
            POI.UpdateOverlay(poioverlay);
        }

        public void poiaddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            POI.POIAdd(MouseDownStart);
        }

        public void poideleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentPOIMarker == null)
                return;

            POI.POIDelete(CurrentPOIMarker);
        }

        public void poieditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentGMapMarker == null || !(CurrentGMapMarker is GMapMarkerPOI))
                return;

            POI.POIEdit(CurrentPOIMarker);
        }

        public void prefetchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RectLatLng area = MainMap.SelectedArea;
            if (area.IsEmpty)
            {
                var res = DevComponents.DotNetBar.MessageBoxEx.Show("No ripp area defined, ripp displayed on screen?", "Rip",
                    MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    area = MainMap.ViewArea;
                }
            }

            if (!area.IsEmpty)
            {
                string maxzoomstring = "20";
                if (InputBox.Show("max zoom", "输入 max zoom.", ref maxzoomstring) != DialogResult.OK)
                    return;

                int maxzoom = 20;
                if (!int.TryParse(maxzoomstring, out maxzoom))
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show(Strings.InvalidNumberEntered, Strings.ERROR);
                    return;
                }

                maxzoom = Math.Min(maxzoom, MainMap.MaxZoom);

                for (int i = 1; i <= maxzoom; i++)
                {
                    TilePrefetcher obj = new TilePrefetcher();
                    ThemeManager.ApplyThemeTo(obj);
                    obj.ShowCompleteMessage = false;
                    obj.Start(area, i, MainMap.MapProvider, 0, 0);

                    if (obj.UserAborted)
                    {
                        obj.Dispose();
                        break;
                    }

                    obj.Dispose();
                }
            }
            else
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("按住 ALT 选择区域", "GMap.NET", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        public void prefetchWPPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FetchPath();
        }

        private void processKML(Element Element)
        {
            Document doc = Element as Document;
            Placemark pm = Element as Placemark;
            Folder folder = Element as Folder;
            Polygon polygon = Element as Polygon;
            LineString ls = Element as LineString;
            MultipleGeometry geom = Element as MultipleGeometry;

            if (doc != null)
            {
                foreach (var feat in doc.Features)
                {
                    //Console.WriteLine("feat " + feat.GetType());
                    //processKML((Element)feat);
                }
            }
            else if (folder != null)
            {
                foreach (Feature feat in folder.Features)
                {
                    //Console.WriteLine("feat "+feat.GetType());
                    //processKML(feat);
                }
            }
            else if (pm != null)
            {
            }
            else if (polygon != null)
            {
                GMapPolygon kmlpolygon = new GMapPolygon(new List<PointLatLng>(), "kmlpolygon");

                kmlpolygon.Stroke.Color = Color.Purple;
                kmlpolygon.Fill = Brushes.Transparent;

                foreach (var loc in polygon.OuterBoundary.LinearRing.Coordinates)
                {
                    kmlpolygon.Points.Add(new PointLatLng(loc.Latitude, loc.Longitude));
                }

                kmlpolygonsoverlay.Polygons.Add(kmlpolygon);
            }
            else if (ls != null)
            {
                GMapRoute kmlroute = new GMapRoute(new List<PointLatLng>(), "kmlroute");

                kmlroute.Stroke.Color = Color.Purple;

                foreach (var loc in ls.Coordinates)
                {
                    kmlroute.Points.Add(new PointLatLng(loc.Latitude, loc.Longitude));
                }

                kmlpolygonsoverlay.Routes.Add(kmlroute);
            }
            else if (geom != null)
            {
                foreach (var geometry in geom.Geometry)
                {
                    processKML(geometry);
                }
            }
        }




        private Dictionary<string, string[]> readCMDXML()
        {
            Dictionary<string, string[]> cmd = new Dictionary<string, string[]>();

            // do lang stuff here

            string file = Settings.GetRunningDirectory() + "mavcmd.xml";

            if (!File.Exists(file))
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Missing mavcmd.xml file");
                return cmd;
            }

            log.Info("Reading MAV_CMD for " + MainV2.comPort.MAV.cs.firmware);

            using (XmlReader reader = XmlReader.Create(file))
            {
                reader.Read();
                reader.ReadStartElement("CMD");
                if (MainV2.comPort.MAV.cs.firmware == Firmwares.ArduPlane ||
                    MainV2.comPort.MAV.cs.firmware == Firmwares.Ateryx)
                {
                    reader.ReadToFollowing("APM");
                }
                else if (MainV2.comPort.MAV.cs.firmware == Firmwares.ArduRover)
                {
                    reader.ReadToFollowing("APRover");
                }
                else
                {
                    reader.ReadToFollowing("AC2");
                }

                XmlReader inner = reader.ReadSubtree();

                inner.Read();

                inner.MoveToElement();

                inner.Read();

                while (inner.Read())
                {
                    inner.MoveToElement();
                    if (inner.IsStartElement())
                    {
                        string cmdname = inner.Name;
                        string[] cmdarray = new string[7];
                        int b = 0;

                        XmlReader inner2 = inner.ReadSubtree();

                        inner2.Read();

                        while (inner2.Read())
                        {
                            inner2.MoveToElement();
                            if (inner2.IsStartElement())
                            {
                                cmdarray[b] = inner2.ReadString();
                                b++;
                            }
                        }

                        cmd[cmdname] = cmdarray;
                    }
                }
            }

            return cmd;
        }



        private void setWPParams()
        {
            try
            {
                log.Info("Loading wp params");

                Dictionary<string, double> param = new Dictionary<string, double>((Dictionary<string, double>)MainV2.comPort.MAV.param);

                if (param.ContainsKey("WP_RADIUS"))
                {
                    SetWPRadHandle((int)((double)param["WP_RADIUS"] * CurrentState.multiplierdist));
                }
                if (param.ContainsKey("WPNAV_RADIUS"))
                {
                    SetWPRadHandle((int)((double)param["WPNAV_RADIUS"] * CurrentState.multiplierdist / 100.0));
                }

                log.Info("param WP_RADIUS " + wpRad.ToString());

                try
                {
                    if (param.ContainsKey("LOITER_RADIUS"))
                    {
                        loiterRad = ((int)((double)param["LOITER_RADIUS"] * CurrentState.multiplierdist));
                    }
                    else if (param.ContainsKey("WP_LOITER_RAD"))
                    {
                        loiterRad = ((int)((double)param["WP_LOITER_RAD"] * CurrentState.multiplierdist));
                    }

                    log.Info("param LOITER_RADIUS " + loiterRad.ToString());
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        /// <summary>
        /// Draw an mav icon, and update tracker location icon and guided mode wp on FP screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (IsMouseDown || CurentRectMarker != null)
                    return;

                prop.alt = MainV2.comPort.MAV.cs.alt;
                prop.altasl = MainV2.comPort.MAV.cs.altasl;
                prop.center = MainMap.Position;
                prop.Update(MainV2.comPort.MAV.cs.PlannedHomeLocation, MainV2.comPort.MAV.cs.Location,
                    MainV2.comPort.MAV.cs.battery_kmleft);

                routesoverlay.Markers.Clear();

                if (MainV2.comPort.MAV.cs.TrackerLocation != MainV2.comPort.MAV.cs.PlannedHomeLocation &&
                    MainV2.comPort.MAV.cs.TrackerLocation.Lng != 0)
                {
                    addpolygonmarker("Tracker Home", MainV2.comPort.MAV.cs.TrackerLocation.Lng,
                        MainV2.comPort.MAV.cs.TrackerLocation.Lat, (int)MainV2.comPort.MAV.cs.TrackerLocation.Alt,
                        Color.Blue, routesoverlay);
                }

                if (MainV2.comPort.MAV.cs.lat == 0 || MainV2.comPort.MAV.cs.lng == 0)
                    return;

                var marker = Common.getMAVMarker(MainV2.comPort.MAV);

                routesoverlay.Markers.Add(marker);

                if (MainV2.comPort.MAV.cs.mode.ToLower() == "guided" && MainV2.comPort.MAV.GuidedMode.x != 0)
                {
                    addpolygonmarker("Guided Mode", MainV2.comPort.MAV.GuidedMode.y / 1e7, MainV2.comPort.MAV.GuidedMode.x / 1e7,
                        (int)MainV2.comPort.MAV.GuidedMode.z, Color.Blue, routesoverlay);
                }
            }
            catch (Exception ex)
            {
                log.Warn(ex);
            }
        }

        public void trackBar1_Scroll(object sender, EventArgs e)
        {
            try
            {
                lock (thisLock)
                {
                    MainMap.Zoom = trackBar1.Value;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                lock (thisLock)
                {
                    MainMap.Zoom = trackBar1.Value;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        private List<string> cmds = new List<string>();

        private void updateCMDParams()
        {
            cmdParamNames = readCMDXML();

            foreach (string item in cmdParamNames.Keys)
            {
                cmds.Add(item);
            }

            cmds.Add("UNKNOWN");
        }

        private void updateHomeText()
        {
            // set home location
            if (MainV2.comPort.MAV.cs.HomeLocation.Lat != 0 && MainV2.comPort.MAV.cs.HomeLocation.Lng != 0)
            {
                CustomData.WP.WPGlobalData.instance.SetHomePosition(new VPS.CustomData.WP.VPSPosition(
                                MainV2.comPort.MAV.cs.HomeLocation.Lat,
                                MainV2.comPort.MAV.cs.HomeLocation.Lng,
                                MainV2.comPort.MAV.cs.HomeLocation.Alt));
                writeKML();
            }
            else if (MainV2.comPort.MAV.cs.PlannedHomeLocation.Lat != 0 && MainV2.comPort.MAV.cs.PlannedHomeLocation.Lng != 0)
            {
                CustomData.WP.WPGlobalData.instance.SetHomePosition(new VPS.CustomData.WP.VPSPosition(
                                MainV2.comPort.MAV.cs.PlannedHomeLocation.Lat,
                                MainV2.comPort.MAV.cs.PlannedHomeLocation.Lng,
                                MainV2.comPort.MAV.cs.PlannedHomeLocation.Alt));
                writeKML();
            }
        }

        private void updateMapPosition(PointLatLng currentloc)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                try
                {
                    if (lastmapposchange.Second != DateTime.Now.Second)
                    {
                        MainMap.Position = currentloc;
                        lastmapposchange = DateTime.Now;
                    }
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                }
            });
        }

        private void updateMapType(object sender, System.Timers.ElapsedEventArgs e)
        {
            log.Info("updateMapType invoke req? " + comboBoxMapType.InvokeRequired);

            if (sender is System.Timers.Timer)
                ((System.Timers.Timer)sender).Stop();

            string mapType = Settings.Instance["MapType"];
            if (!string.IsNullOrEmpty(mapType))
            {
                try
                {
                    var index = GMapProviders.List.FindIndex(x => (x.Name == mapType));

                    if (index != -1) comboBoxMapType.SelectedIndex = index;
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                }
            }
            else
            {
                if (L10N.ConfigLang.IsChildOf(CultureInfo.GetCultureInfo("zh-Hans")))
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show(
                        "亲爱的中国用户，为保证地图使用正常，已为您将默认地图自动切换到具有中国特色的【谷歌中国卫星地图】！\r\n与默认【谷歌卫星地图】的区别：使用.cn服务器，加入火星坐标修正\r\n",
                        "默认地图已被切换");

                    mapType = "谷歌中国卫星地图";
                    try
                    {
                        var index = GMapProviders.List.FindIndex(x => (x.Name == mapType));

                        if (index != -1) comboBoxMapType.SelectedIndex = index;
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                    }
                }
                else
                {
                    mapType = "GoogleSatelliteMap";
                    // set default
                    try
                    {
                        var index = GMapProviders.List.FindIndex(x => (x.Name == mapType));

                        if (index != -1) comboBoxMapType.SelectedIndex = index;
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                    }
                }
            }
        }


        /// <summary>
        /// Builds the get Capability request.
        /// </summary>
        /// <param name="serverUrl">The server URL.</param>
        /// <returns></returns>
        private string BuildGetCapabilitityRequest(string serverUrl)
        {
            // What happens if the URL already has  '?'. 
            // For example: http://foo.com?Token=yyyy
            // In this example, the get capability request should be 
            // http://foo.com?Token=yyyy&version=1.1.0&Request=GetCapabilities&service=WMS but not
            // http://foo.com?Token=yyyy?version=1.1.0&Request=GetCapabilities&service=WMS

            // If the URL doesn't contain '?', append it.
            if (!serverUrl.Contains("?"))
            {
                serverUrl += "?";
            }
            else
            {
                // Check if the URL already has query strings.
                // If the URL doesn't have query strings, '?' comes at the end.
                if (!serverUrl.EndsWith("?"))
                {
                    // Already have query string, so add '&' before adding other query strings.
                    serverUrl += "&";
                }
            }
            return serverUrl + "version=1.1.0&Request=GetCapabilities&service=WMS";
        }

        private void groupmarkeradd(GMapMarker marker)
        {
            System.Diagnostics.Debug.WriteLine("add marker " + marker.Tag.ToString());
            wpMarkersGroup.Add(int.Parse(marker.Tag.ToString()));
            if (marker is GMapMarkerWP)
            {
                ((GMapMarkerWP)marker).Selected = true;
            }
            if (marker is GMapMarkerRect)
            {
                ((GMapMarkerWP)((GMapMarkerRect)marker).InnerMarker).Selected = true;
            }
        }

        private void wpMarkersGroupAdd(GMapMarker marker)
        {

            if (marker is GMapMarkerWP)
            {
                System.Diagnostics.Debug.WriteLine("add marker " + marker.Tag.ToString());
                if (int.TryParse(((GMapMarkerWP)marker).Tag.ToString(), out int no))
                {
                    wpMarkersGroup.Add(int.Parse(marker.Tag.ToString()));
                    ((GMapMarkerWP)marker).Selected = true;
                }
            }
            if (marker is GMapMarkerRect)
            {
                System.Diagnostics.Debug.WriteLine("add marker " + ((GMapMarkerWP)((GMapMarkerRect)marker).InnerMarker).Tag.ToString());
                if (int.TryParse(((GMapMarkerWP)((GMapMarkerRect)marker).InnerMarker).Tag.ToString(), out int no))
                {
                    wpMarkersGroup.Add(no);
                    ((GMapMarkerWP)((GMapMarkerRect)marker).InnerMarker).Selected = true;
                }
            }
        }

        private void polygonMarkersGroupAdd(GMapMarker marker)
        {
            if (marker is GMapMarkerPolygon)
            {
                System.Diagnostics.Debug.WriteLine("add marker " + marker.Tag.ToString());
                if (int.TryParse(marker.Tag.ToString().Replace("grid", ""), out int no))
                {
                    polyMarkersGroup.Add(no);
                    ((GMapMarkerPolygon)marker).selected = true;
                }
            }
            if (marker is GMapMarkerRect)
            {
                if (int.TryParse(((GMapMarkerRect)marker).InnerMarker.Tag.ToString().Replace("grid", ""), out int no))
                {
                    polyMarkersGroup.Add(no);
                    ((GMapMarkerPolygon)((GMapMarkerRect)marker).InnerMarker).selected = true;
                }
            }

        }

        public void wpMarkersGroupAddAll()
        {
            foreach (var marker in MainMap.Overlays.First(a => a.Id == "WPOverlay").Markers)
            {
                try
                {
                    if (marker.Tag != null)
                    {
                        wpMarkersGroupAdd(marker);
                    }
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                }
            }
            writeKML();
        }

        public void polygonMarkersGroupAddAll()
        {
            foreach (var marker in MainMap.Overlays.First(a => a.Id == "drawnpolygons").Markers)
            {
                try
                {
                    if (marker.Tag != null)
                    {
                        polygonMarkersGroupAdd(marker);
                    }
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                }
            }
            redrawPolygonSurvey();
        }

        public void wpMarkersGroupClear()
        {
            if (wpMarkersGroup.Count > 0)
            {
                wpMarkersGroup.Clear();
                writeKML();
            }
        }

        public void polygonMarkersGroupClear()
        {
            if (polyMarkersGroup.Count > 0)
            {
                polyMarkersGroup.Clear();

                redrawPolygonSurvey();
            }
        }

        public void wpMarkersGroupFirst()
        {
            if (CustomData.WP.WPGlobalData.instance.GetWPCount() > 0)
                wpMarkersGroup.Add(0);
            writeKML();
        }

        public void polygonMarkersGroupFirst()
        {
            if (CustomData.WP.WPGlobalData.instance.GetPolyCount() > 0)
                polyMarkersGroup.Add(0);
            redrawPolygonSurvey();
        }

        public void wpMarkersGroupNext()
        {
            if (wpMarkersGroup.Count > 0)
            {
                int next = (wpMarkersGroup.Max() + 1);
                wpMarkersGroup.Clear();
                if (next >= 0)
                    wpMarkersGroup.Add(next % CustomData.WP.WPGlobalData.instance.GetWPCount());
                else
                    wpMarkersGroup.Add(next);
                writeKML();
            }
        }

        public void wpMarkersGroupPrev()
        {
            if (wpMarkersGroup.Count > 0)
            {
                int prev = (wpMarkersGroup.Min() - 1);
                wpMarkersGroup.Clear();
                if (prev >= 0)
                    wpMarkersGroup.Add(prev);
                else
                    wpMarkersGroup.Add(prev + CustomData.WP.WPGlobalData.instance.GetWPCount());
                writeKML();
            }
        }

        public void polygonMarkersGroupNext()
        {
            if (polyMarkersGroup.Count > 0)
            {
                int next = (polyMarkersGroup.Max() + 1);
                polyMarkersGroup.Clear();
                if (next >= CustomData.WP.WPGlobalData.instance.GetPolyCount())
                    polyMarkersGroup.Add(next % CustomData.WP.WPGlobalData.instance.GetPolyCount());
                else
                    polyMarkersGroup.Add(next);

                redrawPolygonSurvey();
            }
        }

        public void polygonMarkersGroupPrev()
        {
            if (polyMarkersGroup.Count > 0)
            {
                int prev = (polyMarkersGroup.Min() - 1);
                polyMarkersGroup.Clear();
                if (prev >= 0)
                    polyMarkersGroup.Add(prev);
                else
                    polyMarkersGroup.Add(prev + CustomData.WP.WPGlobalData.instance.GetPolyCount());
                redrawPolygonSurvey();
            }
        }

        private void polygonMarkersGroupMoveUp()
        {
            polygonMarkersGroupMove(0, 1);
        }

        private void polygonMarkersGroupMoveDown()
        {
            polygonMarkersGroupMove(0, -1);
        }

        private void polygonMarkersGroupMoveLeft()
        {
            polygonMarkersGroupMove(-1, 0);
        }

        private void polygonMarkersGroupMoveRight()
        {
            polygonMarkersGroupMove(1, 0);
        }

        private void polygonMarkersGroupMove(int xMove, int yMove)
        {
            CustomData.WP.WPGlobalData.instance.BegionQuick();

            for (int index = 0; index < polyMarkersGroup.Count; index++)
            {
                try
                {
                    int no = polyMarkersGroup[index];
                    if (no >= 0 && no < CustomData.WP.WPGlobalData.instance.GetPolyCount())
                    {
                        var poly = CustomData.WP.WPGlobalData.instance.GetPolyPoint(no);
                        GPoint point = MainMap.FromLatLngToLocal(poly.ToPoint());
                        int idx = 1;
                        while (true)
                        {
                            PointLatLngAlt position = MainMap.FromLocalToLatLng(
                                (int)point.X + idx * xMove,
                                (int)point.Y - idx * yMove);
                            if (xMove * (position.Lng - poly.Lng) >= 0 && yMove * (position.Lat - poly.Lat) >= 0)
                            {
                                if (yMove != 0)
                                    poly.Lat = position.Lat;
                                if (xMove != 0)
                                    poly.Lng = position.Lng;
                                CustomData.WP.WPGlobalData.instance.MovePolyHandle(no, poly);
                                break;
                            }
                            else
                                idx++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                }
            }

            CustomData.WP.WPGlobalData.instance.EndQuick();

            CustomData.WP.WPGlobalData.instance.ExecutePolyOverSetting();
        }

        private void wpMarkersGroupMoveUp()
        {
            wpMarkersGroupMove(0, 10);
        }

        private void wpMarkersGroupMoveDown()
        {
            wpMarkersGroupMove(0, -10);
        }

        private void wpMarkersGroupMoveLeft()
        {
            wpMarkersGroupMove(-10, 0);
        }

        private void wpMarkersGroupMoveRight()
        {
            wpMarkersGroupMove(10, 0);
        }

        private void wpMarkersGroupMove(int xMove, int yMove)
        {
            CustomData.WP.WPGlobalData.instance.BegionQuick();

            for (int index = 0; index < wpMarkersGroup.Count; index++)
            {
                try
                {
                    int no = wpMarkersGroup[index];
                    if (no >= 0 && no < CustomData.WP.WPGlobalData.instance.GetWPCount())
                    {
                        var wp = CustomData.WP.WPGlobalData.instance.GetWPPoint(no);
                        GPoint point = MainMap.FromLatLngToLocal(wp.ToPoint());
                        int idx = 1;
                        while (true)
                        {
                            PointLatLngAlt position = MainMap.FromLocalToLatLng(
                                (int)point.X + idx * xMove,
                                (int)point.Y - idx * yMove);
                            if (xMove * (position.Lng - wp.Lng) >= 0 && yMove * (position.Lat - wp.Lat) >= 0)
                            {
                                if (yMove != 0)
                                    wp.Lat = position.Lat;
                                if (xMove != 0)
                                    wp.Lng = position.Lng;
                                CustomData.WP.WPGlobalData.instance.SetWPHandle(no, wp);
                                break;
                            }
                            else
                                idx++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                }
            }

            CustomData.WP.WPGlobalData.instance.EndQuick();

            CustomData.WP.WPGlobalData.instance.ExecuteWPOverSetting();
        }

        private void MainMap_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                //记录鼠标开始位置
                SetStartPoint(e.X, e.Y);

                if (IsMouseClickOffMenu)
                    return;

                if (e.Button == MouseButtons.Middle && Control.ModifierKeys != Keys.Alt && Control.ModifierKeys != Keys.Control)
                {
                    IsMouseDown = true;
                    IsWndDroppable = true;
                    return;
                }

                if (e.Button == MouseButtons.Left && (Control.ModifierKeys == Keys.Control) || Control.ModifierKeys == Keys.Alt)
                {
                    // group move
                    IsMouseDown = true;
                    IsMarkerPickable = true;
                    return;
                }

                if (e.Button == MouseButtons.Left && Control.ModifierKeys != Keys.Alt && Control.ModifierKeys != Keys.Control)
                {
                    IsMouseDown = true;

                    if (currentMarker.IsVisible)
                    {
                        currentMarker.Position = MainMap.FromLocalToLatLng(e.X, e.Y);
                    }
                    if (!IsDrawPolygongridMode && !IsDrawWPMode && CurentRectMarker == null)
                    {
                        IsWndDroppable = true;
                    }
                    else
                    {
                        IsMarkerAddable = true;
                        IsMarkerDroppable = true;
                    }
                    return;
                }
            }
            finally
            {
            }
        }

        private void MainMap_MouseEnter(object sender, EventArgs e)
        {
            // MainMap.Focus();
        }

        private void MainMap_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                //记录鼠标位置
                SetCurrentPoint(e.X, e.Y);

                //鼠标没按下
                if (!IsMouseDown)
                {
                    // update mouse pos display
                    SetMouseDisplay(MouseDownCurrent.Lat, MouseDownCurrent.Lng, -1);
                }

                //鼠标没移动
                if (MouseDownStart == MouseDownCurrent)
                    return;
                //鼠标移动

                //设置移动点
                currentMarker.Position = MouseDownCurrent;

                //可拖动状态下鼠标按下
                if (IsMarkerDroppable)
                {
                    IsMarkerDroping = true;

                    if (CurentRectMarker != null) // left click pan
                    {
                        //更新Polygon点位置
                        try
                        {
                            // 检查polygon点
                            if (CurentRectMarker.InnerMarker.Tag.ToString().Contains("grid"))
                            {
                                if (int.TryParse(CurentRectMarker.InnerMarker.Tag.ToString().Replace("grid", ""), out int no))
                                    SetPolyPoint(no, MouseDownCurrent.Lat, MouseDownCurrent.Lng);
                            }
                        }
                        catch (Exception ex)
                        {
                            log.Error(ex);
                        }

                        //更新WP位置
                        try
                        {
                            // 检查WP点
                            if ((CurentRectMarker != null && Regex.IsMatch(CurentRectMarker.Tag.ToString(), @"^\d+$")))
                            {
                                int? pIndex = (int?)CurentRectMarker.Tag;
                                if (pIndex.HasValue)
                                {
                                    if (pIndex < wppolygon.Points.Count)
                                    {
                                        wppolygon.Points[pIndex.Value] = MouseDownCurrent;
                                        lock (thisLock)
                                        {
                                            MainMap.UpdatePolygonLocalPosition(wppolygon);
                                            MainMap.Invalidate();
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            log.Error(ex);
                        }

                        //随鼠标位置更新当前标记
                        if (CurentRectMarker.InnerMarker.Tag.ToString().Contains("grid"))
                        {
                            if (currentMarker.IsVisible)
                            {
                                currentMarker.Position = MouseDownCurrent;
                            }
                            CurentRectMarker.Position = MouseDownCurrent;
                            if (CurentRectMarker.InnerMarker != null)
                            {
                                CurentRectMarker.InnerMarker.Position = MouseDownCurrent;
                            }
                        }
                        else if (Regex.IsMatch(CurentRectMarker.Tag.ToString(), @"^\d+$"))
                        {
                            if (currentMarker.IsVisible)
                            {
                                currentMarker.Position = MouseDownCurrent;
                            }
                            CurentRectMarker.Position = MouseDownCurrent;
                            if (CurentRectMarker.InnerMarker != null)
                            {
                                CurentRectMarker.InnerMarker.Position = MouseDownCurrent;
                            }
                        }
                    }
                    else
                    {
                        if (polyMarkersGroup.Count >= 0 && IsDrawPolygongridMode)
                        {
                            polygonMarkersGroupMove(
                                (int)(MouseDownCurrentPoint.X - MouseDownPrevPoint.X),
                                (int)(MouseDownPrevPoint.Y - MouseDownCurrentPoint.Y)
                                );
                        }
                        if (wpMarkersGroup.Count >= 0 && IsDrawWPMode)
                        {
                            wpMarkersGroupMove(
                                (int)(MouseDownCurrentPoint.X - MouseDownPrevPoint.X),
                                (int)(MouseDownPrevPoint.Y - MouseDownCurrentPoint.Y)
                                );
                        }
                    }
                    //else if (CurrentPOIMarker != null)
                    //{
                    //    CurrentPOIMarker.Position = mousePoint;
                    //}
                    //else if (CurrentGMapMarker != null)
                    //{
                    //    CurrentGMapMarker.Position = mousePoint;
                    //}
                }
                else if (IsWndDroppable)
                {
                    IsWndDroping = true;
                    double latdif = MouseDownStart.Lat - MouseDownCurrent.Lat;
                    double lngdif = MouseDownStart.Lng - MouseDownCurrent.Lng;

                    try
                    {
                        lock (thisLock)
                        {
                            if (!IsMouseClickOffMenu)
                                MainMap.Position = new PointLatLng(center.Position.Lat + latdif,
                                    center.Position.Lng + lngdif);
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                    }
                }
                else if (IsMarkerPickable)
                {
                    // draw selection box
                    double latdif = MouseDownStart.Lat - MouseDownCurrent.Lat;
                    double lngdif = MouseDownStart.Lng - MouseDownCurrent.Lng;

                    MainMap.SelectedArea = new RectLatLng(Math.Max(MouseDownStart.Lat, MouseDownCurrent.Lat),
                        Math.Min(MouseDownStart.Lng, MouseDownCurrent.Lng), Math.Abs(lngdif), Math.Abs(latdif));
                }
                else if (e.Button == MouseButtons.None)
                {
                    IsMouseDown = false;
                }
            }
            finally
            {
            }

        }

        private void MainMap_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) // ignore right clicks
            {
                if (polyicon.Rectangle.Contains(e.Location)) {
                    contextMenuStripMain.Visible = false;
                    ClearPloygon();
                }
                if (WPicon.Rectangle.Contains(e.Location))
                {
                    contextMenuStripMain.Visible = false;
                    ClearMission();
                    //ClearMissionToolStripMenuItem_Click(this, null);
                }
                if (zoomicon.Rectangle.Contains(e.Location))
                {
                    contextMenuStripMain.Visible = false;
                    contextMenuStripTiff.Show(MainMap, e.Location);
                }
                return;
            }
            try
            {
                if (IsMouseClickOffMenu)
                {
                    IsMouseClickOffMenu = false;
                    return;
                }

                // check if the mouse up happend over our button
                if (OnIcon_MouseClick(sender, e))
                    return;

                if (e.Button == MouseButtons.None)
                {
                    return;
                }

                SetEndPoint(e.X, e.Y);

                if (IsMouseDown) // mouse down on some other object and dragged to here.
                {
                    if (IsWndDroppable)
                    {
                        return;
                    }
                    else if (IsMarkerPickable && Control.ModifierKeys == Keys.Control)
                    {
                        // group select wps
                        GMapPolygon poly = new GMapPolygon(new List<PointLatLng>(), "temp");

                        poly.Points.Add(MouseDownStart);
                        poly.Points.Add(new PointLatLng(MouseDownStart.Lat, MouseDownEnd.Lng));
                        poly.Points.Add(MouseDownEnd);
                        poly.Points.Add(new PointLatLng(MouseDownEnd.Lat, MouseDownStart.Lng));

                        foreach (var marker in MainMap.Overlays.First(a => a.Id == "WPOverlay").Markers)
                        {
                            if (poly.IsInside(marker.Position))
                            {
                                try
                                {
                                    if (marker.Tag != null)
                                    {
                                        wpMarkersGroupAdd(marker);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    log.Error(ex);
                                }
                            }
                        }

                        return;
                    }
                    else if (IsMarkerPickable && Control.ModifierKeys == Keys.Alt)
                    {
                        // group select wps
                        GMapPolygon poly = new GMapPolygon(new List<PointLatLng>(), "temp");

                        poly.Points.Add(MouseDownStart);
                        poly.Points.Add(new PointLatLng(MouseDownStart.Lat, MouseDownEnd.Lng));
                        poly.Points.Add(MouseDownEnd);
                        poly.Points.Add(new PointLatLng(MouseDownEnd.Lat, MouseDownStart.Lng));

                        foreach (var marker in MainMap.Overlays.First(a => a.Id == "drawnpolygons").Markers)
                        {
                            if (poly.IsInside(marker.Position))
                            {
                                try
                                {
                                    if (marker.Tag != null)
                                    {
                                        polygonMarkersGroupAdd(marker);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    log.Error(ex);
                                }
                            }
                        }

                        return;
                    }
                    else if (IsMarkerDroping)
                    {
                        if (CurentRectMarker != null && CurentRectMarker.InnerMarker != null)
                        {
                            if (CurentRectMarker.InnerMarker.Tag.ToString().Contains("grid"))
                            {
                                try
                                {
                                    if (int.TryParse(CurentRectMarker.InnerMarker.Tag.ToString().Replace("grid", ""), out int no))
                                        SetPolyPoint(no, MouseDownEnd.Lat, MouseDownEnd.Lng);
                                }
                                catch (Exception ex)
                                {
                                    log.Error(ex);
                                }
                            }
                            else if ((CurentRectMarker != null && Regex.IsMatch(CurentRectMarker.Tag.ToString(), @"^\d+$")))
                            {
                                CallMeDrag(
                                    (int.Parse(CurentRectMarker.InnerMarker.Tag.ToString())).ToString(),
                                    currentMarker.Position.Lat,
                                    currentMarker.Position.Lng, -1);

                                writeKML();
                            }
                            CurentRectMarker = null;
                        }
                        else
                        {
                            if (polyMarkersGroup.Count >= 0 && IsDrawPolygongridMode)
                            {
                                polygonMarkersGroupMove(
                                    (int)(MouseDownCurrentPoint.X - MouseDownPrevPoint.X),
                                    (int)(MouseDownPrevPoint.Y - MouseDownCurrentPoint.Y)
                                    );
                            }
                            if (wpMarkersGroup.Count >= 0 && IsDrawWPMode)
                            {
                                wpMarkersGroupMove(
                                    (int)(MouseDownCurrentPoint.X - MouseDownPrevPoint.X),
                                    (int)(MouseDownPrevPoint.Y - MouseDownCurrentPoint.Y)
                                    );
                            }
                        }
                        return;
                    }

                    if (wpMarkersGroup.Count > 0 || polyMarkersGroup.Count > 0)
                    {
                        if (wpMarkersGroup.Count > 0)
                        {
                            wpMarkersGroupClear();
                            // redraw to remove selection
                        }
                        if (polyMarkersGroup.Count > 0)
                        {
                            polygonMarkersGroupClear();
                            // redraw to remove selection
                        }
                        return;
                    }

                    if (IsMarkerAddable)
                    {
                        if (CurentRectMarker != null)
                        {
                            // cant add WP in existing rect
                            return;
                        }
                        if (CurrentMidLine is GMapMarkerPlus)
                        {
                            OnMidLine_Click();
                            return;
                        }
                        AddMarkToMap(currentMarker.Position.Lat, currentMarker.Position.Lng, -1);

                    }
                    // drag finished, update poi db
                    //if (CurrentPOIMarker != null)
                    //{
                    //    POI.POIMove(CurrentPOIMarker);
                    //    CurrentPOIMarker = null;
                    //}
                }
            }
            finally
            {
                MainMap.SelectedArea = RectLatLng.Empty;
                IsMouseDown = false;
                IsMarkerAddable = false;
                IsWndDroppable = false;
                IsMarkerDroppable = false;
                IsMarkerPickable = false;
                IsMarkerDroping = false;
                CurentRectMarker = null;
            }
        }


        private void MainMap_OnCurrentPositionChanged(PointLatLng point)
        {
            if (point.Lat > 90)
            {
                point.Lat = 90;
            }
            if (point.Lat < -90)
            {
                point.Lat = -90;
            }
            if (point.Lng > 180)
            {
                point.Lng = 180;
            }
            if (point.Lng < -180)
            {
                point.Lng = -180;
            }
            center.Position = point;
        }

        #region 
        private void MainMap_OnMapTypeChanged(GMapProvider type)
        {
            comboBoxMapType.SelectedItem = MainMap.MapProvider;

            if (type == WMSProvider.Instance)
            {
                string url = "";
                if (Settings.Instance["WMSserver"] != null)
                    url = Settings.Instance["WMSserver"];
                if (DialogResult.Cancel == InputBox.Show("WMS Server", "请输入 WMS server URL", ref url))
                    return;

                // Build get capability request.
                string szCapabilityRequest = BuildGetCapabilitityRequest(url);

                XmlDocument xCapabilityResponse = MakeRequest(szCapabilityRequest);
                ProcessWmsCapabilitesRequest(xCapabilityResponse);

                Settings.Instance["WMSserver"] = url;
                WMSProvider.CustomWMSURL = url;
            }
        }

        private void MainMap_OnMapZoomChanged()
        {
            if (MainMap.Zoom > 0)
            {
                try
                {
                    trackBar1.Value = (int)(MainMap.Zoom);
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                }
                //textBoxZoomCurrent.Text = MainMap.Zoom.ToString();
                center.Position = MainMap.Position;
            }
        }
        #endregion

        #region
        private void MainMap_OnMarkerClick(GMapMarker item, object ei)
        {
            var e = ei as MouseEventArgs;
            //int answer;
            try // when dragging item can sometimes be null
            {
                if (item.Tag == null)
                {
                    // home.. etc
                    return;
                }
                if (int.TryParse(item.Tag.ToString(), out int answer))
                {
                    //Commands.CurrentCell = Commands[0, answer - 1];
                }
                if (IsMarkerPickable)
                {
                    if (Control.ModifierKeys == Keys.Control)
                    {
                        try
                        {
                            wpMarkersGroupAdd(item);

                            log.Info("add marker to group");
                        }
                        catch (Exception ex)
                        {
                            log.Error(ex);
                        }
                    }
                    else if (Control.ModifierKeys == Keys.Alt)
                    {
                        try
                        {
                            polygonMarkersGroupAdd(item);

                            log.Info("add marker to group");
                        }
                        catch (Exception ex)
                        {
                            log.Error(ex);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        private void MainMap_OnMarkerEnter(GMapMarker item)
        {
            if (!IsMouseDown)
            {
                if (item is GMapMarkerRect)
                {
                    GMapMarkerRect rc = item as GMapMarkerRect;
                    rc.Pen.Color = Color.Red;
                    MainMap.Invalidate(false);

                    int answer;
                    if (item.Tag != null && rc.InnerMarker != null &&
                        int.TryParse(rc.InnerMarker.Tag.ToString(), out answer))
                    {
                        try
                        {
                            //Commands.CurrentCell = Commands[0, answer - 1];
                            //item.ToolTipText = "Alt: " + Commands[Alt.Index, answer - 1].Value;
                            //item.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                        }
                        catch (Exception ex)
                        {
                            log.Error(ex);
                        }
                    }

                    CurentRectMarker = rc;
                }
                if (item is GMapMarkerRallyPt)
                {
                    CurrentRallyPt = item as GMapMarkerRallyPt;
                }
                if (item is GMapMarkerAirport)
                {
                    // do nothing - readonly
                    return;
                }
                if (item is GMapMarkerPlus && ((GMapMarkerPlus)item).Tag is midline)
                {
                    CurrentMidLine = item;
                    return;
                }
                if (item is GMapMarkerPOI)
                {
                    CurrentPOIMarker = item as GMapMarkerPOI;
                }
                if (item is GMapMarkerWP)
                {
                    //CurrentGMapMarker = item;
                }
                if (item is GMapMarker)
                {
                    //CurrentGMapMarker = item;
                }
            }
        }

        private void MainMap_OnMarkerLeave(GMapMarker item)
        {
            if (!IsMouseDown)
            {
                if (item is GMapMarkerRect)
                {
                    CurentRectMarker = null;
                    GMapMarkerRect rc = item as GMapMarkerRect;
                    rc.ResetColor();
                    MainMap.Invalidate(false);
                }
                if (item is GMapMarkerRallyPt)
                {
                    CurrentRallyPt = null;
                }
                if (item is GMapMarkerPOI)
                {
                    CurrentPOIMarker = null;
                }
                if (item is GMapMarkerPlus && ((GMapMarkerPlus)item).Tag is midline)
                {
                    CurrentMidLine = null;
                }
                if (item is GMapMarker)
                {
                    // when you click the context menu this triggers and causes problems
                    CurrentGMapMarker = null;
                }
            }
        }
        #endregion

        private void MainMap_OnTileLoadComplete(long ElapsedMilliseconds)
        {
            //MainMap.ElapsedMilliseconds = ElapsedMilliseconds;

            MethodInvoker m = delegate
            {
                lbl_status.Text = "Status: loaded tiles";

                //panelMenu.Text = "Menu, last load in " + MainMap.ElapsedMilliseconds + "ms";

                //textBoxMemory.Text = string.Format(CultureInfo.InvariantCulture, "{0:0.00}MB of {1:0.00}MB", MainMap.Manager.MemoryCacheSize, MainMap.Manager.MemoryCacheCapacity);
            };
            try
            {
                if (!IsDisposed && IsHandleCreated) BeginInvoke(m);
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        private void MainMap_OnTileLoadStart()
        {
            MethodInvoker m = delegate { lbl_status.Text = "Status: loading tiles..."; };
            try
            {
                if (IsHandleCreated) BeginInvoke(m);
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        private XmlDocument MakeRequest(string requestUrl)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                if (!String.IsNullOrEmpty(Settings.Instance.UserAgent))
                    ((HttpWebRequest)request).UserAgent = Settings.Instance.UserAgent;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;


                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(response.GetResponseStream());
                return (xmlDoc);
            }
            catch (Exception e)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Failed to make WMS Server request: " + e.Message);
                return null;
            }
        }

        private void ProcessWmsCapabilitesRequest(XmlDocument xCapabilitesResponse)
        {
            //Create namespace manager
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xCapabilitesResponse.NameTable);

            //check if the response is a valid xml document - if not, the server might still be able to serve us but all the checks below would fail. example: http://tiles.kartat.kapsi.fi/peruskartta
            //best sign is that there is no node WMT_MS_Capabilities
            if (xCapabilitesResponse.SelectNodes("//WMT_MS_Capabilities", nsmgr).Count == 0)
                return;


            //first, we have to make sure that the server is able to send us png imagery
            bool bPngCapable = false;
            XmlNodeList getMapElements = xCapabilitesResponse.SelectNodes("//GetMap", nsmgr);
            if (getMapElements.Count != 1)
                DevComponents.DotNetBar.MessageBoxEx.Show("Invalid WMS Server response: Invalid number of GetMap elements.");
            else
            {
                XmlNode getMapNode = getMapElements.Item(0);
                //search through all format nodes for image/png
                foreach (XmlNode formatNode in getMapNode.SelectNodes("//Format", nsmgr))
                {
                    if (formatNode.InnerText.Contains("image/png"))
                    {
                        bPngCapable = true;
                        break;
                    }
                }
            }


            if (!bPngCapable)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Invalid WMS Server response: Server unable to return PNG images.");
                return;
            }


            //now search through all layer -> srs nodes for EPSG:4326 compatibility
            bool bEpsgCapable = false;
            XmlNodeList srsELements = xCapabilitesResponse.SelectNodes("//SRS", nsmgr);
            foreach (XmlNode srsNode in srsELements)
            {
                if (srsNode.InnerText.Contains("EPSG:4326"))
                {
                    bEpsgCapable = true;
                    break;
                }
            }


            if (!bEpsgCapable)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show(
                    "Invalid WMS Server response: Server unable to return EPSG:4326 / WGS84 compatible images.");
                return;
            }


            // the server is capable of serving our requests - now check if there is a layer to be selected
            // Display layer title in the input box instead of layer name.
            // format: layer -> layer -> name
            //         layer -> layer -> title
            string szLayerSelection = "";
            int iSelect = 0;
            List<string> szListLayerName = new List<string>();
            // Loop through all layers.
            XmlNodeList layerElements = xCapabilitesResponse.SelectNodes("//Layer/Layer", nsmgr);
            foreach (XmlNode layerElement in layerElements)
            {
                // Get Name element.
                var nameNode = layerElement.SelectSingleNode("Name", nsmgr);

                // Skip if no name element is found.
                if (nameNode != null)
                {
                    var name = nameNode.InnerText;
                    // Set the default title as the layer name. 
                    var title = name;
                    // Get Title element.
                    var titleNode = layerElement.SelectSingleNode("Title", nsmgr);
                    if (titleNode != null)
                    {
                        var titleText = titleNode.InnerText;
                        if (!string.IsNullOrWhiteSpace(titleText))
                        {
                            title = titleText;
                        }
                    }
                    szListLayerName.Add(name);

                    szLayerSelection += string.Format("{0}: {1}\n ", iSelect, title);
                    //mixing control and formatting is not optimal...
                    iSelect++;
                }
            }

            //only select layer if there is one
            if (szListLayerName.Count != 0)
            {
                //now let the user select a layer
                string szUserSelection = "";
                if (DialogResult.Cancel ==
                    InputBox.Show("WMS Server",
                        "The following layers were detected:\n " + szLayerSelection +
                        "Please choose one by typing the associated number.", ref szUserSelection))
                    return;
                int iUserSelection = 0;
                try
                {
                    iUserSelection = Convert.ToInt32(szUserSelection);
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    iUserSelection = 0; //ignore all errors and default to first layer
                }

                WMSProvider.szWmsLayer = szListLayerName[iUserSelection];
                Settings.Instance["WMSLayer"] = WMSProvider.szWmsLayer;
            }
        }

        private void zoomToVehicleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainV2.comPort.MAV.cs.Location.Lat == 0 && MainV2.comPort.MAV.cs.Location.Lng == 0)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show(Strings.Invalid_Location, Strings.ERROR);
                return;
            }

            MainMap.Position = MainV2.comPort.MAV.cs.Location;
            if (MainMap.Zoom < 17)
                MainMap.Zoom = 17;
        }


        public void ShowLayerOverlay(GDAL.GDAL.GeoBitmap geoBitmap)
        {
            if (geoBitmap.File == CustomData.WP.WPGlobalData.instance.GetLayer())
            {
                layerPolygonsOverlay.Polygons.Clear();

                PointLatLngAlt pos1 = new PointLatLngAlt(geoBitmap.Rect.Top, geoBitmap.Rect.Left);
                PointLatLngAlt pos2 = new PointLatLngAlt(geoBitmap.Rect.Bottom, geoBitmap.Rect.Right);

                var mark = new GMapMarkerLayer(
                    pos1, pos2,
                    geoBitmap.DisplayBitmap);
                layerPolygonsOverlay.Polygons.Add(mark);

                MainMap.SetZoomToFitRect(CustomData.WP.WPGlobalData.instance.GetLayerRect().ToWGS84());

                Task.Run(
                    () =>
                    {
                        var tile = MainV2.CreateTile(geoBitmap, 400, 400);
                        for (int i = 0; i < tile.Count; i++)
                        {
                            mark.AddTile(tile[i]._tile, tile[i]._rect);
                        }

                    }
                );

                CustomData.WP.WPGlobalData.instance.SetHomePosition(
                    CustomData.WP.WPGlobalData.instance.GetLayerHome());

                writeKML();
            }
        }

        public void zoomToTiffLayer()
        {
            if (CustomData.WP.WPGlobalData.instance.GetLayer() != null)
                MainMap.SetZoomToFitRect(CustomData.WP.WPGlobalData.instance.GetLayerRect().ToWGS84());
        }


        #region 右键菜单项

        #region 删除标记
        public void DeleteMarkerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurentRectMarker != null)
            {
                if (int.TryParse(CurentRectMarker.InnerMarker.Tag.ToString(), out int no))
                {
                    try
                    {
                        DeleteWP(no);
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                        DevComponents.DotNetBar.MessageBoxEx.Show("error selecting wp, please try again.");
                    }
                }
                else if (int.TryParse(CurentRectMarker.InnerMarker.Tag.ToString().Replace("grid", ""), out no))
                {
                    try
                    {
                        DeletePolygon(no);
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                        //CustomMessageBox.Show("Remove point Failed. Please try again.");
                    }
                }
            }
            if (wpMarkersGroup.Count > 0)
            {
                DeleteCurrentWP();
            }
            if (polyMarkersGroup.Count > 0)
            {
                DeleteCurrentPolygon();
            }


            if (currentMarker != null)
                CurentRectMarker = null;

        }
        #endregion

        #region 规划航点

        #region 设置航点
        private void AddWPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!IsDrawWPMode)
            {
                IsDrawWPMode = true;
                return;
            }

            AddWPPoint(MouseDownStart.Lat, MouseDownStart.Lng, defaultAlt);
            writeKML();
        }
        #endregion

        #region 清除航点
        public void ClearMission()
        {
            clearMissionToolStripMenuItem_Click(this, null);
        }

        private void clearMissionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomData.WP.WPGlobalData.instance.ClearWPListHandle();
        }
        #endregion

        #region 自动航点
        private void surveyGridToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 保存航点
        public void SaveWPFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            savewaypoints();
        }
        #endregion

        #region 加载航点
        private void loadWPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadwaypoints();
        }
        #endregion

        #endregion

        #region 规划区域

        #region 设置区域
        private void AddPolygonPointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!IsDrawPolygongridMode)
            {
                IsDrawPolygongridMode = true;
                return;
            }
            AddPolyPoint(MouseDownStart.Lat, MouseDownStart.Lng);
        }
        #endregion

        #region 清除区域
        public void ClearPloygon()
        {
            ClearPolygonToolStripMenuItem_Click(this, null);
        }

        private void ClearPolygonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomData.WP.WPGlobalData.instance.ClearPolyHandle();
        }
        #endregion

        #region 保存区域
        public void SavePolygonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CustomData.WP.WPGlobalData.instance.GetPolyCount() <= 0)
            {
                return;
            }

            using (SaveFileDialog sf = new SaveFileDialog())
            {
                sf.Filter = "Polygon (*.poly)|*.poly";
                var result = sf.ShowDialog();

                string file = sf.FileName;
                if (result == DialogResult.OK && File.Exists(file))
                {
                    switch (sf.FilterIndex)
                    {
                        case 1:
                            savePolygons(file);
                            break;
                    }
                }
            }
        }
        #endregion

        #region 加载区域
        private void loadPolygonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadpolygons();
        }
        #endregion

        #endregion

        #endregion

        #region 功能区

        #region 定位

        #region 定位到WP
        public void ZoomToCenterWP()
        {
            MainMap.Invalidate();
            MainMap.ZoomAndCenterMarkers("WPOverlay");
        }
        #endregion

        #region 定位到Polygon
        public void ZoomToCenterPolygon()
        {
            var list = CustomData.WP.WPGlobalData.instance.GetPolyList();
            if (list.Count > 0)
            {
                double left = list[0].Lng; double right = list[0].Lng;
                double top = list[0].Lat; double bottom = list[0].Lat;
                for (int i = 1; i < list.Count; i++)
                {
                    if (list[i].Lng > right)
                        right = list[i].Lng;
                    if (list[i].Lng < left)
                        left = list[i].Lng;
                    if (list[i].Lat > top)
                        top = list[i].Lat;
                    if (list[i].Lat < bottom)
                        bottom = list[i].Lat;
                }
                ZoomToRectMap(RectLatLng.FromLTRB(left - 0.01, top + 0.01, right + 0.01, bottom - 0.01));
            }

            //MainMap.UpdatePolygonLocalPosition(drawnpolygon);
            //MainMap.Invalidate();
            //MainMap.ZoomAndCenterMarkers(drawnpolygonsoverlay.Id);
        }
        #endregion

        #region 定位到灵活点
        public void ZoomToRectMap(RectLatLng limit)
        {
            MainMap.SetZoomToFitRect(limit);
        }
        #endregion

        #endregion

        #region 添加Marker
        /// <summary>
        /// Used to create a new WP
        /// </summary>
        /// <param name="lat"></param>
        /// <param name="lng"></param>
        /// <param name="alt"></param>
        public void AddMarkToMap(double lat, double lng, int alt)
        {
            if (IsDrawPolygongridMode)
            {
                AddPolyPoint(lat, lng);
                return;
            }
            else if (IsDrawWPMode)
            {

                if (sethome)
                {
                    sethome = false;
                    CallMeDrag(CustomData.WP.WPCommands.HomeCommand, lat, lng, alt);
                    return;
                }
                //creating a WP

                AddWPPoint(lat, lng, alt);
            }
        }
        #endregion

        #region 坐标转换

        #region WGS84 To Loc
        /// <summary>
        /// form WGS84 covert to Local coordinates
        /// </summary>
        private void CovertToWorkCoordinate(PointLatLngAlt WGS84Point, out PointLatLngAlt WorkPoint)
        {
            var layer = CustomData.Layer.MemoryLayerCache.GetLayerFromMemoryCache(
                CustomData.WP.WPGlobalData.instance.GetLayer()
                );
            if (layer == null)
            {
            }
            double Scale = layer.Scale;

            PointLatLngAlt Home = layer.Home.ToWGS84();

            int OriginZone = Home.GetUTMZone();
            double[] OriginCoord = Home.ToUTM(OriginZone);

            int WGS84Zone = WGS84Point.GetUTMZone();
            double[] WGS84Coord = WGS84Point.ToUTM(OriginZone);

            double WGS84UTMEast = WGS84Coord[0];
            double WGS84UTMNorth = WGS84Coord[1];
            if (WGS84Zone < 0)
                WGS84UTMNorth = WGS84UTMNorth - 10000000;
            double OriginUTMEast = OriginCoord[0];
            double OriginUTMNorth = OriginCoord[1];
            if (OriginZone < 0)
                OriginUTMNorth = OriginUTMNorth - 10000000;

            double deltaLng, deltaLat, deltaAlt;

            deltaLng = (WGS84UTMEast - OriginUTMEast) / Scale;
            deltaLat = (WGS84UTMNorth - OriginUTMNorth) / Scale;
            deltaAlt = (WGS84Point.Alt - Home.Alt) / Scale;

            // m => mm
            WorkPoint = new PointLatLngAlt(deltaLat * 1000, deltaLng * 1000, deltaAlt * 1000);

        }

        /// <summary>
        /// form WGS84 covert to Local coordinates
        /// </summary>
        private void CovertToWorkCoordinate(double lng, double lat, double alt, out double x, out double y, out double z)
        {
            this.CovertToWorkCoordinate(new PointLatLngAlt(lat, lng, alt), out PointLatLngAlt wgs84);
            x = wgs84.Lng;
            y = wgs84.Lat;
            z = wgs84.Alt;
        }
        #endregion

        #region Loc To WGS84
        /// <summary>
        /// form Local coordinates covert to WGS84
        /// </summary>
        private void CovertFromWorkCoordinate(PointLatLngAlt WorkCoordPoint, out PointLatLngAlt WGS84CorrdPoint)
        {
            var layer = CustomData.Layer.MemoryLayerCache.GetLayerFromMemoryCache(
                CustomData.WP.WPGlobalData.instance.GetLayer()
                );
            if (layer == null)
            {
            }
            double Scale = layer.Scale;

            PointLatLngAlt Home = layer.Home.ToWGS84();

            int OriginZone = Home.GetUTMZone();
            double[] OriginCoord = Home.ToUTM();

            double OriginUTMEast = OriginCoord[0];
            double OriginUTMNorth = OriginCoord[1];
            if (OriginZone < 0)
                OriginUTMNorth = OriginUTMNorth - 10000000;

            // mm => m
            WorkCoordPoint = new PointLatLngAlt(WorkCoordPoint.Lat / 1000, WorkCoordPoint.Lng / 1000, WorkCoordPoint.Alt / 1000);

            double deltaEast, deltaNorth, deltaAlt;

            deltaEast = (WorkCoordPoint.Lng * Scale + OriginUTMEast);
            deltaNorth = (WorkCoordPoint.Lat * Scale + OriginUTMNorth);
            deltaAlt = (WorkCoordPoint.Alt * Scale + Home.Alt);

            WGS84CorrdPoint = PointLatLngAlt.FromUTM(OriginZone, deltaEast, deltaNorth);
            WGS84CorrdPoint.Alt = deltaAlt;
        }

        /// <summary>
        /// form Local coordinates covert to WGS84
        /// </summary>
        private void CovertFromWorkCoordinate(double x, double y, double z, out double lng, out double lat, out double alt)
        {
            this.CovertFromWorkCoordinate(new PointLatLngAlt(y, x, z), out PointLatLngAlt local);
            lng = local.Lng;
            lat = local.Lat;
            alt = local.Alt;
        }

        #endregion

        #endregion

        #endregion

        #region 鼠标

        #region 根据鼠标当前位置触发效果
        /// <summary>
        /// Used for current mouse position
        /// </summary>
        /// <param name="lat"></param>
        /// <param name="lng"></param>
        /// <param name="alt"></param>
        private void SetMouseDisplay(double lat, double lng, int alt)
        {
            var mouseposdisplay = new CustomData.WP.VPSPosition(lat, lng, alt);


            var current = new CustomData.WP.VPSPosition(lat, lng);
            current.Alt = defaultAlt;
            current.AltMode = altFrame.ToString();
            CustomData.WP.WPGlobalData.instance.SetCurrentPosition(current);
        }
        #endregion

        #region 鼠标操作数据
        internal PointLatLng MouseDownStart;
        internal PointLatLng MouseDownCurrent;
        internal PointLatLng MouseDownEnd;
        private GPoint MouseDownStartPoint = new GPoint();
        private GPoint MouseDownCurrentPoint = new GPoint();
        private GPoint MouseDownPrevPoint = new GPoint();
        private GPoint MouseDownEndPoint = new GPoint();

        #region Loc Point 
        private void SetStartPoint(int X, int Y)
        {
            MouseDownStartPoint = new GPoint(X, Y);
            MouseDownCurrentPoint = new GPoint(X, Y);
            MouseDownStart = MainMap.FromLocalToLatLng(X, Y);
        }

        private void SetCurrentPoint(int X, int Y)
        {
            if (MouseDownCurrentPoint != null)
                MouseDownPrevPoint = MouseDownCurrentPoint;
            MouseDownCurrentPoint = new GPoint(X, Y);
            MouseDownCurrent = MainMap.FromLocalToLatLng(X, Y);
        }

        private void SetEndPoint(int X, int Y)
        {
            MouseDownEndPoint = new GPoint(X, Y);
            MouseDownEnd = MainMap.FromLocalToLatLng(X, Y);
        }
        #endregion

        #endregion

        #endregion

        #region 小图标

        #region 入口函数
        private bool OnIcon_MouseClick(object sender, MouseEventArgs e)
        {
            // check if the mouse up happend over our button

            bool ret = false;

            ret = OnPolyIcon_MouseClick(sender, e) || ret;
            ret = OnWPIcon_MouseClick(sender, e) || ret;
            ret = OnZoomIcon_MouseClick(sender, e) || ret;

            return ret;
        }
        #endregion

        #region Polygon
        private VPS.Controls.Icon.Polygon polyicon = new VPS.Controls.Icon.Polygon();

        private bool OnPolyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            // check if the mouse up happend over our button
            if (polyicon.Rectangle.Contains(e.Location))
            {
                if (e.Button == MouseButtons.Left)
                {
                    polyicon.IsSelected = !polyicon.IsSelected;

                }
                IsDrawPolygongridMode = polyicon.IsSelected ? true : false;

                //contextMenuStripPoly.Show(MainMap, e.Location);
                return true;
            }
            return false;
        }
        #endregion

        #region WP
        private VPS.Controls.Icon.WP WPicon = new VPS.Controls.Icon.WP();

        private bool OnWPIcon_MouseClick(object sender, MouseEventArgs e)
        {
            // check if the mouse up happend over our button
            if (WPicon.Rectangle.Contains(e.Location))
            {
                if (e.Button == MouseButtons.Left)
                {
                    //surveyGridToolStripMenuItem_Click(this, null);
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Zoom
        private VPS.Controls.Icon.Zoom zoomicon = new VPS.Controls.Icon.Zoom();

        private bool OnZoomIcon_MouseClick(object sender, MouseEventArgs e)
        {
            // check if the mouse up happend over our button
            if (zoomicon.Rectangle.Contains(e.Location))
            {
                //contextMenuStripZoom.Show(MainMap, e.Location);
                if (layerPolygonsOverlay.Polygons.Count > 0)
                    zoomicon.IsSelected = true;
                else
                    zoomicon.IsSelected = false;
                if (e.Button == MouseButtons.Left)
                {
                    if (zoomicon.IsSelected)
                    {
                        zoomToTiffLayer();
                    }
                    else
                    {
                        contextMenuStripMain.Visible = false;
                        TiffOverlayToolStripMenuItem_Click(this, null);
                    }
                    if (layerPolygonsOverlay.Polygons.Count > 0)
                        zoomicon.IsSelected = true;
                    else
                        zoomicon.IsSelected = false;
                }
                return true;
            }
            return false;
        }
        #endregion

        #endregion

        #region 数据

        #region CoordSystem

        private enum CoordsSystems
        {
            WGS84,
            UTM,
            MGRS
        }
        private CoordsSystems coordSystem = CoordsSystems.WGS84;

        public StringChangeHandle coordChange;

        #region SetCoordSystem

        #region 接口函数
        private delegate void SetCoordSystemInThread(string coord);
        public void SetCoordSystemHandle(string coord)
        {
            if (this.InvokeRequired)
            {
                SetCoordSystemInThread inThread = new SetCoordSystemInThread(SetCoordSystemHandle);
                this.Invoke(inThread);
            }
            else
            {
                StopSendDataChange();
                SetCoordSystem(coord);
                StartSendDataChange();
            }
        }
        #endregion

        #region 入口函数
        private void SetCoordSystem(string coord)
        {
            switch (coord.ToString())
            {
                case "WGS84":
                    coordSystem = CoordsSystems.WGS84;
                    break;
                case "UTM":
                    coordSystem = CoordsSystems.UTM;
                    break;
                case "MGRS":
                    coordSystem = CoordsSystems.MGRS;
                    break;
                default:
                    coordSystem = CoordsSystems.WGS84;
                    break;
            }
            if (IsAllowSendDataChange())
                coordChange?.Invoke(coordSystem.ToString());
        }
        #endregion

        #endregion

        #endregion

        #region AltFrame

        private CustomData.EnumCollect.AltFrame.Mode altFrame = CustomData.EnumCollect.AltFrame.Mode.Relative;

        public StringChangeHandle altFrameChange;

        #region SetAltFrame

        #region AltFrame 接口函数
        private delegate void SetAltFrameInThread(string frame);
        public void SetAltFrameHandle(string frame)
        {
            if (this.InvokeRequired)
            {
                SetAltFrameInThread inThread = new SetAltFrameInThread(SetAltFrameHandle);
                this.Invoke(inThread, new object[] { frame });
            }
            else
            {
                StopSendDataChange();
                SetAltFrame(frame);
                StartSendDataChange();
            }
        }
        #endregion

        #region AltFrame 入口函数
        private void SetAltFrame(string frame)
        {
            altFrame = CustomData.EnumCollect.AltFrame.GetAltFrame(frame);

            if (IsAllowSendDataChange())
                altFrameChange?.Invoke(altFrame.ToString());
        }
        #endregion

        #endregion

        #region GetAltFrame
        public string GetAltFrame()
        {
            return CustomData.EnumCollect.AltFrame.GetAltFrame(altFrame);
        }
        #endregion

        #endregion

        #region Alt

        #region DefaultAlt

        private int defaultAlt = 200;

        public IntegerChangeHandler defaultAltChange;

        #region SetDefaultAlt

        #region DefaultAlt 接口函数
        private delegate void SetDefaultAltInThread(int defaultAlt);
        public void SetDefaultAltHandle(int defaultAlt)
        {
            if (this.InvokeRequired)
            {
                SetDefaultAltInThread inThread = new SetDefaultAltInThread(SetDefaultAltHandle);
                this.Invoke(inThread, new object[] { defaultAlt });
            }
            else
            {
                StopSendDataChange();
                SetDefaultAlt(defaultAlt);
                StartSendDataChange();
            }
        }
        #endregion

        #region DefaultAlt 入口函数
        private void SetDefaultAlt(int alt)
        {
            defaultAlt = alt;
            if (IsAllowSendDataChange())
                defaultAltChange?.Invoke(defaultAlt);
        }
        #endregion

        #endregion

        #region GetDefaultAlt
        private int GetDefaultAlt()
        {
            return defaultAlt;
        }
        #endregion

        #endregion

        #region WarnAlt

        private int warnAlt = 40;

        public IntegerChangeHandler warnAltChange;

        #region SetWarnAlt

        #region WarnAlt 接口函数
        private delegate void SetWarnAltInThread(int warnAlt);
        public void SetWarnAltHandle(int warnAlt)
        {
            if (this.InvokeRequired)
            {
                SetWarnAltInThread inThread = new SetWarnAltInThread(SetWarnAltHandle);
                this.Invoke(inThread, new object[] { warnAlt });
            }
            else
            {
                StopSendDataChange();
                SetWarnAlt(warnAlt);
                StartSendDataChange();
            }
        }
        #endregion

        #region WarnAlt 入口函数
        private void SetWarnAlt(int alt)
        {
            warnAlt = alt;
            if (IsAllowSendDataChange())
                warnAltChange?.Invoke(warnAlt);

        }
        #endregion

        #endregion

        #endregion

        #endregion

        #region WPRad

        private int wpRad = 5;

        public IntegerChangeHandler wpRadChange;

        #region SetWPRad

        #region WPRad 接口函数
        private delegate void SetWPRadInThread(int wpRad);
        public void SetWPRadHandle(int wpRad)
        {
            if (this.InvokeRequired)
            {
                SetWPRadInThread inThread = new SetWPRadInThread(SetWPRadHandle);
                this.Invoke(inThread, new object[] { wpRad });
            }
            else
            {
                StopSendDataChange();
                SetWPRad(wpRad);
                StartSendDataChange();
            }
        }
        #endregion

        #region WPRad 入口函数
        private void SetWPRad(int rad)
        {
            wpRad = rad;
            if (!isSendDataChange)
                wpRadChange?.Invoke(wpRad);
        }
        #endregion

        #endregion

        #endregion

        #region LoiterRad

        private int loiterRad = 30;

        public IntegerChangeHandler LoiterRadChange;

        #region SetLoiterRad

        #region LoiterRad 接口函数
        private delegate void SetLoiterRadInThread(int alt);

        public void SetLoiterRadHandle(int alt)
        {
            if (this.InvokeRequired)
            {
                SetLoiterRadInThread inThread = new SetLoiterRadInThread(SetLoiterRadHandle);
                this.Invoke(inThread, new object[] { alt });
            }
            else
            {
                StopSendDataChange();
                SetLoiterRad(alt);
                StartSendDataChange();
            }
        }
        #endregion

        #region LoiterRad 入口函数

        private void SetLoiterRad(int alt)
        {
            loiterRad = alt;
            if (IsAllowSendDataChange())
                LoiterRadChange?.Invoke(loiterRad);
        }
        #endregion

        #endregion

        #endregion

        #endregion

        #region 标记

        #region DrawPolygon 标记
        private static object polygonLock = new object();
        private bool addPolygonMode;

        #region 访问器
        public bool IsDrawPolygongridMode
        {
            get { return addPolygonMode; }
            set
            {
                lock (polygonLock)
                {
                    addPolygonMode = value;
                    if (value)
                    {
                        addWPMode = false;
                        addPolygonMode = true;
                        DrawPolygonHandle?.Invoke();
                    }
                    else
                    {
                        addPolygonMode = false;
                        LeaveDrawPolygonHandle?.Invoke();
                    }
                }
            }
        }
        #endregion

        #region 对外接口
        public void LeavePolygon()
        {
            IsDrawPolygongridMode = false;
        }

        public void DrawPolygon()
        {
            IsDrawPolygongridMode = true;
        }
        #endregion

        public delegateHandler LeaveDrawPolygonHandle;
        public delegateHandler DrawPolygonHandle;

        #endregion

        #region DrawWP 标记
        private static object wpLock = new object();
        private bool addWPMode;

        #region 访问器
        public bool IsDrawWPMode
        {
            get { return addWPMode; }
            set
            {
                lock (wpLock)
                {
                    if (value)
                    {
                        addWPMode = true;
                        addPolygonMode = false;
                        DrawWPHandle?.Invoke();
                    }
                    else
                    {
                        addWPMode = false;
                        LeaveDrawWPHandle?.Invoke();
                    }
                }
            }
        }
        #endregion

        #region 对外接口
        public void DrawWP()
        {
            IsDrawWPMode = true;
        }

        public void LeaveWP()
        {
            IsDrawWPMode = false;
        }
        #endregion

        public delegateHandler LeaveDrawWPHandle;
        public delegateHandler DrawWPHandle;

        #endregion

        #region quickadd 标记（添加maker时，不会触发重绘）
        private bool quickadd = false;
        private bool isWPChange = false;
        private bool isPolygonChange = false;

        #region 接口函数
        public void EnterQuickADD()
        {
            quickadd = true;
        }

        public void LeaveQuickADD()
        {
            quickadd = false;
            if (isWPChange)
            {
                writeKML();
            }
            if (isPolygonChange)
            {
                redrawPolygonSurvey();
            }
        }

        #endregion
        #endregion

        #region NotTriggerDelegate

        private bool isSendDataChange = true;

        #region 接口函数

        public void StopSendDataChange()
        {
            isSendDataChange = false;
        }


        public void StartSendDataChange()
        {
            isSendDataChange = true;
        }

        #endregion

        #region 判断函数
        private bool IsAllowSendDataChange()
        {
            return isSendDataChange;
        }
        #endregion

        #endregion

        #region SplineMode
        private bool splineMode = false;

        #region SetSplineMode
        public void SetSplinMode(bool mode)
        {
            splineMode = mode;
        }
        #endregion

        #endregion

        #endregion

        #region MainMap控件

        #region Marker MidLine
        private void OnMidLine_Click()
        {
            int pnt2 = 0;
            var midline = CurrentMidLine.Tag as midline;
            // var pnt1 = int.Parse(midline.now.Tag);


            if (IsDrawPolygongridMode)
            {
                if (midline.next != null)
                {
                    //点击到多边形中线
                    var idx = drawnpolygon.Points.IndexOf(midline.next);

                    InsertPolyPoint(idx, CurrentMidLine.Position.Lat, CurrentMidLine.Position.Lng);
                }
            }
            else if (IsDrawWPMode)
            {
                if (midline.next != null)
                {
                    if (int.TryParse(midline.next.Tag, out pnt2))
                    {
                        //点击到航点中线
                        InsertWPPoint(pnt2, CurrentMidLine.Position.Lat, CurrentMidLine.Position.Lng, -1);
                    }
                }
            }

            CurrentMidLine = null;

            return;
        }
        #endregion

        #endregion

        #region 重绘函数

        #region 刷新Polygon显示
        public void redrawPolygonSurvey()
        {
            var list = CustomData.WP.WPGlobalData.instance.GetPolyList();
            if (quickadd)
                return;
            drawnpolygon.Points.Clear();
            drawnpolygonsoverlay.Clear();

            int tag = 0;
            list.ForEach(x =>
            {
                drawnpolygon.Points.Add(x.ToPoint());
                if (IsDrawPolygongridMode)
                {
                    Addpolygonmarkergrid(tag.ToString(), x.Lng, x.Lat, 0);
                }
                tag++;
            });

            drawnpolygonsoverlay.Polygons.Add(drawnpolygon);
            MainMap.UpdatePolygonLocalPosition(drawnpolygon);

            if (IsDrawPolygongridMode && drawnpolygon.Points.Count > 0)
            {
                foreach (var pointLatLngAlt in drawnpolygon.Points.CloseLoop().PrevNowNext())
                {
                    var now = pointLatLngAlt.Item2;
                    var next = pointLatLngAlt.Item3;

                    if (now == null || next == null)
                        continue;

                    var mid = new PointLatLngAlt((now.Lat + next.Lat) / 2, (now.Lng + next.Lng) / 2, 0);

                    var pnt = new GMapMarkerPlus(mid);
                    pnt.Tag = new midline() { now = now, next = next };
                    drawnpolygonsoverlay.Markers.Add(pnt);
                }
            }

        }
        #endregion

        #region 刷新WPList显示
        /// <summary>
        /// used to write a KML, update the Map view polygon, and update the row headers
        /// </summary>
        public void writeKML()
        {
            // quickadd is for when loading wps from eeprom or file, to prevent slow, loading times
            if (quickadd)
                return;

            if (Disposing)
                return;

            try
            {
                var wpList = CustomData.WP.WPGlobalData.WPListChangeAltFrame(
                    CustomData.WP.WPGlobalData.WPListRemoveHome(CustomData.WP.WPGlobalData.instance.GetWPList()), 
                    CustomData.EnumCollect.AltFrame.Absolute);

                List<PointLatLngAlt> commands = new List<PointLatLngAlt>();

                foreach (var wp in wpList)
                {
                    if (wp.Command == CustomData.WP.WPCommands.HomeCommand)
                        continue;
                    else /*if (CustomData.WP.WPCommands.CoordsWPCommands.Contains(wp.Command))*/
                        commands.Add(wp.ToWGS84());
                }

                #region Home
                VPS.CustomData.WP.VPSPosition home = CustomData.WP.WPGlobalData.instance.GetHomePosition();
                if (home == null)
                {
                    home = new VPS.CustomData.WP.VPSPosition();
                    home.Command = CustomData.WP.WPCommands.HomeCommand;
                    home.AltMode = CustomData.EnumCollect.AltFrame.Terrain;
                }

                PointLatLngAlt homePosition = CustomData.WP.WPGlobalData.WPChangeAltFrame(
                    home,
                    CustomData.WP.WPGlobalData.GetBaseAlt(wpList),
                    CustomData.EnumCollect.AltFrame.Absolute).ToWGS84();
                #endregion

                #region CreateWPOverlay
                overlay = new WPOverlay();
                overlay.overlay.Id = "WPOverlay";

                try
                {
                    if (wpRad <= 0) wpRad = 5;
                    if (loiterRad <= 0) loiterRad = 30;

                    overlay.CreateOverlay(
                        homePosition,
                        commands,
                        wpRad / CurrentState.multiplieralt,
                        loiterRad / CurrentState.multiplieralt);

                }
                catch (FormatException ex)
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show(Strings.InvalidNumberEntered + "\n" + "WP Radius or Loiter Radius",
                        Strings.ERROR);
                }
                #endregion

                #region Set WPOverlay State
                foreach (var marker in overlay.overlay.Markers)
                {
                    try
                    {
                        if (marker is GMapMarkerWP)
                        {
                            if (int.TryParse(((GMapMarkerWP)marker).Tag.ToString(), out int no))
                            {
                                if (wpMarkersGroup.Contains(no))
                                {
                                    ((GMapMarkerWP)marker).Selected = true;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
                #endregion

                MainMap.HoldInvalidation = true;

                var existing = MainMap.Overlays.Where(a => a.Id == overlay.overlay.Id).ToList();
                foreach (var b in existing)
                {
                    MainMap.Overlays.Remove(b);
                }

                MainMap.Overlays.Add(overlay.overlay);

                overlay.overlay.ForceUpdate();

                pointlist = overlay.pointlist;

                if (IsDrawWPMode && pointlist.Count > 0) 
                {
                    foreach (var pointLatLngAlt in pointlist.PrevNowNext())
                    {
                        var prev = pointLatLngAlt.Item1;
                        var now = pointLatLngAlt.Item2;
                        var next = pointLatLngAlt.Item3;

                        if (now == null || next == null)
                            continue;

                        var mid = new PointLatLngAlt((now.Lat + next.Lat) / 2, (now.Lng + next.Lng) / 2,
                            (now.Alt + next.Alt) / 2);

                        var pnt = new GMapMarkerPlus(mid);
                        pnt.Tag = new midline() { now = now, next = next };
                        overlay.overlay.Markers.Add(pnt);
                    }
                }

                MainMap.RefreshInThread();


            }
            catch (FormatException ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show(Strings.InvalidNumberEntered + "\n" + ex.Message, Strings.ERROR);
            }
            finally
            {
            }
        }
        #endregion

        #endregion

        #region 主要功能

        #region SaveWP

        #region SaveWP 对外接口
        public void SaveWPFile()
        {
            savewaypoints();
        }
        #endregion

        #region SaveWP 入口函数
        /// <summary>
        /// Saves a waypoint writer file
        /// </summary>
        private void savewaypoints()
        {
            using (VPS.Controls.LoadAndSave.SaveWP save = new VPS.Controls.LoadAndSave.SaveWP())
            {
                var result = save.ShowDialog();

                if (result == DialogResult.OK)
                {
                    save.SaveWaypoint();
                }
            }
        }
        #endregion

        #region SaveWP From

        #region SaveWP KML
        private void saveWaypointsKML(string file)
        {
            var wpList = CustomData.WP.WPGlobalData.WPListChangeAltFrame(
                    CustomData.WP.WPGlobalData.instance.GetWPList(), CustomData.EnumCollect.AltFrame.Terrain);
            var home = wpList[0];
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

                if (home.AltMode == CustomData.EnumCollect.AltFrame.Absolute)
                    w.WriteString("absolute");
                else if (home.AltMode == CustomData.EnumCollect.AltFrame.Terrain)
                    w.WriteString("relativeToGround");
                else
                    w.WriteString("relativeToGround");

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
                if (CustomData.WP.WPCommands.CoordsWPCommands.Contains(wpList[i].Command))
                    isVisbility = true;
                w.WriteStartElement("Placemark");

                // Write Point element
                w.WriteStartElement("name");
                if (isVisbility)
                    w.WriteString(wpList[index].Command + " " + (index).ToString());
                else
                    w.WriteString(wpList[index].Command);
                w.WriteEndElement();//name

                w.WriteStartElement("visibility");
                w.WriteString(isVisbility.ToString());
                //if (isVisbility)
                //    w.WriteString("true");
                //else
                //    w.WriteString("false");
                w.WriteEndElement();//visibility

                w.WriteStartElement("description");
                w.WriteString(wpList[index].Command);
                w.WriteEndElement();//description

                if (isVisbility)
                {
                    w.WriteStartElement("styleUrl");
                    w.WriteString("#waypointStyle");
                    w.WriteEndElement();//styleUrl
                }

                //w.WriteStartElement("ExtendedData", "www.dji.com");
                //w.WriteStartElement("param1");
                //w.WriteString(wpList[i].Param1.ToString());
                //w.WriteEndElement();//param1
                //w.WriteStartElement("param2");
                //w.WriteString(wpList[i].Param2.ToString());
                //w.WriteEndElement();//param2
                //w.WriteStartElement("param3");
                //w.WriteString(wpList[i].Param3.ToString());
                //w.WriteEndElement();//param3
                //w.WriteStartElement("param4");
                //w.WriteString(wpList[i].Param4.ToString());
                //w.WriteEndElement();//param4
                //w.WriteEndElement();//ExtendedData

                if (isVisbility)
                {
                    w.WriteStartElement("Point");
                    w.WriteStartElement("altitudeMode");

                    if (wpList[i].AltMode == CustomData.EnumCollect.AltFrame.Absolute)
                        w.WriteString("absolute");
                    else if (wpList[i].AltMode == CustomData.EnumCollect.AltFrame.Terrain)
                        w.WriteString("relativeToGround");
                    else
                        w.WriteString("relativeToGround");

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
                if (altFrame.ToString() == CustomData.EnumCollect.AltFrame.Absolute)
                    wpList = CustomData.WP.WPGlobalData.WPListChangeAltFrame(
                        wpList, CustomData.EnumCollect.AltFrame.Absolute);
                else if (altFrame.ToString() == CustomData.EnumCollect.AltFrame.Terrain)
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

                if (altFrame.ToString() == CustomData.EnumCollect.AltFrame.Absolute)
                    w.WriteString("absolute");
                else if (altFrame.ToString() == CustomData.EnumCollect.AltFrame.Terrain)
                    w.WriteString("relativeToGround");
                else
                    w.WriteString("relativeToGround");

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
        #endregion

        #endregion

        #endregion

        #region LoadWP

        #region LoadWP 对外接口
        public void LoadWPFile()
        {
            loadwaypoints();
        }
        #endregion

        #region LoadWp 入口函数
        /// <summary>
        /// Saves a waypoint writer file
        /// </summary>
        private void loadwaypoints()
        {
            using (VPS.Controls.LoadAndSave.LoadWP load = new VPS.Controls.LoadAndSave.LoadWP())
            {
                var result = load.ShowDialog();

                if (result == DialogResult.OK)
                {
                    VPS.CustomData.WP.WPGlobalData.instance.SetWPListHandle(load.GetWPList());
                }
            }
        }

        #endregion

        #region LoadWP From

        #region LoadWP DefaultWPFile KML
        private void LoadWaypointsKML(string file, bool append)
        {
            // Create the file and writer.
            if (!System.IO.File.Exists(file))
                return;
            try
            {
                
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(file);
                XmlNamespaceManager nsMgr = new XmlNamespaceManager(xmlDoc.NameTable);
                foreach (XmlNode kml in xmlDoc.ChildNodes)
                {
                    if (kml.Name.Equals("kml"))
                    {
                        nsMgr.AddNamespace("ns", kml.NamespaceURI);

                        foreach (XmlNode doc in kml.ChildNodes)
                        {
                            if (doc.Name.Equals("Document"))
                            {
                                nsMgr.AddNamespace("ns1", doc.NamespaceURI);

                                XmlNode folder = doc.SelectSingleNode(@"./ns1:Folder", nsMgr);

                                var wpList = new List<CustomData.WP.VPSPosition>();
                                foreach (XmlNode point in folder.ChildNodes)
                                {
                                    if (point.Name == "Placemark")
                                    {
                                        string cmd = CustomData.WP.WPCommands.DefaultWPCommand;
                                        string altitudeMode = CustomData.EnumCollect.AltFrame.Terrain;
                                        double x = 0, y = 0, z = 0;
                                        double p1 = 0, p2 = 0, p3 = 0, p4 = 0;
                                        //selectedrow = Commands.Rows.Add();
                                        foreach (XmlNode info in point.ChildNodes)
                                        {
                                            switch (info.Name)
                                            {
                                                case "description":
                                                    //cmd = System.Convert.ToInt32(info.SelectSingleNode(@".//@id").Value);
                                                    cmd = info.InnerText;
                                                    break;
                                                case "Point":
                                                    nsMgr.AddNamespace("ns2", info.NamespaceURI);
                                                    var smode = info.SelectSingleNode(@"./ns2:altitudeMode", nsMgr);
                                                    if (smode != null)
                                                    {
                                                        if (smode.InnerText == "relativeToGround")
                                                            altitudeMode = CustomData.EnumCollect.AltFrame.Terrain;
                                                        else if (smode.InnerText == "absolute")
                                                            altitudeMode = CustomData.EnumCollect.AltFrame.Absolute;
                                                        else if (smode.InnerText == "clampedToGround")
                                                            altitudeMode = CustomData.EnumCollect.AltFrame.Terrain;
                                                        else
                                                            altitudeMode = CustomData.EnumCollect.AltFrame.Terrain;
                                                    }
                                                    else
                                                    {
                                                        altitudeMode = CustomData.EnumCollect.AltFrame.Terrain;
                                                    }
                                                    var sWGS84 = info.SelectSingleNode(@"./ns2:coordinates", nsMgr);
                                                    if (sWGS84 != null)
                                                    {
                                                        string WGS84 = sWGS84.InnerText;
                                                        var splitWGS84 = WGS84.Split(',');
                                                        x = System.Convert.ToDouble(splitWGS84[0]);
                                                        y = System.Convert.ToDouble(splitWGS84[1]);
                                                        z = System.Convert.ToDouble(splitWGS84[2]);
                                                    }
                                                    break;

                                                case "ExtendedData":
                                                    nsMgr.AddNamespace("ns3", info.NamespaceURI);
                                                    var sp1 = info.SelectSingleNode(@".//ns3:param1", nsMgr);
                                                    if (sp1 != null)
                                                        p1 = System.Convert.ToDouble(sp1.InnerText);
                                                    else
                                                        p1 = 0;
                                                    var sp2 = info.SelectSingleNode(@".//ns3:param2", nsMgr);
                                                    if (sp2 != null)
                                                        p2 = System.Convert.ToDouble(sp2.InnerText);
                                                    else
                                                        p2 = 0;
                                                    var sp3 = info.SelectSingleNode(@".//ns3:param3", nsMgr);
                                                    if (sp3 != null)
                                                        p3 = System.Convert.ToDouble(sp3.InnerText);
                                                    else
                                                        p3 = 0;
                                                    var sp4 = info.SelectSingleNode(@".//ns3:param4", nsMgr);
                                                    if (sp4 != null)
                                                        p4 = System.Convert.ToDouble(sp4.InnerText);
                                                    else
                                                        p4 = 0;
                                                    break;


                                            }
                                        }


                                        var wp = new CustomData.WP.VPSPosition();
                                        wp.AltMode = altitudeMode;

                                        wp.Command = cmd;

                                        wp.Alt = z;
                                        wp.Lat = y;
                                        wp.Lng = x;

                                        //wp.Param1 = p1;
                                        //wp.Param2 = p2;
                                        //wp.Param3 = p3;
                                        //wp.Param4 = p4;

                                        wpList.Add(wp);
                                    }
                                }

                                if (append)
                                    CustomData.WP.WPGlobalData.instance.AppendWPListHandle(wpList);
                                else
                                    CustomData.WP.WPGlobalData.instance.SetWPListHandle(wpList);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            finally
            {
                ZoomToCenterWP();
            }

        }
        #endregion

        #region LoadWP SHP
        private void LoadSHPFile(string file)
        {
            ProjectionInfo pStart = new ProjectionInfo();
            ProjectionInfo pESRIEnd = KnownCoordinateSystems.Geographic.World.WGS1984;
            bool reproject = false;

            if (File.Exists(file))
            {

                try
                {
                    string prjfile = Path.GetDirectoryName(file) + Path.DirectorySeparatorChar +
                                     Path.GetFileNameWithoutExtension(file) + ".prj";
                    if (File.Exists(prjfile))
                    {
                        using (
                            StreamReader re =
                                File.OpenText(Path.GetDirectoryName(file) + Path.DirectorySeparatorChar +
                                              Path.GetFileNameWithoutExtension(file) + ".prj"))
                        {
                            pStart.ParseEsriString(re.ReadLine());

                            reproject = true;
                        }
                    }

                    IFeatureSet fs = FeatureSet.Open(file);

                    fs.FillAttributes();

                    int rows = fs.NumRows();

                    DataTable dtOriginal = fs.DataTable;
                    for (int row = 0; row < dtOriginal.Rows.Count; row++)
                    {
                        object[] original = dtOriginal.Rows[row].ItemArray;
                    }

                    foreach (DataColumn col in dtOriginal.Columns)
                    {
                        Console.WriteLine(col.ColumnName + " " + col.DataType);
                    }

                    bool dosort = false;

                    var wplist = new List<CustomData.WP.VPSPosition>();

                    for (int row = 0; row < dtOriginal.Rows.Count; row++)
                    {
                        double x = fs.Vertex[row * 2];
                        double y = fs.Vertex[row * 2 + 1];

                        double z = -1;
                        float wp = 0;

                        try
                        {
                            if (dtOriginal.Columns.Contains("ELEVATION"))
                                z = (float)Convert.ChangeType(dtOriginal.Rows[row]["ELEVATION"], TypeCode.Single);
                        }
                        catch (Exception ex)
                        {
                            log.Error(ex);
                        }

                        try
                        {
                            if (z == -1 && dtOriginal.Columns.Contains("alt"))
                                z = (float)Convert.ChangeType(dtOriginal.Rows[row]["alt"], TypeCode.Single);
                        }
                        catch (Exception ex)
                        {
                            log.Error(ex);
                        }

                        try
                        {
                            if (z == -1)
                                z = fs.Z[row];
                        }
                        catch (Exception ex)
                        {
                            log.Error(ex);
                        }


                        try
                        {
                            if (dtOriginal.Columns.Contains("wp"))
                            {
                                wp = (float)Convert.ChangeType(dtOriginal.Rows[row]["wp"], TypeCode.Single);
                                dosort = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            log.Error(ex);
                        }

                        if (reproject)
                        {
                            double[] xyarray = { x, y };
                            double[] zarray = { z };

                            Reproject.ReprojectPoints(xyarray, zarray, pStart, pESRIEnd, 0, 1);


                            x = xyarray[0];
                            y = xyarray[1];
                            z = zarray[0];
                        }

                        var pnt = new CustomData.WP.VPSPosition(y, x, z);
                        pnt.Command = wp.ToString();

                        wplist.Add(pnt);
                    }

                    if (dosort)
                        wplist.Sort();

                    for (int index = 0; index < wplist.Count; index++)
                    {
                        wplist[index].Command = MAVLink.MAV_CMD.WAYPOINT.ToString();
                        //wplist[index].Param1 = 0;
                        //wplist[index].Param2 = 0;
                        //wplist[index].Param3 = 0;
                        //wplist[index].Param4 = 0;
                        
                    }
                    CustomData.WP.WPGlobalData.instance.SetWPListHandle(wplist);
                }
                catch { }
                finally
                {
                    ZoomToCenterWP();
                }
            }
        }
        #endregion

        #region LoadWP Google Earth KML
        private void LoadKMLFile(string file)
        {
            if (file != "")
            {
                try
                {
                    string kml = "";
                    string tempdir = "";
                    if (file.ToLower().EndsWith("kmz"))
                    {
                        ZipFile input = new ZipFile(file);

                        tempdir = Path.GetTempPath() + Path.DirectorySeparatorChar + Path.GetRandomFileName();
                        input.ExtractAll(tempdir, ExtractExistingFileAction.OverwriteSilently);

                        string[] kmls = Directory.GetFiles(tempdir, "*.kml");

                        if (kmls.Length > 0)
                        {
                            file = kmls[0];

                            input.Dispose();
                        }
                        else
                        {
                            input.Dispose();
                            return;
                        }
                    }

                    var sr = new StreamReader(File.OpenRead(file));
                    kml = sr.ReadToEnd();
                    sr.Close();

                    // cleanup after out
                    if (tempdir != "")
                        Directory.Delete(tempdir, true);

                    kml = kml.Replace("<Snippet/>", "");

                    var parser = new Parser();

                    parser.ElementAdded += processKMLMission;
                    parser.ParseString(kml, false);
                }
                catch (Exception ex)
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show(Strings.Bad_KML_File + ex);
                }
            }
        }

        private void processKMLMission(object sender, ElementEventArgs e)
        {
            CustomData.WP.WPGlobalData.instance.ExecuteWPStartSetting();
            CustomData.WP.WPGlobalData.instance.BegionQuick();
            try
            {
                Element element = e.Element;
                try
                {
                    //  log.Info(Element.ToString() + " " + Element.Parent);
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                }

                Document doc = element as Document;
                Placemark pm = element as Placemark;
                Folder folder = element as Folder;
                Polygon polygon = element as Polygon;
                LineString ls = element as LineString;

                if (doc != null)
                {
                    foreach (var feat in doc.Features)
                    {
                        //Console.WriteLine("feat " + feat.GetType());
                        //processKML((Element)feat);
                    }
                }
                else if (folder != null)
                {
                    foreach (Feature feat in folder.Features)
                    {
                        //Console.WriteLine("feat "+feat.GetType());
                        //processKML(feat);
                    }
                }
                else if (pm != null)
                {
                    //if (pm.Geometry is SharpKml.Dom.Point)
                    //{
                    //    var point = ((SharpKml.Dom.Point)pm.Geometry).Coordinate;
                    //    POI.POIAdd(new PointLatLngAlt(point.Latitude, point.Longitude), pm.Name);
                    //}
                }
                else if (polygon != null)
                {
                }
                else if (ls != null)
                {
                    foreach (var loc in ls.Coordinates)
                    {
                        AddWPPoint(loc.Latitude, loc.Longitude, (int)loc.Altitude);
                    }
                }
            }
            catch { }
            finally
            {
                CustomData.WP.WPGlobalData.instance.EndQuick();
                CustomData.WP.WPGlobalData.instance.ExecuteWPOverSetting();
                ZoomToCenterWP();
            }
        }
        #endregion

        #endregion

        #endregion

        #region SavePolygon

        #region SavePolygon 对外接口
        public void SavePolygonFile()
        {
            savepolygons();
        }
        #endregion

        #region SavePolygon 入口函数
        /// <summary>
        /// Saves a waypoint writer file
        /// </summary>
        private void savepolygons()
        {
            using (VPS.Controls.LoadAndSave.SavePolygon save = new VPS.Controls.LoadAndSave.SavePolygon())
            {
                var result = save.ShowDialog();

                if (result == DialogResult.OK)
                {
                    save.SavePolygonPoints();
                }
            }
            
            //if (CustomData.WP.WPGlobalData.instance.GetPolyCount() <= 0)
            //{
            //    return;
            //}

            //using (SaveFileDialog sf = new SaveFileDialog())
            //{
            //    sf.Filter = "Polygon (*.poly)|*.poly";
            //    var result = sf.ShowDialog();
            //    if (result == DialogResult.OK && sf.FileName != "")
            //    {
            //        switch (sf.FilterIndex)
            //        {
            //            case 1:
            //                savePolygons(sf.FileName);
            //                break;
            //        }
            //    }
            //}
        }
        #endregion

        #region SavePolygon To

        #region SavePolygon Poly
        private void savePolygons(string file)
        {
            try
            {
                StreamWriter sw = new StreamWriter(file);

                sw.WriteLine("#saved by Mission Planner " + Application.ProductVersion);

                if (CustomData.WP.WPGlobalData.instance.GetPolyCount() > 0)
                {
                    foreach (var pll in CustomData.WP.WPGlobalData.instance.GetPolyList())
                    {
                        sw.WriteLine(pll.Lat.ToString(CultureInfo.InvariantCulture) + " " + pll.Lng.ToString(CultureInfo.InvariantCulture));
                    }

                    var pll2 = CustomData.WP.WPGlobalData.instance.GetPolyPoint(0);

                    sw.WriteLine(pll2.Lat.ToString(CultureInfo.InvariantCulture) + " " + pll2.Lng.ToString(CultureInfo.InvariantCulture));
                }

                sw.Close();
            }
            catch
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Failed to write fence file");
            }
        }
        #endregion

        #endregion

        #endregion

        #region LoadPolygon

        #region LoadPolygon 对外接口
        public void LoadPolygonFile()
        {
            loadpolygons();
        }
        #endregion

        #region LoadPolygon 入口函数
        /// <summary>
        /// Saves a waypoint writer file
        /// </summary>
        private void loadpolygons()
        {
            using (VPS.Controls.LoadAndSave.LoadPolygon load = new VPS.Controls.LoadAndSave.LoadPolygon())
            {
                var result = load.ShowDialog();

                if (result == DialogResult.OK)
                {
                    VPS.CustomData.WP.WPGlobalData.instance.SetPolyListHandle(load.GetWPList());
                }
            }
        }
        #endregion

        #region LoadPolygon From

        #region LoadPolygon DefaultPolygonFile Poly
        private void LoadPolygonsPoly(string file)
        {
            StreamReader sr = new StreamReader(file);

            var poly = new List<CustomData.WP.VPSPosition>();

            int a = 0;

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                if (line.StartsWith("#"))
                {
                }
                else
                {
                    string[] items = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                    if (items.Length < 2)
                        continue;

                    poly.Add(new CustomData.WP.VPSPosition(
                        double.Parse(items[0], CultureInfo.InvariantCulture),
                        double.Parse(items[1], CultureInfo.InvariantCulture)));

                    a++;
                }
            }

            // remove loop close
            if (poly.Count > 1 &&
                poly[0] == poly[poly.Count - 1])
            {
                poly.RemoveAt(poly.Count - 1);
            }

            CustomData.WP.WPGlobalData.instance.SetPolyListHandle(poly);

            ZoomToCenterPolygon();
        }
        #endregion

        #region LoadPolygon SHP
        private void LoadPolygonSHP(string file)
        {
            ProjectionInfo pStart = new ProjectionInfo();
            ProjectionInfo pESRIEnd = KnownCoordinateSystems.Geographic.World.WGS1984;
            bool reproject = false;
            // Poly Clear
            var poly = new List<CustomData.WP.VPSPosition>();

            if (File.Exists(file))
            {
                string prjfile = Path.GetDirectoryName(file) + Path.DirectorySeparatorChar +
                                 Path.GetFileNameWithoutExtension(file) + ".prj";
                if (File.Exists(prjfile))
                {
                    using (
                        StreamReader re =
                            File.OpenText(Path.GetDirectoryName(file) + Path.DirectorySeparatorChar +
                                          Path.GetFileNameWithoutExtension(file) + ".prj"))
                    {
                        pStart.ParseEsriString(re.ReadLine());
                        reproject = true;
                    }
                }
                try
                {
                    IFeatureSet fs = FeatureSet.Open(file);
                    fs.FillAttributes();
                    int rows = fs.NumRows();
                    DataTable dtOriginal = fs.DataTable;
                    for (int row = 0; row < dtOriginal.Rows.Count; row++)
                    {
                        object[] original = dtOriginal.Rows[row].ItemArray;
                    }
                    string path = Path.GetDirectoryName(file);
                    foreach (var feature in fs.Features)
                    {
                        foreach (var point in feature.Coordinates)
                        {
                            if (reproject)
                            {
                                double[] xyarray = { point.X, point.Y };
                                double[] zarray = { point.Z };
                                Reproject.ReprojectPoints(xyarray, zarray, pStart, pESRIEnd, 0, 1);
                                point.X = xyarray[0];
                                point.Y = xyarray[1];
                                point.Z = zarray[0];
                            }
                            poly.Add(new CustomData.WP.VPSPosition(point.Y, point.X));
                        }
                        // remove loop close
                        if (poly.Count > 1 &&
                            poly[0] == poly[poly.Count - 1])
                        {
                            poly.RemoveAt(poly.Count - 1);
                        }

                        CustomData.WP.WPGlobalData.instance.SetPolyListHandle(poly);

                        ZoomToCenterPolygon();
                    }
                }
                catch (Exception ex)
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show(Strings.ERROR + "\n" + ex, Strings.ERROR);
                }
            }
        }
        #endregion

        #endregion

        #endregion

        #endregion

        #region 重要数据

        #region 航点

        #region 航点变化响应函数
        public void WPChangeHandle()
        {
            writeKML();
        }
        #endregion

        #region 辅助函数

        #region GeneralWP
        private Locationwp GeneralWP(CustomData.WP.VPSPosition wp)
        {
            Locationwp temp = new Locationwp();

            if (wp.Command.Contains("UNKNOWN"))
            {
                temp.id = (ushort)16;
            }
            else
            {
                if (Enum.TryParse(wp.Command, out MAVLink.MAV_CMD id))
                {
                    temp.id = (ushort)id;
                }
                else
                {
                    temp.id = (ushort)16;
                }
            }
            {
                temp.alt = (float)wp.Alt / CurrentState.multiplieralt;
                temp.lat = wp.Lat;
                temp.lng = wp.Lng;

                temp.frame = (byte)(short)CustomData.EnumCollect.AltFrame.GetAltFrame(wp.AltMode);

                //temp.p1 = (float)wp.Param1;
                //temp.p2 = (float)wp.Param2;
                //temp.p3 = (float)wp.Param3;
                //temp.p4 = (float)wp.Param4;
            }
            return temp;
        }
        #endregion

        #region GeneralWPPoint
        private PointLatLngAlt GeneralWPPoint(Locationwp wp)
        {
            PointLatLngAlt temp = new PointLatLngAlt();

            temp.Tag = ((MAVLink.MAV_CMD)wp.id).ToString();

            {
                temp.Alt = wp.alt;
                temp.Lat = wp.lat;
                temp.Lng = wp.lng;

                temp.Tag2 = CustomData.EnumCollect.AltFrame.GetAltFrame(
                    (CustomData.EnumCollect.AltFrame.Mode)wp.frame);

                temp.Lat = wp.p1;
                temp.Lng = wp.p2;
                temp.Alt = wp.p3;
                temp.Tag2 = wp.p4.ToString();

            }
            return temp;
        }
        #endregion

        #endregion

        #region wpPoint

        #region GeneralWPPoint
        private VPS.CustomData.WP.VPSPosition GeneralWPPoint(double lat, double lng, int alt = -1)
        {
            if (alt == -1)
            {
                alt = GetDefaultAlt();
            }

            var wp = new VPS.CustomData.WP.VPSPosition(lat, lng, alt);
            if (splineMode)
            {
                wp.Command = CustomData.WP.WPCommands.SplineWPCommand;
                wp.AltMode = "Relative";
            }
            else
            {
                wp.Command = CustomData.WP.WPCommands.DefaultWPCommand;
                wp.AltMode = "Relative";
            }
            return wp;
        }

        #endregion

        #region 添加航点
        private int AddWPPoint(double lat, double lng, int alt)
        {
            var wp = GeneralWPPoint(lat, lng, alt);
            return CustomData.WP.WPGlobalData.instance.AddWPHandle(wp);
        }

        #endregion

        #region 插入航点
        private void InsertWPPoint(int index, double lat, double lng, int alt = -1)
        {
            var wp = GeneralWPPoint(lat, lng, alt);

            CustomData.WP.WPGlobalData.instance.InsertWPHandle(index, wp);
        }

        #endregion

        #region 修改航点
        private void SetWPPoint(int index, double lat, double lng, int alt = -1)
        {
            if (alt == -1)
            {
                var wp = CustomData.WP.WPGlobalData.instance.GetWPPoint(index);
                wp.Lat = lat;
                wp.Lng = lng;

                CustomData.WP.WPGlobalData.instance.SetWPHandle(index, wp);
            }
            else
            {
                var wp = GeneralWPPoint(lat, lng, alt);
                CustomData.WP.WPGlobalData.instance.SetWPHandle(index, wp);
            }
        }
        #endregion

        #region 删除航点
        public void DeleteWP(int index)
        {
            if (index >= 0 && index < CustomData.WP.WPGlobalData.instance.GetWPCount())
            {
                CustomData.WP.WPGlobalData.instance.DeleteWPHandle(index);
            }
        }
        #endregion

        #endregion

        #endregion

        #endregion

        #region 区域点

        #region 区域点变化响应函数
        public void PolyChangeHandle()
        {
            redrawPolygonSurvey();
        }
        #endregion

        #region polyPoint

        #region 添加区域点
        public void AddPolyPoint(double lat, double lng)
        {
            var point = new CustomData.WP.VPSPosition(lat, lng);
            CustomData.WP.WPGlobalData.instance.AddPolyHandle(point);
        }
        #endregion

        #region 插入区域点
        public void InsertPolyPoint(int index,double lat, double lng)
        {
            var point = new CustomData.WP.VPSPosition(lat, lng);
            CustomData.WP.WPGlobalData.instance.InsertPolyHandle(index, point);
        }
        #endregion

        #region 修改区域点
        public void SetPolyPoint(int index, double lat, double lng)
        {
            var point = new CustomData.WP.VPSPosition(lat, lng);
            CustomData.WP.WPGlobalData.instance.MovePolyHandle(index, point);
        }
        #endregion

        #region 删除区域点
        public void DeletePolygon(int index)
        {
            if (index >= 0 && index < CustomData.WP.WPGlobalData.instance.GetPolyCount())
            {
                CustomData.WP.WPGlobalData.instance.DeletePolyHandle(index);
            }
        }
        #endregion

        #endregion

        #endregion

        #region WP选中组

        #region 删除选中组
        public void DeleteCurrentWP()
        {
            CustomData.WP.WPGlobalData.instance.ExecuteWPStartSetting();
            CustomData.WP.WPGlobalData.instance.BegionQuick();
            if (wpMarkersGroup.Count > 0)
            {
                for (int a = CustomData.WP.WPGlobalData.instance.GetWPCount() - 1; a >= 0; a--)
                {
                    try
                    {
                        if (wpMarkersGroup.Contains(a))
                            CustomData.WP.WPGlobalData.instance.DeleteWPHandle(a);// home is none
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                        DevComponents.DotNetBar.MessageBoxEx.Show("error selecting wp, please try again.");
                    }
                }
                wpMarkersGroupClear();
            }
            CustomData.WP.WPGlobalData.instance.EndQuick();
            if (currentMarker != null)
                CurentRectMarker = null;
            CustomData.WP.WPGlobalData.instance.ExecuteWPOverSetting();
        }
        #endregion

        #endregion

        #region Poly选中组

        #region 删除选中组
        public void DeleteCurrentPolygon()
        {
            CustomData.WP.WPGlobalData.instance.BegionQuick();
            if (polyMarkersGroup.Count > 0)
            {
                for (int a = CustomData.WP.WPGlobalData.instance.GetPolyCount() - 1; a >= 0; a--)
                {
                    try
                    {
                        if (polyMarkersGroup.Contains(a))
                        {
                            CustomData.WP.WPGlobalData.instance.DeletePolyHandle(a);
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                        DevComponents.DotNetBar.MessageBoxEx.Show("error selecting polygon, please try again.");
                    }
                }
                polygonMarkersGroupClear();
            }
            CustomData.WP.WPGlobalData.instance.EndQuick();
            if (currentMarker != null)
                CurentRectMarker = null;
            CustomData.WP.WPGlobalData.instance.ExecutePolyOverSetting();
        }
        #endregion

        #endregion

        #region 初始位置

        #region 初始位置变化响应函数
        public void HomeChangeHandle()
        {
            writeKML();
        }
        #endregion

        #endregion

        #region 通用委托
        public delegate void PositionChangeHandle(PointLatLngAlt position);
        public delegate void IntegerChangeHandler(int integer);
        public delegate void StringChangeHandle(string str);
        public delegate void delegateHandler();

        #endregion

        #region 快捷键
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // undo
            if (keyData == (Keys.Delete))
            {
                DeleteMarkerToolStripMenuItem_Click(null, null);
                return true;
            }

            if (keyData == (Keys.Control | Keys.Delete))
            {
                DeleteCurrentWP();
                return true;
            }

            if (keyData == (Keys.Alt | Keys.Delete))
            {
                DeleteCurrentPolygon();
                return true;
            }

            if (keyData == (Keys.Alt | Keys.A))
            {
                polygonMarkersGroupAddAll();
                return true;
            }

            if (keyData == (Keys.Control | Keys.A))
            {
                wpMarkersGroupAddAll();
                return true;
            }

            if (keyData == (Keys.Alt | Keys.C))
            {
                polygonMarkersGroupClear();
                return true;
            }

            if (keyData == (Keys.Control | Keys.C))
            {
                wpMarkersGroupClear();
                return true;
            }

            if (keyData == (Keys.Control | Keys.F))
            {
                wpMarkersGroupFirst();
                return true;
            }

            if (keyData == (Keys.Alt | Keys.F))
            {
                polygonMarkersGroupFirst();
                return true;
            }

            if (keyData == (Keys.Control | Keys.PageUp))
            {
                wpMarkersGroupPrev();
                return true;
            }

            if (keyData == (Keys.Control | Keys.PageDown))
            {
                wpMarkersGroupNext();
                return true;
            }

            if (keyData == (Keys.Alt | Keys.PageUp))
            {
                polygonMarkersGroupPrev();
                return true;
            }

            if (keyData == (Keys.Alt | Keys.PageDown))
            {
                polygonMarkersGroupNext();
                return true;
            }

            if (keyData == (Keys.PageUp))
            {
                wpMarkersGroupPrev();
                polygonMarkersGroupPrev();
                return true;
            }

            if (keyData == (Keys.PageDown))
            {
                wpMarkersGroupNext();
                polygonMarkersGroupNext();
                return true;
            }

            if (keyData == (Keys.Alt | Keys.Up) ||
                keyData == (Keys.Alt | Keys.Down) ||
                keyData == (Keys.Alt | Keys.Left) ||
                keyData == (Keys.Alt | Keys.Right))
            {
                if (keyData == (Keys.Alt | Keys.Up))
                {
                    polygonMarkersGroupMoveUp();
                }

                if (keyData == (Keys.Alt | Keys.Down))
                {
                    polygonMarkersGroupMoveDown();
                }

                if (keyData == (Keys.Alt | Keys.Left))
                {
                    polygonMarkersGroupMoveLeft();
                }

                if (keyData == (Keys.Alt | Keys.Right))
                {
                    polygonMarkersGroupMoveRight();
                }
                return true;
            }
            if (keyData == (Keys.Control | Keys.Up) ||
                keyData == (Keys.Control | Keys.Down) ||
                keyData == (Keys.Control | Keys.Left) ||
                keyData == (Keys.Control | Keys.Right))
            {
                if (keyData == (Keys.Control | Keys.Up))
                {
                    wpMarkersGroupMoveUp();
                }

                if (keyData == (Keys.Control | Keys.Down))
                {
                    wpMarkersGroupMoveDown();
                }

                if (keyData == (Keys.Control | Keys.Left))
                {
                    wpMarkersGroupMoveLeft();
                }

                if (keyData == (Keys.Control | Keys.Right))
                {
                    wpMarkersGroupMoveRight();
                }
                return true;
            }

            if (keyData == (Keys.Up) ||
                keyData == (Keys.Down) ||
                keyData == (Keys.Left) ||
                keyData == (Keys.Right))
            {
                if (keyData == (Keys.Up))
                {
                    wpMarkersGroupMoveUp();
                    polygonMarkersGroupMoveUp();
                }
                if (keyData == (Keys.Down))
                {
                    wpMarkersGroupMoveDown();
                    polygonMarkersGroupMoveDown();
                }
                if (keyData == (Keys.Left))
                {
                    wpMarkersGroupMoveLeft();
                    polygonMarkersGroupMoveLeft();
                }

                if (keyData == (Keys.Right))
                {
                    wpMarkersGroupMoveRight();
                    polygonMarkersGroupMoveRight();
                }
                return true;
            }

            if (keyData == (Keys.Control | Keys.Shift | Keys.A))
            {
                return true;
            }

            if (keyData == (Keys.Alt | Keys.Shift | Keys.A))
            {
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        #region 旧版接口
        private List<Locationwp> GetCommandList(List<CustomData.WP.VPSPosition> wpLists)
        {
            List<Locationwp> commands = new List<Locationwp>();

            foreach (var wp in wpLists)
            {
                if (wp.Command == CustomData.WP.WPCommands.HomeCommand)
                    continue;
                else /*if (VPS.WP.WPCommands.CoordsWPCommands.Contains(wp.Tag))*/
                    commands.Add(GeneralWP(wp));
            }

            return commands;
        }
        #endregion
    }
}