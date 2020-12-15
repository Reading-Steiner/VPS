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
        }

        public CustomRect(GMap.NET.RectLatLng rect)
        {
            InitializeComponent();

            LocationRect = rect;
            defaultRect = LocationRect;
        }

        private GMap.NET.RectLatLng defaultRect = new GMap.NET.RectLatLng();
        private GMap.NET.RectLatLng rect = new GMap.NET.RectLatLng();

        public GMap.NET.RectLatLng LocationRect
        {
            set
            {
                rect = new GMap.NET.RectLatLng(value.Lat, value.Lng, value.WidthLng, value.HeightLat);
                TopLatInput.Value = rect.Top;
                BottomLatInput.Value = rect.Bottom;
                LeftLngInput.Value = rect.Left;
                RightLngInput.Value = rect.Right;
            }
            get
            {
                return new GMap.NET.RectLatLng(rect.Lat, rect.Lng, rect.WidthLng, rect.HeightLat);
            }
        }

        private void Default_Click(object sender, EventArgs e)
        {
            LocationRect = defaultRect;
        }

        private void RightLngInput_ValueChanged(object sender, EventArgs e)
        {
            rect.WidthLng = RightLngInput.Value - LeftLngInput.Value;
        }

        private void BottomLatInput_ValueChanged(object sender, EventArgs e)
        {
            rect.HeightLat = BottomLatInput.Value - TopLatInput.Value;
        }

        private void TopLatInput_ValueChanged(object sender, EventArgs e)
        {
            rect.Lat = TopLatInput.Value;
        }

        private void LeftLngInput_ValueChanged(object sender, EventArgs e)
        {
            rect.Lng = LeftLngInput.Value;
        }
    }
}
