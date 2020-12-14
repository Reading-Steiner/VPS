using System;
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
    public partial class UserMessageBox : UserControl
    {
        public UserMessageBox()
        {
            InitializeComponent();
        }

        #region 文本
        private delegate void SetTextInThread(string text);
        private void SetMessageInfo(string text)
        {
            if (this.InvokeRequired)
            {
                SetTextInThread inThread = new SetTextInThread(SetMessageInfo);
                this.Invoke(inThread, new object[] { text });
            }
            else
            {
                this.Info.Text = text;
            }
        }
        #endregion

        #region 颜色
        private delegate void SetColorInThread(Color color);
        private void SetMessageColor(Color color)
        {
            if (this.InvokeRequired)
            {
                SetColorInThread inThread = new SetColorInThread(SetMessageColor);
                this.Invoke(inThread, new object[] { color });
            }
            else
            {
                if (defaultColor == Color.Transparent)
                    defaultColor = this.Info.ForeColor;
                this.Info.ForeColor = color;
            }
        }
        #endregion

        Color defaultColor = Color.Transparent;

        public void SetWarnMessage(string warn)
        {
            SetMessageInfo(warn);
            SetMessageColor(Color.Red);
        }

        public void SetInfoMessage(string info)
        {
            SetMessageInfo(info);
            if (defaultColor != Color.Transparent)
                this.Info.ForeColor = defaultColor;
        }
    }
}
