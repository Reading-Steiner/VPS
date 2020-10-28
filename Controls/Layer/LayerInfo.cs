namespace VPS.Layer
{
    using System;
    using System.Drawing;
    using System.Xml;

    public struct LayerInfo
    {
        private enum LayerTypes
        {
            file,
            limit
        }
        private LayerTypes layerType;
        public string LayerType
        {
            get
            {
                return layerType.ToString();
            }
        }
        private double originLng;
        private double originLat;
        private double originAlt;
        private string frameOfAlt;
        public Utilities.PointLatLngAlt Origin
        {
            get
            {
                var origin = new Utilities.PointLatLngAlt(originLat, originLng, originAlt);
                origin.Tag2 = frameOfAlt;
                return origin;
            }
            set
            {
                originLng = value.Lng;
                originLat = value.Lat;
                originAlt = value.Alt;
                if (value.Tag2 == "Relative" || value.Tag2 == "Absolute" || value.Tag2 == "Terrain")
                    frameOfAlt = value.Tag2;
                else
                    frameOfAlt = "Relative";
            }
        }

        private double scale;
        public double Scale
        {
            get
            {
                return scale;
            }
            set
            {
                scale = value;
            }
        }

        public string ScaleFormat
        {
            get
            {
                return "1:" + scale.ToString();
            }
        }

        private string path;
        public string Layer
        {
            get
            {
                return path;
            }
        }

        private Color transparent;
        public Color Transparent
        {
            get
            {
                return transparent;
            }
        }

        private string createTime;
        private string modifyTime;
        public string CreateTime
        {
            get { return createTime; }
        }
        public string ModifyTime
        {
            get { return modifyTime; }
        }

        #region LayerInfo 构造函数
        #region Type:file
        public LayerInfo(
            string path,
            Utilities.PointLatLngAlt origin,
            System.Drawing.Color transparent,
            double scale = 1,
            string create = null, string modify = null)
        {
            this.originLat = 0.0;
            this.originLng = 0.0;
            this.originAlt = 0.0;
            this.frameOfAlt = "Relative";
            this.path = path;
            this.scale = scale;
            this.transparent = transparent;
            this.layerType = LayerTypes.file;
            if (create != null)
                createTime = create;
            else
                createTime = DateTime.Now.ToString("F");
            if (modify != null)
                modifyTime = modify;
            else
                modifyTime = createTime;
            this.Origin = origin;
        }
        #endregion
        #endregion

        #region LayerInfo SetLayerInfo

        #region 入口函数
        public LayerInfo SetLayerInfo(LayerInfo info)
        {
            if (GetHashCode() == info.GetHashCode())
            {
                switch (info.layerType)
                {
                    case LayerTypes.file:
                        SetLayerInfo(info.path, info.Origin, info.transparent, info.scale, createTime, DateTime.Now.ToString("F"));
                        break;
                }
            }
            return info;
        }
        #endregion

        #region Type:file
        private void SetLayerInfo(
        string path,
        Utilities.PointLatLngAlt origin,
        System.Drawing.Color transparent,
        double scale = 1,
        string create = null, string modify = null)
        {
            this.originLat = 0.0;
            this.originLng = 0.0;
            this.originAlt = 0.0;
            this.frameOfAlt = "Relative";
            this.path = path;
            this.scale = scale;
            this.transparent = transparent;
            this.layerType = LayerTypes.file;
            if (create != null)
                createTime = create;
            else
                createTime = DateTime.Now.ToString("F");
            if (modify != null)
                modifyTime = modify;
            else
                modifyTime = createTime;
            this.Origin = origin;
        }
        #endregion

        #endregion

        #region LayerInfo  函数重载
        #region LayerInfo GetHashCode
        public new string GetHashCode()
        {
            switch (layerType)
            {
                case LayerTypes.file:
                    return ((uint)Layer.GetHashCode()).ToString("X");
            }
            return "";
        }
        #endregion

        #region LayerInfo ToString
        public override string ToString()
        {
            switch (layerType)
            {
                case LayerTypes.file:
                    return GetHashCode() + " with origin (" + originLng + "," + originLat + "," + originAlt + "), scale (" + ScaleFormat + ")";
            }
            return "";
        }
        #endregion

        #region LayerInfo Equals
        public bool Equals(LayerInfo obj)
        {
            if (obj.GetHashCode() != GetHashCode())
                return false;
            return true;
        }
        #endregion

        #endregion

        #region LayerInfo 生成XML

        #region 入口函数
        public XmlElement GetXML(XmlDocument xmlDoc, string key)
        {
            switch (this.layerType)
            {
                case LayerTypes.file:
                    {
                        return GetXMLFromFile(xmlDoc, key);
                    }
            }

            XmlElement keyIndex = xmlDoc.CreateElement("key");
            keyIndex.InnerText = key;
            return keyIndex;
        }
        #endregion

        #region Type:file
        private XmlElement GetXMLFromFile(XmlDocument xmlDoc, string key)
        {
            XmlElement keyIndex = xmlDoc.CreateElement("key");
            keyIndex.InnerText = key;
            {
                XmlElement type = xmlDoc.CreateElement("layerType");
                type.InnerText = this.layerType.ToString();
                keyIndex.AppendChild(type);

                XmlElement path = xmlDoc.CreateElement("path");
                path.InnerText = this.Layer;
                keyIndex.AppendChild(path);

                XmlElement originX = xmlDoc.CreateElement("originLng");
                originX.InnerText = this.originLng.ToString();
                keyIndex.AppendChild(originX);

                XmlElement originY = xmlDoc.CreateElement("originLat");
                originY.InnerText = this.originLat.ToString();
                keyIndex.AppendChild(originY);

                XmlElement originZ = xmlDoc.CreateElement("originAlt");
                originZ.InnerText = this.originAlt.ToString();
                keyIndex.AppendChild(originZ);

                XmlElement frame = xmlDoc.CreateElement("frameOfAlt");
                frame.InnerText = this.frameOfAlt;
                keyIndex.AppendChild(frame);

                XmlElement scale = xmlDoc.CreateElement("scale");
                scale.InnerText = this.Scale.ToString();
                keyIndex.AppendChild(scale);

                XmlElement createTime = xmlDoc.CreateElement("createTime");
                createTime.InnerText = this.createTime.ToString();
                keyIndex.AppendChild(createTime);

                XmlElement modifyTime = xmlDoc.CreateElement("modifyTime");
                modifyTime.InnerText = this.modifyTime.ToString();
                keyIndex.AppendChild(modifyTime);

                XmlElement Scale = xmlDoc.CreateElement("scale");
                Scale.InnerText = this.Scale.ToString();
                keyIndex.AppendChild(Scale);

                XmlElement transparent = xmlDoc.CreateElement("transparent");
                keyIndex.AppendChild(transparent);

                XmlElement A = xmlDoc.CreateElement("A");
                A.InnerText = this.Transparent.A.ToString();
                transparent.AppendChild(A);

                XmlElement R = xmlDoc.CreateElement("R");
                R.InnerText = this.Transparent.R.ToString();
                transparent.AppendChild(R);

                XmlElement G = xmlDoc.CreateElement("G");
                G.InnerText = this.Transparent.G.ToString();
                transparent.AppendChild(G);

                XmlElement B = xmlDoc.CreateElement("B");
                B.InnerText = this.Transparent.B.ToString();
                transparent.AppendChild(B);
            }
            return keyIndex;
        }
        #endregion

        #endregion

        #region LayerInfo 解析XML

        #region 入口函数
        static public LayerInfo? FromXML(XmlNode LayerInfoKeys)
        {
            if (LayerInfoKeys.Name == "key")
            {
                LayerTypes layerType = LayerTypes.file;
                foreach (XmlNode Info in LayerInfoKeys.ChildNodes)
                {
                    switch (Info.Name)
                    {
                        case "layerType":
                            switch (Info.InnerText)
                            {
                                case "file":
                                    layerType = LayerTypes.file;
                                    break;
                            }
                            break;
                    }
                }
                switch (layerType)
                {
                    case LayerTypes.file:
                        return FromXMLGetFile(LayerInfoKeys);
                }
            }
            return null;
        }
        #endregion

        #region Type:file
        static private LayerInfo? FromXMLGetFile(XmlNode LayerInfoKeys)
        {
            string path = "";
            Utilities.PointLatLngAlt origin = new Utilities.PointLatLngAlt();
            double scale = 1;
            string createTime = DateTime.Now.ToString("F"), modifyTime = DateTime.Now.ToString("F");
            Color transparent = Color.Transparent;
            foreach (XmlNode Info in LayerInfoKeys.ChildNodes)
            {
                switch (Info.Name)
                {
                    case "path":
                        path = Info.InnerText;
                        break;
                    case "originLng":
                        origin.Lng = System.Convert.ToDouble(Info.InnerText);
                        break;
                    case "originLat":
                        origin.Lat = System.Convert.ToDouble(Info.InnerText);
                        break;
                    case "originAlt":
                        origin.Alt = System.Convert.ToDouble(Info.InnerText);
                        break;
                    case "frameOfAlt":
                        origin.Tag2 = Info.InnerText;
                        break;
                    case "scale":
                        scale = System.Convert.ToDouble(Info.InnerText);
                        break;
                    case "createTime":
                        createTime = Info.InnerText;
                        break;
                    case "modifyTime":
                        modifyTime = Info.InnerText;
                        break;
                    case "transparent":
                        {
                            int A = 0, R = 0, G = 0, B = 0;
                            foreach (XmlNode channel in Info.ChildNodes)
                            {
                                switch (channel.Name)
                                {
                                    case "A":
                                        A = System.Convert.ToUInt16(channel.InnerText);
                                        break;
                                    case "R":
                                        R = System.Convert.ToUInt16(channel.InnerText);
                                        break;
                                    case "G":
                                        G = System.Convert.ToUInt16(channel.InnerText);
                                        break;
                                    case "B":
                                        B = System.Convert.ToUInt16(channel.InnerText);
                                        break;

                                }
                            }
                            transparent = Color.FromArgb(A, R, G, B);
                        }
                        break;
                }
            }
            if (path == null)
                return null;
            return new LayerInfo(path, origin, transparent, scale, createTime, modifyTime);
        }
        #endregion

        #endregion
    }
}
