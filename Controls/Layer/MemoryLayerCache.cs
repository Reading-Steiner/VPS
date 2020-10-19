﻿namespace VPS.Layer
{
    using System.Diagnostics;
    using GMap.NET.Internals;
    using System;
    using System.Xml;
    using System.Collections.Generic;

    public class MemoryLayerCache
    {
        static readonly LayerInfoCache layerInfoInMemory = new LayerInfoCache();
        static readonly List<string> layerInfoKey = new List<string>();

        static MemoryLayerCache()
        {
            if (Count <= 0)
                ReadLayerInfoConfig();
        }

        public MemoryLayerCache()
        {
        }

        ~MemoryLayerCache()
        {
            SaveLayerInfoConfig();
        }

        public void Clear()
        {
            try
            {
                layerInfoInMemory.Clear();
                LayerInfosChange?.Invoke();
            }
            finally
            {
            }
        }

        static public int Count
        {
            get
            {
                return layerInfoInMemory.Count;
            }
        }

        static public int TotalCount
        {
            get
            {
                return layerInfoInMemory.TotalCount;
            }
        }

        static public bool IsEmpty
        {
            get
            {
                try
                {
                    return layerInfoInMemory.Count > 0 ? false : true;
                }
                finally
                {
                }
            }
        }

        static public LayerInfo? GetLayerFromMemoryCache(string layer)
        {
            try
            {
                string hash = GetHashCode(layer);
                if (string.IsNullOrEmpty(layer) || !layerInfoInMemory.ContainsKey(hash))
                    return null;
                LayerInfo ret;
                if (layerInfoInMemory.TryGetValue(hash, out ret))
                {
                    return ret;
                }
            }
            catch
            {

            }
            return null;
        }

        static private LayerInfo? GetLayerFromMemoryCacheWithHashCode(string key)
        {
            try
            {
                if (string.IsNullOrEmpty(key) || !layerInfoInMemory.ContainsKey(key))
                    return null;
                LayerInfo ret;
                if (layerInfoInMemory.TryGetValue(key, out ret))
                {
                    return ret;
                }
            }
            catch
            {

            }
            return null;
        }

        static public LayerInfo? GetLayerFromMemoryCache(int index,bool vaild = false)
        {
            try
            {
                if (index >= layerInfoInMemory.Count || index < 0)
                    return null;
                return layerInfoInMemory[index, vaild];
            }
            finally
            {
            }
        }


        static public bool AddLayerToMemoryCache(LayerInfo data)
        {

            try
            {
                string key = GetHashCode(data);
                if (key == null)
                    return false;
                if (!layerInfoInMemory.ContainsKey(key))
                {
                    layerInfoInMemory.Add(key, data);
                    LayerInfosChange?.Invoke();
                }
                else
                {
                    layerInfoInMemory.Modify(key, data);
                    LayerInfosChange?.Invoke();
                }
            }
            catch { }
            finally{ }
            return true;
        }

        static public bool DeleteLayerInMenoryCacheWithHashCode(string key)
        {
            if (key == null)
                return false;
            if (layerInfoInMemory.ContainsKey(key))
            {
                layerInfoInMemory.Remove(key);
                LayerInfosChange?.Invoke();

                return true;
            }
            else
                return false;
        }

        public delegate void LayerInfosChangeHandle();
        static public LayerInfosChangeHandle LayerInfosChange;

        internal static string GetHashCode(LayerInfo data)
        {
            if (data.Layer != null || data.Layer != "")
            {
                return (data.Layer.GetHashCode().ToString());
            }
            else
            {

                return (data.Origin).GetHashCode().ToString();
            }
        }

        internal static string GetHashCode(string data)
        {
            if (data != null || data != "")
            {
                return (data.GetHashCode().ToString());
            }
            else
            {
                return "";
            }
        }

        internal static void ReadLayerInfoConfig()
        {
            if (!System.IO.File.Exists(".\\plugins\\GMap.NET.CacheProviders.MemoryLayerCache.xml"))
                return;
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(".\\plugins\\GMap.NET.CacheProviders.MemoryLayerCache.xml");
                layerInfoInMemory.FromXML(xmlDoc, out string selectedLayer);
                LayerInfosChange?.Invoke();
            }
            catch(Exception ex)
            {
            }
            finally
            {
            }
        }

        internal static void SaveLayerInfoConfig()
        {
            XmlDocument xmlDoc = new XmlDocument();

            XmlDeclaration dec = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
            xmlDoc.AppendChild(dec);

            xmlDoc.AppendChild(layerInfoInMemory.GetXML(xmlDoc));

            //需要保存修改的值
            xmlDoc.Save(".\\plugins\\GMap.NET.CacheProviders.MemoryLayerCache.xml");
            xmlDoc = null;
        }
    }
}

