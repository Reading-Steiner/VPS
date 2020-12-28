using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPS.Controls.Icon
{
    public class Marker
    {
        #region Icon
        public enum Style
        {
            normal,
            small,
            dot,
            pushpin,
            big,
            all
        }

        #region 筛选Icon
        public static List<KeyValuePair<int, string>> CustomMarkerIcon(Style style)
        {
            List<KeyValuePair<int, string>> EnumDataList = Utilities.EnumTranslator.EnumToList<GMap.NET.WindowsForms.Markers.GMarkerGoogleType>();
            EnumDataList.Remove(EnumDataList.Find(s => s.Key == (int)GMap.NET.WindowsForms.Markers.GMarkerGoogleType.none));

            switch (style)
            {
                case Style.all:
                    break;
                case Style.normal:
                    EnumDataList.RemoveAll(s => s.Value.Contains("_"));
                    break;
                case Style.dot:
                    EnumDataList.RemoveAll(s => !s.Value.Contains("dot"));
                    break;
                case Style.pushpin:
                    EnumDataList.RemoveAll(s => !s.Value.Contains("pushpin"));
                    break;
                case Style.small:
                    EnumDataList.RemoveAll(s => !s.Value.Contains("small"));
                    break;
                case Style.big:
                    EnumDataList.RemoveAll(s => !s.Value.Contains("big"));
                    break;
                default:
                    break;
            }
            return EnumDataList;
        }
        #endregion

        #region 获取Icon
        public static Image GetIcon(string name)
        {
            Image ret = new Bitmap(new System.IO.MemoryStream(
                GMap.NET.Drawing.Properties.Resources.ResourceManager.GetObject(
                    name, GMap.NET.Drawing.Properties.Resources.Culture) as byte[]));
            return ret;
        }
        #endregion

        #endregion
    }
}
