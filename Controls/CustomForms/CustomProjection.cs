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

        public CustomProjection(ProjectionInfo projection)
        {
            InitializeComponent();
            SetProjection(projection);
        }

        public void SetProjection(ProjectionInfo value)
        {
            if (projectionSelectControl.SelectedCoordinateSystem == null)
                projectionSelectControl.SelectedCoordinateSystem = new ProjectionInfo();
            projectionSelectControl.SelectedCoordinateSystem.CopyProperties(value);
        }

        public ProjectionInfo GetProjection()
        {
            return projectionSelectControl.SelectedCoordinateSystem;
        }
    }
}
