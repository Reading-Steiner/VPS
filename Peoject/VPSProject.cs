using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPS.CustomData.EnumCollect;
using VPS.CustomData.WP;

namespace VPS.Project
{
    public class VPSProject
    {
        #region 工程列表
        private static List<VPSProject> mProjectStore;
        private static int currentProjectIndex = -1;
        public static VPSProject mInstance {
            get
            {
                if (currentProjectIndex < 0 && currentProjectIndex >= mProjectStore.Count)
                    return CreateProject(true);
                else
                    return mProjectStore[currentProjectIndex];
            }
            set
            {
                if (value == null)
                {
                    currentProjectIndex = -1;
                    return;
                }
                bool inLimit = false;
                for (int index = 0; index < mProjectStore.Count; index++)
                {
                    if (mProjectStore[index] == value)
                    {
                        inLimit = true;
                        currentProjectIndex = index;
                    }
                }
                if(!inLimit)
                {
                    if (currentProjectIndex + 1 >= 0 && currentProjectIndex + 1 < mProjectStore.Count)
                        mProjectStore.Insert(++currentProjectIndex, value);
                    else
                    {
                        mProjectStore.Add(value);
                        currentProjectIndex = mProjectStore.Count - 1;
                    }
                }
            }
        }


        #region 创建工程
        public static VPSProject CreateProject(bool isDefault = false)
        {
            VPSProject instance = new VPSProject();
            if (isDefault)
                mInstance = instance;
            else
                mProjectStore.Add(instance);
            return instance;
        }
        #endregion

        #endregion

        #region 构造函数
        private VPSProject()
        {
            BegionQuickPrivate();
            mHomePosition = new VPSPosition(0, 0, 0, AltFrame.Terrain, WPCommands.HomeCommand);

            mWPListHistory = new List<List<VPSPosition>>();
            mWPList = new List<VPSPosition>();
            mWPListHistory.Add(new List<VPSPosition>(mWPList));
            firstRecord = lastRecord = currentRecord = 0;

            mPolygonHistory = new List<List<VPSPosition>>();
            mPolygon = new List<VPSPosition>();
            mPolygonHistory.Add(new List<VPSPosition>(mPolygon));
            firstPolygonRecord = lastPolygonRecord = currentPolygonRecord = 0;


            mWorkSpace = new List<double>(new double[] { 0, 0, 0, 0, 0, 0 });

            EndQuickPrivate();
        }
        #endregion

        #region 委托类型
        //变化型委托
        public delegate void ChangeHandle();
        //状态型委托
        public delegate void StatusHandle(bool status);
        #endregion

        #region 快速添加

        #region 外部标记
        private readonly object QuickAddLock = new object();
        /// <summary>
        /// 快速添加，不触发数据变化响应函数
        /// </summary>
        private int QuickAdd { set; get; } = 0;

        public void BegionQuick()
        {
            lock (QuickAddLock)
            {
                QuickAdd = QuickAdd + 1;
            }
        }

        public void EndQuick()
        {
            lock (QuickAddLock)
            {
                QuickAdd = QuickAdd - 1;
            }
        }
        #endregion

        #region 内部标记
        /// <summary>
        /// 快速添加，不触发数据变化响应函数（用于类内）
        /// </summary>
        private bool QuickAddPrivate { set; get; }

        private void BegionQuickPrivate()
        {
            QuickAddPrivate = true;
        }

        private void EndQuickPrivate()
        {
            QuickAddPrivate = false;
        }
        #endregion

        #region 判断函数
        public bool IsQuickAdd()
        {
            lock (QuickAddLock)
            {
                return QuickAdd <= 0 || QuickAddPrivate;
            }
        }
        #endregion

        #endregion

        #region HOME
        private VPSPosition mHomePosition;
        public event ChangeHandle HomeChange;

        public VPSPosition HomePosition
        {
            get
            {
                if (mHomePosition == null)
                    return null;
                var retHome = new VPSPosition(mHomePosition);
                if (retHome.Command != WPCommands.HomeCommand)
                    retHome.Command = WPCommands.HomeCommand;
                return retHome;
            }

            set
            {
                mHomePosition = new VPSPosition(value);

                if (mHomePosition.Command != WPCommands.HomeCommand)
                    mHomePosition.Command = WPCommands.HomeCommand;

                if (!IsQuickAdd())
                {
                    HomeChange?.Invoke();
                }
            }
        }
        #endregion

        #region 航线
        private List<VPSPosition> mWPList;
        public event ChangeHandle WPListChange;

        #region 设置航线
        public void SetWPListHandle(List<VPSPosition> list)
        {
            bool hasHome = false;
            if (list.Count > 0)
            {
                if (list[0].Command == WPCommands.HomeCommand)
                {
                    if (list[0] != HomePosition)
                        HomePosition = mWPList[0];
                    hasHome = true;
                }

            }
            if (hasHome)
                mWPList = new List<VPSPosition>(list.GetRange(1, list.Count - 1));
            else
                mWPList = new List<VPSPosition>(list);


            if (!IsQuickAdd())
            {
                AppendWPListHistory();
                WPListChange?.Invoke();
            }
        }
        #endregion

        #region 扩充航线
        public void AppendWPListHandle(List<VPSPosition> list)
        {
            var lastList = new List<VPSPosition>(list);
            if (lastList.Count <= 0)
                return;

            mWPList.AddRange(lastList);

            if (!IsQuickAdd())
            {
                AppendWPListHistory();
                WPListChange?.Invoke();
            }
        }
        #endregion

        #region 清空航线
        public void ClearWPListHandle()
        {
            mWPList.Clear();

            if (!IsQuickAdd())
            {
                AppendWPListHistory();
                WPListChange?.Invoke();
            }
        }
        #endregion

        #region 获取航线
        public VPSGeometry GetWPList()
        {
            List<VPSPosition> retList = new List<VPSPosition>(mWPList);

            if ((retList.Count <= 0) || retList[0].Command != WPCommands.HomeCommand)
                retList.Insert(0, HomePosition);

            var geom = new VPSGeometry();
            geom.SetGeometryHandle(retList);

            return geom;
        }
        #endregion

        #region 获取航点
        public VPSPosition GetWPPoint(int index)
        {
            if (index < 0)
                index = (index % mWPList.Count + mWPList.Count) % mWPList.Count;
            if (index >= mWPList.Count)
                index = index % mWPList.Count;
            return new VPSPosition(mWPList[index]);
        }
        #endregion

        #region 获取航点数
        public int WPCount
        {
            get { return mWPList.Count; }
        }
        #endregion

        //#region 添加航点
        //public int AddWPHandle(Position wp)
        //{
        //    int index = mWPList.Count;
        //    mWPList.Add(new Position(wp));

        //    if (!IsQuickAdd())
        //    {
        //        AppendWPListHistory();
        //        WPListChange?.Invoke();
        //    }

        //    return index;
        //}
        //#endregion

        //#region 插入航点
        //public void InsertWPHandle(int index, Position wp)
        //{
        //    if (index < 0)
        //        index = 0;
        //    if (index >= mWPList.Count)
        //        mWPList.Add(new Position(wp));
        //    else
        //        mWPList.Insert(index, new Position(wp));

        //    if (!IsQuickAdd())
        //    {
        //        AppendWPListHistory();
        //        WPListChange?.Invoke();
        //    }
        //}
        //#endregion

        //#region 修改航点
        //public void SetWPHandle(int index, Position wp)
        //{
        //    if (index < 0)
        //        index = 0;

        //    if (index >= mWPList.Count)
        //        mWPList.Add(new Position(wp));
        //    else
        //        mWPList[index] = new Position(wp);

        //    if (!IsQuickAdd())
        //    {
        //        AppendWPListHistory();
        //        WPListChange?.Invoke();
        //    }
        //}
        //#endregion

        //#region 删除航点
        //public void DeleteWPHandle(int index)
        //{
        //    if (index < 0 || index >= mWPList.Count)
        //        return;
        //    mWPList.RemoveAt(index);

        //    if (!IsQuickAdd())
        //    {
        //        AppendWPListHistory();
        //        WPListChange?.Invoke();
        //    }
        //}
        //#endregion

        //#endregion

        #endregion

        #region 区域
        private List<VPSPosition> mPolygon;
        public event ChangeHandle PolygonChange;

        #region 设置区域
        public void SetPolygonHandle(List<VPSPosition> polygonList)
        {
            mPolygon = new List<VPSPosition>(polygonList);

            if (!IsQuickAdd())
            {
                AppendPolygonHistory();
                PolygonChange?.Invoke();
            }
        }
        #endregion

        #region 获取区域
        public VPSGeometry GetPolygon()
        {
            var geom = new VPSGeometry();
            geom.SetGeometryHandle(mPolygon);
            return geom;
        }
        #endregion

        #region 扩充区域 
        public void AppendPolygonHandle(List<VPSPosition> list)
        {
            var lastList = new List<VPSPosition>(list);
            if (lastList.Count <= 0)
                return;

            mPolygon.AddRange(lastList);

            if (!IsQuickAdd())
            {
                AppendPolygonHistory();
                PolygonChange?.Invoke();
            }
        }
        #endregion

        #region 获取区域点
        public VPSPosition GetPolyPoint(int index)
        {
            if (index < 0)
                index = (index % mPolygon.Count + mPolygon.Count) % mPolygon.Count;
            if (index >= mPolygon.Count)
                index = index % mPolygon.Count;
            return new VPSPosition(mPolygon[index]);
        }
        #endregion

        #region 清空区域点
        public void ClearPolyHandle()
        {
            mPolygon.Clear();

            if (!IsQuickAdd())
            {
                AppendPolygonHistory();
                PolygonChange?.Invoke();
            }
        }
        #endregion

        #region 获取区域点数
        public int PolygonCount
        {
            get
            {
                return mPolygon.Count;
            }

        }
        #endregion

        //#region 添加区域点
        //public void AppendPolyHandle(Position poly)
        //{
        //    var polygon = new Position(poly);
        //    mPolygon.Add(polygon);

        //    if (!IsQuickAdd())
        //    {
        //        AppendPolygonHistory();
        //        PolygonChange?.Invoke();
        //    }
        //}
        //#endregion

        //#region 插入区域点
        //public void InsertPolyHandle(int index, Position poly)
        //{
        //    var polygon = new Position(poly);
        //    mPolygon.Insert(index, polygon);

        //    if (!IsQuickAdd())
        //    {
        //        AppendPolygonHistory();
        //        PolygonChange?.Invoke();
        //    }
        //}
        //#endregion

        //#region 移动区域点
        //public void MovePolyHandle(int index, Position poly)
        //{
        //    var polygon = new Position(poly);
        //    mPolygon[index] = polygon;

        //    if (!IsQuickAdd())
        //    {
        //        AppendPolygonHistory();
        //        PolygonChange?.Invoke();
        //    }
        //}
        //#endregion

        //#region 删除区域点
        //public void DeletePolyHandle(int index)
        //{
        //    mPolygon.RemoveAt(index);

        //    if (!IsQuickAdd())
        //    {
        //        AppendPolygonHistory();
        //        PolygonChange?.Invoke();
        //    }
        //}
        //#endregion

        #endregion

        #region 航点历史记录
        private List<List<VPSPosition>> mWPListHistory;
        private readonly int recordCount = 20;
        private int currentRecord = -1;
        private int firstRecord = -1;
        private int lastRecord = -1;
        public event StatusHandle ExistNextRecord;
        public event StatusHandle ExistPrevRecord;

        #region 添加记录
        private void AppendWPListHistory()
        {
            List<VPSPosition> wpList = new List<VPSPosition>(mWPList);

            currentRecord = (currentRecord + 1) % recordCount;

            if (currentRecord >= mWPListHistory.Count)
            {
                currentRecord = mWPListHistory.Count;
                mWPListHistory.Add(wpList);
            }
            else
                mWPListHistory[currentRecord] = wpList;

            lastRecord = currentRecord;
            if(firstRecord == currentRecord)
            {
                firstRecord = (firstRecord + 1) % recordCount;
            }

            if (currentRecord == firstRecord)
                ExistPrevRecord?.Invoke(false);
            else
                ExistPrevRecord?.Invoke(true);
            if (currentRecord == lastRecord)
                ExistNextRecord?.Invoke(false);
            else
                ExistNextRecord?.Invoke(true);

        }
        #endregion

        #region 回退记录
        private void RebackWPListHistory()
        {
            if (currentRecord == firstRecord)
                return;

            currentRecord = (currentRecord - 1 + mWPListHistory.Count) % mWPListHistory.Count;
            BegionQuickPrivate();

            mWPList = new List<VPSPosition>(mWPListHistory[currentRecord]);

            EndQuickPrivate();

            if (currentRecord == firstRecord)
                ExistPrevRecord?.Invoke(false);
            else
                ExistPrevRecord?.Invoke(true);
            if (currentRecord == lastRecord)
                ExistNextRecord?.Invoke(false);
            else
                ExistNextRecord?.Invoke(true);

            WPListChange?.Invoke();
        }
        #endregion

        #region 恢复记录
        private void forebackWPListHistory()
        {
            if (currentRecord == lastRecord)
                return;

            currentRecord = (currentRecord + 1) % mWPListHistory.Count;
            BegionQuickPrivate();

            mWPList = new List<VPSPosition>(mWPListHistory[currentRecord]);

            EndQuickPrivate();

            if (currentRecord == firstRecord)
                ExistPrevRecord?.Invoke(false);
            else
                ExistPrevRecord?.Invoke(true);
            if (currentRecord == lastRecord)
                ExistNextRecord?.Invoke(false);
            else
                ExistNextRecord?.Invoke(true);

            WPListChange?.Invoke();
        }
        #endregion

        #endregion

        #region 区域历史记录
        private List<List<VPSPosition>> mPolygonHistory;
        private readonly int recordPolygonCount = 20;
        private int currentPolygonRecord = -1;
        private int firstPolygonRecord = -1;
        private int lastPolygonRecord = -1;
        public event StatusHandle ExistNextPolygonRecord;
        public event StatusHandle ExistPrevPolygonRecord;

        #region 添加记录
        private void AppendPolygonHistory()
        {
            List<VPSPosition> polygon = new List<VPSPosition>(mPolygon);

            currentPolygonRecord = (currentPolygonRecord + 1) % recordPolygonCount;

            if (currentPolygonRecord >= mPolygonHistory.Count)
            {
                currentPolygonRecord = mPolygonHistory.Count;
                mPolygonHistory.Add(polygon);
            }
            else
                mPolygonHistory[currentPolygonRecord] = polygon;

            lastPolygonRecord = currentPolygonRecord;
            if (firstPolygonRecord == currentPolygonRecord)
            {
                firstPolygonRecord = (firstPolygonRecord + 1) % recordPolygonCount;
            }

            if (currentPolygonRecord == firstPolygonRecord)
                ExistPrevPolygonRecord?.Invoke(false);
            else
                ExistPrevPolygonRecord?.Invoke(true);
            if (currentPolygonRecord == lastPolygonRecord)
                ExistNextPolygonRecord?.Invoke(false);
            else
                ExistNextPolygonRecord?.Invoke(true);

        }
        #endregion

        #region 回退记录
        private void RebackPolygonHistory()
        {
            if (currentPolygonRecord == firstPolygonRecord)
                return;

            currentPolygonRecord = (currentPolygonRecord - 1 + mPolygonHistory.Count) % mPolygonHistory.Count;
            BegionQuickPrivate();

            mPolygon = new List<VPSPosition>(mPolygonHistory[currentPolygonRecord]);

            EndQuickPrivate();

            if (currentPolygonRecord == firstPolygonRecord)
                ExistPrevPolygonRecord?.Invoke(false);
            else
                ExistPrevPolygonRecord?.Invoke(true);
            if (currentPolygonRecord == lastPolygonRecord)
                ExistNextPolygonRecord?.Invoke(false);
            else
                ExistNextPolygonRecord?.Invoke(true);

            PolygonChange?.Invoke();
        }
        #endregion

        #region 恢复记录
        private void forebackPolygonHistory()
        {
            if (currentPolygonRecord == lastPolygonRecord)
                return;

            currentPolygonRecord = (currentPolygonRecord + 1) % mPolygonHistory.Count;
            BegionQuickPrivate();

            mPolygon = new List<VPSPosition>(mPolygonHistory[currentPolygonRecord]);

            EndQuickPrivate();

            if (currentPolygonRecord == firstPolygonRecord)
                ExistPrevPolygonRecord?.Invoke(false);
            else
                ExistPrevPolygonRecord?.Invoke(true);
            if (currentPolygonRecord == lastPolygonRecord)
                ExistNextPolygonRecord?.Invoke(false);
            else
                ExistNextPolygonRecord?.Invoke(true);

            PolygonChange?.Invoke();
        }
        #endregion

        #endregion

        #region 工作区
        private List<double> mWorkSpace;

        #region 设置工作区
        public void SetWorkSpace(List<VPSPosition> points)
        {
            if (points.Count <= 0)
                return;
            
            double latNorth = points[0].Lat; double latSouth = points[0].Lat;
            double lngEast = points[0].Lng; double lngWest = points[0].Lng;
            double altTop = points[0].Alt; double altBottom = points[0].Alt;

            foreach (VPSPosition point in points)
            {
                if (point.Alt > altTop)
                    altTop = point.Alt;
                else if (point.Alt < altBottom)
                    altBottom = point.Alt;

                if (point.Lat > latNorth)
                    latNorth = point.Lat;
                else if (point.Lat < latSouth)
                    latSouth = point.Lat;

                if (point.Alt > lngEast)
                    lngEast = point.Alt;
                else if (point.Alt < lngWest)
                    lngWest = point.Alt;
            }
            mWorkSpace.Clear();
            mWorkSpace.Add(latNorth);
            mWorkSpace.Add(latSouth);
            mWorkSpace.Add(lngEast);
            mWorkSpace.Add(lngWest);
            mWorkSpace.Add(altTop);
            mWorkSpace.Add(altBottom);
        }
        #endregion

        #region 获取工作区
        public double mWorkSpaceNorth
        {
            get
            {
                if (mWorkSpace.Count != 6)
                    return 0;
                else
                    return mWorkSpace[0];
            }
        }

        public double mWorkSpaceSouth
        {
            get
            {
                if (mWorkSpace.Count != 6)
                    return 0;
                else
                    return mWorkSpace[1];
            }
        }

        public double mWorkSpaceEast
        {
            get
            {
                if (mWorkSpace.Count != 6)
                    return 0;
                else
                    return mWorkSpace[2];
            }
        }

        public double mWorkSpaceWest
        {
            get
            {
                if (mWorkSpace.Count != 6)
                    return 0;
                else
                    return mWorkSpace[3];
            }
        }

        public double mWorkSpaceTop
        {
            get
            {
                if (mWorkSpace.Count != 6)
                    return 0;
                else
                    return mWorkSpace[4];
            }
        }

        public double mWorkSpaceBottom
        {
            get
            {
                if (mWorkSpace.Count != 6)
                    return 0;
                else
                    return mWorkSpace[5];
            }
        }

        #endregion

        #endregion
    }
}
