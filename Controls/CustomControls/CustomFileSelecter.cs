using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace VPS.Controls.CustomControls
{
    public partial class CustomFileSelecter : UserControl
    {
        public CustomFileSelecter()
        {
            InitializeComponent();
        }

        public string FileName
        {
            set
            {
                if (TXT_FileName.Text != value)
                {
                    TXT_FileName.Text = value;
                    if (File.Exists(value))
                    {
                        checkBoxX1.Enabled = true;
                        panelEx2.Visible = checkBoxX1.Enabled && checkBoxX1.Checked;
                    }
                    else
                    {
                        checkBoxX1.Enabled = false;
                        panelEx2.Visible = false;
                    }
                }
            }
            get
            {
                return TXT_FileName.Text;
            }
        }
        public string FileFilter = "所有文件|*.*";

        private void OpenFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fd = new OpenFileDialog())
            {
                fd.Filter = FileFilter;
                if (Directory.Exists(Utilities.Settings.Instance["WPFileDirectory"] ?? ""))
                    fd.InitialDirectory = Utilities.Settings.Instance["WPFileDirectory"];
                var result = fd.ShowDialog();
                if(result == DialogResult.OK)
                {
                    checkBoxX1.Enabled = true;
                    FileName = fd.FileName;
                }
            }
        }

        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {
            panelEx2.Visible = checkBoxX1.Enabled && checkBoxX1.Checked;
        }

        private void panelEx2_VisibleChanged(object sender, EventArgs e)
        {
            if (panelEx2.Visible && File.Exists(FileName))
            {
                FileInfo info = new FileInfo(FileName);
                string type = info.Extension;
                long size = info.Length;
                string sizeBig = ""; string sizeSmall = ""; string sizeTag = "";
                if (size / 1024 > 1)
                {
                    sizeBig = ((int)(size / 1024)).ToString();
                    sizeSmall = ((int)(size % 1024)).ToString();
                    sizeTag = "KB";
                    size = size / 1024;
                    if (size / 1024 > 1)
                    {
                        sizeBig = ((int)(size / 1024)).ToString();
                        sizeSmall = ((int)(size % 1024)).ToString();
                        sizeTag = "MB";
                        size = size / 1024;
                        if (size / 1024 > 1)
                        {
                            sizeBig = ((int)(size / 1024)).ToString();
                            sizeSmall = ((int)(size % 1024)).ToString();
                            sizeTag = "GB";
                        }
                    }
                }
                else
                {
                    sizeBig = ((int)(size / 1024)).ToString();
                    sizeSmall = ((int)(size % 1024)).ToString();
                    sizeTag = "Byte";
                }
                string modify = info.LastAccessTime.ToLongTimeString();
                string create = info.CreationTime.ToLongTimeString();
                
                labelX2.Text = string.Format(
                    "文件类型:%s" + System.Environment.NewLine +
                    "文件大小:%s" + System.Environment.NewLine +
                    "创建时间:%s" + System.Environment.NewLine +
                    "修改时间:%s",
                    type, sizeBig + "." + sizeSmall + sizeTag, create, modify
                    );
            }
        }
    }
}
