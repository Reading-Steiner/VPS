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
    public partial class ComboDataList : UserControl
    {
        private int temporary = -1;
        public delegate void delegateHandler();
        public delegateHandler SelectedChange;
        public delegateHandler ChangeSelected;
        private int selected = -1;
        private bool mouseDown = false; 
        public int SelectedIndex
        {
            get{return selected;}
            set
            {
                if (value >= 0 && value < DataString.Count)
                {
                    if (value != selected)
                    {
                        selected = value;
                        SelectedChange?.Invoke();
                    }
                }
                else
                {
                    selected = -1;
                }
            }
        }

        List<string> _list = new List<string>();
        [Category("设置"), Description("数据")]
        public List<string> DataString
        {
            get { return _list; }
            set
            {
                _list = value;
                this.Width = ItemSize.Width;
                this.Height = ItemSize.Height * DataString.Count;
                //Invalidate();
            }
        }

        Size _itemSize;
        [Category("设置"), Description("数据项")]
        public Size ItemSize
        {
            get { return _itemSize; }
            set
            {
                _itemSize = value;
                this.Width = value.Width;
                this.Height = value.Height * DataString.Count;
                Invalidate();
            }
        }
        public ComboDataList()
        {
            InitializeComponent();

            //DoubleBuffered = true;
            ShowLabel.Paint += ShowLabel_Paint;
            ShowLabel.MouseDown += ShowLabel_MouseDown;
            ShowLabel.MouseMove += ShowLabel_MouseMove;
            ShowLabel.MouseUp += ShowLabel_MouseUp;
        }

        private void ShowLabel_MouseUp(object sender, MouseEventArgs e)
        {
            OnMouseUp(e);
        }

        private void ShowLabel_MouseMove(object sender, MouseEventArgs e)
        {
            OnMouseMove(e);
        }

        private void ShowLabel_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
        }

        private void ShowLabel_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            for (int i = 0; i < _list.Count(); i++)
            {
                Color fore;
                if (i == selected)
                    fore = Color.FromArgb(
                        this.ForeColor.A,
                        255 - this.ForeColor.R / 15,
                        this.ForeColor.G / 5,
                        this.ForeColor.B / 5);
                else if (i == temporary)
                    fore = Color.FromArgb(
                       this.ForeColor.A,
                       255 - this.ForeColor.R / 15,
                       this.ForeColor.G / 5,
                       255 - this.ForeColor.B / 15);
                else
                    fore = ForeColor;
                SolidBrush brush = new SolidBrush(fore);
                StringFormat SF = new StringFormat();
                SF.Alignment = StringAlignment.Center;
                SF.LineAlignment = StringAlignment.Center;
                g.DrawString(
                    _list[i], this.Font, brush,
                    new Rectangle(0, i * _itemSize.Height, _itemSize.Width, _itemSize.Height),
                    SF);
                Pen pen = new Pen(this.ForeColor);
                g.DrawLine(pen, 0, (i + 1) * _itemSize.Height, _itemSize.Width, (i + 1) * _itemSize.Height);
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            this.ShowLabel.Left = 0;
            this.ShowLabel.Top = 0;
            this.ShowLabel.Width = this.Width;
            this.ShowLabel.Height = this.Height;
            base.OnSizeChanged(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDown = true;
                int index = e.Y / this.ItemSize.Height;
                if (index >= 0 && index < DataString.Count)
                {
                    if (temporary != index)
                    {
                        int oldIndex = temporary;
                        int newIndex = index;
                        temporary = index;
                        if (oldIndex != -1)
                            ShowLabel.Invalidate(rect(oldIndex));
                        ShowLabel.Invalidate(rect(newIndex));
                    }
                }
                else
                {
                    if (temporary != -1)
                    {
                        ShowLabel.Invalidate(rect(temporary));
                        temporary = -1;
                    }
                }
            }
            else
            {
                if (temporary != -1)
                {
                    ShowLabel.Invalidate(rect(temporary));
                    temporary = -1;
                }
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (mouseDown)
            {
                int index = e.Y / this.ItemSize.Height;
                if (index >= 0 && index < DataString.Count)
                {
                    if (temporary != index)
                    {
                        int oldIndex = temporary;
                        int newIndex = index;
                        temporary = index;
                        if (oldIndex != -1)
                            ShowLabel.Invalidate(rect(oldIndex));
                        ShowLabel.Invalidate(rect(newIndex));
                    }
                }
                else
                {
                    if (temporary != -1)
                    {
                        ShowLabel.Invalidate(rect(temporary));
                        temporary = -1;
                    }
                }
            }
            else
            {
                if (temporary != -1)
                {
                    ShowLabel.Invalidate(rect(temporary));
                    temporary = -1;
                }
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (mouseDown)
            {
                
                int index = e.Y / this.ItemSize.Height;
                if (index >= 0 && index < DataString.Count())
                {
                    if (SelectedIndex != index)
                    {
                        int oldIndex = SelectedIndex;
                        int newIndex = index;

                        SelectedIndex = index;
                        if (oldIndex != -1)
                            ShowLabel.Invalidate(rect(oldIndex));
                        ShowLabel.Invalidate(rect(newIndex));
                        ChangeSelected?.Invoke();
                    }
                }
                else
                {
                    if (temporary != -1)
                    {
                        ShowLabel.Invalidate(rect(temporary));
                        temporary = -1;
                    }
                }
            }
            else
            {
                if (temporary != -1)
                {
                    ShowLabel.Invalidate(rect(temporary));
                    temporary = -1;
                }
            }
            mouseDown = false;
            base.OnMouseDown(e);
        }

        protected Rectangle rect(int index)
        {
            if (index >= 0 && index < DataString.Count())
                return new Rectangle(
                    0, index * ItemSize.Height,
                    ItemSize.Width, ItemSize.Height);
            else
                return new Rectangle();
        }

    }
}
