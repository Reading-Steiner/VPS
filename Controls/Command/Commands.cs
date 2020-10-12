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
        public CommandsPanel instance = null;

        public CommandsPanel()
        {
            StartEdit();
            InitializeComponent();
            InitAltFrame();

            instance = this;
            EndEdit();
        }

        private void InitAltFrame()
        {
            AltFrame.Items.Add(AltFrames.Relative);
            AltFrame.Items.Add(AltFrames.Absolute);
            AltFrame.Items.Add(AltFrames.Terrain);
            AltFrame.SelectedIndex = 0;
        }

        private void InitCoordSystem()
        {
            CoordSystem.Items.Add(CoordSystems.WGS84);
            CoordSystem.Items.Add(CoordSystems.UTM);
            CoordSystem.Items.Add(CoordSystems.MGRS);
            CoordSystem.SelectedIndex = 0;
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
        public DataChangeHandle AltFrameChange;
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

        private int defaultAlt = 200;
        public DataChangeHandle DefaultAltChange;
        private void DefaultAlt_ValueChanged(object sender, EventArgs e)
        {
            defaultAlt = DefaultAlt.Value;
            if (isEdit)
                return;
            DefaultAltChange?.Invoke(defaultAlt);
        }

        private int warnAlt = 0;
        public DataChangeHandle WarnAltChange;
        private void WarnAlt_ValueChanged(object sender, EventArgs e)
        {
            warnAlt = WarnAlt.Value;
            if (isEdit)
                return;
            WarnAltChange?.Invoke(warnAlt);
        }

        private bool isAutoWarn = false;
        private void AutoWarnAlt_CheckedChanged(object sender, EventArgs e)
        {
            isAutoWarn = AutoWarnAlt.Checked;
        }

        private int baseAlt = 0;
        public DataChangeHandle BaseAltChange;
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
        public DataChangeHandle CoordSystemChange;
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
        public DataChangeHandle WPRadChange;
        private void WpRad_ValueChanged(object sender, EventArgs e)
        {
            wpRad = WpRad.Value;
            if (isEdit)
                return;
            WPRadChange?.Invoke(wpRad);
        }

        private Utilities.PointLatLngAlt homePosition;
        public DataChangeHandle HomeChange;
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
                case "WayPoint":
                    {
                        CommandDataList[Lat.Index, index].Value = wp.Lat;
                        CommandDataList[Lon.Index, index].Value = wp.Lng;

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
            BaseAlt.Value = (int)(totalAlt / wpList.Count);
            if (isAutoWarn)
                WarnAlt.Value = (int)(maxAlt - baseAlt + 1);
        }

        private void SetAltitude(List<Utilities.PointLatLngAlt> wpList)
        {
            for (int index = 0; index < wpList.Count; index++)
            {
                double terrain = Utilities.srtm.getAltitude(wpList[index].Lat, wpList[index].Lng).alt * CurrentState.multiplieralt;
                switch (wpList[index].Tag2)
                {
                    case "Relative":
                        CommandDataList[RelativeAlt.Index, index].Value = wpList[index].Alt;
                        CommandDataList[AbsoluteAlt.Index, index].Value = wpList[index].Alt + baseAlt;
                        CommandDataList[TerrainAlt.Index, index].Value = wpList[index].Alt + baseAlt - terrain;
                        break;
                    case "Absolute":
                        CommandDataList[RelativeAlt.Index, index].Value = wpList[index].Alt - baseAlt;
                        CommandDataList[AbsoluteAlt.Index, index].Value = wpList[index].Alt;
                        CommandDataList[TerrainAlt.Index, index].Value = wpList[index].Alt - terrain;
                        break;
                    case "Terrain":
                        CommandDataList[RelativeAlt.Index, index].Value = wpList[index].Alt + terrain - baseAlt;
                        CommandDataList[AbsoluteAlt.Index, index].Value = wpList[index].Alt + terrain;
                        CommandDataList[TerrainAlt.Index, index].Value = wpList[index].Alt;
                        break;
                    default:
                        CommandDataList[RelativeAlt.Index, index].Value = wpList[index].Alt;
                        CommandDataList[AbsoluteAlt.Index, index].Value = wpList[index].Alt + baseAlt;
                        CommandDataList[TerrainAlt.Index, index].Value = wpList[index].Alt + baseAlt - terrain;
                        break;
                }
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

                CommandDataList[Grad.Index, 0].Value = (grad * 100);
                CommandDataList[Angle.Index, 0].Value = ((180.0 / Math.PI) * Math.Atan(grad));
                CommandDataList[Dist.Index, 0].Value = (Math.Sqrt(Math.Pow(distance, 2) + Math.Pow(height, 2)) * CurrentState.multiplierdist);
                CommandDataList[AZ.Index, 0].Value = ((wpList[index].GetBearing(wpList[index - 1]) + 180) % 360);
            }
        }

        public DataChangeHandle WPListChange;

        private List<Utilities.PointLatLngAlt> GetWPList()
        {
            List<Utilities.PointLatLngAlt> wpList = new List<Utilities.PointLatLngAlt>();
            for (int index  = 0; index < CommandDataList.Rows.Count;index++)
            {
                Utilities.PointLatLngAlt wpPoint = new Utilities.PointLatLngAlt();
                wpPoint.Lat = (double)CommandDataList[Lat.Index, index].Value;
                wpPoint.Lng = (double)CommandDataList[Lon.Index, index].Value;
                wpPoint.Alt = (int)CommandDataList[Alt.Index, index].Value;
                wpPoint.Tag = CommandDataList[Command.Index, index].Value.ToString();
                wpPoint.Tag2 = "Relative";
                wpList.Add(wpPoint);
            }
            return wpList;
        }

        public void SetWPList(List<Utilities.PointLatLngAlt> wpList)
        {
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
            SetWpListParam(wpList);
            EndEdit();

            SetBaseAlt(wpList);
            SetAltitude(wpList);
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
    }
}
