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
        public static GridConfig instance = null;

        public GridConfig()
        {
            InitializeComponent();
            instance = this;
            var cameras = CustomData.Grid.camerainfo.GetCameras();
            for (int i = 0; i < cameras.Count; i++)
            {
                this.CMB_Camera.Items.Add(cameras[i]);
            }

            CMB_startfrom.DataSource = Enum.GetNames(typeof(Utilities.Grid.StartPosition));
            CMB_startfrom.SelectedIndex = 0;

            historyChange += HistoryChangeHandle;
        }

        ~GridConfig()
        {
            savesettings();
        }

        #region Load
        private void GridConfig_Load(object sender, EventArgs e)
        {
            StartLoading();

            if (!loadedfromfile)
                loadsettings();
            // setup state before settings load

            EndLoading();

            if (CHK_AutoGeneralWP.Checked)
                domainUpDown1_ValueChanged();
            else
                EnterCalc();
        }
        #endregion

        #region Config

        #region LoadConfig

        #region 加载一个配置信息
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
        #endregion

        #region 加在整个配置信息
        void loadsettings()
        {
            if (Settings.Instance.ContainsKey("grid_camera"))
            {
                loadsetting("grid_camera", CMB_Camera);
                loadsetting("grid_camdir", CHK_camdirection);
                loadsetting("grid_camerainfo", CHK_ShowCameraInfo);


                loadsetting("grid_alt", NUM_altitude);
                loadsetting("grid_angle", num_angle);
                loadsetting("grid_startfrom", CMB_startfrom);
                //loadsetting("grid_usespeed", CHK_usespeed);
                //loadsetting("grid_speed", NUM_UpDownFlySpeed);
                //loadsetting("grid_autotakeoff", CHK_toandland);
                //loadsetting("grid_autotakeoff_RTL", CHK_toandland_RTL);

                loadsetting("grid_dist", Num_Distance);
                loadsetting("grid_spacing", num_spacing);
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
        #endregion

        #endregion

        #region SaveConfig

        #region 接口函数
        private delegate void SaveSettingInThread();

        public void SaveSetting()
        {
            if (this.InvokeRequired)
            {
                SaveSettingInThread inThread = new SaveSettingInThread(SaveSetting);
                this.Invoke(inThread);
            }
            else
            {
                savesettings();
            }
        }
        #endregion

        #region 入口函数
        void savesettings()
        {
            //相机设置
            Settings.Instance["grid_camera"] = CMB_Camera.Text;
            Settings.Instance["grid_camdir"] = CHK_camdirection.Checked.ToString();
            Settings.Instance["grid_camerainfo"] = CHK_ShowCameraInfo.Checked.ToString();

            //摄影设置
            //航飞设置
            Settings.Instance["grid_alt"] = NUM_altitude.Value.ToString();
            Settings.Instance["grid_startfrom"] = CMB_startfrom.Text;
            Settings.Instance["grid_angle"] = num_angle.Value.ToString();


            //Settings.Instance["grid_usespeed"] = CHK_usespeed.Checked.ToString();
            //航信设置
            Settings.Instance["grid_dist"] = Num_Distance.Value.ToString();
            Settings.Instance["grid_spacing"] = num_spacing.Value.ToString();
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
        #endregion

        #endregion

        #region LoadConfig控件响应
        private void DefaultConfig_Click(object sender, EventArgs e)
        {
            StartLoading();

            loadsettings();

            EndLoading();
            if (CHK_AutoGeneralWP.Checked)
                domainUpDown1_ValueChanged();
            else
                EnterCalc();
        }
        #endregion

        #region SaveConfig控件响应
        private void SaveConfig_Click(object sender, EventArgs e)
        {
            savesettings();
        }
        #endregion

        #endregion

        #region Gird文件
        bool loadedfromfile = false;

        #region 加载Grid文件

        #region 入口函数
        public void LoadGrid()
        {
            System.Xml.Serialization.XmlSerializer reader = 
                new System.Xml.Serialization.XmlSerializer(typeof(CustomData.Grid.NewGridData));

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "*.grid|*.grid";
                ofd.ShowDialog();

                if (File.Exists(ofd.FileName))
                {
                    using (StreamReader sr = new StreamReader(ofd.FileName))
                    {
                        var test = (CustomData.Grid.NewGridData)reader.Deserialize(sr);

                        StartLoading();

                        loadgriddata(test);

                        EndLoading();
                    }
                }
            }
        }
        #endregion

        #region 解码函数
        void loadgriddata(CustomData.Grid.NewGridData griddata)
        {
            poly = griddata.poly;

            CMB_Camera.Text = griddata.camera;
            NUM_altitude.Value = griddata.alt;
            num_angle.Value = griddata.angle;
            LockAngle.Checked = griddata.lockangle;
            CHK_camdirection.Checked = griddata.camdir;


            Num_Distance.Value = griddata.dist;
            NUM_overshoot.Value = griddata.overshoot1;
            NUM_overshoot2.Value = griddata.overshoot2;
            NUM_leadin.Value = griddata.leadin;
            CMB_startfrom.Text = griddata.startfrom;
            num_overlap.Value = griddata.overlap;
            num_sidelap.Value = griddata.sidelap;
            num_spacing.Value = griddata.spacing;
            NUM_Lane_Dist.Value = griddata.minlaneseparation;


            chk_crossgrid.Checked = griddata.crossgrid;
            chk_spiral.Checked = griddata.spiral;
            chk_Corridor.Checked = griddata.corridor;
            num_corridorwidth.Value = griddata.corriidorwidth;


            loadedfromfile = true;
        }
        #endregion

        #endregion

        #region 保存Grid文件

        #region 入口函数
        public void SaveGrid()
        {
            System.Xml.Serialization.XmlSerializer writer = 
                new System.Xml.Serialization.XmlSerializer(typeof(CustomData.Grid.NewGridData));

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
        #endregion

        #region 转码函数
        CustomData.Grid.NewGridData savegriddata()
        {
            var griddata = new CustomData.Grid.NewGridData();

            griddata.poly = poly;

            griddata.camera = CMB_Camera.Text;
            griddata.alt = NUM_altitude.Value;
            griddata.angle = num_angle.Value;
            griddata.lockangle = LockAngle.Checked;
            griddata.camdir = CHK_camdirection.Checked;

            griddata.advanced = ShowAdvanceOptions.Checked;

            griddata.dist = Num_Distance.Value;
            griddata.overshoot1 = NUM_overshoot.Value;
            griddata.overshoot2 = NUM_overshoot2.Value;
            griddata.leadin = NUM_leadin.Value;
            griddata.startfrom = CMB_startfrom.Text;
            griddata.overlap = num_overlap.Value;
            griddata.sidelap = num_sidelap.Value;
            griddata.spacing = num_spacing.Value;
            griddata.minlaneseparation = NUM_Lane_Dist.Value;

            griddata.crossgrid = chk_crossgrid.Checked;
            griddata.spiral = chk_spiral.Checked;
            griddata.corridor = chk_Corridor.Checked;
            griddata.corriidorwidth = num_corridorwidth.Value;


            return griddata;
        }
        #endregion

        #endregion

        #endregion

        #region 重要参数
        public delegate void ListChangedHandle(List<PointLatLngAlt> wpList);
        public delegate void IntegerChangeHandler(int integer);
        public delegate void StateChangeHandler();

        #region 航线记录
        List<List<PointLatLngAlt>> history = new List<List<PointLatLngAlt>>();

        public IntegerChangeHandler historyChange;

        #region 添加航线记录
        private void AddHistoryList()
        {
            history.Add(wp);

            historyChange?.Invoke(history.Count);
        }
        #endregion

        #region 回退航线记录
        private void UndoHistoryList()
        {
            if (history.Count > 0)
            {
                int no = history.Count - 1;
                var pop = history[no];
                history.RemoveAt(no);

                SetWPListHandle(pop, false);

                historyChange?.Invoke(history.Count);
            }
        }
        #endregion

        #endregion

        #region 航线记录数验证
        private void HistoryChangeHandle(int count)
        {
            if (count > 0)
                SetControlMainThread(Undo, true);
            else
                SetControlMainThread(Undo, false);
        }
        #endregion

        #region 添加信息提示
        private void SetLockWPToolTips()
        {
            if (wp.Count > 0)
            {
                var tip = new DevComponents.DotNetBar.SuperTooltipInfo();
                tip.HeaderText = "锁定航线";
                tip.FooterText = "";
                tip.BodyText =
                    "行点数: " + wp.Count + '\n' +
                    "起始位置: " + "[ " + 
                    wp[0].Lat.ToString("0.######") + " , " + 
                    wp[0].Lng.ToString("0.######") + " ]" + '\n' +
                    "终止位置: " + "[ " + 
                    wp[wp.Count - 1].Lat.ToString("0.######") + " , " + 
                    wp[wp.Count - 1].Lng.ToString("0.######") + " ]" + '\n' +
                    "航线距离: " + CalcTotalDist(wp).ToString("0.##") + " m" + '\n' +
                    "航摄基线: " + CalcBaseAlt(wp).ToString() + " m";
                tip.Color = DevComponents.DotNetBar.eTooltipColor.Office2003;
                tip.CustomSize = new Size(250, 110);

                this.defaultTooltip.SetSuperTooltip(this.panelEx7, tip);
            }
            else
                this.defaultTooltip.SetSuperTooltip(this.panelEx7, null);
        }
        #endregion

        #region 参数计算
        private int CalcBaseAlt(List<Utilities.PointLatLngAlt> wpList)
        {
            double totalAlt = 0.0;
            double maxA = 0.0;
            double minA = wpList.Count > 0 ?
                Utilities.srtm.getAltitude(wpList[0].Lat, wpList[0].Lng).alt * CurrentState.multiplieralt : 0.0;
            for (int index = 0; index < wpList.Count; index++)
            {
                double terrain = Utilities.srtm.getAltitude(wpList[index].Lat, wpList[index].Lng).alt * CurrentState.multiplieralt;
                totalAlt += terrain;
                if (terrain > maxA)
                    maxA = terrain;
                if (terrain < minA)
                    minA = terrain;
            }
            return (int)(totalAlt / Math.Max(1, wpList.Count));

        }

        private double CalcTotalDist(List<Utilities.PointLatLngAlt> wpList)
        {
            double totalDist = 0.0;
            for (int index = 1; index < wpList.Count; index++)
            {
                totalDist += Math.Sqrt(
                    Math.Pow(wpList[index].GetDistance(wpList[index - 1]), 2) +
                    Math.Pow(wpList[index].Alt - wpList[index - 1].Alt, 2)) *
                    CurrentState.multiplierdist;
            }
            return totalDist;
        }
        #endregion

        #region 航线
        List<PointLatLngAlt> grid = new List<PointLatLngAlt>();
        List<PointLatLngAlt> wp = new List<PointLatLngAlt>();

        #region 设置航线
        public void SetWPListHandle(List<PointLatLngAlt> wpList, bool history = true)
        {
            if (history)
                AddHistoryList();

            if (wpList.Count > 0)
            {
                if (wpList[0].Tag == CustomData.WP.WPCommands.HomeCommand)
                    wpList.RemoveAt(0);
            }

            wp = new List<PointLatLngAlt>(wpList);
            SetLockWPToolTips();

            DataTable set = new DataTable();
            set.Columns.Add("key");
            set.Columns.Add("Value");

            for (int index = 0; index < wpList.Count; index++)
            {
                var row = set.NewRow();
                row["key"] = index;
                row["Value"] = "WP: " + index.ToString();
                set.Rows.Add(row);
            }

            CMB_WPBox.DataSource = set;
            CMB_WPBox.ValueMember = "key";
            CMB_WPBox.DisplayMember = "Value";
        }
        #endregion

        #region 获取航线
        public List<PointLatLngAlt> GetWPList()
        {
            List<PointLatLngAlt> wpList;
            if ((bool)ReadControlMainThread(CHK_AppendWP))
            {
                wpList = new List<PointLatLngAlt>(wp);
                wpList.AddRange(grid);
            }
            else
                wpList = new List<PointLatLngAlt>(grid);

            for (int i = 0; i < wpList.Count; i++)
            {
                wpList[i].Tag = CustomData.WP.WPCommands.DefaultWPCommand;
                wpList[i].Tag2 = CustomData.EnumCollect.AltFrame.Relative;
            }
            return wpList;
        }
        #endregion

        #endregion

        #region 区域
        List<PointLatLngAlt> poly = new List<PointLatLngAlt>();

        #region 设置区域
        public void SetPolygonList()
        {
            if (gridGrenate)
                return;
            List<PointLatLngAlt> polygons = CustomData.WP.WPGlobalData.instance.GetPolyList();
            poly = new List<PointLatLngAlt>(polygons.ToArray());

            DataTable set = new DataTable();
            set.Columns.Add("key");
            set.Columns.Add("Value");

            for (int index = 0; index < polygons.Count; index++)
            {
                var row = set.NewRow();
                row["key"] = index;
                row["Value"] = "Grid: " + index.ToString();
                set.Rows.Add(row);
            }

            CMB_PolygonBox.DataSource = set;
            CMB_PolygonBox.ValueMember = "key";
            CMB_PolygonBox.DisplayMember = "Value";

            if (CHK_AutoGeneralWP.Checked)
                domainUpDown1_ValueChanged();
            else
                EnterCalc();
        }
        #endregion

        #endregion

        #endregion

        #region 航线生成

        #region 标记

        #region 加载状态符（加载数据过程中的数据变换不引发航线生成函数）
        bool loading = false;

        #region 接口函数
        public void StartLoading()
        {
            loading = true;
        }

        public void EndLoading()
        {
            loading = false;
        }
        #endregion

        #region 判断函数
        private bool IsLoading()
        {
            return loading;
        }
        #endregion

        #endregion

        #region 编辑标记符（编辑数据过程中的数据变换不引发航线生成函数）
        bool editable = true;

        #region 接口函数
        public void CloseEditFun()
        {
            editable = false;
        }

        public void OpenEditFun()
        {
            editable = true;
        }

        #endregion

        #region 判断函数
        private bool IsAllowEdit()
        {
            return editable;
        }
        #endregion

        #endregion

        #endregion

        #region 延迟生成 入口函数
        private void domainUpDown1_ValueChanged()
        {
            if (IsLoading())
                return;

            if (!IsAllowEdit())
                return;

            EnterCalc();

            if (poly.Count <= 0)
                return;

            // new grid system test
            ThreadPool.QueueUserWorkItem(new WaitCallback(delayGrid), lockObj);
        }

        #endregion

        #region 立即生成 入口函数
        private void domainUpDown2_ValueChanged()
        {
            if (IsLoading())
                return;
            if (!IsAllowEdit())
                return;

            EnterCalc();

            // new grid system test
            lock (lockObj2)
            {
                gridGrenate = true;
                autoGrid();
                gridGrenate = false;
            }
        }
        #endregion

        #region 延迟生成
        static long waitTime = 1000;
        static string progressBar = null;

        static object lockObj = new object();
        static object lockObj2 = new object();
        static long alterTime;
        static bool gridWait = false;
        static bool gridGrenate = false;
        static private void delayGrid(object obj)
        {
            alterTime = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000;
            lock (lockObj)
            {
                if (gridWait || gridGrenate)
                {
                    return;
                }

                progressBar = VPS.Controls.MainInfo.TopMainInfo.instance.CreateProgress("准备生成航线");
                gridWait = true;

            }
            var bar = VPS.Controls.MainInfo.TopMainInfo.instance.GetProgress(progressBar);
            while (true)
            {
                long time = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000 - alterTime;
                if (progressBar != null)
                    bar.SetProgress((double)time / waitTime);
                if (time > waitTime)
                {
                    lock (lockObj2)
                    {
                        try
                        {
                            if (progressBar != null)
                                bar.SetProgressFailure("生成航线");
                            bar.SetProgressStageInfo("生成航线", Color.Orange);
                            gridGrenate = true;
                            autoGrid();
                            gridGrenate = false;
                            gridWait = false;
                            if (progressBar != null)
                            {
                                bar.SetProgressSuccess("成功生成成功");
                            }
                        }
                        catch
                        {
                            bar.SetProgressFailure("生成航线失败");
                        }
                        finally
                        {
                            if (progressBar != null)
                                VPS.Controls.MainInfo.TopMainInfo.instance.DisposeControlEnter(progressBar, 1000);
                        }
                    }
                    return;
                }
                else
                {

                    Thread.SpinWait(100);
                }
            }
        }
        #endregion

        #region 立即生成
        private static async void autoGrid()
        {
            bool ch_Corridor = (bool)ReadControlMainThread(instance.chk_Corridor);
            bool chk_spiral = (bool)ReadControlMainThread(instance.chk_spiral);
            bool chk_crossgrid = (bool)ReadControlMainThread(instance.chk_crossgrid);

            double altitude = (int)ReadControlMainThread(instance.NUM_altitude);
            double distance = (double)ReadControlMainThread(instance.Num_Distance);
            double spacing = (double)ReadControlMainThread(instance.num_spacing);
            double angle = (double)ReadControlMainThread(instance.num_angle);
            double overshoot = (int)ReadControlMainThread(instance.NUM_overshoot);
            double overshoot2 = (int)ReadControlMainThread(instance.NUM_overshoot2);
            string startfrom = (string)ReadControlMainThread(instance.CMB_startfrom);

            float num_lane_dist = (int)ReadControlMainThread(instance.NUM_Lane_Dist);
            float num_corridorwidth = (int)ReadControlMainThread(instance.num_corridorwidth);
            float num_landin = (int)ReadControlMainThread(instance.NUM_leadin);

            PointLatLngAlt startPoint = instance.GetStartPoint();
            if (startPoint != null)
                Utilities.Grid.StartPointLatLngAlt = startPoint;
            List<PointLatLngAlt> wp = new List<PointLatLngAlt>();
            if (ch_Corridor)
            {
                wp = await Utilities.Grid.CreateCorridorAsync(
                    instance.poly, CurrentState.fromDistDisplayUnit(altitude),
                    distance, spacing, angle,
                    overshoot, overshoot2,
                    (Utilities.Grid.StartPosition)Enum.Parse(typeof(Utilities.Grid.StartPosition), startfrom), false,
                    num_lane_dist, num_corridorwidth, num_landin).ConfigureAwait(true);
            }
            else if (chk_spiral)
            {
                //生成螺旋航线
                wp = await Utilities.Grid.CreateRotaryAsync(
                    instance.poly, CurrentState.fromDistDisplayUnit(altitude),
                    distance, spacing, angle,
                    overshoot, (double)instance.NUM_overshoot2.Value,
                    (Utilities.Grid.StartPosition)Enum.Parse(typeof(Utilities.Grid.StartPosition), startfrom), false,
                    num_lane_dist, num_landin, MainV2.comPort.MAV.cs.PlannedHomeLocation).ConfigureAwait(true);
            }
            else
            {

                wp = await Utilities.Grid.CreateGridAsync(
                    instance.poly, CurrentState.fromDistDisplayUnit(altitude),
                    distance, spacing, angle,
                    overshoot, overshoot2,
                    (Utilities.Grid.StartPosition)Enum.Parse(typeof(Utilities.Grid.StartPosition), startfrom), false,
                    num_lane_dist, num_landin, MainV2.comPort.MAV.cs.PlannedHomeLocation).ConfigureAwait(true);
            }

            if (wp.Count == 0)
            {
                instance.grid.Clear();
                CustomData.WP.WPGlobalData.instance.SetWPListHandle(instance.GetWPList());
                return;
            }

            if (chk_crossgrid)
            {
                //添加栅栏纵航线
                Utilities.Grid.StartPointLatLngAlt = wp[wp.Count - 1];

                wp.AddRange(await Utilities.Grid.CreateGridAsync(
                    instance.poly, CurrentState.fromDistDisplayUnit(altitude),
                    distance, spacing, angle + 90.0,
                    overshoot, overshoot2,
                    Utilities.Grid.StartPosition.Point, false,
                    num_lane_dist, num_landin, MainV2.comPort.MAV.cs.PlannedHomeLocation).ConfigureAwait(true));
            }

            if (wp.Count == 0)
            {
                instance.grid.Clear();
                CustomData.WP.WPGlobalData.instance.SetWPListHandle(instance.GetWPList());
                return;
            }

            int images = 0;
            int a = 0;

            instance.grid.Clear();
            for (int index = 0; index < wp.Count; index++)
            {
                if (wp[index].Tag == "S" || wp[index].Tag == "E")
                {
                    PointLatLngAlt point = wp[index];
                    point.Tag = CustomData.WP.WPCommands.DefaultWPCommand;
                    point.Tag2 = CustomData.EnumCollect.AltFrame.Relative;

                    instance.grid.Add(point);
                    a++;
                }
                else if (wp[index].Tag == "SM")
                {
                    if (wp[index - 1].Lat == wp[index].Lat && wp[index - 1].Lng == wp[index].Lng)
                        continue;
                    else
                    {
                        PointLatLngAlt point = wp[index];
                        point.Tag = CustomData.WP.WPCommands.DefaultWPCommand;
                        point.Tag2 = CustomData.EnumCollect.AltFrame.Relative;

                        instance.grid.Add(point);
                        a++;
                    }

                }
                else if (wp[index].Tag == "ME")
                {
                    if (wp[index + 1].Lat == wp[index].Lat && wp[index + 1].Lng == wp[index].Lng)
                        continue;
                    else
                    {
                        PointLatLngAlt point = wp[index];
                        point.Tag = CustomData.WP.WPCommands.DefaultWPCommand;
                        point.Tag2 = CustomData.EnumCollect.AltFrame.Relative;

                        instance.grid.Add(point);
                        a++;
                    }
                }
                else if (wp[index].Tag == "M")
                {
                    if (false)
                    {
                        PointLatLngAlt point = wp[index];
                        point.Tag = CustomData.WP.WPCommands.ClickWPCommand;
                        point.Tag2 = CustomData.EnumCollect.AltFrame.Relative;

                        instance.grid.Add(point);
                    }
                    images++;
                    a++;
                }


            }
            SetControlMainThread(instance.Num_GndeLev, instance.GetBaseAlt(instance.GetWPList()));
            CustomData.WP.WPGlobalData.instance.SetWPListHandle(instance.GetWPList());
        }
        #endregion

        #region 参数计算

        #region 入口函数
        private void EnterCalc()
        {
            if (!IsAllowEdit())
                return;

            if (CMB_Camera.Text != "")
            {
                CloseEditFun();
                doCalc();
                OpenEditFun();
            }
        }
        #endregion

        #region 实现
        void doCalc()
        {

            // entered values
            float flyalt = (float)CurrentState.fromDistDisplayUnit((float)NUM_altitude.Value);
            int imagewidth = TXT_ImgWidth.Value;
            int imageheight = TXT_ImgHeight.Value;

            double overlap = num_overlap.Value;
            double sidelap = num_sidelap.Value;

            double viewwidth = 0;
            double viewheight = 0;

            getFOV(flyalt, ref viewwidth, ref viewheight);

            TXT_FovH.Value = viewwidth;
            TXT_FovV.Value = viewheight;
            // Imperial
            //feet_fovH = (viewwidth * 3.2808399f).ToString("#.#");
            //feet_fovV = (viewheight * 3.2808399f).ToString("#.#");

            //    mm  / pixels * 100
            TXT_cmPixel.Value = ((viewheight / imageheight) * 100);
            // Imperial
            //inchpixel = (((viewheight / imageheight) * 100) * 0.393701).ToString("0.00 inches");

            if (CHK_camdirection.Checked)
            {
                num_spacing.Value = (double)((1 - (overlap / 100.0f)) * viewheight);
                Num_Distance.Value = (double)((1 - (sidelap / 100.0f)) * viewwidth);
            }
            else
            {
                num_spacing.Value = (double)((1 - (overlap / 100.0f)) * viewwidth);
                Num_Distance.Value = (double)((1 - (sidelap / 100.0f)) * viewheight);
            }

            if (!isLockAngle)
            {
                num_angle.Value = getAngleOfLongestSide(poly);
            }

        }
        #endregion

        #endregion

        #endregion

        #region 参数计算

        #region 获取航飞角度
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
        #endregion

        #region 获取相机效果
        // Variables
        const double rad2deg = (180 / Math.PI);
        const double deg2rad = (1.0 / rad2deg);

        void getFOV(double flyalt, ref double fovh, ref double fovv)
        {
            double focallen = NUM_FocalLength.Value;
            double sensorwidth = TXT_SensWidth.Value;
            double sensorheight = TXT_SensHeight.Value;

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
        #endregion

        #region 获取航摄基线
        private int GetBaseAlt(List<PointLatLngAlt> list)
        {
            double totalWP = 0;
            int totalCount = 0;
            foreach (var wp in list)
            {
                if (CustomData.WP.WPCommands.CoordsWPCommands.Contains(wp.Tag))
                {
                    totalWP += Utilities.srtm.getAltitude(wp.Lat, wp.Lng).alt * CurrentState.multiplieralt;
                    totalCount++;
                }
            }
            return (int)(totalWP / Math.Max(1, totalCount));
        }
        #endregion

        #endregion

        #region CameraInfos

        #region 获取信息
        public CustomData.Grid.camerainfo GetCameraInfo
        {
            get
            {
                return new CustomData.Grid.camerainfo()
                {
                    name = this.CMB_Camera.Text,
                    focallen = (float)this.NUM_FocalLength.Value,
                    imageheight = (int)this.TXT_ImgHeight.Value,
                    imagewidth = (int)this.TXT_ImgWidth.Value,
                    sensorheight = (float)this.TXT_SensHeight.Value,
                    sensorwidth = (float)this.TXT_SensWidth.Value
                };
            }
            set
            {
                CMB_Camera.Text = (value.name);
                NUM_FocalLength.Value = value.focallen;
                TXT_ImgHeight.Value = value.imageheight;
                TXT_ImgWidth.Value = value.imagewidth;
                TXT_SensHeight.Value = value.sensorheight;
                TXT_SensWidth.Value = value.sensorwidth;
            }
        }
        #endregion

        #region 添加信息
        private void AddCamera_Click(object sender, EventArgs e)
        {
            using (CustomForms.CustomCamera dlg = new CustomForms.CustomCamera())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var info = dlg.GetCamerainfo();
                    CustomData.Grid.camerainfo.AddCamera(info);


                    if (!CMB_Camera.Items.Contains(info.name))
                        CMB_Camera.Items.Add(info.name);
                    CMB_Camera.SelectedIndex = CMB_Camera.Items.IndexOf(info.name);
                }

            }

        }
        #endregion

        #endregion

        #region 获取控件数据
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
                    return ((DevComponents.DotNetBar.Controls.ComboBoxEx)control).SelectedItem;
                return null;
            }
        }
        #endregion

        #region 设置控件数据
        private delegate void SetControlInMainThreadHandle(Control control, object data);

        private static void SetControlMainThread(Control control, object data)
        {
            if (control.InvokeRequired)
            {
                SetControlInMainThreadHandle inThread = new SetControlInMainThreadHandle(SetControlMainThread);
                control.Invoke(inThread, new object[] { control, data });
            }
            else
            {
                if (control is DevComponents.Editors.DoubleInput)
                    ((DevComponents.Editors.DoubleInput)control).Value = (double)data;
                if (control is DevComponents.Editors.IntegerInput)
                    ((DevComponents.Editors.IntegerInput)control).Value = (int)data;
                if (control is DevComponents.DotNetBar.Controls.CheckBoxX)
                    ((DevComponents.DotNetBar.Controls.CheckBoxX)control).Checked = (bool)data;
                if (control is DevComponents.DotNetBar.Controls.ComboBoxEx)
                    ((DevComponents.DotNetBar.Controls.ComboBoxEx)control).Text = (string)data;
                if (control is DevComponents.DotNetBar.ButtonX)
                    ((DevComponents.DotNetBar.ButtonX)control).Enabled = (bool)data;
                if (control is DevComponents.DotNetBar.PanelEx)
                    ((DevComponents.DotNetBar.PanelEx)control).Visible = (bool)data;

            }
        }
        #endregion

        #region 参数变换响应函数

        #region 相机

        #region 相机型号
        private void CMB_camera_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCameraInfo = CustomData.Grid.camerainfo.GetCameraInfos(CMB_Camera.Text);
            if (CHK_AutoGeneralWP.Checked)
                domainUpDown1_ValueChanged();
            else
                EnterCalc();
        }

        private void CMB_camera_SelectedValueChanged(object sender, EventArgs e)
        {
            GetCameraInfo = CustomData.Grid.camerainfo.GetCameraInfos(CMB_Camera.Text);
            if (CHK_AutoGeneralWP.Checked)
                domainUpDown1_ValueChanged();
            else
                EnterCalc();
        }
        #endregion

        #region 相机姿态
        private void CHK_camdirection_CheckedChanged(object sender, EventArgs e)
        {
            if (CHK_AutoGeneralWP.Checked)
                domainUpDown1_ValueChanged();
            else
                EnterCalc();
        }
        #endregion

        #region 相机焦距
        private void NUM_focallength_ValueChanged(object sender, EventArgs e)
        {
            if (CHK_AutoGeneralWP.Checked)
                domainUpDown1_ValueChanged();
            else
                EnterCalc();
        }
        #endregion

        #region 显示详细信息
        private void ShowCameraInfo_CheckedChanged(object sender, EventArgs e)
        {
            this.CameraDetailBox.Visible = this.CHK_ShowCameraInfo.Checked;
        }
        #endregion

        #endregion

        #region 航线类型

        #region 栅线
        private void chk_crossgrid_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_crossgrid.Checked)
            {
                chk_Corridor.Checked = chk_spiral.Checked = false;
            }
            if (CHK_AutoGeneralWP.Checked)
                domainUpDown1_ValueChanged();
            else
                EnterCalc();
        }
        #endregion

        #region 廊线
        private void chk_Corridor_CheckedChanged(object sender, EventArgs e)
        {
            CorridorInfoBox.Visible = chk_Corridor.Checked;
            if (chk_Corridor.Checked)
            {
                chk_crossgrid.Checked = chk_spiral.Checked = false;
            }
            if (CHK_AutoGeneralWP.Checked)
                domainUpDown1_ValueChanged();
            else
                EnterCalc();
        }

        #region 廊线宽
        private void num_corridorwidth_ValueChanged(object sender, EventArgs e)
        {
            if (CHK_AutoGeneralWP.Checked)
                domainUpDown1_ValueChanged();
            else
                EnterCalc();
        }
        #endregion

        #endregion

        #region 螺线
        private void chk_spiral_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_spiral.Checked)
            {
                chk_Corridor.Checked = chk_crossgrid.Checked = false;
            }
            if (CHK_AutoGeneralWP.Checked)
                domainUpDown1_ValueChanged();
            else
                EnterCalc();
        }
        #endregion

        #endregion

        #region 高度

        #region 相对高度
        private void NUM_altitude_ValueChanged(object sender, EventArgs e)
        {
            if (CHK_AutoGeneralWP.Checked)
                domainUpDown1_ValueChanged();
            else
                EnterCalc();
        }
        #endregion

        #region 航摄基准
        private void lbl_gndelev_ValueChanged(object sender, EventArgs e)
        {
            if (CHK_AutoGeneralWP.Checked)
                domainUpDown1_ValueChanged();
            else
                EnterCalc();
        }
        #endregion

        #endregion

        #region 重叠度

        #region 航向重叠度
        private void num_overlap_ValueChanged(object sender, EventArgs e)
        {
            if (CHK_AutoGeneralWP.Checked)
                domainUpDown1_ValueChanged();
            else
                EnterCalc();
        }
        #endregion

        #region 旁像重叠度
        private void num_sidelap_ValueChanged(object sender, EventArgs e)
        {
            if (CHK_AutoGeneralWP.Checked)
                domainUpDown1_ValueChanged();
            else
                EnterCalc();
        }
        #endregion

        #endregion

        #region 角度

        #region 航飞角度
        private void NUM_angle_ValueChanged(object sender, EventArgs e)
        {
            if (CHK_AutoGeneralWP.Checked)
                domainUpDown1_ValueChanged();
            else
                EnterCalc();
        }
        #endregion

        #region 锁定
        bool isLockAngle;
        private void LockAngle_CheckedChanged(object sender, EventArgs e)
        {
            isLockAngle = LockAngle.Checked;
            if (!isLockAngle)
            {
                if (CHK_AutoGeneralWP.Checked)
                    domainUpDown1_ValueChanged();
                else
                    EnterCalc();
                num_angle.Enabled = true;
                DefaultAngle.Enabled = true;
            }
            else
            {
                num_angle.Enabled = false;
                DefaultAngle.Enabled = false;
            }
        }
        #endregion

        #region 默认
        private void defaultAngle_Click(object sender, EventArgs e)
        {
            if (!isLockAngle)
            {
                this.num_angle.Value = getAngleOfLongestSide(poly);
                if (CHK_AutoGeneralWP.Checked)
                    domainUpDown1_ValueChanged();
                else
                    EnterCalc();
            }
        }
        #endregion

        #endregion

        #region 起始位置
        private void CMB_startfrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Utilities.Grid.StartPosition.Point.ToString() == CMB_startfrom.SelectedItem.ToString())
            {
                this.StartPointBox.Visible = true;
                return;
            }
            else
                this.StartPointBox.Visible = false;

            if (CHK_AutoGeneralWP.Checked)
                domainUpDown1_ValueChanged();
        }
        #endregion

        #region 启用高级选项
        private void ShowAdvanceOptions_CheckedChanged(object sender, EventArgs e)
        {
            this.AdvanceAirLineBox.Visible = this.ShowAdvanceOptions.Checked;
        }
        #endregion

        #region 航线延伸

        #region 前冲量（来）
        private void NUM_overshoot_ValueChanged(object sender, EventArgs e)
        {
            if (CHK_AutoGeneralWP.Checked)
                domainUpDown1_ValueChanged();
            else
                EnterCalc();
        }
        #endregion

        #region 前冲量（去）
        private void NUM_overshoot2_ValueChanged(object sender, EventArgs e)
        {
            if (CHK_AutoGeneralWP.Checked)
                domainUpDown1_ValueChanged();
            else
                EnterCalc();
        }
        #endregion

        #region 引入线
        private void NUM_leadin_ValueChanged(object sender, EventArgs e)
        {
            if (CHK_AutoGeneralWP.Checked)
                domainUpDown1_ValueChanged();
            else
                EnterCalc();
        }
        #endregion

        #endregion

        #region 备用航线
        private void NUM_Lane_Dist_ValueChanged(object sender, EventArgs e)
        {
            if (CHK_AutoGeneralWP.Checked)
                domainUpDown1_ValueChanged();
            else
                EnterCalc();
        }
        #endregion

        #region 航线计算参数

        #region 航线间距
        private void NUM_Distance_ValueChanged(object sender, EventArgs e)
        {
            if (CHK_AutoGeneralWP.Checked)
                domainUpDown1_ValueChanged();
            else
                EnterCalc();
        }
        #endregion

        #region 航摄基线
        private void NUM_spacing_ValueChanged(object sender, EventArgs e)
        {
            if (CHK_AutoGeneralWP.Checked)
                domainUpDown1_ValueChanged();
            else
                EnterCalc();
        }
        #region

        #endregion

        #endregion

        #endregion

        #endregion

        #region 航线生成响应函数

        #region 功能切换
        private void AutoGeneralWP_CheckedChanged(object sender, EventArgs e)
        {
            if (CHK_AutoGeneralWP.Checked)
            {
                DelayBox.Visible = true;
                HandBox.Visible = false;
            }
            else
            {
                DelayBox.Visible = false;
                HandBox.Visible = true;
            }
        }
        #endregion

        #region 立即生成

        #region 响应函数
        private void GeneralWP_Click(object sender, EventArgs e)
        {
            domainUpDown2_ValueChanged();
        }
        #endregion

        #region 启用快捷键
        private void CHK_UseGeneralWPKey_CheckedChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #endregion

        #region 延迟生成

        #region 设置延迟时间
        private void NUM_WPDelayTime_ValueChanged(object sender, EventArgs e)
        {
            waitTime = (long)(NUM_WPDelayTime.Value * 1000);
        }
        #endregion

        #endregion

        #endregion

        #region 快捷键
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.F5))
            {
                if (!(bool)ReadControlMainThread(CHK_AutoGeneralWP) && (bool)ReadControlMainThread(CHK_UseGeneralWPKey))
                {
                    GeneralWP_Click(null, null);
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        private void CHK_UsingPolygon_CheckedChanged(object sender, EventArgs e)
        {
            if (CHK_UsingPolygon.Checked)
                polygonListBox.Visible = true;
            else
                polygonListBox.Visible = false;

        }

        private void CHK_UsingWP_CheckedChanged(object sender, EventArgs e)
        {
            if (CHK_UsingWP.Checked)
                WPListBox.Visible = true;
            else
                WPListBox.Visible = false;
        }

        private void CHK_UsingCustom_CheckedChanged(object sender, EventArgs e)
        {
            if (CHK_UsingCustom.Checked)
                CustomPointBox.Visible = true;
            else
                CustomPointBox.Visible = false;
        }

        private void CMB_PolygonBox_ValueMemberChanged(object sender, EventArgs e)
        {
            if (CMB_PolygonBox.Items.Count > 0)
            {
                TXT_PolygonInfo.Text =
                    "   经度：" + poly[0].Lng.ToString("0.######") +
                    "   纬度：" + poly[0].Lat.ToString("0.######");
                return;
            }

            TXT_PolygonInfo.Text = "   经度：null   纬度：null";
        }

        private void CMB_PolygonBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (int.TryParse(CMB_PolygonBox.SelectedValue.ToString(), out int index))
            {

                if (index >= 0 && index < poly.Count)
                {
                    TXT_PolygonInfo.Text =
                        "   经度：" + poly[index].Lng.ToString("0.######") +
                        "   纬度：" + poly[index].Lat.ToString("0.######");
                    return;
                }
            }
            TXT_PolygonInfo.Text = "   经度：null   纬度：null";
        }

        private delegate PointLatLngAlt GetStartPointInThread();
        public PointLatLngAlt GetStartPoint()
        {
            if (this.InvokeRequired)
            {
                GetStartPointInThread inThread = new GetStartPointInThread(GetStartPoint);
                IAsyncResult iar = this.BeginInvoke(inThread);
                return (PointLatLngAlt)this.EndInvoke(iar);
            }
            else
            {
                string startfrom = CMB_startfrom.Text;
                if (startfrom == "Point")
                {
                    if (CHK_UsingPolygon.Checked)
                    {
                        if (CMB_PolygonBox.SelectedValue == null)
                            return null;
                        if (int.TryParse(CMB_PolygonBox.SelectedValue.ToString(), out int index))
                        {
                            return poly[index];
                        }
                    }
                    if (CHK_UsingWP.Checked)
                    {
                        if (CMB_WPBox.SelectedValue == null)
                            return null;
                        if (int.TryParse(CMB_WPBox.SelectedValue.ToString(), out int index))
                        {
                            return wp[index];
                        }
                    }
                    if (CHK_UsingCustom.Checked)
                    {

                    }

                }

                return new PointLatLng(0, 0);
            }

        }

        private void CMB_WPBox_ValueMemberChanged(object sender, EventArgs e)
        {
            if (CMB_WPBox.Items.Count > 0)
            {
                TXT_WPInfo.Text =
                    "   经度：" + wp[0].Lng.ToString("0.######") +
                    "   纬度：" + wp[0].Lat.ToString("0.######");
                return;
            }

            TXT_WPInfo.Text = "   经度：null   纬度：null";
        }

        private void CMB_WPBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (int.TryParse(CMB_WPBox.SelectedValue.ToString(), out int index))
            {

                if (index >= 0 && index < poly.Count)
                {
                    TXT_WPInfo.Text =
                        "   经度：" + wp[index].Lng.ToString("0.######") +
                        "   纬度：" + wp[index].Lat.ToString("0.######");
                    return;
                }
            }
            TXT_WPInfo.Text = "   经度：null   纬度：null";
        }

        private void LockWP_Click(object sender, EventArgs e)
        {
            SetWPListHandle(CustomData.WP.WPGlobalData.instance.GetWPList());
        }

        private void Undo_Click(object sender, EventArgs e)
        {
            UndoHistoryList();
        }

        private void CHK_AppendWP_CheckedChanged(object sender, EventArgs e)
        {
            panelEx7.Visible = CHK_AppendWP.Checked;
        }
    }
}
