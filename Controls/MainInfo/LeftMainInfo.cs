using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VPS.Utilities;

namespace VPS.Controls.MainInfo
{
    public partial class LeftMainInfo : UserControl
    {
        public static LeftMainInfo instance = null;

        public LeftMainInfo()
        {
            InitializeComponent();

            instance = this;
        }

        #region HOME 初始位置
        private delegate void SetPositionInThread(PointLatLngAlt position);
        private PointLatLngAlt homePosition = null;

        private void SetHomePosition(PointLatLngAlt position)
        {
            homePosition = position;
            HomePosition.WGS84Position = homePosition;
            CalcPointRelative();
        }
        #endregion

        #region CURRENT 当前位置
        private PointLatLngAlt current = null;

        public void SetCurrentPosition(Utilities.PointLatLngAlt position)
        {
            current = new PointLatLngAlt(position);
            current.Tag2 = "Terrain";
            current.Alt = (srtm.getAltitude(current.Lat, current.Lng).alt * CurrentState.multiplieralt);

            CurrentPosition.WGS84Position = current;
            CalcPointRelative();
        }
        #endregion

        #region LAST 最后位置
        private PointLatLngAlt last = null;
        #endregion

        #region HOME 初始位置变化响应函数
        public void HomeChangeHandle()
        {
            PointLatLngAlt home = VPS.WP.WPGlobalData.instance.GetHomePosition();
            SetHomePosition(home);
        }
        #endregion

        #region WPLIST 航线变化响应函数
        public void WPChangeHandle()
        {
            List<PointLatLngAlt> wpLists = VPS.WP.WPGlobalData.instance.GetWPList();
            //去除Home点
            if (wpLists.Count > 0 && wpLists[0].Tag == VPS.WP.WPCommands.HomeCommand)
            {
                SetHomePosition(wpLists[0]);
                wpLists.RemoveAt(0);
            }

            CalcBaseAlt(wpLists);

            for(int index = 0; index < wpLists.Count; index++)
            {
                var point = new PointLatLngAlt(wpLists[index]);
                double terrainA = srtm.getAltitude(point.Lat, point.Lng).alt * CurrentState.multiplieralt;
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
                        point.Tag2 = "Relative";
                        break;
                }
                wpLists[index] = point;
            }

            if (wpLists.Count > 0)
                last = wpLists[wpLists.Count - 1];
            else
                last = null;

            CalcTotalDist(wpLists);

            CalcPointRelative();
        }
        #endregion

        #region 计算
        double baseAlt = 0;
        double maxAlt = 0;
        double minAlt = 0;

        private void CalcBaseAlt(List<PointLatLngAlt> wpList)
        {
            double totalAlt = 0.0;
            double maxA = 0.0;
            double minA = wpList.Count > 0 ? 
                srtm.getAltitude(wpList[0].Lat, wpList[0].Lng).alt * CurrentState.multiplieralt : 0.0;
            for (int index = 0; index < wpList.Count; index++)
            {
                double terrain = srtm.getAltitude(wpList[index].Lat, wpList[index].Lng).alt * CurrentState.multiplieralt;
                totalAlt += terrain;
                if (terrain > maxA)
                    maxA = terrain;
                if (terrain < minA)
                    minA = terrain;
            }
            baseAlt = (int)(totalAlt / Math.Max(1, wpList.Count));
            SetControlMainThread(WPBaseAlt, baseAlt.ToString("0.## m"));
            maxAlt = maxA; minAlt = minA;
            SetControlMainThread(WPGndeLev, minA.ToString("0.##") + "-" + maxA.ToString("0.##") + " m");
        }

        private void CalcTotalDist(List<PointLatLngAlt> list)
        {
            double totalDist = 0.0;
            for (int index = 1; index < list.Count; index++)
            {
                totalDist += Math.Sqrt(
                    Math.Pow(list[index].GetDistance(list[index - 1]), 2) +
                    Math.Pow(list[index].Alt - list[index - 1].Alt, 2)) *
                    CurrentState.multiplierdist;
            }
            SetControlMainThread(WPTotalDist, totalDist.ToString("0.## m"));
        }

        private void CalcPointRelative()
        {
            double baseAltCopy = baseAlt;
            if (baseAltCopy == 0)
                baseAltCopy = (int)(srtm.getAltitude(homePosition.Lat, homePosition.Lng).alt * CurrentState.multiplieralt);
            if (current != null)
            {
                
                if (homePosition != null)
                {
                    double height = (homePosition.Alt + baseAltCopy) - current.Alt;
                    double distance = current.GetDistance(homePosition);
                    double grad = height / distance;

                    SetControlMainThread(HomeGrad, (grad).ToString("0.## %"));
                    SetControlMainThread(HomeDist, (distance * CurrentState.multiplierdist).ToString("0.## m"));
                    SetControlMainThread(HomeAZ, ((current.GetBearing(homePosition) + 180) % 360).ToString("0.##"));
                }
                else
                {
                    SetControlMainThread(HomeGrad, "0");
                    SetControlMainThread(HomeDist, "0");
                    SetControlMainThread(HomeAZ, "0");
                }

                if (last != null)
                {
                    double height = (last.Alt + baseAltCopy) - current.Alt;
                    double distance = current.GetDistance(last);
                    double grad = height / distance;

                    SetControlMainThread(LastGrad, (grad).ToString("0.## %"));
                    SetControlMainThread(LastDist, (distance * CurrentState.multiplierdist).ToString("0.## m"));
                    SetControlMainThread(LastAZ, ((current.GetBearing(last) + 180) % 360).ToString("0.##"));
                }
                else
                {
                    SetControlMainThread(LastGrad, "0");
                    SetControlMainThread(LastDist, "0");
                    SetControlMainThread(LastAZ, "0");
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

            SetControlMainThread(HeightOverlap, heightOverlap.ToString("0.00 %"));
            SetControlMainThread(HeightSidelap, heightSidelap.ToString("0.00 %"));
            SetControlMainThread(LowOverlap, lowOverlap.ToString("0.00 %"));
            SetControlMainThread(LowSidelap, lowSidelap.ToString("0.00 %"));
        }

        #endregion

        #region 设置控件数据
        private delegate void SetControlInMainThreadHandle(Control control, object data);

        private static void SetControlMainThread(Control control, object data)
        {
            if (control.InvokeRequired)
            {
                SetControlInMainThreadHandle inThread = new SetControlInMainThreadHandle(SetControlMainThread);
                control.Invoke(inThread, new object[] { control, data });
            }
            else
            {
                if (control is DevComponents.Editors.DoubleInput)
                    ((DevComponents.Editors.DoubleInput)control).Value = (double)data;
                if (control is DevComponents.Editors.IntegerInput)
                    ((DevComponents.Editors.IntegerInput)control).Value = (int)data;
                if (control is DevComponents.DotNetBar.Controls.CheckBoxX)
                    ((DevComponents.DotNetBar.Controls.CheckBoxX)control).Checked = (bool)data;
                if (control is DevComponents.DotNetBar.Controls.ComboBoxEx)
                    ((DevComponents.DotNetBar.Controls.ComboBoxEx)control).Text = (string)data;
                if (control is DevComponents.DotNetBar.LabelX)
                    ((DevComponents.DotNetBar.LabelX)control).Text = (string)data;
                if (control is DevComponents.DotNetBar.ButtonX)
                    ((DevComponents.DotNetBar.ButtonX)control).Enabled = (bool)data;
                if (control is DevComponents.DotNetBar.PanelEx)
                    ((DevComponents.DotNetBar.PanelEx)control).Visible = (bool)data;

            }
        }
        #endregion
    }
}
