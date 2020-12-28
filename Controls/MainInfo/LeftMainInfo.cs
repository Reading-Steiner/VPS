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
            this.Load += LeftMainInfo_Load;
        }

        private void LeftMainInfo_Load(object sender, EventArgs e)
        {
            if (CustomData.WP.WPGlobalData.instance != null)
            {
                HomeChangeHandle();
                WorkspaceRectChangeHandle();
            }
        }

        #region HOME 初始位置
        private delegate void SetPositionInThread(VPS.CustomData.WP.VPSPosition position);
        private VPS.CustomData.WP.VPSPosition homePosition = null;

        private void SetHomePosition(VPS.CustomData.WP.VPSPosition position)
        {
            homePosition = position;
            HomePosition.CopyPosition(homePosition);

            double grad = CustomData.WP.WPGlobalData.GetPointGrad(
                homePosition, currentPosition, baseAlt);
            double dist = CustomData.WP.WPGlobalData.GetPointDist(
                homePosition, currentPosition, baseAlt);
            double az = CustomData.WP.WPGlobalData.GetPointAZ(
                homePosition, currentPosition, baseAlt);

            SetControlMainThread(HomeGrad, (grad).ToString("0.## \\%"));
            SetControlMainThread(HomeDist, (dist).ToString("0.## m"));
            SetControlMainThread(HomeAZ, (az).ToString("0.##"));
        }
        #endregion

        #region CURRENT 当前位置
        private VPS.CustomData.WP.VPSPosition currentPosition = null;

        public void SetCurrentPosition(VPS.CustomData.WP.VPSPosition position)
        {
            currentPosition = new VPS.CustomData.WP.VPSPosition(position);
            if (!CustomData.EnumCollect.AltFrame.Modes.Contains(position.AltMode))
            {
                currentPosition.AltMode = CustomData.EnumCollect.AltFrame.Absolute;
                currentPosition.Alt = (srtm.getAltitude(currentPosition.Lat, currentPosition.Lng).alt * CurrentState.multiplieralt);
            }

            CurrentPosition.SetPosition(currentPosition);

            double grad = CustomData.WP.WPGlobalData.GetPointGrad(
                homePosition, currentPosition, baseAlt);
            double distance = CustomData.WP.WPGlobalData.GetPointDist(
                homePosition, currentPosition, baseAlt);
            double az = CustomData.WP.WPGlobalData.GetPointAZ(
                homePosition, currentPosition, baseAlt);
            SetControlMainThread(HomeGrad, (grad).ToString("0.## \\%"));
            SetControlMainThread(HomeDist, (distance).ToString("0.## m"));
            SetControlMainThread(HomeAZ, (az).ToString("0.##"));

            grad = CustomData.WP.WPGlobalData.GetPointGrad(
                lastPosition, currentPosition, baseAlt);
            distance = CustomData.WP.WPGlobalData.GetPointDist(
                lastPosition, currentPosition, baseAlt);
            az = CustomData.WP.WPGlobalData.GetPointAZ(
                lastPosition, currentPosition, baseAlt);
            SetControlMainThread(LastGrad, (grad).ToString("0.## \\%"));
            SetControlMainThread(LastDist, (distance).ToString("0.## m"));
            SetControlMainThread(LastAZ, (az).ToString("0.##"));
        }
        #endregion

        #region LAST 最后位置
        private VPS.CustomData.WP.VPSPosition lastPosition = null;
        #endregion

        #region RECT 图层区域
        private delegate void SetRectInThread(VPS.CustomData.WP.VPSRect rect);
        private VPS.CustomData.WP.VPSRect workspace = new VPS.CustomData.WP.VPSRect();

        private void SetWorkspace(VPS.CustomData.WP.VPSRect rect)
        {
            workspace = rect;
            LayerRect.SetRect(workspace);

            var rectList = new List<CustomData.WP.VPSPosition>() {
                new CustomData.WP.VPSPosition(rect.Left, rect.Top),
                new CustomData.WP.VPSPosition(rect.Right, rect.Top),
                new CustomData.WP.VPSPosition(rect.Right, rect.Bottom),
                new CustomData.WP.VPSPosition(rect.Left, rect.Bottom)
            };
            SetControlMainThread(LayerArea, 
                (VPS.CustomData.WP.WPGlobalData.instance.GetPolygonArea(rectList)).ToString("0.##"));
        }
        #endregion

        #region HOME 初始位置变化响应函数
        public void HomeChangeHandle()
        {
            VPS.CustomData.WP.VPSPosition home = CustomData.WP.WPGlobalData.instance.GetHomePosition();
            SetHomePosition(home);
        }
        #endregion

        #region WPLIST 航线变化响应函数
        public void WPChangeHandle()
        {
            List<VPS.CustomData.WP.VPSPosition> wpLists = CustomData.WP.WPGlobalData.instance.GetWPList();
            //去除Home点
            if (wpLists.Count > 0 && wpLists[0].Command == CustomData.WP.WPCommands.HomeCommand)
            {
                SetHomePosition(wpLists[0]);
                wpLists.RemoveAt(0);
            }

            baseAlt = CustomData.WP.WPGlobalData.GetBaseAlt(wpLists);
            SetControlMainThread(WPBaseAlt, (baseAlt).ToString("0.## m"));
            maxAlt = CustomData.WP.WPGlobalData.GetMaxGroundAlt(wpLists);
            minAlt = CustomData.WP.WPGlobalData.GetMinGroundAlt(wpLists);
            SetControlMainThread(WPGndeLev, minAlt.ToString("0.##") + " - " + maxAlt.ToString("0.## m"));

            wpLists = CustomData.WP.WPGlobalData.WPListChangeAltFrame(
                wpLists, CustomData.EnumCollect.AltFrame.Relative);

            if (wpLists.Count > 0)
                lastPosition = wpLists[wpLists.Count - 1];
            else
                lastPosition = null;

            double totalDist = CustomData.WP.WPGlobalData.GetTotalDist(wpLists);
            SetControlMainThread(WPTotalDist, totalDist.ToString("0.## m"));

            double grad = CustomData.WP.WPGlobalData.GetPointGrad(
                homePosition, currentPosition, baseAlt);
            double distance = CustomData.WP.WPGlobalData.GetPointDist(
                homePosition, currentPosition, baseAlt);
            double az = CustomData.WP.WPGlobalData.GetPointAZ(
                homePosition, currentPosition, baseAlt);
            SetControlMainThread(HomeGrad, (grad).ToString("0.## \\%"));
            SetControlMainThread(HomeDist, (distance).ToString("0.## m"));
            SetControlMainThread(HomeAZ, (az).ToString("0.##"));


            grad = CustomData.WP.WPGlobalData.GetPointGrad(
                lastPosition, currentPosition, baseAlt);
            distance = CustomData.WP.WPGlobalData.GetPointDist(
                lastPosition, currentPosition, baseAlt);
            az = CustomData.WP.WPGlobalData.GetPointAZ(
                lastPosition, currentPosition, baseAlt);
            SetControlMainThread(LastGrad, (grad).ToString("0.## \\%"));
            SetControlMainThread(LastDist, (distance).ToString("0.## m"));
            SetControlMainThread(LastAZ, (az).ToString("0.##"));
        }
        #endregion

        #region WPLIST 航线变化响应函数
        public void WorkspaceRectChangeHandle()
        {
            VPS.CustomData.WP.VPSRect workspace = CustomData.WP.WPGlobalData.instance.GetLayerRect();

            SetWorkspace(workspace);

        }
        #endregion

        #region 中间参数
        double baseAlt = 0;
        double maxAlt = 0;
        double minAlt = 0;
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
