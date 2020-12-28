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
    public class VPSPosition
    {
        public virtual double Lat { get; set; } = 0;

        public virtual double Lng { get; set; } = 0;

        public virtual double Alt { get; set; } = 0;

        public virtual string AltMode { get; set; } = "";

        public virtual string Command { get; set; } = "";


        #region 构造函数
        public VPSPosition()
        {
        }

        public VPSPosition(double lat, double lng, double alt = -1, string altMode = "Terrain", string command = "")
        {
            Lat = lat;
            Lng = lng;
            Alt = alt;
            AltMode = altMode;
            Command = command;
        }

        public VPSPosition(VPSPosition point)
        {
            Lng = point.Lng;
            Lat = point.Lat;
            Alt = point.Alt;
            Command = point.Command;
            AltMode = point.AltMode;
        }

        public VPSPosition(PointLatLng point)
        {
            this.Lat = point.Lat;
            this.Lng = point.Lng;
            Alt = -1;
            Command = "";
            AltMode = "Terrain";
        }

        public VPSPosition(Locationwp point)
        {
            this.Lat = point.lat;
            this.Lng = point.lng;
            this.Alt = point.alt;
            Command = "WAYPOINT";
            AltMode = "Terrain";
        }

        public VPSPosition(PointLatLngAlt point)
        {
            Lng = point.Lng;
            Lat = point.Lat;
            Alt = point.Alt;
            Command = point.Tag;
            AltMode = point.Tag2;
        }
        #endregion

        public static readonly VPSPosition InvaildPosition = new VPSPosition(-1, -1, -1, "", "");

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

        public void FromPosition(VPSPosition point)
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
            VPSPosition plla = pllaobj as VPSPosition;

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

        public static bool operator ==(VPSPosition p1, VPSPosition p2)
        {
            if (p1 is null && p2 is null)
                return true;
            else if (p1 is null || p2 is null)
                return false;

            if (p1.Lat == p2.Lat &&
                p1.Lng == p2.Lng)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(VPSPosition p1, VPSPosition p2)
        {
            return !(p1 == p2);
        }
        #endregion

        public override string ToString()
        {
            return Math.Abs(Lng).ToString("0.##") + (Lng >= 0 ? "E; " : "W") + "; " +
                Math.Abs(Lat).ToString("0.##") + (Lat >= 0 ? "N;" : "S") + "; " +
                (Alt).ToString("0.##");
        }

        public override int GetHashCode()
        {
            return (int)(BitConverter.DoubleToInt64Bits(Lat) ^
                          BitConverter.DoubleToInt64Bits(Lng) ^
                          BitConverter.DoubleToInt64Bits(Alt));
        }

        #region 航点高度框架转换
        public static CustomData.WP.VPSPosition ChangeAltFrame(CustomData.WP.VPSPosition cur, double baseAlt, string altitudeMode = "Terrain")
        {
            var point = new CustomData.WP.VPSPosition(cur);

            double alt = srtm.getAltitude(cur.Lat, cur.Lng).alt * CurrentState.multiplieralt;
            if (altitudeMode == EnumCollect.AltFrame.Relative)
            {
                if (point.AltMode == EnumCollect.AltFrame.Relative)
                    point.Alt = cur.Alt;
                else if (point.AltMode == EnumCollect.AltFrame.Absolute)
                    point.Alt = cur.Alt - baseAlt;
                else if (point.AltMode == EnumCollect.AltFrame.Terrain)
                    point.Alt = cur.Alt + alt - baseAlt;
                else
                    point.Alt = cur.Alt + alt - baseAlt;

                point.AltMode = EnumCollect.AltFrame.Relative;
            }
            else if (altitudeMode == EnumCollect.AltFrame.Absolute)
            {
                if (point.AltMode == EnumCollect.AltFrame.Relative)
                    point.Alt = cur.Alt + baseAlt;
                else if (point.AltMode == EnumCollect.AltFrame.Absolute)
                    point.Alt = cur.Alt;
                else if (point.AltMode == EnumCollect.AltFrame.Terrain)
                    point.Alt = cur.Alt + alt;
                else
                    point.Alt = cur.Alt + alt;

                point.AltMode = EnumCollect.AltFrame.Absolute;
            }
            else if (altitudeMode == EnumCollect.AltFrame.Terrain)
            {
                if (point.AltMode == EnumCollect.AltFrame.Relative)
                    point.Alt = cur.Alt + baseAlt - alt;
                else if (point.AltMode == EnumCollect.AltFrame.Absolute)
                    point.Alt = cur.Alt - alt;
                else if (point.AltMode == EnumCollect.AltFrame.Terrain)
                    point.Alt = cur.Alt;
                else
                    point.Alt = cur.Alt;
                point.AltMode = EnumCollect.AltFrame.Terrain;
            }
            else
                point.Alt = cur.Alt;
            return point;
        }
        #endregion
    }

    public class VPSRect
    {
        public virtual double Top { get; set; } = 0;

        public virtual double Bottom { get; set; } = 0;

        public virtual double Left { get; set; } = 0;

        public virtual double Right { get; set; } = 0;


        #region 构造函数
        public VPSRect()
        {
        }

        public VPSRect(double top, double bottom, double left, double right)
        {
            Top = top;
            Bottom = bottom;
            Left = left;
            Right = right;
        }

        public VPSRect(VPSPosition TopLeft, VPSPosition BottomRight)
        {
            Top = TopLeft.Lat;
            Left = TopLeft.Lng;

            Bottom = BottomRight.Lat;
            Right = BottomRight.Lng;
        }

        public VPSRect(RectLatLng rect)
        {
            Top = rect.Top;
            Bottom = rect.Bottom;
            Left = rect.Left;
            Right = rect.Right;
        }

        public VPSRect(VPSRect rect)
        {
            Top = rect.Top;
            Bottom = rect.Bottom;
            Left = rect.Left;
            Right = rect.Right;
        }
        #endregion

        #region 类型转换
        public RectLatLng ToWGS84()
        {
            RectLatLng rect = RectLatLng.FromLTRB(Left, Top, Right, Bottom);

            return rect;
        }

        public void FromWGS84(RectLatLng rect)
        {
            Top = rect.Top;
            Bottom = rect.Bottom;
            Left = rect.Left;
            Right = rect.Right;
        }

        public void FromRect(VPS.CustomData.WP.VPSRect rect)
        {
            Top = rect.Top;
            Bottom = rect.Bottom;
            Left = rect.Left;
            Right = rect.Right;
        }
        #endregion

        #region 比较函数
        public override bool Equals(Object pllaobj)
        {
            VPSRect plla = pllaobj as VPSRect;

            if (plla == null)
                return false;

            if (this.Top == plla.Top &&
            this.Bottom == plla.Bottom &&
            this.Left == plla.Left &&
            this.Right == plla.Right)
            {
                return true;
            }
            return false;
        }

        public static bool operator ==(VPSRect p1, VPSRect p2)
        {
            if (p1 == null || p2 == null)
                return false;

            if (p1.Top == p2.Top &&
            p1.Bottom == p2.Bottom &&
            p1.Left == p2.Left &&
            p1.Right == p2.Right)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(VPSRect p1, VPSRect p2)
        {
            return !(p1 == p2);
        }
        #endregion

        public override string ToString()
        {
            return
                Math.Abs(Left).ToString("0.##") + (Left >= 0 ? "E; " : "W") + " - " +
                Math.Abs(Right).ToString("0.##") + (Right >= 0 ? "E; " : "W") + "; " +
                Math.Abs(Bottom).ToString("0.##") + (Bottom >= 0 ? "N;" : "S") + " - " +
                Math.Abs(Top).ToString("0.##") + (Top >= 0 ? "N;" : "S");
        }

        public override int GetHashCode()
        {
            return (int)(
                BitConverter.DoubleToInt64Bits(Top) ^
                BitConverter.DoubleToInt64Bits(Bottom) ^
                BitConverter.DoubleToInt64Bits(Left) ^
                BitConverter.DoubleToInt64Bits(Right));
        }

    }


    public class VPSGeometry
    {
        private object obj = new object();
        private List<VPSPosition> mPositionList;
        private List<bool> mPositionSelected;
        private List<bool> mPositionVisible;
        public delegate void ChangeHandle();
        public ChangeHandle GeometryChange;

        private int mSelectedCount = 0;

        public VPSGeometry()
        {
            mPositionList = new List<VPSPosition>();
            mPositionSelected = new List<bool>();
            mPositionVisible = new List<bool>();

            mSelectedCount = 0;
        }

        public VPSGeometry(List<VPSPosition> posList)
        {
            mPositionList = new List<VPSPosition>();
            mPositionSelected = new List<bool>();
            mPositionVisible = new List<bool>();
            foreach (VPSPosition pos in posList)
            {
                mPositionList.Add(pos);
                mPositionSelected.Add(false);
                mPositionVisible.Add(false);
            }

            mSelectedCount = 0;
        }

        public VPSGeometry(VPSGeometry geom)
        {
            mPositionList = new List<VPSPosition>(geom.mPositionList);
            mPositionSelected = new List<bool>(geom.mPositionSelected);
            mPositionVisible = new List<bool>(geom.mPositionVisible);

            mSelectedCount = geom.mSelectedCount;
        }

        public void SetGeometryHandle(List<VPSPosition> posList)
        {
            lock (obj)
            {
                mPositionList.Clear();
                mPositionSelected.Clear();
                mPositionVisible.Clear();
                foreach (VPSPosition pos in posList)
                {
                    mPositionList.Add(pos);
                    mPositionSelected.Add(false);
                    mPositionVisible.Add(false);
                }

                mSelectedCount = 0;
            }
        }

        public void AppendGeometryHandle(List<VPSPosition> posList)
        {
            lock (obj)
            {
                foreach (VPSPosition pos in posList)
                {
                    mPositionList.Add(pos);
                    mPositionSelected.Add(false);
                    mPositionVisible.Add(false);
                }
            }
        }

        public void InsertGeometryHandle(int index, List<VPSPosition> posList)
        {
            lock (obj)
            {
                if (index < 0)
                    index = 0;
                if (index >= mPositionList.Count)
                {
                    AppendGeometryHandle(posList);
                }
                else
                {
                    foreach (VPSPosition pos in posList)
                    {
                        mPositionList.Insert(index, pos);
                        mPositionSelected.Insert(index, false);
                        mPositionVisible.Insert(index, false);
                        ++index;
                    }
                }
            }
        }

        public void ClearGeometryHandle()
        {
            lock (obj)
            {
                mPositionList.Clear();
                mPositionSelected.Clear();
                mPositionVisible.Clear();

                mSelectedCount = 0;
            }
        }

        public List<VPSPosition> GetGeometry()
        {
            lock (obj)
            {
                var posList = new List<VPSPosition>(mPositionList);
                return posList;
            }
        }

        public int AppendPositionHandle(VPSPosition pos)
        {
            lock (obj)
            {
                int index = mPositionList.Count;
                mPositionList.Add(pos);
                mPositionSelected.Add(false);
                mPositionVisible.Add(false);

                return index;
            }
        }

        public int InsertPositionHandle(int index, VPSPosition pos)
        {
            lock (obj)
            {
                var position = new VPSPosition(pos);
                if (index < 0)
                    index = 0;
                if (index >= mPositionList.Count)
                {
                    index = mPositionList.Count;

                    mPositionList.Add(pos);
                    mPositionSelected.Add(false);
                    mPositionVisible.Add(false);
                }
                else
                {
                    mPositionList.Insert(index, position);
                    mPositionSelected.Insert(index, false);
                    mPositionVisible.Insert(index, false);
                }
                return index;
            }
        }

        public int MovePositionHandle(int index, VPSPosition pos)
        {
            lock (obj)
            {
                if (index < 0 || index >= mPositionList.Count)
                    return -1;
                mPositionList[index] = pos;
                return index;
            }
        }

        public void DeletePositionHandle(int index)
        {
            lock (obj)
            {
                mPositionList.RemoveAt(index);
                mPositionSelected.RemoveAt(index);
                mPositionVisible.RemoveAt(index);
            }
        }

        public VPSPosition GetPosition(int index)
        {
            lock (obj)
            {
                if (mPositionList.Count < 0)
                    return VPSPosition.InvaildPosition;

                if (index < 0)
                    index = (index % mPositionList.Count + mPositionList.Count) % mPositionList.Count;
                if (index >= mPositionList.Count)
                    index = index % mPositionList.Count;

                return new VPSPosition(mPositionList[index]);
            }
        }

        public VPSPosition this[int index]
        {
            get
            {
                lock (obj)
                {
                    if (mPositionList.Count < 0)
                        return VPSPosition.InvaildPosition;

                    if (index < 0)
                        index = (index % mPositionList.Count + mPositionList.Count) % mPositionList.Count;
                    if (index >= mPositionList.Count)
                        index = index % mPositionList.Count;
                    return mPositionList[index];
                }
            }
        }

        public int GeometryCount
        {
            get
            {
                lock (obj)
                {
                    return mPositionList.Count;
                }
            }
        }

        public bool IsSelected(int index)
        {
            lock (obj)
            {
                if (mPositionSelected.Count != mPositionList.Count)
                    throw (new Exception("VPSGeometry 数据源对齐异常"));
                if (index < 0 || index >= mPositionList.Count)
                    return false;

                return mPositionSelected[index];
            }
        }

        public bool Selected(int index, bool isSelected = true)
        {
            lock (obj)
            {
                if (mPositionSelected.Count != mPositionList.Count)
                    throw (new Exception("VPSGeometry 数据源对齐异常"));
                if (index < 0 || index >= mPositionList.Count)
                    return false;

                if (mPositionSelected[index] != isSelected)
                {
                    if (isSelected)
                        mSelectedCount += 1;
                    else
                        mSelectedCount -= 1;
                    mPositionSelected[index] = isSelected;
                }
                return true;
            }
        }

        public void ClearSelected()
        {
            lock (obj)
            {
                mPositionSelected.Clear();
                foreach(VPSPosition pos in mPositionList)
                {
                    mPositionSelected.Add(false);
                }

                mSelectedCount = 0;
            }
        }

        public bool ExistSelected()
        {
            if (mSelectedCount > 0)
                return true;
            else
                return false;
        }
    }
}
