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

        public void SetBitMap(Bitmap bitmap, Color transparent)
        {
            bitmap.MakeTransparent(transparent);
            Image img = Image.FromHbitmap(bitmap.GetHbitmap());
            DisplayImage.BackgroundImage = img;
        }
    }
}
