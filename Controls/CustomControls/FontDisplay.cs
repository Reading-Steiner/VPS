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
    public partial class FontDisplay : UserControl
    {
        public FontDisplay()
        {
            InitializeComponent();

            Invaild();
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
        private Font font = SystemFonts.DefaultFont;

        #region Set
        public void SetFont(Font value)
        {
            font = value;

            Invaild();
        }
        #endregion

        #region Get
        public Font GetFont()
        {
            return font;
        }
        #endregion

        #region Delagate
        public delegate void RectChangeHandle(Font value);
        public RectChangeHandle RectChange;
        #endregion

        #endregion

        #region 自定义重绘函数
        private void Invaild()
        {
            SetControlMainThread(labelX1,
                "[ " + font.Name + ", "
                + "大小 = " + font.Size.ToString() + "pt" + ", "
                + "行距 = " + font.Height.ToString() + "pt" + " ]");
            SetControlMainThread(labelX2,
                "[ " + (font.Bold ? "粗体, " : "")
                + (font.Italic ? "斜体, " : "")
                + (font.Strikeout ? "删除, " : "")
                + (font.Underline ? "下划线" : "") + " ]");
        }
        #endregion

        #region 修改响应函数
        private void Display_DoubleClick(object sender, EventArgs e)
        {
            if (!isEndable)
                return;
            //传值
            using (FontDialog fontDlg = new FontDialog())
            {
                fontDlg.Font = font;
                if (fontDlg.ShowDialog() == DialogResult.OK)
                {
                    // 赋值
                    font = fontDlg.Font;
                    Invaild();
                    RectChange?.Invoke(font);
                }
            }

        }

        private void Display_TextChanged(object sender, EventArgs e)
        {
            //Graphics g = this.CreateGraphics();
            //string top = labelX1.Text; var topSize = g.MeasureString(top, labelX1.Font);
            //string mid = labelX2.Text; var midSize = g.MeasureString(mid, labelX2.Font);
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
