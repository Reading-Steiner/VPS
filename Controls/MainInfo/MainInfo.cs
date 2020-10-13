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
    public partial class MainInfo : UserControl
    {
        public MainInfo()
        {
            InitializeComponent();

            instance = this;
        }

        public static MainInfo instance = null;

        private Utilities.PointLatLngAlt home = null;
        public void SetHomePosition(Utilities.PointLatLngAlt position)
        {
            home = position;

            HomeLat.Text = home.Lat.ToString("0.######");
            HomeLng.Text = home.Lng.ToString("0.######");
            HomeAlt.Text = home.Alt.ToString("0.######");

            DoCalc();
        }

        private List<Utilities.PointLatLngAlt> grid = null;
        public void SetWPList(List<Utilities.PointLatLngAlt> wpList)
        {
            grid = wpList;
            CalcBaseAlt();
        }

        private Utilities.PointLatLngAlt current = null;
        public void SetCurrentPosition(Utilities.PointLatLngAlt position)
        {
            current = position;
            current.Alt = (Utilities.srtm.getAltitude(current.Lat, current.Lng).alt * CurrentState.multiplieralt);

            CurrentLat.Text = current.Lat.ToString("0.######");
            CurrentLng.Text = current.Lng.ToString("0.######");
            CurrentAlt.Text = (Utilities.srtm.getAltitude(current.Lat, current.Lng).alt * CurrentState.multiplieralt).ToString("0.##");

            DoCalc();
        }


        double baseAlt = 0;
        private void CalcBaseAlt()
        {
            double totalAlt = 0.0;
            double maxAlt = 0.0;
            for (int index = 0; index < grid.Count; index++)
            {
                double terrain = Utilities.srtm.getAltitude(grid[index].Lat, grid[index].Lng).alt * CurrentState.multiplieralt;
                totalAlt += terrain;
                if (terrain > maxAlt)
                    maxAlt = terrain;
            }
            baseAlt = (int)(totalAlt / Math.Max(1, grid.Count));
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

                if (grid != null && grid.Count > 0)
                {
                    double height = (grid[grid.Count - 1].Alt + baseAltCopy) - current.Alt;
                    double distance = current.GetDistance(grid[grid.Count - 1]);
                    double grad = height / distance;

                    LastGrad.Text = (grad).ToString("0.## %");
                    LastDist.Text = (distance * CurrentState.multiplierdist).ToString("0.## m");
                    LastAZ.Text = ((current.GetBearing(grid[grid.Count - 1]) + 180) % 360).ToString("0.##");
                }
            }
        }
    }
}
