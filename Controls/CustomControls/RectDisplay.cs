using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPS.Controls.CustomControls
{
    public partial class  RectDisplay : UserControl
    {
        public RectDisplay()
        {
            InitializeComponent();
        }

        #region 标题
        private string posName = "区域";
        [Category("Value"), Description("标题")]
        public string PositionName
        {
            set
            {
                posName = value;
                DisplayName.Text = posName;
            }
            get
            {
                return posName;
            }
        }
        #endregion

        #region 坐标
        private GMap.NET.RectLatLng Rect = new GMap.NET.RectLatLng();
        [Category("Value"), Description("区域信息")]
        public GMap.NET.RectLatLng WGS84Rect
        {
            set
            {
                Rect = new GMap.NET.RectLatLng(value.Lat, value.Lng, value.WidthLng, value.HeightLat);
                SetControlMainThread(
                    labelX1,
                    "[ " + Rect.Top.ToString("0.######") + (Rect.Top >= 0 ? "N" : "S") + " ]");
                SetControlMainThread(
                    labelX2,
                    "[ " + Rect.Left.ToString("0.######") + (Rect.Left > 0 ? "E" : "W") + " , " +
                    Rect.Left.ToString("0.######") + (Rect.Left >= 0 ? "E" : "W") + " ]");
                SetControlMainThread(
                    labelX3,
                    "[ " + Rect.Bottom.ToString("0.######") + (Rect.Bottom > 0 ? "N" : "S") + " ]");
            }
            get
            {
                return new GMap.NET.RectLatLng(Rect.Lat, Rect.Lng, Rect.WidthLng, Rect.HeightLat);
            }
        }
        #endregion

        #region 是否可修改
        private bool isEndable = true;
        [Category("Value"), Description("可修改的")]
        public bool IsReadOnly
        {
            set
            {
                isEndable = value;
            }
            get
            {
                return isEndable;
            }
        }

        #region 接口函数
        public void AllowClick()
        {
            isEndable = true;
        }

        public void ForbidClick()
        {
            isEndable = false;
        }
        #endregion
        #endregion

        #region 修改响应函数
        private void Display_DoubleClick(object sender, EventArgs e)
        {
            if (isEndable)
            {
                using (CustomForms.CustomRect dlg = new CustomForms.CustomRect(Rect))
                {
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        Rect = dlg.LocationRect;
                        RectChange?.Invoke(Rect);
                    }
                }
            }
        }
        #endregion

        #region
        public delegate void RectChangeHandle(GMap.NET.RectLatLng rect);
        public RectChangeHandle RectChange;
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
