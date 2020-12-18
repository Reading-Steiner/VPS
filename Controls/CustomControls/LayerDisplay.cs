using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VPS.CustomData.Layer;

namespace VPS.Controls.CustomControls
{
    public partial class LayerDisplay : UserControl
    {
        public LayerDisplay()
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

        #region 自定义数据访问器
        LayerInfo info = new LayerInfo();

        #region Set
        public void SetLayer(LayerInfo layer)
        {
            if (layer is TiffLayerInfo)
            {
                info = new TiffLayerInfo(layer as TiffLayerInfo);
            }
            else
            {
                info = new LayerInfo(layer);
            }
            Invaild();
        }
        #endregion

        #region Copy
        public void CopyLayer(LayerInfo layer)
        {
            info = layer;
            Invaild();
        }
        #endregion

        #region Get
        public LayerInfo GetLayer()
        {
            return info;
        }
        #endregion

        #region Delegate
        public delegate void LayerChangeHandle(LayerInfo info);
        public LayerChangeHandle LayerChange;
        #endregion

        #endregion

        #region 自定义重绘函数
        public void Invaild()
        {
            SetControlMainThread(this.labelX1, "图层：" + info.Layer);
        }
        #endregion

        #region 修改响应函数
        private void Display_Click(object sender, EventArgs e)
        {
            if (!isEndable)
                return;
            if (info is TiffLayerInfo)
            {
                //传值
                using (CustomForms.CustomTiffLayer cusDlg = new CustomForms.CustomTiffLayer())
                {

                    if (info is TiffLayerInfo)
                    {
                        var tiff = info as TiffLayerInfo;
                        var bitInfo = GDAL.GDAL.LoadImageInfo(info.Layer);
                        cusDlg.SetBitMap(bitInfo.PreviewBitmap, tiff.Transparent);

                    }
                    if (cusDlg.ShowDialog() == DialogResult.OK)
                    {
                        if (info is TiffLayerInfo)
                        {
                            //赋值
                            (info as TiffLayerInfo).Transparent = cusDlg.GetTransparent();
                            Invaild();
                            LayerChange?.Invoke(info);
                        }
                    }
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
