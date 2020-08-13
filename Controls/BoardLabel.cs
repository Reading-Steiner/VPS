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

namespace MissionPlanner.Controls
{
    public partial class BoardLabel : UserControl
    {
        public BoardLabel()
        {
            InitializeComponent();
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
                    Invalidate();
                }
            }
        }

        [Category("设置"), Description("文本正则表达式")]
        public string Pattern { get; set; } = @"^\S*$";

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

    }
}
