using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace VPS.Maps
{
    [Serializable]
    public class GMapMarkerPolygon : GMarkerGoogle
    {

        public bool selected = false;
        SizeF txtsize = SizeF.Empty;
        static Dictionary<string, Bitmap> fontBitmaps = new Dictionary<string, Bitmap>();
        static Font font;
        string no;

        public GMapMarkerPolygon(PointLatLng p, string tag)
            : base(p, GMarkerGoogleType.red)
        {
            if (font == null)
                font = SystemFonts.DefaultFont;

            no = tag;
            if (!fontBitmaps.ContainsKey(no))
            {
                Bitmap temp = new Bitmap(100, 40, PixelFormat.Format32bppArgb);
                using (Graphics g = Graphics.FromImage(temp))
                {
                    txtsize = g.MeasureString(no, font);

                    g.DrawString(no, font, Brushes.Black, new PointF(0, 0));
                }
                fontBitmaps[no] = temp;
            }
            
            ToolTipText = "grid" + tag;
            Tag = "grid" + tag;
        }

        public override void OnRender(IGraphics g)
        {
            if (selected)
            {
                g.FillEllipse(Brushes.DeepSkyBlue, new Rectangle(this.LocalPosition, this.Size));
                g.DrawArc(Pens.DeepSkyBlue, new Rectangle(this.LocalPosition, this.Size), 0, 360);
            }

            base.OnRender(g);

            var midw = LocalPosition.X + 10;
            var midh = LocalPosition.Y + 3;

            if (txtsize.Width > 15)
                midw -= 4;

            if (Overlay.Control.Zoom > 16 || IsMouseOver)
                g.DrawImageUnscaled(fontBitmaps[no], midw, midh);
        }
    }
}
