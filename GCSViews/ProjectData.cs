﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPS.Utilities;

namespace VPS.GCSViews
{
    public struct ProjectData
    {
        public List<CustomData.WP.Position> poly;
        public List<CustomData.WP.Position> wp;
        public string layer;
        public CustomData.WP.Rect layerRect;
        public CustomData.WP.Position homePosition;

        public bool isLeftHide;
        public bool isBottomHide;
        public bool isConfigGridVisible;

    }
}
