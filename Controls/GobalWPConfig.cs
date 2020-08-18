using VPS.Grid;
using VPS.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace VPS.Controls
{
    public partial class GobalWPConfig : Form
    {
        public camerainfo GetCameraInfo
        {
            get
            {
                return new camerainfo()
                {
                    name = CMB_camera.TextContent,
                    focallen = Convert.ToSingle(CameraFocus.TextContent),
                    imageheight = Convert.ToSingle(ImageHeight.TextContent),
                    imagewidth = Convert.ToSingle(ImageWidth.TextContent),
                    sensorheight = Convert.ToSingle(CameraSensorHeight.TextContent),
                    sensorwidth = Convert.ToSingle(CameraSensorWidth.TextContent)
                };
            }
            set
            {
                CMB_camera.TextContent = value.name;
                CameraFocus.TextContent = value.focallen.ToString("0.00");
                ImageHeight.TextContent = value.imageheight.ToString();
                ImageWidth.TextContent = value.imagewidth.ToString();
                CameraSensorHeight.TextContent = value.sensorheight.ToString("0.00");
                CameraSensorWidth.TextContent = value.sensorwidth.ToString("0.00");
            }
        }

        public float[] GetOverlay
        {
            get
            {
                return new float[] {
                    Convert.ToSingle(CourseOverlap.TextContent),
                    Convert.ToSingle(SideOverlap.TextContent)
                };
            }
            set
            {
                CourseOverlap.TextContent = value[0].ToString();
                SideOverlap.TextContent = value[1].ToString();
            }
        }

        public int GetAltitude
        {
            get
            {
                return Convert.ToInt32(this.RelativeAltitude.TextContent);
            }
            set
            {
                this.RelativeAltitude.TextContent = value.ToString();
            }
        }

        public float[] GetDist
        {
            get
            {
                return new float[] {
                    Convert.ToSingle(Dy.TextContent),
                    Convert.ToSingle(Bx.TextContent)
                };
            }
            set
            {
                Dy.TextContent = value[0].ToString("0.00");
                Bx.TextContent = value[1].ToString("0.00");
            }
        }

        public bool GetCameraHeadTop
        {
            get
            {
                return this.CameraTopHead.TextContent == "横放";
            }
            set
            {
                if (value)
                    this.CameraTopHead.TextContent = "横放";
                else
                    this.CameraTopHead.TextContent = "纵放";
            }
        }

        public GobalWPConfig()
        {
            InitializeComponent();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            xmlcamera(false, Settings.GetRunningDirectory() + "camerasBuiltin.xml");
            xmlcamera(false, Settings.GetUserDataDirectory() + "cameras.xml");
            SetPresetScale();
            SetCameraTop();

            this.CMB_camera.ChangeSelected += CameraChange;
            this.CameraFocus.ChangeText += FocusChange;
            this.PresetScale.ChangeSelected += PresetScaleChange;
            this.GSD.ChangeText += GSDChange;
            this.RelativeAltitude.ChangeText += RelativeAltitudeChange;
            this.CourseOverlap.ChangeText += CourseOverlapChange;
            this.SideOverlap.ChangeText += SideOverlapChange;
            this.CameraTopHead.ChangeSelected += CamereTopHeadChange;

            this.returnButton1.OnOK += OnOk;
            this.returnButton1.OnCancel += OnCancel;
        }


        private void OnOk()
        {
            this.Close();
        }


        private void OnCancel()
        {
            this.Close();
        }

        Dictionary<string, camerainfo> cameras = new Dictionary<string, camerainfo>();

        private void CameraChange()
        {
            try
            {
                string selectedCamera = this.CMB_camera.TextContent;
                var cameraInfo = cameras[selectedCamera];
                this.ImageWidth.TextContent = cameraInfo.imagewidth.ToString();
                this.ImageHeight.TextContent = cameraInfo.imageheight.ToString();
                this.CameraSensorWidth.TextContent = cameraInfo.sensorwidth.ToString();
                this.CameraSensorHeight.TextContent = cameraInfo.sensorheight.ToString();
                this.CameraFocus.TextContent = cameraInfo.focallen.ToString();
                CalculRelativeAltitude();
                CalculBx();
                CalculDy();
            }
            catch (Exception ex) { }
        }

        private void CamereTopHeadChange()
        {
            CalculBx();
            CalculDy();
        }

        private void FocusChange()
        {
            CalculRelativeAltitude();
            CalculBx();
            CalculDy();
        }

        private void PresetScaleChange()
        {
            CalculGSDFromScale();
            CalculRelativeAltitude();
            CalculBx();
            CalculDy();
        }

        private void GSDChange()
        {
            CalculRelativeAltitude();
            CalculBx();
            CalculDy();
        }

        private void RelativeAltitudeChange()
        {
            CalculGSD();
            CalculBx();
            CalculDy();
        }

        private void CourseOverlapChange()
        {
            CalculBx();
        }

        private void SideOverlapChange()
        {
            CalculDy();
        }

        private void CalculGSDFromScale()
        {
            if (!string.IsNullOrEmpty(PresetScale.TextContent))
            {
                string[] data = PresetScale.TextContent.Split(':');
                float gsd = System.Convert.ToSingle(data[1]) / (System.Convert.ToSingle(data[0]) * 10000) * 0.8f;
                this.GSD.TextContent = gsd.ToString("0.000");
            }
        }

        private void CalculRelativeAltitude()
        {
            if (!string.IsNullOrEmpty(GSD.TextContent) &&
                !string.IsNullOrEmpty(CameraFocus.TextContent))
            {
                float gsd = System.Convert.ToSingle(this.GSD.TextContent);
                float f = System.Convert.ToSingle(this.CameraFocus.TextContent);
                float a = System.Convert.ToSingle(this.CameraSensorWidth.TextContent) /
                    System.Convert.ToSingle(this.ImageWidth.TextContent);

                int ra = (int)(f * gsd / a);

                this.RelativeAltitude.TextContent = ra.ToString();
            }
        }

        public void CalculGSD()
        {
            if (!string.IsNullOrEmpty(RelativeAltitude.TextContent) &&
                !string.IsNullOrEmpty(CameraFocus.TextContent))
            {
                int ra = System.Convert.ToInt32(this.RelativeAltitude.TextContent);
                float f = System.Convert.ToSingle(this.CameraFocus.TextContent);
                float a = System.Convert.ToSingle(this.CameraSensorWidth.TextContent) /
                    System.Convert.ToSingle(this.ImageWidth.TextContent);

                float gsd = (ra * a / f);

                this.GSD.TextContent = gsd.ToString("0.000");
            }
        }

        private void CalculBx()
        {
            if (!string.IsNullOrEmpty(CourseOverlap.TextContent) &&
                !string.IsNullOrEmpty(CameraFocus.TextContent) &&
                !string.IsNullOrEmpty(RelativeAltitude.TextContent))
            {
                if (!string.IsNullOrEmpty(CameraSensorHeight.TextContent))
                {
                    float flyalt = (float)CurrentState.fromDistDisplayUnit(System.Convert.ToSingle(RelativeAltitude.TextContent));
                    double viewwidth = 0, viewheight = 0;
                    getFOV(flyalt, ref viewwidth, ref viewheight);
                    if (CameraTopHead.TextContent == "纵放")
                    {
                        double bx = (1 - System.Convert.ToSingle(CourseOverlap.TextContent) / 100) * viewwidth;
                        this.Bx.TextContent = bx.ToString("0.00");
                    }
                    else
                    {
                        double bx = (1 - System.Convert.ToSingle(CourseOverlap.TextContent) / 100) * viewheight;
                        this.Bx.TextContent = bx.ToString("0.00");
                    }
                }
            }
        }

        private void CalculDy()
        {
            if (!string.IsNullOrEmpty(SideOverlap.TextContent) &&
                !string.IsNullOrEmpty(CameraFocus.TextContent) &&
                !string.IsNullOrEmpty(RelativeAltitude.TextContent))
            {
                if (!string.IsNullOrEmpty(CameraSensorWidth.TextContent))
                {
                    float flyalt = (float)CurrentState.fromDistDisplayUnit(System.Convert.ToSingle(RelativeAltitude.TextContent));
                    double viewwidth = 0, viewheight = 0;
                    getFOV(flyalt, ref viewwidth, ref viewheight);
                    if (CameraTopHead.TextContent == "纵放")
                    {
                        double dy = (1 - System.Convert.ToSingle(SideOverlap.TextContent) / 100) * viewheight;
                        this.Dy.TextContent = dy.ToString("0.00");
                    }
                    else
                    {
                        double dy = (1 - System.Convert.ToSingle(SideOverlap.TextContent) / 100) * viewwidth;
                        this.Dy.TextContent = dy.ToString("0.00");
                    }
                }
            }
        }

        private void xmlcamera(bool write, string filename)
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

                    foreach (string key in cameras.Keys)
                    {
                        try
                        {
                            if (key == "")
                                continue;
                            xmlwriter.WriteStartElement("Camera");
                            xmlwriter.WriteElementString("name", cameras[key].name);
                            xmlwriter.WriteElementString("flen", cameras[key].focallen.ToString(new System.Globalization.CultureInfo("en-US")));
                            xmlwriter.WriteElementString("imgh", cameras[key].imageheight.ToString(new System.Globalization.CultureInfo("en-US")));
                            xmlwriter.WriteElementString("imgw", cameras[key].imagewidth.ToString(new System.Globalization.CultureInfo("en-US")));
                            xmlwriter.WriteElementString("senh", cameras[key].sensorheight.ToString(new System.Globalization.CultureInfo("en-US")));
                            xmlwriter.WriteElementString("senw", cameras[key].sensorwidth.ToString(new System.Globalization.CultureInfo("en-US")));
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
                                                        camera.imagewidth = float.Parse(xmlreader.ReadString(), new System.Globalization.CultureInfo("en-US"));
                                                        break;
                                                    case "imgh":
                                                        camera.imageheight = float.Parse(xmlreader.ReadString(), new System.Globalization.CultureInfo("en-US"));
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
                                                        cameras[camera.name] = camera;
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
                            catch (Exception ee) { Console.WriteLine(ee.Message); } // silent fail on bad entry
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine("Bad Camera File: " + ex.ToString()); } // bad config file

                // populate list
                foreach (var camera in cameras.Values)
                {
                    if (!CMB_camera.Contains(camera.name))
                    {
                        CMB_camera.Add(camera.name);
                    }
                }
            }
        }

        

        private void SetPresetScale()
        {
            if (!PresetScale.Contains("1:500"))
                PresetScale.Add("1:500");
            if (!PresetScale.Contains("1:1000"))
                PresetScale.Add("1:1000");
            if (!PresetScale.Contains("1:2000"))
                PresetScale.Add("1:2000");
            if (!PresetScale.Contains("1:5000"))
                PresetScale.Add("1:5000");
            if (!PresetScale.Contains("1:10000"))
                PresetScale.Add("1:10000");
            if (!PresetScale.Contains("1:20000"))
                PresetScale.Add("1:20000");
            PresetScale.TextContent = "1:500";
        }

        private void SetCameraTop()
        {
            if (!CameraTopHead.Contains("横放"))
                CameraTopHead.Add("横放");
            if (!CameraTopHead.Contains("纵放"))
                CameraTopHead.Add("纵放");
            CameraTopHead.TextContent = "纵放";
        }

        //void doCalc()
        //{
        //    try
        //    {
        //        // entered values
        //        float flyalt = (float)CurrentState.fromDistDisplayUnit(System.Convert.ToSingle(RelativeAltitude.TextString));
        //        int imagewidth = int.Parse(ImageWidth.TextString);
        //        int imageheight = int.Parse(ImageHeight.TextString);

        //        float overlap = float.Parse(CourseOverlap.TextString);
        //        float sidelap = float.Parse(SideOverlap.TextString);

        //        double viewwidth = 0;
        //        double viewheight = 0;

        //        getFOV(flyalt, ref viewwidth, ref viewheight);

        //        TXT_fovH.Text = viewwidth.ToString("#.#");
        //        TXT_fovV.Text = viewheight.ToString("#.#");
        //        // Imperial
        //        feet_fovH = (viewwidth * 3.2808399f).ToString("#.#");
        //        feet_fovV = (viewheight * 3.2808399f).ToString("#.#");

        //        //    mm  / pixels * 100
        //        striing TXT_cmpixel = ((viewheight / imageheight) * 100).ToString("0.00");
        //        // Imperial
        //        inchpixel = (((viewheight / imageheight) * 100) * 0.393701).ToString("0.00 inches");
        //    }
        //    catch { return; }
        //}

        void getFOV(double flyalt, ref double fovh, ref double fovv)
        {
            double focallen = double.Parse(CameraFocus.TextContent);
            double sensorwidth = double.Parse(CameraSensorWidth.TextContent);
            double sensorheight = double.Parse(CameraSensorHeight.TextContent);

            // scale      mm / mm
            double flscale = (1000 * flyalt) / focallen;

            //   mm * mm / 1000
            double viewwidth = (sensorwidth * flscale / 1000);
            double viewheight = (sensorheight * flscale / 1000);

            float fovh1 = (float)(Math.Atan(sensorwidth / (2 * focallen)) * rad2deg * 2);
            float fovv1 = (float)(Math.Atan(sensorheight / (2 * focallen)) * rad2deg * 2);

            fovh = viewwidth;
            fovv = viewheight;
        }

        const double rad2deg = (180 / Math.PI);
        const double deg2rad = (1.0 / rad2deg);
    }
}
