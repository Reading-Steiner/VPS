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
                BindingData(new List<Utilities.PointLatLngAlt>());

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

        private void SetCommandParam(List<Utilities.PointLatLngAlt> wpList)
        {
            SetBaseAlt(wpList);

            GridPanel panel = CommandDataList.PrimaryGrid;

            if (panel != null)
            {
                Utilities.PointLatLngAlt wpLast = homePosition;
                switch (wpLast.Tag2)
                {
                    case "Relative":
                        break;
                    case "Absolute":
                        wpLast.Alt = wpLast.Alt - baseAlt;
                        wpLast.Tag2 = "Relative";
                        break;
                    case "Terrain":
                        wpLast.Alt =
                            wpLast.Alt - baseAlt +
                            Utilities.srtm.getAltitude(wpLast.Lat, wpLast.Lng).alt * CurrentState.multiplieralt;
                        wpLast.Tag2 = "Relative";
                        break;
                    default:
                        wpLast.Tag2 = "Relative";
                        break;
                }

                int index = 0;
                foreach (var wp in wpList)
                {
                    if (wp == null)
                        continue;
                    try
                    {
                        if (wp.Tag.ToUpper() == "WAYPOINT" || wp.Tag.ToUpper() == "SPLINE_WAYPOINT")
                        {
                            int zone = wp.GetUTMZone();
                            var temp2 = wp.ToUTM();
                            panel.GetCell(index, panel.Columns[ZoneColumn.ColumnName].ColumnIndex).Value =
                                zone;
                            panel.GetCell(index, panel.Columns[EastColumn.ColumnName].ColumnIndex).Value =
                                temp2[0];
                            panel.GetCell(index, panel.Columns[NorthColumn.ColumnName].ColumnIndex).Value =
                                temp2[1];

                            panel.GetCell(index, panel.Columns[MGRSColumn.ColumnName].ColumnIndex).Value =
                                ((MGRS)new Geographic(wp.Lng, wp.Lat));

                            double terrain = Utilities.srtm.getAltitude(wp.Lat, wp.Lng).alt * CurrentState.multiplieralt;
                            switch (wp.Tag2)
                            {
                                case "Relative":
                                    panel.GetCell(index, panel.Columns[AbsoluteAltColumn.ColumnName].ColumnIndex).Value =
                                        (int)(baseAlt + wp.Alt);
                                    panel.GetCell(index, panel.Columns[TerrainAltColumn.ColumnName].ColumnIndex).Value =
                                        (int)(baseAlt + wp.Alt - terrain);
                                    break;
                                case "Absolute":
                                    panel.GetCell(index, panel.Columns[RelativeAltColumn.ColumnName].ColumnIndex).Value =
                                        (int)(wp.Alt - baseAlt);
                                    panel.GetCell(index, panel.Columns[TerrainAltColumn.ColumnName].ColumnIndex).Value =
                                        (int)(wp.Alt - terrain);
                                    wp.Alt = wp.Alt - baseAlt;
                                    wp.Tag2 = "Relative";
                                    break;
                                case "Terrain":
                                    panel.GetCell(index, panel.Columns[RelativeAltColumn.ColumnName].ColumnIndex).Value =
                                        (int)(wp.Alt - baseAlt + terrain);
                                    panel.GetCell(index, panel.Columns[AbsoluteAltColumn.ColumnName].ColumnIndex).Value =
                                        (int)(wp.Alt + terrain);
                                    wp.Alt = wp.Alt - baseAlt + terrain;
                                    wp.Tag2 = "Relative";
                                    break;
                                default:
                                    panel.GetCell(index, panel.Columns[AbsoluteAltColumn.ColumnName].ColumnIndex).Value =
                                        (int)(baseAlt + wp.Alt);
                                    panel.GetCell(index, panel.Columns[TerrainAltColumn.ColumnName].ColumnIndex).Value =
                                        (int)(baseAlt + wp.Alt - terrain);
                                    wp.Tag2 = "Relative";
                                    break;
                            }


                            double height = wp.Alt - wpLast.Alt;
                            double distance = wp.GetDistance(wpLast);
                            double grad = height / distance;

                            panel.GetCell(index, panel.Columns[GradColumn.ColumnName].ColumnIndex).Value =
                                (grad * 100);

                            panel.GetCell(index, panel.Columns[AngleColumn.ColumnName].ColumnIndex).Value =
                                ((180.0 / Math.PI) * Math.Atan(grad));

                            panel.GetCell(index, panel.Columns[DistColumn.ColumnName].ColumnIndex).Value =
                                (Math.Sqrt(Math.Pow(distance, 2) + Math.Pow(height, 2)) * CurrentState.multiplierdist);

                            panel.GetCell(index, panel.Columns[AZColumn.ColumnName].ColumnIndex).Value =
                                ((wp.GetBearing(wpLast) + 180) % 360);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        wpLast = wp;
                        index++;
                    }
                }
            }
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

        //#region 单元格点击
        //private void CommandDataList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    DataGridViewButtonXCell cell = CommandDataList.CurrentCell as DataGridViewButtonXCell;

        //    if (cell != null)
        //    {
        //        DataGridViewButtonXColumn bc =
        //            CommandDataList.Columns[e.ColumnIndex] as DataGridViewButtonXColumn;

        //        if (bc != null)
        //        {
        //            var index = cell.RowIndex;
        //            var row = cell.OwningRow;

        //            switch (bc.Name)
        //            {
        //                case "Up":
        //                    if (index > 0)
        //                    {
        //                        CommandDataList.Rows.RemoveAt(index);
        //                        CommandDataList.Rows.Insert(index - 1, row);

        //                        WPListChange?.Invoke(GetWPList());
        //                    }
        //                    break;
        //                case "Down":
        //                    if(index < CommandDataList.Rows.Count - 1)
        //                    {
        //                        CommandDataList.Rows.RemoveAt(index);
        //                        CommandDataList.Rows.Insert(index + 1, row);

        //                        WPListChange?.Invoke(GetWPList());
        //                    }
        //                    break;
        //                case "Delete":
        //                    CommandDataList.Rows.RemoveAt(index);
        //                    WPListChange?.Invoke(GetWPList());
        //                    break;
        //            }
        //        }
        //    }
        //}
        //#endregion

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
                    if (wpList[0].Tag.ToLower() == "home")
                    {
                        SetHome(wpList[0]);
                        wpList.RemoveAt(0);
                    }
                }

                table.BeginLoadData();

                table.Rows.Clear();
                foreach (var wp in wpList)
                {
                    DataRow row = table.NewRow();

                    row[CommandColumn] = wp.Tag;
                    row[LngColumn] = wp.Lng;
                    row[LatColumn] = wp.Lat;
                    switch (wp.Tag2)
                    {
                        case "Relative":
                            row[RelativeAltColumn] = wp.Alt;
                            break;
                        case "Absolute":
                            row[AbsoluteAltColumn] = wp.Alt;
                            break;
                        case "Terrain":
                            row[TerrainAltColumn] = wp.Alt;
                            break;
                        default:
                            row[RelativeAltColumn] = wp.Alt;
                            break;
                    }

                    table.Rows.Add(row);

                    row.AcceptChanges();
                }
                if (wpList.Count > 0)
                    SetCommandParam(wpList);
                
            }
            catch(Exception ex)
            {

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
        DataColumn CommandColumn = new DataColumn();
        DataColumn LngColumn = new DataColumn();
        DataColumn LatColumn = new DataColumn();
        DataColumn RelativeAltColumn = new DataColumn();
        DataColumn AbsoluteAltColumn = new DataColumn();
        DataColumn TerrainAltColumn = new DataColumn();
        DataColumn ZoneColumn = new DataColumn();
        DataColumn EastColumn = new DataColumn();
        DataColumn NorthColumn = new DataColumn();
        DataColumn MGRSColumn = new DataColumn();
        DataColumn GradColumn = new DataColumn();
        DataColumn AngleColumn = new DataColumn();
        DataColumn DistColumn = new DataColumn();
        DataColumn AZColumn = new DataColumn();
        DataColumn UpColumn = new DataColumn();
        DataColumn DownColumn = new DataColumn();
        DataColumn DeleteColumn = new DataColumn();

        const string WPHandle = "WP";
        private DataTable CreateTable()
        {
            DataTable table = new DataTable(WPHandle);

            CommandColumn.ColumnName = "指令";
            CommandColumn.DataType = typeof(string);
            table.Columns.Add(CommandColumn);

            LngColumn.ColumnName = "经度";
            LngColumn.DataType = typeof(double);
            table.Columns.Add(LngColumn);

            LatColumn.ColumnName = "纬度";
            LatColumn.DataType = typeof(double);
            table.Columns.Add(LatColumn);

            ZoneColumn.ColumnName = "区";
            ZoneColumn.DataType = typeof(int);
            table.Columns.Add(ZoneColumn);

            EastColumn.ColumnName = "东";
            EastColumn.DataType = typeof(double);
            table.Columns.Add(EastColumn);

            NorthColumn.ColumnName = "北";
            NorthColumn.DataType = typeof(double);
            table.Columns.Add(NorthColumn);

            MGRSColumn.ColumnName = "MGRS";
            MGRSColumn.DataType = typeof(string);
            table.Columns.Add(MGRSColumn);

            RelativeAltColumn.ColumnName = "相对高度";
            RelativeAltColumn.DataType = typeof(int);
            table.Columns.Add(RelativeAltColumn);

            AbsoluteAltColumn.ColumnName = "绝对高度";
            AbsoluteAltColumn.DataType = typeof(int);
            table.Columns.Add(AbsoluteAltColumn);

            TerrainAltColumn.ColumnName = "地面高度";
            TerrainAltColumn.DataType = typeof(int);
            table.Columns.Add(TerrainAltColumn);

            GradColumn.ColumnName = "坡度";
            GradColumn.DataType = typeof(double);
            table.Columns.Add(GradColumn);

            AngleColumn.ColumnName = "角度";
            AngleColumn.DataType = typeof(double);
            table.Columns.Add(AngleColumn);

            DistColumn.ColumnName = "距离";
            DistColumn.DataType = typeof(double);
            table.Columns.Add(DistColumn);

            AZColumn.ColumnName = "方位";
            AZColumn.DataType = typeof(double);
            table.Columns.Add(AZColumn);

            UpColumn.ColumnName = "上移";
            UpColumn.DataType = typeof(GridLabelXEditControl);
            table.Columns.Add(UpColumn);

            DownColumn.ColumnName = "下移";
            DownColumn.DataType = typeof(GridLabelXEditControl);
            table.Columns.Add(DownColumn);

            DeleteColumn.ColumnName = "删除";
            DeleteColumn.DataType = typeof(GridLabelXEditControl);
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
                    CustomizeWPPanel(panel);
                    break;
            }
        }
        #endregion

        enum commands
        {
            WAYPOINT,
            SPLINE_WAYPOINT
        }

        private void CustomizeWPPanel(GridPanel panel)
        {
            panel.FrozenColumnCount = 1;
            panel.ColumnHeader.RowHeight = 30;
            panel.MinRowHeight = 25;

            {
                panel.Columns[CommandColumn.ColumnName].AutoSizeMode = ColumnAutoSizeMode.Fill;
                panel.Columns[CommandColumn.ColumnName].MinimumWidth = 200;
                panel.Columns[CommandColumn.ColumnName].EditorType = typeof(GridControls.FragrantComboBox);
                panel.Columns[CommandColumn.ColumnName].EditorParams = new object[] { Enum.GetValues(typeof(commands)) };
                //panel.Columns[CommandColumn.ColumnName].ReadOnly = true;
            }

            {
                panel.Columns[LatColumn.ColumnName].AutoSizeMode = ColumnAutoSizeMode.Fill;
                panel.Columns[LatColumn.ColumnName].MinimumWidth = 120;
                panel.Columns[LatColumn.ColumnName].EditorType = typeof(GridDoubleInputEditControl);
                //panel.Columns[LatColumn.ColumnName].ReadOnly = true;
                panel.Columns[LatColumn.ColumnName].Visible = true;
                GridDoubleInputEditControl LatControl = (GridDoubleInputEditControl)panel.Columns[LatColumn.ColumnName].EditControl;
                LatControl.DisplayFormat = "0.########";
                LatControl.MaxValue = 90;
                LatControl.MinValue = -90;

                panel.Columns[LngColumn.ColumnName].AutoSizeMode = ColumnAutoSizeMode.Fill;
                panel.Columns[LngColumn.ColumnName].MinimumWidth = 120;
                panel.Columns[LngColumn.ColumnName].EditorType = typeof(GridDoubleInputEditControl);
                //panel.Columns[LngColumn.ColumnName].ReadOnly = true;
                panel.Columns[LngColumn.ColumnName].Visible = true;
                GridDoubleInputEditControl LngControl = (GridDoubleInputEditControl)panel.Columns[LngColumn.ColumnName].EditControl;
                LngControl.DisplayFormat = "0.########";
                LngControl.MaxValue = 180;
                LngControl.MinValue = -180;
            }

            {
                panel.Columns[ZoneColumn.ColumnName].AutoSizeMode = ColumnAutoSizeMode.Fill;
                panel.Columns[ZoneColumn.ColumnName].MinimumWidth = 60;
                panel.Columns[ZoneColumn.ColumnName].EditorType = typeof(GridIntegerInputEditControl);
                panel.Columns[ZoneColumn.ColumnName].ReadOnly = true;
                panel.Columns[ZoneColumn.ColumnName].Visible = false;

                panel.Columns[EastColumn.ColumnName].AutoSizeMode = ColumnAutoSizeMode.Fill;
                panel.Columns[EastColumn.ColumnName].MinimumWidth = 90;
                panel.Columns[EastColumn.ColumnName].EditorType = typeof(GridDoubleInputEditControl);
                panel.Columns[EastColumn.ColumnName].ReadOnly = true;
                panel.Columns[EastColumn.ColumnName].Visible = false;

                panel.Columns[NorthColumn.ColumnName].AutoSizeMode = ColumnAutoSizeMode.Fill;
                panel.Columns[NorthColumn.ColumnName].MinimumWidth = 90;
                panel.Columns[NorthColumn.ColumnName].EditorType = typeof(GridDoubleInputEditControl);
                panel.Columns[NorthColumn.ColumnName].ReadOnly = true;
                panel.Columns[NorthColumn.ColumnName].Visible = false;
            }

            {
                panel.Columns[MGRSColumn.ColumnName].AutoSizeMode = ColumnAutoSizeMode.Fill;
                panel.Columns[MGRSColumn.ColumnName].MinimumWidth = 240;
                panel.Columns[MGRSColumn.ColumnName].EditorType = typeof(GridTextBoxXEditControl);
                panel.Columns[MGRSColumn.ColumnName].ReadOnly = true;
                panel.Columns[MGRSColumn.ColumnName].Visible = false;
            }

            {
                panel.Columns[RelativeAltColumn.ColumnName].AutoSizeMode = ColumnAutoSizeMode.Fill;
                panel.Columns[RelativeAltColumn.ColumnName].MinimumWidth = 80;
                panel.Columns[RelativeAltColumn.ColumnName].EditorType = typeof(GridIntegerInputEditControl);
                //panel.Columns[RelativeAltColumn.ColumnName].ReadOnly = true;
                panel.Columns[RelativeAltColumn.ColumnName].Visible = true;

                panel.Columns[AbsoluteAltColumn.ColumnName].AutoSizeMode = ColumnAutoSizeMode.Fill;
                panel.Columns[AbsoluteAltColumn.ColumnName].MinimumWidth = 80;
                panel.Columns[AbsoluteAltColumn.ColumnName].EditorType = typeof(GridIntegerInputEditControl);
                //panel.Columns[AbsoluteAltColumn.ColumnName].ReadOnly = true;
                panel.Columns[AbsoluteAltColumn.ColumnName].Visible = false;

                panel.Columns[TerrainAltColumn.ColumnName].AutoSizeMode = ColumnAutoSizeMode.Fill;
                panel.Columns[TerrainAltColumn.ColumnName].MinimumWidth = 80;
                panel.Columns[TerrainAltColumn.ColumnName].EditorType = typeof(GridIntegerInputEditControl);
                //panel.Columns[TerrainAltColumn.ColumnName].ReadOnly = true;
                panel.Columns[TerrainAltColumn.ColumnName].Visible = false;
            }

            {
                panel.Columns[GradColumn.ColumnName].AutoSizeMode = ColumnAutoSizeMode.Fill;
                panel.Columns[GradColumn.ColumnName].MinimumWidth = 80;
                panel.Columns[GradColumn.ColumnName].EditorType = typeof(GridDoubleInputEditControl);
                panel.Columns[GradColumn.ColumnName].ReadOnly = true;
                panel.Columns[GradColumn.ColumnName].Visible = false;

                panel.Columns[AngleColumn.ColumnName].AutoSizeMode = ColumnAutoSizeMode.Fill;
                panel.Columns[AngleColumn.ColumnName].MinimumWidth = 80;
                panel.Columns[AngleColumn.ColumnName].EditorType = typeof(GridDoubleInputEditControl);
                panel.Columns[AngleColumn.ColumnName].ReadOnly = true;
                panel.Columns[AngleColumn.ColumnName].Visible = false;

                panel.Columns[DistColumn.ColumnName].AutoSizeMode = ColumnAutoSizeMode.Fill;
                panel.Columns[DistColumn.ColumnName].MinimumWidth = 80;
                panel.Columns[DistColumn.ColumnName].EditorType = typeof(GridDoubleInputEditControl);
                panel.Columns[DistColumn.ColumnName].ReadOnly = true;
                panel.Columns[DistColumn.ColumnName].Visible = false;

                panel.Columns[AZColumn.ColumnName].AutoSizeMode = ColumnAutoSizeMode.Fill;
                panel.Columns[AZColumn.ColumnName].MinimumWidth = 80;
                panel.Columns[AZColumn.ColumnName].EditorType = typeof(GridDoubleInputEditControl);
                panel.Columns[AZColumn.ColumnName].ReadOnly = true;
                panel.Columns[AZColumn.ColumnName].Visible = false;
            }

            {
                panel.Columns[UpColumn.ColumnName].MinimumWidth = 25;
                panel.Columns[UpColumn.ColumnName].Width = 25;
                panel.Columns[UpColumn.ColumnName].EditorType = typeof(GridControls.ImagePanel);
                panel.Columns[UpColumn.ColumnName].EditorParams = new object[] { ImageList.Images["Up.png"] };

                panel.Columns[DownColumn.ColumnName].MinimumWidth = 25;
                panel.Columns[DownColumn.ColumnName].Width = 25;
                panel.Columns[DownColumn.ColumnName].EditorType = typeof(GridControls.ImagePanel);
                panel.Columns[DownColumn.ColumnName].EditorParams = new object[] { ImageList.Images["Down.png"] };

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
                InitAltFrame();
                InitCoordSystem();
                InitParam();
            }
            finally
            {
                EndEdit();
            }
        }
    }


}
