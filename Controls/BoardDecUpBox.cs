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

namespace VPS.Controls
{
    public partial class BoardDecUpBox : UserControl
    {
        bool isUpClickable = false;
        bool isDownClickable = false;
        public BoardDecUpBox()
        { 
            InitializeComponent();
            Up.Paint += Up_Paint;
            Up.MouseEnter += Up_MouseEnter;
            Up.MouseLeave += Up_MouseLeave;

            Down.Paint += Down_Paint;
            Down.MouseEnter += Down_MouseEnter;
            Down.MouseLeave += Down_MouseLeave;
        }

        private void Down_MouseLeave(object sender, EventArgs e)
        {
            isDownClickable = false;
        }

        private void Down_MouseEnter(object sender, EventArgs e)
        {
            isDownClickable = true;
        }

        private void Down_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            Brush brush;
            if (!isUpClickable)
            {
                brush = new SolidBrush(this._boardColor);
            }
            else
            {
                brush = new SolidBrush(Color.FromArgb(
                    this._boardColor.A,
                    255 - this._boardColor.R / 15,
                    this._boardColor.G / 5,
                    this._boardColor.B / 5));
            }
            g.FillPolygon(brush, new Point[] {
                        new Point(Down.Width / 2, Down.Height / 3  *2),
                        new Point(Down.Width / 3 * 2, Down.Height / 3),
                        new Point(Down.Width / 3, Down.Height / 3)});
        }

        private void Up_MouseLeave(object sender, EventArgs e)
        {
            isUpClickable = false;
        }

        private void Up_MouseEnter(object sender, EventArgs e)
        {
            isUpClickable = true;
        }

        private void Up_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            Brush brush;
            if (!isDownClickable)
            {
                brush = new SolidBrush(this._boardColor);
            }
            else
            {
                brush = new SolidBrush(Color.FromArgb(
                    this._boardColor.A,
                    255 - this._boardColor.R / 15,
                    this._boardColor.G / 5,
                    this._boardColor.B / 5));
            }
            g.FillPolygon(brush, new Point[] {
                        new Point(Up.Width / 2,Up.Height / 3),
                        new Point(Up.Width / 3 * 2,Up.Height / 3  *2),
                        new Point(Up.Width / 3,Up.Height / 3 * 2)});
        }

        public enum Style
        {
            Inner,
            Outside,
            None
        }

        public delegate void delegateHandler();
        public delegateHandler TextChange;
        public delegateHandler ChangeText;

        private Color _boardColor = Color.Orange;
        private Style _rederStyle = Style.Inner;
        private int _rederWidth = 2;
        [Category("设置"), Description("渲染颜色")]
        public Color BoardColor
        {
            get { return _boardColor; }
            set
            {
                _boardColor = value;
                Invalidate();
            }
        }

        [Category("设置"), Description("渲染风格")]
        public Style RederStyle
        {
            get { return _rederStyle; }
            set
            {
                _rederStyle = value;
                Invalidate();
            }
        }

        [Category("设置"), Description("渲染深度")]
        public int RederWidth
        {
            get { return _rederWidth; }
            set
            {
                _rederWidth = value;
                Invalidate();
            }
        }

        [Category("设置"), Description("文本位置")]
        public Point TextPosition
        {
            get { return DisplayText.Location; }
            set
            {
                DisplayText.Location = value;
                Invalidate();
            }
        }

        [Category("设置"), Description("文本内容")]
        public string TextString
        {
            get { return DisplayText.Text; }
            set
            {
                if (Regex.IsMatch(value, Pattern))
                {
                    DisplayText.Text = value;
                    TextChange?.Invoke();
                    Invalidate();
                }
            }
        }

        [Category("设置"), Description("文本正则表达式")]
        public string Pattern { get; set; } = @"^\S*$";

        [Category("设置"), Description("文本布局")]
        public ContentAlignment TextAlignment
        {
            get { return this.DisplayText.TextAlign; }
            set { this.DisplayText.TextAlign = value; }

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.DisplayText.BackColor != Color.Transparent)
                this.DisplayText.BackColor = Color.Transparent;
            base.OnPaint(e);
            var g = e.Graphics;
            //g.Clear(Color.White);
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

        }

        protected override void OnSizeChanged(EventArgs e)
        {

            base.OnSizeChanged(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            this.EditBox.Text = this.DisplayText.Text;
            this.EditBox.Left = this.DisplayText.Left;
            this.EditBox.Top = this.DisplayText.Left;
            this.EditBox.Width = this.Width - 2 * this.DisplayText.Left;
            this.EditBox.BackColor = this.BackColor;
            this.EditBox.Visible = true;
            base.OnMouseClick(e);
        }

        protected override void OnClientSizeChanged(EventArgs e)
        {
            this.Up.Left = this.Width / 10 * 7;
            this.Up.Top = this.Height / 5;
            this.Up.Width = this.Width / 5;
            this.Up.Height = this.Height / 5;

            this.Down.Left = this.Width / 10 * 9;
            this.Down.Top = this.Height / 5 * 3;
            this.Down.Width = this.Width / 5;
            this.Down.Height = this.Height / 5;
        }

        private void EditBox_LostFocus(object sender, EventArgs e)
        {
            if (this.EditBox.Visible == true)
            {
                TextString = this.EditBox.Text;
                this.EditBox.Visible = false;
                ChangeText?.Invoke();
                return;
            }
        }

        protected void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.EditBox.Visible == true)
                {
                    TextString = this.EditBox.Text;
                    this.EditBox.Visible = false;
                    ChangeText?.Invoke();
                    return;
                }
            }

            base.OnKeyUp(e);
        }

        private void CheckAndCloseEdit()
        {
            if (this.EditBox.Visible == true)
            {
                this.EditBox.Text = this.DisplayText.Text;
                this.EditBox.Visible = false;
            }
        }
    }
}
