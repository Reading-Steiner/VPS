using System.Windows.Forms;

namespace VPS
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();

            string strVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            TXT_version.Text = "Version: " + Application.ProductVersion; // +" Build " + strVersion;

            if (Program.Logo != null)
            {
                pictureBox1.BackgroundImage = VPS.Properties.Resources.bgdark;
                pictureBox1.Image = Program.Logo;
                pictureBox1.Visible = true;
            }
        }
    }
}