using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace VPS.Utilities
{
    public class Ui3dEffectForm
    {
        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        private static extern bool BitBlt(
            IntPtr hdcDest, // 目标 DC的句柄 
            int nXDest,
            int nYDest,
            int nWidth,
            int nHeight,
            IntPtr hdcSrc, // 源DC的句柄 
            int nXSrc,
            int nYSrc,
            System.Int32 dwRop // 光栅的处理数值 
        );

        private static Bitmap GetFormDC(Form form)
        {
            Graphics g1 = form.CreateGraphics();
            Bitmap MyImage = new Bitmap(form.Width, form.Height, g1);
            Graphics g2 = Graphics.FromImage(MyImage);
            //得到屏幕的DC
            IntPtr dc1 = g1.GetHdc();
            //得到Bitmap的DC
            IntPtr dc2 = g2.GetHdc();

            BitBlt(dc2, 0, 0, form.Width, form.Height, dc1, 0, 0, 13369376);

            //释放掉屏幕的DC 
            g1.ReleaseHdc(dc1);
            //释放掉Bitmap的DC 
            g2.ReleaseHdc(dc2);
            return MyImage;
        }

        [DllImport("winmm.dll", EntryPoint = "timeBeginPeriod")]
        public static extern uint _BeginPeriod(uint uMilliseconds);
        [DllImport("winmm.dll", EntryPoint = "timeEndPeriod")]
        public static extern uint _EndPeriod(uint uMilliseconds);

        public static void ConvertForm(Form hide, Form show)
        {
            Form form = new Form();
            form.Bounds = new Rectangle(hide.Left - 5, hide.Right - 5, hide.Width + 10, hide.Height + 10);
            Bitmap hideDC = GetFormDC(hide);
            Bitmap showDC = GetFormDC(show);
            Graphics g1 = form.CreateGraphics();
            form.Opacity = 0;
            hide.Opacity = 0;
            show.Opacity = 0;
            var outForm = new System.Threading.Thread(() => OverturnForm(g1, hideDC, showDC));
            outForm.Start();
        }

        private static void OverturnForm(Graphics g1, Bitmap hideDC, Bitmap showDC)
        {
            
            _BeginPeriod((uint)2);
            for (int i = 0; i < 90; i++)
            {
                Bitmap bitmap = KiRotate(hideDC, i, Color.Transparent);
                g1.DrawImage(bitmap, hideDC.Width - bitmap.Width, 0);
                Thread.Sleep(2);
            }

            for (int i = 90; i >= 0; i--)
            {
                g1.DrawImage(KiRotate(showDC, i, Color.Transparent), 0, 0);
                Thread.Sleep(2);
            }
            _EndPeriod((uint)2);
        }

        public static Bitmap KiRotate(Bitmap bmp, float angle, Color bkColor)
        {
            int w = bmp.Width + 2;
            int h = bmp.Height + 2;

            PixelFormat pf;

            if (bkColor == Color.Transparent)
            {
                pf = PixelFormat.Format32bppArgb;
            }
            else
            {
                pf = bmp.PixelFormat;
            }

            Bitmap tmp = new Bitmap(w, h, pf);
            Graphics g = Graphics.FromImage(tmp);
            g.Clear(bkColor);
            g.DrawImageUnscaled(bmp, 1, 1);
            g.Dispose();

            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddRectangle(new RectangleF(0f, 0f, w, h));
            var mtrx = new System.Drawing.Drawing2D.Matrix();
            mtrx.Rotate(angle);
            RectangleF rct = path.GetBounds(mtrx);

            Bitmap dst = new Bitmap((int)rct.Width, (int)rct.Height, pf);
            g = Graphics.FromImage(dst);
            g.Clear(bkColor);
            g.TranslateTransform(-rct.X, -rct.Y);
            g.RotateTransform(angle);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            g.DrawImageUnscaled(tmp, 0, 0);
            g.Dispose();

            tmp.Dispose();

            return dst;
        }
    }

}
