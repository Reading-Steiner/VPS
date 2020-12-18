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

            defaultLayer = new CustomData.Layer.TiffLayerInfo();
            //SetLayer(defaultLayer);
        }

        public TiffLayerDisplay(CustomData.Layer.TiffLayerInfo value)
        {
            InitializeComponent();
            defaultLayer = value;
            SetLayer(defaultLayer);
        }

        #region 图层信息
        private CustomData.Layer.TiffLayerInfo layer;
        private CustomData.Layer.TiffLayerInfo defaultLayer;

        public CustomData.Layer.TiffLayerInfo GetLayerInfo()
        {
            return layer;
        }

        public void SetLayerInfo(CustomData.Layer.TiffLayerInfo value)
        {
            if (layer is CustomData.Layer.TiffLayerInfo)
                layer = new CustomData.Layer.TiffLayerInfo(value);
            else
                layer = value;
            LayerDisplay.CopyLayer(layer);
        }
        #endregion

        #region 初始位置
        private VPS.CustomData.WP.Position home;

        public VPS.CustomData.WP.Position GetHomePosition()
        {
            return home;
        }

        public void SetHomePosition(VPS.CustomData.WP.Position value)
        {
            home = new CustomData.WP.Position(value);
            HomePositionDisplay.CopyPosition(home);
        }
        #endregion

        #region 图层范围
        private VPS.CustomData.WP.Rect rect = new VPS.CustomData.WP.Rect();

        public VPS.CustomData.WP.Rect GetLayerRect()
        {
            return rect;
        }

        public void SetLayerRect(VPS.CustomData.WP.Rect value)
        {
            rect = new VPS.CustomData.WP.Rect(value);
            LayerRectDisplay.CopyRect(rect);
        }
        #endregion

        #region 投影信息
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
        #endregion

        #region 时间信息
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
        #endregion

        public void SetLayer(CustomData.Layer.TiffLayerInfo info)
        {
            SetLayerInfo(info);
            SetHomePosition(info.Home);
            CreateTime = info.CreateTime;
            ModifyTime = info.ModifyTime;
            IdDisplay.Text = info.GetOnlyCode();

            if (info.LayerInvaild())
                StateDisplay.SetState("就绪");
            else
                StateDisplay.SetState("无效");

            if (!info.LayerInvaild())
                return;
            var bitmapInfo = GDAL.GDAL.LoadImageInfo(info.Layer);
            if (bitmapInfo != null)
            {
                SetLayerRect(new VPS.CustomData.WP.Rect(bitmapInfo.Rect));
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

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var value = new CustomData.Layer.TiffLayerInfo(
                layer.Layer, 
                home, layer.Transparent, layer.Scale, 
                layer.CreateTime, DateTime.Now.ToString("yyyy年 MM月 dd日 HH:mm:ss"));
            VPS.CustomData.Layer.MemoryLayerCache.AddLayerToMemoryCache(value);
            if (checkBoxX1.Checked)
                VPS.CustomData.WP.WPGlobalData.instance.SetDefaultLayer(layer.Layer, rect, home);

        }

        private void DefaultButton_Click(object sender, EventArgs e)
        {
            SetLayer(defaultLayer);
        }
    }
}
