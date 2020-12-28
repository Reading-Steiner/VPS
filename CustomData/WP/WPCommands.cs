using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPS.CustomData.WP
{
    class WPCommands
    {
        static public readonly string DefaultWPCommand = "WAYPOINT";
        static public readonly string SplineWPCommand = "SPLINE_WAYPOINT";
        static public readonly string ClickWPCommand = "INTERNALS_WAYPOINT";
        static public readonly string HomeCommand = "H";

        static public readonly List<string> CoordsWPCommands =
            new List<string>() { DefaultWPCommand, SplineWPCommand, HomeCommand, ClickWPCommand };
    }

    class WPLines
    {
        static public readonly string DefaultWPLine = "WAYLINE";
        static public readonly string SplineWPLine = "SPLINE_WAYLINE";
        static public readonly string HomeWPLine = "HOME_WAYLINE";
    }

    public class Convert
    {
        static public string ToString(Maps.GMapMarkerStyle style)
        {
            if (style == null)
                return "";
            return string.Format("[{0}、{1}、{2}]", 
                style.Type.ToString(), 
                new System.Drawing.FontConverter().ConvertToString(style.TipFont), 
                System.Drawing.ColorTranslator.ToHtml(style.SedColor));
        }

        static public Maps.GMapMarkerStyle ToMarkerStyle(string format)
        {
            if (!(format.StartsWith("[") && format.EndsWith("]")))
                return null;
            string[] list = format.Replace("[", "").Replace("]", "").Split('、');
            if (list.Count<string>() != 3)
                return null;
            return new Maps.GMapMarkerStyle(
                System.Drawing.ColorTranslator.FromHtml(list[2]),
                (new System.Drawing.FontConverter()).ConvertFromString(list[1]) as System.Drawing.Font,
                (GMarkerGoogleType)Enum.Parse(typeof(GMarkerGoogleType), list[0]));


        }

        static public string ToString(Maps.GMapOverlayStyle style)
        {
            if (style == null)
                return "";
            return string.Format("[{0}、{1}、{2}]", 
                style.lineStyle.ToString(), 
                style.lineWidth.ToString(), 
                System.Drawing.ColorTranslator.ToHtml(style.lineColor));
        }

        static public Maps.GMapOverlayStyle ToOverlayStyle(string format)
        {
            if (!(format.StartsWith("[") && format.EndsWith("]")))
                return null;
            string[] list = format.Replace("[", "").Replace("]", "").Split('、');
            if (list.Count<string>() != 3)
                return null;
            return new Maps.GMapOverlayStyle(
                ColorTranslator.FromHtml(list[2]),
                System.Convert.ToInt32(list[1]),
                (DashStyle)Enum.Parse(typeof(DashStyle), list[0]));
        }
    }
}
