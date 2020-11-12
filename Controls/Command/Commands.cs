using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using GeoUtility.GeoSystem;
using DevComponents.DotNetBar.SuperGrid;
using System.Collections;
using DevComponents.DotNetBar.SuperGrid.Style;

namespace VPS.Controls.Command
{
    public partial class CommandsPanel : UserControl
    {
        public static CommandsPanel instance = null;

        public CommandsPanel()
        {
            
            try
            {
                InitializeComponent();

                StartEdit();

                InitAltFrame();
                InitCoordSystem();
                InitParam();
                instance = this;
            }
            finally
            {
                EndEdit();
            }

            BindingDataSource(wpLists);

            HomePositionDisplay.PositionChange += SetHome;
        }


        #region Init
        private void InitParam()
        {
            LoadConfig();
        }
        private void InitCoordSystem()
        {
            CoordSystem.DisplayMember = "Value";
            CoordSystem.ValueMember = "Key";
            CoordSystem.DataSource = Utilities.EnumTranslator.EnumToList<CoordSystems>();

            CoordSystem.SelectedItem = CoordSystems.WGS84;
        }

        private void InitAltFrame()
        {
            AltFrame.DisplayMember = "Value";
            AltFrame.ValueMember = "Key";
            AltFrame.DataSource = Utilities.EnumTranslator.EnumToList<AltFrames>();

            AltFrame.SelectedItem = AltFrames.Relative;
        }
        #endregion

        #region Load
        private void CommandsPanel_Load(object sender, EventArgs e)
        {
            StartEdit();
            try
            {
            }
            finally
            {
                EndEdit();
            }
        }
        #endregion

        #region Config

        #region LoadConfig
        private void LoadConfig()
        {
            foreach (string key in Utilities.Settings.Instance.Keys)
            {
                switch (key)
                {
                    case "Commands_WpRad":
                        if (int.TryParse(Utilities.Settings.Instance[key], out int wpRad))
                            WpRad.Value = wpRad;
                        break;
                    case "Commands_DefaultAlt":
                        if (int.TryParse(Utilities.Settings.Instance[key], out int defaultAlt))
                            DefaultAlt.Value = defaultAlt;
                        break;
                    case "Commands_WarnAlt":
                        if (int.TryParse(Utilities.Settings.Instance[key], out int warnAlt))
                            WarnAlt.Value = warnAlt;
                        break;
                    case "Commands_BaseAlt":
                        if (int.TryParse(Utilities.Settings.Instance[key], out int baseAlt))
                            BaseAlt.Value = baseAlt;
                        break;
                    case "Commands_IsAutoWarn":
                        if (bool.TryParse(Utilities.Settings.Instance[key], out bool isAutoWarn))
                            AutoWarnAlt.Checked = isAutoWarn;
                        break;
                    case "Commands_AltFrame":
                        AltFrame.Text = Utilities.Settings.Instance[key];
                        break;
                    case "Commands_CoordSystem":
                        CoordSystem.Text = Utilities.Settings.Instance[key];

                        break;
                    case "Main_HomeLat":
                        if (double.TryParse(Utilities.Settings.Instance[key], out double lat))
                            homePosition.Lat = lat;
                        break;
                    case "Main_HomeLng":
                        if (double.TryParse(Utilities.Settings.Instance[key], out double lng))
                            homePosition.Lng = lng;
                        break;
                    case "Main_HomeAlt":
                        if (double.TryParse(Utilities.Settings.Instance[key], out double alt))
                            homePosition.Alt = alt;
                        break;
                    case "Main_HomeFrame":
                        homePosition.Tag2 = Utilities.Settings.Instance[key];
                        break;
                }
            }
        }
        #endregion

        #region SaveConfig
        void SaveConfig()
        {
            Utilities.Settings.Instance["Commands_WpRad"] = WpRad.Value.ToString();
            Utilities.Settings.Instance["Commands_DefaultAlt"] = DefaultAlt.Value.ToString();
            Utilities.Settings.Instance["Commands_WarnAlt"] = WarnAlt.Value.ToString();
            Utilities.Settings.Instance["Commands_BaseAlt"] = BaseAlt.Value.ToString();
            Utilities.Settings.Instance["Commands_IsAutoWarn"] = AutoWarnAlt.Checked.ToString();
            Utilities.Settings.Instance["Commands_AltFrame"] = AltFrame.Text;
            Utilities.Settings.Instance["Commands_CoordSystem"] = CoordSystem.Text;
        }
        #endregion

        #endregion

        #region Command 控件

        #region 数据绑定

        #region 绑定数据源格式

        const string MainHandle = "Command";
        private DataSet BindingDataSource(List<Utilities.PointLatLngAlt> wpList)
        {
            DataSet set = new DataSet(MainHandle);

            DataTable table = CreateTable();

            BindingData(table, wpList);

            set.Tables.Add(table);

            CommandDataList.PrimaryGrid.DataSource = set;
            CommandDataList.PrimaryGrid.DataMember = WPHandle;
            CommandDataList.PrimaryGrid.ShowRowGridIndex = true;

            return set;
        }
        #endregion

        #region 绑定数据
        private void BindingData(DataTable table, List<Utilities.PointLatLngAlt> wpList)
        {
            if (isEdit)
                return;
            try
            {
                StartEdit();

                if (wpList == null)
                    return;
                else if(wpList.Count > 0)
                {
                    if (wpList[0].Tag == VPS.WP.WPCommands.HomeCommand)
                    {
                        SetHome(wpList[0]);
                        wpList.RemoveAt(0);
                    }
                }
            
                table.BeginLoadData();
                table.Rows.Clear();

                Utilities.PointLatLngAlt wpLast = homePosition;
                foreach (var wp in wpList)
                {
                    if (VPS.WP.WPCommands.CoordsWPCommands.Contains(wp.Tag))
                    {
                        var row = table.NewRow();
                        SetCommandParam(wp, wpLast, ref row);
                        table.Rows.Add(row);
                        wpLast = wp;
                    }
                }
            }
            finally
            {
                table.EndLoadData();
                EndEdit();
            }
        }
        #endregion

        #endregion

        #region 数据绑定完成后的处理函数
        private void CommandDataList_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            GridPanel panel = e.GridPanel;

            switch (panel.DataMember)
            {
                case WPHandle:
                    CustomizeWPPanel(panel);
                    break;
            }
        }
        #endregion

        #region 点击响应函数
        private void CommandDataList_CellClick(object sender, GridCellClickEventArgs e)
        {
            GridPanel panel = e.GridPanel;
            GridCell cell = e.GridCell;
            switch (panel.DataMember)
            {
                case WPHandle:
                    CellClickWPPanel(panel, cell);
                    break;
            }
            
        }
        #endregion

        #endregion

        #region WP 数据表

        #region 创建表格
        const string CommandColumnName = "指令";
        const string LngColumnName = "经度";
        const string LatColumnName = "纬度";
        const string ZoneColumnName = "区";
        const string EastColumnName = "东";
        const string NorthColumnName = "北";
        const string MGRSColumnName = "MGRS";
        const string RelativeAltColumnName = "相对高度";
        const string AbsoluteAltColumnName = "绝对高度";
        const string TerrainAltColumnName = "地面高度";
        const string GradColumnName = "坡度";
        const string AngleColumnName = "角度";
        const string DistColumnName = "距离";
        const string AZColumnName = "方位";
        const string UpColumnName = "上移";
        const string DownColumnName = "下移";
        const string DeleteColumnName = "删除";

        const string WPHandle = "WP";
        private DataTable CreateTable()
        {
            DataTable table = new DataTable(WPHandle);

            DataColumn CommandColumn = new DataColumn(CommandColumnName, typeof(string));
            table.Columns.Add(CommandColumn);
            DataColumn LngColumn = new DataColumn(LngColumnName, typeof(double));
            table.Columns.Add(LngColumn);
            DataColumn LatColumn = new DataColumn(LatColumnName, typeof(double));
            table.Columns.Add(LatColumn);
            DataColumn ZoneColumn = new DataColumn(ZoneColumnName, typeof(int));
            table.Columns.Add(ZoneColumn);
            DataColumn EastColumn = new DataColumn(EastColumnName, typeof(double));
            table.Columns.Add(EastColumn);
            DataColumn NorthColumn = new DataColumn(NorthColumnName, typeof(double));
            table.Columns.Add(NorthColumn);
            DataColumn MGRSColumn = new DataColumn(MGRSColumnName, typeof(string));
            table.Columns.Add(MGRSColumn);
            DataColumn RelativeAltColumn = new DataColumn(RelativeAltColumnName, typeof(int));
            table.Columns.Add(RelativeAltColumn);
            DataColumn AbsoluteAltColumn = new DataColumn(AbsoluteAltColumnName, typeof(int));
            table.Columns.Add(AbsoluteAltColumn);
            DataColumn TerrainAltColumn = new DataColumn(TerrainAltColumnName, typeof(int));
            table.Columns.Add(TerrainAltColumn);
            DataColumn GradColumn = new DataColumn(GradColumnName, typeof(double));
            table.Columns.Add(GradColumn);
            DataColumn AngleColumn = new DataColumn(AngleColumnName, typeof(double));
            table.Columns.Add(AngleColumn);
            DataColumn DistColumn = new DataColumn(DistColumnName, typeof(double));
            table.Columns.Add(DistColumn);
            DataColumn AZColumn = new DataColumn(AZColumnName, typeof(double));
            table.Columns.Add(AZColumn);
            DataColumn UpColumn = new DataColumn(UpColumnName, typeof(string));
            table.Columns.Add(UpColumn);
            DataColumn DownColumn = new DataColumn(DownColumnName, typeof(string));
            table.Columns.Add(DownColumn);
            DataColumn DeleteColumn = new DataColumn(DeleteColumnName, typeof(string));
            table.Columns.Add(DeleteColumn);

            return table;
        }
        #endregion

        #region 添加数据
        private void SetCommandParam(Utilities.PointLatLngAlt wp, Utilities.PointLatLngAlt wpLast, ref DataRow row)
        {
            if (wp == null || wpLast == null)
                return;
            try
            {

                row[CommandColumnName] = wp.Tag;
                row[LngColumnName] = wp.Lng;
                row[LatColumnName] = wp.Lat;

                double terrain = Utilities.srtm.getAltitude(wp.Lat, wp.Lng).alt * CurrentState.multiplieralt;
                double terrainLast = Utilities.srtm.getAltitude(wpLast.Lat, wpLast.Lng).alt * CurrentState.multiplieralt;

                switch (wp.Tag2)
                {
                    case "Relative":
                        row[RelativeAltColumnName] = (int)wp.Alt;
                        row[AbsoluteAltColumnName] = (int)(baseAlt + wp.Alt);
                        row[TerrainAltColumnName] = (int)(baseAlt + wp.Alt - terrain);
                        break;
                    case "Absolute":
                        row[AbsoluteAltColumnName] = (int)wp.Alt;
                        row[RelativeAltColumnName] = (int)(wp.Alt - baseAlt);
                        row[TerrainAltColumnName] = (int)(wp.Alt - terrain);
                        break;
                    case "Terrain":
                        row[TerrainAltColumnName] = (int)wp.Alt;
                        row[RelativeAltColumnName] = (int)(wp.Alt - baseAlt + terrain);
                        row[AbsoluteAltColumnName] = (int)(wp.Alt + terrain);
                        break;
                    default:
                        row[RelativeAltColumnName] = (int)wp.Alt;
                        row[AbsoluteAltColumnName] = (int)(baseAlt + wp.Alt);
                        row[TerrainAltColumnName] = (int)(baseAlt + wp.Alt - terrain);
                        break;
                }

                int zone = wp.GetUTMZone();
                var temp2 = wp.ToUTM();
                row[ZoneColumnName] = (int)zone;
                row[EastColumnName] = (double)temp2[0];
                row[NorthColumnName] = (double)temp2[1];
                row[MGRSColumnName] = ((MGRS)new Geographic(wp.Lng, wp.Lat)).ToString();

                
                switch (wpLast.Tag2)
                {
                    case "Relative":
                        break;
                    case "Absolute":
                        wpLast.Alt = wpLast.Alt - baseAlt;
                        wpLast.Tag2 = "Relative";
                        break;
                    case "Terrain":
                        wpLast.Alt = wpLast.Alt - baseAlt + terrainLast;
                        wpLast.Tag2 = "Relative";
                        break;
                    default:
                        wpLast.Tag2 = "Relative";
                        break;
                }
                switch (wp.Tag2)
                {
                    case "Relative":
                        break;
                    case "Absolute":
                        wp.Alt = wp.Alt - baseAlt;
                        wp.Tag2 = "Relative";
                        break;
                    case "Terrain":
                        wp.Alt = wp.Alt - baseAlt + terrain;
                        wp.Tag2 = "Relative";
                        break;
                    default:
                        wp.Tag2 = "Relative";
                        break;
                }


                double height = wp.Alt - wpLast.Alt;
                double distance = wp.GetDistance(wpLast);
                double grad = height / distance;
                double angle = wp.GetBearing(wpLast);

                row[GradColumnName] = (double)(grad * 100);
                row[AngleColumnName] = (double)((180.0 / Math.PI) * Math.Atan(grad));
                row[DistColumnName] = (double)(Math.Sqrt(Math.Pow(distance, 2) + Math.Pow(height, 2)) * CurrentState.multiplierdist);
                row[AZColumnName] = (double)((angle + 180) % 360);

                row.AcceptChanges();
            }
            catch { }
            finally { }
        }
        #endregion

        #region 点击响应函数
        private void CellClickWPPanel(GridPanel panel, GridCell cell)
        {
            if (cell != null)
            {
                int rowIndex = cell.GridRow.Index;
                var row = cell.GridRow;
                switch (cell.GridColumn.Name)
                {
                    case UpColumnName:
                        if (rowIndex > 0)
                        {
                            ExchangeWP(rowIndex - 1, rowIndex);

                            //WPListChange?.Invoke(GetWPList());
                        }
                        break;
                    case DownColumnName:
                        if (rowIndex < panel.Rows.Count - 1)
                        {
                            ExchangeWP(rowIndex + 1, rowIndex);

                            //WPListChange?.Invoke(GetWPList());
                        }
                        break;
                    case DeleteColumnName:
                        DeleteWP(rowIndex);

                        //WPListChange?.Invoke(GetWPList());
                        break;
                }

            }
        }
        #endregion

        #region 数据绑定完成后的处理函数
        private void CustomizeWPPanel(GridPanel panel)
        {
            panel.ColumnHeader.RowHeight = 30;
            panel.ColumnAutoSizeMode = ColumnAutoSizeMode.Fill;
            panel.MinRowHeight = 25;

            for (int i = 0; i < panel.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    GridRow row = (GridRow)panel.Rows[i];

                    row.RowStyles.Default.RowHeaderStyle.DirtyMarkerBackground =
                        new Background(Color.Crimson, Color.Gainsboro, BackFillType.VerticalCenter);
                }
            }

            {
                panel.Columns[CommandColumnName].AutoSizeMode = ColumnAutoSizeMode.Fill;
                panel.Columns[CommandColumnName].FillWeight = 150;
                panel.Columns[CommandColumnName].EditorType = typeof(MyControls.FragrantComboBox);
                panel.Columns[CommandColumnName].EditorParams = new object[] { Enum.GetValues(typeof(commands)) };
                //panel.Columns[CommandColumn.ColumnName].ReadOnly = true;
            }

            {
                panel.Columns[LatColumnName].AutoSizeMode = ColumnAutoSizeMode.Fill;
                panel.Columns[LatColumnName].FillWeight = 120;
                panel.Columns[LatColumnName].EditorType = typeof(GridDoubleInputEditControl);
                //panel.Columns[LatColumn.ColumnName].ReadOnly = true;
                panel.Columns[LatColumnName].Visible = true;
                GridDoubleInputEditControl LatEditControl = (GridDoubleInputEditControl)panel.Columns[LatColumnName].EditControl;
                LatEditControl.MaxValue = 90;
                LatEditControl.MinValue = -90;
                GridDoubleInputEditControl LatRenderControl = (GridDoubleInputEditControl)panel.Columns[LatColumnName].RenderControl;
                LatRenderControl.DisplayFormat = "0.########";

                panel.Columns[LngColumnName].AutoSizeMode = ColumnAutoSizeMode.Fill;
                panel.Columns[LngColumnName].FillWeight = 120;
                panel.Columns[LngColumnName].EditorType = typeof(GridDoubleInputEditControl);
                //panel.Columns[LngColumn.ColumnName].ReadOnly = true;
                panel.Columns[LngColumnName].Visible = true;
                GridDoubleInputEditControl LngEditControl = (GridDoubleInputEditControl)panel.Columns[LngColumnName].EditControl;
                LngEditControl.MaxValue = 180;
                LngEditControl.MinValue = -180;
                GridDoubleInputEditControl LngRenderControl = (GridDoubleInputEditControl)panel.Columns[LngColumnName].RenderControl;
                LngRenderControl.DisplayFormat = "0.########";

                if (currentCoord != CoordSystems.WGS84)
                {
                    panel.Columns[LatColumnName].Visible = false;
                    panel.Columns[LngColumnName].Visible = false;
 
                }
            }

            {
                panel.Columns[ZoneColumnName].AutoSizeMode = ColumnAutoSizeMode.Fill;
                panel.Columns[ZoneColumnName].FillWeight = 60;
                panel.Columns[ZoneColumnName].EditorType = typeof(GridIntegerInputEditControl);
                panel.Columns[ZoneColumnName].ReadOnly = true;
                
                panel.Columns[EastColumnName].AutoSizeMode = ColumnAutoSizeMode.Fill;
                panel.Columns[EastColumnName].FillWeight = 90;
                panel.Columns[EastColumnName].EditorType = typeof(GridDoubleInputEditControl);
                panel.Columns[EastColumnName].ReadOnly = true;

                panel.Columns[NorthColumnName].AutoSizeMode = ColumnAutoSizeMode.Fill;
                panel.Columns[NorthColumnName].FillWeight = 90;
                panel.Columns[NorthColumnName].EditorType = typeof(GridDoubleInputEditControl);
                panel.Columns[NorthColumnName].ReadOnly = true;

                if (currentCoord != CoordSystems.UTM)
                {
                    panel.Columns[ZoneColumnName].Visible = false;
                    panel.Columns[EastColumnName].Visible = false;
                    panel.Columns[NorthColumnName].Visible = false;
                }

            }

            {
                panel.Columns[MGRSColumnName].AutoSizeMode = ColumnAutoSizeMode.Fill;
                panel.Columns[MGRSColumnName].FillWeight = 240;
                panel.Columns[MGRSColumnName].EditorType = typeof(GridTextBoxXEditControl);
                panel.Columns[MGRSColumnName].ReadOnly = true;

                if (currentCoord != CoordSystems.MGRS)
                {
                    panel.Columns[MGRSColumnName].Visible = false;
                }
            }

            {
                panel.Columns[RelativeAltColumnName].AutoSizeMode = ColumnAutoSizeMode.Fill;
                panel.Columns[RelativeAltColumnName].FillWeight = 80;
                panel.Columns[RelativeAltColumnName].EditorType = typeof(GridIntegerInputEditControl);
                //panel.Columns[RelativeAltColumn.ColumnName].ReadOnly = true;


                panel.Columns[AbsoluteAltColumnName].AutoSizeMode = ColumnAutoSizeMode.Fill;
                panel.Columns[AbsoluteAltColumnName].FillWeight = 80;
                panel.Columns[AbsoluteAltColumnName].EditorType = typeof(GridIntegerInputEditControl);
                //panel.Columns[AbsoluteAltColumn.ColumnName].ReadOnly = true;


                panel.Columns[TerrainAltColumnName].AutoSizeMode = ColumnAutoSizeMode.Fill;
                panel.Columns[TerrainAltColumnName].FillWeight = 80;
                panel.Columns[TerrainAltColumnName].EditorType = typeof(GridIntegerInputEditControl);
                //panel.Columns[TerrainAltColumn.ColumnName].ReadOnly = true;
                if (currentFrame != AltFrames.Relative)
                    panel.Columns[RelativeAltColumnName].Visible = false;
                if(currentFrame != AltFrames.Absolute)
                    panel.Columns[AbsoluteAltColumnName].Visible = false;
                if (currentFrame != AltFrames.Terrain)
                    panel.Columns[TerrainAltColumnName].Visible = false;
            }

            {
                panel.Columns[GradColumnName].AutoSizeMode = ColumnAutoSizeMode.Fill;
                panel.Columns[GradColumnName].FillWeight = 80;
                panel.Columns[GradColumnName].EditorType = typeof(GridDoubleInputEditControl);
                panel.Columns[GradColumnName].ReadOnly = true;

                panel.Columns[AngleColumnName].AutoSizeMode = ColumnAutoSizeMode.Fill;
                panel.Columns[AngleColumnName].FillWeight = 80;
                panel.Columns[AngleColumnName].EditorType = typeof(GridDoubleInputEditControl);
                panel.Columns[AngleColumnName].ReadOnly = true;

                panel.Columns[DistColumnName].AutoSizeMode = ColumnAutoSizeMode.Fill;
                panel.Columns[DistColumnName].FillWeight = 80;
                panel.Columns[DistColumnName].EditorType = typeof(GridDoubleInputEditControl);
                panel.Columns[DistColumnName].ReadOnly = true;

                panel.Columns[AZColumnName].AutoSizeMode = ColumnAutoSizeMode.Fill;
                panel.Columns[AZColumnName].FillWeight = 80;
                panel.Columns[AZColumnName].EditorType = typeof(GridDoubleInputEditControl);
                panel.Columns[AZColumnName].ReadOnly = true;
            }

            {
                panel.Columns[UpColumnName].AutoSizeMode = ColumnAutoSizeMode.None;
                panel.Columns[UpColumnName].MinimumWidth = 25;
                panel.Columns[UpColumnName].Width = 25;
                panel.Columns[UpColumnName].EditorType = typeof(MyControls.ImagePanel);
                panel.Columns[UpColumnName].EditorParams = new object[] { ImageList.Images["Up.png"] };

                panel.Columns[DownColumnName].AutoSizeMode = ColumnAutoSizeMode.None;
                panel.Columns[DownColumnName].MinimumWidth = 25;
                panel.Columns[DownColumnName].Width = 25;
                panel.Columns[DownColumnName].EditorType = typeof(MyControls.ImagePanel);
                panel.Columns[DownColumnName].EditorParams = new object[] { ImageList.Images["Down.png"] };

                panel.Columns[DeleteColumnName].AutoSizeMode = ColumnAutoSizeMode.None;
                panel.Columns[DeleteColumnName].MinimumWidth = 25;
                panel.Columns[DeleteColumnName].Width = 25;
                panel.Columns[DeleteColumnName].EditorType = typeof(MyControls.ImagePanel);
                panel.Columns[DeleteColumnName].EditorParams = new object[] { ImageList.Images["Delete.png"] };
            }
        }
        #endregion

        #endregion

        public delegate void DataChangeHandle(object data);
        public delegate void IntegerChangeHandle(int data);
        public delegate void StringChangeHandle(string str);
        public delegate void PositionChangeHandle(Utilities.PointLatLngAlt point);
        public delegate void WPListChangeHandle(List<Utilities.PointLatLngAlt> wpList);

        #region 重要数据

        #region WPList 数据源
        enum commands
        {
            WAYPOINT,
            SPLINE_WAYPOINT
        }

        public WPListChangeHandle WPListChange;
        List<Utilities.PointLatLngAlt> wpLists = new List<Utilities.PointLatLngAlt>();
        bool settingWP = false;

        #region SetWPList 方法
        private delegate void SetWPListInThread(List<Utilities.PointLatLngAlt> wpList);

        #region 对外接口
        public void SetWPListHandle(List<Utilities.PointLatLngAlt> wpList)
        {
            if (this.InvokeRequired)
            {
                SetWPListInThread inThread = new SetWPListInThread(SetWPListHandle);
                this.Invoke(inThread, new object[] { wpList });
            }
            else
            {
                Task.Run(() =>
                {
                    StopSendListChange();
                    SetWPList(wpList);
                    StartSendListChange();
                });

            }
        }
        #endregion

        #region 入口函数
        private void SetWPList(List<Utilities.PointLatLngAlt> wpList)
        {
            lock (this)
            {
                if (settingWP)
                    return;
                else
                    settingWP = true;
            }
            wpLists = wpList;
            GeneralBaseAlt();

            BindingDataSource(wpList);

            lock (this)
            {
                settingWP = false;
                if (IsAllowSendListChange())
                    WPListChange?.Invoke(GetWPList());
            }
        }
        #endregion

        #endregion

        #region GetWPList 方法
        public List<Utilities.PointLatLngAlt> GetWPList()
        {
            return wpLists;
        }
        #endregion

        #region ExchangeWP 方法
        private void ExchangeWP(int index1,int index2)
        {
            Utilities.PointLatLngAlt temp = wpLists[index1];
            wpLists[index1] = wpLists[index2];
            wpLists[index2] = temp;

            BindingDataSource(wpLists);
            if (IsAllowSendListChange())
                WPListChange?.Invoke(GetWPList());
        }
        #endregion

        #region SetWP 方法
        private void SetWP(int index, Utilities.PointLatLngAlt wp)
        {
            wpLists[index] = wp;

            GeneralBaseAlt();

            BindingDataSource(wpLists);
            if (IsAllowSendListChange())
                WPListChange?.Invoke(GetWPList());
        }
        #endregion

        #region DeleteWP 方法
        private void DeleteWP(int index)
        {
            wpLists.RemoveAt(index);

            GeneralBaseAlt();

            BindingDataSource(wpLists);
            if (IsAllowSendListChange())
                WPListChange?.Invoke(GetWPList());
        }
        #endregion

        #endregion

        #region Home 位置数据
        private Utilities.PointLatLngAlt homePosition = new Utilities.PointLatLngAlt();
        public PositionChangeHandle HomeChange;

        #region SetHome

        #region SetHome 接口函数
        private delegate void SetHomeInThread(Utilities.PointLatLngAlt home);

        public void SetHomeHandle(Utilities.PointLatLngAlt home)
        {
            if (this.InvokeRequired)
            {
                SetHomeInThread inThread = new SetHomeInThread(SetHomeHandle);
                this.Invoke(inThread, new object[] { home });
            }
            else
            {
                StopSendPositionChange();
                SetHome(home);
                StartSendPositionChange();
            }
        }
        #endregion

        #region SetHome 入口函数
        private void SetHome(Utilities.PointLatLngAlt home)
        {
            if (home.Tag != VPS.WP.WPCommands.HomeCommand)
                home.Tag = VPS.WP.WPCommands.HomeCommand;

            if (!homePosition.Equals(home))
            {
                homePosition = home;
                HomePositionDisplay.WGS84Position = home;

                if (IsAllowSendPositionChange())
                    HomeChange?.Invoke(homePosition);
            }
        }
        #endregion

        #endregion

        #endregion

        #endregion

        #region 数据

        #region CoordSystem
        private enum CoordSystems
        {
            WGS84,
            UTM,
            MGRS
        }

        private CoordSystems currentCoord = CoordSystems.WGS84;
        public StringChangeHandle CoordSystemChange;

        #region SetSystemCoord

        #region SetSystemCoord 接口函数
        private delegate void SetCoordInThread(string coord);

        public void SetCoordHandle(string coord)
        {
            if (this.InvokeRequired)
            {
                SetCoordInThread inThread = new SetCoordInThread(SetCoordHandle);
                this.Invoke(inThread, new object[] { coord });
            }
            else
            {
                StopSendDataChange();
                SetCurrentCoord((CoordSystems)Enum.Parse(typeof(CoordSystems),coord));
                StartSendDataChange();
            }
        }
        #endregion

        #region SetSystemCoord 入口函数
        private void SetCurrentCoord(CoordSystems coord)
        {
            currentCoord = coord;

            if (IsAllowSendDataChange())
                CoordSystemChange?.Invoke(currentCoord.ToString());

            if (isEdit)
                return;

            GridPanel panel = CommandDataList.PrimaryGrid;
            if (panel != null)
            {
                switch (currentCoord)
                {
                    case CoordSystems.WGS84:
                        panel.Columns[LatColumnName].Visible = true;
                        panel.Columns[LngColumnName].Visible = true;
                        panel.Columns[ZoneColumnName].Visible = false;
                        panel.Columns[EastColumnName].Visible = false;
                        panel.Columns[NorthColumnName].Visible = false;
                        panel.Columns[MGRSColumnName].Visible = false;
                        break;
                    case CoordSystems.UTM:
                        panel.Columns[LatColumnName].Visible = false;
                        panel.Columns[LngColumnName].Visible = false;
                        panel.Columns[ZoneColumnName].Visible = true;
                        panel.Columns[EastColumnName].Visible = true;
                        panel.Columns[NorthColumnName].Visible = true;
                        panel.Columns[MGRSColumnName].Visible = false;
                        break;
                    case CoordSystems.MGRS:
                        panel.Columns[LatColumnName].Visible = false;
                        panel.Columns[LngColumnName].Visible = false;
                        panel.Columns[ZoneColumnName].Visible = false;
                        panel.Columns[EastColumnName].Visible = false;
                        panel.Columns[NorthColumnName].Visible = false;
                        panel.Columns[MGRSColumnName].Visible = true;
                        break;
                    default:
                        panel.Columns[LatColumnName].Visible = true;
                        panel.Columns[LngColumnName].Visible = true;
                        panel.Columns[ZoneColumnName].Visible = false;
                        panel.Columns[EastColumnName].Visible = false;
                        panel.Columns[NorthColumnName].Visible = false;
                        panel.Columns[MGRSColumnName].Visible = false;
                        break;
                }
            }
        }
        #endregion

        #endregion

        #endregion

        #region  AltFrame
        private enum AltFrames
        {
            Relative,
            Absolute,
            Terrain
        }

        private AltFrames currentFrame = AltFrames.Relative;
        public StringChangeHandle AltFrameChange;

        #region SetAltFrame

        #region SetAltFrame 接口函数
        private delegate void SetFrameInThread(string frame);
        public void SetFrameHandle(string frame)
        {
            if (this.InvokeRequired)
            {
                SetFrameInThread inThread = new SetFrameInThread(SetFrameHandle);
                this.Invoke(inThread, new object[] { frame });
            }
            else
            {
                StopSendDataChange();
                SetCurrentFrame((AltFrames)Enum.Parse(typeof(AltFrames), frame));
                StartSendDataChange();
            }
        }
        #endregion

        #region SetAltFrame 入口函数
        private void SetCurrentFrame(AltFrames frame)
        {
            currentFrame = frame;

            if (IsAllowSendDataChange())
                AltFrameChange?.Invoke(currentFrame.ToString());

            if (isEdit)
                return;

            GridPanel panel = CommandDataList.PrimaryGrid;
            if (panel != null)
            {
                switch (currentFrame)
                {
                    case AltFrames.Relative:
                        panel.Columns[RelativeAltColumnName].Visible = true;
                        panel.Columns[AbsoluteAltColumnName].Visible = false;
                        panel.Columns[TerrainAltColumnName].Visible = false;
                        break;
                    case AltFrames.Absolute:
                        panel.Columns[RelativeAltColumnName].Visible = false;
                        panel.Columns[AbsoluteAltColumnName].Visible = true;
                        panel.Columns[TerrainAltColumnName].Visible = false;
                        break;
                    case AltFrames.Terrain:
                        panel.Columns[RelativeAltColumnName].Visible = false;
                        panel.Columns[AbsoluteAltColumnName].Visible = false;
                        panel.Columns[TerrainAltColumnName].Visible = true;
                        break;
                    default:
                        panel.Columns[RelativeAltColumnName].Visible = true;
                        panel.Columns[AbsoluteAltColumnName].Visible = false;
                        panel.Columns[TerrainAltColumnName].Visible = false;
                        break;
                }
            }
        }
        #endregion

        #endregion

        #endregion

        #region DefaultAlt
        private int defaultAlt = 200;
        public IntegerChangeHandle DefaultAltChange;

        #region SetDefaultAlt

        #region SetDefaultAlt 接口函数
        private delegate void SetDefaultAltInThread(int alt);

        public void SetDefaultAltHandle(int alt)
        {
            if (this.InvokeRequired)
            {
                SetDefaultAltInThread inThread = new SetDefaultAltInThread(SetDefaultAltHandle);
                this.Invoke(inThread, new object[] { alt });
            }
            else
            {
                StopSendDataChange();
                SetDefaultAlt(alt);
                StartSendDataChange();
            }
        }

        #endregion

        #region SetDefaultAlt 入口函数
        private void SetDefaultAlt(int alt)
        {
            defaultAlt = alt;
            if (IsAllowSendDataChange())
                DefaultAltChange?.Invoke(defaultAlt);
        }
        #endregion

        #endregion

        #endregion

        #region WarnAlt
        private int warnAlt = 0;
        public IntegerChangeHandle WarnAltChange;

        #region SetWarnAlt

        #region SetWarnAlt 接口函数
        private delegate void SetWarnAltInThread(int alt);

        public void SetWarnAltHandle(int alt)
        {
            if (this.InvokeRequired)
            {
                SetWarnAltInThread inThread = new SetWarnAltInThread(SetWarnAltHandle);
                this.Invoke(inThread, new object[] { alt });
            }
            else
            {
                StopSendDataChange();
                SetWarnAlt(alt);
                StartSendDataChange();
            }
        }

        #endregion

        #region SetWarnAlt 入口函数
        private void SetWarnAlt(int alt)
        {
            warnAlt = alt;
            if (IsAllowSendDataChange())
                WarnAltChange?.Invoke(warnAlt);
        }
        #endregion

        #endregion

        #endregion

        #region wpRad
        private int wpRad = 20;
        public IntegerChangeHandle WPRadChange;

        #region SetWpRad

        #region SetWpRad 接口函数
        private delegate void SetWpRadInThread(int rad);

        public void SetWpRadHandle(int rad)
        {
            if (this.InvokeRequired)
            {
                SetWpRadInThread inThread = new SetWpRadInThread(SetWpRadHandle);
                this.Invoke(inThread, new object[] { rad });
            }
            else
            {
                StopSendDataChange();
                SetWpRad(rad);
                StartSendDataChange();
            }
        }
        #endregion

        #region SetWpRad 入口函数
        private void SetWpRad(int rad)
        {
            wpRad = rad;
            if (IsAllowSendDataChange())
                WPRadChange?.Invoke(wpRad);
        }
        #endregion

        #endregion

        #endregion

        #region BaseAlt 计算值
        private int baseAlt = 0;
        private void BaseAlt_ValueChanged(object sender, EventArgs e)
        {
            baseAlt = BaseAlt.Value;
        }

        private void GeneralBaseAlt()
        {
            double totalAlt = 0.0;
            double maxAlt = 0.0;
            for (int index = 0; index < wpLists.Count; index++)
            {
                if (VPS.WP.WPCommands.CoordsWPCommands.Contains(wpLists[index].Tag))
                {
                    double terrain = Utilities.srtm.getAltitude(wpLists[index].Lat, wpLists[index].Lng).alt * CurrentState.multiplieralt;
                    totalAlt += terrain;
                    if (terrain > maxAlt)
                        maxAlt = terrain;
                }
            }
            BaseAlt.Value = (int)(totalAlt / Math.Max(1, wpLists.Count));
            if (isAutoWarn)
                WarnAlt.Value = (int)(maxAlt - baseAlt);
        }
        #endregion

        #endregion

        #region 标记

        #region Edit
        private bool isEdit = false;

        #region 接口函数
        private void StartEdit()
        {
            isEdit = true;
        }
        private void EndEdit()
        {
            isEdit = false;
        }
        #endregion

        #region 判断函数

        #endregion

        #endregion

        #region SendListChange 标记
        public bool isSendListChange = true;

        #region 接口函数
        public void StopSendListChange()
        {
            isSendListChange = false;
        }

        public void StartSendListChange()
        {
            isSendListChange = true;
        }
        #endregion

        #region 判断函数
        private bool IsAllowSendListChange()
        {
            return isSendListChange;
        }
        #endregion

        #endregion

        #region SendPositionChange 标记
        public bool isSendPositionChange = true;

        #region 接口函数
        public void StopSendPositionChange()
        {
            isSendPositionChange = false;
        }

        public void StartSendPositionChange()
        {
            isSendPositionChange = true;
        }
        #endregion

        #region 判断函数
        private bool IsAllowSendPositionChange()
        {
            return isSendPositionChange;
        }
        #endregion

        #endregion

        #region SendDataChange 标记
        public bool isSendDataChange = true;

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

        #region 自动生成警戒高度
        private bool isAutoWarn = true;

        #endregion

        #endregion

        #region 控件响应函数

        #region coordSystem
        private void CoordSystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetCurrentCoord((CoordSystems)CoordSystem.SelectedValue);
        }
        #endregion

        #region AltFrame
        private void AltFrame_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetCurrentFrame((AltFrames)AltFrame.SelectedValue);
        }
        #endregion

        #region defaultAlt
        private void DefaultAlt_ValueChanged(object sender, EventArgs e)
        {
            SetDefaultAlt(DefaultAlt.Value);
        }
        #endregion

        #region autoWarnAlt
        private void AutoWarnAlt_CheckedChanged(object sender, EventArgs e)
        {
            isAutoWarn = AutoWarnAlt.Checked;
            WarnAlt.Enabled = !AutoWarnAlt.Checked;
            labelX3.Enabled = !AutoWarnAlt.Checked;
        }
        #endregion

        #region warnAlt
        private void WarnAlt_ValueChanged(object sender, EventArgs e)
        {
            SetWarnAlt((int)WarnAlt.Value);
        }
        #endregion

        #region wpRad
        private void WpRad_ValueChanged(object sender, EventArgs e)
        {
            SetWpRad(WpRad.Value);
        }
        #endregion

        #endregion

        #region CommandPanel 响应函数
        private void CommandsPanel_Leave(object sender, EventArgs e)
        {
            SaveConfig();
        }
        #endregion
    }


}
