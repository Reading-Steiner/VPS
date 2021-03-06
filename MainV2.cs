﻿extern alias Drawing;

using GMap.NET.WindowsForms;
using log4net;
using VPS.ArduPilot;
using VPS.Comms;
using VPS.Controls;
using VPS.GCSViews.ConfigurationView;
using VPS.Log;
using VPS.Maps;
using VPS.Utilities;
using VPS.Utilities.AltitudeAngel;
using VPS.Warnings;
using SkiaSharp;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VPS.ArduPilot.Mavlink;
using VPS.Utilities.HW;
using Transitions;
using AltitudeAngelWings;
using GMap.NET.CacheProviders;
using System.Runtime.Remoting.Messaging;
using static GDAL.GDAL;
using System.Linq;
using DevComponents.DotNetBar;

namespace VPS
{
    public partial class MainV2 : Office2007RibbonForm
    {
        private static readonly ILog log =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region DisplayView

        private static DisplayView _displayConfiguration = File.Exists(DisplayViewExtensions.custompath)
            ? new DisplayView().Custom()
            : new DisplayView().Advanced();

        public static event EventHandler LayoutChanged;

        public static DisplayView DisplayConfiguration
        {
            get { return _displayConfiguration; }
            set
            {
                _displayConfiguration = value;
                Settings.Instance["displayview"] = _displayConfiguration.ConvertToString();
                LayoutChanged?.Invoke(null, EventArgs.Empty);
            }
        }

        #endregion

        //public static bool ShowAirports { get; set; }

        private Utilities.adsb _adsb;

        public bool EnableADSB
        {
            get { return _adsb != null; }
            set
            {
                if (value == true)
                {
                    _adsb = new Utilities.adsb();

                    if (Settings.Instance["adsbserver"] != null)
                        Utilities.adsb.server = Settings.Instance["adsbserver"];
                    if (Settings.Instance["adsbport"] != null)
                        Utilities.adsb.serverport = int.Parse(Settings.Instance["adsbport"].ToString());
                }
                else
                {
                    Utilities.adsb.Stop();
                    _adsb = null;
                }
            }
        }

        //public static event EventHandler LayoutChanged;

        /// <summary>
        /// Active Comport interface
        /// </summary>
        public static MAVLinkInterface comPort
        {
            get
            {
                return _comPort;
            }
            set
            {
                if (_comPort == value)
                    return;
                _comPort = value;
                _comPort.MavChanged -= instance.comPort_MavChanged;
                _comPort.MavChanged += instance.comPort_MavChanged;
                instance.comPort_MavChanged(null, null);
            }
        }

        static MAVLinkInterface _comPort = new MAVLinkInterface();

        /// <summary>
        /// passive comports
        /// </summary>
        public static List<MAVLinkInterface> Comports = new List<MAVLinkInterface>();

        public delegate void WMDeviceChangeEventHandler(WM_DEVICECHANGE_enum cause);

        public event WMDeviceChangeEventHandler DeviceChanged;

        /// <summary>
        /// other planes in the area from adsb
        /// </summary>
        public object adsblock = new object();

        public ConcurrentDictionary<string, adsb.PointLatLngAltHdg> adsbPlanes = new ConcurrentDictionary<string, adsb.PointLatLngAltHdg>();

        //string titlebar;

        /// <summary>
        /// Comport name
        /// </summary>
        public static string comPortName = "";

        public static int comPortBaud = 115200;

        /// <summary>
        /// mono detection
        /// </summary>
        public static bool MONO = false;

        /// <summary>
        /// speech engine enable
        /// </summary>
        public static bool speechEnable
        {
            get { return speechEngine == null ? false : speechEngine.speechEnable; }
            set
            {
                if (speechEngine != null) speechEngine.speechEnable = value;
            }
        }

        /// <summary>
        /// spech engine static class
        /// </summary>
        public static ISpeech speechEngine { get; set; }

        /// <summary>
        /// joystick static class
        /// </summary>
        public static Joystick.Joystick joystick { get; set; }

        /// <summary>
        /// track last joystick packet sent. used to control rate
        /// </summary>
        DateTime lastjoystick = DateTime.Now;

        /// <summary>
        /// determine if we are running sitl
        /// </summary>
        public static bool sitl
        {
            get
            {
                if (VPS.GCSViews.SITL.SITLSEND == null) return false;
                if (VPS.GCSViews.SITL.SITLSEND.Client.Connected) return true;
                return false;
            }
        }

        /// <summary>
        /// hud background image grabber from a video stream - not realy that efficent. ie no hardware overlays etc.
        /// </summary>
        public static WebCamService.Capture cam { get; set; }

        /// <summary>
        /// controls the main serial reader thread
        /// </summary>
        bool serialThread = false;

        bool pluginthreadrun = false;

        bool joystickthreadrun = false;

        Thread httpthread;
        Thread joystickthread;
        Thread serialreaderthread;
        Thread pluginthread;

        /// <summary>
        /// track the last heartbeat sent
        /// </summary>
        private DateTime heatbeatSend = DateTime.Now;

        /// <summary>
        /// used to call anything as needed.
        /// </summary>
        public static MainV2 instance = null;


        public static MainSwitcher View;

        /// <summary>
        /// store the time we first connect
        /// </summary>
        DateTime connecttime = DateTime.Now;

        DateTime nodatawarning = DateTime.Now;
        DateTime OpenTime = DateTime.Now;


        DateTime connectButtonUpdate = DateTime.Now;

        /// <summary>
        /// declared here if i want a "single" instance of the form
        /// ie configuration gets reloaded on every click
        /// </summary>
        public GCSViews.FlightData FlightData;
        CustomData.Layer.MemoryLayerCache layerCache;
        public GCSViews.FlightPlanner FlightPlanner;
        //GCSViews.SITL Simulation;

        private Form connectionStatsForm;
        private ConnectionStats _connectionStats;

        /// <summary>
        /// This 'Control' is the toolstrip control that holds the comport combo, baudrate combo etc
        /// Otiginally seperate controls, each hosted in a toolstip sqaure, combined into this custom
        /// control for layout reasons.
        /// </summary>
        public static ConnectionControl _connectionControl;

        public static bool TerminalTheming = true;

        public void updateLayout(object sender, EventArgs e)
        {
            MenuSimulation.Visible = DisplayConfiguration.displaySimulation;
            MenuHelp.Visible = DisplayConfiguration.displayHelp;
            VPS.Controls.BackstageView.BackstageView.Advanced = DisplayConfiguration.isAdvancedMode;


            //Flight data page
            if (MainV2.instance.FlightData != null)
            {
                var t = MainV2.instance.FlightData.tabControlactions;
                if (DisplayConfiguration.displayQuickTab && !t.TabPages.Contains(FlightData.tabQuick))
                {
                    t.TabPages.Add(FlightData.tabQuick);
                }
                else if (!DisplayConfiguration.displayQuickTab && t.TabPages.Contains(FlightData.tabQuick))
                {
                    t.TabPages.Remove(FlightData.tabQuick);
                }
                if (DisplayConfiguration.displayPreFlightTab && !t.TabPages.Contains(FlightData.tabPagePreFlight))
                {
                    t.TabPages.Add(FlightData.tabPagePreFlight);
                }
                else if (!DisplayConfiguration.displayPreFlightTab && t.TabPages.Contains(FlightData.tabPagePreFlight))
                {
                    t.TabPages.Remove(FlightData.tabPagePreFlight);
                }
                if (DisplayConfiguration.displayAdvActionsTab && !t.TabPages.Contains(FlightData.tabActions))
                {
                    t.TabPages.Add(FlightData.tabActions);
                }
                else if (!DisplayConfiguration.displayAdvActionsTab && t.TabPages.Contains(FlightData.tabActions))
                {
                    t.TabPages.Remove(FlightData.tabActions);
                }
                if (DisplayConfiguration.displaySimpleActionsTab && !t.TabPages.Contains(FlightData.tabActionsSimple))
                {
                    t.TabPages.Add(FlightData.tabActionsSimple);
                }
                else if (!DisplayConfiguration.displaySimpleActionsTab && t.TabPages.Contains(FlightData.tabActionsSimple))
                {
                    t.TabPages.Remove(FlightData.tabActionsSimple);
                }
                if (DisplayConfiguration.displayGaugesTab && !t.TabPages.Contains(FlightData.tabGauges))
                {
                    t.TabPages.Add(FlightData.tabGauges);
                }
                else if (!DisplayConfiguration.displayGaugesTab && t.TabPages.Contains(FlightData.tabGauges))
                {
                    t.TabPages.Remove(FlightData.tabGauges);
                }
                if (DisplayConfiguration.displayStatusTab && !t.TabPages.Contains(FlightData.tabStatus))
                {
                    t.TabPages.Add(FlightData.tabStatus);
                }
                else if (!DisplayConfiguration.displayStatusTab && t.TabPages.Contains(FlightData.tabStatus))
                {
                    t.TabPages.Remove(FlightData.tabStatus);
                }
                if (DisplayConfiguration.displayServoTab && !t.TabPages.Contains(FlightData.tabServo))
                {
                    t.TabPages.Add(FlightData.tabServo);
                }
                else if (!DisplayConfiguration.displayServoTab && t.TabPages.Contains(FlightData.tabServo))
                {
                    t.TabPages.Remove(FlightData.tabServo);
                }
                if (DisplayConfiguration.displayScriptsTab && !t.TabPages.Contains(FlightData.tabScripts))
                {
                    t.TabPages.Add(FlightData.tabScripts);
                }
                else if (!DisplayConfiguration.displayScriptsTab && t.TabPages.Contains(FlightData.tabScripts))
                {
                    t.TabPages.Remove(FlightData.tabScripts);
                }
                if (DisplayConfiguration.displayTelemetryTab && !t.TabPages.Contains(FlightData.tabTLogs))
                {
                    t.TabPages.Add(FlightData.tabTLogs);
                }
                else if (!DisplayConfiguration.displayTelemetryTab && t.TabPages.Contains(FlightData.tabTLogs))
                {
                    t.TabPages.Remove(FlightData.tabTLogs);
                }
                if (DisplayConfiguration.displayDataflashTab && !t.TabPages.Contains(FlightData.tablogbrowse))
                {
                    t.TabPages.Add(FlightData.tablogbrowse);
                }
                else if (!DisplayConfiguration.displayDataflashTab && t.TabPages.Contains(FlightData.tablogbrowse))
                {
                    t.TabPages.Remove(FlightData.tablogbrowse);
                }
                if (DisplayConfiguration.displayMessagesTab && !t.TabPages.Contains(FlightData.tabPagemessages))
                {
                    t.TabPages.Add(FlightData.tabPagemessages);
                }
                else if (!DisplayConfiguration.displayMessagesTab && t.TabPages.Contains(FlightData.tabPagemessages))
                {
                    t.TabPages.Remove(FlightData.tabPagemessages);
                }
                t.SelectedIndex = 0;

                MainV2.instance.FlightData.loadTabControlActions();
            }

            if (MainV2.instance.FlightPlanner != null)
            {
                //hide menu items 
                MainV2.instance.FlightPlanner.updateDisplayView();
            }
        }


        public MainV2()
        {


            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            // create one here - but override on load
            Settings.Instance["guid"] = Guid.NewGuid().ToString();

            // load config
            LoadConfig();

            // force language to be loaded
            L10N.GetConfigLang();

            //ShowAirports = true;

            // setup adsb
            Utilities.adsb.UpdatePlanePosition += adsb_UpdatePlanePosition;

            MAVLinkInterface.UpdateADSBPlanePosition += adsb_UpdatePlanePosition;

            MAVLinkInterface.UpdateADSBCollision += (sender, tuple) =>
            {
                lock (adsblock)
                {
                    if (MainV2.instance.adsbPlanes.ContainsKey(tuple.id))
                    {
                        // update existing
                        ((adsb.PointLatLngAltHdg)instance.adsbPlanes[tuple.id]).ThreatLevel = tuple.threat_level;
                    }
                }
            };

            MAVLinkInterface.gcssysid = (byte)Settings.Instance.GetByte("gcsid", MAVLinkInterface.gcssysid);

            Form splash = Program.Splash;

            splash?.Refresh();

            Application.DoEvents();

            instance = this;
            InitializeComponent();

            //Init Theme table and load BurntKermit as a default
            //ThemeManager.thmColor = new ThemeColorTable(); //Init colortable
            //ThemeManager.thmColor.InitColors();     //This fills up the table with BurntKermit defaults. 
            //ThemeManager.thmColor.SetTheme();              //Set the colors, this need to handle the case when not all colors are defined in the theme file



            //if (Settings.Instance["theme"] == null) Settings.Instance["theme"] = "HighContrast.mpsystheme";
            //if (Settings.Instance["theme"] == "BurntKermit.mpsystheme") Settings.Instance["theme"] = "HighContrast.mpsystheme";

            //ThemeManager.LoadTheme(Settings.Instance["theme"]);

            //Utilities.ThemeManager.ApplyThemeTo(this);

            MyView = new MainSwitcher(this.RibbonClientPanel);

            View = MyView;

            //startup console
            TCPConsole.Write((byte)'S');

            // define default basestream
            comPort.BaseStream = new SerialPort();
            comPort.BaseStream.BaudRate = 115200;

            _connectionControl = toolStripConnectionControl.ConnectionControl;
            _connectionControl.CMB_baudrate.TextChanged += this.CMB_baudrate_TextChanged;
            _connectionControl.CMB_serialport.SelectedIndexChanged += this.CMB_serialport_SelectedIndexChanged;
            _connectionControl.CMB_serialport.Click += this.CMB_serialport_Click;
            _connectionControl.cmb_sysid.Click += cmb_sysid_Click;

            _connectionControl.ShowLinkStats += (sender, e) => ShowConnectionStatsForm();
            srtm.datadirectory = Settings.GetDataDirectory() +
                                 "srtm";

            var t = Type.GetType("Mono.Runtime");
            MONO = (t != null);

            try
            {
                speechEngine = new Speech();
                MAVLinkInterface.Speech = speechEngine;
                CurrentState.Speech = speechEngine;
            }
            catch { }

            Warnings.CustomWarning.defaultsrc = comPort.MAV.cs;
            Warnings.WarningEngine.Start(speechEnable ? speechEngine : null);
            Warnings.WarningEngine.WarningMessage += (sender, s) =>
            {
                MainV2.comPort.MAV.cs.messageHigh = s;
            };

            // proxy loader - dll load now instead of on config form load
            new Transition(new TransitionType_EaseInEaseOut(2000));

            PopulateSerialportList();
            if (_connectionControl.CMB_serialport.Items.Count > 0)
            {
                _connectionControl.CMB_baudrate.SelectedIndex = 8;
                _connectionControl.CMB_serialport.SelectedIndex = 0;
            }
            // ** Done

            splash?.Refresh();
            Application.DoEvents();

            // load last saved connection settings
            string temp = Settings.Instance.ComPort;
            if (!string.IsNullOrEmpty(temp))
            {
                _connectionControl.CMB_serialport.SelectedIndex = _connectionControl.CMB_serialport.FindString(temp);
                if (_connectionControl.CMB_serialport.SelectedIndex == -1)
                {
                    _connectionControl.CMB_serialport.Text = temp; // allows ports that dont exist - yet
                }
                comPort.BaseStream.PortName = temp;
                comPortName = temp;
            }
            string temp2 = Settings.Instance.BaudRate;
            if (!string.IsNullOrEmpty(temp2))
            {
                var idx = _connectionControl.CMB_baudrate.FindString(temp2);
                if (idx == -1)
                {
                    _connectionControl.CMB_baudrate.Text = temp2;
                }
                else
                {
                    _connectionControl.CMB_baudrate.SelectedIndex = idx;
                }

                comPortBaud = int.Parse(temp2);
            }

            VPS.Utilities.Tracking.cid = new Guid(Settings.Instance["guid"].ToString());

            if (Settings.Instance.ContainsKey("language") && !string.IsNullOrEmpty(Settings.Instance["language"]))
            {
                changelanguage(CultureInfoEx.GetCultureInfo(Settings.Instance["language"]));
            }

            if (!string.IsNullOrEmpty(Settings.Instance["formStyle"]))
            {
                eStyle style = (eStyle)Enum.Parse(typeof(eStyle), Settings.Instance["formStyle"]);
                // Using StyleManager change the style and color tinting
                this.styleManager.ManagerStyle = style;
                this.styleManager.ManagerColorTint = System.Drawing.Color.Empty;
            }
            else if (!Settings.Instance.ContainsKey("fromStyle"))
            {
                Settings.Instance.AppendList("formStyle", "");
            }
            //if (splash != null)
            //{
            //    this.Text = splash?.Text;
            //    titlebar = splash?.Text;
            //}

            if (!MONO) // windows only
            {
                // prevent system from sleeping while mp open
                var previousExecutionState =
                    NativeMethods.SetThreadExecutionState(NativeMethods.ES_CONTINUOUS | NativeMethods.ES_SYSTEM_REQUIRED);
            }

            ChangeUnits();

            if (Settings.Instance["enableadsb"] != null)
            {
                MainV2.instance.EnableADSB = Settings.Instance.GetBoolean("enableadsb");
            }

            try
            {
                log.Info("Create FlightData");
                FlightData = new GCSViews.FlightData();
                FlightData.Width = MyView.Width;

                log.Info("Create FlightPlanner");
                FlightPlanner = new GCSViews.FlightPlanner();
                FlightPlanner.Width = MyView.Width;

                //Configuration = new GCSViews.ConfigurationView.Setup();
                //log.Info("Create SIM");
                //Simulation = new GCSViews.SITL();
                //Firmware = new GCSViews.Firmware();
                //Terminal = new GCSViews.Terminal();
            }
            catch (ArgumentException e)
            {
                //http://www.microsoft.com/en-us/download/details.aspx?id=16083
                //System.ArgumentException: Font 'Arial' does not support style 'Regular'.
                log.Fatal(e);

                //splash.Close();
                //this.Close();
                Application.Exit();
            }
            catch (Exception e)
            {
                log.Fatal(e);

                Application.Exit();
            }

            //set first instance display configuration
            if (DisplayConfiguration == null)
            {
                DisplayConfiguration = DisplayConfiguration.Advanced();
            }

            // load old config
            if (Settings.Instance["advancedview"] != null)
            {
                if (Settings.Instance.GetBoolean("advancedview") == true)
                {
                    DisplayConfiguration = new DisplayView().Advanced();
                }
                // remove old config
                Settings.Instance.Remove("advancedview");
            }            //// load this before the other screens get loaded
            if (Settings.Instance["displayview"] != null)
            {
                try
                {
                    DisplayConfiguration = Settings.Instance.GetDisplayView("displayview");
                }
                catch
                {
                    DisplayConfiguration = DisplayConfiguration.Advanced();
                }
            }

            LayoutChanged += updateLayout;
            LayoutChanged?.Invoke(null, EventArgs.Empty);

            LoadMainFormSize();

            LoadCurrentState();
            try
            {
                // make sure rates propogate
                MainV2.comPort.MAV.cs.ResetInternals();

                if (Settings.Instance["speechenable"] != null)
                    MainV2.speechEnable = Settings.Instance.GetBoolean("speechenable");

                if (Settings.Instance["analyticsoptout"] != null)
                    VPS.Utilities.Tracking.OptOut = Settings.Instance.GetBoolean("analyticsoptout");
            }
            catch
            {
            }

            LoadPlannedHomeLocation();

            // create log dir if it doesnt exist
            try
            {
                if (!Directory.Exists(Settings.Instance.LogDir))
                    Directory.CreateDirectory(Settings.Instance.LogDir);
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

#if !NETSTANDARD2_0
#if !NETCOREAPP2_0
            Microsoft.Win32.SystemEvents.PowerModeChanged += SystemEvents_PowerModeChanged;
#endif
#endif

            LoadMarkerStyle();

            // make sure new enough .net framework is installed
            if (!MONO)
            {
                Microsoft.Win32.RegistryKey installed_versions =
                    Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP");
                string[] version_names = installed_versions.GetSubKeyNames();
                //version names start with 'v', eg, 'v3.5' which needs to be trimmed off before conversion
                double Framework = Convert.ToDouble(version_names[version_names.Length - 1].Remove(0, 1),
                    CultureInfo.InvariantCulture);
                int SP =
                    Convert.ToInt32(installed_versions.OpenSubKey(version_names[version_names.Length - 1])
                        .GetValue("SP", 0));

                if (Framework < 4.0)
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("项目需要 .NET Framework 4.0. 你当前版本为 " + Framework);
                }
            }


            Application.DoEvents();

            Comports.Add(comPort);

            MainV2.comPort.MavChanged += comPort_MavChanged;

            CustomData.WP.WPGlobalData.instance.historyChange += this.historyChange;
            SaveConfig();
        }


        #region 加载参数
        void LoadPlannedHomeLocation()
        {
            log.Info("加载PlannedHomeLocation");
            try
            {
                CustomData.WP.Position home = new CustomData.WP.Position();
                home.Command = VPS.CustomData.WP.WPCommands.HomeCommand;
                if (Settings.Instance["Main_DefaultHomeLat"] != null)
                    home.Lat = Settings.Instance.GetDouble("Main_DefaultHomeLat");

                if (Settings.Instance["Main_DefaultHomeLng"] != null)
                    home.Lng = Settings.Instance.GetDouble("Main_DefaultHomeLng");

                if (Settings.Instance["Main_DefaultHomeAlt"] != null)
                    home.Alt = Settings.Instance.GetDouble("Main_DefaultHomeAlt");

                if (Settings.Instance["Main_DefaultHomeAlt"] != null)
                    home.AltMode = Settings.Instance["TXT_homealt"].ToString();

                // remove invalid entrys
                if (Math.Abs(home.Lat) > 90 || Math.Abs(home.Lng) > 180)
                    MainV2.comPort.MAV.cs.PlannedHomeLocation = new PointLatLngAlt();
                else
                    MainV2.comPort.MAV.cs.PlannedHomeLocation = home.ToWGS84();
            }
            catch(Exception ex)
            {
                
                log.Error(ex.Message);
            }
            finally
            {}
        }

        void LoadMainFormSize()
        {
            log.Info("加载MainFormSize");
            try
            {
                if (Settings.Instance["MainLocX"] != null && Settings.Instance["MainLocY"] != null)
                {
                    this.StartPosition = FormStartPosition.Manual;
                    Point startpos = new Point(Settings.Instance.GetInt32("MainLocX"),
                        Settings.Instance.GetInt32("MainLocY"));

                    // fix common bug which happens when user removes a monitor, the app shows up
                    // offscreen and it is very hard to move it onscreen.  Also happens with 
                    // remote desktop a lot.  So this only restores position if the position
                    // is visible.
                    foreach (Screen s in Screen.AllScreens)
                    {
                        if (s.WorkingArea.Contains(startpos))
                        {
                            this.Location = startpos;
                            break;
                        }
                    }

                }

                if (Settings.Instance["MainMaximised"] != null)
                {
                    this.WindowState =
                        (FormWindowState)Enum.Parse(typeof(FormWindowState), Settings.Instance["MainMaximised"]);
                    // dont allow minimised start state
                    if (this.WindowState == FormWindowState.Minimized)
                    {
                        this.WindowState = FormWindowState.Normal;
                        this.Location = new Point(100, 100);
                    }
                }

                if (Settings.Instance["MainHeight"] != null)
                    this.Height = Settings.Instance.GetInt32("MainHeight");
                if (Settings.Instance["MainWidth"] != null)
                    this.Width = Settings.Instance.GetInt32("MainWidth");
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            finally { }
        }

        void LoadCurrentState()
        {
            log.Info("加载CurrentState");
            try
            {
                // set presaved default telem rates
                if (Settings.Instance["CMB_rateattitude"] != null)
                    CurrentState.rateattitudebackup = Settings.Instance.GetInt32("CMB_rateattitude");
                if (Settings.Instance["CMB_rateposition"] != null)
                    CurrentState.ratepositionbackup = Settings.Instance.GetInt32("CMB_rateposition");
                if (Settings.Instance["CMB_ratestatus"] != null)
                    CurrentState.ratestatusbackup = Settings.Instance.GetInt32("CMB_ratestatus");
                if (Settings.Instance["CMB_raterc"] != null)
                    CurrentState.ratercbackup = Settings.Instance.GetInt32("CMB_raterc");
                if (Settings.Instance["CMB_ratesensors"] != null)
                    CurrentState.ratesensorsbackup = Settings.Instance.GetInt32("CMB_ratesensors");

                if (CurrentState.rateattitudebackup == 0) // initilised to 10, configured above from save
                {
                    log.Error("NOTE: your attitude rate is 0, the hud will not work\nChange in Configuration > Planner > Telemetry Rates");
                    DevComponents.DotNetBar.MessageBoxEx.Show(
                        "NOTE: your attitude rate is 0, the hud will not work\nChange in Configuration > Planner > Telemetry Rates");
                }
                //Load customfield names from config
                for (short i = 0; i < 10; i++)
                {
                    var fieldname = "customfield" + i.ToString();
                    if (Settings.Instance.ContainsKey(fieldname))
                        CurrentState.custom_field_names.Add(fieldname, Settings.Instance[fieldname].ToUpper());
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            finally { }
        }

        void LoadMarkerStyle()
        {

            try
            {
                if (Settings.Instance["Style_LineStyle"] != null &&
                    Settings.Instance["Style_LineStyle"] != "")
                {
                    string LineStyle = Settings.Instance["Style_LineStyle"];
                    if (LineStyle.Contains("}") && LineStyle.Contains("{") && LineStyle.Contains(";"))
                    {



                        LineStyle = LineStyle.Replace("{", "").Replace("}", "");
                        var lines = LineStyle.Split(';');

                        for (int i = 0; i < lines.Count(); i++)
                        {
                            if (lines[i].Contains(':'))
                            {
                                var value = lines[i].Split(':');
                                var line = CustomData.WP.Convert.ToOverlayStyle(value[1]);
                                if (line != null)
                                    VPS.Maps.GMapOverlayStyle.SetGMapOverlayStyle(value[0], line);
                            }
                        }
                    }
                }

                if (Settings.Instance["Style_MarkerStyle"] != null &&
                    Settings.Instance["Style_MarkerStyle"] != "")
                {
                    string markerStyle = Settings.Instance["Style_MarkerStyle"];
                    if (markerStyle.Contains("}") && markerStyle.Contains("{") && markerStyle.Contains(";"))
                    {
                        markerStyle = markerStyle.Replace("{", "").Replace("}", "");
                        var markers = markerStyle.Split(';');

                        for (int i = 0; i < markers.Count(); i++)
                        {
                            if (markers[i].Contains(':'))
                            {
                                var value = markers[i].Split(':');
                                var marker = CustomData.WP.Convert.ToMarkerStyle(value[1]);
                                VPS.Maps.GMapMarkerStyle.SetGMapMarkerStyle(value[0], marker);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                log.Error("配置文件参数错误", ex);
            }
        }
        #endregion

        void cmb_sysid_Click(object sender, EventArgs e)
        {
            MainV2._connectionControl.UpdateSysIDS();
        }

        void comPort_MavChanged(object sender, EventArgs e)
        {
            log.Info("Mav Changed " + MainV2.comPort.MAV.sysid);

            HUD.Custom.src = MainV2.comPort.MAV.cs;

            CustomWarning.defaultsrc = MainV2.comPort.MAV.cs;

            VPS.Controls.PreFlight.CheckListItem.defaultsrc = MainV2.comPort.MAV.cs;

            // when uploading a firmware we dont want to reload this screen.
            if (instance.MyView.current.Control != null && instance.MyView.current.Control.GetType() == typeof(GCSViews.InitialSetup))
            {
                var page = ((GCSViews.InitialSetup)instance.MyView.current.Control).backstageView.SelectedPage;
                if (page != null && page.Text.Contains("Install Firmware"))
                {
                    return;
                }
            }

            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate
               {
                   //enable the payload control page if a mavlink gimbal is detected
                   if (instance.FlightData != null)
                   {
                       instance.FlightData.updatePayloadTabVisible();
                   }

                   instance.MyView.Reload();
               });
            }
            else
            {
                //enable the payload control page if a mavlink gimbal is detected
                if (instance.FlightData != null)
                {
                    instance.FlightData.updatePayloadTabVisible();
                }

                instance.MyView.Reload();
            }
        }
#if !NETSTANDARD2_0
#if !NETCOREAPP2_0
        void SystemEvents_PowerModeChanged(object sender, Microsoft.Win32.PowerModeChangedEventArgs e)
        {
            // try prevent crash on resume
            if (e.Mode == Microsoft.Win32.PowerModes.Suspend)
            {
                doDisconnect(MainV2.comPort);
            }
        }
#endif
#endif
        private void BGLoadAirports(object nothing)
        {
            // read airport list
            try
            {
                Utilities.Airports.ReadOurairports(Settings.GetRunningDirectory() +
                                                   "airports.csv");

                Utilities.Airports.checkdups = true;

                //Utilities.Airports.ReadOpenflights(Application.StartupPath + Path.DirectorySeparatorChar + "airports.dat");

                log.Info("Loaded " + Utilities.Airports.GetAirportCount + " airports");
            }
            catch
            {
            }
        }


        void adsb_UpdatePlanePosition(object sender, VPS.Utilities.adsb.PointLatLngAltHdg adsb)
        {
            lock (adsblock)
            {
                var id = adsb.Tag;

                if (MainV2.instance.adsbPlanes.ContainsKey(id))
                {
                    // update existing
                    ((adsb.PointLatLngAltHdg)instance.adsbPlanes[id]).Lat = adsb.Lat;
                    ((adsb.PointLatLngAltHdg)instance.adsbPlanes[id]).Lng = adsb.Lng;
                    ((adsb.PointLatLngAltHdg)instance.adsbPlanes[id]).Alt = adsb.Alt;
                    ((adsb.PointLatLngAltHdg)instance.adsbPlanes[id]).Heading = adsb.Heading;
                    ((adsb.PointLatLngAltHdg)instance.adsbPlanes[id]).Time = DateTime.Now;
                    ((adsb.PointLatLngAltHdg)instance.adsbPlanes[id]).CallSign = adsb.CallSign;
                    ((adsb.PointLatLngAltHdg)instance.adsbPlanes[id]).Squawk = adsb.Squawk;
                    ((adsb.PointLatLngAltHdg)instance.adsbPlanes[id]).Raw = adsb.Raw;
                    ((adsb.PointLatLngAltHdg)instance.adsbPlanes[id]).Speed = adsb.Speed;
                }
                else
                {
                    // create new plane
                    MainV2.instance.adsbPlanes[id] =
                        new adsb.PointLatLngAltHdg(adsb.Lat, adsb.Lng,
                                adsb.Alt, adsb.Heading, adsb.Speed, id,
                                DateTime.Now)
                        { CallSign = adsb.CallSign, Squawk = adsb.Squawk, Raw = adsb.Raw };
                }

                try
                {
                    // dont rebroadcast something that came from the drone
                    if (sender != null && sender is MAVLinkInterface)
                        return;

                    MAVLink.mavlink_adsb_vehicle_t packet = new MAVLink.mavlink_adsb_vehicle_t();

                    packet.altitude = (int)(MainV2.instance.adsbPlanes[id].Alt * 1000);
                    packet.altitude_type = (byte)MAVLink.ADSB_ALTITUDE_TYPE.GEOMETRIC;
                    packet.callsign = adsb.CallSign.MakeBytes();
                    packet.squawk = adsb.Squawk;
                    packet.emitter_type = (byte)MAVLink.ADSB_EMITTER_TYPE.NO_INFO;
                    packet.heading = (ushort)(MainV2.instance.adsbPlanes[id].Heading * 100);
                    packet.lat = (int)(MainV2.instance.adsbPlanes[id].Lat * 1e7);
                    packet.lon = (int)(MainV2.instance.adsbPlanes[id].Lng * 1e7);
                    packet.ICAO_address = uint.Parse(id, NumberStyles.HexNumber);

                    packet.flags = (ushort)(MAVLink.ADSB_FLAGS.VALID_ALTITUDE | MAVLink.ADSB_FLAGS.VALID_COORDS |
                        MAVLink.ADSB_FLAGS.VALID_HEADING | MAVLink.ADSB_FLAGS.VALID_CALLSIGN);

                    //send to current connected
                    MainV2.comPort.sendPacket(packet, MainV2.comPort.MAV.sysid, MainV2.comPort.MAV.compid);
                }
                catch
                {

                }
            }
        }


        private void ResetConnectionStats()
        {
            log.Info("Reset connection stats");
            // If the form has been closed, or never shown before, we need do nothing, as 
            // connection stats will be reset when shown
            if (this.connectionStatsForm != null && connectionStatsForm.Visible)
            {
                // else the form is already showing.  reset the stats
                this.connectionStatsForm.Controls.Clear();
                _connectionStats = new ConnectionStats(comPort);
                this.connectionStatsForm.Controls.Add(_connectionStats);
                ThemeManager.ApplyThemeTo(this.connectionStatsForm);
            }
        }

        private void ShowConnectionStatsForm()
        {
            if (this.connectionStatsForm == null || this.connectionStatsForm.IsDisposed)
            {
                // If the form has been closed, or never shown before, we need all new stuff
                this.connectionStatsForm = new Form
                {
                    Width = 430,
                    Height = 180,
                    MaximizeBox = false,
                    MinimizeBox = false,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = Strings.LinkStats
                };
                // Change the connection stats control, so that when/if the connection stats form is showing,
                // there will be something to see
                this.connectionStatsForm.Controls.Clear();
                _connectionStats = new ConnectionStats(comPort);
                this.connectionStatsForm.Controls.Add(_connectionStats);
                this.connectionStatsForm.Width = _connectionStats.Width;
            }

            this.connectionStatsForm.Show();
            ThemeManager.ApplyThemeTo(this.connectionStatsForm);
        }

        private void CMB_serialport_Click(object sender, EventArgs e)
        {
            string oldport = _connectionControl.CMB_serialport.Text;
            PopulateSerialportList();
            if (_connectionControl.CMB_serialport.Items.Contains(oldport))
                _connectionControl.CMB_serialport.Text = oldport;
        }

        private void PopulateSerialportList()
        {
            _connectionControl.CMB_serialport.Items.Clear();
            _connectionControl.CMB_serialport.Items.Add("AUTO");
            _connectionControl.CMB_serialport.Items.AddRange(SerialPort.GetPortNames());
            _connectionControl.CMB_serialport.Items.Add("TCP");
            _connectionControl.CMB_serialport.Items.Add("UDP");
            _connectionControl.CMB_serialport.Items.Add("UDPCl");
            _connectionControl.CMB_serialport.Items.Add("WS");
        }


        public void MenuSetup_Click(object sender, EventArgs e)
        {
            if (Settings.Instance.GetBoolean("password_protect") == false)
            {
                MyView.ShowScreen("HWConfig");
            }
            else
            {
                var pw = "";
                if (InputBox.Show("Enter Password", "Please enter your password", ref pw, true) ==
    System.Windows.Forms.DialogResult.OK)
                {
                    bool ans = Password.ValidatePassword(pw);

                    if (ans == false)
                    {
                        DevComponents.DotNetBar.MessageBoxEx.Show("Bad Password", "Bad Password");
                    }
                }

                if (Password.VerifyPassword(pw))
                {
                    MyView.ShowScreen("HWConfig");
                }
            }
        }

        private void MenuSimulation_Click(object sender, EventArgs e)
        {
            MyView.ShowScreen("Simulation");
        }

        private void MenuTuning_Click(object sender, EventArgs e)
        {
            if (Settings.Instance.GetBoolean("password_protect") == false)
            {
                MyView.ShowScreen("SWConfig");
            }
            else
            {
                var pw = "";
                if (InputBox.Show("Enter Password", "Please enter your password", ref pw, true) ==
    System.Windows.Forms.DialogResult.OK)
                {
                    bool ans = Password.ValidatePassword(pw);

                    if (ans == false)
                    {
                        DevComponents.DotNetBar.MessageBoxEx.Show("Bad Password", "Bad Password");
                    }
                }

                if (Password.VerifyPassword(pw))
                {
                    MyView.ShowScreen("SWConfig");
                }
            }
        }

        private void MenuTerminal_Click(object sender, EventArgs e)
        {
            MyView.ShowScreen("Terminal");
        }

        public void doDisconnect(MAVLinkInterface comPort)
        {
            log.Info("正在断开连接");
            try
            {
                if (speechEngine != null) // cancel all pending speech
                    speechEngine.SpeakAsyncCancelAll();

                comPort.BaseStream.DtrEnable = false;
                comPort.Close();
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

            // now that we have closed the connection, cancel the connection stats
            // so that the 'time connected' etc does not grow, but the user can still
            // look at the now frozen stats on the still open form
            try
            {
                // if terminal is used, then closed using this button.... exception
                if (this.connectionStatsForm != null)
                    ((ConnectionStats)this.connectionStatsForm.Controls[0]).StopUpdates();
            }
            catch
            {
            }

            // refresh config window if needed
            if (MyView.current != null)
            {
                if (MyView.current.Name == "HWConfig")
                    MyView.ShowScreen("HWConfig");
                if (MyView.current.Name == "SWConfig")
                    MyView.ShowScreen("SWConfig");
            }

            try
            {
                System.Threading.ThreadPool.QueueUserWorkItem((WaitCallback)delegate
               {
                   try
                   {
                       VPS.Log.LogSort.SortLogs(Directory.GetFiles(Settings.Instance.LogDir, "*.tlog"));
                   }
                   catch
                   {
                   }
               }
                    );
            }
            catch
            {
            }

            this.MenuConnect.Image = global::VPS.Properties.Resources.light_connect_icon;
        }

        public void doConnect(MAVLinkInterface comPort, string portname, string baud, bool getparams = true)
        {
            bool skipconnectcheck = false;
            log.Info("连接到 " + portname + " " + baud);
            switch (portname)
            {
                case "preset":
                    skipconnectcheck = true;
                    if (comPort.BaseStream is TcpSerial)
                        _connectionControl.CMB_serialport.Text = "TCP";
                    if (comPort.BaseStream is UdpSerial)
                        _connectionControl.CMB_serialport.Text = "UDP";
                    if (comPort.BaseStream is UdpSerialConnect)
                        _connectionControl.CMB_serialport.Text = "UDPCl";
                    if (comPort.BaseStream is SerialPort)
                    {
                        _connectionControl.CMB_serialport.Text = comPort.BaseStream.PortName;
                        _connectionControl.CMB_baudrate.Text = comPort.BaseStream.BaudRate.ToString();
                    }
                    break;
                case "TCP":
                    comPort.BaseStream = new TcpSerial();
                    _connectionControl.CMB_serialport.Text = "TCP";
                    break;
                case "UDP":
                    comPort.BaseStream = new UdpSerial();
                    _connectionControl.CMB_serialport.Text = "UDP";
                    break;
                case "WS":
                    comPort.BaseStream = new WebSocket();
                    _connectionControl.CMB_serialport.Text = "WS";
                    break;
                case "UDPCl":
                    comPort.BaseStream = new UdpSerialConnect();
                    _connectionControl.CMB_serialport.Text = "UDPCl";
                    break;
                case "AUTO":
                    // do autoscan
                    Comms.CommsSerialScan.Scan(true);
                    DateTime deadline = DateTime.Now.AddSeconds(50);
                    while (Comms.CommsSerialScan.foundport == false || Comms.CommsSerialScan.run == 1)
                    {
                        System.Threading.Thread.Sleep(500);
                        Console.WriteLine("wait for port " + CommsSerialScan.foundport + " or " + CommsSerialScan.run);
                        if (DateTime.Now > deadline)
                        {
                            DevComponents.DotNetBar.MessageBoxEx.Show(Strings.Timeout);
                            _connectionControl.IsConnected(false);
                            return;
                        }
                    }
                    return;
                default:
                    comPort.BaseStream = new SerialPort();
                    break;
            }

            // Tell the connection UI that we are now connected.
            _connectionControl.IsConnected(true);

            // Here we want to reset the connection stats counter etc.
            this.ResetConnectionStats();

            comPort.MAV.cs.ResetInternals();

            //cleanup any log being played
            comPort.logreadmode = false;
            if (comPort.logplaybackfile != null)
                comPort.logplaybackfile.Close();
            comPort.logplaybackfile = null;

            try
            {
                log.Info("Set Portname");
                // set port, then options
                if (portname.ToLower() != "preset")
                    comPort.BaseStream.PortName = portname;

                log.Info("Set Baudrate");
                try
                {
                    if (baud != "" && baud != "0")
                        comPort.BaseStream.BaudRate = int.Parse(baud);
                }
                catch (Exception exp)
                {
                    log.Error(exp);
                }

                // prevent serialreader from doing anything
                comPort.giveComport = true;

                log.Info("About to do dtr if needed");
                // reset on connect logic.
                if (Settings.Instance.GetBoolean("CHK_resetapmonconnect") == true)
                {
                    log.Info("set dtr rts to false");
                    comPort.BaseStream.DtrEnable = false;
                    comPort.BaseStream.RtsEnable = false;

                    comPort.BaseStream.toggleDTR();
                }

                comPort.giveComport = false;

                // setup to record new logs
                try
                {
                    Directory.CreateDirectory(Settings.Instance.LogDir);
                    lock (this)
                    {
                        // create log names
                        var dt = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
                        var tlog = Settings.Instance.LogDir + Path.DirectorySeparatorChar +
                                   dt + ".tlog";
                        var rlog = Settings.Instance.LogDir + Path.DirectorySeparatorChar +
                                   dt + ".rlog";

                        // check if this logname already exists
                        int a = 1;
                        while (File.Exists(tlog))
                        {
                            Thread.Sleep(1000);
                            // create new names with a as an index
                            dt = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + "-" + a.ToString();
                            tlog = Settings.Instance.LogDir + Path.DirectorySeparatorChar +
                                   dt + ".tlog";
                            rlog = Settings.Instance.LogDir + Path.DirectorySeparatorChar +
                                   dt + ".rlog";
                        }

                        //open the logs for writing
                        comPort.logfile =
                            new BufferedStream(File.Open(tlog, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.None));
                        comPort.rawlogfile =
                            new BufferedStream(File.Open(rlog, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.None));
                        log.Info("creating logfile " + dt + ".tlog");
                    }
                }
                catch (Exception exp2)
                {
                    log.Error(exp2);
                    DevComponents.DotNetBar.MessageBoxEx.Show(Strings.Failclog);
                } // soft fail

                // reset connect time - for timeout functions
                connecttime = DateTime.Now;

                // do the connect
                comPort.Open(false, skipconnectcheck);

                if (!comPort.BaseStream.IsOpen)
                {
                    log.Info("comport is closed. existing connect");
                    try
                    {
                        _connectionControl.IsConnected(false);
                        UpdateConnectIcon();
                        comPort.Close();
                    }
                    catch
                    {
                    }
                    return;
                }

                if (getparams)
                {
                    var ftpfile = false;
                    if ((MainV2.comPort.MAV.cs.capabilities & (int)MAVLink.MAV_PROTOCOL_CAPABILITY.FTP) > 0)
                    {
                        var prd = new ProgressReporterDialogue();
                        prd.DoWork += (IProgressReporterDialogue sender) =>
                        {
                            sender.UpdateProgressAndStatus(-1, "Checking for Param MAVFTP");
                            var cancel = new CancellationTokenSource();
                            var paramfileTask = Task.Run<MemoryStream>(() =>
                            {
                                return new MAVFtp(comPort, comPort.MAV.sysid, comPort.MAV.compid).GetFile(
                                    "@PARAM/param.pck", cancel, false, 110);
                            });
                            while (!paramfileTask.IsCompleted)
                            {
                                if (sender.doWorkArgs.CancelRequested)
                                {
                                    cancel.Cancel();
                                    sender.doWorkArgs.CancelAcknowledged = true;
                                }
                            }

                            var paramfile = paramfileTask.Result;
                            if (paramfile != null && paramfile.Length > 0)
                            {
                                var mavlist = parampck.unpack(paramfile.GetBuffer());
                                if (mavlist != null)
                                {
                                    comPort.MAVlist[comPort.MAV.sysid, comPort.MAV.compid].param.Clear();
                                    comPort.MAVlist[comPort.MAV.sysid, comPort.MAV.compid].param.TotalReported =
                                        mavlist.Count;
                                    comPort.MAVlist[comPort.MAV.sysid, comPort.MAV.compid].param.AddRange(mavlist);
                                    var gen = new MAVLink.MavlinkParse();
                                    mavlist.ForEach(a =>
                                    {
                                        comPort.MAVlist[comPort.MAV.sysid, comPort.MAV.compid].param_types[a.Name] =
                                            a.Type;
                                        MainV2.comPort.SaveToTlog(gen.GenerateMAVLinkPacket10(
                                            MAVLink.MAVLINK_MSG_ID.PARAM_VALUE,
                                            new MAVLink.mavlink_param_value_t(a.float_value, (ushort)mavlist.Count, 0,
                                                a.Name.MakeBytesSize(16), (byte)a.Type)));
                                    });

                                    ftpfile = true;
                                }
                            }
                        };

                        prd.RunBackgroundOperationAsync();
                    }

                    if (!ftpfile)
                    {
                        if (Settings.Instance.GetBoolean("Params_BG", false))
                            Task.Run(() => { comPort.getParamList(comPort.MAV.sysid, comPort.MAV.compid); });
                        else
                            comPort.getParamList();
                    }
                }

                _connectionControl.UpdateSysIDS();

                // check for newer firmware
                var softwares = Firmware.LoadSoftwares();

                if (softwares.Count > 0)
                {
                    try
                    {
                        string[] fields1 = comPort.MAV.VersionString.Split(' ');

                        foreach (Firmware.software item in softwares)
                        {
                            string[] fields2 = item.name.Split(' ');

                            // check primare firmware type. ie arudplane, arducopter
                            if (fields1[0] == fields2[0])
                            {
                                Version ver1 = VersionDetection.GetVersion(comPort.MAV.VersionString);
                                Version ver2 = VersionDetection.GetVersion(item.name);

                                if (ver2 > ver1)
                                {
                                    Common.MessageShowAgain(Strings.NewFirmware + "-" + item.name,
                                        Strings.NewFirmwareA + item.name + Strings.Pleaseup +
                                        "[link;https://discuss.ardupilot.org/tags/stable-release;Release Notes]");
                                    break;
                                }

                                // check the first hit only
                                break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                    }
                }

                FlightData.CheckBatteryShow();

                // save the baudrate for this port
                Settings.Instance[_connectionControl.CMB_serialport.Text + "_BAUD"] = _connectionControl.CMB_baudrate.Text;

                //this.Text = titlebar + " " + comPort.MAV.VersionString;

                // refresh config window if needed
                if (MyView.current != null)
                {
                    if (MyView.current.Name == "HWConfig")
                        MyView.ShowScreen("HWConfig");
                    if (MyView.current.Name == "SWConfig")
                        MyView.ShowScreen("SWConfig");
                }

                // load wps on connect option.
                if (Settings.Instance.GetBoolean("loadwpsonconnect") == true)
                {
                    // only do it if we are connected.
                    if (comPort.BaseStream.IsOpen)
                    {
                        FlightPlannerShow();
                    }
                }

                // get any rallypoints
                if (MainV2.comPort.MAV.param.ContainsKey("RALLY_TOTAL") &&
                    int.Parse(MainV2.comPort.MAV.param["RALLY_TOTAL"].ToString()) > 0)
                {
                    try
                    {
                        FlightPlanner.getRallyPointsToolStripMenuItem_Click(null, null);

                        double maxdist = 0;

                        foreach (var rally in comPort.MAV.rallypoints)
                        {
                            foreach (var rally1 in comPort.MAV.rallypoints)
                            {
                                var pnt1 = new PointLatLngAlt(rally.Value.y / 10000000.0f, rally.Value.x / 10000000.0f);
                                var pnt2 = new PointLatLngAlt(rally1.Value.y / 10000000.0f,
                                    rally1.Value.x / 10000000.0f);

                                var dist = pnt1.GetDistance(pnt2);

                                maxdist = Math.Max(maxdist, dist);
                            }
                        }

                        if (comPort.MAV.param.ContainsKey("RALLY_LIMIT_KM") &&
                            (maxdist / 1000.0) > (float)comPort.MAV.param["RALLY_LIMIT_KM"])
                        {
                            DevComponents.DotNetBar.MessageBoxEx.Show(Strings.Warningrallypointdistance + " " +
                                                  (maxdist / 1000.0).ToString("0.00") + " > " +
                                                  (float)comPort.MAV.param["RALLY_LIMIT_KM"]);
                        }
                    }
                    catch (Exception ex) { log.Warn(ex); }
                }

                // get any fences
                if (MainV2.comPort.MAV.param.ContainsKey("FENCE_TOTAL") &&
                    int.Parse(MainV2.comPort.MAV.param["FENCE_TOTAL"].ToString()) > 1 &&
                    MainV2.comPort.MAV.param.ContainsKey("FENCE_ACTION"))
                {
                    try
                    {
                        FlightPlanner.GeoFencedownloadToolStripMenuItem_Click(null, null);
                    }
                    catch (Exception ex) { log.Warn(ex); }
                }
                //Add HUD custom items source 
                HUD.Custom.src = MainV2.comPort.MAV.cs;

                // set connected icon
            }
            catch (Exception ex)
            {
                log.Warn(ex);
                try
                {
                    _connectionControl.IsConnected(false);
                    UpdateConnectIcon();
                    comPort.Close();
                }
                catch (Exception ex2)
                {
                    log.Warn(ex2);
                }
                DevComponents.DotNetBar.MessageBoxEx.Show("Can not establish a connection\n\n" + ex.Message);
                return;
            }
        }

        private void MenuConnect_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void Connect()
        {
            comPort.giveComport = false;

            log.Info("MenuConnect Start");

            // sanity check
            if (comPort.BaseStream.IsOpen && comPort.MAV.cs.groundspeed > 4)
            {
                if (DialogResult.No ==
                    DevComponents.DotNetBar.MessageBoxEx.Show(Strings.Stillmoving, Strings.Disconnect, MessageBoxButtons.YesNo))
                {
                    return;
                }
            }

            try
            {
                log.Info("Cleanup last logfiles");
                // cleanup from any previous sessions
                if (comPort.logfile != null)
                    comPort.logfile.Close();

                if (comPort.rawlogfile != null)
                    comPort.rawlogfile.Close();
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show(Strings.ErrorClosingLogFile + ex.Message, Strings.ERROR);
            }

            comPort.logfile = null;
            comPort.rawlogfile = null;

            // decide if this is a connect or disconnect
            if (comPort.BaseStream.IsOpen)
            {
                doDisconnect(comPort);
            }
            else
            {
                doConnect(comPort, _connectionControl.CMB_serialport.Text, _connectionControl.CMB_baudrate.Text);
            }

            _connectionControl.UpdateSysIDS();

            if (comPort.BaseStream.IsOpen)
                loadph_serial();
        }

        void loadph_serial()
        {
            try
            {
                if (comPort.MAV.SerialString == "")
                    return;

                if (comPort.MAV.SerialString.Contains("CubeBlack") && !comPort.MAV.SerialString.Contains("CubeBlack+") &&
                    comPort.MAV.param.ContainsKey("INS_ACC3_ID") && comPort.MAV.param["INS_ACC3_ID"].Value == 0 &&
                    comPort.MAV.param.ContainsKey("INS_GYR3_ID") && comPort.MAV.param["INS_GYR3_ID"].Value == 0 &&
                    comPort.MAV.param.ContainsKey("INS_ENABLE_MASK") && comPort.MAV.param["INS_ENABLE_MASK"].Value >= 7)
                {
                    VPS.Controls.SB.Show("Param Scan");
                }
            }
            catch { }

            try
            {
                if (comPort.MAV.SerialString == "")
                    return;

                // brd type should be 3
                // devids show which sensor is not detected
                // baro does not list a devid

                //devop read spi lsm9ds0_ext_am 0 0 0x8f 1
                if (comPort.MAV.SerialString.Contains("CubeBlack") && !comPort.MAV.SerialString.Contains("CubeBlack+"))
                {
                    Task.Run(() =>
                        {
                            bool bad1 = false;
                            byte[] data = new byte[0];

                            comPort.device_op(comPort.MAV.sysid, comPort.MAV.compid, out data,
                                MAVLink.DEVICE_OP_BUSTYPE.SPI,
                                "lsm9ds0_ext_g", 0, 0, 0x8f, 1);
                            if (data.Length != 0 && (data[0] != 0xd4 && data[0] != 0xd7))
                                bad1 = true;

                            comPort.device_op(comPort.MAV.sysid, comPort.MAV.compid, out data,
                                MAVLink.DEVICE_OP_BUSTYPE.SPI,
                                "lsm9ds0_ext_am", 0, 0, 0x8f, 1);
                            if (data.Length != 0 && data[0] != 0x49)
                                bad1 = true;

                            if (bad1)
                                this.BeginInvoke(method: (Action)delegate
                               {
                                   VPS.Controls.SB.Show("SPI Scan");
                               });
                        });
                }

            }
            catch { }
        }

        private void CMB_serialport_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_connectionControl.CMB_serialport.SelectedItem == _connectionControl.CMB_serialport.Text)
                return;

            comPortName = _connectionControl.CMB_serialport.Text;
            if (comPortName == "UDP" || comPortName == "UDPCl" || comPortName == "TCP" || comPortName == "AUTO")
            {
                _connectionControl.CMB_baudrate.Enabled = false;
            }
            else
            {
                _connectionControl.CMB_baudrate.Enabled = true;
            }

            try
            {
                // check for saved baud rate and restore
                if (Settings.Instance[_connectionControl.CMB_serialport.Text + "_BAUD"] != null)
                {
                    _connectionControl.CMB_baudrate.Text =
                        Settings.Instance[_connectionControl.CMB_serialport.Text + "_BAUD"];
                }
            }
            catch
            {
            }
        }


        /// <summary>
        /// overriding the OnCLosing is a bit cleaner than handling the event, since it 
        /// is this object.
        /// 
        /// This happens before FormClosed
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            log.Info("MainV2_FormClosing");

            log.Info("GMaps write cache");
            // speed up tile saving on exit
            GMap.NET.GMaps.Instance.CacheOnIdleRead = false;
            GMap.NET.GMaps.Instance.BoostCacheEngine = true;



            Settings.Instance["MainHeight"] = this.Height.ToString();
            Settings.Instance["MainWidth"] = this.Width.ToString();
            Settings.Instance["MainMaximised"] = this.WindowState.ToString();

            Settings.Instance["MainLocX"] = this.Location.X.ToString();
            Settings.Instance["MainLocY"] = this.Location.Y.ToString();

            log.Info("close logs");
            AltitudeAngel.Dispose();

            // close bases connection
            try
            {
                comPort.logreadmode = false;
                if (comPort.logfile != null)
                    comPort.logfile.Close();

                if (comPort.rawlogfile != null)
                    comPort.rawlogfile.Close();

                comPort.logfile = null;
                comPort.rawlogfile = null;
            }
            catch
            {
            }

            log.Info("close ports");
            // close all connections
            foreach (var port in Comports)
            {
                try
                {
                    port.logreadmode = false;
                    if (port.logfile != null)
                        port.logfile.Close();

                    if (port.rawlogfile != null)
                        port.rawlogfile.Close();

                    port.logfile = null;
                    port.rawlogfile = null;
                }
                catch
                {
                }
            }

            log.Info("stop adsb");
            Utilities.adsb.Stop();

            log.Info("stop WarningEngine");
            Warnings.WarningEngine.Stop();

            log.Info("stop GStreamer");
            GStreamer.StopAll();

            log.Info("closing vlcrender");
            try
            {
                while (vlcrender.store.Count > 0)
                    vlcrender.store[0].Stop();
            }
            catch
            {
            }

            log.Info("closing pluginthread");

            pluginthreadrun = false;

            if (pluginthread != null)
            {
                try
                {
                    while (!PluginThreadrunner.WaitOne(100)) Application.DoEvents();
                } catch { }
                pluginthread.Join();
            }

            log.Info("closing serialthread");

            serialThread = false;

            if (serialreaderthread != null)
                serialreaderthread.Join();

            log.Info("closing joystickthread");

            joystickthreadrun = false;

            if (joystickthread != null)
                joystickthread.Join();

            log.Info("closing httpthread");

            // if we are waiting on a socket we need to force an abort
            httpserver.Stop();

            log.Info("sorting tlogs");
            try
            {
                System.Threading.ThreadPool.QueueUserWorkItem((WaitCallback)delegate
                   {
                       try
                       {
                           VPS.Log.LogSort.SortLogs(Directory.GetFiles(Settings.Instance.LogDir, "*.tlog"));
                       }
                       catch
                       {
                       }
                   }
                );
            }
            catch
            {
            }

            log.Info("closing MyView");

            // close all tabs
            MyView.Dispose();

            log.Info("closing fd");
            try
            {
                FlightData.Dispose();
            }
            catch
            {
            }
            log.Info("closing fp");
            try
            {
                FlightPlanner.Dispose();
            }
            catch
            {
            }
            //log.Info("closing sim");
            //try
            //{
            //    Simulation.Dispose();
            //}
            //catch
            //{
            //}

            try
            {
                if (comPort.BaseStream.IsOpen)
                    comPort.Close();
            }
            catch
            {
            } // i get alot of these errors, the port is still open, but not valid - user has unpluged usb

            CustomData.WP.WPGlobalData.instance.SaveConfig();

            var markers = VPS.Maps.GMapMarkerStyle.GetGMapMarkerStyles();

            string MarkerStyle = "{";
            for (int i = 0; i < markers.Count; i++)
            {
                MarkerStyle += markers[i].Key + ":" + CustomData.WP.Convert.ToString(markers[i].Value) + ";";
            }
            MarkerStyle += "}";
            Settings.Instance["Style_MarkerStyle"] = MarkerStyle;

            var lines = VPS.Maps.GMapOverlayStyle.GetGMapOverlayStyles();
            string LineStyle = "{";
            for (int i = 0; i < lines.Count; i++)
            {
                LineStyle += lines[i].Key + ":" + CustomData.WP.Convert.ToString(lines[i].Value) + ";";
            }
            LineStyle += "}";
            Settings.Instance["Style_LineStyle"] = LineStyle;

            // save config
            SaveConfig();

            Console.WriteLine(httpthread?.IsAlive);
            Console.WriteLine(joystickthread?.IsAlive);
            Console.WriteLine(serialreaderthread?.IsAlive);
            Console.WriteLine(pluginthread?.IsAlive);

            log.Info("MainV2_FormClosing done");

            if (MONO)
                this.Dispose();
        }


        /// <summary>
        /// this happens after FormClosing...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            Console.WriteLine("MainV2_FormClosed");

            if (joystick != null)
            {
                while (!joysendThreadExited)
                    Thread.Sleep(10);

                joystick.Dispose(); //proper clean up of joystick.
            }
        }

        private void LoadConfig()
        {
            try
            {
                log.Info("Loading config");

                Settings.Instance.Load();

                comPortName = Settings.Instance.ComPort;
            }
            catch (Exception ex)
            {
                log.Error("Bad Config File", ex);
            }
        }

        private void SaveConfig()
        {
            try
            {
                log.Info("Saving config");
                Settings.Instance.ComPort = comPortName;

                if (_connectionControl != null)
                    Settings.Instance.BaudRate = _connectionControl.CMB_baudrate.Text;

                Settings.Instance.APMFirmware = MainV2.comPort.MAV.cs.firmware.ToString();

                Settings.Instance.Save();
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show(ex.ToString());
            }
        }

        /// <summary>
        /// needs to be true by default so that exits properly if no joystick used.
        /// </summary>
        volatile private bool joysendThreadExited = true;

        /// <summary>
        /// thread used to send joystick packets to the MAV
        /// </summary>
        private void joysticksend()
        {
            float rate = 50; // 1000 / 50 = 20 hz
            int count = 0;

            DateTime lastratechange = DateTime.Now;

            joystickthreadrun = true;

            while (joystickthreadrun)
            {
                joysendThreadExited = false;
                //so we know this thread is stil alive.           
                try
                {
                    if (MONO)
                    {
                        log.Error("Mono: closing joystick thread");
                        break;
                    }

                    if (!MONO)
                    {
                        //joystick stuff

                        if (joystick != null && joystick.enabled)
                        {
                            if (!joystick.manual_control)
                            {
                                MAVLink.mavlink_rc_channels_override_t rc = new MAVLink.mavlink_rc_channels_override_t();

                                rc.target_component = comPort.MAV.compid;
                                rc.target_system = comPort.MAV.sysid;

                                if (joystick.getJoystickAxis(1) == Joystick.Joystick.joystickaxis.None) rc.chan1_raw = ushort.MaxValue;
                                if (joystick.getJoystickAxis(2) == Joystick.Joystick.joystickaxis.None) rc.chan2_raw = ushort.MaxValue;
                                if (joystick.getJoystickAxis(3) == Joystick.Joystick.joystickaxis.None) rc.chan3_raw = ushort.MaxValue;
                                if (joystick.getJoystickAxis(4) == Joystick.Joystick.joystickaxis.None) rc.chan4_raw = ushort.MaxValue;
                                if (joystick.getJoystickAxis(5) == Joystick.Joystick.joystickaxis.None) rc.chan5_raw = ushort.MaxValue;
                                if (joystick.getJoystickAxis(6) == Joystick.Joystick.joystickaxis.None) rc.chan6_raw = ushort.MaxValue;
                                if (joystick.getJoystickAxis(7) == Joystick.Joystick.joystickaxis.None) rc.chan7_raw = ushort.MaxValue;
                                if (joystick.getJoystickAxis(8) == Joystick.Joystick.joystickaxis.None) rc.chan8_raw = ushort.MaxValue;
                                if (joystick.getJoystickAxis(9) == Joystick.Joystick.joystickaxis.None) rc.chan9_raw = (ushort)0;
                                if (joystick.getJoystickAxis(10) == Joystick.Joystick.joystickaxis.None) rc.chan10_raw = (ushort)0;
                                if (joystick.getJoystickAxis(11) == Joystick.Joystick.joystickaxis.None) rc.chan11_raw = (ushort)0;
                                if (joystick.getJoystickAxis(12) == Joystick.Joystick.joystickaxis.None) rc.chan12_raw = (ushort)0;
                                if (joystick.getJoystickAxis(13) == Joystick.Joystick.joystickaxis.None) rc.chan13_raw = (ushort)0;
                                if (joystick.getJoystickAxis(14) == Joystick.Joystick.joystickaxis.None) rc.chan14_raw = (ushort)0;
                                if (joystick.getJoystickAxis(15) == Joystick.Joystick.joystickaxis.None) rc.chan15_raw = (ushort)0;
                                if (joystick.getJoystickAxis(16) == Joystick.Joystick.joystickaxis.None) rc.chan16_raw = (ushort)0;
                                if (joystick.getJoystickAxis(17) == Joystick.Joystick.joystickaxis.None) rc.chan17_raw = (ushort)0;
                                if (joystick.getJoystickAxis(18) == Joystick.Joystick.joystickaxis.None) rc.chan18_raw = (ushort)0;

                                if (joystick.getJoystickAxis(1) != Joystick.Joystick.joystickaxis.None) rc.chan1_raw = (ushort)MainV2.comPort.MAV.cs.rcoverridech1;
                                if (joystick.getJoystickAxis(2) != Joystick.Joystick.joystickaxis.None) rc.chan2_raw = (ushort)MainV2.comPort.MAV.cs.rcoverridech2;
                                if (joystick.getJoystickAxis(3) != Joystick.Joystick.joystickaxis.None) rc.chan3_raw = (ushort)MainV2.comPort.MAV.cs.rcoverridech3;
                                if (joystick.getJoystickAxis(4) != Joystick.Joystick.joystickaxis.None) rc.chan4_raw = (ushort)MainV2.comPort.MAV.cs.rcoverridech4;
                                if (joystick.getJoystickAxis(5) != Joystick.Joystick.joystickaxis.None) rc.chan5_raw = (ushort)MainV2.comPort.MAV.cs.rcoverridech5;
                                if (joystick.getJoystickAxis(6) != Joystick.Joystick.joystickaxis.None) rc.chan6_raw = (ushort)MainV2.comPort.MAV.cs.rcoverridech6;
                                if (joystick.getJoystickAxis(7) != Joystick.Joystick.joystickaxis.None) rc.chan7_raw = (ushort)MainV2.comPort.MAV.cs.rcoverridech7;
                                if (joystick.getJoystickAxis(8) != Joystick.Joystick.joystickaxis.None) rc.chan8_raw = (ushort)MainV2.comPort.MAV.cs.rcoverridech8;
                                if (joystick.getJoystickAxis(9) != Joystick.Joystick.joystickaxis.None) rc.chan9_raw = (ushort)MainV2.comPort.MAV.cs.rcoverridech9;
                                if (joystick.getJoystickAxis(10) != Joystick.Joystick.joystickaxis.None) rc.chan10_raw = (ushort)MainV2.comPort.MAV.cs.rcoverridech10;
                                if (joystick.getJoystickAxis(11) != Joystick.Joystick.joystickaxis.None) rc.chan11_raw = (ushort)MainV2.comPort.MAV.cs.rcoverridech11;
                                if (joystick.getJoystickAxis(12) != Joystick.Joystick.joystickaxis.None) rc.chan12_raw = (ushort)MainV2.comPort.MAV.cs.rcoverridech12;
                                if (joystick.getJoystickAxis(13) != Joystick.Joystick.joystickaxis.None) rc.chan13_raw = (ushort)MainV2.comPort.MAV.cs.rcoverridech13;
                                if (joystick.getJoystickAxis(14) != Joystick.Joystick.joystickaxis.None) rc.chan14_raw = (ushort)MainV2.comPort.MAV.cs.rcoverridech14;
                                if (joystick.getJoystickAxis(15) != Joystick.Joystick.joystickaxis.None) rc.chan15_raw = (ushort)MainV2.comPort.MAV.cs.rcoverridech15;
                                if (joystick.getJoystickAxis(16) != Joystick.Joystick.joystickaxis.None) rc.chan16_raw = (ushort)MainV2.comPort.MAV.cs.rcoverridech16;
                                if (joystick.getJoystickAxis(17) != Joystick.Joystick.joystickaxis.None) rc.chan17_raw = (ushort)MainV2.comPort.MAV.cs.rcoverridech17;
                                if (joystick.getJoystickAxis(18) != Joystick.Joystick.joystickaxis.None) rc.chan18_raw = (ushort)MainV2.comPort.MAV.cs.rcoverridech18;

                                if (lastjoystick.AddMilliseconds(rate) < DateTime.Now)
                                {
                                    /*
                                if (MainV2.comPort.MAV.cs.rssi > 0 && MainV2.comPort.MAV.cs.remrssi > 0)
                                {
                                    if (lastratechange.Second != DateTime.Now.Second)
                                    {
                                        if (MainV2.comPort.MAV.cs.txbuffer > 90)
                                        {
                                            if (rate < 20)
                                                rate = 21;
                                            rate--;

                                            if (MainV2.comPort.MAV.cs.linkqualitygcs < 70)
                                                rate = 50;
                                        }
                                        else
                                        {
                                            if (rate > 100)
                                                rate = 100;
                                            rate++;
                                        }

                                        lastratechange = DateTime.Now;
                                    }
                                 
                                }
                                */
                                    //                                Console.WriteLine(DateTime.Now.Millisecond + " {0} {1} {2} {3} {4}", rc.chan1_raw, rc.chan2_raw, rc.chan3_raw, rc.chan4_raw,rate);

                                    //Console.WriteLine("Joystick btw " + comPort.BaseStream.BytesToWrite);

                                    if (!comPort.BaseStream.IsOpen)
                                        continue;

                                    if (comPort.BaseStream.BytesToWrite < 50)
                                    {
                                        if (sitl)
                                        {
                                            VPS.GCSViews.SITL.rcinput();
                                        }
                                        else
                                        {
                                            comPort.sendPacket(rc, rc.target_system, rc.target_component);
                                        }
                                        count++;
                                        lastjoystick = DateTime.Now;
                                    }
                                }
                            }
                            else
                            {
                                MAVLink.mavlink_manual_control_t rc = new MAVLink.mavlink_manual_control_t();

                                rc.target = comPort.MAV.compid;

                                if (joystick.getJoystickAxis(1) != Joystick.Joystick.joystickaxis.None)
                                    rc.x = MainV2.comPort.MAV.cs.rcoverridech1;
                                if (joystick.getJoystickAxis(2) != Joystick.Joystick.joystickaxis.None)
                                    rc.y = MainV2.comPort.MAV.cs.rcoverridech2;
                                if (joystick.getJoystickAxis(3) != Joystick.Joystick.joystickaxis.None)
                                    rc.z = MainV2.comPort.MAV.cs.rcoverridech3;
                                if (joystick.getJoystickAxis(4) != Joystick.Joystick.joystickaxis.None)
                                    rc.r = MainV2.comPort.MAV.cs.rcoverridech4;

                                if (lastjoystick.AddMilliseconds(rate) < DateTime.Now)
                                {
                                    if (!comPort.BaseStream.IsOpen)
                                        continue;

                                    if (comPort.BaseStream.BytesToWrite < 50)
                                    {
                                        if (sitl)
                                        {
                                            VPS.GCSViews.SITL.rcinput();
                                        }
                                        else
                                        {
                                            comPort.sendPacket(rc, comPort.MAV.sysid, comPort.MAV.compid);
                                        }
                                        count++;
                                        lastjoystick = DateTime.Now;
                                    }
                                }
                            }
                        }
                    }
                    Thread.Sleep(20);
                }
                catch
                {
                } // cant fall out
            }
            joysendThreadExited = true; //so we know this thread exited.    
        }

        /// <summary>
        /// Used to fix the icon status for unexpected unplugs etc...
        /// </summary>
        private void UpdateConnectIcon()
        {
            if ((DateTime.Now - connectButtonUpdate).Milliseconds > 500)
            {
                //                        Console.WriteLine(DateTime.Now.Millisecond);
                if (comPort.BaseStream.IsOpen)
                {
                    if (this.MenuConnect.Image == null || (string)this.MenuConnect.Image.Tag != "Disconnect")
                    {
                        this.BeginInvoke((MethodInvoker)delegate
                       {
                           this.MenuConnect.Image.Tag = "Disconnect";
                           this.MenuConnect.Text = Strings.DISCONNECTc;
                           _connectionControl.IsConnected(true);
                       });
                    }
                }
                else
                {
                    if (this.MenuConnect.Image != null && (string)this.MenuConnect.Image.Tag != "Connect")
                    {
                        this.BeginInvoke((MethodInvoker)delegate
                       {
                           this.MenuConnect.Image.Tag = "Connect";
                           this.MenuConnect.Text = Strings.CONNECTc;
                           _connectionControl.IsConnected(false);
                           if (_connectionStats != null)
                           {
                               _connectionStats.StopUpdates();
                           }
                       });
                    }

                    if (comPort.logreadmode)
                    {
                        this.BeginInvoke((MethodInvoker)delegate { _connectionControl.IsConnected(true); });
                    }
                }
                connectButtonUpdate = DateTime.Now;
            }
        }

        ManualResetEvent PluginThreadrunner = new ManualResetEvent(false);

        private void PluginThread()
        {
            Hashtable nextrun = new Hashtable();

            pluginthreadrun = true;

            PluginThreadrunner.Reset();

            while (pluginthreadrun)
            {
                try
                {
                    foreach (var plugin in Plugin.PluginLoader.Plugins.ToArray())
                    {
                        if (!nextrun.ContainsKey(plugin))
                            nextrun[plugin] = DateTime.MinValue;

                        if (DateTime.Now > plugin.NextRun)
                        {
                            // get ms till next run
                            int msnext = (int)(1000 / plugin.loopratehz);
                            // allow the plug to modify this, if needed
                            plugin.NextRun = DateTime.Now.AddMilliseconds(msnext);

                            try
                            {
                                bool ans = plugin.Loop();
                            }
                            catch (Exception ex)
                            {
                                log.Error(ex);
                            }
                        }
                    }
                }
                catch
                {
                }

                // max rate is 100 hz - prevent massive cpu usage
                System.Threading.Thread.Sleep(10);
            }

            while (Plugin.PluginLoader.Plugins.Count > 0)
            {
                var plugin = Plugin.PluginLoader.Plugins[0];
                try
                {
                    plugin.Exit();
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                }
                Plugin.PluginLoader.Plugins.Remove(plugin);
            }
            try
            {
                PluginThreadrunner.Set();
            }
            catch { }

            return;
        }

        ManualResetEvent SerialThreadrunner = new ManualResetEvent(false);

        /// <summary>
        /// main serial reader thread
        /// controls
        /// serial reading
        /// link quality stats
        /// speech voltage - custom - alt warning - data lost
        /// heartbeat packet sending
        /// 
        /// and can't fall out
        /// </summary>
        private async void SerialReader()
        {
            if (serialThread == true)
                return;
            serialThread = true;

            SerialThreadrunner.Reset();

            int minbytes = 10;

            int altwarningmax = 0;

            bool armedstatus = false;

            string lastmessagehigh = "";

            DateTime speechcustomtime = DateTime.Now;

            DateTime speechlowspeedtime = DateTime.Now;

            DateTime linkqualitytime = DateTime.Now;

            while (serialThread)
            {
                try
                {
                    Thread.Sleep(1); // was 5

                    try
                    {
                        if (GCSViews.ConfigTerminal.comPort is MAVLinkSerialPort)
                        {
                        }
                        else
                        {
                            if (GCSViews.ConfigTerminal.comPort != null && GCSViews.ConfigTerminal.comPort.IsOpen)
                                continue;
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                    }

                    // update connect/disconnect button and info stats
                    try
                    {
                        UpdateConnectIcon();
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                    }

                    // 30 seconds interval speech options
                    if (speechEnable && speechEngine != null && (DateTime.Now - speechcustomtime).TotalSeconds > 30 &&
                        (MainV2.comPort.logreadmode || comPort.BaseStream.IsOpen))
                    {
                        if (MainV2.speechEngine.IsReady)
                        {
                            if (Settings.Instance.GetBoolean("speechcustomenabled"))
                            {
                                MainV2.speechEngine.SpeakAsync(ArduPilot.Common.speechConversion(comPort.MAV, "" + Settings.Instance["speechcustom"]));
                            }

                            speechcustomtime = DateTime.Now;
                        }

                        // speech for battery alerts
                        //speechbatteryvolt
                        float warnvolt = Settings.Instance.GetFloat("speechbatteryvolt");
                        float warnpercent = Settings.Instance.GetFloat("speechbatterypercent");

                        if (Settings.Instance.GetBoolean("speechbatteryenabled") == true &&
                            MainV2.comPort.MAV.cs.battery_voltage <= warnvolt &&
                            MainV2.comPort.MAV.cs.battery_voltage >= 5.0)
                        {
                            if (MainV2.speechEngine.IsReady)
                            {
                                MainV2.speechEngine.SpeakAsync(ArduPilot.Common.speechConversion(comPort.MAV, "" + Settings.Instance["speechbattery"]));
                            }
                        }
                        else if (Settings.Instance.GetBoolean("speechbatteryenabled") == true &&
                                 (MainV2.comPort.MAV.cs.battery_remaining) < warnpercent &&
                                 MainV2.comPort.MAV.cs.battery_voltage >= 5.0 &&
                                 MainV2.comPort.MAV.cs.battery_remaining != 0.0)
                        {
                            if (MainV2.speechEngine.IsReady)
                            {
                                MainV2.speechEngine.SpeakAsync(
                                    ArduPilot.Common.speechConversion(comPort.MAV, "" + Settings.Instance["speechbattery"]));
                            }
                        }
                    }

                    // speech for airspeed alerts
                    if (speechEnable && speechEngine != null && (DateTime.Now - speechlowspeedtime).TotalSeconds > 10 &&
                        (MainV2.comPort.logreadmode || comPort.BaseStream.IsOpen))
                    {
                        if (Settings.Instance.GetBoolean("speechlowspeedenabled") == true && MainV2.comPort.MAV.cs.armed)
                        {
                            float warngroundspeed = Settings.Instance.GetFloat("speechlowgroundspeedtrigger");
                            float warnairspeed = Settings.Instance.GetFloat("speechlowairspeedtrigger");

                            if (MainV2.comPort.MAV.cs.airspeed < warnairspeed)
                            {
                                if (MainV2.speechEngine.IsReady)
                                {
                                    MainV2.speechEngine.SpeakAsync(
                                        ArduPilot.Common.speechConversion(comPort.MAV, "" + Settings.Instance["speechlowairspeed"]));
                                    speechlowspeedtime = DateTime.Now;
                                }
                            }
                            else if (MainV2.comPort.MAV.cs.groundspeed < warngroundspeed)
                            {
                                if (MainV2.speechEngine.IsReady)
                                {
                                    MainV2.speechEngine.SpeakAsync(
                                        ArduPilot.Common.speechConversion(comPort.MAV, "" + Settings.Instance["speechlowgroundspeed"]));
                                    speechlowspeedtime = DateTime.Now;
                                }
                            }
                            else
                            {
                                speechlowspeedtime = DateTime.Now;
                            }
                        }
                    }

                    // speech altitude warning - message high warning
                    if (speechEnable && speechEngine != null &&
                        (MainV2.comPort.logreadmode || comPort.BaseStream.IsOpen))
                    {
                        float warnalt = float.MaxValue;
                        if (Settings.Instance.ContainsKey("speechaltheight"))
                        {
                            warnalt = Settings.Instance.GetFloat("speechaltheight");
                        }
                        try
                        {
                            altwarningmax = (int)Math.Max(MainV2.comPort.MAV.cs.alt, altwarningmax);

                            if (Settings.Instance.GetBoolean("speechaltenabled") == true && MainV2.comPort.MAV.cs.alt != 0.00 &&
                                (MainV2.comPort.MAV.cs.alt <= warnalt) && MainV2.comPort.MAV.cs.armed)
                            {
                                if (altwarningmax > warnalt)
                                {
                                    if (MainV2.speechEngine.IsReady)
                                        MainV2.speechEngine.SpeakAsync(
                                            ArduPilot.Common.speechConversion(comPort.MAV, "" + Settings.Instance["speechalt"]));
                                }
                            }
                        }
                        catch
                        {
                        } // silent fail


                        try
                        {
                            // say the latest high priority message
                            if (MainV2.speechEngine.IsReady &&
                                lastmessagehigh != MainV2.comPort.MAV.cs.messageHigh && MainV2.comPort.MAV.cs.messageHigh != null)
                            {
                                if (!MainV2.comPort.MAV.cs.messageHigh.StartsWith("PX4v2 "))
                                {
                                    MainV2.speechEngine.SpeakAsync(MainV2.comPort.MAV.cs.messageHigh);
                                    lastmessagehigh = MainV2.comPort.MAV.cs.messageHigh;
                                }
                            }
                        }
                        catch
                        {
                        }
                    }

                    // not doing anything
                    if (!MainV2.comPort.logreadmode && !comPort.BaseStream.IsOpen)
                    {
                        altwarningmax = 0;
                    }

                    // attenuate the link qualty over time
                    if ((DateTime.Now - MainV2.comPort.MAV.lastvalidpacket).TotalSeconds >= 1)
                    {
                        if (linkqualitytime.Second != DateTime.Now.Second)
                        {
                            MainV2.comPort.MAV.cs.linkqualitygcs = (ushort)(MainV2.comPort.MAV.cs.linkqualitygcs * 0.8f);
                            linkqualitytime = DateTime.Now;

                            // force redraw if there are no other packets are being read
                            GCSViews.FlightData.myhud.Invalidate();
                        }
                    }

                    // data loss warning - wait min of 10 seconds, ignore first 30 seconds of connect, repeat at 5 seconds interval
                    if ((DateTime.Now - MainV2.comPort.MAV.lastvalidpacket).TotalSeconds > 10
                        && (DateTime.Now - connecttime).TotalSeconds > 30
                        && (DateTime.Now - nodatawarning).TotalSeconds > 5
                        && (MainV2.comPort.logreadmode || comPort.BaseStream.IsOpen)
                        && MainV2.comPort.MAV.cs.armed)
                    {
                        if (speechEnable && speechEngine != null)
                        {
                            if (MainV2.speechEngine.IsReady)
                            {
                                MainV2.speechEngine.SpeakAsync("WARNING No Data for " +
                                                               (int)
                                                                   (DateTime.Now - MainV2.comPort.MAV.lastvalidpacket)
                                                                       .TotalSeconds + " Seconds");
                                nodatawarning = DateTime.Now;
                            }
                        }
                    }

                    // get home point on armed status change.
                    if (armedstatus != MainV2.comPort.MAV.cs.armed && comPort.BaseStream.IsOpen)
                    {
                        armedstatus = MainV2.comPort.MAV.cs.armed;
                        // status just changed to armed
                        if (MainV2.comPort.MAV.cs.armed == true &&
                            MainV2.comPort.MAV.apname != MAVLink.MAV_AUTOPILOT.INVALID &&
                            MainV2.comPort.MAV.aptype != MAVLink.MAV_TYPE.GIMBAL)
                        {
                            System.Threading.ThreadPool.QueueUserWorkItem(state =>
                            {
                                Thread.CurrentThread.Name = "Arm State change";
                                try
                                {
                                    while (comPort.giveComport == true)
                                        Thread.Sleep(100);

                                    MainV2.comPort.MAV.cs.HomeLocation = new PointLatLngAlt(MainV2.comPort.getWP(0));
                                    if (MyView.current != null && MyView.current.Name == "FlightPlanner")
                                    {
                                        // update home if we are on flight data tab
                                        this.BeginInvoke((Action)delegate { FlightPlanner.updateHome(); });
                                    }

                                }
                                catch
                                {
                                    // dont hang this loop
                                    this.BeginInvoke(
                                        (Action)
                                            delegate
                                            {
                                                DevComponents.DotNetBar.MessageBoxEx.Show("Failed to update home location (" +
                                                                      MainV2.comPort.MAV.sysid + ")");
                                            });
                                }
                            });
                        }

                        if (speechEnable && speechEngine != null)
                        {
                            if (Settings.Instance.GetBoolean("speecharmenabled"))
                            {
                                string speech = armedstatus ? Settings.Instance["speecharm"] : Settings.Instance["speechdisarm"];
                                if (!string.IsNullOrEmpty(speech))
                                {
                                    MainV2.speechEngine.SpeakAsync(ArduPilot.Common.speechConversion(comPort.MAV, speech));
                                }
                            }
                        }
                    }

                    // send a hb every seconds from gcs to ap
                    if (heatbeatSend.Second != DateTime.Now.Second)
                    {
                        MAVLink.mavlink_heartbeat_t htb = new MAVLink.mavlink_heartbeat_t()
                        {
                            type = (byte)MAVLink.MAV_TYPE.GCS,
                            autopilot = (byte)MAVLink.MAV_AUTOPILOT.INVALID,
                            mavlink_version = 3 // MAVLink.MAVLINK_VERSION
                        };

                        // enumerate each link
                        foreach (var port in Comports.ToArray())
                        {
                            if (!port.BaseStream.IsOpen)
                                continue;

                            // poll for params at heartbeat interval - primary mav on this port only
                            if (!port.giveComport)
                            {
                                try
                                {
                                    // poll only when not armed
                                    if (!port.MAV.cs.armed)
                                    {
                                        port.getParamPoll();
                                        port.getParamPoll();
                                    }
                                }
                                catch
                                {
                                }
                            }

                            // there are 3 hb types we can send, mavlink1, mavlink2 signed and unsigned
                            bool sentsigned = false;
                            bool sentmavlink1 = false;
                            bool sentmavlink2 = false;

                            // enumerate each mav
                            foreach (var MAV in port.MAVlist)
                            {
                                try
                                {
                                    // poll for version if we dont have it - every mav every port
                                    if (!port.giveComport && MAV.cs.capabilities == 0 && (DateTime.Now.Second % 20) == 0 && MAV.cs.version < new Version(0, 1))
                                        port.getVersion(MAV.sysid, MAV.compid, false);

                                    // are we talking to a mavlink2 device
                                    if (MAV.mavlinkv2)
                                    {
                                        // is signing enabled
                                        if (MAV.signing)
                                        {
                                            // check if we have already sent
                                            if (sentsigned)
                                                continue;
                                            sentsigned = true;
                                        }
                                        else
                                        {
                                            // check if we have already sent
                                            if (sentmavlink2)
                                                continue;
                                            sentmavlink2 = true;
                                        }
                                    }
                                    else
                                    {
                                        // check if we have already sent
                                        if (sentmavlink1)
                                            continue;
                                        sentmavlink1 = true;
                                    }

                                    port.sendPacket(htb, MAV.sysid, MAV.compid);
                                }
                                catch (Exception ex)
                                {
                                    log.Error(ex);
                                    // close the bad port
                                    try
                                    {
                                        port.Close();
                                    }
                                    catch
                                    {
                                    }
                                    // refresh the screen if needed
                                    if (port == MainV2.comPort)
                                    {
                                        // refresh config window if needed
                                        if (MyView.current != null)
                                        {
                                            this.BeginInvoke((MethodInvoker)delegate ()
                                           {
                                               if (MyView.current.Name == "HWConfig")
                                                   MyView.ShowScreen("HWConfig");
                                               if (MyView.current.Name == "SWConfig")
                                                   MyView.ShowScreen("SWConfig");
                                           });
                                        }
                                    }
                                }
                            }
                        }

                        heatbeatSend = DateTime.Now;
                    }

                    // if not connected or busy, sleep and loop
                    if (!comPort.BaseStream.IsOpen || comPort.giveComport == true)
                    {
                        if (!comPort.BaseStream.IsOpen)
                        {
                            // check if other ports are still open
                            foreach (var port in Comports)
                            {
                                if (port.BaseStream.IsOpen)
                                {
                                    Console.WriteLine("Main comport shut, swapping to other mav");
                                    comPort = port;
                                    break;
                                }
                            }
                        }

                        System.Threading.Thread.Sleep(100);
                    }

                    // read the interfaces
                    foreach (var port in Comports.ToArray())
                    {
                        if (!port.BaseStream.IsOpen)
                        {
                            // skip primary interface
                            if (port == comPort)
                                continue;

                            // modify array and drop out
                            Comports.Remove(port);
                            port.Dispose();
                            break;
                        }

                        DateTime startread = DateTime.Now;

                        // must be open, we have bytes, we are not yielding the port,
                        // the thread is meant to be running and we only spend 1 seconds max in this read loop
                        while (port.BaseStream.IsOpen && port.BaseStream.BytesToRead > minbytes &&
                               port.giveComport == false && serialThread && startread.AddSeconds(1) > DateTime.Now)
                        {
                            try
                            {
                                await port.readPacketAsync().ConfigureAwait(false);
                            }
                            catch (Exception ex)
                            {
                                log.Error(ex);
                            }
                        }
                        // update currentstate of sysids on the port
                        foreach (var MAV in port.MAVlist)
                        {
                            try
                            {
                                MAV.cs.UpdateCurrentSettings(null, false, port, MAV);
                            }
                            catch (Exception ex)
                            {
                                log.Error(ex);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Tracking.AddException(e);
                    log.Error("Serial Reader fail :" + e.ToString());
                    try
                    {
                        comPort.Close();
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                    }
                }
            }

            Console.WriteLine("SerialReader Done");
            SerialThreadrunner.Set();
        }

        public void LoadGDALImages(object nothing)
        {
            if (Settings.Instance.ContainsKey("GDALImageDir"))
            {
                try
                {
                    GDAL.GDAL.ScanDirectory(Settings.Instance["GDALImageDir"]);
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                }
            }
        }

        private Dictionary<string, string> ProcessCommandLine(string[] args)
        {
            Dictionary<string, string> cmdargs = new Dictionary<string, string>();
            string cmd = "";
            foreach (var s in args)
            {
                if (s.StartsWith("-") || s.StartsWith("/") || s.StartsWith("--"))
                {
                    cmd = s.TrimStart(new char[] { '-', '/', '-' }).TrimStart(new char[] { '-', '/', '-' });
                    continue;
                }
                if (cmd != "")
                {
                    cmdargs[cmd] = s;
                    log.Info("ProcessCommandLine: " + cmd + " = " + s);
                    cmd = "";
                    continue;
                }
                if (File.Exists(s))
                {
                    // we are not a command, and the file exists.
                    cmdargs["file"] = s;
                    log.Info("ProcessCommandLine: " + "file" + " = " + s);
                    continue;
                }

                log.Info("ProcessCommandLine: UnKnown = " + s);
            }

            return cmdargs;
        }

        private void BGFirmwareCheck(object state)
        {
            try
            {
                if (Settings.Instance["fw_check"] != DateTime.Now.ToShortDateString())
                {
                    var fw = new Firmware();
                    var list = fw.getFWList();
                    if (list.Count > 1)
                        Firmware.SaveSoftwares(new Firmware.optionsObject() { softwares = list });

                    Settings.Instance["fw_check"] = DateTime.Now.ToShortDateString();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        private void BGGetKIndex(object state)
        {
            try
            {
                // check the last kindex date
                if (Settings.Instance["kindexdate"] == DateTime.Now.ToShortDateString())
                {
                    KIndex_KIndex(Settings.Instance.GetInt32("kindex"), null);
                }
                else
                {
                    // get a new kindex
                    KIndex.KIndexEvent += KIndex_KIndex;
                    KIndex.GetKIndex();

                    Settings.Instance["kindexdate"] = DateTime.Now.ToShortDateString();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        private void BGgetTFR(object state)
        {
            try
            {
                tfr.tfrcache = Settings.GetUserDataDirectory() + "tfr.xml";
                tfr.GetTFRs();
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        private void BGNoFly(object state)
        {
            try
            {
                NoFly.NoFly.Scan();
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }


        void KIndex_KIndex(object sender, EventArgs e)
        {
            CurrentState.KIndexstatic = (int)sender;
            Settings.Instance["kindex"] = CurrentState.KIndexstatic.ToString();
        }

        private void BGCreateMaps(object state)
        {
            // sort logs
            try
            {
                VPS.Log.LogSort.SortLogs(Directory.GetFiles(Settings.Instance.LogDir, "*.tlog"));

                VPS.Log.LogSort.SortLogs(Directory.GetFiles(Settings.Instance.LogDir, "*.rlog"));
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

            try
            {
                // create maps
                Log.LogMap.MapLogs(Directory.GetFiles(Settings.Instance.LogDir, "*.tlog", SearchOption.AllDirectories));
                Log.LogMap.MapLogs(Directory.GetFiles(Settings.Instance.LogDir, "*.bin", SearchOption.AllDirectories));
                Log.LogMap.MapLogs(Directory.GetFiles(Settings.Instance.LogDir, "*.log", SearchOption.AllDirectories));

                if (File.Exists(tlogThumbnailHandler.tlogThumbnailHandler.queuefile))
                {
                    Log.LogMap.MapLogs(File.ReadAllLines(tlogThumbnailHandler.tlogThumbnailHandler.queuefile));

                    File.Delete(tlogThumbnailHandler.tlogThumbnailHandler.queuefile);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

            try
            {
                if (File.Exists(tlogThumbnailHandler.tlogThumbnailHandler.queuefile))
                {
                    Log.LogMap.MapLogs(File.ReadAllLines(tlogThumbnailHandler.tlogThumbnailHandler.queuefile));

                    File.Delete(tlogThumbnailHandler.tlogThumbnailHandler.queuefile);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        private void checkupdate(object stuff)
        {
            if (Program.WindowsStoreApp)
                return;

            try
            {
                //MissionPlanner.Utilities.Update.CheckForUpdate();
            }
            catch (Exception ex)
            {
                log.Error("Update check failed", ex);
            }
        }

        private void MainV2_Resize(object sender, EventArgs e)
        {
            // mono - resize is called before the control is created
            if (MyView != null)
                log.Info("myview width " + MyView.Width + " height " + MyView.Height);

            log.Info("this   width " + this.Width + " height " + this.Height);
        }

        private void MenuHelp_Click(object sender, EventArgs e)
        {
            MyView.ShowScreen("Help");
        }


        #region 改变界面语言

        public void changelanguage(CultureInfo ci)
        {
            log.Info("change lang to " + ci.ToString() + " current " + Thread.CurrentThread.CurrentUICulture.ToString());

            if (ci != null && !Thread.CurrentThread.CurrentUICulture.Equals(ci))
            {
                Thread.CurrentThread.CurrentUICulture = ci;
                Settings.Instance["language"] = ci.Name;
                //System.Threading.Thread.CurrentThread.CurrentCulture = ci;

                HashSet<Control> views = new HashSet<Control> { this, FlightData, FlightPlanner/*, Simulation*/ };

                foreach (Control view in MyView.Controls)
                    views.Add(view);

                foreach (Control view in views)
                {
                    if (view != null)
                    {
                        ComponentResourceManager rm = new ComponentResourceManager(view.GetType());
                        foreach (Control ctrl in view.Controls)
                        {
                            rm.ApplyResource(ctrl);
                        }
                        rm.ApplyResources(view, "$this");
                    }
                }
            }
        }

        #endregion

        public void ChangeUnits()
        {
            try
            {
                // dist
                if (Settings.Instance["distunits"] != null)
                {
                    switch (
                        (distances)Enum.Parse(typeof(distances), Settings.Instance["distunits"].ToString()))
                    {
                        case distances.Meters:
                            CurrentState.multiplierdist = 1;
                            CurrentState.DistanceUnit = "m";
                            break;
                        case distances.Feet:
                            CurrentState.multiplierdist = 3.2808399f;
                            CurrentState.DistanceUnit = "ft";
                            break;
                    }
                }
                else
                {
                    CurrentState.multiplierdist = 1;
                    CurrentState.DistanceUnit = "m";
                }

                // alt
                if (Settings.Instance["altunits"] != null)
                {
                    switch (
                        (distances)Enum.Parse(typeof(altitudes), Settings.Instance["altunits"].ToString()))
                    {
                        case distances.Meters:
                            CurrentState.multiplieralt = 1;
                            CurrentState.AltUnit = "m";
                            break;
                        case distances.Feet:
                            CurrentState.multiplieralt = 3.2808399f;
                            CurrentState.AltUnit = "ft";
                            break;
                    }
                }
                else
                {
                    CurrentState.multiplieralt = 1;
                    CurrentState.AltUnit = "m";
                }

                // speed
                if (Settings.Instance["speedunits"] != null)
                {
                    switch ((speeds)Enum.Parse(typeof(speeds), Settings.Instance["speedunits"].ToString()))
                    {
                        case speeds.meters_per_second:
                            CurrentState.multiplierspeed = 1;
                            CurrentState.SpeedUnit = "m/s";
                            break;
                        case speeds.fps:
                            CurrentState.multiplierspeed = 3.2808399f;
                            CurrentState.SpeedUnit = "fps";
                            break;
                        case speeds.kph:
                            CurrentState.multiplierspeed = 3.6f;
                            CurrentState.SpeedUnit = "kph";
                            break;
                        case speeds.mph:
                            CurrentState.multiplierspeed = 2.23693629f;
                            CurrentState.SpeedUnit = "mph";
                            break;
                        case speeds.knots:
                            CurrentState.multiplierspeed = 1.94384449f;
                            CurrentState.SpeedUnit = "kts";
                            break;
                    }
                }
                else
                {
                    CurrentState.multiplierspeed = 1;
                    CurrentState.SpeedUnit = "m/s";
                }
            }
            catch
            {
            }
        }

        private void CMB_baudrate_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(_connectionControl.CMB_baudrate.Text, out comPortBaud))
            {
                DevComponents.DotNetBar.MessageBoxEx.Show(Strings.InvalidBaudRate, Strings.ERROR);
                return;
            }
            var sb = new StringBuilder();
            int baud = 0;
            for (int i = 0; i < _connectionControl.CMB_baudrate.Text.Length; i++)
                if (char.IsDigit(_connectionControl.CMB_baudrate.Text[i]))
                {
                    sb.Append(_connectionControl.CMB_baudrate.Text[i]);
                    baud = baud * 10 + _connectionControl.CMB_baudrate.Text[i] - '0';
                }
            if (_connectionControl.CMB_baudrate.Text != sb.ToString())
            {
                _connectionControl.CMB_baudrate.Text = sb.ToString();
            }
            try
            {
                if (baud > 0 && comPort.BaseStream.BaudRate != baud)
                    comPort.BaseStream.BaudRate = baud;
            }
            catch (Exception)
            {
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        internal class DEV_BROADCAST_HDR
        {
            internal Int32 dbch_size;
            internal Int32 dbch_devicetype;
            internal Int32 dbch_reserved;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal class DEV_BROADCAST_PORT
        {
            public int dbcp_size;
            public int dbcp_devicetype;
            public int dbcp_reserved; // MSDN say "do not use"
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 255)] public byte[] dbcp_name;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal class DEV_BROADCAST_DEVICEINTERFACE
        {
            public Int32 dbcc_size;
            public Int32 dbcc_devicetype;
            public Int32 dbcc_reserved;

            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 16)]
            internal Byte[]
                dbcc_classguid;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 255)] internal Byte[] dbcc_name;
        }


        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_CREATE:
                    try
                    {
                        DEV_BROADCAST_DEVICEINTERFACE devBroadcastDeviceInterface = new DEV_BROADCAST_DEVICEINTERFACE();
                        IntPtr devBroadcastDeviceInterfaceBuffer;
                        IntPtr deviceNotificationHandle = IntPtr.Zero;
                        Int32 size = 0;

                        // frmMy is the form that will receive device-change messages.


                        size = Marshal.SizeOf(devBroadcastDeviceInterface);
                        devBroadcastDeviceInterface.dbcc_size = size;
                        devBroadcastDeviceInterface.dbcc_devicetype = DBT_DEVTYP_DEVICEINTERFACE;
                        devBroadcastDeviceInterface.dbcc_reserved = 0;
                        devBroadcastDeviceInterface.dbcc_classguid = GUID_DEVINTERFACE_USB_DEVICE.ToByteArray();
                        devBroadcastDeviceInterfaceBuffer = Marshal.AllocHGlobal(size);
                        Marshal.StructureToPtr(devBroadcastDeviceInterface, devBroadcastDeviceInterfaceBuffer, true);


                        deviceNotificationHandle = NativeMethods.RegisterDeviceNotification(this.Handle,
                            devBroadcastDeviceInterfaceBuffer, DEVICE_NOTIFY_WINDOW_HANDLE);
                    }
                    catch
                    {
                    }

                    break;

                case WM_DEVICECHANGE:
                    // The WParam value identifies what is occurring.
                    WM_DEVICECHANGE_enum n = (WM_DEVICECHANGE_enum)m.WParam;
                    var l = m.LParam;
                    if (n == WM_DEVICECHANGE_enum.DBT_DEVICEREMOVEPENDING)
                    {
                        Console.WriteLine("DBT_DEVICEREMOVEPENDING");
                    }
                    if (n == WM_DEVICECHANGE_enum.DBT_DEVNODES_CHANGED)
                    {
                        Console.WriteLine("DBT_DEVNODES_CHANGED");
                    }
                    if (n == WM_DEVICECHANGE_enum.DBT_DEVICEARRIVAL ||
                        n == WM_DEVICECHANGE_enum.DBT_DEVICEREMOVECOMPLETE)
                    {
                        Console.WriteLine(((WM_DEVICECHANGE_enum)n).ToString());

                        DEV_BROADCAST_HDR hdr = new DEV_BROADCAST_HDR();
                        Marshal.PtrToStructure(m.LParam, hdr);

                        try
                        {
                            switch (hdr.dbch_devicetype)
                            {
                                case DBT_DEVTYP_DEVICEINTERFACE:
                                    DEV_BROADCAST_DEVICEINTERFACE inter = new DEV_BROADCAST_DEVICEINTERFACE();
                                    Marshal.PtrToStructure(m.LParam, inter);
                                    log.InfoFormat("Interface {0}",
                                        ASCIIEncoding.Unicode.GetString(inter.dbcc_name, 0, inter.dbcc_size - (4 * 3)));
                                    break;
                                case DBT_DEVTYP_PORT:
                                    DEV_BROADCAST_PORT prt = new DEV_BROADCAST_PORT();
                                    Marshal.PtrToStructure(m.LParam, prt);
                                    log.InfoFormat("port {0}",
                                        ASCIIEncoding.Unicode.GetString(prt.dbcp_name, 0, prt.dbcp_size - (4 * 3)));
                                    break;
                            }
                        }
                        catch
                        {
                        }

                        //string port = Marshal.PtrToStringAuto((IntPtr)((long)m.LParam + 12));
                        //Console.WriteLine("Added port {0}",port);
                    }
                    log.InfoFormat("Device Change {0} {1} {2}", m.Msg, (WM_DEVICECHANGE_enum)m.WParam, m.LParam);

                    if (DeviceChanged != null)
                    {
                        try
                        {
                            DeviceChanged((WM_DEVICECHANGE_enum)m.WParam);
                        }
                        catch
                        {
                        }
                    }

                    foreach (var item in VPS.Plugin.PluginLoader.Plugins)
                    {
                        item.Host.ProcessDeviceChanged((WM_DEVICECHANGE_enum)m.WParam);
                    }

                    break;
                case 0x86: // WM_NCACTIVATE
                    //var thing = Control.FromHandle(m.HWnd);

                    var child = Control.FromHandle(m.LParam);

                    if (child is Form)
                    {
                        log.Debug("ApplyThemeTo " + child.Name);
                        ThemeManager.ApplyThemeTo(child);
                    }
                    break;
                default:
                    //Console.WriteLine(m.ToString());
                    break;
            }
            base.WndProc(ref m);
        }

        const int DBT_DEVTYP_PORT = 0x00000003;
        const int WM_CREATE = 0x0001;
        const Int32 DBT_DEVTYP_HANDLE = 6;
        const Int32 DBT_DEVTYP_DEVICEINTERFACE = 5;
        const Int32 DEVICE_NOTIFY_WINDOW_HANDLE = 0;
        const Int32 DIGCF_PRESENT = 2;
        const Int32 DIGCF_DEVICEINTERFACE = 0X10;
        const Int32 WM_DEVICECHANGE = 0X219;
        public static Guid GUID_DEVINTERFACE_USB_DEVICE = new Guid("A5DCBF10-6530-11D2-901F-00C04FB951ED");


        public enum WM_DEVICECHANGE_enum
        {
            DBT_CONFIGCHANGECANCELED = 0x19,
            DBT_CONFIGCHANGED = 0x18,
            DBT_CUSTOMEVENT = 0x8006,
            DBT_DEVICEARRIVAL = 0x8000,
            DBT_DEVICEQUERYREMOVE = 0x8001,
            DBT_DEVICEQUERYREMOVEFAILED = 0x8002,
            DBT_DEVICEREMOVECOMPLETE = 0x8004,
            DBT_DEVICEREMOVEPENDING = 0x8003,
            DBT_DEVICETYPESPECIFIC = 0x8005,
            DBT_DEVNODES_CHANGED = 0x7,
            DBT_QUERYCHANGECONFIG = 0x17,
            DBT_USERDEFINED = 0xFFFF,
        }


        #region 更改主窗口
        Controls.MainSwitcher MyView;

        private void FlightPlannerShow()
        {
            //MyView.ShowScreen("FlightPlanner");
            MyView.ShowScreen("FlightPlanner");
        }


        private void FlightDataShow()
        {
            MyView.ShowScreen("FlightData");
        }
        #endregion

        #region 自定义初始化
        private void SetInitHandler()
        {
            LeaveDrawPolygonState();

            delegateDataChange();
            delegateHomeChange();
            delegateWorkspaceChange();
            delegateWPListChange();
            delegateCurrentPosition();

            CustomData.WP.WPGlobalData.instance.HomeChange += VPS.Controls.MainInfo.LeftMainInfo.instance.HomeChangeHandle;
            #region 控件反应链接
            GCSViews.FlightPlanner.instance.DrawPolygonHandle += VPS.MainV2.instance.DrawPolygonState;
            GCSViews.FlightPlanner.instance.LeaveDrawPolygonHandle += VPS.MainV2.instance.LeaveDrawPolygonState;
            GCSViews.FlightPlanner.instance.DrawWPHandle += VPS.MainV2.instance.DrawWPState;
            GCSViews.FlightPlanner.instance.LeaveDrawWPHandle += VPS.MainV2.instance.LeaveDrawWPState;
            VPS.MainV2.instance.NoneLayerHandle += VPS.MainV2.instance.SetNoneLayerState;
            VPS.MainV2.instance.LoadLayerHandle += VPS.MainV2.instance.SetLaodLayerState;
            #endregion

        }

        #region Home 数据链接
        private void delegateHomeChange()
        {
            CustomData.WP.WPGlobalData.instance.HomeChange += VPS.Controls.Command.CommandsPanel.instance.HomeChangeHandle;
            CustomData.WP.WPGlobalData.instance.HomeChange += VPS.Controls.MainInfo.LeftMainInfo.instance.HomeChangeHandle;
            CustomData.WP.WPGlobalData.instance.HomeChange += VPS.GCSViews.FlightPlanner.instance.HomeChangeHandle;
        }
        #endregion

        #region WPList 数据链接
        private void delegateWPListChange()
        {
            CustomData.WP.WPGlobalData.instance.WPListChange += VPS.Controls.Command.CommandsPanel.instance.WPChangeHandle;
            CustomData.WP.WPGlobalData.instance.WPListChange += VPS.Controls.MainInfo.LeftMainInfo.instance.WPChangeHandle;
            CustomData.WP.WPGlobalData.instance.WPListChange += VPS.GCSViews.FlightPlanner.instance.WPChangeHandle;

            CustomData.WP.WPGlobalData.instance.PolygonListChange += VPS.GCSViews.FlightPlanner.instance.PolyChangeHandle;
        }
        #endregion

        #region Workspace 工作区
        private void delegateWorkspaceChange()
        {
            CustomData.WP.WPGlobalData.instance.WorkspaceRectChange += VPS.Controls.MainInfo.LeftMainInfo.instance.WorkspaceRectChangeHandle;
        }
        #endregion

        #region CurrentPosition 数据链接
        private void delegateCurrentPosition()
        {
            CustomData.WP.WPGlobalData.instance.CurrentChange += VPS.Controls.MainInfo.LeftMainInfo.instance.SetCurrentPosition;
        }
        #endregion

        #region 基础数据 数据链接
        private void delegateDataChange()
        {
            VPS.Controls.Command.CommandsPanel.instance.CoordSystemChange += GCSViews.FlightPlanner.instance.SetCoordSystemHandle;
            VPS.Controls.Command.CommandsPanel.instance.WPRadChange += GCSViews.FlightPlanner.instance.SetWPRadHandle;
            VPS.Controls.Command.CommandsPanel.instance.AltFrameChange += GCSViews.FlightPlanner.instance.SetAltFrameHandle;
            VPS.Controls.Command.CommandsPanel.instance.WarnAltChange += GCSViews.FlightPlanner.instance.SetWarnAltHandle;
            VPS.Controls.Command.CommandsPanel.instance.DefaultAltChange += GCSViews.FlightPlanner.instance.SetDefaultAltHandle;
        }
        #endregion

        #region 加载默认图层（工作区）
        public bool LoadDefaultLayer()
        {
            var layerInfo = CustomData.Layer.MemoryLayerCache.GetLayerFromMemoryCache(
                CustomData.WP.WPGlobalData.instance.GetDefaultLayer()
                );
            if (layerInfo != null)
            {
                return SetLayerOverlay(layerInfo);
            }
            else
            {
                return false;
            }
        }
        #endregion

        #endregion

        #region OnLoad

        #region 入口函数
        protected override void OnLoad(EventArgs e)
        {

            MyView.AddScreen(new MainSwitcher.Screen("FlightData", FlightData, true));
            MyView.AddScreen(new MainSwitcher.Screen("FlightPlanner", FlightPlanner, true));
            MyView.AddScreen(new MainSwitcher.Screen("HWConfig", typeof(GCSViews.InitialSetup), false));
            MyView.AddScreen(new MainSwitcher.Screen("SWConfig", typeof(GCSViews.SoftwareConfig), false));
            //MyView.AddScreen(new MainSwitcher.Screen("Simulation", Simulation, true));
            MyView.AddScreen(new MainSwitcher.Screen("Help", typeof(GCSViews.Help), false));

            // hide simulation under mono
            if (Program.MONO)
            {
                MenuSimulation.Visible = false;
            }

            try
            {
                if (Control.ModifierKeys == Keys.Shift)
                {
                }
                else
                {
                    log.Info("Load Pluggins");
                    Plugin.PluginLoader.DisabledPluginNames.Clear();
                    foreach (var s in Settings.Instance.GetList("DisabledPlugins")) Plugin.PluginLoader.DisabledPluginNames.Add(s);
                    Plugin.PluginLoader.LoadAll();
                    log.Info("Load Pluggins... Done");
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

            this.PerformLayout();
            FlightPlannerShow();

            // for long running tasks using own threads.
            // for short use threadpool

            this.SuspendLayout();

            // setup http server
            try
            {
                log.Info("start http");
                httpthread = new Thread(new httpserver().listernforclients)
                {
                    Name = "motion jpg stream-network kml",
                    IsBackground = true
                };
                httpthread.Start();
            }
            catch (Exception ex)
            {
                log.Error("Error starting TCP listener thread: ", ex);
                DevComponents.DotNetBar.MessageBoxEx.Show(ex.ToString());
            }

            log.Info("start joystick");
            // setup joystick packet sender
            joystickthread = new Thread(new ThreadStart(joysticksend))
            {
                IsBackground = true,
                Priority = ThreadPriority.AboveNormal,
                Name = "Main joystick sender"
            };
            joystickthread.Start();

            log.Info("start serialreader");
            // setup main serial reader
            serialreaderthread = new Thread(SerialReader)
            {
                IsBackground = true,
                Name = "Main Serial reader",
                Priority = ThreadPriority.AboveNormal
            };
            serialreaderthread.Start();

            log.Info("start plugin thread");
            // setup main plugin thread
            pluginthread = new Thread(PluginThread)
            {
                IsBackground = true,
                Name = "plugin runner thread",
                Priority = ThreadPriority.BelowNormal
            };
            pluginthread.Start();


            ThreadPool.QueueUserWorkItem(LoadGDALImages);

            ThreadPool.QueueUserWorkItem(BGLoadAirports);

            ThreadPool.QueueUserWorkItem(BGCreateMaps);

            //ThreadPool.QueueUserWorkItem(BGGetAlmanac);

            ThreadPool.QueueUserWorkItem(BGgetTFR);

            ThreadPool.QueueUserWorkItem(BGNoFly);

            ThreadPool.QueueUserWorkItem(BGGetKIndex);

            // update firmware version list - only once per day
            ThreadPool.QueueUserWorkItem(BGFirmwareCheck);

            log.Info("start AutoConnect");
            AutoConnect.NewMavlinkConnection += (sender, serial) =>
            {
                try
                {
                    log.Info("AutoConnect.NewMavlinkConnection " + serial.PortName);
                    MainV2.instance.BeginInvoke((Action)delegate
                    {
                        if (MainV2.comPort.BaseStream.IsOpen)
                        {
                            var mav = new MAVLinkInterface();
                            mav.BaseStream = serial;
                            MainV2.instance.doConnect(mav, "preset", serial.PortName);

                            MainV2.Comports.Add(mav);
                        }
                        else
                        {
                            MainV2.comPort.BaseStream = serial;
                            MainV2.instance.doConnect(MainV2.comPort, "preset", serial.PortName);
                        }
                    });
                }
                catch (Exception ex) { log.Error(ex); }
            };
            //AutoConnect.NewVideoStream += (sender, gststring) =>
            //{
            //    try
            //    {
            //        log.Info("AutoConnect.NewVideoStream " + gststring);
            //        GStreamer.gstlaunch = GStreamer.LookForGstreamer();

            //        if (!File.Exists(GStreamer.gstlaunch))
            //        {
            //            if (DevComponents.DotNetBar.MessageBoxEx.Show(
            //                    "A video stream has been detected, but gstreamer has not been configured/installed.\nDo you want to install/config it now?",
            //                    "GStreamer", System.Windows.Forms.MessageBoxButtons.YesNo) ==
            //                System.Windows.Forms.DialogResult.Yes)
            //            {
            //                {
            //                    ProgressReporterDialogue prd = new ProgressReporterDialogue();
            //                    ThemeManager.ApplyThemeTo(prd);
            //                    prd.DoWork += sender2 =>
            //                    {
            //                        GStreamer.DownloadGStreamer(((i, s) =>
            //                        {
            //                            prd.UpdateProgressAndStatus(i, s);
            //                            if (prd.doWorkArgs.CancelRequested) throw new Exception("User Request");
            //                        }));
            //                    };
            //                    prd.RunBackgroundOperationAsync();

            //                    GStreamer.gstlaunch = GStreamer.LookForGstreamer();
            //                }
            //                if (!File.Exists(GStreamer.gstlaunch))
            //                {
            //                    return;
            //                }
            //            }
            //            else
            //            {
            //                return;
            //            }
            //        }

            //        GStreamer.StartA(gststring);
            //    }
            //    catch (Exception ex)
            //    {
            //        log.Error(ex);
            //    }
            //};
            //AutoConnect.Start();

            BinaryLog.onFlightMode += (firmware, modeno) =>
            {
                try
                {
                    if (firmware == "")
                        return null;

                    var modes = ArduPilot.Common.getModesList((Firmwares)Enum.Parse(typeof(Firmwares), firmware));
                    string currentmode = null;

                    foreach (var mode in modes)
                    {
                        if (mode.Key == modeno)
                        {
                            currentmode = mode.Value;
                            break;
                        }
                    }

                    return currentmode;
                }
                catch
                {
                    return null;
                }
            };

            GStreamer.onNewImage += (sender, image) =>
            {
                if (image == null)
                {
                    GCSViews.FlightData.myhud.bgimage = null;
                    return;
                }

                if (!(image is Drawing::System.Drawing.Bitmap bmp))
                    return;
                var old = GCSViews.FlightData.myhud.bgimage;
                GCSViews.FlightData.myhud.bgimage = new Bitmap(image.Width, image.Height, 4 * image.Width,
                    PixelFormat.Format32bppPArgb,
                    bmp.LockBits(Rectangle.Empty, null, SKColorType.Bgra8888)
                    .Scan0);
                if (old != null)
                    old.Dispose();
            };

            vlcrender.onNewImage += (sender, image) =>
            {
                if (image == null)
                {
                    GCSViews.FlightData.myhud.bgimage = null;
                    return;
                }
                if (!(image is Drawing::System.Drawing.Bitmap bmp))
                    return;
                var old = GCSViews.FlightData.myhud.bgimage;
                GCSViews.FlightData.myhud.bgimage = new Bitmap(image.Width,
                                                               image.Height,
                                                               4 * image.Width,
                                                               PixelFormat.Format32bppPArgb,
                                                               bmp.LockBits(Rectangle.Empty, null, SKColorType.Bgra8888).Scan0);
                if (old != null)
                    old.Dispose();
            };

            CaptureMJPEG.onNewImage += (sender, image) =>
            {
                if (image == null)
                {
                    GCSViews.FlightData.myhud.bgimage = null;
                    return;
                }
                if (!(image is Drawing::System.Drawing.Bitmap bmp))
                    return;
                var old = GCSViews.FlightData.myhud.bgimage;
                GCSViews.FlightData.myhud.bgimage = new Bitmap(image.Width, image.Height, 4 * image.Width,
                                                               PixelFormat.Format32bppPArgb,
                                                               bmp.LockBits(Rectangle.Empty, null, SKColorType.Bgra8888).Scan0);
                if (old != null)
                    old.Dispose();
            };

            try
            {
                ZeroConf.EnumerateAllServicesFromAllHosts().ContinueWith(a => ZeroConf.ProbeForRTSP());
            }
            catch
            {
            }

            CommsSerialScan.doConnect += port =>
            {
                if (MainV2.instance.InvokeRequired)
                {
                    log.Info("CommsSerialScan.doConnect invoke");
                    MainV2.instance.BeginInvoke(
                        (Action)delegate ()
                        {
                            MAVLinkInterface mav = new MAVLinkInterface();
                            mav.BaseStream = port;
                            MainV2.instance.doConnect(mav, "preset", "0");
                            MainV2.Comports.Add(mav);
                        });
                }
                else
                {

                    log.Info("CommsSerialScan.doConnect NO invoke");
                    MAVLinkInterface mav = new MAVLinkInterface();
                    mav.BaseStream = port;
                    MainV2.instance.doConnect(mav, "preset", "0");
                    MainV2.Comports.Add(mav);
                }
            };

            try
            {
                if (!MONO)
                {
                    log.Info("Load AltitudeAngel");
                    AltitudeAngel.Configure();
                    AltitudeAngel.Initialize();
                    log.Info("Load AltitudeAngel... Done");
                }
            }
            catch (TypeInitializationException) // windows xp lacking patch level
            {
                //CustomMessageBox.Show("Please update your .net version. kb2468871");
            }
            catch (Exception ex)
            {
                Tracking.AddException(ex);
            }

            this.ResumeLayout();

            Program.Splash?.Close();

            log.Info("appload time");
            VPS.Utilities.Tracking.AddTiming("AppLoad", "Load Time",
                (DateTime.Now - Program.starttime).TotalMilliseconds, "");

            int p = (int)Environment.OSVersion.Platform;
            bool isWin = (p != 4) && (p != 6) && (p != 128);
            bool winXp = isWin && Environment.OSVersion.Version.Major == 5;
            if (winXp)
            {
                Common.MessageShowAgain("Windows XP",
                    "This is the last version that will support Windows XP, please update your OS");

                // invalidate update url
                System.Configuration.ConfigurationManager.AppSettings["UpdateLocationVersion"] =
                    "https://firmware.ardupilot.org/MissionPlanner/xp/";
                System.Configuration.ConfigurationManager.AppSettings["UpdateLocation"] =
                    "https://firmware.ardupilot.org/MissionPlanner/xp/";
                System.Configuration.ConfigurationManager.AppSettings["UpdateLocationMD5"] =
                    "https://firmware.ardupilot.org/MissionPlanner/xp/checksums.txt";
                System.Configuration.ConfigurationManager.AppSettings["BetaUpdateLocationVersion"] = "";
            }

            try
            {
                // single update check per day - in a seperate thread
                if (Settings.Instance["update_check"] != DateTime.Now.ToShortDateString())
                {
                    System.Threading.ThreadPool.QueueUserWorkItem(checkupdate);
                    Settings.Instance["update_check"] = DateTime.Now.ToShortDateString();
                }
                else if (Settings.Instance.GetBoolean("beta_updates") == true)
                {
                    VPS.Utilities.Update.dobeta = true;
                    System.Threading.ThreadPool.QueueUserWorkItem(checkupdate);
                }
            }
            catch (Exception ex)
            {
                log.Error("Update check failed", ex);
            }

            // play a tlog that was passed to the program/ load a bin log passed
            if (Program.args.Length > 0)
            {
                var cmds = ProcessCommandLine(Program.args);

                if (cmds.ContainsKey("file") && File.Exists(cmds["file"]) && cmds["file"].ToLower().EndsWith(".tlog"))
                {
                    FlightData.LoadLogFile(Program.args[0]);
                    FlightData.BUT_playlog_Click(null, null);
                }
                else if (cmds.ContainsKey("file") && File.Exists(cmds["file"]) &&
                         (cmds["file"].ToLower().EndsWith(".log") || cmds["file"].ToLower().EndsWith(".bin")))
                {
                    LogBrowse logbrowse = new LogBrowse();
                    ThemeManager.ApplyThemeTo(logbrowse);
                    logbrowse.logfilename = Program.args[0];
                    logbrowse.Show(this);
                    logbrowse.BringToFront();
                }

                if (cmds.ContainsKey("script") && File.Exists(cmds["script"]))
                {
                    // invoke for after onload finished
                    this.BeginInvoke((Action)delegate ()
                    {
                        try
                        {
                            FlightData.selectedscript = cmds["script"];

                            FlightData.BUT_run_script_Click(null, null);
                        }
                        catch (Exception ex)
                        {
                            DevComponents.DotNetBar.MessageBoxEx.Show("Start script failed: " + ex.ToString(), Strings.ERROR);
                        }
                    });
                }

                if (cmds.ContainsKey("joy") && cmds.ContainsKey("type"))
                {
                    if (cmds["type"].ToLower() == "plane")
                    {
                        MainV2.comPort.MAV.cs.firmware = Firmwares.ArduPlane;
                    }
                    else if (cmds["type"].ToLower() == "copter")
                    {
                        MainV2.comPort.MAV.cs.firmware = Firmwares.ArduCopter2;
                    }
                    else if (cmds["type"].ToLower() == "rover")
                    {
                        MainV2.comPort.MAV.cs.firmware = Firmwares.ArduRover;
                    }
                    else if (cmds["type"].ToLower() == "sub")
                    {
                        MainV2.comPort.MAV.cs.firmware = Firmwares.ArduSub;
                    }

                    var joy = new Joystick.Joystick(() => MainV2.comPort);

                    if (joy.start(cmds["joy"]))
                    {
                        MainV2.joystick = joy;
                        MainV2.joystick.enabled = true;
                    }
                    else
                    {
                        DevComponents.DotNetBar.MessageBoxEx.Show("Failed to start joystick");
                    }
                }

                if (cmds.ContainsKey("rtk"))
                {
                    var inject = new ConfigSerialInjectGPS();
                    if (cmds["rtk"].ToLower().Contains("http"))
                    {
                        inject.CMB_serialport.Text = "NTRIP";
                        var nt = new CommsNTRIP();
                        ConfigSerialInjectGPS.comPort = nt;
                        Task.Run(() =>
                        {
                            try
                            {
                                nt.Open(cmds["rtk"]);
                                nt.lat = MainV2.comPort.MAV.cs.PlannedHomeLocation.Lat;
                                nt.lng = MainV2.comPort.MAV.cs.PlannedHomeLocation.Lng;
                                nt.alt = MainV2.comPort.MAV.cs.PlannedHomeLocation.Alt;
                                this.BeginInvokeIfRequired(() => { inject.DoConnect(); });
                            }
                            catch (Exception ex)
                            {
                                this.BeginInvokeIfRequired(() => { DevComponents.DotNetBar.MessageBoxEx.Show(ex.ToString()); });
                            }
                        });
                    }
                }

                if (cmds.ContainsKey("cam"))
                {
                    try
                    {
                        MainV2.cam = new WebCamService.Capture(int.Parse(cmds["cam"]), null);

                        MainV2.cam.Start();
                    }
                    catch (Exception ex)
                    {
                        DevComponents.DotNetBar.MessageBoxEx.Show(ex.ToString());
                    }
                }

                //if (cmds.ContainsKey("gstream"))
                //{
                //    GStreamer.gstlaunch = GStreamer.LookForGstreamer();

                //    if (!File.Exists(GStreamer.gstlaunch))
                //    {
                //        if (DevComponents.DotNetBar.MessageBoxEx.Show(
                //                "A video stream has been detected, but gstreamer has not been configured/installed.\nDo you want to install/config it now?",
                //                "GStreamer", System.Windows.Forms.MessageBoxButtons.YesNo) ==
                //            System.Windows.Forms.DialogResult.Yes)
                //        {
                //            GStreamerUI.DownloadGStreamer();
                //        }
                //    }

                //    try
                //    {
                //        new Thread(delegate ()
                //        {
                //            // 36 retrys
                //            for (int i = 0; i < 36; i++)
                //            {
                //                try
                //                {
                //                    var st = GStreamer.StartA(cmds["gstream"]);
                //                    if (st == null)
                //                    {
                //                        // prevent spam
                //                        Thread.Sleep(5000);
                //                    }
                //                    else
                //                    {
                //                        while (st.IsAlive)
                //                        {
                //                            Thread.Sleep(1000);
                //                        }
                //                    }
                //                }
                //                catch (BadImageFormatException ex)
                //                {
                //                    // not running on x64
                //                    log.Error(ex);
                //                    return;
                //                }
                //                catch (DllNotFoundException ex)
                //                {
                //                    // missing or failed download
                //                    log.Error(ex);
                //                    return;
                //                }
                //            }
                //        })
                //        { IsBackground = true, Name = "Gstreamer cli" }.Start();
                //    }
                //    catch (Exception ex)
                //    {
                //        log.Error(ex);
                //    }
                //}

                if (cmds.ContainsKey("port") && cmds.ContainsKey("baud"))
                {
                    _connectionControl.CMB_serialport.Text = cmds["port"];
                    _connectionControl.CMB_baudrate.Text = cmds["baud"];

                    doConnect(MainV2.comPort, cmds["port"], cmds["baud"]);
                }
            }

            GMapMarkerBase.length = Settings.Instance.GetInt32("GMapMarkerBase_length", 500);
            GMapMarkerBase.DisplayCOG = Settings.Instance.GetBoolean("GMapMarkerBase_DisplayCOG", true);
            GMapMarkerBase.DisplayHeading = Settings.Instance.GetBoolean("GMapMarkerBase_DisplayHeading", true);
            GMapMarkerBase.DisplayNavBearing = Settings.Instance.GetBoolean("GMapMarkerBase_DisplayNavBearing", true);
            GMapMarkerBase.DisplayRadius = Settings.Instance.GetBoolean("GMapMarkerBase_DisplayRadius", true);
            GMapMarkerBase.DisplayTarget = Settings.Instance.GetBoolean("GMapMarkerBase_DisplayTarget", true);                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 

            SetInitHandler();
            layerCache = new CustomData.Layer.MemoryLayerCache();

            //}
            if (!LoadDefaultLayer())
            {
                CustomData.WP.WPGlobalData.instance.DefaultLayerInvalid();
            }
        }
        #endregion

        #endregion

        #region 主菜单项Checked

        #region SetCheckedState
        private delegate void SetMenuItemCheckedCallback(DevComponents.DotNetBar.ButtonItem stripButton, bool value);
        private void SetMenuItemChecked(DevComponents.DotNetBar.ButtonItem stripButton, bool value)
        {
            if (stripButton.InvokeRequired)
            {
                SetMenuItemCheckedCallback callback = new SetMenuItemCheckedCallback(SetMenuItemChecked);
                stripButton.Invoke(callback, new object[] { stripButton, value });
            }
            else
            {
                stripButton.Checked = value;
            }
        }
        #endregion

        #region GetCheckedState
        private delegate bool GetMenuItemCheckedCallback(DevComponents.DotNetBar.ButtonItem stripButton);
        private bool GetMenuItemChecked(DevComponents.DotNetBar.ButtonItem stripButton)
        {
            if (stripButton.InvokeRequired)
            {
                GetMenuItemCheckedCallback callback = new GetMenuItemCheckedCallback(GetMenuItemChecked);
                IAsyncResult iar = this.BeginInvoke(callback, new object[] { stripButton });
                return (bool)this.EndInvoke(iar);
            }
            else
            {
                return stripButton.Checked;
            }
        }
        #endregion

        //开启 添加区域点 菜单项
        private void DrawPolygonState()
        {
            SetMenuItemChecked(this.DrawPolygonButton, true);
            SetMenuItemChecked(this.DrawWPButton, false);
        }
        //关闭 添加区域点 菜单项
        private void LeaveDrawPolygonState()
        {
            SetMenuItemChecked(this.DrawPolygonButton, false);
        }

        //开启 添加航点 菜单项
        private void DrawWPState()
        {
            SetMenuItemChecked(this.DrawWPButton, true);
            SetMenuItemChecked(this.DrawPolygonButton, false);
        }

        //关闭 添加航点 菜单项
        private void LeaveDrawWPState()
        {
            SetMenuItemChecked(this.DrawWPButton, false);
        }
        #endregion

        #region 主菜单项

        #region 工程模块

        #region LoadProject
        /// <summary>
        /// 提取工程文件数据
        /// </summary>
        private void LoadProjectButton_Click(object sender, EventArgs e)
        {
            var load = new Controls.LoadAndSave.LoadProject();
            var result = load.ShowDialog();
            if (result == DialogResult.OK)
            {
                CustomData.WP.WPGlobalData.instance.SetPolyListHandle(load.info.polygon.features);
                CustomData.WP.WPGlobalData.instance.SetWPListHandle(load.info.wpList.features);
                if (load.info.layer != CustomData.WP.WPGlobalData.instance.GetLayer())
                {
                    CustomData.WP.WPGlobalData.instance.SetLayer(
                        load.info.layer, load.info.defaultLayer);
                    CustomData.WP.WPGlobalData.instance.SetLayerLimit(
                        load.info.layerRect, load.info.homePosition, load.info.defaultLayer);
                    ShowLayerOverlay(load.info.layer);
                }

                GCSViews.FlightPlanner.instance.MainMap.SetZoomToFitRect(load.info.layerRect.ToWGS84());
            }
        }

        #endregion

        #region SaveProject
        /// <summary>
        /// 将提取的数据保存到文件中
        /// </summary>
        private void SaveProjectButton_Click(object sender, EventArgs e)
        {
            var save = new VPS.Controls.LoadAndSave.SaveProject();
            var result = save.ShowDialog();
            if(result == DialogResult.OK)
            {
                save.SaveProjectToFile();
            }
        }
        #endregion

        #endregion

        #region 工作区模块

        #region LoadTiff

        #region LoadTiff 入口函数
        /// <summary>
        /// 显示或隐藏LayerReader停靠栏
        /// </summary>
        private void LoadTiffButton_Click(object sender, EventArgs e)
        {
            using (VPS.Controls.LoadAndSave.LoadLayer load = new Controls.LoadAndSave.LoadLayer()) { 
                var result = load.ShowDialog();
                if (result == DialogResult.OK)
                {
                    load.LoadLayerInfo();
                }
            }
            //if (!LoadTiffButton.Checked)
            //{
            //    LoadTiffButton.Checked = true;
            //    ((System.ComponentModel.ISupportInitialize)(this.LeftBar)).BeginInit();
            //    LayerReaderDockContainerItem.Visible = true;
            //    this.LeftBar.AutoHide = this.LeftBar.AutoHide;
            //    LeftBar.SelectedDockContainerItem = LayerReaderDockContainerItem;
            //    ((System.ComponentModel.ISupportInitialize)(this.LeftBar)).EndInit();
            //    this.LeftBar.ResumeLayout(false);
            //}
            //else
            //{
            //    LoadTiffButton.Checked = false;
            //    ((System.ComponentModel.ISupportInitialize)(this.LeftBar)).BeginInit();
            //    LayerReaderDockContainerItem.Visible = false;
            //    this.LeftBar.AutoHide = this.LeftBar.AutoHide;
            //    //LeftBar.SelectedDockContainerItem = LayerReaderDockContainerItem;
            //    ((System.ComponentModel.ISupportInitialize)(this.LeftBar)).EndInit();
            //    this.LeftBar.ResumeLayout(false);
            //}
        }
        #endregion

        #region LoadTiff 接口函数
        public void LoadTiffLayer()
        {
            LoadTiffButton_Click(this, null);
        }
        #endregion

        #region LoadTiff 相应函数
        public delegate void delegateHandler();
        public delegateHandler LoadLayerHandle;
        public delegateHandler NoneLayerHandle;
        private void SetLaodLayerState()
        {
            this.ZoomTiffButton.Enabled = true;
            this.ZoomToButton.Enabled = true;
        }

        private void SetNoneLayerState()
        {
            this.ZoomTiffButton.Enabled = false;
            this.ZoomToButton.Enabled = false;
        }
        #endregion

        #region LoadTiff 标记 
        #region LoadTiff 是否已经加载标记
        private bool isLoadLayer;
        public bool IsLoadLayer
        {
            set
            {
                isLoadLayer = value;
                if (isLoadLayer)
                {
                    LoadLayerHandle?.Invoke();
                }
                else
                {
                    NoneLayerHandle?.Invoke();
                }
            }
        }
        #endregion
        #region LoadTiff 加载中的名称标记 
        object layerLock = new object();
        private string isLoadingLayerName = "";
        public void SetLoadingLayer(string layerName)
        {
            lock (layerLock)
            {
                isLoadingLayerName = layerName;
            }
        }

        public bool IsLoadingLayer(string layerName)
        {
            lock (layerLock)
            {
                return isLoadingLayerName == layerName;
            }
        }
        #endregion
        #endregion
        #endregion

        #region ZoomTiff
        /// <summary>
        /// 定位到地图指定工作区
        /// </summary>
        private void ZoomTiffButton_Click(object sender, EventArgs e)
        {
            GCSViews.FlightPlanner.instance.zoomToTiffLayer();
            //GCSViews.FlightData.instance.zoomToTiffLayer();
        }
        #endregion

        #region ManagerTiff
        #region ManagerTiff 入口函数
        /// <summary>
        /// 显示或隐藏LayerManager停靠栏
        /// </summary>
        private void ManagerTiffButton_Click(object sender, EventArgs e)
        {
            if (!TiffManagerButton.Checked)
            {
                TiffManagerButton.Checked = true;
                ((System.ComponentModel.ISupportInitialize)(this.BottomBar)).BeginInit();
                LayerManagerDockContainerItem.Visible = true;
                BottomBar.SelectedDockContainerItem = LayerManagerDockContainerItem;
                ((System.ComponentModel.ISupportInitialize)(this.BottomBar)).EndInit();
                this.BottomBar.ResumeLayout(false);
            }
            else
            {
                TiffManagerButton.Checked = false;
                ((System.ComponentModel.ISupportInitialize)(this.BottomBar)).BeginInit();
                LayerManagerDockContainerItem.Visible = false;
                //LeftBar.SelectedDockContainerItem = LayerReaderDockContainerItem;
                ((System.ComponentModel.ISupportInitialize)(this.BottomBar)).EndInit();
                this.BottomBar.ResumeLayout(false);
            }
        }
        #endregion
        #region 接口函数
        public void ManagerTiffLayer()
        {
            ManagerTiffButton_Click(this, null);
        }
        #endregion
        #endregion

        #endregion

        #region 航摄区域模块

        #region DrawPolygon
        private void DrawPolygonButton_Click(object sender, EventArgs e)
        {
            if (!DrawPolygonButton.Checked)
                GCSViews.FlightPlanner.instance.DrawPolygon();
            else
                GCSViews.FlightPlanner.instance.LeavePolygon();
        }
        #endregion

        #region ClearPolygon
        private void ClearPolygonButton_Click(object sender, EventArgs e)
        {
            GCSViews.FlightPlanner.instance.ClearPloygon();
        }
        #endregion

        #region SelectedPolygon

        #region SelectedPolygon 选中首个
        private void FirstPolygonButton_Click(object sender, EventArgs e)
        {
            GCSViews.FlightPlanner.instance.polygonMarkersGroupFirst();
        }
        #endregion

        #region SelectedPolygon 选中下一个
        private void NextPolygonButton_Click(object sender, EventArgs e)
        {
            GCSViews.FlightPlanner.instance.polygonMarkersGroupNext();
        }
        #endregion

        #region SelectedPolygon 选中上一个
        private void PrevPolygonButton_Click(object sender, EventArgs e)
        {
            GCSViews.FlightPlanner.instance.polygonMarkersGroupPrev();
        }
        #endregion

        #region SelectedPolygon 选中全部
        private void AllPolygonButton_Click(object sender, EventArgs e)
        {
            GCSViews.FlightPlanner.instance.polygonMarkersGroupAddAll();
        }
        #endregion

        #region SelectedPolygon 取消选中
        private void CancelPolygonButton_Click(object sender, EventArgs e)
        {
            GCSViews.FlightPlanner.instance.polygonMarkersGroupClear();
        }
        #endregion

        #region SelectedPolygon 删除选中
        private void DeleteSelectedPolygonButton_Click(object sender, EventArgs e)
        {
            GCSViews.FlightPlanner.instance.DeleteCurrentPolygon();
        }
        #endregion

        #endregion

        #region PolygonList
        #region PolygonList 访问器
        private void SetPolygonList(List<PointLatLngAlt> polygonList)
        {

        }

        #endregion
        #endregion

        #region SavePolygon
        private void SavePolygonButton_Click(object sender, EventArgs e)
        {
            GCSViews.FlightPlanner.instance.SavePolygonFile();
        }
        #endregion

        #region LoadPolygon
        private void LoadPolygonButton_Click(object sender, EventArgs e)
        {
            GCSViews.FlightPlanner.instance.LoadPolygonFile();
        }
        #endregion

        #endregion

        #region 航点规划模块

        #region DrawWP
        private void DrawWPButton_Click(object sender, EventArgs e)
        {
            if (!DrawWPButton.Checked)
                GCSViews.FlightPlanner.instance.DrawWP();
            else
                GCSViews.FlightPlanner.instance.LeaveWP();
        }
        #endregion

        #region ClearWP
        private void ClearWPButton_Click(object sender, EventArgs e)
        {
            GCSViews.FlightPlanner.instance.ClearMission();
        }
        #endregion

        #region AutoWP

        #region AutoWP 入口函数
        private void AutoWPButton_Click(object sender, EventArgs e)
        {
            if (!AutoWPButton.Checked)
            {
                bool hide = IsLeftBarHide();
                AutoWPButton.Checked = true;
                CustomData.WP.WPGlobalData.instance.PolygonListChange += VPS.Controls.Grid.GridConfig.instance.SetPolygonList;

                ((System.ComponentModel.ISupportInitialize)(this.LeftBar)).BeginInit();
                AutoGridDockContainerItem.Visible = true;
                LeftBar.SelectedDockContainerItem = AutoGridDockContainerItem;

                ((System.ComponentModel.ISupportInitialize)(this.LeftBar)).EndInit();
                this.LeftBar.AutoHide = hide;
                this.LeftBar.ResumeLayout(false);

                VPS.Controls.Grid.GridConfig.instance.SetPolygonList();
            }
            else
            {
                AutoWPButton.Checked = false;
                CustomData.WP.WPGlobalData.instance.PolygonListChange -= VPS.Controls.Grid.GridConfig.instance.SetPolygonList;

                ((System.ComponentModel.ISupportInitialize)(this.LeftBar)).BeginInit();
                VPS.Controls.Grid.GridConfig.instance.SaveSetting();
                AutoGridDockContainerItem.Visible = false;
                this.LeftBar.AutoHide = this.LeftBar.AutoHide;
                ((System.ComponentModel.ISupportInitialize)(this.LeftBar)).EndInit();
                this.LeftBar.ResumeLayout(false);
            }
        }
        #endregion

        #region AutoWP 对外接口
        public void AutoWP()
        {
            AutoWPButton_Click(null, null);
        }
        #endregion

        #region 辅助函数
        public void AutoGridQuestWPList()
        {
        }
        #endregion

        #endregion

        #region SelectedWP

        #region SelectedWP 选中首个
        private void FirstWPButton_Click(object sender, EventArgs e)
        {
            GCSViews.FlightPlanner.instance.wpMarkersGroupFirst();
        }
        #endregion

        #region SelectedWP 选中下一个
        private void NextWPButton_Click(object sender, EventArgs e)
        {
            GCSViews.FlightPlanner.instance.wpMarkersGroupNext();
        }
        #endregion

        #region SelectedWP 选中上一个
        private void PrevWPButton_Click(object sender, EventArgs e)
        {
            GCSViews.FlightPlanner.instance.wpMarkersGroupPrev();
        }
        #endregion

        #region SelectedWP 选中全部
        private void AllWPButton_Click(object sender, EventArgs e)
        {
            GCSViews.FlightPlanner.instance.wpMarkersGroupAddAll();
        }
        #endregion

        #region SelectedWP 取消选中
        private void CancelWPButton_Click(object sender, EventArgs e)
        {
            GCSViews.FlightPlanner.instance.wpMarkersGroupClear();
        }
        #endregion

        #region SelectedWP 删除选中
        private void DeleteSelectedWPButton_Click(object sender, EventArgs e)
        {
            GCSViews.FlightPlanner.instance.DeleteCurrentWP();
        }
        #endregion

        #endregion

        #region SaveWP
        private void SaveWPButton_Click(object sender, EventArgs e)
        {
            GCSViews.FlightPlanner.instance.SaveWPFile();
        }
        #endregion

        #region LoadWP
        private void LoadWPButton_Click(object sender, EventArgs e)
        {
            GCSViews.FlightPlanner.instance.LoadWPFile();
        }
        #endregion

        #endregion

        #region 撤销模块

        #region Undo 入口函数
        private void UndoButton_Click(object sender, EventArgs e)
        {
            CustomData.WP.WPGlobalData.instance.UndoHistory();
        }
        #endregion

        #region Undo 状态更改
        private void historyChange(int Count)
        {
            if (Count > 0)
                this.UndoButton.Enabled = true;
            else
                this.UndoButton.Enabled = false;
        }
        #endregion

        #endregion

        #region 切换主体
        private void AppCommandTheme_Executed(object sender, EventArgs e)
        {
            ICommandSource source = sender as ICommandSource;
            if (source.CommandParameter is string)
            {
                eStyle style = (eStyle)Enum.Parse(typeof(eStyle), source.CommandParameter.ToString());
                Settings.Instance["formStyle"] = source.CommandParameter.ToString();
                // Using StyleManager change the style and color tinting
                this.styleManager.ManagerStyle = style;
                this.styleManager.ManagerColorTint = System.Drawing.Color.Empty;
                //StyleManager.ChangeStyle(style, System.Drawing.Color.Empty);
                //if (style == eStyle.Office2007Black || style == eStyle.Office2007Blue || style == eStyle.Office2007Silver || style == eStyle.Office2007VistaGlass)
                //    StartButton.BackstageTabEnabled = false;
                //else
                //    StartButton.BackstageTabEnabled = true;
            }
            else if (source.CommandParameter is Color)
            {
                //StyleManager.ColorTint = (Color)source.CommandParameter;
                this.styleManager.ManagerColorTint = (Color)source.CommandParameter;
            }
        }
        #endregion

        #region 隐藏功能区
        private void RibbonStateCommand_Executed(object sender, EventArgs e)
        {
            MinMenuBar.Expanded = RibbonStateCommand.Checked;
            RibbonStateCommand.Checked = !RibbonStateCommand.Checked;
        }
        #endregion

        #endregion

        #region 停靠栏

        #region 左
        public bool IsLeftBarHide()
        {
            return this.LeftBar.AutoHide;
        }

        public void SetLeftBarHide(bool isHide)
        {
            this.LeftBar.AutoHide = isHide;
        }
        #endregion

        #region 下
        public bool IsBottomBarHide()
        {
            return this.BottomBar.AutoHide;
        }

        public void SetBottomBarHide(bool isHide)
        {
            this.BottomBar.AutoHide = isHide;
        }
        #endregion

        #region 右
        public bool IsRightBarHide()
        {
            return false;
        }

        public void SetRightBarHide(bool isHide)
        {
        }
        #endregion

        #region ConfigGrid
        public bool IsConfigGridVisible()
        {
            return VPS.Controls.Grid.GridConfig.instance.Visible;
        }
        #endregion

        #endregion

        #region 快捷键

        #region 入口函数
        private void MainV2_KeyDown(object sender, KeyEventArgs e)
        {
            Message temp = new Message();
            ProcessCmdKey(ref temp, e.KeyData);
            Console.WriteLine("MainV2_KeyDown " + e.ToString());
        }
        #endregion

        #region 快捷键触发函数
        /// <summary>
        /// keyboard shortcuts override
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //if (GCSViews.ConfigTerminal.SSHTerminal) { return false; }
            //if (keyData == Keys.F12)
            //{
            //    MenuConnect_Click(null, null);
            //    return true;
            //}

            if (keyData == Keys.F1)
            {
                LoadProjectButton_Click(this, null);
                return true;
            }
            if (keyData == Keys.F2)
            {
                SaveProjectButton_Click(this, null);
                return true;
            }

            if (keyData == Keys.F5)
            {
                LoadTiffButton_Click(this, null);
                return true;
            }

            if (keyData == Keys.F6)
            {
                ZoomTiffButton_Click(this, null);
                return true;
            }

            if (keyData == Keys.F7)
            {
                ManagerTiffButton_Click(this, null);
                return true;
            }

            if (keyData == (Keys.Alt | Keys.E))
            {
                DrawPolygonButton_Click(this, null);
                return true;
            }

            if (keyData == (Keys.Control | Keys.E))
            {
                DrawWPButton_Click(this, null);
                return true;
            }

            if (keyData == (Keys.Control | Keys.D))
            {
                ClearWPButton_Click(this, null);
                return true;
            }

            if (keyData == (Keys.Alt | Keys.D))
            {
                ClearPolygonButton_Click(this, null);
                return true;
            }

            if (keyData == (Keys.Control | Keys.G))
            {
                AutoWPButton_Click(this, null);
                return true;
            }

            // open wp file
            if (keyData == (Keys.Control | Keys.S))
            {
                SaveWPButton_Click(this, null);
                return true;
            }

            // save wp file
            if (keyData == (Keys.Control | Keys.O))
            {
                LoadWPButton_Click(this, null);
                return true;
            }

            if (keyData == (Keys.Control | Keys.Z))
            {
                CustomData.WP.WPGlobalData.instance.UndoHistory();
                return true;
            }

            if (ProcessCmdKeyCallback != null)
            {
                return ProcessCmdKeyCallback(ref msg, keyData);
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        public delegate bool ProcessCmdKeyHandler(ref Message msg, Keys keyData);

        public event ProcessCmdKeyHandler ProcessCmdKeyCallback;

        #endregion

        #region 工作区

        #region AddLayer 入口函数
        public bool ShowLayerOverlay(string path)
        {
            var layerInfo = CustomData.Layer.MemoryLayerCache.GetLayerFromMemoryCache(path);
            return SetLayerOverlay(layerInfo);
        }

        public bool AddLayerOverlay(string path, VPS.CustomData.WP.Position home, Color transparent)
        {
            var layerInfo = new CustomData.Layer.TiffLayerInfo(path, home, transparent);
            CustomData.Layer.MemoryLayerCache.AddLayerToMemoryCache(layerInfo);
            return SetLayerOverlay(layerInfo);
        }

        public bool AddLayerOverlay(CustomData.Layer.LayerInfo info)
        {
            CustomData.Layer.MemoryLayerCache.AddLayerToMemoryCache(info);
            return SetLayerOverlay(info);
        }
        #endregion

        #region LoadLayer 入口函数
        private bool SetLayerOverlay(CustomData.Layer.LayerInfo layerInfo)
        {
            if (File.Exists(layerInfo.Layer))
            {
                var geoBitmap = GDAL.GDAL.LoadImageInfo(layerInfo.Layer);
                if (geoBitmap != null && !geoBitmap.Rect.IsEmpty)
                {
                    SetLoadingLayer(geoBitmap.File);

                    ZoomTiffButton_Click(this, null);

                    if (layerInfo is CustomData.Layer.TiffLayerInfo)
                    {
                        Func<GDAL.GDAL.GeoBitmap, Color, GDAL.GDAL.GeoBitmap> GetGeoBitmap = (_bitmap, _transparent) =>
                        {
                            _bitmap.SetTransparent(_transparent);

                            return _bitmap;
                        };

                        IAsyncResult iar = GetGeoBitmap.BeginInvoke(
                            geoBitmap, ((CustomData.Layer.TiffLayerInfo)layerInfo).Transparent, 
                            CallbackWhenDone, this);
                    }
                    
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private void CallbackWhenDone(IAsyncResult iar)
        {
            AsyncResult ar = (AsyncResult)iar;
            Func<GDAL.GDAL.GeoBitmap, Color, GDAL.GDAL.GeoBitmap> geoFunc = (Func<GDAL.GDAL.GeoBitmap, Color, GDAL.GDAL.GeoBitmap>)ar.AsyncDelegate;

            var geoBitmap = geoFunc.EndInvoke(iar);
            if (geoBitmap.DisplayBitmap != null)
            {
                if (IsLoadingLayer(geoBitmap.File))
                {
                    IsLoadLayer = true;
                    ShowLayerOverlay(geoBitmap);
                }
            }
        }
        #endregion

        #region ShowLayer 入口函数
        private void ShowLayerOverlay(GDAL.GDAL.GeoBitmap geoBitmap)
        { 
            GCSViews.FlightPlanner.instance.ShowLayerOverlay(geoBitmap);
        }
        #endregion

        #region 图像切片
        public class LayerTile
        {
            public Bitmap _tile;
            public GMap.NET.RectLatLng _rect;
            public LayerTile(Bitmap tile, GMap.NET.RectLatLng rect)
            {
                _tile = tile;
                _rect = rect;
            }
        }

        static public List<LayerTile> CreateTile(GeoBitmap _bitmap, int _tileXSize, int _tileYSize)
        {
            List<LayerTile> _tiles = new List<LayerTile>();
            int TileXLen = 1024, TileYLen = 1024, RasterXSize = _bitmap.RasterXSize, RasterYSize = _bitmap.RasterYSize;
            int TileXSize = RasterXSize / TileXLen + (RasterXSize % TileXLen == 0 ? 0 : 1);
            int TileYSize = RasterYSize / TileYLen + (RasterYSize % TileYLen == 0 ? 0 : 1);
            //创建进度条
            string porgressKey = VPS.Controls.MainInfo.TopMainInfo.instance.CreateProgressEnter(
                "加载工作区：" + CustomData.Layer.MemoryLayerCache.GetHashCode(_bitmap.File));
            string messageKey = VPS.Controls.MainInfo.TopMainInfo.instance.CreateMessageBoxEnter();

            var bar = VPS.Controls.MainInfo.TopMainInfo.instance.GetProgress(porgressKey);
            var box = VPS.Controls.MainInfo.TopMainInfo.instance.GetMessageBox(messageKey);
            try
            {

                for (int i = 0; i < TileXSize; i++)
                {
                    for (int j = 0; j < TileYSize; j++)
                    {
                        Bitmap tile = LoadTileImage(_bitmap.File, i * TileXLen, j * TileYLen, TileXLen, TileYLen);
                        double[] pos1 = _bitmap.GetPosition(i * TileXLen, j * TileYLen);
                        double[] pos2 = _bitmap.GetPosition(
                            Math.Min(RasterXSize, (i + 1) * TileXLen),
                            Math.Min(RasterYSize, (j + 1) * TileYLen));

                        GMap.NET.RectLatLng position = new GMap.NET.RectLatLng(
                            Math.Max(pos1[1], pos2[1]), Math.Min(pos1[0], pos2[0]),
                            Math.Abs(pos1[0] - pos2[0]), Math.Abs(pos1[1] - pos2[1]));
                        _tiles.Add(new LayerTile(tile, position));
                        bar.SetProgress((double)(i * TileYSize + j) / (TileXSize * TileYSize));
                    }
                }
                box.SetInfoMessage(string.Format("【{0}】加载完成！", _bitmap.File));
                bar.SetProgressSuccess("加载完成");
                return _tiles;
            }
            catch
            {
                box.SetInfoMessage(string.Format("【{0}】加载失败！", _bitmap.File));
                bar.SetProgressFailure("加载失败");
                return new List<LayerTile>();
            }
            finally
            {
                if (porgressKey != null)
                    VPS.Controls.MainInfo.TopMainInfo.instance.DisposeControlEnter(porgressKey, 5000);
                if (messageKey !=null)
                    VPS.Controls.MainInfo.TopMainInfo.instance.DisposeControlEnter(messageKey, 5000);
            }

        }
        #endregion

        #endregion

        private VPS.CustomData.WP.WPGlobalData WPGlobalData = new VPS.CustomData.WP.WPGlobalData();

        private void OpenProjectItem_Click(object sender, EventArgs e)
        {
            this.LoadProjectButton_Click(sender, e);
        }

        private void SaveProjectItem_Click(object sender, EventArgs e)
        {
            this.SaveProjectButton_Click(sender, e);
        }

        private void CloseProjectItem_Click(object sender, EventArgs e)
        {

        }

        private void ImportWPItem_Click(object sender, EventArgs e)
        {
            this.LoadWPButton_Click(sender, e);
        }

        private void ImportPolyItem_Click(object sender, EventArgs e)
        {
            this.LoadPolygonButton_Click(sender, e);
        }

        private void ExportWPItem_Click(object sender, EventArgs e)
        {
            this.SaveWPButton_Click(sender, e);
        }

        private void ExportPolyItem_Click(object sender, EventArgs e)
        {
            this.SavePolygonButton_Click(sender, e);
        }

        private void WorkSpaceItem_Click(object sender, EventArgs e)
        {
            this.LoadTiffButton_Click(sender, e);
        }

        private void ImportGirdConfig_Click(object sender, EventArgs e)
        {
            VPS.Controls.Grid.GridConfig.instance.LoadGrid();
        }

        private void ExportGirdConfig_Click(object sender, EventArgs e)
        {
            VPS.Controls.Grid.GridConfig.instance.SaveGrid();
        }

        private void ZoomToPolygonButton_Click(object sender, EventArgs e)
        {
            GCSViews.FlightPlanner.instance.ZoomToCenterPolygon();
        }

        private void ZoomToWPButton_Click(object sender, EventArgs e)
        {
            GCSViews.FlightPlanner.instance.ZoomToCenterWP();
        }

        private void MakerStyleButton_Click(object sender, EventArgs e)
        {
            using (var style = new VPS.Controls.CustomForms.CustomMarkerStyle(
                VPS.Controls.Icon.Marker.Style.normal))
            {
                style.Name = "WP 风格";
                if (style.ShowDialog() == DialogResult.OK)
                {
                }
            }
        }
    }
}
