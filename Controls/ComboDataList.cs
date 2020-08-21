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
                if (ItemSize.Height * DataString.Count > 250)
                {
                    this.Width = ItemSize.Width + 20;
                    this.Height = 250;
                }
                else
                {
                    this.Width = ItemSize.Width;
                    this.Height = ItemSize.Height * DataString.Count;
                }
                OnSizeChanged(null);
            }
        }

        public void Add(string value)
        {
            _list.Add(value);
            if (ItemSize.Height * DataString.Count > 250)
            {
                this.Width = ItemSize.Width + 20;
                this.Height = 250;
            }
            else
            {
                this.Width = ItemSize.Width;
                this.Height = ItemSize.Height * DataString.Count;
            }
            OnSizeChanged(null);
        }

        Size _itemSize;
        [Category("设置"), Description("数据项")]
        public Size ItemSize
        {
            get { return _itemSize; }
            set
            {
                _itemSize = value;
                if (ItemSize.Height * DataString.Count > 250)
                {
                    this.Width = ItemSize.Width + 20;
                    this.Height = 250;
                }
                else
                {
                    this.Width = ItemSize.Width;
                    this.Height = ItemSize.Height * DataString.Count;
                }
                OnSizeChanged(null);

            }
        }

        public ComboDataList()
        {
            InitializeComponent();

            DisplayLabel.Paint += ShowLabel_Paint;
            DisplayLabel.MouseDown += ShowLabel_MouseDown;
            DisplayLabel.MouseMove += ShowLabel_MouseMove;
            DisplayLabel.MouseUp += ShowLabel_MouseUp;
        }

        private bool InBounds(Point location)
        {
            if(this.DisplayLabel.Height - this.ShowLabel.Height > 0)
            {
                int Y = location.Y + this.DisplayLabel.Top;
                int X = location.X;
                if (Y < this.ShowLabel.Height && Y > 0 && 
                    X < this.DisplayLabel.Width && X > 0)
                {
                    return true;
                }
                return false;
            }
            else
            {
                if (this.ShowLabel.DisplayRectangle.Contains(location))
                {
                    return true;
                }
                return false;
            }
        }

        private void ShowLabel_MouseUp(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {

                if (!InBounds(e.Location))
                {
                    mouseDown = false;
                    if (temporary != -1)
                    {
                        if (sender is Control)
                            ((Control)sender).Invalidate(rect(temporary));
                        temporary = -1;
                    }
                    return;
                }
                int index = e.Y / this.ItemSize.Height;
                if (index >= 0 && index < DataString.Count())
                {
                    if (SelectedIndex != index)
                    {
                        int oldIndex = SelectedIndex;
                        int newIndex = index;

                        SelectedIndex = index;
                        if (sender is Control)
                        {
                            if (oldIndex != -1)
                                ((Control)sender).Invalidate(rect(oldIndex));
                            ((Control)sender).Invalidate(rect(newIndex));
                        }
                        ChangeSelected?.Invoke();
                    }
                }
                else
                {
                    if (temporary != -1)
                    {
                        if (sender is Control)
                            ((Control)sender).Invalidate(rect(temporary));
                        temporary = -1;
                    }
                }
            }
            else
            {
                if (temporary != -1)
                {
                    if (sender is Control)
                        ((Control)sender).Invalidate(rect(temporary));
                    temporary = -1;
                }
            }
            mouseDown = false;
        }

        private void ShowLabel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                if (sender is Control)
                    if (!InBounds(e.Location))
                        return;
                int index = e.Y / this.ItemSize.Height;
                if (index >= 0 && index < DataString.Count)
                {
                    if (temporary != index)
                    {
                        int oldIndex = temporary;
                        int newIndex = index;
                        temporary = index;
                        if (sender is Control)
                        {
                            if (oldIndex != -1)
                                ((Control)sender).Invalidate(rect(oldIndex));
                            ((Control)sender).Invalidate(rect(newIndex));
                        }
                    }
                }
                else
                {
                    if (temporary != -1)
                    {
                        if (sender is Control)
                            ((Control)sender).Invalidate(rect(temporary));
                        temporary = -1;
                    }
                }
            }
            else
            {
                if (temporary != -1)
                {
                    if (sender is Control)
                        ((Control)sender).Invalidate(rect(temporary));
                    temporary = -1;
                }
            }
        }

        private void ShowLabel_MouseDown(object sender, MouseEventArgs e)
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
                        if (sender is Control)
                        {
                            if (oldIndex != -1)
                                ((Control)sender).Invalidate(rect(oldIndex));
                            ((Control)sender).Invalidate(rect(newIndex));
                        }
                        
                    }
                }
                else
                {
                    if (temporary != -1)
                    {
                        if (sender is Control)
                            ((Control)sender).Invalidate(rect(temporary));
                        temporary = -1;
                    }
                }
            }
            else
            {
                if (temporary != -1)
                {
                    if (sender is Control)
                        ((Control)sender).Invalidate(rect(temporary));
                    temporary = -1;
                }
            }
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
                g.DrawLine(pen, _itemSize.Width / 7, (i + 1) * _itemSize.Height, _itemSize.Width / 7 * 6 + 2, (i + 1) * _itemSize.Height);
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            this.ShowLabel.Left = 0;
            this.ShowLabel.Top = 0;
            this.ShowLabel.Width = this.Width;
            this.ShowLabel.Height = this.Height;
            this.DisplayLabel.Left = 0;
            this.DisplayLabel.Top = 0;
            this.DisplayLabel.Width = this.ItemSize.Width;
            this.DisplayLabel.Height = this.ItemSize.Height * this.DataString.Count;
            //this.DisplayLabel
            base.OnSizeChanged(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.ShowLabel.Left = 0;
            this.ShowLabel.Top = 0;
            base.OnPaint(e);
        }

        protected Rectangle rect(int index)
        {
            if (index >= 0 && index < DataString.Count())
                return new Rectangle(
                    0, index * ItemSize.Height + 1,
                    ItemSize.Width, ItemSize.Height - 2);
            else
                return new Rectangle();
        }

    }
}
