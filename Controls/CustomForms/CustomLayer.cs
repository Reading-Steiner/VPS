using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPS.Controls.CustomForms
{
    public partial class CustomLayer : Office2007Form
    {
        public CustomLayer()
        {
            InitializeComponent();
            DisplayImage.MouseMove += DisplayImage_MouseMove;
            DisplayImage.MouseDoubleClick += DisplayImage_MouseDoubleClick;
            DisplayImage.SizeChanged += DisplayImage_SizeChanged;
        }

        private Color displayColor
        {
            set
            {
                colorDisplay.BackColor = value;
                colorInfoDisplay.Text =
                    string.Format("[{0},{1},{2}]", value.R, value.G, value.B);
            }
            get
            {
                return colorDisplay.BackColor;
            }
        }

        private void DisplayImage_SizeChanged(object sender, EventArgs e)
        {
            ShowGeoBitmap();
        }

        private void DisplayImage_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SetTransparent(displayColor);
        }

        private void DisplayImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (_bitmap != null)
            {
                displayColor = _bitmap.GetPixel(
                    _bitmap.Width * e.Location.X / DisplayImage.Width,
                    _bitmap.Height * e.Location.Y / DisplayImage.Height);
            }
        }

        private void ShowGeoBitmap()
        {
            if (_bitmap == null)
            {
                return;
            }
            var bitmap = new Bitmap(_bitmap, DisplayImage.Width, DisplayImage.Height);
            if (_color != Color.Transparent)
            {
                bitmap.MakeTransparent(_color);
            }
            //Image img = Image.FromHbitmap(bitmap.GetHbitmap());
            DisplayImage.Image = bitmap;

        }

        private void colorPickerButton_SelectedColorChanged(object sender, EventArgs e)
        {
            if (_color == colorPickerButton.SelectedColor)
                return;
            SetTransparent(colorPickerButton.SelectedColor);
        }

        private void withTransparent_CheckedChanged(object sender, EventArgs e)
        {
            panelEx2.Visible = checkBoxX1.Checked;
            panelEx3.Visible = !checkBoxX1.Checked;
        }

        private void DefaultButton_Click(object sender, EventArgs e)
        {
            SetTransparent(_defaultColor);
        }


        Bitmap _bitmap = null;
        Color _color = Color.Transparent;
        Color _defaultColor = Color.Transparent;

        public void SetBitMap(Bitmap bitmap, Color transparent)
        {
            _color = transparent;
            _defaultColor = transparent;
            _bitmap = new Bitmap(bitmap);

            colorPickerButton.SelectedColor = _color;
            displayColor = _color;

            checkBoxX1.Checked = ((_color == Color.Transparent) || (_color.A == 0));
            checkBoxX1.Checked = !((_color == Color.Transparent) || (_color.A == 0));

            ShowGeoBitmap();
        }

        public void SetTransparent(Color transparent)
        {
            if (_color == transparent)
                return;
            _color = transparent;

            colorPickerButton.SelectedColor = _color;

            checkBoxX1.Checked = !((_color == Color.Transparent) || (_color.A == 0));

            ShowGeoBitmap();
        }

        public Color GetTransparent()
        {
            return _color;
        }

        public Bitmap GetBitmap()
        {
            var bitmap = new Bitmap(_bitmap, _bitmap.Width, _bitmap.Height);
            if (_color != Color.Transparent)
            {
                bitmap.MakeTransparent(_color);
            }
            return bitmap;
        }
    }
}
