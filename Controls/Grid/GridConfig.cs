using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VPS.Grid;
using VPS.Plugin;
using VPS.Utilities;
using System.IO;
using VPS.Maps;
using GMap.NET;
using System.Threading;

namespace VPS.Controls.Grid
{
    public partial class GridConfig : UserControl
    {
        public camerainfo GetCameraInfo
        {
            get
            {
                return new camerainfo()
                {
                    name = this.CMB_camera.Text,
                    focallen = (float)this.NUM_focallength.Value,
                    imageheight = (int)this.TXT_imgheight.Value,
                    imagewidth = (int)this.TXT_imgwidth.Value,
                    sensorheight = (float)this.TXT_sensheight.Value,
                    sensorwidth = (float)this.TXT_senswidth.Value
                };
            }
            set
            {
                CMB_camera.Text = (value.name);
                NUM_focallength.Value = value.focallen;
                TXT_imgheight.Value = value.imageheight;
                TXT_imgwidth.Value = value.imagewidth;
                TXT_sensheight.Value = value.sensorheight;
                TXT_senswidth.Value = value.sensorwidth;
            }
        }

        //private GridPlugin plugin;

        void loadsettings()
        {
            if (Settings.Instance.ContainsKey("grid_camera"))
            {
                loadsetting("grid_camera", CMB_camera);
                loadsetting("grid_camdir", CHK_camdirection);
                loadsetting("grid_camerainfo", ShowCameraInfo);


                loadsetting("grid_alt", NUM_altitude);
                loadsetting("grid_angle", NUM_angle);
                loadsetting("grid_startfrom", CMB_startfrom);
                //loadsetting("grid_usespeed", CHK_usespeed);
                //loadsetting("grid_speed", NUM_UpDownFlySpeed);
                //loadsetting("grid_autotakeoff", CHK_toandland);
                //loadsetting("grid_autotakeoff_RTL", CHK_toandland_RTL);

                loadsetting("grid_dist", NUM_Distance);
                loadsetting("grid_spacing", NUM_spacing);
                loadsetting("grid_overlap", num_overlap);
                loadsetting("grid_sidelap", num_sidelap);

                loadsetting("grid_advanced", ShowAdvanceOptions);

                loadsetting("grid_overshoot1", NUM_overshoot);
                loadsetting("grid_overshoot2", NUM_overshoot2);
                loadsetting("grid_leadin", NUM_leadin);
                loadsetting("grid_min_lane_separation", NUM_Lane_Dist);


                loadsetting("grid_crossgrid", chk_crossgrid);
                loadsetting("grid_spiral", chk_spiral);
                loadsetting("grid_corridor", chk_Corridor);
                loadsetting("grid_corriidorwidth", num_corridorwidth);
            }
        }

        void loadsetting(string key, Control item)
        {
            // soft fail on bad param
            try
            {
                if (Settings.Instance.ContainsKey(key))
                {
                    if (item is DevComponents.Editors.DoubleInput)
                    {
                        ((DevComponents.Editors.DoubleInput)item).Value = double.Parse(Settings.Instance[key].ToString());
                    }
                    if (item is DevComponents.Editors.IntegerInput)
                    {
                        ((DevComponents.Editors.IntegerInput)item).Value = int.Parse(Settings.Instance[key].ToString());
                    }
                    else if (item is DevComponents.DotNetBar.Controls.ComboBoxEx)
                    {
                        ((DevComponents.DotNetBar.Controls.ComboBoxEx)item).Text = Settings.Instance[key].ToString();
                    }
                    else if (item is DevComponents.DotNetBar.Controls.CheckBoxX)
                    {
                        ((DevComponents.DotNetBar.Controls.CheckBoxX)item).Checked = bool.Parse(Settings.Instance[key].ToString());
                    }
                }
            }
            catch { }
        }

        void savesettings()
        {
            //相机设置
            Settings.Instance["grid_camera"] = CMB_camera.Text;
            Settings.Instance["grid_camdir"] = CHK_camdirection.Checked.ToString();
            Settings.Instance["grid_camerainfo"] = ShowCameraInfo.Checked.ToString();

            //摄影设置
            //航飞设置
            Settings.Instance["grid_alt"] = NUM_altitude.Value.ToString();
            Settings.Instance["grid_startfrom"] = CMB_startfrom.Text;
            Settings.Instance["grid_angle"] = NUM_angle.Value.ToString();


            //Settings.Instance["grid_usespeed"] = CHK_usespeed.Checked.ToString();
            //航信设置
            Settings.Instance["grid_dist"] = NUM_Distance.Value.ToString();
            Settings.Instance["grid_spacing"] = NUM_spacing.Value.ToString();
            Settings.Instance["grid_overlap"] = num_overlap.Value.ToString();
            Settings.Instance["grid_sidelap"] = num_sidelap.Value.ToString();

            Settings.Instance["grid_advanced"] = ShowAdvanceOptions.Checked.ToString();

            Settings.Instance["grid_overshoot1"] = NUM_overshoot.Value.ToString();
            Settings.Instance["grid_overshoot2"] = NUM_overshoot2.Value.ToString();
            Settings.Instance["grid_leadin"] = NUM_leadin.Value.ToString();

            Settings.Instance["grid_min_lane_separation"] = NUM_Lane_Dist.Value.ToString();




            //Settings.Instance["grid_autotakeoff"] = CHK_toandland.Checked.ToString();
            //Settings.Instance["grid_autotakeoff_RTL"] = CHK_toandland_RTL.Checked.ToString();

            //Settings.Instance["grid_internals"] = CHK_internals.Checked.ToString();
            //Settings.Instance["grid_footprints"] = CHK_footprints.Checked.ToString();
            Settings.Instance["grid_crossgrid"] = chk_crossgrid.Checked.ToString();
            Settings.Instance["grid_spiral"] = chk_spiral.Checked.ToString();
            Settings.Instance["grid_corridor"] = chk_Corridor.Checked.ToString();
            Settings.Instance["grid_corriidorwidth"] = num_corridorwidth.Value.ToString();

            //Settings.Instance["grid_trigdist"] = rad_trigdist.Checked.ToString();

            //Settings.Instance["grid_digicam"] = rad_digicam.Checked.ToString();
            //Settings.Instance["grid_repeatservo"] = rad_repeatservo.Checked.ToString();
            //Settings.Instance["grid_breakstopstart"] = chk_stopstart.Checked.ToString();

            // Copter Settings
            //Settings.Instance["grid_copter_spline"] = chk_spline.Checked.ToString();
            //Settings.Instance["grid_copter_delay"] = NUM_copter_delay.Value.ToString();
            //Settings.Instance["grid_copter_headinghold_chk"] = CHK_copter_headinghold.Checked.ToString();

            // Plane Settings

        }

        bool loading = false;
        public void LoadGrid()
        {
            System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(NewGridData));

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "*.grid|*.grid";
                ofd.ShowDialog();

                if (File.Exists(ofd.FileName))
                {
                    using (StreamReader sr = new StreamReader(ofd.FileName))
                    {
                        var test = (NewGridData)reader.Deserialize(sr);

                        loading = true;
                        loadgriddata(test);
                        loading = false;
                    }
                }
            }
        }

        public void SaveGrid()
        {
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(NewGridData));

            var griddata = savegriddata();

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "*.grid|*.grid";
                var result = sfd.ShowDialog();

                if (sfd.FileName != "" && result == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName))
                    {
                        writer.Serialize(sw, griddata);
                    }
                }
            }
        }
        bool loadedfromfile = false;
        void loadgriddata(NewGridData griddata)
        {
            list = griddata.poly;

            CMB_camera.Text = griddata.camera;
            NUM_altitude.Value = griddata.alt;
            NUM_angle.Value = griddata.angle;
            LockAngle.Checked = griddata.lockangle;
            CHK_camdirection.Checked = griddata.camdir;


            NUM_Distance.Value = griddata.dist;
            NUM_overshoot.Value = griddata.overshoot1;
            NUM_overshoot2.Value = griddata.overshoot2;
            NUM_leadin.Value = griddata.leadin;
            CMB_startfrom.Text = griddata.startfrom;
            num_overlap.Value = griddata.overlap;
            num_sidelap.Value = griddata.sidelap;
            NUM_spacing.Value = griddata.spacing;
            NUM_Lane_Dist.Value = griddata.minlaneseparation;


            chk_crossgrid.Checked = griddata.crossgrid;
            chk_spiral.Checked = griddata.spiral;
            chk_Corridor.Checked = griddata.corridor;
            num_corridorwidth.Value = griddata.corriidorwidth;


            loadedfromfile = true;
        }

        NewGridData savegriddata()
        {
            NewGridData griddata = new NewGridData();

            griddata.poly = list;

            griddata.camera = CMB_camera.Text;
            griddata.alt = NUM_altitude.Value;
            griddata.angle = NUM_angle.Value;
            griddata.lockangle = LockAngle.Checked;
            griddata.camdir = CHK_camdirection.Checked;

            griddata.advanced = ShowAdvanceOptions.Checked;

            griddata.dist = NUM_Distance.Value;
            griddata.overshoot1 = NUM_overshoot.Value;
            griddata.overshoot2 = NUM_overshoot2.Value;
            griddata.leadin = NUM_leadin.Value;
            griddata.startfrom = CMB_startfrom.Text;
            griddata.overlap = num_overlap.Value;
            griddata.sidelap = num_sidelap.Value;
            griddata.spacing = NUM_spacing.Value;
            griddata.minlaneseparation = NUM_Lane_Dist.Value;

            griddata.crossgrid = chk_crossgrid.Checked;
            griddata.spiral = chk_spiral.Checked;
            griddata.corridor = chk_Corridor.Checked;
            griddata.corriidorwidth = num_corridorwidth.Value;


            return griddata;
        }
        public delegate void ListChangedEventArgs(List<PointLatLngAlt> wpList);
        public ListChangedEventArgs WPListChangeHandle;
        List<PointLatLngAlt> list = new List<PointLatLngAlt>();
        List<PointLatLngAlt> grid = new List<PointLatLngAlt>();

        public void SetPolygonList(List<PointLatLngAlt> polygons)
        {
            list = polygons;
            domainUpDown2_ValueChanged(null, null);
        }

        public List<PointLatLngAlt> GetWPList()
        {
            List<PointLatLngAlt> wpList = grid;
            for(int i = 0;i< wpList.Count; i++)
            {
                wpList[i].Tag = "WAYPOINT";
                wpList[i].Tag2 = "Relative";
            }
            return wpList;
        }


        public void SaveSetting()
        {
            savesettings();
        }


        private void domainUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (loading)
                return;
            if (!editable)
                return;

            if (CMB_camera.Text != "")
            {
                editable = false;
                doCalc();
                editable = true;
            }

            if (list.Count <= 0)
                return;

            // new grid system test
            ThreadPool.QueueUserWorkItem(new WaitCallback(delayGrid), lockObj);
        }

        private void domainUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (loading)
                return;
            if (!editable)
                return;

            if (CMB_camera.Text != "")
            {
                editable = false;
                doCalc();
                editable = true;
            }

            if (list.Count <= 0)
                return;

            // new grid system test
            lock (lockObj2)
            {
                gridGrenate = true;
                autoGrid();
                gridGrenate = false;
            }
        }

        static object lockObj = new object();
        static object lockObj2 = new object();
        static long alterTime;
        static bool gridWait = false;
        static bool gridGrenate = false;
        static private void delayGrid(object obj)
        {
            alterTime = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000;
            lock (lockObj) {
                if (gridWait || gridGrenate)
                {
                    return;
                }
                else
                {
                    gridWait = true;
                }
            }
            while (true) {
                if ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000 - alterTime > 500)
                {
                    lock (lockObj2)
                    {
                        gridGrenate = true;
                        autoGrid();
                        gridGrenate = false;
                        gridWait = false;
                    }
                    return;
                }
                else
                {
                    Thread.SpinWait(100);
                }
            }
        }

        private static async void autoGrid()
        {
            bool ch_Corridor = (bool)ReadControlMainThread(instance.chk_Corridor);
            bool chk_spiral = (bool)ReadControlMainThread(instance.chk_spiral);
            bool chk_crossgrid = (bool)ReadControlMainThread(instance.chk_crossgrid);

            double altitude = (int)ReadControlMainThread(instance.NUM_altitude);
            double distance = (double)ReadControlMainThread(instance.NUM_Distance);
            double spacing = (double)ReadControlMainThread(instance.NUM_spacing);
            double angle = (double)ReadControlMainThread(instance.NUM_angle);
            double overshoot = (int)ReadControlMainThread(instance.NUM_overshoot);
            double overshoot2 = (int)ReadControlMainThread(instance.NUM_overshoot2);
            string startfrom = (string)ReadControlMainThread(instance.CMB_startfrom);
            float num_lane_dist = (int)ReadControlMainThread(instance.NUM_Lane_Dist);
            float num_corridorwidth = (int)ReadControlMainThread(instance.num_corridorwidth);
            float num_landin = (int)ReadControlMainThread(instance.NUM_leadin);
            List<PointLatLngAlt> wp = new List<PointLatLngAlt>();
            if (ch_Corridor)
            {
                wp = await Utilities.Grid.CreateCorridorAsync(
                    instance.list, CurrentState.fromDistDisplayUnit(altitude),
                    distance, spacing, angle,
                    overshoot, overshoot2,
                    (Utilities.Grid.StartPosition)Enum.Parse(typeof(Utilities.Grid.StartPosition), startfrom), false,
                    num_lane_dist, num_corridorwidth, num_landin).ConfigureAwait(true);
            }
            else if (chk_spiral)
            {
                wp = await Utilities.Grid.CreateRotaryAsync(
                    instance.list, CurrentState.fromDistDisplayUnit(altitude),
                    distance, spacing, angle,
                    overshoot, (double)instance.NUM_overshoot2.Value,
                    (Utilities.Grid.StartPosition)Enum.Parse(typeof(Utilities.Grid.StartPosition), startfrom), false,
                    num_lane_dist, num_landin, MainV2.comPort.MAV.cs.PlannedHomeLocation).ConfigureAwait(true);
            }
            else
            {
                wp = await Utilities.Grid.CreateGridAsync(
                    instance.list, CurrentState.fromDistDisplayUnit(altitude),
                    distance, spacing, angle,
                    overshoot, overshoot2,
                    (Utilities.Grid.StartPosition)Enum.Parse(typeof(Utilities.Grid.StartPosition), startfrom), false,
                    num_lane_dist, num_landin, MainV2.comPort.MAV.cs.PlannedHomeLocation).ConfigureAwait(true);
            }

            if (wp.Count == 0)
            {
                instance.grid.Clear();
                instance.WPListChangeHandle?.Invoke(instance.GetWPList());
                return;
            }

            if (chk_crossgrid)
            {
                // add crossover
                Utilities.Grid.StartPointLatLngAlt = instance.grid[instance.grid.Count - 1];

                wp.AddRange(await Utilities.Grid.CreateGridAsync(
                    instance.list, CurrentState.fromDistDisplayUnit(altitude),
                    distance, spacing, angle + 90.0,
                    overshoot, overshoot2,
                    Utilities.Grid.StartPosition.Point, false,
                    num_lane_dist, num_landin, MainV2.comPort.MAV.cs.PlannedHomeLocation).ConfigureAwait(true));
            }

            if (wp.Count == 0)
            {
                instance.grid.Clear();
                instance.WPListChangeHandle?.Invoke(instance.GetWPList());
                return;
            }

            int strips = 0;
            int images = 0;
            int a = 0;

            instance.grid.Clear();
            PointLatLngAlt last = null;
            foreach (var item in wp)
            {
                if (item.Tag == "M")
                {
                    images++;
                    a++;
                }
                else
                {
                    if (item.Tag != "SM" && item.Tag != "ME")
                        strips++;
                    if (last != null)
                    {
                        if (last.Lat == item.Lat && last.Lng == item.Lng && last.Alt == item.Alt)
                        {
                            last = item;
                            continue;
                        }

                    }
                    instance.grid.Add(item);
                    last = item;
                    a++;
                }


            }
            instance.WPListChangeHandle?.Invoke(instance.GetWPList());
        }

        private delegate object ReadControlInMainThreadHandle(Control control);

        private static object ReadControlMainThread(Control control)
        {
            if (control.InvokeRequired)
            {
                ReadControlInMainThreadHandle inThread = new ReadControlInMainThreadHandle(ReadControlMainThread);
                IAsyncResult iar = control.BeginInvoke(inThread, new object[] { control });
                return (object)control.EndInvoke(iar);
            }
            else
            {
                if (control is DevComponents.Editors.DoubleInput)
                    return ((DevComponents.Editors.DoubleInput)control).Value;
                if (control is DevComponents.Editors.IntegerInput)
                    return ((DevComponents.Editors.IntegerInput)control).Value;
                if (control is DevComponents.DotNetBar.Controls.CheckBoxX)
                    return ((DevComponents.DotNetBar.Controls.CheckBoxX)control).Checked;
                if (control is DevComponents.DotNetBar.Controls.ComboBoxEx)
                    return ((DevComponents.DotNetBar.Controls.ComboBoxEx)control).Text;
                return null;
            }
        }


        // Variables
        const double rad2deg = (180 / Math.PI);
        const double deg2rad = (1.0 / rad2deg);

        void getFOV(double flyalt, ref double fovh, ref double fovv)
        {
            double focallen = (double)NUM_focallength.Value;
            double sensorwidth = double.Parse(TXT_senswidth.Text);
            double sensorheight = double.Parse(TXT_sensheight.Text);

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

        void doCalc()
        {

                // entered values
                float flyalt = (float)CurrentState.fromDistDisplayUnit((float)NUM_altitude.Value);
                int imagewidth = TXT_imgwidth.Value;
                int imageheight = TXT_imgheight.Value;

                double overlap = num_overlap.Value;
                double sidelap = num_sidelap.Value;

                double viewwidth = 0;
                double viewheight = 0;

                getFOV(flyalt, ref viewwidth, ref viewheight);

                TXT_fovH.Value = viewwidth;
                TXT_fovV.Value = viewheight;
                // Imperial
                //feet_fovH = (viewwidth * 3.2808399f).ToString("#.#");
                //feet_fovV = (viewheight * 3.2808399f).ToString("#.#");

                //    mm  / pixels * 100
                TXT_cmpixel.Value = ((viewheight / imageheight) * 100);
                // Imperial
                //inchpixel = (((viewheight / imageheight) * 100) * 0.393701).ToString("0.00 inches");

                if (CHK_camdirection.Checked)
                {
                    NUM_spacing.Value = (double)((1 - (overlap / 100.0f)) * viewheight);
                    NUM_Distance.Value = (double)((1 - (sidelap / 100.0f)) * viewwidth);
                }
                else
                {
                    NUM_spacing.Value = (double)((1 - (overlap / 100.0f)) * viewwidth);
                    NUM_Distance.Value = (double)((1 - (sidelap / 100.0f)) * viewheight);
                }

            if (!isLockAngle)
            {
                NUM_angle.Value = getAngleOfLongestSide(list);
            }

        }

        public static GridConfig instance = null;
        public GridConfig()
        {
            InitializeComponent();
            instance = this;
            var cameras = camerainfo.GetCameras();
            for (int i = 0; i < cameras.Count; i++)
            {
                this.CMB_camera.Items.Add(cameras[i]);
            }
            CMB_startfrom.DataSource = Enum.GetNames(typeof(Utilities.Grid.StartPosition));
            CMB_startfrom.SelectedIndex = 0;

            editable = true;

            //defaultAngleTooltip.SetSuperTooltip(DefaultAngle, defaultAngleTooltip.DefaultTooltipSettings);
            // set and angle that is good
            //NUM_angle.Value = (int)((getAngleOfLongestSide(list) + 360) % 360);
        }

        ~GridConfig()
        {
            savesettings();
        }


        private void ShowCameraInfo_CheckedChanged(object sender, EventArgs e)
        {
            this.CameraDetailBox.Visible = this.ShowCameraInfo.Checked;
        }

        private void ShowAdvanceOptions_CheckedChanged(object sender, EventArgs e)
        {
            this.AdvanceAirLineBox.Visible = this.ShowAdvanceOptions.Checked;
        }

        bool editable = false;
        private void NUM_Distance_ValueChanged(object sender, EventArgs e)
        {
            domainUpDown1_ValueChanged(sender, e);
        }

        private void num_overlap_ValueChanged(object sender, EventArgs e)
        {
            domainUpDown1_ValueChanged(sender, e);
        }

        private void num_sidelap_ValueChanged(object sender, EventArgs e)
        {
            domainUpDown1_ValueChanged(sender, e);
        }

        private void NUM_spacing_ValueChanged(object sender, EventArgs e)
        {

            domainUpDown1_ValueChanged(sender, e);

        }

        private void NUM_angle_ValueChanged(object sender, EventArgs e)
        {

            domainUpDown1_ValueChanged(sender, e);

        }

        private void NUM_overshoot_ValueChanged(object sender, EventArgs e)
        {

            domainUpDown1_ValueChanged(sender, e);
        }

        private void NUM_Lane_Dist_ValueChanged(object sender, EventArgs e)
        {
            domainUpDown1_ValueChanged(sender, e);
        }

        private void NUM_overshoot2_ValueChanged(object sender, EventArgs e)
        {

            domainUpDown1_ValueChanged(sender, e);

        }

        private void CMB_startfrom_SelectedIndexChanged(object sender, EventArgs e)
        {

            domainUpDown2_ValueChanged(sender, e);

        }

        private void NUM_leadin_ValueChanged(object sender, EventArgs e)
        {

            domainUpDown1_ValueChanged(sender, e);

        }

        private void CMB_camera_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCameraInfo = camerainfo.GetCameraInfos(CMB_camera.Text);
            domainUpDown1_ValueChanged(sender, e);
        }

        private void CMB_camera_SelectedValueChanged(object sender, EventArgs e)
        {
            GetCameraInfo = camerainfo.GetCameraInfos(CMB_camera.Text);
            domainUpDown1_ValueChanged(sender, e);
        }

        private void NUM_focallength_ValueChanged(object sender, EventArgs e)
        {
            domainUpDown1_ValueChanged(sender, e);
        }

        private void GridConfig_Load(object sender, EventArgs e)
        {
            loading = true;
            if (!loadedfromfile)
                loadsettings();
            // setup state before settings load

            loading = false;
            editable = true;
            domainUpDown2_ValueChanged(this, null);
        }

        private void Accept_Click(object sender, EventArgs e)
        {
            savesettings();
        }

        private void Default_Click(object sender, EventArgs e)
        {
            loading = true;
            loadsettings();
            loading = false;
            domainUpDown2_ValueChanged(sender, e);
        }

        private void chk_crossgrid_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_crossgrid.Checked)
            {
                chk_Corridor.Checked = chk_spiral.Checked = false;
            }
            domainUpDown2_ValueChanged(sender, e);
        }

        private void chk_Corridor_CheckedChanged(object sender, EventArgs e)
        {
            CorridorInfoBox.Visible = chk_Corridor.Checked;
            if (chk_Corridor.Checked)
            {
                chk_crossgrid.Checked = chk_spiral.Checked = false;
            }
            domainUpDown2_ValueChanged(sender, e);
        }

        private void chk_spiral_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_spiral.Checked)
            {
                chk_Corridor.Checked = chk_crossgrid.Checked = false;
            }
            domainUpDown2_ValueChanged(sender, e);
        }

        private void NUM_altitude_ValueChanged(object sender, EventArgs e)
        {
            domainUpDown1_ValueChanged(sender, e);
        }

        private void lbl_gndelev_ValueChanged(object sender, EventArgs e)
        {
            domainUpDown1_ValueChanged(sender, e);
        }

        private void num_corridorwidth_ValueChanged(object sender, EventArgs e)
        {
            domainUpDown1_ValueChanged(sender, e);
        }

        private void CHK_camdirection_CheckedChanged(object sender, EventArgs e)
        {
            domainUpDown2_ValueChanged(sender, e);
        }

        private void defaultAngle_Click(object sender, EventArgs e)
        {
            if (!isLockAngle)
            {
                this.NUM_angle.Value = getAngleOfLongestSide(list);
                domainUpDown2_ValueChanged(sender, e);
            }
        }

        private double getAngleOfLongestSide(List<PointLatLngAlt> list)
        {
            if (list.Count == 0)
                return 0;
            double angle = 0;
            double maxdist = 0;
            PointLatLngAlt last = list[list.Count - 1];
            foreach (var item in list)
            {
                if (item.GetDistance(last) > maxdist)
                {
                    angle = item.GetBearing(last);
                    maxdist = item.GetDistance(last);
                }
                last = item;
            }

            return (angle % 360 + 360) % 360;
        }

        bool isLockAngle;
        private void LockAngle_CheckedChanged(object sender, EventArgs e)
        {
            isLockAngle = LockAngle.Checked;
            if (!isLockAngle)
            {
                domainUpDown2_ValueChanged(sender, e);
                NUM_angle.Enabled = true;
                DefaultAngle.Enabled = true;
            }
            else
            {
                NUM_angle.Enabled = false;
                DefaultAngle.Enabled = false;
            }
        }

        private void AddCamera_Click(object sender, EventArgs e)
        {
            using (CustomCamera dlg = new CustomCamera())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var info = dlg.GetCamerainfo();
                    camerainfo.AddCamera(info);


                    if (!CMB_camera.Items.Contains(info.name))
                        CMB_camera.Items.Add(info.name);
                    CMB_camera.SelectedIndex = CMB_camera.Items.IndexOf(info.name);
                }
                
            }
            
        }


    }
}
