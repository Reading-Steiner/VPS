using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissionPlanner.GCSViews
{
    public partial class GobalWPConfig : Form
    {
        public GobalWPConfig()
        {
            InitializeComponent();
            List<string> Installation = new List<string>();
            Installation.Add("横放");
            Installation.Add("纵放");
            InstallationComboBox.DataSource = Installation;

        }
    }
}
