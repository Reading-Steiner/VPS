using GeoAPI.CoordinateSystems;
using GeoAPI.CoordinateSystems.Transformations;
using GMap.NET;
using ProjNet.CoordinateSystems;
using ProjNet.CoordinateSystems.Transformations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPS.Utilities;

namespace VPS.CustomData.WP
{
    public class Position
    {
        public double Lat { get; set; } = 0;

        public double Lng { get; set; } = 0;

        public double Alt { get; set; } = 0;

        public string AltMode { get; set; } = "";

        public string Command { get; set; } = "";


        #region 构造函数
        public Position()
        {
        }

        public Position(double lat, double lng)
        {
            Lat = lat;
            Lng = lng;
        }

        public Position(double lat, double lng, double alt)
        {
            Lat = lat;
            Lng = lng;
            Alt = alt;
        }

        public Position(Position point)
        {
            Lng = point.Lng;
            Lat = point.Lat;
            Alt = point.Alt;
            Command = point.Command;
            AltMode = point.AltMode;
        }

        public Position(PointLatLng point)
        {
            this.Lat = point.Lat;
            this.Lng = point.Lng;
        }

        public Position(Locationwp point)
        {
            this.Lat = point.lat;
            this.Lng = point.lng;
            this.Alt = point.alt;
        }

        public Position(PointLatLngAlt point)
        {
            Lng = point.Lng;
            Lat = point.Lat;
            Alt = point.Alt;
            Command = point.Tag;
            AltMode = point.Tag2;
        }
        #endregion

        public override string ToString()
        {
            return Math.Abs(Lng).ToString("0.##") + (Lng >= 0 ? "E; " : "W") + "; " +
                Math.Abs(Lat).ToString("0.##") + (Lat >= 0 ? "N;" : "S") + "; " +
                (Alt).ToString("0.##");
        }

        #region 类型转换
        public PointLatLngAlt ToWGS84()
        {
            PointLatLngAlt point = new PointLatLngAlt();
            point.Lng = Lng;
            point.Lat = Lat;
            point.Alt = Alt;
            point.Tag = Command;
            point.Tag2 = AltMode;

            return point;
        }

        public PointLatLng ToPoint()
        {
            PointLatLng point = new PointLatLng();
            point.Lng = Lng;
            point.Lat = Lat;

            return point;
        }

        public void FromWGS84(PointLatLngAlt point)
        {
            Lng = point.Lng;
            Lat = point.Lat;
            Alt = point.Alt;
            Command = point.Tag;
            AltMode = point.Tag2;
        }

        public void FromPoint(PointLatLng point)
        {
            Lng = point.Lng;
            Lat = point.Lat;
        }

        public void FromLocationWP(Locationwp point)
        {
            this.Lat = point.lat;
            this.Lng = point.lng;
            this.Alt = point.alt;
        }

        public void FromPosition(Position point)
        {
            Lng = point.Lng;
            Lat = point.Lat;
            Alt = point.Alt;
            Command = point.Command;
            AltMode = point.AltMode;
        }
        #endregion

        #region 比较函数
        public override bool Equals(Object pllaobj)
        {
            Position plla = pllaobj as Position;

            if (plla == null)
                return false;

            if (this.Lat == plla.Lat &&
            this.Lng == plla.Lng &&
            this.Alt == plla.Alt &&
            this.AltMode == plla.AltMode &&
            this.Command == plla.Command)
            {
                return true;
            }
            return false;
        }

        public static bool operator ==(Position p1, Position p2)
        {
            if (p1 == null || p2 == null)
                return false;

            if (p1.Lat == p2.Lat &&
                p1.Lng == p2.Lng)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Position p1, Position p2)
        {
            return !(p1 == p2);
        }
        #endregion

        public override int GetHashCode()
        {
            return (int)(BitConverter.DoubleToInt64Bits(Lat) ^
                          BitConverter.DoubleToInt64Bits(Lng) ^
                          BitConverter.DoubleToInt64Bits(Alt));
        }
    }
}
