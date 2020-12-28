namespace VPS.CustomData.Layer
{
    using System.Diagnostics;
    using GMap.NET.Internals;
    using System;
    using System.Xml;
    using System.Collections.Generic;

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

        static public LayerInfo GetLayerFromMemoryCache(string layer)
        {
            try
            {
                string hash = GetHashCode(layer);
                if (string.IsNullOrEmpty(layer) || !layerInfoInMemory.ContainsKey(hash))
                    return null;
                if (layerInfoInMemory.TryGetValue(hash, out LayerInfo ret))
                {
                    return ret;
                }
            }
            catch
            {

            }
            return null;
        }

        static public LayerInfo GetLayerFromMemoryCacheWithHashCode(string key)
        {
            try
            {
                if (string.IsNullOrEmpty(key) || !layerInfoInMemory.ContainsKey(key))
                    return null;
                if (layerInfoInMemory.TryGetValue(key, out LayerInfo ret))
                {
                    return ret;
                }
            }
            catch
            {

            }
            return null;
        }

        static public LayerInfo GetLayerFromMemoryCache(int index, bool vaild = false)
        {
            try
            {
                if (index < 0 ||
                    vaild ? index >= layerInfoInMemory.TotalCount : index >= layerInfoInMemory.Count)
                    return null;
                return layerInfoInMemory[index, vaild];
            }
            catch
            {
                return null;
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
            return data.GetOnlyCode();
        }

        internal static string GetHashCode(string data)
        {
            if (data != null && data != "")
            {
                return ((uint)data.GetHashCode()).ToString("X");
            }
            else
            {
                return "";
            }
        }

        internal static void ReadLayerInfoConfig()
        {
            string file = VPS.Utilities.Settings.GetUserDataDirectory() + 
                "plugins\\GMap.NET.CacheProviders.MemoryLayerCache.xml";
            if (!System.IO.File.Exists(file))
                return;
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(file);
                layerInfoInMemory.FromXML(xmlDoc);
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
            string path = VPS.Utilities.Settings.GetUserDataDirectory() + "plugins\\";
            if (!System.IO.Directory.Exists(path))

            {
                System.IO.Directory.CreateDirectory(path);//不存在就创建目录

            }
            xmlDoc.Save(path + "GMap.NET.CacheProviders.MemoryLayerCache.xml");
            xmlDoc = null;
        }
    }
}

