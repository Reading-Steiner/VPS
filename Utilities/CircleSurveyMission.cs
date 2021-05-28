﻿using VPS.Controls;
using VPS.GCSViews;

namespace VPS.Utilities
{
    public class CircleSurveyMission
    {
        public static void createGrid(PointLatLngAlt centerPoint)
        {
            int startalt = 10;
            int endalt = 20;
            int seperation = 2;
            int radius = 5;
            int photos = 50;
            int startheading = 0;

            InputBox.Show("", "startalt", ref startalt);
            InputBox.Show("", "endalt", ref endalt);
            InputBox.Show("", "seperation", ref seperation);
            InputBox.Show("", "radius", ref radius);
            InputBox.Show("", "photos", ref photos);
            InputBox.Show("", "start heading", ref startheading);

            CustomData.WP.WPGlobalData.instance.ExecuteWPStartSetting();
            CustomData.WP.WPGlobalData.instance.BegionQuick();

            // set roi centerpoint
            var roi = new CustomData.WP.VPSPosition(centerPoint.Lat, centerPoint.Lng, centerPoint.Alt);
            roi.Command = MAVLink.MAV_CMD.DO_SET_ROI.ToString();
            //roi.Param1 = 0;
            //roi.Param2 = 0;
            //roi.Param3 = 0;
            //roi.Param4 = 0;
            CustomData.WP.WPGlobalData.instance.AddWPHandle(roi);

            // alts
            for (int alt = startalt; alt <= endalt; alt += seperation)
            {
                // headings
                for (int heading = startheading; heading <= startheading + 360; heading += 360 / photos)
                {
                    MainV2.instance.FlightPlanner.EnterQuickADD();
                    var newpoint = centerPoint.newpos(heading, radius);
                    // add wp
                    var wp = new CustomData.WP.VPSPosition(newpoint.Lat, newpoint.Lng, alt);
                    wp.Command = MAVLink.MAV_CMD.WAYPOINT.ToString();
                    //wp.Param1 = 2;
                    //wp.Param2 = 0;
                    //wp.Param3 = 0;
                    //wp.Param4 = 0;
                    CustomData.WP.WPGlobalData.instance.AddWPHandle(wp);
                    // trigger camera
                    var trigger = new CustomData.WP.VPSPosition(1, 0, 0);
                    trigger.Command = MAVLink.MAV_CMD.DO_DIGICAM_CONTROL.ToString();
                    //trigger.Param1 = 0;
                    //trigger.Param2 = 0;
                    //trigger.Param3 = 0;
                    //trigger.Param4 = 0;
                    CustomData.WP.WPGlobalData.instance.AddWPHandle(trigger);
                }
            }

            CustomData.WP.WPGlobalData.instance.EndQuick();

            CustomData.WP.WPGlobalData.instance.ExecuteWPOverSetting();
        }
    }
}
