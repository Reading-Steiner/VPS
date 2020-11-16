using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPS.Utilities;

namespace VPS.WP
{
    class WPGlobalData
    {
        static public WPGlobalData instance = null;

        public WPGlobalData()
        {
            instance = this;
            LoadConfig();
        }

        ~WPGlobalData()
        {
            SaveConfig();
        }

        #region 参数
        private void LoadConfig()
        {
            PointLatLngAlt home = new PointLatLngAlt();
            foreach (string key in Settings.Instance.Keys)
            {
                switch (key)
                {
                    case "Main_HomeLat":
                        {
                            if (double.TryParse(Settings.Instance[key], out double lat))
                                home.Lat = lat;
                        }
                        break;
                    case "Main_HomeLng":
                        {
                            if (double.TryParse(Settings.Instance[key], out double lng))
                                home.Lng = lng;
                        }
                        break;
                    case "Main_HomeAlt":
                        {
                            if (double.TryParse(Settings.Instance[key], out double alt))
                                home.Alt = alt;
                        }
                        break;
                    case "Main_HomeFrame":
                        home.Tag2 = "" + Settings.Instance[key];
                        break;
                }
            }
            SetHomePosition(home);
        }

        private void SaveConfig()
        {
            Settings.Instance["Main_HomeLat"] = homePosition.Lat.ToString();
            Settings.Instance["Main_HomeLng"] = homePosition.Lng.ToString();
            Settings.Instance["Main_HomeAlt"] = homePosition.Alt.ToString();
            Settings.Instance["Main_HomeFrame"] = homePosition.Tag2;
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
        public void ExecuteStartSetting()
        {
            AddHistory();
        }

        public void ExecuteOverSetting()
        {
            WPListChange?.Invoke();
        }
        #endregion

        #endregion

        public delegate void ChangeHandle();
        public delegate void PositionChangeHandle(PointLatLngAlt position);
        public delegate void CountChangeHandle(int count);

        #region WPLIST 航点
        private List<PointLatLngAlt> wpList = new List<PointLatLngAlt>();
        public ChangeHandle WPListChange;

        #region 获取航点
        public List<PointLatLngAlt> GetWPList()
        {
            List<PointLatLngAlt> retList = new List<PointLatLngAlt>(wpList);

            if ((retList.Count <= 0) || retList[0].Tag != VPS.WP.WPCommands.HomeCommand)
                retList.Insert(0, GetHomePosition());

            return retList;
        }
        #endregion

        #region 设置航点
        public void SetWPListHandle(List<PointLatLngAlt> list)
        {
            if (IsExecuteOverSetting())
            {
                AddHistory();
            }
            wpList = new List<PointLatLngAlt>(list);
            if (wpList.Count > 0)
            {
                if (wpList[0].Tag == WPCommands.HomeCommand)
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
        public void AppendWPListHandle(List<PointLatLngAlt> list)
        {
            if (IsExecuteOverSetting())
            {
                AddHistory();
            }
            var apWPList = new List<PointLatLngAlt>(list);
            if (apWPList.Count > 0)
            {
                if (apWPList[0].Tag == WPCommands.HomeCommand)
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
        public int AddWPHandle(PointLatLngAlt wp)
        {
            if (IsExecuteOverSetting())
            {
                AddHistory();
            }

            int index = wpList.Count;
            wpList.Add(new PointLatLngAlt(wp));

            if (IsExecuteOverSetting())
            {
                WPListChange?.Invoke();
            }

            return index;
        }
        #endregion

        #region 插入航点
        public void InsertWPHandle(int index, PointLatLngAlt wp)
        {
            if (IsExecuteOverSetting())
            {
                AddHistory();
            }

            if (index < 0)
                index = 0;
            if (index >= wpList.Count)
                wpList.Add(new PointLatLngAlt(wp));
            else
                wpList.Insert(index, new PointLatLngAlt(wp));

            if (IsExecuteOverSetting())
            {
                WPListChange?.Invoke();
            }
        }
        #endregion

        #region 修改航点
        public void SetWPHandle(int index, PointLatLngAlt wp)
        {
            if (IsExecuteOverSetting())
            {
                AddHistory();
            }

            if (index < 0)
                index = 0;

            if (index >= wpList.Count)
                wpList.Add(new PointLatLngAlt(wp));
            else
                wpList[index] = new PointLatLngAlt(wp);

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
        public PointLatLngAlt GetWPPoint(int index)
        {
            if (index < 0)
                index = (index % wpList.Count + wpList.Count) % wpList.Count;
            if (index >= wpList.Count)
                index = index % wpList.Count;
            return new PointLatLngAlt(wpList[index]);
        }
        #endregion

        #region 获取航点数
        public int GetWPCount()
        {
            return wpList.Count;
        }
        #endregion

        #endregion

        #region HOME 初始位置
        private PointLatLngAlt homePosition = new PointLatLngAlt();
        public ChangeHandle HomeChange;

        #region 获取初始位置
        public PointLatLngAlt GetHomePosition()
        {
            if (homePosition == null)
                return null;
            PointLatLngAlt retHome = new PointLatLngAlt(homePosition);
            if (retHome.Tag != WPCommands.HomeCommand)
                retHome.Tag = WPCommands.HomeCommand;
            return retHome;
        }
        #endregion

        #region 设置初始位置
        public void SetHomePosition(PointLatLngAlt position)
        {
            homePosition = new PointLatLngAlt(position);

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
        public void SetCurrentPosition(PointLatLngAlt position)
        {
            CurrentChange?.Invoke(position);
        }
        #endregion

        #region WPList 历史记录
        private List<List<PointLatLngAlt>> history = new List<List<PointLatLngAlt>>();
        public CountChangeHandle historyChange;

        #region 添加记录
        public void AddHistory()
        {
            List<PointLatLngAlt> wpHistory = new List<PointLatLngAlt>(GetWPList());

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
    }
}
