﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPS.Controls.TopMainInfoControls
{
    public partial class UserProgressBar : UserControl
    {
        public UserProgressBar()
        {
            InitializeComponent();
        }

        private delegate void SetDataInThread(double data);

        #region 修改颜色
        Color defaultProgressColor = Color.Transparent;

        #region 进度
        private delegate void SetColorInThread(Color color);
        private void SetProgressInfoColor(Color color)
        {
            if (this.InvokeRequired)
            {
                SetColorInThread inThread = new SetColorInThread(SetProgressInfoColor);
                this.Invoke(inThread, new object[] { color });
            }
            else
            {
                if (defaultProgressColor == Color.Transparent)
                    defaultProgressColor = this.Progress.ForeColor;
                this.Progress.ForeColor = color;
            }
        }
        #endregion

        Color defaultLabelColor = Color.Transparent;

        #region 提示
        private void SetProgressTextColor(Color color)
        {
            if (this.InvokeRequired)
            {
                SetColorInThread inThread = new SetColorInThread(SetProgressTextColor);
                this.Invoke(inThread, new object[] { color });
            }
            else
            {
                if (defaultLabelColor == Color.Transparent)
                    defaultLabelColor = this.Label.ForeColor;
                this.Label.ForeColor = color;
            }
        }
        #endregion

        #endregion

        #region 修改文本

        #region 进度
        private delegate void SetTextInThread(string text);
        private void SetProgressInfo(string text)
        {
            if (this.InvokeRequired)
            {
                SetTextInThread inThread = new SetTextInThread(SetProgressInfo);
                this.Invoke(inThread, new object[] { text });
            }
            else
            { 
                this.Progress.Text = text;
                if (defaultProgressColor != Color.Transparent)
                    this.Progress.ForeColor = defaultProgressColor;
            }
        }
        #endregion

        #region 提示
        public void SetProgressText(string text)
        {
            if (this.InvokeRequired)
            {
                SetTextInThread inThread = new SetTextInThread(SetProgressText);
                this.Invoke(inThread, new object[] { text });
            }
            else
            {
                this.Label.Text = text;
                if (defaultLabelColor != Color.Transparent)
                    this.Label.ForeColor = defaultLabelColor;
            }
        }
        #endregion

        #endregion

        #region 修改进度
        public void SetProgress(double progress)
        {
            SetProgressCurrentInfo(progress);
        }

        private void SetProgressCurrentInfo(double data)
        {
            if (this.InvokeRequired)
            {
                SetDataInThread inThread = new SetDataInThread(SetProgressCurrentInfo);
                this.Invoke(inThread, new object[] { data });
            }
            else
            {
                if (this.ProgressBox.Maximum != 10000)
                    this.ProgressBox.Maximum = 10000;
                this.ProgressBox.Value = (int)(data * 10000);
                SetProgressInfo(data.ToString("0.## %"));
            }
        }
        #endregion

        public void SetProgressFailure(string text)
        {
            
            this.SetProgressInfo(text);
            this.SetProgressInfoColor(Color.Red);
        }

        public void SetProgressSuccess(string text)
        {
            this.SetProgressCurrentInfo(1);
            this.SetProgressInfo(text);
            this.SetProgressInfoColor(Color.Green);
        }

        public void SetProgressStageInfo(string text, Color color, double progress = -1)
        {
            if (progress >= 0)
                this.SetProgress(progress);
            this.SetProgressInfo(text);
            this.SetProgressInfoColor(color);
        }
    }
}
