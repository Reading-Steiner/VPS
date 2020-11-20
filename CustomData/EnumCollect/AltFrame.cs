using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPS.CustomData.EnumCollect
{
    public class AltFrame
    {
        public enum Mode
        {
            Relative = MAVLink.MAV_FRAME.GLOBAL_RELATIVE_ALT,
            Absolute = MAVLink.MAV_FRAME.GLOBAL,
            Terrain = MAVLink.MAV_FRAME.GLOBAL_TERRAIN_ALT
        }

        static public readonly string Relative = "Relative";
        static public readonly string Absolute = "Absolute";
        static public readonly string Terrain = "Terrain";

        static public readonly List<string> Modes = new List<string>()
        {Relative,Absolute,Terrain };

        static public Mode GetAltFrame(string frame)
        {
            if (Enum.TryParse(frame, out Mode mode))
                return mode;
            else
                return Mode.Relative;
        }

        static public string GetAltFrame(Mode frame)
        {
            return frame.ToString();
        }
    }
}
