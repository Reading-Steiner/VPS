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
    public partial class ProgressBarMainInfo : UserControl
    {
        public ProgressBarMainInfo()
        {
            InitializeComponent();
        }

        Dictionary<string, ProgressBar.UserProgressBar> progressBarList = new Dictionary<string, ProgressBar.UserProgressBar>();


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
                progressBarList.Add(key, bar);

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

        public void SetProgress(string key, int progress)
        {
            if (progressBarList.ContainsKey(key))
            {
                progressBarList[key].SetProgress(progress);
            }
            else
                return;
        }
    }
}
