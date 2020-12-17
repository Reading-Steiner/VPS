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
        }
        Bitmap _bitmap = null;
        Color _color = Color.Transparent;

        public void SetBitMap(Bitmap bitmap, Color transparent)
        {
            _color = transparent;
            _bitmap = new Bitmap(bitmap);

            colorPickerButton.SelectedColor = _color;
            if (_color != Color.Transparent)
            {
                colorCombControl.BackColor = _color;
            }

            ShowGeoBitmap();
        }

        public void SetTransparent(Color transparent)
        {
            if (_color == transparent)
                return;
            _color = transparent;

            colorPickerButton.SelectedColor = _color;
            if (_color != Color.Transparent)
            {
                colorCombControl.BackColor = _color;
            }

            ShowGeoBitmap();
        }

        private void ShowGeoBitmap()
        {
            if (_bitmap == null)
            {
                return;
            }
            var bitmap = new Bitmap(_bitmap);
            if (_color != Color.Transparent)
            {
                bitmap.MakeTransparent(_color);
            }
            Image img = Image.FromHbitmap(bitmap.GetHbitmap());
            DisplayImage.BackgroundImage = img;

        }

        private void colorPickerButton_SelectedColorChanged(object sender, EventArgs e)
        {
            if (_color == colorPickerButton.SelectedColor)
                return;
            SetTransparent(colorPickerButton.SelectedColor);
        }
    }
}
