using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin;
using System.Drawing.Imaging;

namespace VPS.Controls
{
    public partial class ReturnButton : UserControl
    {
        public delegate void delegateHandler();
        public delegateHandler OnOK;
        public delegateHandler OnCancel;

        string _ok = "确定";
        [Category("设置"), Description("确定")]
        public string OKText
        {
            get
            {
                return _ok;
            }
            set
            {
                _ok = value;
                OK.Text = value;
                OK.Invalidate();
            }
        }

        string _cancle = "取消";
        [Category("设置"), Description("取消")]
        public string CancelText
        {
            get
            {
                return _cancle;
            }
            set
            {
                _cancle = value;
                Cancel.Text = value;
                Cancel.Invalidate();
            }
        }
        private Color _topRederBackColor;
        [Category("设置"), Description("顶部背景颜色")]
        public Color TopRederBackColor
        {
            get { return _topRederBackColor; }
            set
            {
                _topRederBackColor = value;
                DrawBackGround();
            }
        }

        private Color _bottomRederButtonColor;
        [Category("设置"), Description("底部背景颜色")]
        public Color BottomRederBackColor
        {
            get { return _bottomRederButtonColor; }
            set
            {
                _bottomRederButtonColor = value;
                DrawBackGround();
            }
        }

        private Color _rederButtonColor;
        [Category("设置"), Description("按钮颜色")]
        public Color RederButtonColor
        {
            get { return _rederButtonColor; }
            set
            {
                _rederButtonColor = value;
                this.OK.BaseColor = value;
                this.Cancel.BaseColor = value;
                DrawBackGround();
            }
        }

        [Category("设置"), Description("按钮悬停颜色")]
        public Color MouseButtonColor
        {
            get { return this.OK.MouseBaseColor; }
            set
            {
                this.OK.MouseBaseColor = value;
                this.Cancel.MouseBaseColor = value;
                Invalidate();
            }
        }

        [Category("设置"), Description("按钮按下颜色")]
        public Color DownButtonColor
        {
            get { return this.OK.DownBaseColor; }
            set
            {
                this.OK.DownBaseColor = value;
                this.Cancel.DownBaseColor = value;
                Invalidate();
            }
        }

        [Category("设置"), Description("按钮渐变颜色")]
        public Color GlowButtonColor
        {
            get { return this.OK.GlowColor; }
            set
            {
                this.OK.GlowColor = value;
                this.Cancel.GlowColor = value;
                Invalidate();
            }
        }

        private Bitmap _background;

        public ReturnButton()
        {
            InitializeComponent();
            OnSizeChanged(null);
            this.OK.Paint += OK_Paint;
            this.Cancel.Paint += Cancel_Paint;
            this.OK.Click += OK_Click;
            this.Cancel.Click += Cancel_Click;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            OnCancel?.Invoke();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            OnOK?.Invoke();
        }

        private void DrawBackGround()
        {
            Bitmap background = new Bitmap(this.Width, this.Height, PixelFormat.Format32bppRgb);
            var g = Graphics.FromImage(background);
            g.Clear(this.BackColor);
            Pen normalPen = new Pen(_rederButtonColor, 2);
            Brush whiteBrush = new SolidBrush(Color.White);

            for(int i =0;i < this.Height; i++)
            {
                Pen pen = new Pen(Color.FromArgb(
                    this.TopRederBackColor.A * (this.Height - i) / this.Height + this.BottomRederBackColor.A * i / this.Height,
                    this.TopRederBackColor.R * (this.Height - i) / this.Height + this.BottomRederBackColor.R * i / this.Height,
                    this.TopRederBackColor.G * (this.Height - i) / this.Height + this.BottomRederBackColor.G * i / this.Height,
                    this.TopRederBackColor.B * (this.Height - i) / this.Height + this.BottomRederBackColor.B * i / this.Height
                    ));
                g.DrawLine(pen, 0, i, this.Width, i);
            }

            g.FillRectangle(whiteBrush,
                    this.OK.Left - 1, this.OK.Top - 1,
                    this.OK.Width + 1, this.OK.Height + 1);
            g.DrawRectangle(normalPen,
                  this.OK.Left - 2, this.OK.Top - 2,
                  this.OK.Width + 4, this.OK.Height + 4);

            g.FillRectangle(whiteBrush,
                    this.Cancel.Left - 1, this.Cancel.Top - 1,
                    this.Cancel.Width + 1, this.Cancel.Height + 1);
            g.DrawRectangle(normalPen,
                this.Cancel.Left - 2, this.Cancel.Top - 2,
                this.Cancel.Width + 4, this.Cancel.Height + 4);
            _background = background;
            Invalidate();
        }

        private void Cancel_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            StringFormat SF = new StringFormat();
            SF.Alignment = StringAlignment.Center;
            SF.LineAlignment = StringAlignment.Center;
            SolidBrush brush = new SolidBrush(Color.Black);
            g.DrawString(CancelText, this.Font, brush, Cancel.DisplayRectangle, SF);
        }

        private void OK_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            StringFormat SF = new StringFormat();
            SF.Alignment = StringAlignment.Center;
            SF.LineAlignment = StringAlignment.Center;
            SolidBrush brush = new SolidBrush(Color.Black);
            g.DrawString(OKText, this.Font, brush, OK.DisplayRectangle, SF);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.DrawImage(_background, 0, 0);
            base.OnPaint(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (this.Width < this.Height * 7)
            {
                this.OK.Width = (int)(this.Width * 0.618f / 2);
                this.Cancel.Width = (int)(this.Width * 0.618f / 2);
            }
            else
            {
                this.OK.Width = (int)(this.Width * 0.382f / 2);
                this.Cancel.Width = (int)(this.Width * 0.382f / 2);
            }
            this.OK.Height = (int)(this.Height * 0.618);
            this.Cancel.Height = (int)(this.Height * 0.618);

            this.OK.Left = (this.Width - this.OK.Width - this.Cancel.Width) / 5 * 2;
            this.OK.Top = (this.Height - this.OK.Height) / 2;
            

            this.Cancel.Left = this.Width / 5 * 3 - this.Cancel.Width / 5 * 3 + this.OK.Width / 5 * 2;
            this.Cancel.Top = (this.Height - this.Cancel.Height) / 2;
            DrawBackGround();
            base.OnSizeChanged(e);
        }
    }
}
