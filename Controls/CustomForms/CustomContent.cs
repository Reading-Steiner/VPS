using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace VPS.Controls.CustomForms
{
    public partial class CustomContent : Office2007Form
    {
        public CustomContent()
        {
            InitializeComponent();
        }

        public CustomContent(string content) : this()
        {
            Content = content;
        }

        public string Content { set; get; }

        private void FormAddress_Load(object sender, EventArgs e)
        {
            richTextBoxEx1.Text = Content;
        }

        private void RichTextBoxEx1_TextChanged(object sender, EventArgs e)
        {
            Content = richTextBoxEx1.Text;
        }
    }
}
