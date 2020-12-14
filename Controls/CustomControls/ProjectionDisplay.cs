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

        private void Display_DoubleClick(object sender, EventArgs e)
        {
            CustomForms.CustomContent content = new CustomForms.CustomContent(projection.ToEsriString());
            content.ShowDialog();
        }

        private ProjectionInfo projection = new ProjectionInfo();
        [Browsable(false)]
        public ProjectionInfo Projection
        {
            get { return projection; }
            set
            {
                projection = value;
                labelX1.Text = "投影：" + projection.ToString();
            }
        }
    }
}
