namespace VPS
{
    partial class Splash
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
            this.TXT_version = new DevComponents.DotNetBar.LabelX();
            this.DisplayBoxLog = new DevComponents.DotNetBar.LabelX();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.SuspendLayout();
            // 
            // TXT_version
            // 
            this.TXT_version.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.TXT_version.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TXT_version.ForeColor = System.Drawing.Color.White;
            this.TXT_version.Location = new System.Drawing.Point(408, 187);
            this.TXT_version.Name = "TXT_version";
            this.TXT_version.Size = new System.Drawing.Size(155, 25);
            this.TXT_version.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.TXT_version.TabIndex = 1;
            // 
            // DisplayBoxLog
            // 
            this.DisplayBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DisplayBoxLog.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.DisplayBoxLog.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.DisplayBoxLog.Location = new System.Drawing.Point(0, 313);
            this.DisplayBoxLog.Name = "DisplayBoxLog";
            this.DisplayBoxLog.Size = new System.Drawing.Size(600, 26);
            this.DisplayBoxLog.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.DisplayBoxLog.TabIndex = 2;
            this.DisplayBoxLog.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(163)))), ((int)(((byte)(26))))));
            // 
            // Splash
            // 
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BottomLeftCornerSize = 14;
            this.ClientSize = new System.Drawing.Size(600, 340);
            this.ControlBox = false;
            this.Controls.Add(this.DisplayBoxLog);
            this.Controls.Add(this.TXT_version);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.FlattenMDIBorder = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 340);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 340);
            this.Name = "Splash";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VPS";
            this.TopLeftCornerSize = 60;
            this.TopMost = true;
            this.TopRightCornerSize = 60;
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.LabelX TXT_version;
        private DevComponents.DotNetBar.LabelX DisplayBoxLog;
        private DevComponents.DotNetBar.StyleManager styleManager1;
    }
}