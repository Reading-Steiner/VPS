using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using VPS.Utilities;

namespace VPS.Grid
{
    public struct camerainfo
    {
        public string name;
        public float focallen;
        public float sensorwidth;
        public float sensorheight;
        public int imagewidth;
        public int imageheight;

        static Dictionary<string, camerainfo> camerainfos = new Dictionary<string, camerainfo>();
        static List<string> cameras = new List<string>();
        static public List<string> GetCameras()
        {
            if (cameras.Count <= 0)
            {
                xmlcamera(false, Settings.GetRunningDirectory() + "camerasBuiltin.xml");
                xmlcamera(false, Settings.GetUserDataDirectory() + "cameras.xml");
            }
            return cameras;
        }
        static public camerainfo GetCameraInfos(string camera)
        {
            if (camerainfos.Count <= 0 || !camerainfos.ContainsKey(camera))
            {
                xmlcamera(false, Settings.GetRunningDirectory() + "camerasBuiltin.xml");
                xmlcamera(false, Settings.GetUserDataDirectory() + "cameras.xml");
            }

            if (camerainfos.ContainsKey(camera))
                return camerainfos[camera];
            else
                return new camerainfo();
        }
        static private void xmlcamera(bool write, string filename)
        {
            bool exists = File.Exists(filename);

            if (write || !exists)
            {
                try
                {
                    XmlTextWriter xmlwriter = new XmlTextWriter(filename, Encoding.ASCII);
                    xmlwriter.Formatting = Formatting.Indented;

                    xmlwriter.WriteStartDocument();

                    xmlwriter.WriteStartElement("Cameras");

                    foreach (string key in camerainfos.Keys)
                    {
                        try
                        {
                            if (key == "")
                                continue;
                            xmlwriter.WriteStartElement("Camera");
                            xmlwriter.WriteElementString("name", camerainfos[key].name);
                            xmlwriter.WriteElementString("flen", camerainfos[key].focallen.ToString(new System.Globalization.CultureInfo("en-US")));
                            xmlwriter.WriteElementString("imgh", camerainfos[key].imageheight.ToString(new System.Globalization.CultureInfo("en-US")));
                            xmlwriter.WriteElementString("imgw", camerainfos[key].imagewidth.ToString(new System.Globalization.CultureInfo("en-US")));
                            xmlwriter.WriteElementString("senh", camerainfos[key].sensorheight.ToString(new System.Globalization.CultureInfo("en-US")));
                            xmlwriter.WriteElementString("senw", camerainfos[key].sensorwidth.ToString(new System.Globalization.CultureInfo("en-US")));
                            xmlwriter.WriteEndElement();
                        }
                        catch { }
                    }

                    xmlwriter.WriteEndElement();

                    xmlwriter.WriteEndDocument();
                    xmlwriter.Close();

                }
                catch (Exception ex) { CustomMessageBox.Show(ex.ToString()); }
            }
            else
            {
                try
                {
                    using (var xmlreader = new XmlTextReader(filename))
                    {
                        while (xmlreader.Read())
                        {
                            xmlreader.MoveToElement();
                            try
                            {
                                switch (xmlreader.Name)
                                {
                                    case "Camera":
                                        {
                                            camerainfo camera = new camerainfo();

                                            while (xmlreader.Read())
                                            {
                                                bool dobreak = false;
                                                xmlreader.MoveToElement();
                                                switch (xmlreader.Name)
                                                {
                                                    case "name":
                                                        camera.name = xmlreader.ReadString();
                                                        break;
                                                    case "imgw":
                                                        camera.imagewidth = int.Parse(xmlreader.ReadString(), new System.Globalization.CultureInfo("en-US"));
                                                        break;
                                                    case "imgh":
                                                        camera.imageheight = int.Parse(xmlreader.ReadString(), new System.Globalization.CultureInfo("en-US"));
                                                        break;
                                                    case "senw":
                                                        camera.sensorwidth = float.Parse(xmlreader.ReadString(), new System.Globalization.CultureInfo("en-US"));
                                                        break;
                                                    case "senh":
                                                        camera.sensorheight = float.Parse(xmlreader.ReadString(), new System.Globalization.CultureInfo("en-US"));
                                                        break;
                                                    case "flen":
                                                        camera.focallen = float.Parse(xmlreader.ReadString(), new System.Globalization.CultureInfo("en-US"));
                                                        break;
                                                    case "Camera":
                                                        camerainfos[camera.name] = camera;
                                                        dobreak = true;
                                                        break;
                                                }
                                                if (dobreak)
                                                    break;
                                            }
                                            string temp = xmlreader.ReadString();
                                        }
                                        break;
                                    case "Config":
                                        break;
                                    case "xml":
                                        break;
                                    default:
                                        if (xmlreader.Name == "") // line feeds
                                            break;
                                        //config[xmlreader.Name] = xmlreader.ReadString();
                                        break;
                                }
                            }
                            catch (Exception ee) { CustomMessageBox.Show(ee.Message); } // silent fail on bad entry
                            
                        }
                    }
                }
                catch (Exception ex) { CustomMessageBox.Show("无效的参数: " + ex.ToString()); } // bad config file
                foreach (var camera in camerainfos.Values)
                {
                    if (!cameras.Contains(camera.name))
                        cameras.Add(camera.name);
                }
            }
        }
    }
}