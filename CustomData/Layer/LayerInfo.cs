namespace VPS.CustomData.Layer
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

        #region LayerHome
        private double homeLng;
        private double homeLat;
        private double homeAlt;
        private string frameOfHomeAlt;

        #region 访问器
        public VPS.CustomData.WP.Position Home
        {
            get
            {
                var origin = new VPS.CustomData.WP.Position(homeLat, homeLng, homeAlt);
                origin.AltMode = frameOfHomeAlt;
                origin.Command = WP.WPCommands.HomeCommand;
                return origin;
            }
            set
            {
                homeLng = value.Lng;
                homeLat = value.Lat;
                homeAlt = value.Alt;
                if (VPS.CustomData.EnumCollect.AltFrame.Modes.Contains(value.AltMode))
                    frameOfHomeAlt = value.AltMode;
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
            VPS.CustomData.WP.Position home,
            double scale = 1, string create = null, string modify = null)
        {
            this.layerType = layerInfo;

            this.url = url;

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
            return GetOnlyCode() + " with origin (" + Home.ToString() + "), type (" + layerType + ")";
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
                    info.Home,
                    info.scale,
                    this.CreateTime,
                    DateTime.Now.ToString("yyyy年 MM月 dd日 HH:mm:ss"));
            }
        }

        protected virtual void SetLayerInfo(
            LayerTypes layerInfo, string url,
            VPS.CustomData.WP.Position home, double scale = 1,
            string create = null, string modify = null)
        {
            this.layerType = layerInfo;

            this.url = url;

            this.Home = home;

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
                homeFrame.InnerText = this.Home.AltMode;
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
            VPS.CustomData.WP.Position origin = new VPS.CustomData.WP.Position();
            VPS.CustomData.WP.Position home = new VPS.CustomData.WP.Position();
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
                        origin.AltMode = Info.InnerText;
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
                        home.AltMode = Info.InnerText;
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
            return new LayerInfo(LayerTypes.none, path, home, scale, createTime, modifyTime);
        }
        #endregion

    }

}

