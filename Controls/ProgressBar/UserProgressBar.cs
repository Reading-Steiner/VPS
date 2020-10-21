using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPS.Controls.ProgressBar
{
    public partial class UserProgressBar : UserControl
    {
        public UserProgressBar()
        {
            InitializeComponent();
        }

        private delegate void SetDataInThread(object data);
        private void SetProgressMaxInfo(object data)
        {
            if (this.InvokeRequired)
            {
                SetDataInThread inThread = new SetDataInThread(SetProgressMaxInfo);
                this.Invoke(inThread, new object[] { data });
            }
            else
            {
                this.ProgressBox.Maximum = (int)data;
            }
        }

        private void SetProgressInfo(object data)
        {
            if (this.InvokeRequired)
            {
                SetDataInThread inThread = new SetDataInThread(SetProgressInfo);
                this.Invoke(inThread, new object[] { data });
            }
            else
            {
                if ((int)data <= this.ProgressBox.Maximum && (int)data >= this.ProgressBox.Minimum)
                {
                    this.ProgressBox.Value = (int)data;
                    this.Progress.Text = (this.ProgressBox.Value / this.ProgressBox.Maximum).ToString("0.## %");
                }
            }
        }

        public void SetLabelInfo(object data)
        {
            if (this.InvokeRequired)
            {
                SetDataInThread inThread = new SetDataInThread(SetLabelInfo);
                this.Invoke(inThread, new object[] { data });
            }
            else
            {
                this.Label.Text = data.ToString();
            }
        }
        public void SetProgress(int progress, int total = -1)
        {
            if(total >= 0)
            {
                SetProgressMaxInfo(total);
            }
            SetProgressInfo(progress);
        }
    }
}
