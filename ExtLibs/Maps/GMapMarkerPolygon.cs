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
        static Dictionary<string, Bitmap> fontBitmaps = new Dictionary<string, Bitmap>();
        private static Font font = SystemFonts.DefaultFont;
        private static GMarkerGoogleType icon = GMarkerGoogleType.red;
        private static Color color = Color.DeepSkyBlue;

        string no;
        public bool selected = false;

        SizeF txtsize = SizeF.Empty;

        public GMapMarkerPolygon(PointLatLng p, string tag)
            : base(p, GMarkerGoogleType.red)
        {
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

            IsVisible = true;

            Tag = "grid" + tag;
        }

        public int GetNo()
        {
            if (int.TryParse(no, out int id))
                return id;
            else
                return -1;
        }

        public override void OnRender(IGraphics g)
        {
            if (selected)
            {
                g.FillEllipse(new SolidBrush(color), new Rectangle(this.LocalPosition, this.Size));
                g.DrawArc(new Pen(color), new Rectangle(this.LocalPosition, this.Size), 0, 360);
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
