using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace VPS.Controls.MainInfo
{
    class WaitTime
    {
        public string key;
        public int time;
        public WaitTime(string _key, int _time = 0)
        {
            key = _key; time = _time;
        }
    }

    public partial class TopMainInfo : UserControl
    {
        public TopMainInfo()
        {
            InitializeComponent();

            instance = this;
        }

        static public TopMainInfo instance = null; 

        Dictionary<string, Control> messageBarList = new Dictionary<string, Control>();
        private int count =0;
        int Count
        {
            set {
                count = value;
                if (count <= 0)
                    this.Visible = false;
                else
                    this.Visible = true;
            }
            get { return count; }
        }

        private Control CreateControl(string type)
        {
            switch (type)
            {
                case "ProgressBar.UserProgressBar":
                    var bar = new ProgressBar.UserProgressBar();
                    bar.Dock = DockStyle.Left;
                    this.Controls.Add(bar);
                    Count++;
                    return bar;
            }
            return null;
        }

        private delegate bool DisposeControlInThread(string key);

        #region DisposeControl
        private bool DisposeControl(string key)
        {
            if (this.InvokeRequired)
            {
                DisposeControlInThread inThread = new DisposeControlInThread(DisposeControl);
                IAsyncResult iar = this.BeginInvoke(inThread, new object[] { key });
                return (bool)this.EndInvoke(iar);
            }
            else
            {
                if (messageBarList.ContainsKey(key))
                {
                    Control control = messageBarList[key];
                    messageBarList.Remove(key);
                    if (control != null)
                    {
                        this.Controls.Remove(control);
                        control.Visible = false;
                        Count--;
                        control.Dispose();
                    }
                    else
                        return false;
                    return true;
                }
                else
                    return false;
            }
        }

        static private void DisposeControlWait(object key)
        {
            var data = key as WaitTime;
            var start = Convert.ToInt64((DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalMilliseconds);
            while (true)
            {
                if (Convert.ToInt64((DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalMilliseconds) - start > data.time)
                {
                    TopMainInfo.instance.DisposeControl(data.key);
                }
                else
                {
                    System.Threading.Thread.SpinWait(100);
                }
            }
        }



        public void DisposeControlEnter(string key, int time = 0)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(DisposeControlWait), new WaitTime(key, time));
        }
        #endregion

        private delegate void SetVisibleInThread(string key, bool visable);
        public void SetVisible(string key, bool visable)
        {
            if (this.InvokeRequired)
            {
                SetVisibleInThread inThread = new SetVisibleInThread(SetVisible);
                this.Invoke(inThread, new object[] { key, visable });
            }
            else
            {
                if (messageBarList.ContainsKey(key))
                {
                    Control control = messageBarList[key];
                    if (control != null && control.Visible != visable)
                    {
                        control.Visible = visable;
                        if (visable)
                            Count++;
                        else
                            Count--;
                    }
                }
            }
        }

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
            ProgressBar.UserProgressBar bar = CreateControl("ProgressBar.UserProgressBar") as ProgressBar.UserProgressBar;
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
