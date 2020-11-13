using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPS.Controls.MyControls
{
    public partial class MyPositionDisplay : UserControl
    {
        public MyPositionDisplay()
        {
            InitializeComponent();
        }

        #region 标题
        private string posName = "位置";
        [Category("Value"),Description("标题")]
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
        [Category("Value"), Description("位置信息")]
        public Utilities.PointLatLngAlt WGS84Position
        {
            set
            {
                Position = new Utilities.PointLatLngAlt(value);
                labelX1.Text = "[ " + Position.Lng.ToString("0.######") + " , " + Position.Lat.ToString("0.######") + " ]";
                labelX2.Text = "[ " + Position.Tag2 + " , " + Position.Alt.ToString() + " ]";
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
                using (Grid.CustomPosition dlg = new Grid.CustomPosition(Position))
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
    }
}
