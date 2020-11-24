using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPS.Utilities;

namespace VPS.CustomData.Markers
{
    class GMapMarkerCustom : GMarkerGoogle
    {
        static Dictionary<string, Bitmap> fontBitmaps = new Dictionary<string, Bitmap>();
        string info = "";

        static Font font;
        SizeF txtsize = SizeF.Empty;

        public GMapMarkerCustom(PointLatLngAlt p, string info)
            : base(p, GMarkerGoogleType.green)
        {
            this.info = info;
            if (font == null)
                font = SystemFonts.DefaultFont;

            if (!fontBitmaps.ContainsKey(this.info))
            {
                Bitmap temp = new Bitmap(100, 40, PixelFormat.Format32bppArgb);
                using (Graphics g = Graphics.FromImage(temp))
                {
                    txtsize = g.MeasureString(this.info, font);

                    g.DrawString(this.info, font, Brushes.Black, new PointF(0, 0));
                }
                fontBitmaps[this.info] = temp;
            }
        }

        public override void OnRender(IGraphics g)
        {
            base.OnRender(g);

            var midw = LocalPosition.X + 10;
            var midh = LocalPosition.Y + 3;

            if (txtsize.Width > 15)
                midw -= 4;

            if (Overlay.Control.Zoom > 16 || IsMouseOver)
                g.DrawImageUnscaled(fontBitmaps[info], midw, midh);
        }
    }
}
