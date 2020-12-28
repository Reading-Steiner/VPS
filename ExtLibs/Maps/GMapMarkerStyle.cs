using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows;
using GMap.NET.WindowsForms.Markers;

namespace VPS.Maps
{
    public class GMapMarkerStyle
    {
        public Color SedColor = Color.Black;
        public Font TipFont = SystemFonts.DefaultFont;
        public GMarkerGoogleType Type = GMarkerGoogleType.green;

        public GMapMarkerStyle(Color color, Font font, GMarkerGoogleType icon)
        {
            SedColor = color;
            TipFont = font;
            Type = icon;
        }

        public readonly static GMapMarkerStyle DefaultWPStyle = new GMapMarkerStyle(Color.Red, SystemFonts.DefaultFont, GMarkerGoogleType.green);
        public readonly static GMapMarkerStyle DefaultHomeStyle = new GMapMarkerStyle(Color.Red, SystemFonts.DefaultFont, GMarkerGoogleType.green);
        public readonly static GMapMarkerStyle DefaultClickStyle = new GMapMarkerStyle(Color.Red, SystemFonts.DefaultFont, GMarkerGoogleType.blue);


        public static Dictionary<string, GMapMarkerStyle> MarkerStyleList = new Dictionary<string, GMapMarkerStyle>();

        static GMapMarkerStyle()
        {
            if (MarkerStyleList == null)
                MarkerStyleList = new Dictionary<string, GMapMarkerStyle>();
        }

        public static bool ExistGMapMarkerStyle(string key)
        {
            if (key == "SPLINE_WAYPOINT")
                key = "WAYPOINT";
            return MarkerStyleList.ContainsKey(key);
        }

        public static void SetGMapMarkerStyle(string key, GMapMarkerStyle style)
        {
            if (key == "SPLINE_WAYPOINT")
                key = "WAYPOINT";
            if (MarkerStyleList.ContainsKey(key))
            {
                MarkerStyleList[key] = style;
            }
            else
            {
                MarkerStyleList.Add(key, style);
            }
        }

        public static GMapMarkerStyle GetGMapMarkerStyle(string key)
        {
            if (key == "SPLINE_WAYPOINT")
                key = "WAYPOINT";
            if (MarkerStyleList.ContainsKey(key))
            {
                return MarkerStyleList[key];
            }
            else
            {
                return null;
            }
            
        }

        public static List<KeyValuePair<string, GMapMarkerStyle>> GetGMapMarkerStyles()
        {
            List<KeyValuePair<string, GMapMarkerStyle>> MarkerStyles = new List<KeyValuePair<string, GMapMarkerStyle>>();
            foreach (var key in MarkerStyleList.Keys)
            {
                MarkerStyles.Add(new KeyValuePair<string, GMapMarkerStyle>(key, MarkerStyleList[key]));
                if (key == "WAYPOINT")
                    MarkerStyles.Add(new KeyValuePair<string, GMapMarkerStyle>("SPLINE_WAYPOINT", MarkerStyleList[key]));
            }
            return MarkerStyles;
        }


    }
}
