using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPS.Controls.LoadAndSave
{
    public partial class LoadTiff : Office2007Form
    {
        public LoadTiff()
        {
            InitializeComponent();
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            if (IsLocalFile.Checked)
            {
                using (OpenFileDialog fd = new OpenFileDialog())
                {
                    fd.Filter = "Google Earth KML(*kml;*.kmz) |*.kml;*.kmz|ShapeFile(*.shp)|*.shp";
                    if (Directory.Exists(Utilities.Settings.Instance["WPFileDirectory"] ?? ""))
                        fd.InitialDirectory = Utilities.Settings.Instance["WPFileDirectory"];
                    var result = fd.ShowDialog();

                    string file = fd.FileName;
                    if (result == DialogResult.OK && File.Exists(file))
                    {
                        Utilities.Settings.Instance["WPFileDirectory"] = Path.GetDirectoryName(file);
                        switch (fd.FilterIndex)
                        {
                            case 1:
                                {
                                }
                                break;
                            case 2:
                                {
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
    }
}
