using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPS.Controls.CustomForms
{
    public partial class CustomRect : Office2007Form
    {
        public CustomRect()
        {
            InitializeComponent();
            defaultRect = new CustomData.WP.Rect();
        }

        public CustomRect(VPS.CustomData.WP.Rect rect)
        {
            InitializeComponent();

            SetWGS84Rect(rect);
            defaultRect = rect;
        }

        VPS.CustomData.WP.Rect defaultRect = new VPS.CustomData.WP.Rect();
        VPS.CustomData.WP.Rect rect = new VPS.CustomData.WP.Rect();

        public void SetWGS84Rect(VPS.CustomData.WP.Rect value)
        {
            rect = new VPS.CustomData.WP.Rect(value);
            TopLatInput.Value = rect.Top;
            BottomLatInput.Value = rect.Bottom;
            LeftLngInput.Value = rect.Left;
            RightLngInput.Value = rect.Right;
        }

        public VPS.CustomData.WP.Rect GetWGS84Rect()
        {
            return new VPS.CustomData.WP.Rect(rect);
        }

        private void Default_Click(object sender, EventArgs e)
        {
            SetWGS84Rect(defaultRect);
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
