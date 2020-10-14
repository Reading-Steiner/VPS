using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace VPS.Controls.Grid
{
    public partial class CustomCamera : Office2007Form
    {
        public CustomCamera()
        {
            InitializeComponent();
        }

        public VPS.Grid.camerainfo GetCamerainfo()
        {
            var camera = new VPS.Grid.camerainfo();

            camera.name = Camera.Text;
            camera.focallen = (float)FocalLength.Value;
            camera.imageheight = ImgHeight.Value;
            camera.imagewidth = ImgWidth.Value;
            camera.sensorheight = (float)SensHeight.Value;
            camera.sensorwidth = (float)SensWidth.Value;

            return camera;
        }
    }
}
