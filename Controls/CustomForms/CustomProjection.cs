using DevComponents.DotNetBar;
using DotSpatial.Projections;
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
    public partial class CustomProjection : Office2007Form
    {
        public CustomProjection()
        {
            InitializeComponent();
        }

        public void SetProjection(ProjectionInfo value)
        {
            projectionSelectControl.SelectedCoordinateSystem = value;
        }

        public ProjectionInfo GetProjection()
        {
            return projectionSelectControl.SelectedCoordinateSystem;
        }
    }
}
