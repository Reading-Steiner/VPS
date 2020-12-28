using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPS.Utilities;

namespace VPS.CustomData.WP
{
    class WPGlobalData
    {
        static public WPGlobalData instance = null;

        public WPGlobalData()
        {
            instance = this;
            LoadConfig();
        }


        #region 参数
        private void LoadConfig()
        {
            VPS.CustomData.WP.VPSPosition defHome = new VPS.CustomData.WP.VPSPosition();
            double defLeft = 0; double defRight = 0;
            double defTop = 0; double defBottom = 0;

            foreach (string key in Settings.Instance.Keys)
            {
                switch (key)
                {
                    case "Main_DefaultLayer":
                        SetLayer(Settings.Instance[key], true);
                        break;
                    case "Main_DefaultHomeLat":
                        {
                            if (double.TryParse(Settings.Instance[key], out double lat))
                                defHome.Lat = lat;
                        }
                        break;
                    case "Main_DefaultHomeLng":
                        {
                            if (double.TryParse(Settings.Instance[key], out double lng))
                                defHome.Lng = lng;
                        }
                        break;
                    case "Main_DefaultHomeAlt":
                        {
                            if (double.TryParse(Settings.Instance[key], out double alt))
                                defHome.Alt = alt;
                        }
                        break;
                    case "Main_DefaultHomeFrame":
                        defHome.AltMode = "" + Settings.Instance[key];
                        break;
                    case "Main_DefaultPointLeft":
                        {
                            if (double.TryParse(Settings.Instance[key], out double left))
                                defLeft = left;
                        }
                        break;
                    case "Main_DefaultPointTop":
                        {
                            if (double.TryParse(Settings.Instance[key], out double top))
                                defTop = top;
                        }
                        break;
                    case "Main_DefaultPointRight":
                        {
                            if (double.TryParse(Settings.Instance[key], out double right))
                                defRight = right;
                        }
                        break;
                    case "Main_DefaultPointBottom":
                        {
                            if (double.TryParse(Settings.Instance[key], out double bottom))
                                defBottom = bottom;
                        }
                        break;
                }
            }
            if (!string.IsNullOrEmpty(defaultLayerPath))
                SetLayerLimit(
                    new VPS.CustomData.WP.VPSRect(defTop, defBottom, defLeft, defRight),
                    defHome, true);

        }

        public void SaveConfig()
        {
            if (this.defaultLayerPath != null)
            {
                Settings.Instance["Main_DefaultLayer"] = this.defaultLayerPath;
                if (this.defaultHome != null)
                {
                    Settings.Instance["Main_DefaultHomeLat"] = this.defaultHome.Lat.ToString();
                    Settings.Instance["Main_DefaultHomeLng"] = this.defaultHome.Lng.ToString();
                    Settings.Instance["Main_DefaultHomeAlt"] = this.defaultHome.Alt.ToString();
                    Settings.Instance["Main_DefaultHomeFrame"] = this.defaultHome.AltMode.ToString();
                }

                Settings.Instance["Main_DefaultPointLeft"] = this.defaultRect.Left.ToString();
                Settings.Instance["Main_DefaultPointTop"] = this.defaultRect.Top.ToString();
                Settings.Instance["Main_DefaultPointRight"] = this.defaultRect.Right.ToString();
                Settings.Instance["Main_DefaultPointBottom"] = this.defaultRect.Bottom.ToString();
            }
        }
        #endregion

        #region QUICKADD 快速添加标记
        private bool quickAdd = false;

        #region 接口函数
        public void BegionQuick()
        {
            quickAdd = true;
        }

        public void EndQuick()
        {
            quickAdd = false;
        }
        #endregion

        #region 执行函数
        public bool IsExecuteOverSetting()
        {
            return !quickAdd;
        }

        #endregion

        #region 修改航点反应函数
        public void ExecuteWPStartSetting()
        {
            AddHistory();
        }

        public void ExecuteWPOverSetting()
        {
            WPListChange?.Invoke();
        }

        public void ExecutePolyOverSetting()
        {
            PolygonListChange?.Invoke();
        }
        #endregion

        #endregion

        public delegate void ChangeHandle();
        public delegate void PositionChangeHandle(VPS.CustomData.WP.VPSPosition position);
        public delegate void RectChangeHandle(VPS.CustomData.WP.VPSRect rect);
        public delegate void CountChangeHandle(int count);

        #region WPLIST 航点
        private List<VPS.CustomData.WP.VPSPosition> wpList = new List<VPS.CustomData.WP.VPSPosition>();
        public ChangeHandle WPListChange;

        #region 获取航点
        public List<VPS.CustomData.WP.VPSPosition> GetWPList()
        {
            List<VPS.CustomData.WP.VPSPosition> retList = new List<VPS.CustomData.WP.VPSPosition>(wpList);

            if ((retList.Count <= 0) || retList[0].Command != WP.WPCommands.HomeCommand)
                retList.Insert(0, GetHomePosition());

            return retList;
        }
        #endregion

        #region 类别转换
        static public List<PointLatLngAlt> ToWGS84WPList(List<VPS.CustomData.WP.VPSPosition> wpList)
        {
            List<PointLatLngAlt> retList = new List<PointLatLngAlt>();
            foreach(var wp in wpList)
            {
                retList.Add(wp.ToWGS84());
            }

            return retList;
        }

        static public List<VPS.CustomData.WP.VPSPosition> FromWGS84WPList(List<PointLatLngAlt>  wpList)
        {
            List<VPS.CustomData.WP.VPSPosition> retList = new List<VPS.CustomData.WP.VPSPosition>();
            foreach (var wp in wpList)
            {
                retList.Add(new VPS.CustomData.WP.VPSPosition(wp));
            }

            return retList;
        }
        #endregion

        #region 设置航点
        public void SetWPListHandle(List<CustomData.WP.VPSPosition> list)
        {
            if (IsExecuteOverSetting())
            {
                AddHistory();
            }
            wpList = new List<CustomData.WP.VPSPosition>(list);
            if (wpList.Count > 0)
            {
                if (wpList[0].Command == WPCommands.HomeCommand)
                {
                    if (wpList[0] != GetHomePosition())
                        SetHomePosition(wpList[0]);
                    wpList.RemoveAt(0);
                }

            }

            if (IsExecuteOverSetting())
            {
                WPListChange?.Invoke();
            }
        }
        #endregion

        #region 扩充航点
        public void AppendWPListHandle(List<CustomData.WP.VPSPosition> list)
        {
            if (IsExecuteOverSetting())
            {
                AddHistory();
            }
            var apWPList = new List<CustomData.WP.VPSPosition>(list);
            if (apWPList.Count > 0)
            {
                if (apWPList[0].Command == WPCommands.HomeCommand)
                {
                    wpList.RemoveAt(0);
                }
            }

            wpList.AddRange(apWPList);

            if (IsExecuteOverSetting())
            {
                WPListChange?.Invoke();
            }
        }
        #endregion

        #region 清空航点
        public void ClearWPListHandle()
        {
            if (IsExecuteOverSetting())
            {
                AddHistory();
            }

            wpList.Clear();

            if (IsExecuteOverSetting())
            {
                WPListChange?.Invoke();
            }
        }
        #endregion

        #region 添加航点
        public int AddWPHandle(VPS.CustomData.WP.VPSPosition wp)
        {
            if (IsExecuteOverSetting())
            {
                AddHistory();
            }

            int index = wpList.Count;
            wpList.Add(new VPS.CustomData.WP.VPSPosition(wp));

            if (IsExecuteOverSetting())
            {
                WPListChange?.Invoke();
            }

            return index;
        }
        #endregion

        #region 插入航点
        public void InsertWPHandle(int index, VPS.CustomData.WP.VPSPosition wp)
        {
            if (IsExecuteOverSetting())
            {
                AddHistory();
            }

            if (index < 0)
                index = 0;
            if (index >= wpList.Count)
                wpList.Add(new VPS.CustomData.WP.VPSPosition(wp));
            else
                wpList.Insert(index, new VPS.CustomData.WP.VPSPosition(wp));

            if (IsExecuteOverSetting())
            {
                WPListChange?.Invoke();
            }
        }
        #endregion

        #region 修改航点
        public void SetWPHandle(int index, VPS.CustomData.WP.VPSPosition wp)
        {
            if (IsExecuteOverSetting())
            {
                AddHistory();
            }

            if (index < 0)
                index = 0;

            if (index >= wpList.Count)
                wpList.Add(new VPS.CustomData.WP.VPSPosition(wp));
            else
                wpList[index] = new VPS.CustomData.WP.VPSPosition(wp);

            if (IsExecuteOverSetting())
            {
                WPListChange?.Invoke();
            }
        }
        #endregion

        #region 删除航点
        public void DeleteWPHandle(int index)
        {
            if (IsExecuteOverSetting())
            {
                AddHistory();
            }

            if (index < 0 || index >= wpList.Count)
                return;
            wpList.RemoveAt(index);

            if (IsExecuteOverSetting())
            {
                WPListChange?.Invoke();
            }
        }
        #endregion

        #region 摘取航点
        public VPS.CustomData.WP.VPSPosition GetWPPoint(int index)
        {
            if (index < 0)
                index = (index % wpList.Count + wpList.Count) % wpList.Count;
            if (index >= wpList.Count)
                index = index % wpList.Count;
            return new VPS.CustomData.WP.VPSPosition(wpList[index]);
        }
        #endregion

        #region 获取航点数
        public int GetWPCount()
        {
            return wpList.Count;
        }
        #endregion

        #endregion

        #region WPList 历史记录
        private List<List<VPS.CustomData.WP.VPSPosition>> history = new List<List<VPS.CustomData.WP.VPSPosition>>();
        public CountChangeHandle historyChange;

        #region 添加记录
        public void AddHistory()
        {
            var wpHistory = new List<VPS.CustomData.WP.VPSPosition>(GetWPList());

            history.Add(wpHistory);

            while (history.Count > 40)
                history.RemoveAt(0);

            historyChange?.Invoke(history.Count);
        }
        #endregion

        #region 撤销记录
        public void UndoHistory()
        {
            if (history.Count > 0)
            {
                int no = history.Count - 1;
                var pop = history[no];
                history.RemoveAt(no);

                BegionQuick();
                SetWPListHandle(pop);
                EndQuick();

                WPListChange?.Invoke();
                historyChange?.Invoke(history.Count);
            }
        }
        #endregion

        #endregion

        #region WPLIST 计算数据

        #region 航点列表去Home
        public static List<CustomData.WP.VPSPosition> WPListRemoveHome(
            List<CustomData.WP.VPSPosition> list)
        {
            List<CustomData.WP.VPSPosition> wpList = new List<CustomData.WP.VPSPosition>(list);
            if (wpList.Count > 0 && wpList[0].Command == WP.WPCommands.HomeCommand)
                wpList.RemoveAt(0);
            return wpList;
        }
        #endregion

        #region 航点列表高度框架统一
        public static List<CustomData.WP.VPSPosition> WPListChangeAltFrame(
            List<CustomData.WP.VPSPosition> list, string altitudeMode = "")
        {
            List<CustomData.WP.VPSPosition> wpList = new List<CustomData.WP.VPSPosition>(list);
            List<CustomData.WP.VPSPosition> retWPList = new List<CustomData.WP.VPSPosition>();

            double baseAlt = GetBaseAlt(wpList);
            foreach (var wp in wpList)
            {
                retWPList.Add(WPChangeAltFrame(wp, baseAlt, altitudeMode));
            }

            return retWPList;
        }
        #endregion

        #region 航点列表求航摄基线
        public static double GetBaseAlt(
            List<CustomData.WP.VPSPosition> wpLists,
            double defaultAlt = 0)
        {
            var wpList = WPListRemoveHome(wpLists);
            double totalAlt = 0;
            int doubleWP = 0;
            foreach (var wp in wpList)
            {
                if (WP.WPCommands.CoordsWPCommands.Contains(wp.Command))
                {
                    if (wp.Lat == 0 && wp.Lng == 0)
                        continue;
                    totalAlt += srtm.getAltitude(wp.Lat, wp.Lng).alt * CurrentState.multiplieralt;
                    doubleWP++;
                }
            }
            if (doubleWP != 0)
                return totalAlt / Math.Max(1, doubleWP);
            else
                return defaultAlt;
        }
        #endregion

        #region 航点列表求最大地面高程
        public static double GetMaxGroundAlt(List<CustomData.WP.VPSPosition> wpLists)
        {
            var wpList = WPListRemoveHome(wpLists);
            double MaxAlt = double.MinValue;
            foreach (var wp in wpList)
            {
                if (WP.WPCommands.CoordsWPCommands.Contains(wp.Command))
                {
                    if (wp.Lat == 0 && wp.Lng == 0)
                        continue;
                    double alt = srtm.getAltitude(wp.Lat, wp.Lng).alt * CurrentState.multiplieralt;
                    if (alt > MaxAlt)
                        MaxAlt = alt;
                }
            }
            if (MaxAlt == double.MinValue)
                return 0;
            return MaxAlt;
        }
        #endregion

        #region 航点列表求最小地面高程
        public static double GetMinGroundAlt(List<CustomData.WP.VPSPosition> wpLists)
        {
            var wpList = WPListRemoveHome(wpLists);
            double MinAlt = double.MaxValue;
            foreach (var wp in wpList)
            {
                if (WP.WPCommands.CoordsWPCommands.Contains(wp.Command))
                {
                    if (wp.Lat == 0 && wp.Lng == 0)
                        continue;
                    double alt = srtm.getAltitude(wp.Lat, wp.Lng).alt * CurrentState.multiplieralt;
                    if (alt < MinAlt)
                        MinAlt = alt;
                }
            }
            if (MinAlt == double.MaxValue)
                return 0;
            return MinAlt;
        }
        #endregion

        #region 获取平均绝对高度
        public static double GetAverAbsoluteAlt(List<CustomData.WP.VPSPosition> wpLists)
        {
            var wpList = WPListChangeAltFrame(
                WPListRemoveHome(wpLists), VPS.CustomData.EnumCollect.AltFrame.Absolute);
            double totalAlt = 0;
            int counter = 0;
            foreach (var wp in wpList)
            {
                if (WP.WPCommands.CoordsWPCommands.Contains(wp.Command))
                {
                    if (wp.Lat == 0 && wp.Lng == 0)
                        continue;
                    totalAlt += wp.Alt;
                    counter++;
                }
            }
            return counter > 0 ? totalAlt / counter : 0;
        }
        #endregion

        #region 获取不合格节点
        public static List<double[]> GetValidPoint(List<CustomData.WP.VPSPosition> wpLists)
        {
            var wpList = WPListChangeAltFrame(
                WPListRemoveHome(wpLists), VPS.CustomData.EnumCollect.AltFrame.Terrain);
            List<double[]> valid = new List<double[]>();
            for (int index = 0; index < wpList.Count; index++) 
            {
                if(wpList[index].Alt < 0)
                {
                    valid.Add(new double[] { index, wpList[index].Alt });
                }
            }

            return valid;
        }
        #endregion

        #region 航点列表求航程
        public static double GetTotalDist(List<CustomData.WP.VPSPosition> wpLists)
        {
            var wpList = WPListRemoveHome(wpLists);
            wpList = WPListChangeAltFrame(wpLists, EnumCollect.AltFrame.Absolute);

            double totalDist = 0.0;
            for (int index = 1; index < wpList.Count; index++)
            {
                totalDist += Math.Sqrt(
                    Math.Pow(wpList[index].ToWGS84().GetDistance(wpList[index - 1].ToWGS84()), 2) +
                    Math.Pow(wpList[index].Alt - wpList[index - 1].Alt, 2)) *
                    CurrentState.multiplierdist;
            }
            return totalDist;
        }
        #endregion

        #region 航点高度框架转换
        public static CustomData.WP.VPSPosition WPChangeAltFrame(
            CustomData.WP.VPSPosition cur, double baseAlt, string altitudeMode = "") {
            var point = new CustomData.WP.VPSPosition(cur);
            double alt = srtm.getAltitude(point.Lat, point.Lng).alt * CurrentState.multiplieralt;
            if (altitudeMode == EnumCollect.AltFrame.Relative)
            {
                if (point.AltMode == EnumCollect.AltFrame.Relative)
                    ;
                else if (point.AltMode == EnumCollect.AltFrame.Absolute)
                    point.Alt = point.Alt - baseAlt;
                else if (point.AltMode == EnumCollect.AltFrame.Terrain)
                    point.Alt = point.Alt + alt - baseAlt;
                else
                    ;
                point.AltMode = EnumCollect.AltFrame.Relative;
            }
            else if (altitudeMode == EnumCollect.AltFrame.Absolute)
            {
                if (point.AltMode == EnumCollect.AltFrame.Relative)
                    point.Alt = point.Alt + baseAlt;
                else if (point.AltMode == EnumCollect.AltFrame.Absolute)
                    ;
                else if (point.AltMode == EnumCollect.AltFrame.Terrain)
                    point.Alt = point.Alt + alt;
                else
                    point.Alt = point.Alt + baseAlt;
                point.AltMode = EnumCollect.AltFrame.Absolute;
            }
            else if (altitudeMode == EnumCollect.AltFrame.Terrain)
            {
                if (point.AltMode == EnumCollect.AltFrame.Relative)
                    point.Alt = point.Alt + baseAlt - alt;
                else if (point.AltMode == EnumCollect.AltFrame.Absolute)
                    point.Alt = point.Alt - alt;
                else if (point.AltMode == EnumCollect.AltFrame.Terrain)
                    ;
                else
                    point.Alt = point.Alt + baseAlt - alt;
                point.AltMode = EnumCollect.AltFrame.Terrain;
            }
            else
                ;
            return point;
        }
        #endregion

        #region 计算航点坡度
        public static double GetPointGrad(CustomData.WP.VPSPosition prev, CustomData.WP.VPSPosition cur, double baseAlt = -1)
        {
            if (prev != null && cur != null)
            {
                double baseAltCopy = baseAlt;
                var prevPoint = new CustomData.WP.VPSPosition(prev);
                var curPoint = new CustomData.WP.VPSPosition(cur);
                if (baseAltCopy == -1)
                {
                    baseAltCopy = 0;
                    baseAltCopy += (srtm.getAltitude(prev.Lat, prev.Lng).alt * CurrentState.multiplieralt);
                    baseAltCopy += (srtm.getAltitude(prev.Lat, prev.Lng).alt * CurrentState.multiplieralt);
                }
                prevPoint = WPChangeAltFrame(prevPoint, baseAlt, EnumCollect.AltFrame.Absolute);
                curPoint = WPChangeAltFrame(curPoint, baseAlt, EnumCollect.AltFrame.Absolute);
                return (prevPoint.Alt - curPoint.Alt) /
                    curPoint.ToWGS84().GetDistance(prevPoint.ToWGS84());
            }
            return 0;
        }
        #endregion

        #region 计算航点距离
        public static double GetPointDist(
            CustomData.WP.VPSPosition prev, CustomData.WP.VPSPosition cur, double baseAlt = -1)
        {
            if (prev != null && cur != null)
            {
                double baseAltCopy = baseAlt;
                var prevPoint = new CustomData.WP.VPSPosition(prev);
                var curPoint = new CustomData.WP.VPSPosition(cur);
                if (baseAltCopy == -1)
                {
                    baseAltCopy = 0;
                    baseAltCopy += (srtm.getAltitude(prev.Lat, prev.Lng).alt * CurrentState.multiplieralt);
                    baseAltCopy += (srtm.getAltitude(prev.Lat, prev.Lng).alt * CurrentState.multiplieralt);
                }
                prevPoint = WPChangeAltFrame(prevPoint, baseAlt, EnumCollect.AltFrame.Absolute);
                curPoint = WPChangeAltFrame(curPoint, baseAlt, EnumCollect.AltFrame.Absolute);

                return Math.Sqrt(
                    Math.Pow(curPoint.ToWGS84().GetDistance(prevPoint.ToWGS84()), 2) +
                    Math.Pow(curPoint.Alt - prevPoint.Alt, 2)) *
                    CurrentState.multiplierdist;
            }
            return 0;
        }
        #endregion

        #region 计算航点方位
        public static double GetPointAZ(
            CustomData.WP.VPSPosition prev, CustomData.WP.VPSPosition cur, double baseAlt = -1)
        {
            if (prev != null && cur != null)
            {
                double baseAltCopy = baseAlt;
                var prevPoint = new CustomData.WP.VPSPosition(prev);
                var curPoint = new CustomData.WP.VPSPosition(cur);
                if (baseAltCopy == -1)
                {
                    baseAltCopy = 0;
                    baseAltCopy += (srtm.getAltitude(prev.Lat, prev.Lng).alt * CurrentState.multiplieralt);
                    baseAltCopy += (srtm.getAltitude(prev.Lat, prev.Lng).alt * CurrentState.multiplieralt);
                }
                prevPoint = WPChangeAltFrame(prevPoint, baseAlt, EnumCollect.AltFrame.Absolute);
                curPoint = WPChangeAltFrame(curPoint, baseAlt, EnumCollect.AltFrame.Absolute);

                return (curPoint.ToWGS84().GetBearing(prevPoint.ToWGS84()) + 180) % 360;
            }
            return 0;
        }
        #endregion

        #region 计算重叠度的航线误差
        public static double GetPointOverlap(double lap, double relative, double baseAlt, double alt)
        {
            return lap + (1 - lap) * (baseAlt - alt) / relative;
        }
        #endregion

        #region 计算区域面积
        public double GetPolygonArea(List<CustomData.WP.VPSPosition> polygon)
        {
            // should be a closed polygon
            // coords are in lat long
            // need utm to calc area

            if (polygon.Count == 0)
            {
                return 0;
            }

            // close the polygon
            if (polygon[0] != polygon[polygon.Count - 1])
                polygon.Add(polygon[0]); // make a full loop

            var ctfac = new ProjNet.CoordinateSystems.Transformations.CoordinateTransformationFactory();

            var wgs84 = ProjNet.CoordinateSystems.GeographicCoordinateSystem.WGS84;

            int utmzone = (int)((polygon[0].Lng - -186.0) / 6.0);

            var utm = ProjNet.CoordinateSystems.ProjectedCoordinateSystem.WGS84_UTM(utmzone,
                polygon[0].Lat < 0 ? false : true);

            var trans = ctfac.CreateFromCoordinateSystems(wgs84, utm);

            double prod1 = 0;
            double prod2 = 0;

            for (int a = 0; a < (polygon.Count - 1); a++)
            {
                double[] pll1 = { polygon[a].Lng, polygon[a].Lat };
                double[] pll2 = { polygon[a + 1].Lng, polygon[a + 1].Lat };

                double[] p1 = trans.MathTransform.Transform(pll1);
                double[] p2 = trans.MathTransform.Transform(pll2);

                prod1 += p1[0] * p2[1];
                prod2 += p1[1] * p2[0];
            }

            double answer = (prod1 - prod2) / 2;

            if (polygon[0] == polygon[polygon.Count - 1])
                polygon.RemoveAt(polygon.Count - 1); // unmake a full loop

            return Math.Abs(answer);
        }
        #endregion

        #endregion

        #region HOME 初始位置
        public ChangeHandle HomeChange;

        #region 获取初始位置
        public VPS.CustomData.WP.VPSPosition GetHomePosition()
        {
            if (currentHome == null)
                return null;
            var retHome = new VPS.CustomData.WP.VPSPosition(currentHome);
            if (retHome.Command != WPCommands.HomeCommand)
                retHome.Command = WPCommands.HomeCommand;
            return retHome;
        }
        #endregion

        #region 设置初始位置
        public void SetHomePosition(VPS.CustomData.WP.VPSPosition position)
        {
            currentHome = new VPS.CustomData.WP.VPSPosition(position);

            if(!string.IsNullOrEmpty(defaultLayerPath) &&
                !string.IsNullOrEmpty(currentLayerPath) &&
                defaultLayerPath == currentLayerPath)
            {
                defaultHome = new VPS.CustomData.WP.VPSPosition(position);
            }


            if (IsExecuteOverSetting())
            {
                HomeChange?.Invoke();
                AddHistory();
            }
        }
        #endregion

        #endregion

        #region CURRENT 当前位置
        public PositionChangeHandle CurrentChange;
        public void SetCurrentPosition(VPS.CustomData.WP.VPSPosition position)
        {
            CurrentChange?.Invoke(position);
        }
        #endregion

        #region LAYER 图层信息
        private string currentLayerPath = null;
        private VPS.CustomData.WP.VPSPosition currentHome = new VPS.CustomData.WP.VPSPosition();
        private VPS.CustomData.WP.VPSRect currentRect = new VPS.CustomData.WP.VPSRect();
        private string defaultLayerPath = null;
        private VPS.CustomData.WP.VPSPosition defaultHome = null;
        private VPS.CustomData.WP.VPSRect defaultRect = new VPS.CustomData.WP.VPSRect();

        //public GDAL.GDAL.GeoBitmap currentLayer;
        public ChangeHandle WorkspaceRectChange;
        public ChangeHandle DefaultWorkspaceRectChange;

        #region 设置图层信息


        public void SetLayer(string path, bool isDefault = true)
        {
            currentLayerPath = path;
            if (isDefault || defaultLayerPath == null)
                defaultLayerPath = path;
        }

        public void SetLayerLimit(
            VPS.CustomData.WP.VPSRect rect, VPS.CustomData.WP.VPSPosition home, bool isDefault = true)
        {
            currentRect = rect;
            SetHomePosition(home);
            if (isDefault || defaultHome == null)
            {
                defaultRect = rect;
                defaultHome = new VPS.CustomData.WP.VPSPosition(home);
                if (defaultHome.Command != WPCommands.HomeCommand)
                    defaultHome.Command = WPCommands.HomeCommand;
                if (IsExecuteOverSetting())
                {
                    DefaultWorkspaceRectChange?.Invoke();
                    AddHistory();
                }
            }
            if (IsExecuteOverSetting())
            {
                WorkspaceRectChange?.Invoke();
                AddHistory();
            }
        }

        public void SetDefaultLayer(string path, VPS.CustomData.WP.VPSRect rect, VPS.CustomData.WP.VPSPosition home)
        {
            defaultLayerPath = path;
            defaultRect = rect;
            defaultHome = home;
        }
        #endregion

        #region 获取图层信息
        public string GetLayer()
        {
            if (currentLayerPath == null)
                return null;
            return currentLayerPath;
        }

        public string GetDefaultLayer()
        {
            if (defaultLayerPath == null)
                return null;
            return defaultLayerPath;
        }

        public VPS.CustomData.WP.VPSPosition GetLayerHome()
        {
            return GetHomePosition();
        }

        public VPS.CustomData.WP.VPSPosition GetDefaultLayerHome()
        {
            if (defaultHome == null)
                return null;
            VPS.CustomData.WP.VPSPosition retHome = new VPS.CustomData.WP.VPSPosition(defaultHome);
            if (retHome.Command != WPCommands.HomeCommand)
                retHome.Command = WPCommands.HomeCommand;
            return retHome;
        }

        public VPSRect GetLayerRect()
        {
            return currentRect;
        }

        public VPSRect GetDefaultLayerRect()
        {
            return defaultRect;
        }
        #endregion

        #region 是否为默认图层
        public bool IsDefaultLayer(string layer)
        {
            if (defaultLayerPath == null || layer == null)
                return false;
            return defaultLayerPath == layer;
        }
        #endregion

        #region 默认图层已失效
        public void DefaultLayerInvalid()
        {
            defaultLayerPath = null;
        }
        #endregion

        #endregion

        #region POLYGON 区域点
        private List<CustomData.WP.VPSPosition> polyList = new List<CustomData.WP.VPSPosition>();
        public ChangeHandle PolygonListChange;

        #region 设置区域点
        public void SetPolyListHandle(List<CustomData.WP.VPSPosition> polygonList)
        {
            polyList = new List<CustomData.WP.VPSPosition>(polygonList);

            if (IsExecuteOverSetting())
            {
                PolygonListChange?.Invoke();
            }
        }
        #endregion

        #region 获取区域点
        public List<CustomData.WP.VPSPosition> GetPolyList()
        {
            var polygonList = new List<CustomData.WP.VPSPosition>(polyList);
            return polygonList;
        }
        #endregion

        #region 添加区域点
        public void AddPolyHandle(CustomData.WP.VPSPosition poly)
        {
            var polygon = new CustomData.WP.VPSPosition(poly);
            polyList.Add(polygon);

            if (IsExecuteOverSetting())
            {
                PolygonListChange?.Invoke();
            }
        }
        #endregion

        #region 插入区域点
        public void InsertPolyHandle(int index, CustomData.WP.VPSPosition poly)
        {
            var polygon = new CustomData.WP.VPSPosition(poly);
            polyList.Insert(index, polygon);

            if (IsExecuteOverSetting())
            {
                PolygonListChange?.Invoke();
            }
        }
        #endregion

        #region 移动区域点
        public void MovePolyHandle(int index, CustomData.WP.VPSPosition poly)
        {
            var polygon = new CustomData.WP.VPSPosition(poly);
            polyList[index] =  polygon;

            if (IsExecuteOverSetting())
            {
                PolygonListChange?.Invoke();
            }
        }
        #endregion

        #region 删除区域点
        public void DeletePolyHandle(int index)
        {
            polyList.RemoveAt(index);

            if (IsExecuteOverSetting())
            {
                PolygonListChange?.Invoke();
            }
        }
        #endregion

        #region 抽取区域点
        public CustomData.WP.VPSPosition GetPolyPoint(int index)
        {
            if (index < 0)
                index = (index % polyList.Count + polyList.Count) % polyList.Count;
            if (index >= polyList.Count)
                index = index % polyList.Count;
            return new CustomData.WP.VPSPosition(polyList[index]);
        }
        #endregion

        #region 清空区域点
        public void ClearPolyHandle()
        {
            polyList.Clear();

            if (IsExecuteOverSetting())
            {
                PolygonListChange?.Invoke();
            }
        }
        #endregion

        #region 获取区域点数
        public int GetPolyCount()
        {
            return polyList.Count;
        }
        #endregion

        #endregion
    }
}
