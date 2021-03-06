﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;

namespace VPS.Controls
{
    public partial class BoardComboBox : UserControl
    {

        private bool isDroppable = false;
        //private int selectedIndex = -1;
        [Category("设置"), Description("选中项")]
        public string TextContent
        {
            get { return this.DisplayText.Text; }
            set
            {
                if (Regex.IsMatch(value, Pattern))
                {
                    this.DisplayText.Text = value;
                    this.dataSourceList.SelectedIndex = this.DataSource.IndexOf(TextContent);
                }
                SelectedChange?.Invoke();
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
        [Category("设置"), Description("数据源")]
        public List<string> DataSource
        {
            get { return dataSourceList.DataString; }
            set
            {
                dataSourceList.DataString = value;

                OnSizeChanged(null);
            }
        }

        [Category("设置"), Description("文本正则表达式")]
        public string Pattern { get; set; } = @"^\S*$";


        public bool Contains(string str)
        {
            return DataSource.Contains(str);
        }

        public void Add(string str)
        {
            if (Regex.IsMatch(str, Pattern))
            {
                this.dataSourceList.Add(str);

                OnSizeChanged(null);
            }
        }

        private Color _boardColor = Color.Orange;
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

        [Category("设置"), Description("文本锁定")]
        public bool AllowEdit { get; set; } = true;

        public delegate void delegateHandler();
        private delegateHandler EditOver;
        public delegateHandler SelectedChange;
        public delegateHandler ChangeSelected;

        Bitmap _background;
        public BoardComboBox()
        {
            this.dataSourceList = new ComboDataList();
            this.comboViewHost = new System.Windows.Forms.ToolStripControlHost(dataSourceList);
            this.dropDown = new System.Windows.Forms.ToolStripDropDown();
            InitializeComponent();
            this.dropDown.AutoSize = false;
            this.comboViewHost.AutoSize = false;
            dropDown.Items.Add(comboViewHost);

            if (this.Button.BackColor != Color.Transparent)
                this.Button.BackColor = Color.Transparent;
            if (this.DisplayText.BackColor != Color.Transparent)
                this.DisplayText.BackColor = Color.Transparent;
            OnSizeChanged(null);
            this.DisplayText.Click += DisplayText_Click;
            this.EditOver += CheckAndCloseEdit;
            this.EditBox.LostFocus += EditBox_LostFocus;
            this.EditBox.KeyDown += OnKeyDown;
            this.Button.Paint += Button_Paint;
            this.Button.MouseClick += Button_MouseClick;
            this.Button.MouseEnter += Button_MouseEnter;
            this.Button.MouseLeave += Button_MouseLeave;
            this.dataSourceList.SelectedChange += SelectedString;
            this.dataSourceList.ChangeSelected += StringSelected;
        }

        private void CheckAndCloseEdit()
        {
            if (this.EditBox.Visible == true)
            {
                this.EditBox.Text = this.DisplayText.Text;
                this.EditBox.Visible = false;
            }
        }

        private void EditBox_LostFocus(object sender, EventArgs e)
        {
            if (this.EditBox.Visible == true)
            {
                TextContent = this.EditBox.Text;
                this.EditBox.Visible = false;
                EditOver?.Invoke();
                ChangeSelected?.Invoke();
                return;
            }
        }

        private void DisplayText_Click(object sender, EventArgs e)
        {
            if (AllowEdit)
            {
                this.EditBox.Text = this.DisplayText.Text;
                this.EditBox.Left = this.DisplayText.Left;
                this.EditBox.Top = this.DisplayText.Top + (this.DisplayText.Height - this.EditBox.Height) / 2;
                this.EditBox.Width = this.Width - 2 * this.DisplayText.Left;
                this.EditBox.BackColor = this.BackColor;
                this.EditBox.Visible = true;
                this.EditBox.Focus();
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

        protected void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.EditBox.Visible == true)
                {
                    TextContent = this.EditBox.Text;
                    this.EditBox.Visible = false;
                    EditOver?.Invoke();
                    ChangeSelected?.Invoke();
                    return;
                }
            }

            base.OnKeyUp(e);
        }

        private void StringSelected()
        {
            ChangeSelected?.Invoke();
            dropDown.Close();
        }

        private void SelectedString()
        {
            if (this.dataSourceList.SelectedIndex >= 0 &&
                this.dataSourceList.SelectedIndex < this.dataSourceList.DataString.Count)
            {
                TextContent = this.DataSource[this.dataSourceList.SelectedIndex];
                Invalidate();
            }
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            isDroppable = false;
            Invalidate();
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            isDroppable = true;
            Invalidate();
        }

        protected void DrawBackground()
        {
            Bitmap background = new Bitmap(this.Width, this.Height, PixelFormat.Format32bppRgb);
            var g = Graphics.FromImage(background);
            g.Clear(this.BackColor);

            for (int i = 0; i < _rederWidth; i++)
            {
                var rect = this.DisplayRectangle;
                Pen pen = new Pen(Color.FromArgb(_boardColor.A / (i + 1), _boardColor));
                DrawRound(
                    new Rectangle(rect.X + i, rect.Y + i, rect.Width - i, rect.Height - i),
                    g, pen, Math.Min(rect.Width, rect.Height) / 3 * 2 - i);
            }

            _background = background;
            Invalidate();
        }

        #region 重绘
        protected override void OnPaint(PaintEventArgs e)
        {

            var g = e.Graphics;
            g.DrawImage(_background, 0, 0);
            base.OnPaint(e);
        }

        private void Button_MouseClick(object sender, MouseEventArgs e)
        {
            if (isDroppable)
            {
                this.dataSourceList.ForeColor = _boardColor;
                int index = this.dataSourceList.SelectedIndex;
                if (this.DataSource.Count * this.dataSourceList.ItemSize.Height > 250)
                {
                    index = -1;
                }
                dropDown.Show(
                    this,
                    this.DisplayText.Left,
                    this.DisplayText.Top - index * this.DisplayText.Height);
                DrawBackground();
            }
        }

        private void Button_Paint(object sender, PaintEventArgs e)
        {
            if (this.Button.BackColor != Color.Transparent)
                this.Button.BackColor = Color.Transparent;
            var g = e.Graphics;
            Brush brush;
            if (!isDroppable)
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
                        new Point(Button.Width / 2,Button.Height / 3),
                        new Point(Button.Width / 3 * 2,Button.Height / 3  *2),
                        new Point(Button.Width / 3,Button.Height / 3 * 2)});

        }
        #endregion

        protected override void OnSizeChanged(EventArgs e)
        {
            int Edge_W = Math.Min(this.Width / 10, 5);
            int Edge_H = Math.Min(this.Height / 10, 5);
            this.DisplayText.Left = Edge_W;
            this.DisplayText.Top = Edge_H;
            this.DisplayText.Width = (this.Width - 2 * Edge_W) - (this.Height - 2 * Edge_H);
            this.DisplayText.Height = (this.Height - 2 * Edge_H);
            this.Button.Left = (this.Width - Edge_W) - (this.Height - 2 * Edge_H);
            this.Button.Top = Edge_H;
            this.Button.Width = (this.Height - 2 * Edge_H);
            this.Button.Height = (this.Height - 2 * Edge_H);
            dataSourceList.ItemSize = DisplayText.Size;
            comboViewHost.Size = new Size(
                this.DisplayText.Height * DataSource.Count() > 250 ? this.DisplayText.Width + 20 : this.DisplayText.Width,
                Math.Min(this.DisplayText.Height * DataSource.Count(), 250));
            dropDown.Size = new Size(
                this.DisplayText.Height * DataSource.Count() > 250 ? this.DisplayText.Width + 22 : this.DisplayText.Width + 2,
                Math.Min(this.DisplayText.Height * DataSource.Count() + 5, 255));
            DrawBackground();
            base.OnSizeChanged(e);
        }

        #region 画圆角矩形
        private void DrawRound(Rectangle rectangle, Graphics g, Pen pen, int _radius)
        {
            g.DrawPath(pen, DrawRoundRect(rectangle.X,
                rectangle.Y, rectangle.Width - 2,
                rectangle.Height - 1, _radius));
        }
        private void FillRound(Rectangle rectangle, Graphics g, Brush br, int _radius)
        {
            g.FillPath(br, DrawRoundRect(rectangle.X,
                rectangle.Y, rectangle.Width - 2,
                rectangle.Height - 1, _radius));
        }
        /// <summary>
        /// 生成圆角矩形路径
        /// </summary>
        public static GraphicsPath DrawRoundRect(int x, int y, int width, int height, int radius)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddArc(x, y, radius, radius, 180, 90);
            gp.AddArc(width - radius, y, radius, radius, 270, 90);
            gp.AddArc(width - radius, height - radius, radius, radius, 0, 90);
            gp.AddArc(x, height - radius, radius, radius, 90, 90);
            gp.CloseAllFigures();
            return gp;
        }
        #endregion
    }
}
