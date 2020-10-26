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

        private delegate void SetDataInThread(int data);
        private void SetProgressMaxInfo(int data)
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

        private void SetProgressCurrentInfo(int data)
        {
            if (this.InvokeRequired)
            {
                SetDataInThread inThread = new SetDataInThread(SetProgressCurrentInfo);
                this.Invoke(inThread, new object[] { data });
            }
            else
            {
                if ((int)data <= this.ProgressBox.Maximum && (int)data >= this.ProgressBox.Minimum)
                {
                    this.ProgressBox.Value = (int)data;
                    this.Progress.Text = ((float)this.ProgressBox.Value / (float)this.ProgressBox.Maximum).ToString("0.## %");
                }
                else
                {
                    if((int)data > this.ProgressBox.Maximum)
                        this.ProgressBox.Value = (int)this.ProgressBox.Maximum;
                }
            }
        }

        private delegate void SetColorInThread(Color color);
        private void SetProgressColor(Color color)
        {
            if (this.InvokeRequired)
            {
                SetColorInThread inThread = new SetColorInThread(SetProgressColor);
                this.Invoke(inThread, new object[] { color });
            }
            else
            {
                this.Progress.ForeColor = color;
            }
        }

        private delegate void SetTextInThread(string text);
        public void SetProgressInfo(string text)
        {
            if (this.InvokeRequired)
            {
                SetTextInThread inThread = new SetTextInThread(SetProgressInfo);
                this.Invoke(inThread, new object[] { text });
            }
            else
            { 
                this.Progress.Text = text;
            }
        }

        public void SetLabelInfo(string text)
        {
            if (this.InvokeRequired)
            {
                SetTextInThread inThread = new SetTextInThread(SetLabelInfo);
                this.Invoke(inThread, new object[] { text });
            }
            else
            {
                this.Label.Text = text;
            }
        }
        public void SetProgress(int progress, int total = -1)
        {
            if(total >= 0)
            {
                SetProgressMaxInfo(total);
            }
            SetProgressCurrentInfo(progress);
        }

        public void SetProgressFailure(string text)
        {
            
            this.SetProgressInfo(text);
            this.SetProgressColor(Color.Red);
        }

        public void SetProgressSuccessful(string text)
        {
            this.SetProgressCurrentInfo(int.MaxValue);
            this.SetProgressInfo(text);
            this.SetProgressColor(Color.Green);
        }
    }
}
