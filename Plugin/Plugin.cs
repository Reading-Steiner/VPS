﻿using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using VPS.GCSViews;
using VPS.Utilities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace VPS.Plugin
{
    public abstract class Plugin
    {
        public Assembly Assembly = null;

        public PluginHost Host { get; internal set; }

        public abstract string Name { get; }
        public abstract string Version { get; }
        public abstract string Author { get; }

        /// <summary>
        /// this is the datetime loop will run next and can be set in loop, to override the loophzrate
        /// </summary>
        public virtual DateTime NextRun { get; set; }

        /// <summary>
        /// Run First, checking plugin
        /// </summary>
        /// <returns></returns>
        public abstract bool Init();

        /// <summary>
        /// Load your own code here, this is only run once on loading
        /// </summary>
        /// <returns></returns>
        public abstract bool Loaded();

        /// <summary>
        /// for future expansion
        /// </summary>
        /// <param name="gui"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public virtual bool SetupUI(int gui = 0, object data = null)
        {
            return true;
        }

        /// <summary>
        /// Run at NextRun time - loop is run in a background thread. and is shared with other plugins
        /// </summary>
        /// <returns></returns>
        public virtual bool Loop()
        {
            return true;
        }

        /// <summary>
        /// run at a specific hz rate.
        /// </summary>
        public virtual float loopratehz { get; set; }

        /// <summary>
        /// Exit is only called on plugin unload. not app exit
        /// </summary>
        /// <returns></returns>
        public abstract bool Exit();
    }

    public class PluginHost
    {
        /// <summary>
        /// Device change event
        /// </summary>
        public event MainV2.WMDeviceChangeEventHandler DeviceChanged;

        internal void ProcessDeviceChanged(MainV2.WM_DEVICECHANGE_enum dc)
        {
            if (DeviceChanged != null)
            {
                try
                {
                    DeviceChanged(dc);
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// access to the main form, this is on a diffrent thread.
        /// </summary>
        public MainV2 MainForm
        {
            get { return MainV2.instance; }
        }

        /// <summary>
        /// access to all the current stats of the mav
        /// </summary>
        public CurrentState cs
        {
            get { return MainV2.comPort.MAV.cs; }
        }

        /// <summary>
        /// access to mavlink functions
        /// </summary>
        public MAVLinkInterface comPort
        {
            get { return MainV2.comPort; }
        }

        /// <summary>
        /// access to mp settings
        /// </summary>
        public Settings config
        {
            get { return Settings.Instance; }
        }

        ///// <summary>
        ///// add things to flightdata map menu
        ///// </summary>
        //public ContextMenuStrip FDMenuMap
        //{
        //    get { return MainV2.instance.FlightData.contextMenuStripMap; }
        //}

        ///// <summary>
        ///// The point where the menu was drawn
        ///// </summary>
        //public PointLatLng FDMenuMapPosition
        //{
        //    get { return MainV2.instance.FlightData.MouseDownStart; }
        //}

        public GMapProvider FPMapType
        {
            get { return FlightPlanner.myMap.MapProvider; }
        }

        ///// <summary>
        ///// add things to flightdata hud menu
        ///// </summary>
        //public ContextMenuStrip FDMenuHud
        //{
        //    get { return MainV2.instance.FlightData.contextMenuStripHud; }
        //}

        /// <summary>
        /// add things to flightplanner map menu
        /// </summary>
        public ContextMenuStrip FPMenuMap
        {
            get { return MainV2.instance.FlightPlanner.contextMenuStripMain; }
        }

        /// <summary>
        /// The point where the menu was drawn
        /// </summary>
        public PointLatLng FPMenuMapPosition
        {
            get { return MainV2.instance.FlightPlanner.MouseDownEnd; }
        }

        /// <summary>
        /// The polygon drawn by the user on the FP page
        /// </summary>
        public GMapPolygon FPDrawnPolygon
        {
            get
            {
                return new GMapPolygon(new List<PointLatLng>(MainV2.instance.FlightPlanner.drawnpolygon.Points),
                    "Poly Copy")
                { Stroke = MainV2.instance.FlightPlanner.drawnpolygon.Stroke };
            }
        }

        public void RedrawFPPolygon(List<PointLatLngAlt> list)
        {
            CustomData.WP.WPGlobalData.instance.SetPolyListHandle(
                CustomData.WP.WPGlobalData.FromWGS84WPList(list));
        }

        /// <summary>
        /// the map control in flightplanner
        /// </summary>
        public GMapControl FPGMapControl
        {
            get { return MainV2.instance.FlightPlanner.MainMap; }
        }

        ///// <summary>
        ///// the map control in flightdata
        ///// </summary>
        //public GMapControl FDGMapControl
        //{
        //    get { return MainV2.instance.FlightData.MainMap; }
        //}

        /// <summary>
        /// add wp to command queue - dont upload to mav
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="p4"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public int AddWPtoList(MAVLink.MAV_CMD cmd, double p1, double p2, double p3, double p4, double x, double y,
            double z, object tag = null)
        {
            var wp = new CustomData.WP.VPSPosition(x, y, z);
            wp.Command = cmd.ToString();
            if (tag != null)
                wp.AltMode = tag.ToString();
            else
                wp.AltMode = "Relative";
            //wp.Param1 = p1;
            //wp.Param2 = p2;
            //wp.Param3 = p3;
            //wp.Param4 = p4;

            int index = CustomData.WP.WPGlobalData.instance.AddWPHandle(wp);
            return index;
        }

        public void InsertWP(int idx, MAVLink.MAV_CMD cmd, double p1, double p2, double p3, double p4, double x,
            double y,
            double z, object tag = null)
        {
            var wp = new CustomData.WP.VPSPosition(x, y, z);
            wp.Command = cmd.ToString();
            if (tag != null)
                wp.AltMode = tag.ToString();
            else
                wp.AltMode = "Relative";
            //wp.Param1 = p1;
            //wp.Param2 = p2;
            //wp.Param3 = p3;
            //wp.Param4 = p4;

            CustomData.WP.WPGlobalData.instance.InsertWPHandle(idx, wp);
        }

        public int AddWPtoList(MAVLink.MAV_CMD cmd, double p1, double p2, double p3, double p4, double x, double y,
            double z)
        {
            return AddWPtoList(cmd, p1, p2, p3, p4, x, y, z, null);
        }

        public void InsertWP(int idx, MAVLink.MAV_CMD cmd, double p1, double p2, double p3, double p4, double x,
            double y,
            double z)
        {
            InsertWP(idx, cmd, p1, p2, p3, p4, x, y, z, null);
        }

        /// <summary>
        /// refresh command list on flight planner tab from autopilot
        /// </summary>
        public void GetWPs()
        {

        }
    }
}