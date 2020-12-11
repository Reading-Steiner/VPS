using System.Windows.Forms;

namespace VPS
{
    public partial class Splash : DevComponents.DotNetBar.Office2007Form
    {
        public Splash()
        {
            InitializeComponent();
        }


        const int WS_EX_NOACTIVATE = 0x08000000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;

                cp.ExStyle |= WS_EX_NOACTIVATE;

                return cp;
            }
        }


        private delegate void SetTextInThreadHander(string text);
        public void SetDisplayInfo(string text)
        {
            if (this.InvokeRequired)
            {
                SetTextInThreadHander hander = new SetTextInThreadHander(SetDisplayInfo);
                this.Invoke(hander, new object[] { text });
            }
            else
                this.DisplayBoxLog.Text = text;
        }

    }
}