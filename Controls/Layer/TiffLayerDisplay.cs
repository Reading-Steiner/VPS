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

namespace VPS.Controls.Layer
{
    public partial class TiffLayerDisplay : UserControl
    {
        public TiffLayerDisplay()
        {
            InitializeComponent();
        }

        private CustomData.Layer.TiffLayerInfo layer;
        public CustomData.Layer.TiffLayerInfo Layer
        {
            get { return layer; }
            set
            {
                layer = value;
                LayerDisplay.CopyLayer(layer);
            }
        }

        private VPS.CustomData.WP.Position home;
        public VPS.CustomData.WP.Position HomePosition
        {
            get
            {
                return home;
            }
            set
            {
                home = value;
                HomePositionDisplay.SetPosition(home);
            }
        }

        private VPS.CustomData.WP.Rect rect = new VPS.CustomData.WP.Rect();

        public VPS.CustomData.WP.Rect LayerRect
        {
            get
            {
                return new VPS.CustomData.WP.Rect(rect);
            }
            set
            {
                rect = new VPS.CustomData.WP.Rect(value);
                LayerRectDisplay.CopyRect(rect);
            }
        }

        public string CreateTime
        {
            set
            {
                CreateTimeDisplay.Text = "创建时间：" + value;
            }
        }

        public string ModifyTime
        {
            set
            {
                ModifyTimeDisplay.Text = "修改时间：" + value;
            }
        }

        private ProjectionInfo projection = new ProjectionInfo();
        public ProjectionInfo GetProjection()
        {
            return projection;
        }

        public void SetProjection(ProjectionInfo value)
        {
            projection.CopyProperties(value);
            ProjectionDisplay.CopyProjection(projection);
        }

        public void SetLayer(CustomData.Layer.TiffLayerInfo info)
        {
            Layer = new CustomData.Layer.TiffLayerInfo(info);
            HomePosition = info.Home;
            CreateTime = info.CreateTime;
            ModifyTime = info.ModifyTime;
            IdDisplay.Text = info.GetOnlyCode();

            if (info.LayerInvaild())
                StateDisplay.SetState("就绪");
            else
                StateDisplay.SetState("无效");
            var bitmapInfo = GDAL.GDAL.LoadImageInfo(info.Layer);
            if (bitmapInfo != null)
            {
                LayerRect = new VPS.CustomData.WP.Rect(bitmapInfo.Rect);
            }
            using (var ds = OSGeo.GDAL.Gdal.Open(info.Layer, OSGeo.GDAL.Access.GA_ReadOnly))
            {
                var projection = ProjectionInfo.FromEsriString(ds.GetProjection());

                SetProjection(projection);
            }
        }

        public class CustomLayerVaildState: VPS.Controls.CustomControls.CustomState
        {
            public CustomLayerVaildState()
                : base()
            {
                AddState("就绪", Color.Lime);
                AddState("无效", Color.Red);
                SetState("就绪");
            }
        }
    }
}
