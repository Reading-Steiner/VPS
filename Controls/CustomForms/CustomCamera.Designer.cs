namespace VPS.Controls.CustomForms
{
    partial class CustomCamera
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.Camera = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.regularExpressionValidator1 = new DevComponents.DotNetBar.Validator.RegularExpressionValidator();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.FocalLength = new VPS.Controls.CustomControls.CustomDoubleInput(this.components);
            this.SensHeight = new VPS.Controls.CustomControls.CustomDoubleInput(this.components);
            this.ImgWidth = new VPS.Controls.CustomControls.CustomIntegerInput(this.components);
            this.SensWidth = new VPS.Controls.CustomControls.CustomDoubleInput(this.components);
            this.ImgHeight = new VPS.Controls.CustomControls.CustomIntegerInput(this.components);
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FocalLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SensHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SensWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.Location = new System.Drawing.Point(17, 19);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(56, 18);
            this.labelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "相机型号";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.Location = new System.Drawing.Point(17, 55);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(56, 18);
            this.labelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "焦距(mm)";
            // 
            // Camera
            // 
            // 
            // 
            // 
            this.Camera.Border.Class = "TextBoxBorder";
            this.Camera.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Camera.Location = new System.Drawing.Point(102, 16);
            this.Camera.Name = "Camera";
            this.Camera.Size = new System.Drawing.Size(150, 21);
            this.Camera.TabIndex = 2;
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX5.Location = new System.Drawing.Point(51, 179);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(156, 23);
            this.labelX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX5.TabIndex = 50;
            this.labelX5.Text = "相机传感器尺寸(mm)";
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX4.Location = new System.Drawing.Point(51, 101);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(156, 23);
            this.labelX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX4.TabIndex = 49;
            this.labelX4.Text = "最高图像分辨率(pl)";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonX1.Location = new System.Drawing.Point(36, 274);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 59;
            this.buttonX1.Text = "确定";
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonX2.Location = new System.Drawing.Point(152, 274);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(75, 23);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 60;
            this.buttonX2.Text = "取消";
            // 
            // regularExpressionValidator1
            // 
            this.regularExpressionValidator1.ErrorMessage = "Your error message here.";
            this.regularExpressionValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.labelX8);
            this.panelEx1.Controls.Add(this.labelX7);
            this.panelEx1.Controls.Add(this.labelX6);
            this.panelEx1.Controls.Add(this.labelX3);
            this.panelEx1.Controls.Add(this.buttonX2);
            this.panelEx1.Controls.Add(this.labelX5);
            this.panelEx1.Controls.Add(this.buttonX1);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.Camera);
            this.panelEx1.Controls.Add(this.FocalLength);
            this.panelEx1.Controls.Add(this.labelX4);
            this.panelEx1.Controls.Add(this.SensHeight);
            this.panelEx1.Controls.Add(this.ImgWidth);
            this.panelEx1.Controls.Add(this.SensWidth);
            this.panelEx1.Controls.Add(this.ImgHeight);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(267, 316);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 61;
            // 
            // labelX8
            // 
            this.labelX8.AutoSize = true;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(147, 211);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(19, 18);
            this.labelX8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX8.TabIndex = 64;
            this.labelX8.Text = "高";
            // 
            // labelX7
            // 
            this.labelX7.AutoSize = true;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(147, 132);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(19, 18);
            this.labelX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX7.TabIndex = 63;
            this.labelX7.Text = "高";
            // 
            // labelX6
            // 
            this.labelX6.AutoSize = true;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(17, 132);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(19, 18);
            this.labelX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX6.TabIndex = 62;
            this.labelX6.Text = "宽";
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(17, 211);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(19, 18);
            this.labelX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX3.TabIndex = 61;
            this.labelX3.Text = "宽";
            // 
            // FocalLength
            // 
            this.FocalLength.AllowEmptyState = false;
            // 
            // 
            // 
            this.FocalLength.BackgroundStyle.Class = "DateTimeInputBackground";
            this.FocalLength.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.FocalLength.ButtonFreeText.Checked = true;
            this.FocalLength.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.FocalLength.DisplayFormat = "0.##";
            this.FocalLength.FreeTextEntryMode = true;
            this.FocalLength.Increment = 0.01D;
            this.FocalLength.Location = new System.Drawing.Point(102, 51);
            this.FocalLength.Name = "FocalLength";
            this.FocalLength.ShowUpDown = true;
            this.FocalLength.Size = new System.Drawing.Size(80, 21);
            this.FocalLength.TabIndex = 39;
            // 
            // SensHeight
            // 
            this.SensHeight.AllowEmptyState = false;
            // 
            // 
            // 
            this.SensHeight.BackgroundStyle.Class = "DateTimeInputBackground";
            this.SensHeight.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.SensHeight.ButtonFreeText.Checked = true;
            this.SensHeight.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.SensHeight.DisplayFormat = "0.##";
            this.SensHeight.FreeTextEntryMode = true;
            this.SensHeight.Increment = 0D;
            this.SensHeight.Location = new System.Drawing.Point(172, 208);
            this.SensHeight.MaxValue = 1000000D;
            this.SensHeight.MinValue = 0D;
            this.SensHeight.Name = "SensHeight";
            this.SensHeight.Size = new System.Drawing.Size(80, 21);
            this.SensHeight.TabIndex = 54;
            // 
            // ImgWidth
            // 
            this.ImgWidth.AllowEmptyState = false;
            // 
            // 
            // 
            this.ImgWidth.BackgroundStyle.Class = "DateTimeInputBackground";
            this.ImgWidth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ImgWidth.ButtonFreeText.Checked = true;
            this.ImgWidth.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.ImgWidth.FreeTextEntryMode = true;
            this.ImgWidth.Increment = 0;
            this.ImgWidth.Location = new System.Drawing.Point(38, 130);
            this.ImgWidth.MaxValue = 1000000000;
            this.ImgWidth.MinValue = 0;
            this.ImgWidth.Name = "ImgWidth";
            this.ImgWidth.Size = new System.Drawing.Size(80, 21);
            this.ImgWidth.TabIndex = 51;
            // 
            // SensWidth
            // 
            this.SensWidth.AllowEmptyState = false;
            // 
            // 
            // 
            this.SensWidth.BackgroundStyle.Class = "DateTimeInputBackground";
            this.SensWidth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.SensWidth.ButtonFreeText.Checked = true;
            this.SensWidth.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.SensWidth.DisplayFormat = "0.##";
            this.SensWidth.FreeTextEntryMode = true;
            this.SensWidth.Increment = 0D;
            this.SensWidth.Location = new System.Drawing.Point(38, 208);
            this.SensWidth.MaxValue = 1000000D;
            this.SensWidth.MinValue = 0D;
            this.SensWidth.Name = "SensWidth";
            this.SensWidth.Size = new System.Drawing.Size(80, 21);
            this.SensWidth.TabIndex = 53;
            // 
            // ImgHeight
            // 
            this.ImgHeight.AllowEmptyState = false;
            // 
            // 
            // 
            this.ImgHeight.BackgroundStyle.Class = "DateTimeInputBackground";
            this.ImgHeight.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ImgHeight.ButtonFreeText.Checked = true;
            this.ImgHeight.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.ImgHeight.FreeTextEntryMode = true;
            this.ImgHeight.Increment = 0;
            this.ImgHeight.Location = new System.Drawing.Point(172, 130);
            this.ImgHeight.MaxValue = 1000000000;
            this.ImgHeight.MinValue = 0;
            this.ImgHeight.Name = "ImgHeight";
            this.ImgHeight.Size = new System.Drawing.Size(80, 21);
            this.ImgHeight.TabIndex = 52;
            // 
            // CustomCamera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(267, 316);
            this.Controls.Add(this.panelEx1);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.Name = "CustomCamera";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "相机参数";
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FocalLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SensHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SensWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgHeight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX Camera;
        private VPS.Controls.CustomControls.CustomDoubleInput FocalLength;
        private VPS.Controls.CustomControls.CustomDoubleInput SensHeight;
        private VPS.Controls.CustomControls.CustomDoubleInput SensWidth;
        private VPS.Controls.CustomControls.CustomIntegerInput ImgHeight;
        private VPS.Controls.CustomControls.CustomIntegerInput ImgWidth;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.Validator.RegularExpressionValidator regularExpressionValidator1;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX3;
    }
}