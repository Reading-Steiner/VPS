using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace VPS.CustomData.Layer
{
    public class TiffLayerInfo : LayerInfo
    {

        #region LayerInfo 访问器

        #region LayerColor
        private Color transparent;

        #region 访问器
        public Color Transparent
        {
            get
            {
                return transparent;
            }
        }
        #endregion
        #endregion
        #endregion

        #region LayerInfo 构造函数

        public TiffLayerInfo(
            string path,
            VPS.CustomData.WP.Position home,
            System.Drawing.Color transparent, double scale = 1,
            string create = null, string modify = null)
            : base(LayerTypes.tiff, path, home, scale, create, modify)
        {
            this.transparent = transparent;
        }

        public TiffLayerInfo(TiffLayerInfo info)
            : base(info.layerType, info.Layer, info.Home, info.Scale, info.CreateTime, info.ModifyTime)
        {
            this.transparent = info.transparent;
        }
        #endregion

        #region LayerInfo SetLayerInfo

        public override void SetLayerInfo(LayerInfo info)
        {
            if (Equals(info))
            {
                if (info is TiffLayerInfo)
                {
                    TiffLayerInfo newLayer = info as TiffLayerInfo;
                    this.SetLayerInfo(
                        newLayer.Layer,
                        newLayer.Home,
                        newLayer.Transparent,
                        newLayer.Scale,
                        this.CreateTime,
                        DateTime.Now.ToString("yyyy年 MM月 dd日 HH:mm:ss"));
                }
            }
        }

        private void SetLayerInfo(
        string path,
        VPS.CustomData.WP.Position origin, System.Drawing.Color transparent, double scale = 1,
        string create = null, string modify = null)
        {
            this.transparent = transparent;

            base.SetLayerInfo(LayerTypes.tiff, path, origin, scale, create, modify);
        }
        #endregion

        #region LayerInfo 函数重载

        #region LayerInfo GetHashCode

        public override string GetOnlyCode()
        {
            return ((uint)Layer.GetHashCode()).ToString("X");
        }
        #endregion

        #region LayerInfo ToString

        public override string ToString()
        {
            return GetHashCode() + " with origin (" + Home.ToString() + "), type (" + layerType + ")";
        }
        #endregion

        #region LayerInfo Equals

        public override bool Equals(LayerInfo obj)
        {
            return obj.GetOnlyCode() == GetOnlyCode();
        }
        #endregion

        //自定义
        #region LayerInfo LayerInvaild

        public override bool LayerInvaild()
        {
            return System.IO.File.Exists(Layer);
        }
        #endregion

        #region LayerInfo 生成XML

        public override XmlElement GetXML(XmlDocument xmlDoc, string key)
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

        public static TiffLayerInfo FromXMLToTiff(XmlNode LayerInfoKeys)
        {
            string path = "";
            VPS.CustomData.WP.Position origin = new VPS.CustomData.WP.Position();
            VPS.CustomData.WP.Position home = new VPS.CustomData.WP.Position();
            double scale = 1;
            string createTime = DateTime.Now.ToString("yyyy年 MM月 dd日 hh:mm:ss");
            string modifyTime = DateTime.Now.ToString("yyyy年 MM月 dd日 hh:mm:ss");
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
            return new TiffLayerInfo(path, home, transparent, scale, createTime, modifyTime);
        }
        #endregion

    }
}
