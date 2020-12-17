using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VPS.CustomData.Layer;

namespace VPS.Controls.CustomControls
{
    public partial class LayerDisplay : UserControl
    {
        public LayerDisplay()
        {
            InitializeComponent();
        }

        public void SetLayer(LayerInfo layer)
        {
            info = layer;
            this.labelX1.Text = "图层：" + info.Layer;
        }

        private void Display_Click(object sender, EventArgs e)
        {
            using (CustomForms.CustomLayer layer = new CustomForms.CustomLayer()) {

                if (info is TiffLayerInfo)
                {
                    var tiff = info as TiffLayerInfo;
                    var bitInfo = GDAL.GDAL.LoadImageInfo(info.Layer);
                    layer.SetBitMap(bitInfo.PreviewBitmap, tiff.Transparent);

                }
                layer.ShowDialog();
            }
        }

        [Browsable(false)]
        LayerInfo info = new LayerInfo();
    }
}
