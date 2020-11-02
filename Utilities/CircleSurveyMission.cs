using VPS.Controls;
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

            MainV2.instance.FlightPlanner.EnterQuickADD();

            // set roi centerpoint
            var roi = new PointLatLngAlt(centerPoint.Lat, centerPoint.Lng, centerPoint.Alt);
            roi.Tag = MAVLink.MAV_CMD.DO_SET_ROI.ToString();
            roi.Param1 = 0;
            roi.Param2 = 0;
            roi.Param3 = 0;
            roi.Param4 = 0;
            FlightPlanner.instance.AddWPPoint(roi);

            // alts
            for (int alt = startalt; alt <= endalt; alt += seperation)
            {
                // headings
                for (int heading = startheading; heading <= startheading + 360; heading += 360 / photos)
                {
                    MainV2.instance.FlightPlanner.EnterQuickADD();
                    var newpoint = centerPoint.newpos(heading, radius);
                    // add wp
                    var wp = new PointLatLngAlt(newpoint.Lat, newpoint.Lng, alt);
                    wp.Tag = MAVLink.MAV_CMD.WAYPOINT.ToString();
                    wp.Param1 = 2;
                    wp.Param2 = 0;
                    wp.Param3 = 0;
                    wp.Param4 = 0;
                    FlightPlanner.instance.AddWPPoint(wp);
                    // trigger camera
                    var trigger = new PointLatLngAlt(1, 0, 0);
                    trigger.Tag = MAVLink.MAV_CMD.DO_DIGICAM_CONTROL.ToString();
                    trigger.Param1 = 0;
                    trigger.Param2 = 0;
                    trigger.Param3 = 0;
                    trigger.Param4 = 0;
                    FlightPlanner.instance.AddWPPoint(trigger);
                }
            }

            MainV2.instance.FlightPlanner.LeaveQuickADD();

            MainV2.instance.FlightPlanner.writeKML();
        }
    }
}
