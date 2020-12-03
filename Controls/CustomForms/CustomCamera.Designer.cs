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
            this.FocalLength = new VPS.Controls.CustomControls.CustomDoubleInput(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SensHeight = new VPS.Controls.CustomControls.CustomDoubleInput(this.components);
            this.SensWidth = new VPS.Controls.CustomControls.CustomDoubleInput(this.components);
            this.ImgHeight = new VPS.Controls.CustomControls.CustomIntegerInput(this.components);
            this.ImgWidth = new VPS.Controls.CustomControls.CustomIntegerInput(this.components);
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.regularExpressionValidator1 = new DevComponents.DotNetBar.Validator.RegularExpressionValidator();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            ((System.ComponentModel.ISupportInitialize)(this.FocalLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SensHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SensWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgWidth)).BeginInit();
            this.panelEx1.SuspendLayout();
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
            this.labelX1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.Location = new System.Drawing.Point(26, 17);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(65, 20);
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
            this.labelX2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.Location = new System.Drawing.Point(26, 52);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(79, 20);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "焦距【mm】";
            // 
            // Camera
            // 
            // 
            // 
            // 
            this.Camera.Border.Class = "TextBoxBorder";
            this.Camera.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Camera.Location = new System.Drawing.Point(111, 16);
            this.Camera.Name = "Camera";
            this.Camera.Size = new System.Drawing.Size(150, 21);
            this.Camera.TabIndex = 2;
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
            this.FocalLength.Location = new System.Drawing.Point(111, 51);
            this.FocalLength.Name = "FocalLength";
            this.FocalLength.ShowUpDown = true;
            this.FocalLength.Size = new System.Drawing.Size(80, 21);
            this.FocalLength.TabIndex = 39;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(158, 211);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 14);
            this.label9.TabIndex = 58;
            this.label9.Text = "高";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(24, 211);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 14);
            this.label8.TabIndex = 57;
            this.label8.Text = "宽";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(24, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 14);
            this.label7.TabIndex = 56;
            this.label7.Text = "宽";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(158, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 14);
            this.label5.TabIndex = 55;
            this.label5.Text = "高";
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
            this.SensHeight.Location = new System.Drawing.Point(181, 208);
            this.SensHeight.MaxValue = 1000000D;
            this.SensHeight.MinValue = 0D;
            this.SensHeight.Name = "SensHeight";
            this.SensHeight.Size = new System.Drawing.Size(80, 21);
            this.SensHeight.TabIndex = 54;
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
            this.SensWidth.Location = new System.Drawing.Point(47, 208);
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
            this.ImgHeight.Location = new System.Drawing.Point(181, 130);
            this.ImgHeight.MaxValue = 1000000000;
            this.ImgHeight.MinValue = 0;
            this.ImgHeight.Name = "ImgHeight";
            this.ImgHeight.Size = new System.Drawing.Size(80, 21);
            this.ImgHeight.TabIndex = 52;
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
            this.ImgWidth.Location = new System.Drawing.Point(47, 130);
            this.ImgWidth.MaxValue = 1000000000;
            this.ImgWidth.MinValue = 0;
            this.ImgWidth.Name = "ImgWidth";
            this.ImgWidth.Size = new System.Drawing.Size(80, 21);
            this.ImgWidth.TabIndex = 51;
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
            this.labelX5.Location = new System.Drawing.Point(58, 179);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(173, 23);
            this.labelX5.TabIndex = 50;
            this.labelX5.Text = "相机传感器尺寸【mm】";
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
            this.labelX4.Location = new System.Drawing.Point(58, 101);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(173, 23);
            this.labelX4.TabIndex = 49;
            this.labelX4.Text = "最高图像分辨率【pl】";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonX1.Location = new System.Drawing.Point(104, 302);
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
            this.buttonX2.Location = new System.Drawing.Point(201, 302);
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
            this.panelEx1.Controls.Add(this.buttonX2);
            this.panelEx1.Controls.Add(this.labelX5);
            this.panelEx1.Controls.Add(this.buttonX1);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Controls.Add(this.label9);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.label8);
            this.panelEx1.Controls.Add(this.Camera);
            this.panelEx1.Controls.Add(this.label7);
            this.panelEx1.Controls.Add(this.FocalLength);
            this.panelEx1.Controls.Add(this.label5);
            this.panelEx1.Controls.Add(this.labelX4);
            this.panelEx1.Controls.Add(this.SensHeight);
            this.panelEx1.Controls.Add(this.ImgWidth);
            this.panelEx1.Controls.Add(this.SensWidth);
            this.panelEx1.Controls.Add(this.ImgHeight);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(288, 337);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 61;
            // 
            // CustomCamera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(288, 337);
            this.Controls.Add(this.panelEx1);
            this.DoubleBuffered = true;
            this.Name = "CustomCamera";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "相机参数";
            ((System.ComponentModel.ISupportInitialize)(this.FocalLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SensHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SensWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgWidth)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX Camera;
        private VPS.Controls.CustomControls.CustomDoubleInput FocalLength;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
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
    }
}