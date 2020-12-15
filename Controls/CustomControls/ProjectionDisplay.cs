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
            using (CustomForms.CustomProjection content = new CustomForms.CustomProjection(projection))
            {
                if(content.ShowDialog() == DialogResult.OK)
                {
                    SetProjection(content.GetProjection());
                }
            }
        }

        private ProjectionInfo projection = new ProjectionInfo();

        public void SetProjection(ProjectionInfo value)
        {
            projection.CopyProperties(value);
            labelX1.Text = "投影：" + projection.ToString();
        }

        public void CopyProjection(ProjectionInfo value)
        {
            projection = value;
            labelX1.Text = "投影：" + projection.ToString();
        }

        public ProjectionInfo GetProjection()
        {
            return projection;
        }
    }
}
