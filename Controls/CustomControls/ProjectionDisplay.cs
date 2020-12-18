using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotSpatial.Projections;

namespace VPS.Controls.CustomControls
{
    public partial class ProjectionDisplay : UserControl
    {
        public ProjectionDisplay()
        {
            InitializeComponent();
        }

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
        private ProjectionInfo projection = new ProjectionInfo();

        #region Set
        public void SetProjection(ProjectionInfo value)
        {
            projection = new ProjectionInfo();
            projection.CopyProperties(value);
            Invaild();
        }
        #endregion

        #region Copy
        public void CopyProjection(ProjectionInfo value)
        {
            projection = value;
            Invaild();
        }
        #endregion

        #region Get
        public ProjectionInfo GetProjection()
        {
            return projection;
        }
        #endregion

        #region Delagate
        public delegate void ProjectionChangeHandle(ProjectionInfo projection);
        public ProjectionChangeHandle ProjectionChange;
        #endregion

        #endregion

        #region 自定义重绘函数
        private void Invaild()
        {
            SetControlMainThread(labelX1,
                "投影：" + projection.ToString());
        }
        #endregion

        #region 修改响应函数
        private void Display_DoubleClick(object sender, EventArgs e)
        {
            if (!isEndable)
                return;
            //传值
            using (CustomForms.CustomProjection cusDlg = new CustomForms.CustomProjection(projection))
            {
                if (cusDlg.ShowDialog() == DialogResult.OK)
                {
                    //赋值
                    projection.CopyProperties(cusDlg.GetProjection());
                    Invaild();
                    ProjectionChange?.Invoke(projection);
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
