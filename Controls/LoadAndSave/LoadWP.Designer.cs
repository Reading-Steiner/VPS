namespace VPS.Controls.LoadAndSave
{
    partial class LoadWP
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
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.TXT_FileType = new DevComponents.DotNetBar.LabelX();
            this.OpenFile = new DevComponents.DotNetBar.ButtonX();
            this.TXT_FileName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.advPropertyGrid1 = new DevComponents.DotNetBar.AdvPropertyGrid();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advPropertyGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.advPropertyGrid1);
            this.panelEx1.Controls.Add(this.TXT_FileType);
            this.panelEx1.Controls.Add(this.OpenFile);
            this.panelEx1.Controls.Add(this.TXT_FileName);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(284, 494);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // TXT_FileType
            // 
            // 
            // 
            // 
            this.TXT_FileType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TXT_FileType.Location = new System.Drawing.Point(12, 39);
            this.TXT_FileType.Name = "TXT_FileType";
            this.TXT_FileType.Size = new System.Drawing.Size(164, 23);
            this.TXT_FileType.TabIndex = 4;
            this.TXT_FileType.Text = "文件类型：";
            // 
            // OpenFile
            // 
            this.OpenFile.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.OpenFile.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.OpenFile.Location = new System.Drawing.Point(197, 39);
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.Size = new System.Drawing.Size(75, 23);
            this.OpenFile.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.OpenFile.TabIndex = 3;
            this.OpenFile.Text = "打开文件";
            this.OpenFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // TXT_FileName
            // 
            // 
            // 
            // 
            this.TXT_FileName.Border.Class = "TextBoxBorder";
            this.TXT_FileName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TXT_FileName.Location = new System.Drawing.Point(12, 12);
            this.TXT_FileName.Name = "TXT_FileName";
            this.TXT_FileName.Size = new System.Drawing.Size(260, 21);
            this.TXT_FileName.TabIndex = 1;
            // 
            // advPropertyGrid1
            // 
            this.advPropertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.advPropertyGrid1.GridLinesColor = System.Drawing.Color.WhiteSmoke;
            this.advPropertyGrid1.Location = new System.Drawing.Point(3, 68);
            this.advPropertyGrid1.Name = "advPropertyGrid1";
            this.advPropertyGrid1.SearchBoxVisible = false;
            this.advPropertyGrid1.Size = new System.Drawing.Size(278, 426);
            this.advPropertyGrid1.TabIndex = 5;
            this.advPropertyGrid1.Text = "advPropertyGrid1";
            this.advPropertyGrid1.ToolbarVisible = false;
            // 
            // LoadWP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 494);
            this.Controls.Add(this.panelEx1);
            this.DoubleBuffered = true;
            this.Name = "LoadWP";
            this.Text = "加载航点";
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advPropertyGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Controls.TextBoxX TXT_FileName;
        private DevComponents.DotNetBar.LabelX TXT_FileType;
        private DevComponents.DotNetBar.ButtonX OpenFile;
        private DevComponents.DotNetBar.AdvPropertyGrid advPropertyGrid1;
    }
}