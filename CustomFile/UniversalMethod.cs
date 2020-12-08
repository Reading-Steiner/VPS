using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPS.CustomFile
{
    class UniversalMethod
    {
        public static string GetFileName(string file)
        {
            if (File.Exists(file) && !string.IsNullOrEmpty(file))
            {
                FileInfo info = new FileInfo(file);
                return info.Name;
            }
            return "";
        }

        public static string GetFilePath(string file)
        {
            if (File.Exists(file) && !string.IsNullOrEmpty(file))
            {
                FileInfo info = new FileInfo(file);
                return info.FullName;
            }
            return "";
        }

        public static string GetFileType(string file)
        {
            if (File.Exists(file) && !string.IsNullOrEmpty(file))
            {
                FileInfo info = new FileInfo(file);
                return info.Extension;
            }
            return "";
        }

        public static string GetFileSize(string file)
        {

            if (File.Exists(file) && !string.IsNullOrEmpty(file))
            {
                FileInfo info = new FileInfo(file);
                long size = info.Length;
                string sizeBig = ""; string sizeSmall = ""; string sizeTag = "";
                if (size / 1024 > 1)
                {
                    sizeBig = ((int)(size / 1024)).ToString();
                    sizeSmall = ((int)(size % 1024)).ToString();
                    sizeTag = "KB";
                    size = size / 1024;
                    if (size / 1024 > 1)
                    {
                        sizeBig = ((int)(size / 1024)).ToString();
                        sizeSmall = ((int)(size % 1024)).ToString();
                        sizeTag = "MB";
                        size = size / 1024;
                        if (size / 1024 > 1)
                        {
                            sizeBig = ((int)(size / 1024)).ToString();
                            sizeSmall = ((int)(size % 1024)).ToString();
                            sizeTag = "GB";
                        }
                    }
                }
                else
                {
                    sizeBig = ((int)(size / 1024)).ToString();
                    sizeSmall = ((int)(size % 1024)).ToString();
                    sizeTag = "Byte";
                }
                return sizeBig + "." + sizeSmall + sizeTag;
            }
            return "";
        }

        public static string GetFileCreate(string file)
        {
            if (File.Exists(file) && !string.IsNullOrEmpty(file))
            {
                FileInfo info = new FileInfo(file);
                return info.LastWriteTime.ToLongDateString() + " " + 
                    info.CreationTime.ToLongTimeString();
            }
            return "";
        }

        public static string GetFileModify(string file)
        {
            if (File.Exists(file) && !string.IsNullOrEmpty(file))
            {
                FileInfo info = new FileInfo(file);
                return info.LastWriteTime.ToLongDateString() + " " + 
                    info.LastWriteTime.ToLongTimeString();
            }
            return "";
        }

    }
    }
