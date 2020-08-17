using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPS.Controls
{
    public partial class GradualButton : Button
    {

        #region Data
        public enum DrawStyle
        {
            Horizontal,
            Vertical,
            Rectangle,
            Ellipse,
        }

        public enum GradualStyle
        {
            Linear,
            Square,
        }

        private DrawStyle _drawStyles;
        private GradualStyle _gradualStyles;
        
        private Color _normalTopColor = Color.LightGreen;
        private Color _normalBottomColor = Color.LightGreen;
        private Color _downTopColor = Color.OrangeRed;
        private Color _downBottomColor = Color.OrangeRed;
        private Color _stayTopColor = Color.Orange;
        private Color _stayBottomColor = Color.Orange;

        [Category("设置"), Description("渐变色变化状态")]
        [DefaultValue(DrawStyle.Horizontal)]
        public DrawStyle ColorDrawStyle
        {
            get { return _drawStyles; }
            set
            {
                _drawStyles = value;
                Invalidate();
            }
        }

        [Category("设置"), Description("渐变色变化程度")]
        [DefaultValue(GradualStyle.Linear)]
        public GradualStyle ColorGradualStyle
        {
            get { return _gradualStyles; }
            set
            {
                _gradualStyles = value;
                switch (_gradualStyles)
                {
                    case GradualStyle.Linear:
                        MAXCOLOR = 255; MINCOLOR = 0;
                        break;
                    case GradualStyle.Square:
                        MAXCOLOR = 15; MINCOLOR = 0;
                        break;
                    default:
                        break;
                }
                //ColorChangeHandler();
                lock (sign)
                {
                    colorTransparentList.Clear();
                    normalColorTransparentList.Clear();
                    normalColorTransparentList = null;
                    downColorTransparentList.Clear();
                    downColorTransparentList = null;
                    stayColorTransparentList.Clear();
                    stayColorTransparentList = null;
                }
                Invalidate();
            }
        }

        [Category("设置"), Description("正常颜色上边界")]
        [DefaultValue(typeof(Color), "#FF90EE90")]
        public Color NormalTopColor
        {
            get { return _normalTopColor; }
            set
            {
                _normalTopColor = value;
                normalColorTransparentList = null;
            }
        }

        [Category("设置"), Description("正常颜色下边界")]
        [DefaultValue(typeof(Color), "#FF90EE90")]
        public Color NormalBottomColor
        {
            get { return _normalBottomColor; }
            set
            {
                _normalBottomColor = value;
                normalColorTransparentList = null;
            }
        }


        [Category("设置"), Description("按下颜色上边界")]
        [DefaultValue(typeof(Color), "#FFFF4500")]
        public Color DownTopColor
        {
            get { return _downTopColor; }
            set
            {
                _downTopColor = value;
                downColorTransparentList = null;
            }
        }

        [Category("设置"), Description("按下颜色下边界")]
        [DefaultValue(typeof(Color), "#FFFF4500")]
        public Color DownBottomColor
        {
            get { return _downBottomColor; }
            set
            {
                _downBottomColor = value;
                downColorTransparentList = null;
            }
        }

        [Category("设置"), Description("停留颜色上边界")]
        [DefaultValue(typeof(Color), "#FFFFA500")]
        public Color StayTopColor
        {
            get { return _stayTopColor; }
            set
            {
                _stayTopColor = value;
                stayColorTransparentList = null;
            }
        }


        [Category("设置"), Description("停留颜色下边界")]
        [DefaultValue(typeof(Color), "#FFFFA500")]
        public Color StayBottomColor
        {
            get { return _stayBottomColor; }
            set
            {
                _stayBottomColor = value;
                stayColorTransparentList = null;
            }
        }

        #endregion
        public GradualButton()
        {
            normalColorTransparentList = GenerateColor(NormalTopColor, NormalBottomColor);
            downColorTransparentList = GenerateColor(DownTopColor, DownBottomColor);
            stayColorTransparentList = GenerateColor(StayTopColor, StayBottomColor);
            InitializeComponent();
        }


        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            state = 1;
            base.OnMouseDown(mevent);
        }


        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            if (this.DisplayRectangle.Contains(mevent.Location))
                state = 2;
            else
                state = 0;
            base.OnMouseUp(mevent);
        }


        protected override void OnMouseEnter(EventArgs e)
        {

            state = 2;
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            state = 0;
            base.OnMouseLeave(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.Visible)
            {
                base.OnPaint(e);

                if (normalColorTransparentList == null)
                    normalColorTransparentList = GenerateColor(NormalTopColor, NormalBottomColor);
                if (downColorTransparentList == null)
                    downColorTransparentList = GenerateColor(DownTopColor, DownBottomColor);
                if (stayColorTransparentList == null)
                    stayColorTransparentList = GenerateColor(StayTopColor, StayBottomColor);
                if (state == 0)
                {
                    colorTransparentList = normalColorTransparentList;
                }
                else if(state == 1)
                {
                    colorTransparentList = downColorTransparentList;
                }
                else if(state == 2)
                {
                    colorTransparentList = stayColorTransparentList;
                }
                else
                {
                    colorTransparentList = normalColorTransparentList;
                }

                Graphics g = e.Graphics;
                g.Clear(this.BackColor);
                int left = this.ClientRectangle.Left;
                int top = this.ClientRectangle.Top;
                int width = this.ClientRectangle.Width;
                int height = this.ClientRectangle.Height;
                int delta = 1;
                //g.Clear(Color.FromArgb(0, 255, 255, 255));

                switch (_drawStyles)
                {
                    case DrawStyle.Horizontal:
                        {
                            int maxCount = height;
                            for (int i = 0; i <= maxCount; i++)
                            {
                                Color brushColor = colorTransparentList[(int)(((double)colorTransparentList.Count - 1) * i / maxCount)];
                                SolidBrush opcBrush = new SolidBrush(brushColor);
                                g.FillRectangle(opcBrush, left, top + i * delta, width, 1);
                            }
                        }
                        break;
                    case DrawStyle.Vertical:
                        {
                            int maxCount = width;
                            for (int i = 0; i <= maxCount; i++)
                            {
                                Color brushColor = colorTransparentList[(int)(((double)colorTransparentList.Count - 1) * i / maxCount)];
                                SolidBrush opcBrush = new SolidBrush(brushColor);
                                g.FillRectangle(opcBrush, left + i * delta, top, 1, height);
                            }
                        }
                        break;
                    case DrawStyle.Rectangle:
                        {
                            int maxCount = (int)(Math.Min(width / 2, height / 2) + 0.5);
                            for (int i = 0; i <= maxCount; i++)
                            {
                                Color brushColor = colorTransparentList[(int)(((double)colorTransparentList.Count - 1) * i / maxCount)];
                                Pen opcPen = new Pen(brushColor, 1);
                                g.DrawRectangle(
                                    opcPen,
                                    left + i * delta,
                                    top + i * delta,
                                    Math.Max(width - 2 * (left + i * delta), 1),
                                    Math.Max(height - 2 * (top + i * delta), 1));
                            }
                        }
                        break;
                    case DrawStyle.Ellipse:
                        {
                            int maxCount = (int)(Math.Min(width / 2, height / 2) + 0.5);
                            for (int i = 0; i <= maxCount; i++)
                            {
                                Color brushColor = colorTransparentList[(int)(((double)colorTransparentList.Count - 1) * i / maxCount)];
                                Pen opcPen = new Pen(brushColor, 1);
                                g.DrawEllipse(
                                    opcPen,
                                    left + i * delta,
                                    top + i * delta,
                                    Math.Max(width - 2 * (left + i * delta), 1),
                                    Math.Max(height - 2 * (top + i * delta), 1));
                            }
                        }
                        break;
                    default:
                        {
                            int maxCount = height;
                            for (int i = 0; i <= maxCount; i++)
                            {
                                Color brushColor = colorTransparentList[(int)(((double)colorTransparentList.Count - 1) * i / maxCount)];
                                SolidBrush opcBrush = new SolidBrush(brushColor);
                                g.FillRectangle(opcBrush, left, top + i * delta, width, 1);
                            }
                        }
                        break;
                }

                SolidBrush brush = new SolidBrush(this.ForeColor);
                string text = this.Text;
                var size = g.MeasureString(text, this.Font);
                for (int i = 1; i <= text.Length; i++)
                {
                    if (size.Width / i < this.Width)
                    {
                        if (text.Length % i == 0)
                        {
                            for (int j = 0; j < i; j++)
                            {
                                string str = text.Substring(j * text.Length / i, text.Length / i);
                                var subSize = g.MeasureString(str, this.Font);

                                g.DrawString(str, this.Font, brush, (int)((this.Width - subSize.ToPointF().X) / 2), (int)((this.Height - i * subSize.ToPointF().Y) / 2 + j * subSize.ToPointF().Y));
                            }
                            break;
                        }
                    }

                }
                //StringFormat SF = new StringFormat();
                //SF.LineAlignment = StringAlignment.Center;                                        //设置属性为水平居中
                //SF.Alignment = StringAlignment.Center;                                            //设置属性为垂直居中
                //e.Graphics.DrawString(this.Text, this.Font, Brushes.Black, this.DisplayRectangle, SF);
            }
        }

        private static object sign = new object();

        private int MAXCOLOR = 15;
        private int MINCOLOR = 0;

        int state = 0;

        private List<Color> colorTransparentList = new List<Color>();
        private List<Color> normalColorTransparentList = new List<Color>();
        private List<Color> downColorTransparentList = new List<Color>();
        private List<Color> stayColorTransparentList = new List<Color>();
        //private delegate void delegateHandler();
        //private delegateHandler ColorChangeHandler;

        List<Color> GenerateColor(Color top, Color bottom)
        {
            lock (sign)
            {
                var colorList = new List<Color>();


                switch (_gradualStyles)
                {
                    case GradualStyle.Linear:
                        {
                            double da = (double)(top.A - bottom.A) / 1000;
                            double dr = (double)(top.R - bottom.R) / 1000;
                            double dg = (double)(top.G - bottom.G) / 1000;
                            double db = (double)(top.B - bottom.B) / 1000;
                            for (int i = 0; i < 1000; i++)
                            {
                                colorList.Add(Color.FromArgb(
                                    (int)(i * da) + bottom.A,
                                    (int)(i * dr) + bottom.R,
                                    (int)(i * dg) + bottom.G,
                                    (int)(i * db) + bottom.B));
                            }
                        }
                        break;
                    case GradualStyle.Square:
                        {
                            double da = (top.A - bottom.A);
                            double dr = (top.R - bottom.R);
                            double dg = (top.G - bottom.G);
                            double db = (top.B - bottom.B);
                            for (int i = 0; i < 1000; i++)
                                colorList.Add(Color.FromArgb(
                                    (int)(da * Math.Pow(i - 500, 2) / 250000) + bottom.A,
                                    (int)(dr * Math.Pow(i - 500, 2) / 250000) + bottom.R,
                                    (int)(dg * Math.Pow(i - 500, 2) / 250000) + bottom.G,
                                    (int)(db * Math.Pow(i - 500, 2) / 250000) + bottom.B));
                        }
                        break;
                }
                return colorList;
            }
        }
    }
}
