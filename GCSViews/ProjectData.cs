using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPS.Utilities;

namespace VPS.GCSViews
{
    public struct ProjectData
    {
        public List<CustomData.WP.VPSPosition> poly;
        public List<CustomData.WP.VPSPosition> wp;
        public string layer;
        public CustomData.WP.VPSRect layerRect;
        public CustomData.WP.VPSPosition homePosition;

        public bool isLeftHide;
        public bool isBottomHide;
        public bool isConfigGridVisible;

    }
}
