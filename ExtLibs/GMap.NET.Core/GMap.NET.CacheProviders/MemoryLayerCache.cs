namespace GMap.NET.CacheProviders
{
    using System.Diagnostics;
    using GMap.NET.Internals;
    using System;
    using System.Xml;


    public class MemoryLayerCache
    {
        static readonly LayerInfoCache layerInfoInMemory = new LayerInfoCache();

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

        static public LayerInfo? GetLayerFromMemoryCache(string key)
        {
            try
            {
                string hash = GetHashCode(key);
                if (string.IsNullOrEmpty(key) || !layerInfoInMemory.ContainsKey(hash))
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

        static public LayerInfo? GetLayerFromMemoryCache(int index)
        {
            try
            {
                if (index >= layerInfoInMemory.Count || index < 0)
                    return null;
                return layerInfoInMemory[index];
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
                }
                else if (!data.Equals(GetLayerFromMemoryCacheWithHashCode(key).GetValueOrDefault()))
                {
                    layerInfoInMemory.Modify(key, data);
                }
                else
                {
                    layerInfoInMemory.MoveToLast(key);
                }
            }
            finally
            {
            }
            return true;
        }

        internal static string GetHashCode(LayerInfo data)
        {
            if (data.Layer != null || data.Layer != "")
            {
                return (data.Layer.GetHashCode().ToString());
            }
            else
            {

                return (data.Lng + data.Lat + data.Alt).GetHashCode().ToString();
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
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(".\\plugins\\GMap.NET.CacheProviders.MemoryLayerCache.xml");
            try
            {
                layerInfoInMemory.FromXML(xmlDoc, out string selectedLayer);
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

