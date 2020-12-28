using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VPS.Utilities;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
using GMap.NET;
using VPS.Controls;
using System.Xml;
using VPS.Maps;
using System.Net;
using System.Text.RegularExpressions;
using GMap.NET.MapProviders;
using VPS.Project;
using VPS.CustomData.WP;

namespace VPS.GCSViews
{
    public partial class MapControl_2D : MyUserControl
    {
        #region 中点标记类定义
        public class midline
        {
            public PointLatLngAlt now { get; set; }
            public PointLatLngAlt next { get; set; }

            public midline(PointLatLngAlt now, PointLatLngAlt next)
            {
                this.now = now;
                this.next = next;
            }
        }
        #endregion

        /// <summary>
        /// 操作日志
        /// </summary>
        private static readonly log4net.ILog mLog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// 全局指针
        /// </summary>
        public static MapControl_2D instance { get; set; } = null;
        private VPSProject mProjectInstace { get; set; } = null;

        private void BindingProject(VPSProject project)
        {
            mProjectInstace = project;
        }


        public MapControl_2D()
        {
            InitializeComponent();

            if (instance == null)
                instance = this;
            mGMap = GMapControl;

            //配置地图信息
            //配置地图信息-地图缓存
            GMapControl.CacheLocation = Settings.GetDataDirectory() + "gmapcache" + System.IO.Path.DirectorySeparatorChar;

            GMapControl.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.GMapControl_OnMarkerClick);
            GMapControl.OnMarkerEnter += new GMap.NET.WindowsForms.MarkerEnter(this.GMapControl_OnMarkerEnter);
            GMapControl.OnMarkerLeave += new GMap.NET.WindowsForms.MarkerLeave(this.GMapControl_OnMarkerLeave);
            
            GMapControl.OnTileLoadStart += new GMap.NET.TileLoadStart(this.GMapControl_OnTileLoadStart);
            GMapControl.OnTileLoadComplete += new GMap.NET.TileLoadComplete(this.GMapControl_OnTileLoadComplete);

            GMapControl.OnPositionChanged += new GMap.NET.PositionChanged(this.GMapControl_OnPositionChanged);
            GMapControl.OnMapZoomChanged += new GMap.NET.MapZoomChanged(this.GMapControl_OnMapZoomChanged);
            GMapControl.OnMapTypeChanged += new GMap.NET.MapTypeChanged(this.GMapControl_OnMapTypeChanged);

            GMapControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GMapControl_MouseDown);
            GMapControl.MouseEnter += new System.EventHandler(this.GMapControl_MouseEnter);
            GMapControl.MouseLeave += new System.EventHandler(this.GMapMainHandle_MouseLeave);
            GMapControl.MouseHover += new System.EventHandler(this.GMapControl_MouseHover);
            GMapControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GMapControl_MouseMove);
            GMapControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GMapControl_MouseUp);

            GMapControl.MapScaleInfoEnabled = false;
            GMapControl.ScalePen = new Pen(Color.Red);

            GMapControl.Manager.Mode = AccessMode.ServerAndCache;
            GMapControl.DisableFocusOnMouseEnter = true;
            GMapControl.ForceDoubleBuffer = false;
            GMapControl.RoutesEnabled = true;
            GMapControl.CanDragMap = true;
            GMapControl.DragButton = System.Windows.Forms.MouseButtons.Middle;

            GMapControl.MinZoom = 1;
            GMapControl.MaxZoom = 24;

            //图层预定义
            mOverlayWorkspace = new GMapOverlay("Workspace");
            GMapControl.Overlays.Add(mOverlayWorkspace);

            mOverlayKMLPolygons = new GMapOverlay("KMLPolygons");
            GMapControl.Overlays.Add(mOverlayKMLPolygons);

            mOverlayPolygons = new GMapOverlay("Polygons");
            GMapControl.Overlays.Add(mOverlayPolygons);

            mOverlayWPList = new ArduPilot.WPOverlay();
            mOverlayWPList.overlay.Id = "WPList";
            GMapControl.Overlays.Add(mOverlayWPList.overlay);

            GMapControl.Zoom = 3;

            currentMarker = new GMarkerGoogle(GMapControl.Position, GMarkerGoogleType.red);

            mOverlayTop = new GMapOverlay("Top");
            center = new GMarkerGoogle(GMapControl.Position, GMarkerGoogleType.none);
            mOverlayTop.Markers.Add(center);

            //加载地图源
            UpdateMapType(Settings.Instance["MapType"]);

            BindingProject(VPSProject.mInstance);

            List<PointLatLng> polygonPoints2 = new List<PointLatLng>();
            mPolygonPolygons = new GMapPolygon(polygonPoints2,"DrawPolygon");
            mPolygonPolygons.Stroke = new Pen(Color.Red, 2);
            mPolygonPolygons.Fill = Brushes.Transparent;
        }

        #region 消息生成事件
        public delegate void MessageInfoHandle(string msg);
        /// <summary>
        /// 展示信息事件
        /// </summary>
        public event MessageInfoHandle ShowMessageInfo;
        #endregion

        #region 当前位置发生变化
        public delegate void PositionChangeHandle(VPSPosition position);
        /// <summary>
        /// 当前位置发生变化
        /// </summary>
        public event PositionChangeHandle CurrentChange;
        #endregion

        #region 委托类型
        public delegate void ChangeHandle();
        
        #endregion

        #region 地图控件附加信息

        #region 地图位置信息
        ////地图中心
        public GMapMarker center = new GMarkerGoogle(new PointLatLng(0.0, 0.0), GMarkerGoogleType.none);
        #endregion

        #region 地图图层
        /// <summary>
        /// 地图控件
        /// </summary>
        public static GMap.NET.WindowsForms.GMapControl mGMap { get; set; }
        /// <summary>
        /// 工作空间层
        /// </summary>
        public GMapOverlay mOverlayWorkspace;
        /// <summary>
        /// KML层
        /// </summary>
        public GMapOverlay mOverlayKMLPolygons;
        /// <summary>
        /// 航摄区域层
        /// </summary>
        public GMapOverlay mOverlayPolygons;
        private GMapPolygon mPolygonPolygons;
        /// <summary>
        /// 航线设计层
        /// </summary>
        public ArduPilot.WPOverlay mOverlayWPList;
        private GMapPolygon mPolygonWPList;

        public GMapOverlay mOverlayTop;
        #endregion

        #endregion


        #region 当前地图标记
        //当前选中的标记
        //// 泛用性标记
        private GMapMarker currentGMapMarker;
        //// 容器标记
        private GMapMarkerRect curentRectMarker;
        //// 
        public GMapMarker currentMarker;
        //// 中点标记
        private GMapMarker currentMidLine;
        #endregion

        #region 地图标记绘制状态
        public enum DrawMarker
        {
            None,
            WPMarker,
            PolyMarker
        }
        public DrawMarker CurrentDrawState { get; set; } = DrawMarker.WPMarker;
        /// <summary>
        /// 当前绘制状态发生变化
        /// </summary>

        #endregion

        #region 编辑地图
        bool isMouseDown;

        bool isMarkerEditble = true;
        bool isMarkerAddable = false;
        bool isMarkerPickable = false;
        bool isMarkerMovable = false;
        bool isMarkerRemovable = false;


        private void ResetEditState()
        {
            isMarkerEditble = true;
            isMarkerAddable = false;
            isMarkerPickable = false;
            isMarkerMovable = false;
            isMarkerRemovable = false;
        }
        #endregion

        //// 是否可以弹出右键菜单
        private bool isMouseClickOffMenu = false;

        #region 鼠标按下时位置信息
        //鼠标按下时的位置信息
        internal PointLatLng MouseDownStart;
        internal PointLatLng MouseDownCurrent;
        internal PointLatLng MouseDownEnd;
        private GPoint MouseDownStartPoint = new GPoint();
        private GPoint MouseDownCurrentPoint = new GPoint();
        private GPoint MouseDownPrevPoint = new GPoint();
        private GPoint MouseDownEndPoint = new GPoint();

        private void SetStartPoint(int X, int Y)
        {
            MouseDownStartPoint = new GPoint(X, Y);
            MouseDownCurrentPoint = new GPoint(X, Y);
            MouseDownStart = GMapControl.FromLocalToLatLng(X, Y);
            SetCurrentPoint(X, Y);
        }

        private void SetCurrentPoint(int X, int Y)
        {
            PointLatLng currentPoint = GMapControl.FromLocalToLatLng(X, Y);
            if (isMouseDown)
            {
                if (MouseDownCurrentPoint != null)
                    MouseDownPrevPoint = MouseDownCurrentPoint;
                MouseDownCurrentPoint = new GPoint(X, Y);
                MouseDownCurrent = currentPoint;
            }

            var current = new CustomData.WP.VPSPosition(currentPoint.Lat, currentPoint.Lng);

            CurrentChange?.Invoke(current);
        }

        private void SetEndPoint(int X, int Y)
        {
            MouseDownEndPoint = new GPoint(X, Y);
            MouseDownEnd = GMapControl.FromLocalToLatLng(X, Y);

            SetCurrentPoint(X, Y);
        }
        #endregion

        #region 地图控件响应函数

        #region 地图控件-菜单操作
        private void ContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (CurrentDrawState == DrawMarker.WPMarker && WPList.ExistSelected() ||
                CurrentDrawState == DrawMarker.PolyMarker && Polygon.ExistSelected())
            {
                ChooseToolStripMenuItem.Enabled = true;
            }
            else
            {
                ChooseToolStripMenuItem.Enabled = false;
            }
        }

        private void ContextMenuStrip_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            isMouseClickOffMenu = true;
        }
        #endregion

        #region 地图控件-标记操作
        private void GMapControl_OnMarkerEnter(GMapMarker item)
        {
            if (!isMouseDown)
            {
                if (item is GMapMarkerRect)
                {
                    GMapMarkerRect rc = item as GMapMarkerRect;
                    rc.Pen.Color = Color.Red;
                    GMapControl.Invalidate(false);

                    curentRectMarker = rc;
                }
                if (item is GMapMarkerPlus && ((GMapMarkerPlus)item).Tag is midline)
                {
                    currentMidLine = item;
                    return;
                }
                if (item is GMapMarker)
                {
                    currentGMapMarker = item;
                }
            }
        }

        private void GMapControl_OnMarkerLeave(GMapMarker item)
        {
            if (!isMouseDown)
            {
                if (item is GMapMarkerRect)
                {
                    curentRectMarker = null;
                    GMapMarkerRect rc = item as GMapMarkerRect;
                    rc.ResetColor();
                    GMapControl.Invalidate(false);
                }
                if (item is GMapMarkerPlus && ((GMapMarkerPlus)item).Tag is midline)
                {
                    currentMidLine = null;
                }
                if (item is GMapMarker)
                {
                    // when you click the context menu this triggers and causes problems
                    currentGMapMarker = null;
                }
            }
        }

        private void GMapControl_OnMarkerClick(GMapMarker item, object ei)
        {
            var e = ei as MouseEventArgs;
            try // when dragging item can sometimes be null
            {
                if (isMarkerPickable && e.Button == MouseButtons.Right)
                {
                    try
                    {
                        //选中
                        if (CurrentDrawState == DrawMarker.WPMarker && item is GMapMarkerWP)
                        {
                            if (Control.ModifierKeys != Keys.Control)
                                WPList.ClearSelected();
                            int no = (item as GMapMarkerWP).GetNo();
                            if (Control.ModifierKeys != Keys.Control)
                                WPList.Selected(no, true);
                            else
                                WPList.Selected(no, !WPList.IsSelected(no));

                        }
                        else if (CurrentDrawState == DrawMarker.PolyMarker && item is GMapMarkerPolygon)
                        {
                            if (Control.ModifierKeys != Keys.Control)
                                WPList.ClearSelected();
                            int no = (item as GMapMarkerWP).GetNo();
                            if (Control.ModifierKeys != Keys.Control)
                                WPList.Selected(no, true);
                            else
                                WPList.Selected(no, !WPList.IsSelected(no));
                        }
                        mLog.Info("add marker to group");
                    }
                    catch (Exception ex)
                    {
                        mLog.Error(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                mLog.Error(ex);
            }
            finally
            {
                RedrawWPListSurvey();
                RedrawPolygonSurvey();
                ResetEditState();
            }
        }
        #endregion

        #region 地图控件-鼠标操作
        private void GMapControl_MouseEnter(object sender, EventArgs e)
        {

        }

        private void GMapControl_MouseHover(object sender, EventArgs e)
        {

        }

        private void GMapMainHandle_MouseLeave(object sender, EventArgs e)
        {

        }

        private void GMapControl_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                //记录鼠标开始位置
                SetStartPoint(e.X, e.Y);

                if (isMouseClickOffMenu)
                    return;

                if (e.Button == MouseButtons.Right)
                {
                    return;
                }
                else if (e.Button == MouseButtons.Middle)
                {
                    return;
                }
                else if (e.Button == MouseButtons.Left ) 
                {
                    isMouseDown = true;
                    isMarkerPickable = true;
                    isMarkerAddable = true;
                }
            }
            finally
            {
                
            }
        }

        private void GMapControl_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                //记录鼠标位置
                SetCurrentPoint(e.X, e.Y);

                if (isMarkerMovable)
                {
                    try
                    {
                        if (CurrentDrawState == DrawMarker.WPMarker)
                        {
                            for (int index = 0; index < WPList.GeometryCount; index++)
                            {

                                if (WPList.IsSelected(index))
                                {
                                    VPSPosition position = WPList.GetPosition(index);
                                    PointLatLng currentPoint = GMapControl.FromLocalToLatLng((int)MouseDownCurrentPoint.X, (int)MouseDownCurrentPoint.Y);
                                    PointLatLng prevPoint = GMapControl.FromLocalToLatLng((int)MouseDownPrevPoint.X, (int)MouseDownPrevPoint.Y);
                                    position.Lat = position.Lat + currentPoint.Lat - prevPoint.Lat;
                                    position.Lng = position.Lng + currentPoint.Lng - prevPoint.Lng;

                                    WPList.MovePositionHandle(index, position);
                                }
                            }
                        }

                        else if (CurrentDrawState == DrawMarker.PolyMarker)
                        {

                            for (int index = 0; index < Polygon.GeometryCount; index++)
                            {

                                if (Polygon.IsSelected(index))
                                {
                                    VPSPosition position = Polygon.GetPosition(index);
                                    PointLatLng currentPoint = GMapControl.FromLocalToLatLng((int)MouseDownCurrentPoint.X, (int)MouseDownCurrentPoint.Y);
                                    PointLatLng prevPoint = GMapControl.FromLocalToLatLng((int)MouseDownPrevPoint.X, (int)MouseDownPrevPoint.Y);
                                    position.Lat = position.Lat + currentPoint.Lat - prevPoint.Lat;
                                    position.Lng = position.Lng + currentPoint.Lng - prevPoint.Lng;

                                    Polygon.MovePositionHandle(index, position);
                                }
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        mLog.Error(ex);
                    }
                }
                else if (isMarkerPickable)
                {
                    GMapControl.SelectedArea = new RectLatLng(
                        Math.Max(MouseDownStart.Lat, MouseDownCurrent.Lat),
                        Math.Min(MouseDownStart.Lng, MouseDownCurrent.Lng),
                        Math.Abs(MouseDownStart.Lng - MouseDownCurrent.Lng),
                        Math.Abs(MouseDownStart.Lat - MouseDownCurrent.Lat));
                }
            }
            finally
            {
                RedrawWPListSurvey();
                RedrawPolygonSurvey();
            }
        }

        private void GMapControl_MouseUp(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right) // ignore right clicks
            //{
            //    // 界面图标
            //    return;
            //}
            try
            {
                if (isMouseClickOffMenu)
                {
                    isMouseClickOffMenu = false;
                    return;
                }

                SetEndPoint(e.X, e.Y);
                if (isMouseDown)
                {
                    if (isMarkerMovable)
                    {
                        try
                        {
                            if (CurrentDrawState == DrawMarker.WPMarker)
                            {
                                for (int index = 0; index < WPList.GeometryCount; index++)
                                {

                                    if (WPList.IsSelected(index))
                                    {
                                        VPSPosition position = WPList.GetPosition(index);
                                        PointLatLng currentPoint = GMapControl.FromLocalToLatLng((int)MouseDownCurrentPoint.X, (int)MouseDownCurrentPoint.Y);
                                        PointLatLng prevPoint = GMapControl.FromLocalToLatLng((int)MouseDownPrevPoint.X, (int)MouseDownPrevPoint.Y);
                                        position.Lat = position.Lat + currentPoint.Lat - prevPoint.Lat;
                                        position.Lng = position.Lng + currentPoint.Lng - prevPoint.Lng;

                                        WPList.MovePositionHandle(index, position);
                                    }
                                }
                            }

                            else if (CurrentDrawState == DrawMarker.PolyMarker)
                            {

                                for (int index = 0; index < Polygon.GeometryCount; index++)
                                {

                                    if (Polygon.IsSelected(index))
                                    {
                                        VPSPosition position = Polygon.GetPosition(index);
                                        PointLatLng currentPoint = GMapControl.FromLocalToLatLng((int)MouseDownCurrentPoint.X, (int)MouseDownCurrentPoint.Y);
                                        PointLatLng prevPoint = GMapControl.FromLocalToLatLng((int)MouseDownPrevPoint.X, (int)MouseDownPrevPoint.Y);
                                        position.Lat = position.Lat + currentPoint.Lat - prevPoint.Lat;
                                        position.Lng = position.Lng + currentPoint.Lng - prevPoint.Lng;

                                        Polygon.MovePositionHandle(index, position);
                                    }
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            mLog.Error(ex);
                        }
                    }
                    if (isMarkerPickable)
                    {
                        // group select wps
                        GMapPolygon poly = new GMapPolygon(new List<PointLatLng>(), "temp");

                        poly.Points.Add(MouseDownStart);
                        poly.Points.Add(new PointLatLng(MouseDownStart.Lat, MouseDownEnd.Lng));
                        poly.Points.Add(MouseDownEnd);
                        poly.Points.Add(new PointLatLng(MouseDownEnd.Lat, MouseDownStart.Lng));

                        if (CurrentDrawState == DrawMarker.WPMarker)
                        {
                            if (Control.ModifierKeys != Keys.Control)
                                WPList.ClearSelected();
                            for (int index = 0; index < WPList.GeometryCount; index++)
                            {
                                if (poly.IsInside(WPList[index].ToPoint()))
                                {
                                    try
                                    {
                                        WPList.Selected(index);
                                    }
                                    catch (Exception ex)
                                    {
                                        mLog.Error(ex);
                                    }
                                }
                            }
                        }
                        else if (CurrentDrawState == DrawMarker.PolyMarker)
                        {
                            if (Control.ModifierKeys != Keys.Control)
                                Polygon.ClearSelected();
                            for (int index = 0; index < Polygon.GeometryCount; index++)
                            {
                                if (poly.IsInside(Polygon[index].ToPoint()))
                                {
                                    try
                                    {
                                        Polygon.Selected(index);
                                    }
                                    catch (Exception ex)
                                    {
                                        mLog.Error(ex);
                                    }
                                }
                            }
                        }
                    }
                    if (isMarkerAddable)
                    {
                        if (CurrentDrawState == DrawMarker.WPMarker)
                        {
                            var wp = GeneralWPPoint(MouseDownEnd.Lat, MouseDownEnd.Lng);
                            WPList.AppendPositionHandle(wp);
                        }
                        else if (CurrentDrawState == DrawMarker.PolyMarker)
                        {
                            var point = new CustomData.WP.VPSPosition(
                                currentMarker.Position.Lat,
                                currentMarker.Position.Lng);
                            CustomData.WP.WPGlobalData.instance.AddPolyHandle(point);
                        }
                    }
                }
            }
            finally
            {
                RedrawWPListSurvey();
                RedrawPolygonSurvey();
                GMapControl.SelectedArea = RectLatLng.Empty;
                isMouseDown = false;
                curentRectMarker = null;
                ResetEditState();
            }
        }

        #endregion

        #region 地图控件-WMS切片加载
        private void GMapControl_OnTileLoadStart()
        {
            try
            {
                if (IsHandleCreated)
                    ShowMessageInfo?.Invoke("状态：加载地图切片...");
            }
            catch (Exception ex)
            {
                mLog.Error(ex);
            }
        }

        private void GMapControl_OnTileLoadComplete(long ElapsedMilliseconds)
        {
            try
            {
                if (!IsDisposed && IsHandleCreated)
                    ShowMessageInfo?.Invoke("状态：地图切片加载成功");
            }
            catch (Exception ex)
            {
                mLog.Error(ex);
            }
        }

        private void GMapControl_OnMapTypeChanged(GMap.NET.MapProviders.GMapProvider type)
        {
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
        #endregion

        #region 地图控件-地图焦点
        private void GMapControl_OnPositionChanged(GMap.NET.PointLatLng point)
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

        private void GMapControl_OnMapZoomChanged()
        {
            if (GMapControl.Zoom > 0)
            {
                try
                {
                    GMapZoomBar.Value = (int)(GMapControl.Zoom);
                }
                catch (Exception ex)
                {
                    mLog.Error(ex);
                }
                //textBoxZoomCurrent.Text = MainMap.Zoom.ToString();
                center.Position = GMapControl.Position;
            }
        }
        #endregion

        #endregion

        #region WMS Request
        private void UpdateMapType(string mapType)
        {

            if (string.IsNullOrEmpty(mapType))
            {
                if (L10N.ConfigLang.IsChildOf(System.Globalization.CultureInfo.GetCultureInfo("zh-Hans")))
                {
                    //DevComponents.DotNetBar.MessageBoxEx.Show(
                    //    "已为您将默认地图自动切换到【谷歌中国卫星地图】！\r\n与【谷歌卫星地图】的区别：使用.cn服务器，加入火星坐标修正\r\n",
                    //    "默认地图已被切换");
                    //mapType = "谷歌中国卫星地图";
                    mapType = "高德卫星地图";
                }
                else
                {
                    mapType = "GoogleSatelliteMap";
                }
            }

            mLog.Info("发起【更新地图源】请求? " + mapType);

            try
            {
                GMapProvider provider = GMapProviders.List.Find(x => (x.Name == mapType));

                if (provider == null || provider == MapboxUser.Instance)
                {
                    var url = Settings.Instance["MapBoxURL", ""];
                    InputBox.Show("输入MapBoxURL", "输入MapBoxURL", ref url);
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

                GMapControl.MapProvider = provider;
                Settings.Instance["MapType"] = provider.Name;
            }
            catch (Exception ex)
            {
                mLog.Error(ex);
                DevComponents.DotNetBar.MessageBoxEx.Show("地图更改失败。请尝试缩小Zoom");
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
                    iUserSelection = System.Convert.ToInt32(szUserSelection);
                }
                catch (Exception ex)
                {
                    mLog.Error(ex);
                    iUserSelection = 0; //ignore all errors and default to first layer
                }

                WMSProvider.szWmsLayer = szListLayerName[iUserSelection];
                Settings.Instance["WMSLayer"] = WMSProvider.szWmsLayer;
            }
        }
        #endregion

        #region 重绘函数

        #region 刷新Polygon显示
        public void RedrawPolygonSurvey(bool forced = false)
        {
            mOverlayPolygons.Clear();
            if (forced)
            {
                Polygon = mProjectInstace.GetPolygon();
            }
            var poly = Polygon;
            mPolygonPolygons.Points.Clear();
                int tag = 0;
            for (int index = 0; index < poly.GeometryCount; index++)
            {
                var point = poly[index];
                mPolygonPolygons.Points.Add(point.ToPoint());
                if (CurrentDrawState == DrawMarker.PolyMarker)
                {
                    GMapMarkerPolygon m = new GMapMarkerPolygon(new PointLatLng(point.Lat, point.Lng), tag.ToString());
                    //m.ToolTipMode = MarkerTooltipMode.Never;

                    if (poly.IsSelected(index))
                    {
                        m.selected = true;
                    }

                    //MissionPlanner.GMapMarkerRectWPRad mBorders = new MissionPlanner.GMapMarkerRectWPRad(point, (int)float.Parse(TXT_WPRad.Text), MainMap);
                    GMapMarkerRect mBorders = new GMapMarkerRect(point.ToPoint());
                    {
                        mBorders.InnerMarker = m;
                    }

                    mOverlayPolygons.Markers.Add(m);
                    mOverlayPolygons.Markers.Add(mBorders);

                }
                tag++;
            }
            mOverlayPolygons.Polygons.Add(mPolygonPolygons);
            GMapControl.UpdatePolygonLocalPosition(mPolygonPolygons);

            if (CurrentDrawState == DrawMarker.PolyMarker && mPolygonPolygons.Points.Count > 0)
            {
                foreach (var pointLatLngAlt in mPolygonPolygons.Points.CloseLoop().PrevNowNext())
                {
                    var now = pointLatLngAlt.Item2;
                    var next = pointLatLngAlt.Item3;

                    if (now == null || next == null)
                        continue;

                    var mid = new PointLatLngAlt((now.Lat + next.Lat) / 2, (now.Lng + next.Lng) / 2, 0);

                    var pnt = new GMapMarkerPlus(mid);
                    pnt.Tag = new midline(now, next);
                    mOverlayPolygons.Markers.Add(pnt);
                }
            }

        }
        #endregion

        #region 刷新WPList显示
        /// <summary>
        /// used to write a KML, update the Map view polygon, and update the row headers
        /// </summary>
        public void RedrawWPListSurvey(bool forced = false)
        {
            // quickadd is for when loading wps from eeprom or file, to prevent slow, loading times
            if (Disposing)
                return;

            try
            {
                if(forced)
                {
                    WPList = mProjectInstace.GetWPList();
                }
                var wpList = WPList;

                List<PointLatLngAlt> commands = new List<PointLatLngAlt>();
                VPSPosition home = new VPSPosition();
                for (int index = 0; index < wpList.GeometryCount; index++)
                {
                    if (wpList[index].Command == CustomData.WP.WPCommands.HomeCommand)
                        home = wpList[index];
                    else /*if (CustomData.WP.WPCommands.CoordsWPCommands.Contains(wp.Command))*/
                        commands.Add(wpList[index].ToWGS84());
                }

                #region Home
                if (home == null || home.Command != CustomData.WP.WPCommands.HomeCommand)
                {
                    home = new VPSPosition();
                    home.Command = CustomData.WP.WPCommands.HomeCommand;
                    home.AltMode = CustomData.EnumCollect.AltFrame.Terrain;
                }

                PointLatLngAlt homePosition = CustomData.WP.WPGlobalData.WPChangeAltFrame(
                    home,
                    CustomData.WP.WPGlobalData.GetBaseAlt(wpList.GetGeometry()),
                    CustomData.EnumCollect.AltFrame.Absolute).ToWGS84();
                #endregion

                #region CreateWPOverlay
                mOverlayWPList = new ArduPilot.WPOverlay();
                mOverlayWPList.overlay.Id = "WPOverlay";

                try
                {
                    //if (wpRad <= 0) wpRad = 5;
                    //if (loiterRad <= 0) loiterRad = 30;

                    mOverlayWPList.CreateOverlay(
                        homePosition,
                        commands,
                        5 / CurrentState.multiplieralt,
                        30 / CurrentState.multiplieralt);

                }
                catch (FormatException ex)
                {
                    mLog.Error(ex);
                }
                #endregion

                #region Set WPOverlay State
                foreach (var marker in mOverlayWPList.overlay.Markers)
                {
                    try
                    {
                        if (marker is GMapMarkerWP)
                        {
                            int no = (marker as GMapMarkerWP).GetNo();
                            if (no != -1)
                            {
                                (marker as GMapMarkerWP).Selected = wpList.IsSelected(no);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        mLog.Error(ex);
                    }
                }
                #endregion

                GMapControl.HoldInvalidation = true;

                var existing = GMapControl.Overlays.Where(a => a.Id == mOverlayWPList.overlay.Id).ToList();
                foreach (var b in existing)
                {
                    GMapControl.Overlays.Remove(b);
                }

                GMapControl.Overlays.Add(mOverlayWPList.overlay);

                mOverlayWPList.overlay.ForceUpdate();

                if (CurrentDrawState == DrawMarker.WPMarker && mOverlayWPList.pointlist.Count > 0)
                {
                    foreach (var pointLatLngAlt in mOverlayWPList.pointlist.PrevNowNext())
                    {
                        var prev = pointLatLngAlt.Item1;
                        var now = pointLatLngAlt.Item2;
                        var next = pointLatLngAlt.Item3;

                        if (now == null || next == null)
                            continue;

                        var mid = new PointLatLngAlt((now.Lat + next.Lat) / 2, (now.Lng + next.Lng) / 2,
                            (now.Alt + next.Alt) / 2);

                        var pnt = new GMapMarkerPlus(mid);
                        pnt.Tag = new midline(now, next);
                        mOverlayWPList.overlay.Markers.Add(pnt);
                    }
                }
                GMapControl.RefreshInThread();
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

        #region WPList
        private VPSGeometry WPList = new VPSGeometry();
        private VPS.CustomData.WP.VPSPosition GeneralWPPoint(double lat, double lng, int alt = -1)
        {
            if (alt == -1)
            {
                alt = 100;
            }

            var wp = new VPS.CustomData.WP.VPSPosition(lat, lng, alt);
            //if (splineMode)
            //{
            //    wp.Command = CustomData.WP.WPCommands.SplineWPCommand;
            //    wp.AltMode = "Terrain";
            //}
            //else
            {
                wp.Command = CustomData.WP.WPCommands.DefaultWPCommand;
                wp.AltMode = "Terrain";
            }
            return wp;
        }
        #endregion

        #region Polygon
        private VPSGeometry Polygon = new VPSGeometry();
        #endregion
    }
}
