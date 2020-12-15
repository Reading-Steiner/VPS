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
using VPS.Utilities;

namespace VPS.Controls.CustomForms
{
    public partial class CustomMap : Office2007Form
    {
        List<List<PointLatLngAlt>> lists = new List<List<PointLatLngAlt>>();

        int currentIndex = -1;

        public CustomMap()
        {
            InitializeComponent();
        }
    }
}
