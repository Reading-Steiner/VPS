using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPS.Controls.Layer
{
    public partial class TiffLayerDisplay : UserControl
    {
        private Utilities.PointLatLngAlt home;
        public Utilities.PointLatLngAlt HomePosition
        {
            get
            {
                return home;
            }
            set
            {
                home = value;
                HomePositionDisplay.WGS84Position = value;
            }
        }


        public TiffLayerDisplay()
        {
            InitializeComponent();
        }
    }
}
