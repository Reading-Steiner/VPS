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

        public void DisposeControlEnter(string key, int time = 0)
        {
            if (time <= 0)
            {
                DisposeControl(key);
                return;
            }
            ThreadPool.QueueUserWorkItem(new WaitCallback(DisposeControlWait), new WaitTime(key, time));
        }

        #region 立即销毁
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
        #endregion

        #region 延时销毁
        static private void DisposeControlWait(object key)
        {
            var data = key as WaitTime;
            var start = Convert.ToInt64((DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalMilliseconds);
            while (true)
            {
                if (Convert.ToInt64((DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalMilliseconds) - start > data.time)
                {
                    TopMainInfo.instance.DisposeControl(data.key);
                    return;
                }
                else
                {
                    System.Threading.Thread.SpinWait(100);
                }
            }
        }
        #endregion

        #endregion

        #region 设置可见性
        private delegate void SetVisibleInThread(string key, bool visible);
        public void SetVisible(string key, bool visible)
        {
            if (this.InvokeRequired)
            {
                SetVisibleInThread inThread = new SetVisibleInThread(SetVisible);
                this.Invoke(inThread, new object[] { key, visible });
            }
            else
            {
                if (messageBarList.ContainsKey(key))
                {
                    Control control = messageBarList[key];
                    if (control != null && control.Visible != visible)
                    {
                        control.Visible = visible;
                        if (visible)
                            Count++;
                        else
                            Count--;
                    }
                }
            }
        }
        #endregion

        #region 创建进度条控件 ProgressBar
        private delegate string CreateProgressInThread(string info);
        public string CreateProgress(string info)
        {
            if (this.InvokeRequired)
            {
                CreateProgressInThread inThread = new CreateProgressInThread(CreateProgress);
                IAsyncResult iar = this.BeginInvoke(inThread, new object[] { info });
                return (string)this.EndInvoke(iar);
            }
            else
            {
                var bar = CreateProgressBar();
                bar.SetProgressText(info);
                bar.SetProgress(0);
                string key = bar.GetHashCode().ToString();
                messageBarList.Add(key, bar);

                return key;
            }
        }

        private ProgressBar.UserProgressBar CreateProgressBar()
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
