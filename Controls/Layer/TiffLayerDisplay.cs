using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPS.Controls.Layer
{
    public partial class TiffLayerDisplay : UserControl
    {
        public TiffLayerDisplay()
        {
            InitializeComponent();
        }

        private string layer;
        public string Layer
        {
            get { return layer; }
            set
            {
                layer = value;
                LayerDisplay.Text = "图层：" + layer;
            }
        }

        private Utilities.PointLatLngAlt home;
        public Utilities.PointLatLngAlt HomePosition
        {
            get
            {
                return home;
            }
            set
            {
                home = value;
                HomePositionDisplay.WGS84Position = value;
            }
        }

        private GMap.NET.RectLatLng rect = new GMap.NET.RectLatLng();

        public GMap.NET.RectLatLng LayerRect
        {
            get
            {
                return rect;
            }
            set
            {
                rect = value;
                LayerRectDisplay.WGS84Rect = value;
            }
        }

        private string createTime;
        public string CreateTime
        {
            get { return createTime; }
            set
            {
                createTime = value;
                CreateTimeDisplay.Text = "创建时间：" + value;
            }
        }

        private string modifyTime;
        public string ModifyTime
        {
            get { return modifyTime; }
            set
            {
                modifyTime = value;
                ModifyTimeDisplay.Text = "修改时间：" + value;
            }
        }

        public void SetLayer(CustomData.Layer.TiffLayerInfo info)
        {
            Layer = info.Layer;
            HomePosition = info.Home;
            CreateTime = info.CreateTime;
            ModifyTime = info.ModifyTime;
            IdDisplay.Text = info.GetOnlyCode();
            if (info.LayerInvaild())
                StateDisplay.SetState("就绪");
            else
                StateDisplay.SetState("无效");
            var bitmapInfo = GDAL.GDAL.LoadImageInfo(info.Layer);
            if (bitmapInfo != null) {
                LayerRect = bitmapInfo.Rect;
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
