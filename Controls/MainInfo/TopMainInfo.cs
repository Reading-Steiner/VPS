using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPS.Controls.MainInfo
{
    public partial class TopMainInfo : UserControl
    {
        public TopMainInfo()
        {
            InitializeComponent();

            instance = this;
        }

        static public TopMainInfo instance = null; 

        Dictionary<string, Control> messageBarList = new Dictionary<string, Control>();

        #region ProgressBar
        private delegate string CreateProgressInThread(string info, int maxData);
        public string CreateProgress(string info, int maxData)
        {
            if (this.InvokeRequired)
            {
                CreateProgressInThread inThread = new CreateProgressInThread(CreateProgress);
                IAsyncResult iar = this.BeginInvoke(inThread, new object[] { info, maxData });
                return (string)this.EndInvoke(iar);
            }
            else
            {
                var bar = CreateProgressBar();
                bar.SetLabelInfo(info);
                bar.SetProgress(0, maxData);
                string key = bar.GetHashCode().ToString();
                messageBarList.Add(key, bar);

                return key;
            }
        }

        public ProgressBar.UserProgressBar CreateProgressBar()
        {
            this.SuspendLayout();
            ProgressBar.UserProgressBar bar = new ProgressBar.UserProgressBar();
            bar.Dock = DockStyle.Left;
            this.Controls.Add(bar);
            this.ResumeLayout(false);
            return bar;
        }

        public ProgressBar.UserProgressBar GetProgress(string key)
        {
            if (messageBarList[key] is ProgressBar.UserProgressBar)
                return messageBarList[key] as ProgressBar.UserProgressBar;
            else
                return null;
        }

        #endregion
    }
}
