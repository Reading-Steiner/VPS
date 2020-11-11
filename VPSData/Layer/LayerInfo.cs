namespace VPS.Layer
{
    using System;
    using System.Drawing;
    using System.Xml;

    public class LayerInfo
    {
        protected enum LayerTypes
        {
            tiff,
            none
        }
        protected LayerTypes layerType;

        #region LayerType

        #region 访问器
        public string LayerType
        {
            get
            {
                return layerType.ToString();
            }
        }
        #endregion
        #endregion

        #region LayerOrigin
        private double originLng;
        private double originLat;
        private double originAlt;
        private string frameOfOriginAlt;

        #region 访问器
        public Utilities.PointLatLngAlt Origin
        {
            get
            {
                var origin = new Utilities.PointLatLngAlt(originLat, originLng, originAlt);
                origin.Tag2 = frameOfOriginAlt;
                return origin;
            }
            set
            {
                originLng = value.Lng;
                originLat = value.Lat;
                originAlt = value.Alt;
                if (value.Tag2 == "Relative" || value.Tag2 == "Absolute" || value.Tag2 == "Terrain")
                    frameOfOriginAlt = value.Tag2;
                else
                    frameOfOriginAlt = "Relative";
            }
        }
        #endregion
        #endregion

        #region LayerOrigin
        private double homeLng;
        private double homeLat;
        private double homeAlt;
        private string frameOfHomeAlt;

        #region 访问器
        public Utilities.PointLatLngAlt Home
        {
            get
            {
                var origin = new Utilities.PointLatLngAlt(homeLat, homeLng, homeAlt);
                origin.Tag2 = frameOfHomeAlt;
                return origin;
            }
            set
            {
                homeLng = value.Lng;
                homeLat = value.Lat;
                homeAlt = value.Alt;
                if (value.Tag2 == "Relative" || value.Tag2 == "Absolute" || value.Tag2 == "Terrain")
                    frameOfHomeAlt = value.Tag2;
                else
                    frameOfHomeAlt = "Relative";
            }
        }
        #endregion
        #endregion

        #region LayerScale
        private double scale;

        #region 访问器
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
        #endregion
        #endregion

        #region LayerUrl
        private string url;

        #region 访问器
        public string Layer
        {
            get
            {
                return url;
            }
        }
        #endregion
        #endregion

        #region LayerTime
        protected string createTime;
        protected string modifyTime;

        #region 访问器

        public string CreateTime
        {
            get { return createTime; }
        }
        public string ModifyTime
        {
            get { return modifyTime; }
        }
        #endregion
        #endregion

        #region LayerInfo 构造函数
        public LayerInfo() { }

        protected LayerInfo(
            LayerTypes layerInfo, string url,
            Utilities.PointLatLngAlt origin, Utilities.PointLatLngAlt home,
            double scale = 1, string create = null, string modify = null)
        {
            this.layerType = layerInfo;

            this.url = url;

            this.Origin = origin;

            this.Home = home;

            this.scale = scale;

            if (create != null)
                createTime = create;
            else
                createTime = DateTime.Now.ToString("yyyy年 MM月 dd日 HH:mm:ss");
            if (modify != null)
                modifyTime = modify;
            else
                modifyTime = createTime;
        }
        #endregion



        #region LayerInfo  函数重载

        #region LayerInfo GetHashCode

        public virtual string GetOnlyCode()
        {
            return "";
        }
        #endregion

        #region LayerInfo ToString

        public override string ToString()
        {
            return GetOnlyCode() + " with origin (" + Origin.ToString() + "), type (" + layerType + ")";
        }
        #endregion

        #region LayerInfo Equals

        public virtual bool Equals(LayerInfo obj)
        {
            return obj.GetOnlyCode() == GetOnlyCode();
        }
        #endregion

        //自定义

        #region LayerInfo SetLayerInfo

        public virtual void SetLayerInfo(LayerInfo info)
        {
            if (GetOnlyCode() == info.GetOnlyCode())
            {

                this.SetLayerInfo(
                    info.layerType,
                    info.url,
                    info.Origin,
                    info.scale,
                    this.CreateTime,
                    DateTime.Now.ToString("yyyy年 MM月 dd日 HH:mm:ss"));
            }
        }

        protected virtual void SetLayerInfo(
            LayerTypes layerInfo, string url,
            Utilities.PointLatLngAlt origin, double scale = 1,
            string create = null, string modify = null)
        {
            this.layerType = layerInfo;

            this.url = url;

            this.Origin = origin;

            this.scale = scale;

            if (create != null)
                createTime = create;
            else
                createTime = DateTime.Now.ToString("yyyy年 MM月 dd日 HH:mm:ss");
            if (modify != null)
                modifyTime = modify;
            else
                modifyTime = DateTime.Now.ToString("yyyy年 MM月 dd日 HH:mm:ss");
        }
        #endregion

        #region LayerInfo 生成XML

        public virtual XmlElement GetXML(XmlDocument xmlDoc, string key)
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
                originX.InnerText = this.Origin.Lng.ToString();
                keyIndex.AppendChild(originX);

                XmlElement originY = xmlDoc.CreateElement("originLat");
                originY.InnerText = this.Origin.Lat.ToString();
                keyIndex.AppendChild(originY);

                XmlElement originZ = xmlDoc.CreateElement("originAlt");
                originZ.InnerText = this.Origin.Alt.ToString();
                keyIndex.AppendChild(originZ);

                XmlElement originFrame = xmlDoc.CreateElement("frameOfOriginAlt");
                originFrame.InnerText = this.Origin.Tag2;
                keyIndex.AppendChild(originFrame);

                XmlElement homeX = xmlDoc.CreateElement("homeLng");
                homeX.InnerText = this.Home.Lng.ToString();
                keyIndex.AppendChild(homeX);

                XmlElement homeY = xmlDoc.CreateElement("homeLat");
                homeY.InnerText = this.Home.Lat.ToString();
                keyIndex.AppendChild(homeY);

                XmlElement homeZ = xmlDoc.CreateElement("homeAlt");
                homeZ.InnerText = this.Home.Alt.ToString();
                keyIndex.AppendChild(homeZ);

                XmlElement homeFrame = xmlDoc.CreateElement("frameOfHomeAlt");
                homeFrame.InnerText = this.Home.Tag2;
                keyIndex.AppendChild(homeFrame);

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
            }
            return keyIndex;
        }
        #endregion

        #region LayerInfo LayerInvaild

        public virtual bool LayerInvaild()
        {
            return false;
        }
        #endregion

        #endregion


        #region LayerInfo 解析XML

        static public LayerInfo FromXML(XmlNode LayerInfoKeys)
        {
            if (LayerInfoKeys.Name == "key")
            {
                LayerTypes layerType = LayerTypes.tiff;
                foreach (XmlNode Info in LayerInfoKeys.ChildNodes)
                {
                    switch (Info.Name)
                    {
                        case "layerType":
                            switch (Info.InnerText)
                            {
                                case "tiff":
                                    layerType = LayerTypes.tiff;
                                    break;
                            }
                            break;
                    }
                }
                switch (layerType)
                {
                    case LayerTypes.tiff:
                        return TiffLayerInfo.FromXMLToTiff(LayerInfoKeys);
                    default:
                        return LayerInfo.FromXMLToBase(LayerInfoKeys);
                }
            }
            return null;
        }

        static public LayerInfo FromXMLToBase(XmlNode LayerInfoKeys)
        {
            string path = "";
            Utilities.PointLatLngAlt origin = new Utilities.PointLatLngAlt();
            Utilities.PointLatLngAlt home = new Utilities.PointLatLngAlt();
            double scale = 1;
            string createTime = DateTime.Now.ToString("yyyy年 MM月 dd日 HH:mm:ss");
            string modifyTime = DateTime.Now.ToString("yyyy年 MM月 dd日 HH:mm:ss");
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
                    case "frameOfOriginAlt":
                        origin.Tag2 = Info.InnerText;
                        break;
                    case "homeLng":
                        home.Lng = System.Convert.ToDouble(Info.InnerText);
                        break;
                    case "homeLat":
                        home.Lat = System.Convert.ToDouble(Info.InnerText);
                        break;
                    case "homeAlt":
                        home.Alt = System.Convert.ToDouble(Info.InnerText);
                        break;
                    case "frameOfHomeAlt":
                        home.Tag2 = Info.InnerText;
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
                }
            }
            if (path == null)
                return null;
            return new LayerInfo(LayerTypes.none, path, origin, home, scale, createTime, modifyTime);
        }
        #endregion

    }

}

