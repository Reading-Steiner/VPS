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
        private static Dictionary<string, Bitmap> fontBitmaps = new Dictionary<string, Bitmap>();
        private static Font font = SystemFonts.DefaultFont;
        private static GMarkerGoogleType icon = GMarkerGoogleType.green;
        private static Color color = Color.Red;

        string no = "";
        SizeF txtsize = SizeF.Empty;

        public bool Selected = false;
        public string Command = "WAYPOINT";


        public GMapMarkerWP(VPS.Utilities.PointLatLngAlt p, string tag)
            : base(p, GMapMarkerStyle.ExistGMapMarkerStyle(p.Tag) ? GMapMarkerStyle.GetGMapMarkerStyle(p.Tag).Type : icon)
        {
            no = tag;

            Command = p.Tag;

            Font TipFont = font;
            TipFont = GMapMarkerStyle.ExistGMapMarkerStyle(Command) ? GMapMarkerStyle.GetGMapMarkerStyle(Command).TipFont : font;

            if (!fontBitmaps.ContainsKey(no))
            {
                Bitmap temp = new Bitmap(100,40, PixelFormat.Format32bppArgb);
                using (Graphics g = Graphics.FromImage(temp))
                {
                    txtsize = g.MeasureString(no, TipFont);

                    g.DrawString(no, SystemFonts.DefaultFont, Brushes.Black, new PointF(0, 0));
                }
                fontBitmaps[no] = temp;
            }

            ToolTipFont = TipFont;
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
                g.DrawImageUnscaled(fontBitmaps[no], midw, midh);
            }
        }
    }
}