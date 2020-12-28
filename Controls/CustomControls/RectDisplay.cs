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
    public partial class RectDisplay : UserControl
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

        #region 自定义访问器
        private VPS.CustomData.WP.VPSRect rect = new VPS.CustomData.WP.VPSRect();

        #region Set
        public void SetRect(VPS.CustomData.WP.VPSRect value)
        {
            rect.FromRect(value);

            Invaild();
        }
        #endregion

        #region Copy
        public void CopyRect(VPS.CustomData.WP.VPSRect value)
        {
            rect = value;

            Invaild();
        }
        #endregion

        #region Get
        public VPS.CustomData.WP.VPSRect GetRect()
        {
            return new VPS.CustomData.WP.VPSRect(rect);
        }
        #endregion

        #region Delagate
        public delegate void RectChangeHandle(VPS.CustomData.WP.VPSRect rect);
        public RectChangeHandle RectChange;
        #endregion

        #endregion

        #region 自定义重绘函数
        private void Invaild()
        {
            SetControlMainThread(labelX1,
                "[ " + rect.Top.ToString("0.######") + (rect.Top >= 0 ? "N" : "S") + " ]");
            SetControlMainThread(labelX2,
                "[ " + rect.Left.ToString("0.######") + (rect.Left > 0 ? "E" : "W") + " , " +
                rect.Left.ToString("0.######") + (rect.Left >= 0 ? "E" : "W") + " ]");
            SetControlMainThread(labelX3,
                "[ " + rect.Bottom.ToString("0.######") + (rect.Bottom > 0 ? "N" : "S") + " ]");
        }
        #endregion

        #region 修改响应函数
        private void Display_DoubleClick(object sender, EventArgs e)
        {
            if (!isEndable)
                return;
            //传值
            using (CustomForms.CustomRect cusDlg = new CustomForms.CustomRect(rect))
            {
                if (cusDlg.ShowDialog() == DialogResult.OK)
                {
                    // 赋值
                    rect.FromRect(cusDlg.GetWGS84Rect());
                    Invaild();
                    RectChange?.Invoke(rect);
                }
            }

        }

        private void Display_TextChanged(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            string top = labelX1.Text; var topSize = g.MeasureString(top, labelX1.Font);
            string mid = labelX2.Text; var midSize = g.MeasureString(mid, labelX2.Font);
            string bot = labelX3.Text; var botSize = g.MeasureString(bot, labelX3.Font);

            labelX1.PaddingLeft = (int)(midSize.Width > topSize.Width ?
                (midSize.Width - topSize.Width) / 2 : 0);

            labelX3.PaddingLeft = (int)(midSize.Width > botSize.Width ?
                (midSize.Width - botSize.Width) / 2 : 0);

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
