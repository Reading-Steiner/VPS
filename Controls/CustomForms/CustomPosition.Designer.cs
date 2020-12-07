namespace VPS.Controls.CustomForms
{
    partial class CustomPosition
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
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AltFrameSelecter = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.Default = new DevComponents.DotNetBar.ButtonX();
            this.GeoAltitude = new DevComponents.DotNetBar.LabelX();
            this.LngInput = new VPS.Controls.CustomControls.CustomDoubleInput(this.components);
            this.LatInput = new VPS.Controls.CustomControls.CustomDoubleInput(this.components);
            this.AltInput = new VPS.Controls.CustomControls.CustomIntegerInput(this.components);
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LngInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LatInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AltInput)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(32, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 14);
            this.label7.TabIndex = 58;
            this.label7.Text = "经度";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(32, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 60;
            this.label1.Text = "纬度";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(32, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 62;
            this.label2.Text = "高度";
            // 
            // AltFrameSelecter
            // 
            this.AltFrameSelecter.DisplayMember = "Text";
            this.AltFrameSelecter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.AltFrameSelecter.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AltFrameSelecter.FormattingEnabled = true;
            this.AltFrameSelecter.ItemHeight = 17;
            this.AltFrameSelecter.Location = new System.Drawing.Point(85, 151);
            this.AltFrameSelecter.Name = "AltFrameSelecter";
            this.AltFrameSelecter.Size = new System.Drawing.Size(123, 23);
            this.AltFrameSelecter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.AltFrameSelecter.TabIndex = 63;
            this.AltFrameSelecter.SelectedIndexChanged += new System.EventHandler(this.AltFrameSelecter_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(18, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 64;
            this.label3.Text = "高度框架";
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonX2.Location = new System.Drawing.Point(128, 273);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(72, 23);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 66;
            this.buttonX2.Text = "取消";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonX1.Location = new System.Drawing.Point(26, 273);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(72, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 65;
            this.buttonX1.Text = "确定";
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.Default);
            this.panelEx1.Controls.Add(this.GeoAltitude);
            this.panelEx1.Controls.Add(this.buttonX2);
            this.panelEx1.Controls.Add(this.LngInput);
            this.panelEx1.Controls.Add(this.buttonX1);
            this.panelEx1.Controls.Add(this.label7);
            this.panelEx1.Controls.Add(this.label3);
            this.panelEx1.Controls.Add(this.LatInput);
            this.panelEx1.Controls.Add(this.AltFrameSelecter);
            this.panelEx1.Controls.Add(this.label1);
            this.panelEx1.Controls.Add(this.label2);
            this.panelEx1.Controls.Add(this.AltInput);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(226, 315);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 67;
            // 
            // Default
            // 
            this.Default.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Default.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Default.Location = new System.Drawing.Point(168, 191);
            this.Default.Name = "Default";
            this.Default.Size = new System.Drawing.Size(40, 23);
            this.Default.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Default.TabIndex = 68;
            this.Default.Text = "默认";
            this.Default.Click += new System.EventHandler(this.Default_Click);
            // 
            // GeoAltitude
            // 
            // 
            // 
            // 
            this.GeoAltitude.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.GeoAltitude.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GeoAltitude.Location = new System.Drawing.Point(23, 110);
            this.GeoAltitude.Name = "GeoAltitude";
            this.GeoAltitude.Size = new System.Drawing.Size(185, 23);
            this.GeoAltitude.TabIndex = 67;
            this.GeoAltitude.Text = "地面海拔";
            // 
            // LngInput
            // 
            this.LngInput.AllowEmptyState = false;
            // 
            // 
            // 
            this.LngInput.BackgroundStyle.Class = "DateTimeInputBackground";
            this.LngInput.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LngInput.ButtonFreeText.Checked = true;
            this.LngInput.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.LngInput.DisplayFormat = "0.###############";
            this.LngInput.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LngInput.FreeTextEntryMode = true;
            this.LngInput.Increment = 0D;
            this.LngInput.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.LngInput.Location = new System.Drawing.Point(85, 29);
            this.LngInput.MaxValue = 1000000000D;
            this.LngInput.MinValue = 0D;
            this.LngInput.Name = "LngInput";
            this.LngInput.Size = new System.Drawing.Size(123, 23);
            this.LngInput.TabIndex = 57;
            this.LngInput.ValueChanged += new System.EventHandler(this.LngInput_ValueChanged);
            // 
            // LatInput
            // 
            this.LatInput.AllowEmptyState = false;
            // 
            // 
            // 
            this.LatInput.BackgroundStyle.Class = "DateTimeInputBackground";
            this.LatInput.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LatInput.ButtonFreeText.Checked = true;
            this.LatInput.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.LatInput.DisplayFormat = "0.###############";
            this.LatInput.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LatInput.FreeTextEntryMode = true;
            this.LatInput.Increment = 0D;
            this.LatInput.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.LatInput.Location = new System.Drawing.Point(85, 68);
            this.LatInput.MaxValue = 1000000000D;
            this.LatInput.MinValue = 0D;
            this.LatInput.Name = "LatInput";
            this.LatInput.Size = new System.Drawing.Size(123, 23);
            this.LatInput.TabIndex = 59;
            this.LatInput.ValueChanged += new System.EventHandler(this.LatInput_ValueChanged);
            // 
            // AltInput
            // 
            this.AltInput.AllowEmptyState = false;
            // 
            // 
            // 
            this.AltInput.BackgroundStyle.Class = "DateTimeInputBackground";
            this.AltInput.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.AltInput.ButtonFreeText.Checked = true;
            this.AltInput.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.AltInput.DisplayFormat = "0 m";
            this.AltInput.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AltInput.FreeTextEntryMode = true;
            this.AltInput.Increment = 0;
            this.AltInput.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.AltInput.Location = new System.Drawing.Point(85, 191);
            this.AltInput.MaxValue = 1000000000;
            this.AltInput.MinValue = 0;
            this.AltInput.Name = "AltInput";
            this.AltInput.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.AltInput.Size = new System.Drawing.Size(82, 23);
            this.AltInput.TabIndex = 61;
            this.AltInput.ValueChanged += new System.EventHandler(this.AltInput_ValueChanged);
            // 
            // CustomPosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 315);
            this.Controls.Add(this.panelEx1);
            this.DoubleBuffered = true;
            this.Name = "CustomPosition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "坐标";
            this.Load += new System.EventHandler(this.CustomPosition_Load);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LngInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LatInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AltInput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private CustomControls.CustomDoubleInput LngInput;
        private System.Windows.Forms.Label label1;
        private CustomControls.CustomDoubleInput LatInput;
        private System.Windows.Forms.Label label2;
        private CustomControls.CustomIntegerInput AltInput;
        private DevComponents.DotNetBar.Controls.ComboBoxEx AltFrameSelecter;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.LabelX GeoAltitude;
        private DevComponents.DotNetBar.ButtonX Default;
    }
}