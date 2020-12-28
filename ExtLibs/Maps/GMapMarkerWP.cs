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
    public class GMapMarkerWP : GMarkerGoogle
    {
        string tips = "";
        SizeF txtsize = SizeF.Empty;

        public bool Selected = false;
        public string Command = "WAYPOINT";
        private static Dictionary<string, Bitmap> fontBitmaps = new Dictionary<string, Bitmap>();
        private readonly static Font font = SystemFonts.DefaultFont;
        private readonly static GMarkerGoogleType icon = GMarkerGoogleType.green;
        private readonly static Color color = Color.Red;

        public GMapMarkerWP(VPS.Utilities.PointLatLngAlt p, string wpno)
            : base(p, GMapMarkerStyle.ExistGMapMarkerStyle(p.Tag) ? GMapMarkerStyle.GetGMapMarkerStyle(p.Tag).Type : icon)
        {
            tips = wpno;

            Command = p.Tag;

            Font TipFont = font;
            TipFont = GMapMarkerStyle.ExistGMapMarkerStyle(Command) ? GMapMarkerStyle.GetGMapMarkerStyle(Command).TipFont : font;

            if (!fontBitmaps.ContainsKey(tips))
            {
                Bitmap temp = new Bitmap(100,40, PixelFormat.Format32bppArgb);
                using (Graphics g = Graphics.FromImage(temp))
                {
                    txtsize = g.MeasureString(tips, TipFont);

                    g.DrawString(tips, SystemFonts.DefaultFont, Brushes.Black, new PointF(0, 0));
                }
                fontBitmaps[tips] = temp;
            }

            ToolTipFont = TipFont;
        }

        public override void OnRender(IGraphics g)
        {
            if (Selected)
            {
                Color SedColor = GMapMarkerStyle.ExistGMapMarkerStyle(Command) ? GMapMarkerStyle.GetGMapMarkerStyle(Command).SedColor : color;

                g.FillEllipse(new SolidBrush(SedColor), new Rectangle(this.LocalPosition, this.Size));
                g.DrawArc(new Pen(SedColor), new Rectangle(this.LocalPosition, this.Size), 0, 360);
            }
            
            base.OnRender(g);

            var midw = LocalPosition.X + 10;
            var midh = LocalPosition.Y + 3;

            if (txtsize.Width > 15)
                midw -= 4;

            if (Overlay.Control.Zoom > 16 || IsMouseOver)
            {
                g.DrawImageUnscaled(fontBitmaps[tips], midw, midh);
            }
        }
    }
}