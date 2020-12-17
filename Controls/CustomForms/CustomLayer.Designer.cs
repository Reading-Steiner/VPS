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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomLayer));
            this.colorPickerButton = new DevComponents.DotNetBar.ColorPickerButton();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.checkBoxX1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.AcceptButton = new DevComponents.DotNetBar.ButtonX();
            this.DefaultButton = new DevComponents.DotNetBar.ButtonX();
            this.DisplayImage = new DevComponents.DotNetBar.Controls.ReflectionImage();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.colorDisplay = new DevComponents.DotNetBar.LabelX();
            this.colorInfoDisplay = new DevComponents.DotNetBar.LabelX();
            this.panelEx1.SuspendLayout();
            this.panelEx3.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.SuspendLayout();
            // 
            // colorPickerButton
            // 
            this.colorPickerButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.colorPickerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.colorPickerButton.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.colorPickerButton.Image = ((System.Drawing.Image)(resources.GetObject("colorPickerButton.Image")));
            this.colorPickerButton.Location = new System.Drawing.Point(59, 3);
            this.colorPickerButton.Name = "colorPickerButton";
            this.colorPickerButton.SelectedColorImageRectangle = new System.Drawing.Rectangle(2, 2, 12, 12);
            this.colorPickerButton.Size = new System.Drawing.Size(51, 23);
            this.colorPickerButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.colorPickerButton.TabIndex = 4;
            this.colorPickerButton.SelectedColorChanged += new System.EventHandler(this.colorPickerButton_SelectedColorChanged);
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.Location = new System.Drawing.Point(3, 5);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(50, 20);
            this.labelX1.TabIndex = 6;
            this.labelX1.Text = "透明色";
            // 
            // panelEx1
            // 
            this.panelEx1.AutoSize = true;
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.panelEx3);
            this.panelEx1.Controls.Add(this.AcceptButton);
            this.panelEx1.Controls.Add(this.DefaultButton);
            this.panelEx1.Controls.Add(this.DisplayImage);
            this.panelEx1.Controls.Add(this.panelEx2);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(302, 361);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 7;
            // 
            // panelEx3
            // 
            this.panelEx3.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.checkBoxX1);
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx3.Location = new System.Drawing.Point(0, 28);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(302, 28);
            this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 12;
            // 
            // checkBoxX1
            // 
            // 
            // 
            // 
            this.checkBoxX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX1.Location = new System.Drawing.Point(28, 2);
            this.checkBoxX1.Name = "checkBoxX1";
            this.checkBoxX1.Size = new System.Drawing.Size(100, 23);
            this.checkBoxX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX1.TabIndex = 0;
            this.checkBoxX1.Text = "使用透明色";
            this.checkBoxX1.CheckedChanged += new System.EventHandler(this.withTransparent_CheckedChanged);
            // 
            // AcceptButton
            // 
            this.AcceptButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.AcceptButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AcceptButton.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.AcceptButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.AcceptButton.Location = new System.Drawing.Point(178, 335);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(75, 23);
            this.AcceptButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.AcceptButton.TabIndex = 11;
            this.AcceptButton.Text = "确定";
            // 
            // DefaultButton
            // 
            this.DefaultButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.DefaultButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DefaultButton.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.DefaultButton.Location = new System.Drawing.Point(53, 335);
            this.DefaultButton.Name = "DefaultButton";
            this.DefaultButton.Size = new System.Drawing.Size(75, 23);
            this.DefaultButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.DefaultButton.TabIndex = 10;
            this.DefaultButton.Text = "默认";
            this.DefaultButton.Click += new System.EventHandler(this.DefaultButton_Click);
            // 
            // DisplayImage
            // 
            this.DisplayImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.DisplayImage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.DisplayImage.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.DisplayImage.Location = new System.Drawing.Point(1, 30);
            this.DisplayImage.Name = "DisplayImage";
            this.DisplayImage.ReflectionEnabled = false;
            this.DisplayImage.Size = new System.Drawing.Size(300, 300);
            this.DisplayImage.TabIndex = 7;
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.colorInfoDisplay);
            this.panelEx2.Controls.Add(this.labelX1);
            this.panelEx2.Controls.Add(this.colorDisplay);
            this.panelEx2.Controls.Add(this.colorPickerButton);
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx2.Location = new System.Drawing.Point(0, 0);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(302, 28);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 9;
            // 
            // colorDisplay
            // 
            this.colorDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.colorDisplay.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.colorDisplay.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.colorDisplay.Location = new System.Drawing.Point(152, 5);
            this.colorDisplay.Name = "colorDisplay";
            this.colorDisplay.Size = new System.Drawing.Size(51, 18);
            this.colorDisplay.TabIndex = 8;
            // 
            // colorInfoDisplay
            // 
            this.colorInfoDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.colorInfoDisplay.AutoSize = true;
            // 
            // 
            // 
            this.colorInfoDisplay.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.colorInfoDisplay.Location = new System.Drawing.Point(209, 7);
            this.colorInfoDisplay.Name = "colorInfoDisplay";
            this.colorInfoDisplay.Size = new System.Drawing.Size(50, 16);
            this.colorInfoDisplay.TabIndex = 9;
            // 
            // CustomLayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(302, 361);
            this.Controls.Add(this.panelEx1);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.Name = "CustomLayer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "图层";
            this.panelEx1.ResumeLayout(false);
            this.panelEx3.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevComponents.DotNetBar.ColorPickerButton colorPickerButton;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Controls.ReflectionImage DisplayImage;
        private DevComponents.DotNetBar.LabelX colorDisplay;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX1;
        private DevComponents.DotNetBar.ButtonX AcceptButton;
        private DevComponents.DotNetBar.ButtonX DefaultButton;
        private DevComponents.DotNetBar.LabelX colorInfoDisplay;
    }
}