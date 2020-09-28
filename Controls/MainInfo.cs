using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPS.Controls
{
    public partial class MainInfo : UserControl
    {
        static public MainInfo instance = null;
        public MainInfo()
        {
            InitializeComponent();
            instance = this;
        }

        private void CoordSystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (CoordSystem.SelectedText)
            {
                case "GWS84":
                    WGS84Box.Visible = true;
                    UTMBox.Visible = false;
                    MGRSBox.Visible = false;
                    break;
                case "UTM":
                    WGS84Box.Visible = false;
                    UTMBox.Visible = true;
                    MGRSBox.Visible = false;
                    break;
                case "MGRS":
                    WGS84Box.Visible = false;
                    UTMBox.Visible = false;
                    MGRSBox.Visible = true;
                    break;
                default:
                    WGS84Box.Visible = false;
                    UTMBox.Visible = false;
                    MGRSBox.Visible = false;
                    break;
            }
        }

        private delegate void DataChangeInLimit(Utilities.PointLatLngAlt home);

        Utilities.PointLatLngAlt Home = new Utilities.PointLatLngAlt();

        public void SetHome(Utilities.PointLatLngAlt home)
        {
            if (this.InvokeRequired)
            {
                DataChangeInLimit inLimit = new DataChangeInLimit(SetHome);
                this.Invoke(inLimit, new object[] { home });
            }
            else
            {
                this.Home = home;
                this.HomeLat.Value = home.Lat;
                this.HomeLng.Value = home.Lng;
                this.HomeAlt.Value = home.Alt;
            }
        }

        Utilities.PointLatLngAlt currentPoint = new Utilities.PointLatLngAlt();
        Utilities.PointLatLngAlt CurrentPoint
        {
            get { return currentPoint; }
            set
            {
                currentPoint = value;
                CurrentLat.Value = currentPoint.Lat;
                CurrentLng.Value = currentPoint.Lng;
                CurrentAlt.Value = currentPoint.Alt;
                var current = new GeoUtility.GeoSystem.Geographic(currentPoint.Lng, currentPoint.Lat);
                var utm = (GeoUtility.GeoSystem.UTM)current;
                CurrentZone.Text = utm.Zoneband;
                CurrentEast.Value = utm.East;
                CurrentNorth.Value = utm.North;
                var mgrs = (GeoUtility.GeoSystem.MGRS)current;
                MGRS.Text = mgrs.ToString();
                if (Home != null)
                {
                    this.HomeDistance.Text = currentPoint.GetDistance(Home).ToString();
                    this.HomeAZ.Text = currentPoint.GetBearing(Home).ToString();
                }
                if (lastPoint != null) {
                    this.LastDistance.Text = currentPoint.GetDistance(lastPoint).ToString();
                    this.LastAZ.Text = currentPoint.GetBearing(lastPoint).ToString();
                }
            }
        }

        public void SetCurrentPosition(Utilities.PointLatLngAlt point)
        {
            if (this.InvokeRequired)
            {
                DataChangeInLimit inLimit = new DataChangeInLimit(SetCurrentPosition);
                this.Invoke(inLimit, new object[] { point });
            }
            else
            {
                CurrentPoint = point;
            }
        }

        public void SetWPList(List<Utilities.PointLatLngAlt> wpList)
        {
            if(wpList.Count <= 0)
            {
                SetLastPosition(null);
                SetTotalDistance(0);
                return;
            }
            SetLastPosition(wpList[wpList.Count - 1]);
            double distance = wpList[0].GetDistance(Home);
            for(int i = 1; i< wpList.Count; i++)
            {
                distance += wpList[i].GetDistance(wpList[i - 1]);
            }
            SetTotalDistance(distance);
        }

        Utilities.PointLatLngAlt lastPoint = new Utilities.PointLatLngAlt();
        Utilities.PointLatLngAlt LastPoint
        {
            get { return currentPoint; }
            set
            {
                lastPoint = value;
                CurrentLat.Value = currentPoint.Lat;
                CurrentLng.Value = currentPoint.Lng;
                CurrentAlt.Value = currentPoint.Alt;
                if (lastPoint != null)
                {
                    this.LastDistance.Text = currentPoint.GetDistance(lastPoint).ToString();
                    this.LastAZ.Text = currentPoint.GetBearing(lastPoint).ToString();
                }
            }
        }

        public void SetLastPosition(Utilities.PointLatLngAlt point)
        {
            if (this.InvokeRequired)
            {
                DataChangeInLimit inLimit = new DataChangeInLimit(SetCurrentPosition);
                this.Invoke(inLimit, new object[] { point });
            }
            else
            {
                LastPoint = point;
            }
        }

        private delegate void DoubleDataChangeInLimit(double data);
        public void SetTotalDistance(double distance)
        {
            if (this.InvokeRequired)
            {
                DoubleDataChangeInLimit inLimit = new DoubleDataChangeInLimit(SetTotalDistance);
                this.Invoke(inLimit, new object[] { distance });
            }
            else
            {
                TotalDistance.Text = distance.ToString() + " m";
            }
        }

    }
}
