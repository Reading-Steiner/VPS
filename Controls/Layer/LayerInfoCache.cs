﻿
namespace VPS.Layer
{
    using System.Collections.Generic;
    using System.IO;
    using System;
    using System.Diagnostics;
    using System.Xml;

    class LayerInfoCache : Dictionary<string, LayerInfo>
    {
        public LayerInfoCache() : base()
        {
        }

        private int vaildIndex = 0;
        readonly List<string> Queue = new List<string>();

        public new int Count
        {
            get
            {
                return Queue.Count - vaildIndex;
            }
        }

        public int TotalCount
        {
            get
            {
                return Queue.Count;
            }
        }

        public LayerInfo this[int index, bool vaild = false]
        {
            get
            {
                LayerInfo layerInfo;
                if (vaild)
                    base.TryGetValue(Queue[index], out layerInfo);
                else
                    base.TryGetValue(Queue[index + vaildIndex], out layerInfo);
                return layerInfo;
            }
        }

        public new bool Add(string key, LayerInfo value)
        {
            base.Add(key, value);
            if (File.Exists(value.Layer))
            {
                Queue.Add(key);
                return true;
            }
            else
            {
                Queue.Insert(0, key);
                vaildIndex++;
                return false;
            }

        }


        public bool Modify(string key, LayerInfo value)
        {
            if (Queue.Contains(key))
            {
                Queue.Remove(key);
                base.Remove(key);
            }
            base.Add(key, value);
            if (File.Exists(value.Layer))
            {
                Queue.Add(key);
                return true;
            }
            else
            {
                Queue.Insert(0, key);
                vaildIndex++;
                return false;
            }

        }


        // do not allow directly removal of elements
        public new void Remove(string key)
        {
            Queue.Remove(key);
            base.Remove(key);
        }

        public new void Clear()
        {
            Queue.Clear();
            base.Clear();
        }


        public XmlElement GetXML(XmlDocument xmlDoc)
        {
            XmlElement LayerInfos = xmlDoc.CreateElement("MemoryLayerCache");
            xmlDoc.AppendChild(LayerInfos);

            for (int i = 0; i < Queue.Count; i++)
            {
                // (4)给根节点Books创建第1个子节点
                try
                {
                    base.TryGetValue(Queue[i], out LayerInfo layerInfo);
                    LayerInfos.AppendChild(layerInfo.GetXML(xmlDoc, Queue[i]));
                }
                catch
                {

                }
            }
            return LayerInfos;
        }

        public void FromXML(XmlDocument xmlDoc, out string selectedKey)
        {
            selectedKey = null;
            XmlNode root = xmlDoc.SelectSingleNode("MemoryLayerCache");
            foreach (XmlNode LayerInfoKey in root)
            {
                if (LayerInfoKey.Name == "key")
                {
                    string key = LayerInfoKey.FirstChild.Value;
                    LayerInfo? layer = LayerInfo.FromXML(LayerInfoKey);
                    if (layer != null)
                    {
                        if (Add(key, layer.GetValueOrDefault()))
                            selectedKey = key;
                    }
                }
            }
        }


    }
}
