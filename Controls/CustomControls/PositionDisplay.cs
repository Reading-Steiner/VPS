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
    public partial class PositionDisplay : UserControl
    {
        public PositionDisplay()
        {
            InitializeComponent();
        }

        #region 标题
        private string posName = "位置";
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
        private Utilities.PointLatLngAlt Position = new Utilities.PointLatLngAlt();
        [Browsable(false)]
        public Utilities.PointLatLngAlt WGS84Position
        {
            set
            {
                Position = new Utilities.PointLatLngAlt(value);
                SetControlMainThread(
                    labelX1,
                    "[ " + Position.Lng.ToString("0.######") + (Position.Lng > 0 ? "E" : "W") + " , " +
                    Position.Lat.ToString("0.######") + (Position.Lat >= 0 ? "N" : "S") + " ]");
                SetControlMainThread(
                    labelX2,
                    "[ " + Position.Tag2 + " , " + Position.Alt.ToString() + " ]");

            }
            get
            {
                return new Utilities.PointLatLngAlt(Position);
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
                using (CustomForms.CustomPosition dlg = new CustomForms.CustomPosition(Position))
                {
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        WGS84Position = dlg.WGS84Position;
                        PositionChange?.Invoke(WGS84Position);
                    }
                }
            }                                          
        }
        #endregion

        #region
        public delegate void PositionChangeHandle(Utilities.PointLatLngAlt position);
        public PositionChangeHandle PositionChange;
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
