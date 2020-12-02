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
        public List<PointLatLngAlt> poly;
        public List<PointLatLngAlt> wp;
        public string layer;
        public GMap.NET.RectLatLng layerRect;
        public PointLatLngAlt homePosition;

        public bool isLeftHide;
        public bool isBottomHide;
        public bool isConfigGridVisible;

    }
}
