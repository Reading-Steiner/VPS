using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;

namespace VPS.Controls
{
    public partial class BoardLabel : UserControl
    {
        Bitmap _background;
        public BoardLabel()
        {
            InitializeComponent();
            DrawBackground();
        }

        private void DisplayText_MouseEnter(object sender, EventArgs e)
        {
            this.Capture = true;
        }


        private void DrawBackground()
        {
            Bitmap background = new Bitmap(this.Width, this.Height, PixelFormat.Format32bppRgb);
            var g = Graphics.FromImage(background);
            g.Clear(this.BackColor);
            {
                StringFormat SF = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                Brush brush = new SolidBrush(this.ForeColor);
                g.DrawString(TextContent, this.Font, brush,
                    new RectangleF(_rederWidth, _rederWidth, this.Width - 2 * _rederWidth, this.Height - 2 * _rederWidth),
                    SF);
            }
            for (int i = 0; i < _rederWidth; i++)
            {
                switch (_rederStyle)
                {
                    case Style.Inner:
                        {
                            Pen pen = new Pen(Color.FromArgb(_boardColor.A / (i + 1), _boardColor));
                            g.DrawRectangle(pen, i, i, this.Width - 1 - 2 * i, this.Height - 1 - 2 * i);
                        }
                        break;
                    case Style.Outside:
                        {
                            Pen pen = new Pen(Color.FromArgb(_boardColor.A / (_rederWidth - i), _boardColor));
                            g.DrawRectangle(pen, i, i, this.Width - 1 - 2 * i, this.Height - 1 - 2 * i);
                        }
                        break;
                    default:
                        {
                            Pen pen = new Pen(_boardColor);
                            g.DrawRectangle(pen, i, i, this.Width - 1 - 2 * i, this.Height - 1 - 2 * i);
                        }
                        break;
                }
            }
            _background = background;
            Invalidate();
        }

        public enum Style
        {
            Inner,
            Outside,
            None
        }

        private Color _boardColor = Color.Orange;
        private Style _rederStyle = Style.Inner;
        private int _rederWidth = 2;
        [Category("设置"),Description("渲染颜色")]
        public Color BoardColor
        {
            get { return _boardColor; }
            set
            {
                _boardColor = value;
                DrawBackground();

            }
        }

        [Category("设置"), Description("渲染风格")]
        public Style RederStyle
        {
            get { return _rederStyle; }
            set
            {
                _rederStyle = value;
                DrawBackground();
            }
        }

        [Category("设置"), Description("渲染深度")]
        public int RederWidth
        {
            get { return _rederWidth; }
            set
            {
                _rederWidth = value;
                DrawBackground();
            }
        }


        [Category("设置"), Description("文本内容")]
        public string TextContent
        {
            get { return this.Text; }
            set
            {
                if (Regex.IsMatch(value, Pattern))
                {
                    this.Text = value;
                    DrawBackground();
                }
            }
        }

        private delegate void SetTextContentCallback(string text);
        public void SetTextContent(string value)
        {
            if (this.InvokeRequired)
            {
                SetTextContentCallback setText = new SetTextContentCallback(SetTextContent);
                this.Invoke(setText, new object[] { value });
            }
            else
            {
                this.TextContent = value;
            }
        }

        private delegate string GetTextContentCallback();
        public string GetTextContent()
        {
            if (this.InvokeRequired)
            {
                GetTextContentCallback getText = new GetTextContentCallback(GetTextContent);
                IAsyncResult iar = this.BeginInvoke(getText);
                return (string)this.EndInvoke(iar);
            }
            else
            {
                return this.TextContent;
            }
        }

        [Category("设置"), Description("文本正则表达式")]
        public string Pattern { get; set; } = @"^\S*$";

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.DrawImage(_background, 0, 0);
            base.OnPaint(e);
            
            
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            DrawBackground();
            base.OnSizeChanged(e);
        }

    }
}
