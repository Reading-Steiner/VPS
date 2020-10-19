namespace VPS.Layer
{
    using System.IO;
    using System;
    using System.Collections.Generic;
    using System.Xml;
    using System.Drawing;

    public struct LayerInfo
    {
        private enum LayerTypes
        {
            file
        }
        private LayerTypes layerType;
        public string LayerType {
            get
            {
                return layerType.ToString() ;
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

        private readonly Color transparent;
        public Color Transparent
        {
            get
            {
                return transparent;
            }
        }

        public LayerInfo(string path, Utilities.PointLatLngAlt origin, System.Drawing.Color transparent)
        {
            this.originLat = 0.0;
            this.originLng = 0.0;
            this.originAlt = 0.0;
            this.frameOfAlt = "Relative";
            this.path = path;
            this.scale = 1;
            this.transparent = transparent;
            this.layerType = LayerTypes.file;
            this.Origin = origin;

        }

        public LayerInfo(string path, Utilities.PointLatLngAlt origin, double scale, System.Drawing.Color transparent)
        {
            this.originLat = 0.0;
            this.originLng = 0.0;
            this.originAlt = 0.0;
            this.frameOfAlt = "Relative";
            this.path = path;
            this.scale = scale;
            this.transparent = transparent;
            this.layerType = LayerTypes.file;
            this.Origin = origin;
        }

        public new string GetHashCode()
        {
            if (Layer != null || Layer != "")
            {
                return ((uint)Layer.GetHashCode()).ToString("X");
            }
            else
            {

                return ((uint)(Origin).GetHashCode()).ToString("X");
            }
        }

        public override string ToString()
        {
            return Layer + " with origin (" + originLng + "," + originLat + "," + originAlt +"), scale (" + ScaleFormat + ")";
        }

        public bool Equals(LayerInfo obj)
        {
            if (obj.path != path)
                return false;
            if (obj.originLng != originLng || obj.originLat != originLat)
                return false;

            return true;
        }

        public XmlElement GetXML(XmlDocument xmlDoc, string key)
        {

            XmlElement keyIndex = xmlDoc.CreateElement("key");
            keyIndex.InnerText = key;

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

            return keyIndex;
        }

        static public LayerInfo? FromXML(XmlNode LayerInfoKeys)
        {
            if (LayerInfoKeys.Name == "key")
            {
                LayerTypes layerType = LayerTypes.file;
                string path = "";
                Utilities.PointLatLngAlt origin = new Utilities.PointLatLngAlt();
                double? scale = null;
                Color transparent = Color.Transparent;
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
                switch (layerType)
                {
                    case LayerTypes.file:
                        return new LayerInfo(
                            path,
                            origin,
                            scale.GetValueOrDefault(),
                            transparent);
                    default:
                        return new LayerInfo(
                            path,
                            origin,
                            scale.GetValueOrDefault(),
                            transparent);
                }
            }
            else
                return null;
        }
    }

}
