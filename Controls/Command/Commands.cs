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

namespace VPS.Controls.Command
{
    public partial class CommandsPanel : UserControl
    {
        public static CommandsPanel instance = null;

        public CommandsPanel()
        {
            StartEdit();
            InitializeComponent();
            InitAltFrame();
            InitCoordSystem();
            InitParam();
            instance = this;
            EndEdit();
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
            switch (currentFrame)
            {
                case AltFrames.Relative:
                    CommandDataList.Columns[RelativeAlt.Index].Visible = true;
                    CommandDataList.Columns[AbsoluteAlt.Index].Visible = false;
                    CommandDataList.Columns[TerrainAlt.Index].Visible = false;
                    break;
                case AltFrames.Absolute:
                    CommandDataList.Columns[RelativeAlt.Index].Visible = false;
                    CommandDataList.Columns[AbsoluteAlt.Index].Visible = true;
                    CommandDataList.Columns[TerrainAlt.Index].Visible = false;
                    break;
                case AltFrames.Terrain:
                    CommandDataList.Columns[RelativeAlt.Index].Visible = false;
                    CommandDataList.Columns[AbsoluteAlt.Index].Visible = false;
                    CommandDataList.Columns[TerrainAlt.Index].Visible = true;
                    break;
                default:
                    CommandDataList.Columns[RelativeAlt.Index].Visible = true;
                    CommandDataList.Columns[AbsoluteAlt.Index].Visible = false;
                    CommandDataList.Columns[TerrainAlt.Index].Visible = false;
                    break;
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
            switch (currentCoord)
            {
                case CoordSystems.WGS84:
                    CommandDataList.Columns[Lat.Index].Visible = true;
                    CommandDataList.Columns[Lon.Index].Visible = true;
                    CommandDataList.Columns[Zone.Index].Visible = false;
                    CommandDataList.Columns[East.Index].Visible = false;
                    CommandDataList.Columns[North.Index].Visible = false;
                    CommandDataList.Columns[MGRS.Index].Visible = false;
                    break;
                case CoordSystems.UTM:
                    CommandDataList.Columns[Lat.Index].Visible = false;
                    CommandDataList.Columns[Lon.Index].Visible = false;
                    CommandDataList.Columns[Zone.Index].Visible = true;
                    CommandDataList.Columns[East.Index].Visible = true;
                    CommandDataList.Columns[North.Index].Visible = true;
                    CommandDataList.Columns[MGRS.Index].Visible = false;
                    break;
                case CoordSystems.MGRS:
                    CommandDataList.Columns[Lat.Index].Visible = false;
                    CommandDataList.Columns[Lon.Index].Visible = false;
                    CommandDataList.Columns[Zone.Index].Visible = false;
                    CommandDataList.Columns[East.Index].Visible = false;
                    CommandDataList.Columns[North.Index].Visible = false;
                    CommandDataList.Columns[MGRS.Index].Visible = true;
                    break;
                default:
                    CommandDataList.Columns[Lat.Index].Visible = true;
                    CommandDataList.Columns[Lon.Index].Visible = true;
                    CommandDataList.Columns[Zone.Index].Visible = false;
                    CommandDataList.Columns[East.Index].Visible = false;
                    CommandDataList.Columns[North.Index].Visible = false;
                    CommandDataList.Columns[MGRS.Index].Visible = false;
                    break;
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
            homePosition.Lat = HomeLat.Value;
            if (isEdit)
                return;
            HomeChange?.Invoke(homePosition);
        }

        private void HomeLng_ValueChanged(object sender, EventArgs e)
        {
            homePosition.Lng = HomeLng.Value;
            if (isEdit)
                return;
            HomeChange?.Invoke(homePosition);
        }

        private void HomeAlt_ValueChanged(object sender, EventArgs e)
        {
            homePosition.Alt = HomeAlt.Value;
            if (isEdit)
                return;
            HomeChange?.Invoke(homePosition);
        }

        public void SetHome(Utilities.PointLatLngAlt home)
        {
            StartEdit();
            HomeLat.Value = home.Lat;
            HomeLng.Value = home.Lng;
            HomeAlt.Value = home.Alt;
            EndEdit();
        }

        private void AddWPPoint(int index, Utilities.PointLatLngAlt wp)
        {
            if (index < CommandDataList.Rows.Count)
                FillWPPoint(index, wp);
            else
            {
                index = CommandDataList.Rows.Add();
                FillWPPoint(index, wp);
            }
        }

        private void DeleteWPPoint(int index)
        {
            if (index >= 0 && index < CommandDataList.Rows.Count)
                CommandDataList.Rows.RemoveAt(index);
        }

        private void FillWPPoint(int index, Utilities.PointLatLngAlt wp)
        {
            CommandDataList.Rows[index].Cells[Command.Index].Value = wp.Tag;

            CommandDataList[Command.Index, index].Value = wp.Tag;
            switch (wp.Tag)
            {
                case "WAYPOINT":
                    {
                        CommandDataList[Lat.Index, index].Value = wp.Lat;
                        CommandDataList[Lon.Index, index].Value = wp.Lng;
                        SetAltitude(index, wp);
                        int zone = wp.GetUTMZone();
                        var utm = wp.ToUTM();
                        CommandDataList[Zone.Index, index].Value = zone;
                        CommandDataList[East.Index, index].Value = utm[0];
                        CommandDataList[North.Index, index].Value = utm[1];

                        CommandDataList[MGRS.Index, index].Value = ((MGRS)new Geographic(wp.Lng, wp.Lat));
                    }
                    break;
                default:
                    {
                        CommandDataList[Lat.Index, index].Value = wp.Lat;
                        CommandDataList[Lon.Index, index].Value = wp.Lng;
                        switch (wp.Tag2.ToLower())
                        {
                            case "relative":
                                CommandDataList[RelativeAlt.Index, index].Value = wp.Alt;
                                break;
                            case "absolute":
                                CommandDataList[AbsoluteAlt.Index, index].Value = wp.Alt;
                                break;
                            case "terrain":
                                CommandDataList[TerrainAlt.Index, index].Value = wp.Alt;
                                break;
                            default:
                                CommandDataList[RelativeAlt.Index, index].Value = wp.Alt;
                                break;
                        }
                        int zone = wp.GetUTMZone();
                        var utm = wp.ToUTM();
                        CommandDataList[Zone.Index, index].Value = zone;
                        CommandDataList[East.Index, index].Value = utm[0];
                        CommandDataList[North.Index, index].Value = utm[1];

                        CommandDataList[MGRS.Index, index].Value = ((MGRS)new Geographic(wp.Lng, wp.Lat));
                    }
                    break;
            }
                
                

                
            switch (wp.Tag2)
            {
                case "Relative":
                    CommandDataList[RelativeAlt.Index, index].Value = wp.Alt;
                    CommandDataList[Frame.Index, index].Value = wp.Tag2;
                    break;
                case "Absolute":
                    CommandDataList[AbsoluteAlt.Index, index].Value = wp.Alt;
                    CommandDataList[Frame.Index, index].Value = wp.Tag2;
                    break;
                case "Terrain":
                    CommandDataList[TerrainAlt.Index, index].Value = wp.Alt;
                    CommandDataList[Frame.Index, index].Value = wp.Tag2;
                    break;
                default:
                    CommandDataList[RelativeAlt.Index, index].Value = wp.Alt;
                    CommandDataList[Frame.Index, index].Value = wp.Tag2;
                    break;

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

        private void SetAltitude(int index, Utilities.PointLatLngAlt wp)
        {

            double terrain = Utilities.srtm.getAltitude(wp.Lat, wp.Lng).alt * CurrentState.multiplieralt;
            switch (wp.Tag2)
            {
                case "Relative":
                    CommandDataList[RelativeAlt.Index, index].Value = wp.Alt;
                    CommandDataList[AbsoluteAlt.Index, index].Value = wp.Alt + baseAlt;
                    CommandDataList[TerrainAlt.Index, index].Value = wp.Alt + baseAlt - terrain;
                    break;
                case "Absolute":
                    CommandDataList[RelativeAlt.Index, index].Value = wp.Alt - baseAlt;
                    CommandDataList[AbsoluteAlt.Index, index].Value = wp.Alt;
                    CommandDataList[TerrainAlt.Index, index].Value = wp.Alt - terrain;
                    break;
                case "Terrain":
                    CommandDataList[RelativeAlt.Index, index].Value = wp.Alt + terrain - baseAlt;
                    CommandDataList[AbsoluteAlt.Index, index].Value = wp.Alt + terrain;
                    CommandDataList[TerrainAlt.Index, index].Value = wp.Alt;
                    break;
                default:
                    CommandDataList[RelativeAlt.Index, index].Value = wp.Alt;
                    CommandDataList[AbsoluteAlt.Index, index].Value = wp.Alt + baseAlt;
                    CommandDataList[TerrainAlt.Index, index].Value = wp.Alt + baseAlt - terrain;
                    break;
            }


        }

        private void SetWpListParam(List<Utilities.PointLatLngAlt> wpList)
        {
            if (wpList.Count > 0)
            {
                double height = wpList[0].Alt - homePosition.Alt;
                double distance = wpList[0].GetDistance(homePosition);
                double grad = height / distance;

                CommandDataList[Grad.Index, 0].Value = (grad * 100);
                CommandDataList[Angle.Index, 0].Value = ((180.0 / Math.PI) * Math.Atan(grad));
                CommandDataList[Dist.Index, 0].Value = (Math.Sqrt(Math.Pow(distance, 2) + Math.Pow(height, 2)) * CurrentState.multiplierdist);
                CommandDataList[AZ.Index, 0].Value = ((wpList[0].GetBearing(homePosition) + 180) % 360);
            }

            for(int index = 1; index < wpList.Count; index++)
            {
                double height = wpList[index].Alt - wpList[index - 1].Alt;
                double distance = wpList[index].GetDistance(wpList[index - 1]);
                double grad = height / distance;

                CommandDataList[Grad.Index, index].Value = (grad * 100);
                CommandDataList[Angle.Index, index].Value = ((180.0 / Math.PI) * Math.Atan(grad));
                CommandDataList[Dist.Index, index].Value = (Math.Sqrt(Math.Pow(distance, 2) + Math.Pow(height, 2)) * CurrentState.multiplierdist);
                CommandDataList[AZ.Index, index].Value = ((wpList[index].GetBearing(wpList[index - 1]) + 180) % 360);
            }
        }

        public delegate void WPListChangeHandle(List<Utilities.PointLatLngAlt> wpList);
        public WPListChangeHandle WPListChange;

        private List<Utilities.PointLatLngAlt> GetWPList()
        {
            List<Utilities.PointLatLngAlt> wpList = new List<Utilities.PointLatLngAlt>();
            for (int index  = 0; index < CommandDataList.Rows.Count;index++)
            {
                Utilities.PointLatLngAlt wpPoint = new Utilities.PointLatLngAlt();
                wpPoint.Lat = (double)CommandDataList[Lat.Index, index].Value;
                wpPoint.Lng = (double)CommandDataList[Lon.Index, index].Value;
                wpPoint.Alt = (double)CommandDataList[RelativeAlt.Index, index].Value;
                wpPoint.Tag = CommandDataList[Command.Index, index].Value.ToString();
                wpPoint.Tag2 = "Relative";
                wpList.Add(wpPoint);
            }
            return wpList;
        }

        public void SetWPList(List<Utilities.PointLatLngAlt> wpList)
        {
            SetBaseAlt(wpList);
            StartEdit();
            
            int count = CommandDataList.Rows.Count;
            int index = 0;
            for (; index < wpList.Count; index++)
            {
                AddWPPoint(index, wpList[index]);
            }
            while (index < count)
            {
                DeleteWPPoint(index);
                count--;
            }
            
            EndEdit();

            SetWpListParam(wpList);

        }

        private void CommandDataList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewButtonXCell cell = CommandDataList.CurrentCell as DataGridViewButtonXCell;

            if (cell != null)
            {
                DataGridViewButtonXColumn bc =
                    CommandDataList.Columns[e.ColumnIndex] as DataGridViewButtonXColumn;

                if (bc != null)
                {
                    var index = cell.RowIndex;
                    var row = cell.OwningRow;

                    switch (bc.Name)
                    {
                        case "Up":
                            if (index > 0)
                            {
                                CommandDataList.Rows.RemoveAt(index);
                                CommandDataList.Rows.Insert(index - 1, row);

                                WPListChange?.Invoke(GetWPList());
                            }
                            break;
                        case "Down":
                            if(index < CommandDataList.Rows.Count - 1)
                            {
                                CommandDataList.Rows.RemoveAt(index);
                                CommandDataList.Rows.Insert(index + 1, row);

                                WPListChange?.Invoke(GetWPList());
                            }
                            break;
                        case "Delete":
                            CommandDataList.Rows.RemoveAt(index);
                            WPListChange?.Invoke(GetWPList());
                            break;
                    }
                }
            }
        }

        private void CommandDataList_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
        }

        private void CommandDataList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
        }

        private void CommandDataList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex < CommandDataList.Rows.Count - 1)
            //{
            //    DataGridViewRow dgrSingle = CommandDataList.Rows[e.RowIndex];
            //    if (e.ColumnIndex == RelativeAlt.Index)
            //    {
            //        try
            //        {
            //            if ((int)dgrSingle.Cells[RelativeAlt.Index].Value < warnAlt)
            //            {
            //                dgrSingle.DefaultCellStyle.ForeColor = Color.Red;
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //        }
            //    }
            //}
        }

        private void CommandDataList_GridColorChanged(object sender, EventArgs e)
        {

        }
    }
}
