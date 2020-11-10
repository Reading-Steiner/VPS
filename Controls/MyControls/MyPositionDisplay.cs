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

        private Utilities.PointLatLngAlt Position = new Utilities.PointLatLngAlt();
        public Utilities.PointLatLngAlt WGS84Position
        {
            set
            {
                Position = value;
                labelX1.Text = "[ " + Position.Lng.ToString("0.######") + " , " + Position.Lat.ToString("0.######") + " ]";
                labelX2.Text = "[ " + Position.Tag2 + " , " + Position.Alt.ToString() + " ]";
            }
            get
            {
                return Position;
            }
        }

        private bool isEndable = true;

        public void AllowClick()
        {
            isEndable = true;
        }

        public void ForbidClick()
        {
            isEndable = false;
        }


        private void Display_DoubleClick(object sender, EventArgs e)
        {
            if (isEndable)
            {
                using (Grid.CustomPosition dlg = new Grid.CustomPosition(Position))
                {
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        WGS84Position = dlg.WGS84Position;
                    }
                }
            }                                          
        }
    }
}
