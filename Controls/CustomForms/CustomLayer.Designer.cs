namespace VPS.Controls.CustomForms
{
    partial class CustomLayer
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
            this.DisplayImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayImage)).BeginInit();
            this.SuspendLayout();
            // 
            // DisplayImage
            // 
            this.DisplayImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DisplayImage.Location = new System.Drawing.Point(2, 1);
            this.DisplayImage.Name = "DisplayImage";
            this.DisplayImage.Size = new System.Drawing.Size(300, 300);
            this.DisplayImage.TabIndex = 3;
            this.DisplayImage.TabStop = false;
            // 
            // CustomLayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 301);
            this.Controls.Add(this.DisplayImage);
            this.Name = "CustomLayer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "图层";
            ((System.ComponentModel.ISupportInitialize)(this.DisplayImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox DisplayImage;
    }
}