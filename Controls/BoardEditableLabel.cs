﻿using System;
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
    public partial class BoardEditableLabel : UserControl
    {
        private Bitmap _background;
        public BoardEditableLabel()
        {
            InitializeComponent();
            SetForeColor();
            DrawBackground();
            this.ForeColorChanged += OnForeColorChanged;
            this.EditBox.KeyDown += OnKeyDown;
            this.EditBox.LostFocus += EditBox_LostFocus;
            EditOver += CheckAndCloseEdit;
        }

        private void DrawBackground()
        {
            Bitmap background = new Bitmap(this.Width, this.Height, PixelFormat.Format32bppRgb);
            var g = Graphics.FromImage(background);
            g.Clear(this.BackColor);
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

        private void OnForeColorChanged(object sender, EventArgs e)
        {
            SetForeColor();
        }

        private void SetForeColor()
        {
            this.EditBox.ForeColor = Color.FromArgb(
                this.ForeColor.A,
                255 - this.ForeColor.R / 15,
                this.ForeColor.G / 5,
                this.ForeColor.B / 5);
            this.DisplayText.ForeColor = this.ForeColor;
        }

        public enum Style
        {
            Inner,
            Outside,
            None
        }

        public delegate void delegateHandler();
        private delegateHandler EditOver;
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

        [Category("设置"), Description("文本位置")]
        public Point TextPosition
        {
            get { return DisplayText.Location; }
            set
            {
                DisplayText.Location = value;
                DisplayText.Invalidate();
            }
        }

        [Category("设置"), Description("文本内容")]
        public string TextContent
        {
            get { return DisplayText.Text; }
            set
            {
                if (Regex.IsMatch(value, Pattern))
                {
                    DisplayText.Text = value;
                    TextChange?.Invoke();
                    DisplayText.Invalidate();
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

        [Category("设置"), Description("文本锁定")]
        public bool AllowEdit { get; set; } = true;

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.DisplayText.BackColor != Color.Transparent)
                this.DisplayText.BackColor = Color.Transparent;
            //var bufferGraphic = new BufferedGraphicsContext().Allocate(CreateGraphics(), DisplayRectangle);
            //var g = bufferGraphic.Graphics;
            var g = e.Graphics;
            g.DrawImage(_background, 0, 0);

            //bufferGraphic.Render();
            base.OnPaint(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            DrawBackground();
            base.OnSizeChanged(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (AllowEdit)
            {
                this.EditBox.Text = this.DisplayText.Text;
                this.EditBox.Left = this.DisplayText.Left;
                this.EditBox.Top = this.DisplayText.Top;
                this.EditBox.Width = this.Width - 2 * this.DisplayText.Left;
                this.EditBox.BackColor = this.BackColor;
                this.EditBox.Visible = true;
                this.EditBox.Focus();
                base.OnMouseClick(e);
            }
        }

        protected override void OnGotFocus(EventArgs e)
        {
            if (AllowEdit)
            {
                this.EditBox.Text = this.DisplayText.Text;
                this.EditBox.Left = this.DisplayText.Left;
                this.EditBox.Top = this.DisplayText.Top;
                this.EditBox.Width = this.Width - 2 * this.DisplayText.Left;
                this.EditBox.BackColor = this.BackColor;
                this.EditBox.Visible = true;
                this.EditBox.Focus();
                base.OnGotFocus(e);
            }
        }

        private void EditBox_LostFocus(object sender, EventArgs e)
        {
            if (this.EditBox.Visible == true)
            {
                TextContent = this.EditBox.Text;
                this.EditBox.Visible = false;
                EditOver?.Invoke();
                ChangeText?.Invoke();
                return;
            }
        }

        protected void OnKeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (this.EditBox.Visible == true)
                {
                    TextContent = this.EditBox.Text;
                    this.EditBox.Visible = false;
                    EditOver?.Invoke();
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
