using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissionPlanner.Controls
{
    public partial class ReturnButton : UserControl
    {
        public int state = 0;
        public delegate void delegateHandler();
        public delegateHandler OnOK;
        public delegateHandler OnCancel;

        [Category("设置"), Description("确定")]
        public string OKText { get; set; } = "确定";
        [Category("设置"), Description("取消")]
        public string CancelText { get; set; } = "取消";

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
            state = 2;
            OnCancel?.Invoke();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            state = 1;
            OnOK?.Invoke();
        }

        private void Cancel_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(_rederButtonColor);
            StringFormat SF = new StringFormat();
            SF.Alignment = StringAlignment.Center;
            SF.LineAlignment = StringAlignment.Center;
            SolidBrush brush = new SolidBrush(Color.Black);
            g.DrawString(CancelText, this.Font, brush, Cancel.DisplayRectangle, SF);
        }

        private void OK_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(_rederButtonColor);
            StringFormat SF = new StringFormat();
            SF.Alignment = StringAlignment.Center;
            SF.LineAlignment = StringAlignment.Center;
            SolidBrush brush = new SolidBrush(Color.Black);
            g.DrawString(OKText, this.Font, brush, OK.DisplayRectangle, SF);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(_rederBackColor);

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
            base.OnSizeChanged(e);
        }

        private Color _rederBackColor;
        [Category("设置"), Description("背景颜色")]
        public Color RederBackColor
        {
            get { return _rederBackColor; }
            set
            {
                _rederBackColor = value;
                Invalidate();
            }
        }

        private Color _rederButtonColor;
        [Category("设置"), Description("按钮颜色")]
        public Color RederWidth
        {
            get { return _rederButtonColor; }
            set
            {
                _rederButtonColor = value;
                Invalidate();
            }
        }

    }
}
