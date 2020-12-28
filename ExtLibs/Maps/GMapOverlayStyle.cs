using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace VPS.Maps
{
    public class GMapOverlayStyle
    {
        public DashStyle lineStyle = DashStyle.Custom;
        public int lineWidth = 4;
        public Color lineColor = Color.Yellow;

        public GMapOverlayStyle(Color color, int width, DashStyle style)
        {
            lineStyle = style;
            lineWidth = width;
            lineColor = color;
        }

        public readonly static GMapOverlayStyle DefaultWPStyle = new GMapOverlayStyle(Color.Blue, 3, DashStyle.Custom);
        public readonly static GMapOverlayStyle DefaultHomeStyle = new GMapOverlayStyle(Color.Green, 2, DashStyle.Dash);


        public static Dictionary<string, GMapOverlayStyle> OverlayStyleList = new Dictionary<string, GMapOverlayStyle>();

        static GMapOverlayStyle()
        {
            if (OverlayStyleList == null)
                OverlayStyleList = new Dictionary<string, GMapOverlayStyle>();
        }

        public static bool ExistGMapOverlayStyle(string key)
        {
            if (key == "SPLINE_WAYLINE")
                key = "WAYLINE";
            return OverlayStyleList.ContainsKey(key);
        }

        public static void SetGMapOverlayStyle(string key, GMapOverlayStyle style)
        {
            if (key == "SPLINE_WAYLINE")
                key = "WAYLINE";
            if (OverlayStyleList.ContainsKey(key))
            {
                OverlayStyleList[key] = style;
            }
            else
            {
                OverlayStyleList.Add(key, style);
            }
        }

        public static GMapOverlayStyle GetGMapOverlayStyle(string key)
        {
            if (key == "SPLINE_WAYLINE")
                key = "WAYLINE";
            if (OverlayStyleList.ContainsKey(key))
            {
                return OverlayStyleList[key];
            }
            else
            {
                return null;
            }
            
        }

        public static List<KeyValuePair<string, GMapOverlayStyle>> GetGMapOverlayStyles()
        {
            List<KeyValuePair<string, GMapOverlayStyle>> OverlayStyles = new List<KeyValuePair<string, GMapOverlayStyle>>();
            foreach (var key in OverlayStyleList.Keys)
            {
                OverlayStyles.Add(new KeyValuePair<string, GMapOverlayStyle>(key, OverlayStyleList[key]));
                if (key == "WAYPOINT")
                    OverlayStyles.Add(new KeyValuePair<string, GMapOverlayStyle>("SPLINE_WAYPOINT", OverlayStyleList[key]));
            }
            return OverlayStyles;
        }
    }
}
