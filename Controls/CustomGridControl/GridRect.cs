using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPS.Controls.CustomGridControl
{
    public partial class GridRect : Form
    {
        public GridRect()
        {
            InitializeComponent();
        }

        public GridRect(VPS.Controls.LoadAndSave.Rect rect)
        {
            InitializeComponent();

            LocationRect = rect;
            defaultRect = LocationRect;
        }

        private VPS.Controls.LoadAndSave.Rect defaultRect = new LoadAndSave.Rect();
        private VPS.Controls.LoadAndSave.Rect rect = new LoadAndSave.Rect();

        public VPS.Controls.LoadAndSave.Rect LocationRect
        {
            set
            {
                rect = value;
                TopLatInput.Value = rect.Top;
                BottomLatInput.Value = rect.Bottom;
                LeftLngInput.Value = rect.Left;
                RightLngInput.Value = rect.Right;
            }
            get
            {
                return rect;
            }
        }

        private void Default_Click(object sender, EventArgs e)
        {
            LocationRect = defaultRect;
        }

        private void RightLngInput_ValueChanged(object sender, EventArgs e)
        {
            rect.Right = RightLngInput.Value;
        }

        private void BottomLatInput_ValueChanged(object sender, EventArgs e)
        {
            rect.Bottom = BottomLatInput.Value;
        }

        private void TopLatInput_ValueChanged(object sender, EventArgs e)
        {
            rect.Top = TopLatInput.Value;
        }

        private void LeftLngInput_ValueChanged(object sender, EventArgs e)
        {
            rect.Left = LeftLngInput.Value;
        }
    }
}
