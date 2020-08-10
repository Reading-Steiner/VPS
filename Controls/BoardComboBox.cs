using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace MissionPlanner.Controls
{
    public partial class BoardComboBox : UserControl
    {
        private bool isDroppable = false;
        //private int selectedIndex = -1;
        [Category("设置"), Description("数据源")]
        public List<string> DataSource
        {
            get { return dataSourceList.DataString; }
            set
            {
                dataSourceList.DataString = value;
                dataSourceList.ItemSize = DisplayText.Size;
                comboViewHost.Size = new Size(
                this.DisplayText.Width + 5,
                this.DisplayText.Height * DataSource.Count() + 10);
                dropDown.Size = new Size(
                    this.DisplayText.Width + 5,
                    this.DisplayText.Height * DataSource.Count() + 10);
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

        public BoardComboBox()
        {
            this.dataSourceList = new ComboDataList();
            this.comboViewHost = new System.Windows.Forms.ToolStripControlHost(dataSourceList);
            this.dropDown = new System.Windows.Forms.ToolStripDropDown();
            InitializeComponent();
            this.dropDown.AutoSize = false;
            dropDown.Items.Add(comboViewHost);

            if (this.Button.BackColor != Color.Transparent)
                this.Button.BackColor = Color.Transparent;
            if (this.DisplayText.BackColor != Color.Transparent)
                this.DisplayText.BackColor = Color.Transparent;
            if (this.Board.BackColor != Color.Transparent)
                this.Board.BackColor = Color.Transparent;
            OnSizeChanged(null);
            this.Board.Paint += Board_Paint;
            this.Button.Paint += Button_Paint;
            //this.TextList.Paint += TextList_Paint;
            this.Button.MouseClick += Button_MouseClick;
            this.Button.MouseEnter += Button_MouseEnter;
            this.Button.MouseLeave += Button_MouseLeave;
            this.dataSourceList.SelectedChange += SelectedString;
        }

        private void SelectedString()
        {
            if (this.dataSourceList.SelectedIndex >= 0 &&
                this.dataSourceList.SelectedIndex < this.dataSourceList.DataString.Count)
            {
                this.DisplayText.Text = this.dataSourceList.DataString[this.dataSourceList.SelectedIndex];
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

        private void Button_MouseClick(object sender, MouseEventArgs e)
        {
            if (isDroppable)
            {
                this.dataSourceList.ForeColor = _boardColor;
                dropDown.Show(
                    this,
                    this.DisplayText.Left,
                    this.DisplayText.Top - this.dataSourceList.SelectedIndex * this.DisplayText.Height);
                Invalidate();
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

        private void Board_Paint(object sender, PaintEventArgs e)
        {
            if (this.Board.BackColor != Color.Transparent)
                this.Board.BackColor = Color.Transparent;
            var g = e.Graphics;
            for (int i = 0; i < _rederWidth; i++)
            {
                var rect = this.DisplayRectangle;
                Pen pen = new Pen(Color.FromArgb(_boardColor.A / (i + 1), _boardColor));
                DrawRound(
                    new Rectangle(rect.X + i, rect.Y + i, rect.Width - i, rect.Height - i),
                    g, pen, Math.Min(rect.Width, rect.Height) / 3);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            int Edge_W = Math.Min(this.Width / 10, 5);
            int Edge_H = Math.Min(this.Height / 10, 5);
            this.Board.Left = 0;
            this.Board.Top = 0;
            this.Board.Width = this.Width;
            this.Board.Height = this.Height;
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
                this.DisplayText.Width,
                this.DisplayText.Height * DataSource.Count());
            dropDown.Size = new Size(
                this.DisplayText.Width + 5,
                this.DisplayText.Height * DataSource.Count() + 10);
            base.OnSizeChanged(e);
        }

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
    }
}
