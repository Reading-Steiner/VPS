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
        private VPS.CustomData.WP.Position Position = new VPS.CustomData.WP.Position();

        #region Set
        public void SetPosition(VPS.CustomData.WP.Position value)
        {
            Position = new VPS.CustomData.WP.Position(value);
            Invaild();
        }
        #endregion

        #region Copy
        public void CopyPosition(VPS.CustomData.WP.Position value)
        {
            Position = value;
            Invaild();
        }
        #endregion

        #region Get
        public VPS.CustomData.WP.Position GetPosition()
        {
            return Position;
        }
        #endregion

        #region Delegate
        public delegate void PositionChangeHandle(VPS.CustomData.WP.Position position);
        public PositionChangeHandle PositionChange;
        #endregion

        #endregion

        #region 自定义重绘函数
        public void Invaild()
        {
            SetControlMainThread(
                labelX1,
                "[ " + Position.Lng.ToString("0.######") + (Position.Lng > 0 ? "E" : "W") + " , " +
                Position.Lat.ToString("0.######") + (Position.Lat >= 0 ? "N" : "S") + " ]");
            SetControlMainThread(
                labelX2,
                "[ " + Position.AltMode + " , " + Position.Alt.ToString() + " ]");
        }
        #endregion

        #region 修改响应函数
        private void Display_DoubleClick(object sender, EventArgs e)
        {
            if (!isEndable)
                return;
            //传值
            using (CustomForms.CustomPosition cusDlg = new CustomForms.CustomPosition(Position))
            {
                if (cusDlg.ShowDialog() == DialogResult.OK)
                {
                    //赋值
                    Position.FromPosition(cusDlg.GetWGS84Position());
                    Invaild();
                    PositionChange?.Invoke(GetPosition());
                }
            }

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
