namespace VPS.Controls.CustomForms
{
    partial class CustomContent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBoxEx1 = new DevComponents.DotNetBar.Controls.RichTextBoxEx();
            this.SuspendLayout();
            // 
            // richTextBoxEx1
            // 
            // 
            // 
            // 
            this.richTextBoxEx1.BackgroundStyle.Class = "RichTextBoxBorder";
            this.richTextBoxEx1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.richTextBoxEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxEx1.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxEx1.Name = "richTextBoxEx1";
            this.richTextBoxEx1.Size = new System.Drawing.Size(332, 216);
            this.richTextBoxEx1.TabIndex = 0;
            this.richTextBoxEx1.TextChanged += new System.EventHandler(this.RichTextBoxEx1_TextChanged);
            // 
            // CustomContent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 216);
            this.Controls.Add(this.richTextBoxEx1);
            this.DoubleBuffered = true;
            this.Name = "CustomContent";
            this.Text = "CustomContent";
            this.Load += new System.EventHandler(this.FormAddress_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.RichTextBoxEx richTextBoxEx1;
    }
}