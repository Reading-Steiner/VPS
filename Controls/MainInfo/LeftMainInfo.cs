using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPS.Controls.MainInfo
{
    public partial class LeftMainInfo : UserControl
    {
        public LeftMainInfo()
        {
            InitializeComponent();

            instance = this;
        }

        public static LeftMainInfo instance = null;

        private delegate void SetPositionInThread(Utilities.PointLatLngAlt position);
        private Utilities.PointLatLngAlt home = null;
        public void SetHomeHandle(Utilities.PointLatLngAlt position)
        {
            if (this.InvokeRequired)
            {
                SetPositionInThread inThread = new SetPositionInThread(SetHomeHandle);
                this.Invoke(inThread, new object[] { position });
            }
            else
            {
                home = position;

                HomePosition.WGS84Position = position;

                DoCalc();
            }
        }

        private List<Utilities.PointLatLngAlt> grid = new List<Utilities.PointLatLngAlt>();

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
                SetWPList(wpList);
            }
        }

        private void SetWPList(List<Utilities.PointLatLngAlt> wpList)
        {
            CalcBaseAlt(wpList);
            grid.Clear();
            for(int index = 0; index < wpList.Count; index++)
            {
                var point = wpList[index];
                double terrainA = Utilities.srtm.getAltitude(point.Lat, point.Lng).alt * CurrentState.multiplieralt;
                double alt = point.Alt;
                double baseA = baseAlt;
                switch (point.Tag2)
                {
                    case "Relative":
                        break;
                    case "Absolute":
                        point.Tag2 = "Relative";
                        point.Alt = alt - baseA;
                        break;
                    case "Terrain":
                        point.Tag2 = "Relative";
                        point.Alt = alt + terrainA - baseA;
                        break;
                    default:
                        break;
                }
                grid.Add(point);
            }
            grid = wpList;

            CalcTotalAlt();

            CalcLap();
        }

        private Utilities.PointLatLngAlt current = null;
        public void SetCurrentPosition(Utilities.PointLatLngAlt position)
        {
            if (this.InvokeRequired)
            {
                SetPositionInThread inThread = new SetPositionInThread(SetCurrentPosition);
                this.Invoke(inThread, new object[] { position });
            }
            else
            {
                current = position;
                current.Tag2 = "Terrain";
                current.Alt = (Utilities.srtm.getAltitude(current.Lat, current.Lng).alt * CurrentState.multiplieralt);

                CurrentPosition.WGS84Position = current;

                DoCalc();
            }
        }


        double baseAlt = 0;
        double maxAlt = 0;
        double minAlt = 0;
        private void CalcBaseAlt(List<Utilities.PointLatLngAlt> wpList)
        {
            double totalAlt = 0.0;
            double maxA = 0.0;
            double minA = wpList.Count > 0 ? 
                Utilities.srtm.getAltitude(wpList[0].Lat, wpList[0].Lng).alt * CurrentState.multiplieralt : 0.0;
            for (int index = 0; index < wpList.Count; index++)
            {
                double terrain = Utilities.srtm.getAltitude(wpList[index].Lat, wpList[index].Lng).alt * CurrentState.multiplieralt;
                totalAlt += terrain;
                if (terrain > maxA)
                    maxA = terrain;
                if (terrain < minA)
                    minA = terrain;
            }
            baseAlt = (int)(totalAlt / Math.Max(1, wpList.Count));
            WPBaseAlt.Text = baseAlt.ToString("0.## m");
            maxAlt = maxA; minAlt = minA;
            WPGndeLev.Text = minA.ToString("0.##") + "-" + maxA.ToString("0.##") + " m";

        }

        private void CalcTotalAlt()
        {
            double totalDist = 0.0;
            for (int index = 1; index < grid.Count; index++)
            {
                totalDist += Math.Sqrt(
                    Math.Pow(grid[index].GetDistance(grid[index - 1]), 2) +
                    Math.Pow(grid[index].Alt - grid[index - 1].Alt, 2)) *
                    CurrentState.multiplierdist;
            }
            WPTotalDist.Text = totalDist.ToString("0.## m");
        }
        private void DoCalc()
        {
            double baseAltCopy = baseAlt;
            if (baseAltCopy == 0)
                baseAltCopy = (int)(Utilities.srtm.getAltitude(home.Lat, home.Lng).alt * CurrentState.multiplieralt);
            if (current != null)
            {
                
                if (home != null)
                {
                    double height = (home.Alt + baseAltCopy) - current.Alt;
                    double distance = current.GetDistance(home);
                    double grad = height / distance;

                    HomeGrad.Text = (grad).ToString("0.## %");
                    HomeDist.Text = (distance * CurrentState.multiplierdist).ToString("0.## m");
                    HomeAZ.Text = ((current.GetBearing(home) + 180) % 360).ToString("0.##");

                }
                else
                {
                    HomeGrad.Text = "0";
                    HomeDist.Text = "0";
                    HomeAZ.Text = "0";
                }

                if (grid != null && grid.Count > 0)
                {
                    double height = (grid[grid.Count - 1].Alt + baseAltCopy) - current.Alt;
                    double distance = current.GetDistance(grid[grid.Count - 1]);
                    double grad = height / distance;

                    LastGrad.Text = (grad).ToString("0.## %");
                    LastDist.Text = (distance * CurrentState.multiplierdist).ToString("0.## m");
                    LastAZ.Text = ((current.GetBearing(grid[grid.Count - 1]) + 180) % 360).ToString("0.##");
                }
                else
                {
                    LastGrad.Text = "0";
                    LastDist.Text = "0";
                    LastAZ.Text = "0";
                }
            }
        }

        private void CalcLap()
        {
            double overlap = Overlap.Value;
            double sidelap = Sidelap.Value;
            double relative = Relative.Value;

            double heightOverlap = overlap + (1 - overlap) * (baseAlt - maxAlt) / relative;
            double heightSidelap = sidelap + (1 - sidelap) * (baseAlt - maxAlt) / relative;
            double lowOverlap = overlap + (1 - overlap) * (baseAlt - minAlt) / relative;
            double lowSidelap = sidelap + (1 - sidelap) * (baseAlt - minAlt) / relative;

            HeightOverlap.Text = heightOverlap.ToString("0.00 %");
            HeightSidelap.Text = heightSidelap.ToString("0.00 %");
            LowOverlap.Text = lowOverlap.ToString("0.00 %");
            LowSidelap.Text = lowSidelap.ToString("0.00 %");
        }

        private void Overlap_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Sidelap_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Relative_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
