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

                BindingDataSource();

                StartEdit();
                instance = this;
            }
            finally
            {
                EndEdit();
            }
        }

        private void InitAltFrame()
        {
            AltFrame.DisplayMember = "Value";
            AltFrame.ValueMember = "Key";
            AltFrame.DataSource = Utilities.EnumTranslator.EnumToList<AltFrames>();

            AltFrame.SelectedItem = AltFrames.Relative;
        }

        private void InitCoordSystem()
        {
            CoordSystem.DisplayMember = "Value";
            CoordSystem.ValueMember = "Key";
            CoordSystem.DataSource = Utilities.EnumTranslator.EnumToList<CoordSystems>();

            CoordSystem.SelectedItem = CoordSystems.WGS84;
        }

        private void InitParam()
        {
            if (Utilities.Settings.Instance.ContainsKey("Commands_WpRad") && Utilities.Settings.Instance["Commands_WpRad"] != null)
            {
                if (int.TryParse(Utilities.Settings.Instance["Commands_WpRad"], out int wpRad))
                    WpRad.Value = wpRad;
            }
            if (Utilities.Settings.Instance.ContainsKey("Commands_DefaultAlt") && Utilities.Settings.Instance["Commands_DefaultAlt"] != null)
            {
                if (int.TryParse(Utilities.Settings.Instance["Commands_DefaultAlt"], out int defaultAlt))
                    DefaultAlt.Value = defaultAlt;
            }
            if (Utilities.Settings.Instance.ContainsKey("Commands_WarnAlt") && Utilities.Settings.Instance["Commands_WarnAlt"] != null)
            {
                if (int.TryParse(Utilities.Settings.Instance["Commands_WarnAlt"], out int warnAlt))
                    WarnAlt.Value = warnAlt;
            }
            if (Utilities.Settings.Instance.ContainsKey("Commands_BaseAlt") && Utilities.Settings.Instance["Commands_BaseAlt"] != null)
            {
                if (int.TryParse(Utilities.Settings.Instance["Commands_BaseAlt"], out int baseAlt))
                    BaseAlt.Value = baseAlt;
            }
            if (Utilities.Settings.Instance.ContainsKey("Commands_IsAutoWarn") && Utilities.Settings.Instance["Commands_IsAutoWarn"] != null)
            {
                if (bool.TryParse(Utilities.Settings.Instance["Commands_IsAutoWarn"], out bool isAutoWarn))
                    AutoWarnAlt.Checked = isAutoWarn;
            }
            if (Utilities.Settings.Instance.ContainsKey("Commands_AltFrame") && Utilities.Settings.Instance["Commands_AltFrame"] != null)
            {
                AltFrame.Text = Utilities.Settings.Instance["Commands_AltFrame"];
            }
            if (Utilities.Settings.Instance.ContainsKey("Commands_CoordSystem") && Utilities.Settings.Instance["Commands_CoordSystem"] != null)
            {
                CoordSystem.Text = Utilities.Settings.Instance["Commands_CoordSystem"];
            }
            if (Utilities.Settings.Instance.ContainsKey("Main_HomeLat") && Utilities.Settings.Instance["Main_HomeLat"] != null)
            {
                if (double.TryParse(Utilities.Settings.Instance["Main_HomeLat"], out double lat))
                    HomeLat.Value = lat;
            }
            if (Utilities.Settings.Instance.ContainsKey("Main_HomeLng") && Utilities.Settings.Instance["Main_HomeLng"] != null)
            {
                if (double.TryParse(Utilities.Settings.Instance["Main_HomeLng"], out double lng))
                    HomeLng.Value = lng;
            }
            if (Utilities.Settings.Instance.ContainsKey("Main_HomeAlt") && Utilities.Settings.Instance["Main_HomeAlt"] != null)
            {
                if (double.TryParse(Utilities.Settings.Instance["Main_HomeAlt"], out double alt))
                    HomeAlt.Value = alt;
            }
        }

        void SaveParam()
        {
            Utilities.Settings.Instance["Commands_WpRad"] = WpRad.Value.ToString();
            Utilities.Settings.Instance["Commands_DefaultAlt"] = DefaultAlt.Value.ToString();
            Utilities.Settings.Instance["Commands_WarnAlt"] = WarnAlt.Value.ToString();
            Utilities.Settings.Instance["Commands_BaseAlt"] = BaseAlt.Value.ToString();
            Utilities.Settings.Instance["Commands_IsAutoWarn"] = AutoWarnAlt.Checked.ToString();
            Utilities.Settings.Instance["Commands_AltFrame"] = AltFrame.Text;
            Utilities.Settings.Instance["Commands_CoordSystem"] = CoordSystem.Text;

        }


        private void CommandsPanel_Leave(object sender, EventArgs e)
        {
            SaveParam();
        }


        private bool isEdit = false;
        private void StartEdit()
        {
            isEdit = true;
        }
        private void EndEdit()
        {
            isEdit = false;
        }

        private enum AltFrames
        {
            Relative,
            Absolute,
            Terrain
        }
        private AltFrames currentFrame = AltFrames.Relative;
        public StringChangeHandle AltFrameChange;
        private void AltFrame_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetCurrentFrame((AltFrames)AltFrame.SelectedValue);
            if (isEdit)
                return;
            AltFrameChange?.Invoke(currentFrame.ToString());
        }


        private void SetCurrentFrame(AltFrames frame)
        {
            currentFrame = frame;

            GridPanel panel = CommandDataList.PrimaryGrid;
            if (panel != null)
            {
                switch (currentFrame)
                {
                    case AltFrames.Relative:
                        panel.Columns[RelativeAltColumn.ColumnName].Visible = true;
                        panel.Columns[AbsoluteAltColumn.ColumnName].Visible = false;
                        panel.Columns[TerrainAltColumn.ColumnName].Visible = false;
                        break;
                    case AltFrames.Absolute:
                        panel.Columns[RelativeAltColumn.ColumnName].Visible = false;
                        panel.Columns[AbsoluteAltColumn.ColumnName].Visible = true;
                        panel.Columns[TerrainAltColumn.ColumnName].Visible = false;
                        break;
                    case AltFrames.Terrain:
                        panel.Columns[RelativeAltColumn.ColumnName].Visible = false;
                        panel.Columns[AbsoluteAltColumn.ColumnName].Visible = false;
                        panel.Columns[TerrainAltColumn.ColumnName].Visible = true;
                        break;
                    default:
                        panel.Columns[RelativeAltColumn.ColumnName].Visible = true;
                        panel.Columns[AbsoluteAltColumn.ColumnName].Visible = false;
                        panel.Columns[TerrainAltColumn.ColumnName].Visible = false;
                        break;
                }
            }
        }

        public delegate void DataChangeHandle(object data);
        public delegate void IntegerChangeHandle(int data);
        public delegate void StringChangeHandle(string str);
        public delegate void PositionChangeHandle(Utilities.PointLatLngAlt point);
        

        private int defaultAlt = 200;
        public IntegerChangeHandle DefaultAltChange;
        private void DefaultAlt_ValueChanged(object sender, EventArgs e)
        {
            defaultAlt = DefaultAlt.Value;
            if (isEdit)
                return;
            DefaultAltChange?.Invoke(defaultAlt);
        }

        private int warnAlt = 0;
        public IntegerChangeHandle WarnAltChange;
        private void WarnAlt_ValueChanged(object sender, EventArgs e)
        {
            warnAlt = WarnAlt.Value;
            if (isEdit)
                return;
            WarnAltChange?.Invoke(warnAlt);
        }

        private bool isAutoWarn = true;
        private void AutoWarnAlt_CheckedChanged(object sender, EventArgs e)
        {
            isAutoWarn = AutoWarnAlt.Checked;
        }

        private int baseAlt = 0;
        public IntegerChangeHandle BaseAltChange;
        private void BaseAlt_ValueChanged(object sender, EventArgs e)
        {
            baseAlt = BaseAlt.Value;
            if (isEdit)
                return;
            BaseAltChange?.Invoke(baseAlt);
        }

        private enum CoordSystems
        {
            WGS84,
            UTM,
            MGRS
        }
        private CoordSystems currentCoord = CoordSystems.WGS84;
        public StringChangeHandle CoordSystemChange;
        private void CoordSystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetCurrentCoord((CoordSystems)CoordSystem.SelectedValue);
            if (isEdit)
                return;
            CoordSystemChange?.Invoke(currentCoord.ToString());
        }

        private void SetCurrentCoord(CoordSystems coord)
        { 
            currentCoord = coord;

            GridPanel panel = CommandDataList.PrimaryGrid;
            if (panel != null)
            {
                switch (currentCoord)
                {
                    case CoordSystems.WGS84:
                        panel.Columns[LatColumn.ColumnName].Visible = true;
                        panel.Columns[LngColumn.ColumnName].Visible = true;
                        panel.Columns[ZoneColumn.ColumnName].Visible = false;
                        panel.Columns[EastColumn.ColumnName].Visible = false;
                        panel.Columns[NorthColumn.ColumnName].Visible = false;
                        panel.Columns[MGRSColumn.ColumnName].Visible = false;
                        break;
                    case CoordSystems.UTM:
                        panel.Columns[LatColumn.ColumnName].Visible = false;
                        panel.Columns[LngColumn.ColumnName].Visible = false;
                        panel.Columns[ZoneColumn.ColumnName].Visible = true;
                        panel.Columns[EastColumn.ColumnName].Visible = true;
                        panel.Columns[NorthColumn.ColumnName].Visible = true;
                        panel.Columns[MGRSColumn.ColumnName].Visible = false;
                        break;
                    case CoordSystems.MGRS:
                        panel.Columns[LatColumn.ColumnName].Visible = false;
                        panel.Columns[LngColumn.ColumnName].Visible = false;
                        panel.Columns[ZoneColumn.ColumnName].Visible = false;
                        panel.Columns[EastColumn.ColumnName].Visible = false;
                        panel.Columns[NorthColumn.ColumnName].Visible = false;
                        panel.Columns[MGRSColumn.ColumnName].Visible = true;
                        break;
                    default:
                        panel.Columns[LatColumn.ColumnName].Visible = true;
                        panel.Columns[LngColumn.ColumnName].Visible = true;
                        panel.Columns[ZoneColumn.ColumnName].Visible = false;
                        panel.Columns[EastColumn.ColumnName].Visible = false;
                        panel.Columns[NorthColumn.ColumnName].Visible = false;
                        panel.Columns[MGRSColumn.ColumnName].Visible = false;
                        break;
                }
            }
        }

        private int wpRad = 20;
        public IntegerChangeHandle WPRadChange;
        private void WpRad_ValueChanged(object sender, EventArgs e)
        {
            wpRad = WpRad.Value;
            if (isEdit)
                return;
            WPRadChange?.Invoke(wpRad);
        }

        private Utilities.PointLatLngAlt homePosition = new Utilities.PointLatLngAlt();
        public PositionChangeHandle HomeChange;
        private void HomeLat_ValueChanged(object sender, EventArgs e)
        {
            if (isEdit)
                return;
            HomeChange?.Invoke(homePosition);
        }

        private void HomeLng_ValueChanged(object sender, EventArgs e)
        {
            if (isEdit)
                return;
            HomeChange?.Invoke(homePosition);
        }

        private void HomeAlt_ValueChanged(object sender, EventArgs e)
        {
            if (isEdit)
                return;
            HomeChange?.Invoke(homePosition);
        }

        public void SetHome(Utilities.PointLatLngAlt home)
        {
            StartEdit();
            try
            {
                HomeLat.Value = home.Lat;
                HomeLng.Value = home.Lng;
                HomeAlt.Value = home.Alt;

                homePosition = home;
            }
            finally
            {
                EndEdit();
            }
        }


        private void SetBaseAlt(List<Utilities.PointLatLngAlt> wpList)
        {
            double totalAlt = 0.0;
            double maxAlt = 0.0;
            for(int index =0; index < wpList.Count; index++)
            {
                double terrain = Utilities.srtm.getAltitude(wpList[index].Lat, wpList[index].Lng).alt * CurrentState.multiplieralt;
                totalAlt += terrain;
                if (terrain > maxAlt)
                    maxAlt = terrain;
            }
            BaseAlt.Value = (int)(totalAlt / Math.Max(1, wpList.Count));
            if (isAutoWarn)
                WarnAlt.Value = (int)(maxAlt - baseAlt);
        }

        private void SetCommandParam(DataRow row, Utilities.PointLatLngAlt wp, Utilities.PointLatLngAlt wpLast)
        {
            if (row == null || wp == null || wpLast == null)
                return;
            try
            {
                double terrain = Utilities.srtm.getAltitude(wp.Lat, wp.Lng).alt * CurrentState.multiplieralt;
                switch (wpLast.Tag2)
                {
                    case "Relative":
                        break;
                    case "Absolute":
                        wpLast.Alt = wpLast.Alt - baseAlt;
                        wpLast.Tag2 = "Relative";
                        break;
                    case "Terrain":
                        wpLast.Alt = wpLast.Alt - baseAlt + terrain;
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

                row[GradColumn.ColumnName] = (double)(grad * 100);
                row[AngleColumn.ColumnName] = (double)((180.0 / Math.PI) * Math.Atan(grad));
                row[DistColumn.ColumnName] = (double)(Math.Sqrt(Math.Pow(distance, 2) + Math.Pow(height, 2)) * CurrentState.multiplierdist);
                row[AZColumn.ColumnName] = (double)((angle + 180) % 360);
            }
            catch { }
            finally { }
        }

        public delegate void WPListChangeHandle(List<Utilities.PointLatLngAlt> wpList);
        public WPListChangeHandle WPListChange;

        public List<Utilities.PointLatLngAlt> GetWPList()
        {
            GridPanel panel = CommandDataList.PrimaryGrid;

            List<Utilities.PointLatLngAlt> wpList = new List<Utilities.PointLatLngAlt>();
            for (int index = 0; index < panel.Rows.Count; index++) 
            {
                Utilities.PointLatLngAlt wpPoint = new Utilities.PointLatLngAlt();
                wpPoint.Lat = (double)panel.GetCell(index, panel.Columns[LatColumn.ColumnName].ColumnIndex).Value;
                wpPoint.Lng = (double)panel.GetCell(index, panel.Columns[LngColumn.ColumnName].ColumnIndex).Value;
                wpPoint.Alt = (double)panel.GetCell(index, panel.Columns[RelativeAltColumn.ColumnName].ColumnIndex).Value;
                wpPoint.Tag = panel.GetCell(index, panel.Columns[CommandColumn.ColumnName].ColumnIndex).Value.ToString();
                wpPoint.Tag2 = "Relative";
                wpList.Add(wpPoint);
            }
            return wpList;
        }

        #region interceptSendChange
        public bool isSendChange = true;

        #region 接口函数

        public void InterceptSendListChange()
        {
            isSendChange = false;
        }

        public void AllowSendListChange()
        {
            isSendChange = true;
        }

        #endregion

        #region 判断函数
        private bool IsAllowSendChange()
        {
            return isSendChange;
        }
        #endregion

        #endregion

        private delegate void SetWPListInThread(List<Utilities.PointLatLngAlt> wpList);

        public void SetWPListHandle(List<Utilities.PointLatLngAlt> wpList)
        {
            if (this.InvokeRequired)
            {
                SetWPListInThread inThread = new SetWPListInThread(SetWPListHandle);
                this.Invoke(inThread, new object[] { wpList });
            }
            else
            {
                InterceptSendListChange();
                SetWPList(wpList);
                AllowSendListChange();
            }
        }

        private void SetWPList(List<Utilities.PointLatLngAlt> wpList)
        {
            BindingData(wpList);
        }

        #region 绑定数据
        private void BindingData(List<Utilities.PointLatLngAlt> wpList)
        {
            if (isEdit)
                return;
            try
            {
                StartEdit();

                if (set == null)
                    BindingDataSource();

                if (wpList == null)
                    return;
                else if (wpList.Count <= 0)
                    ;
                else
                {
                    if (wpList[0].Tag.ToLower() == "home" || wpList[0].Tag.ToLower() == "h")
                    {
                        SetHome(wpList[0]);
                        wpList.RemoveAt(0);
                    }
                }

                SetBaseAlt(wpList);

                table.BeginLoadData();
                table.Rows.Clear();

                Utilities.PointLatLngAlt wpLast = homePosition;
                foreach (var wp in wpList)
                {
                    try
                    {
                        DataRow row = table.NewRow();

                        row[CommandColumn] = wp.Tag;
                        if (wp.Tag.ToUpper() == "WAYPOINT" || wp.Tag.ToUpper() == "SPLINE_WAYPOINT")
                        {
                            row[LngColumn] = wp.Lng;
                            row[LatColumn] = wp.Lat;

                            double terrain = Utilities.srtm.getAltitude(wp.Lat, wp.Lng).alt * CurrentState.multiplieralt;
                            switch (wp.Tag2)
                            {
                                case "Relative":
                                    row[RelativeAltColumn] = (int)wp.Alt;
                                    row[AbsoluteAltColumn.ColumnName] = (int)(baseAlt + wp.Alt);
                                    row[TerrainAltColumn.ColumnName] = (int)(baseAlt + wp.Alt - terrain);
                                    break;
                                case "Absolute":
                                    row[AbsoluteAltColumn] = (int)wp.Alt;
                                    row[RelativeAltColumn.ColumnName] = (int)(wp.Alt - baseAlt);
                                    row[TerrainAltColumn.ColumnName] = (int)(wp.Alt - terrain);
                                    break;
                                case "Terrain":
                                    row[TerrainAltColumn] = (int)wp.Alt;
                                    row[RelativeAltColumn.ColumnName] = (int)(wp.Alt - baseAlt + terrain);
                                    row[AbsoluteAltColumn.ColumnName] = (int)(wp.Alt + terrain);
                                    break;
                                default:
                                    row[RelativeAltColumn] = (int)wp.Alt;
                                    row[AbsoluteAltColumn.ColumnName] = (int)(baseAlt + wp.Alt);
                                    row[TerrainAltColumn.ColumnName] = (int)(baseAlt + wp.Alt - terrain);
                                    break;
                            }

                            int zone = wp.GetUTMZone();
                            var temp2 = wp.ToUTM();
                            row[ZoneColumn.ColumnName] = (int)zone;
                            row[EastColumn.ColumnName] = (double)temp2[0];
                            row[NorthColumn.ColumnName] = (double)temp2[1];
                            row[MGRSColumn.ColumnName] = ((MGRS)new Geographic(wp.Lng, wp.Lat)).ToString();

                            SetCommandParam(row, wp, wpLast);
                        }

                        table.Rows.Add(row);

                        row.AcceptChanges();
                    }
                    catch {}
                    finally
                    {
                        if (wp.Tag.ToUpper() == "WAYPOINT" || wp.Tag.ToUpper() == "SPLINE_WAYPOINT")
                        {
                            wpLast = wp;
                        }
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

        #region 绑定数据源格式
        DataSet set = null;
        DataTable table = null;

        const string MainHandle = "Command";
        private void BindingDataSource()
        {
            set = new DataSet(MainHandle);

            table = CreateTable();

            set.Tables.Add(table);

            CommandDataList.PrimaryGrid.DataSource = set;
            CommandDataList.PrimaryGrid.DataMember = WPHandle;
        }
        #endregion

        #region 添加表格格式
        const string CommandColumName = "指令";
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

        DataColumn CommandColumn = new DataColumn(CommandColumName, typeof(string));
        DataColumn LngColumn = new DataColumn(LngColumnName, typeof(double));
        DataColumn LatColumn = new DataColumn(LatColumnName, typeof(double));
        DataColumn ZoneColumn = new DataColumn(ZoneColumnName, typeof(int));
        DataColumn EastColumn = new DataColumn(EastColumnName, typeof(double));
        DataColumn NorthColumn = new DataColumn(NorthColumnName, typeof(double));
        DataColumn MGRSColumn = new DataColumn(MGRSColumnName, typeof(string));
        DataColumn RelativeAltColumn = new DataColumn(RelativeAltColumnName, typeof(int));
        DataColumn AbsoluteAltColumn = new DataColumn(AbsoluteAltColumnName, typeof(int));
        DataColumn TerrainAltColumn = new DataColumn(TerrainAltColumnName, typeof(int));
        DataColumn GradColumn = new DataColumn(GradColumnName, typeof(double));
        DataColumn AngleColumn = new DataColumn(AngleColumnName, typeof(double));
        DataColumn DistColumn = new DataColumn(DistColumnName, typeof(double));
        DataColumn AZColumn = new DataColumn(AZColumnName, typeof(double));
        DataColumn UpColumn = new DataColumn(UpColumnName, typeof(string));
        DataColumn DownColumn = new DataColumn(DownColumnName, typeof(string));
        DataColumn DeleteColumn = new DataColumn(DeleteColumnName, typeof(string));

        const string WPHandle = "WP";
        private DataTable CreateTable()
        {
            DataTable table = new DataTable(WPHandle);

            table.Columns.Add(CommandColumn);

            table.Columns.Add(LngColumn);

            table.Columns.Add(LatColumn);

            table.Columns.Add(ZoneColumn);

            table.Columns.Add(EastColumn);

            table.Columns.Add(NorthColumn);

            table.Columns.Add(MGRSColumn);

            table.Columns.Add(RelativeAltColumn);

            table.Columns.Add(AbsoluteAltColumn);

            table.Columns.Add(TerrainAltColumn);

            table.Columns.Add(GradColumn);

            table.Columns.Add(AngleColumn);

            table.Columns.Add(DistColumn);

            table.Columns.Add(AZColumn);

            table.Columns.Add(UpColumn);

            table.Columns.Add(DownColumn);

            table.Columns.Add(DeleteColumn);

            return table;
        }
        #endregion

        #region 数据绑定完成后的处理函数
        private void CommandDataList_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            GridPanel panel = e.GridPanel;

            switch (panel.DataMember)
            {
                case WPHandle:
                    //CustomizeWPPanel(panel);
                    break;
            }
        }
        #endregion

        enum commands
        {
            WAYPOINT,
            SPLINE_WAYPOINT
        }

        private void InitializeGrid()
        {
            GridPanel panel = CommandDataList.PrimaryGrid;

            panel.ColumnHeader.RowHeight = 30;
            panel.ColumnAutoSizeMode = ColumnAutoSizeMode.Fill;
            panel.MinRowHeight = 25;

            {
                panel.Columns[CommandColumn.ColumnName].AutoSizeMode = ColumnAutoSizeMode.Fill;
                panel.Columns[CommandColumn.ColumnName].FillWeight = 150;
                panel.Columns[CommandColumn.ColumnName].EditorType = typeof(GridControls.FragrantComboBox);
                panel.Columns[CommandColumn.ColumnName].EditorParams = new object[] { Enum.GetValues(typeof(commands)) };
                //panel.Columns[CommandColumn.ColumnName].ReadOnly = true;
            }

            {
                panel.Columns[LatColumn.ColumnName].AutoSizeMode = ColumnAutoSizeMode.Fill;
                panel.Columns[LatColumn.ColumnName].FillWeight = 120;
                panel.Columns[LatColumn.ColumnName].EditorType = typeof(GridDoubleInputEditControl);
                //panel.Columns[LatColumn.ColumnName].ReadOnly = true;
                panel.Columns[LatColumn.ColumnName].Visible = true;
                GridDoubleInputEditControl LatEditControl = (GridDoubleInputEditControl)panel.Columns[LatColumn.ColumnName].EditControl;
                LatEditControl.MaxValue = 90;
                LatEditControl.MinValue = -90;
                GridDoubleInputEditControl LatRenderControl = (GridDoubleInputEditControl)panel.Columns[LatColumn.ColumnName].RenderControl;
                LatRenderControl.DisplayFormat = "0.########";

                panel.Columns[LngColumn.ColumnName].AutoSizeMode = ColumnAutoSizeMode.Fill;
                panel.Columns[LngColumn.ColumnName].FillWeight = 120;
                panel.Columns[LngColumn.ColumnName].EditorType = typeof(GridDoubleInputEditControl);
                //panel.Columns[LngColumn.ColumnName].ReadOnly = true;
                panel.Columns[LngColumn.ColumnName].Visible = true;
                GridDoubleInputEditControl LngEditControl = (GridDoubleInputEditControl)panel.Columns[LngColumn.ColumnName].EditControl;
                LngEditControl.MaxValue = 180;
                LngEditControl.MinValue = -180;
                GridDoubleInputEditControl LngRenderControl = (GridDoubleInputEditControl)panel.Columns[LngColumn.ColumnName].RenderControl;
                LngRenderControl.DisplayFormat = "0.########";
            }

            {
                panel.Columns[ZoneColumn.ColumnName].AutoSizeMode = ColumnAutoSizeMode.Fill;
                panel.Columns[ZoneColumn.ColumnName].FillWeight = 60;
                panel.Columns[ZoneColumn.ColumnName].EditorType = typeof(GridIntegerInputEditControl);
                panel.Columns[ZoneColumn.ColumnName].ReadOnly = true;
                panel.Columns[ZoneColumn.ColumnName].Visible = false;

                panel.Columns[EastColumn.ColumnName].AutoSizeMode = ColumnAutoSizeMode.Fill;
                panel.Columns[EastColumn.ColumnName].FillWeight = 90;
                panel.Columns[EastColumn.ColumnName].EditorType = typeof(GridDoubleInputEditControl);
                panel.Columns[EastColumn.ColumnName].ReadOnly = true;
                panel.Columns[EastColumn.ColumnName].Visible = false;

                panel.Columns[NorthColumn.ColumnName].AutoSizeMode = ColumnAutoSizeMode.Fill;
                panel.Columns[NorthColumn.ColumnName].FillWeight = 90;
                panel.Columns[NorthColumn.ColumnName].EditorType = typeof(GridDoubleInputEditControl);
                panel.Columns[NorthColumn.ColumnName].ReadOnly = true;
                panel.Columns[NorthColumn.ColumnName].Visible = false;
            }

            {
                panel.Columns[MGRSColumn.ColumnName].AutoSizeMode = ColumnAutoSizeMode.Fill;
                panel.Columns[MGRSColumn.ColumnName].FillWeight = 240;
                panel.Columns[MGRSColumn.ColumnName].EditorType = typeof(GridTextBoxXEditControl);
                panel.Columns[MGRSColumn.ColumnName].ReadOnly = true;
                panel.Columns[MGRSColumn.ColumnName].Visible = false;
            }

            {
                panel.Columns[RelativeAltColumn.ColumnName].AutoSizeMode = ColumnAutoSizeMode.Fill;
                panel.Columns[RelativeAltColumn.ColumnName].FillWeight = 80;
                panel.Columns[RelativeAltColumn.ColumnName].EditorType = typeof(GridIntegerInputEditControl);
                //panel.Columns[RelativeAltColumn.ColumnName].ReadOnly = true;
                panel.Columns[RelativeAltColumn.ColumnName].Visible = true;

                panel.Columns[AbsoluteAltColumn.ColumnName].AutoSizeMode = ColumnAutoSizeMode.Fill;
                panel.Columns[AbsoluteAltColumn.ColumnName].FillWeight = 80;
                panel.Columns[AbsoluteAltColumn.ColumnName].EditorType = typeof(GridIntegerInputEditControl);
                //panel.Columns[AbsoluteAltColumn.ColumnName].ReadOnly = true;
                panel.Columns[AbsoluteAltColumn.ColumnName].Visible = false;

                panel.Columns[TerrainAltColumn.ColumnName].AutoSizeMode = ColumnAutoSizeMode.Fill;
                panel.Columns[TerrainAltColumn.ColumnName].FillWeight = 80;
                panel.Columns[TerrainAltColumn.ColumnName].EditorType = typeof(GridIntegerInputEditControl);
                //panel.Columns[TerrainAltColumn.ColumnName].ReadOnly = true;
                panel.Columns[TerrainAltColumn.ColumnName].Visible = false;
            }

            {
                panel.Columns[GradColumn.ColumnName].AutoSizeMode = ColumnAutoSizeMode.Fill;
                panel.Columns[GradColumn.ColumnName].FillWeight = 80;
                panel.Columns[GradColumn.ColumnName].EditorType = typeof(GridDoubleInputEditControl);
                panel.Columns[GradColumn.ColumnName].ReadOnly = true;

                panel.Columns[AngleColumn.ColumnName].AutoSizeMode = ColumnAutoSizeMode.Fill;
                panel.Columns[AngleColumn.ColumnName].FillWeight = 80;
                panel.Columns[AngleColumn.ColumnName].EditorType = typeof(GridDoubleInputEditControl);
                panel.Columns[AngleColumn.ColumnName].ReadOnly = true;

                panel.Columns[DistColumn.ColumnName].AutoSizeMode = ColumnAutoSizeMode.Fill;
                panel.Columns[DistColumn.ColumnName].FillWeight = 80;
                panel.Columns[DistColumn.ColumnName].EditorType = typeof(GridDoubleInputEditControl);
                panel.Columns[DistColumn.ColumnName].ReadOnly = true;

                panel.Columns[AZColumn.ColumnName].AutoSizeMode = ColumnAutoSizeMode.Fill;
                panel.Columns[AZColumn.ColumnName].FillWeight = 80;
                panel.Columns[AZColumn.ColumnName].EditorType = typeof(GridDoubleInputEditControl);
                panel.Columns[AZColumn.ColumnName].ReadOnly = true;
            }

            {
                panel.Columns[UpColumn.ColumnName].AutoSizeMode = ColumnAutoSizeMode.None;
                panel.Columns[UpColumn.ColumnName].MinimumWidth = 25;
                panel.Columns[UpColumn.ColumnName].Width = 25;
                panel.Columns[UpColumn.ColumnName].EditorType = typeof(GridControls.ImagePanel);
                panel.Columns[UpColumn.ColumnName].EditorParams = new object[] { ImageList.Images["Up.png"] };

                panel.Columns[DownColumn.ColumnName].AutoSizeMode = ColumnAutoSizeMode.None;
                panel.Columns[DownColumn.ColumnName].MinimumWidth = 25;
                panel.Columns[DownColumn.ColumnName].Width = 25;
                panel.Columns[DownColumn.ColumnName].EditorType = typeof(GridControls.ImagePanel);
                panel.Columns[DownColumn.ColumnName].EditorParams = new object[] { ImageList.Images["Down.png"] };

                panel.Columns[DeleteColumn.ColumnName].AutoSizeMode = ColumnAutoSizeMode.None;
                panel.Columns[DeleteColumn.ColumnName].MinimumWidth = 25;
                panel.Columns[DeleteColumn.ColumnName].Width = 25;
                panel.Columns[DeleteColumn.ColumnName].EditorType = typeof(GridControls.ImagePanel);
                panel.Columns[DeleteColumn.ColumnName].EditorParams = new object[] { ImageList.Images["Delete.png"] };
            }
        }

        private void WPDefaultValuePanel(GridPanel panel)
        {
        }

        private void CommandDataList_RowSetDefaultValues(object sender, GridRowSetDefaultValuesEventArgs e)
        {
            GridPanel panel = e.GridPanel;
            switch (panel.DataMember)
            {
                case WPHandle:
                    WPDefaultValuePanel(panel);
                    break;
            }

        }

        private void CommandsPanel_Load(object sender, EventArgs e)
        {
            StartEdit();
            try
            {
                InitializeGrid();

                InitAltFrame();
                InitCoordSystem();
                InitParam();
            }
            finally
            {
                EndEdit();
            }
        }

        private void CommandDataList_CellClick(object sender, GridCellClickEventArgs e)
        {
            GridPanel panel = e.GridPanel;
            GridCell cell = e.GridCell;

            if (cell != null)
            {
                int rowIndex = cell.GridRow.Index;
                var row = cell.GridRow;
                switch (cell.GridColumn.Name)
                {
                    case UpColumnName:
                        if (rowIndex > 0)
                        {
                            panel.Rows.RemoveAt(rowIndex);
                            panel.Rows.Insert(rowIndex - 1, row);

                            WPListChange?.Invoke(GetWPList());
                        }
                        break;
                    case DownColumnName:
                        if (rowIndex < panel.Rows.Count - 1)
                        {
                            panel.Rows.RemoveAt(rowIndex);
                            panel.Rows.Insert(rowIndex + 1, row);

                            WPListChange?.Invoke(GetWPList());
                        }
                        break;
                    case DeleteColumnName:
                        panel.Rows.RemoveAt(rowIndex);
                        WPListChange?.Invoke(GetWPList());
                        break;
                }

            }
        }
    }


}
