namespace VPS.Controls.CustomForms
{
    partial class CustomRect
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
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.Default = new DevComponents.DotNetBar.ButtonX();
            this.TopLatInput = new VPS.Controls.CustomControls.CustomDoubleInput(this.components);
            this.BottomLatInput = new VPS.Controls.CustomControls.CustomDoubleInput(this.components);
            this.LeftLngInput = new VPS.Controls.CustomControls.CustomDoubleInput(this.components);
            this.RightLngInput = new VPS.Controls.CustomControls.CustomDoubleInput(this.components);
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TopLatInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomLatInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftLngInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightLngInput)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.Default);
            this.panelEx1.Controls.Add(this.TopLatInput);
            this.panelEx1.Controls.Add(this.BottomLatInput);
            this.panelEx1.Controls.Add(this.LeftLngInput);
            this.panelEx1.Controls.Add(this.RightLngInput);
            this.panelEx1.Controls.Add(this.buttonX2);
            this.panelEx1.Controls.Add(this.buttonX1);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(345, 180);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 70;
            // 
            // Default
            // 
            this.Default.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Default.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Default.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Default.Location = new System.Drawing.Point(238, 134);
            this.Default.Name = "Default";
            this.Default.Size = new System.Drawing.Size(72, 23);
            this.Default.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Default.TabIndex = 79;
            this.Default.Text = "默认";
            // 
            // TopLatInput
            // 
            this.TopLatInput.AllowEmptyState = false;
            // 
            // 
            // 
            this.TopLatInput.BackgroundStyle.Class = "DateTimeInputBackground";
            this.TopLatInput.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TopLatInput.ButtonFreeText.Checked = true;
            this.TopLatInput.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.TopLatInput.DisplayFormat = "0.###############";
            this.TopLatInput.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TopLatInput.FreeTextEntryMode = true;
            this.TopLatInput.Increment = 0D;
            this.TopLatInput.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.TopLatInput.Location = new System.Drawing.Point(113, 27);
            this.TopLatInput.MaxValue = 1000000000D;
            this.TopLatInput.MinValue = 0D;
            this.TopLatInput.Name = "TopLatInput";
            this.TopLatInput.Size = new System.Drawing.Size(123, 23);
            this.TopLatInput.TabIndex = 74;
            // 
            // BottomLatInput
            // 
            this.BottomLatInput.AllowEmptyState = false;
            // 
            // 
            // 
            this.BottomLatInput.BackgroundStyle.Class = "DateTimeInputBackground";
            this.BottomLatInput.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.BottomLatInput.ButtonFreeText.Checked = true;
            this.BottomLatInput.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.BottomLatInput.DisplayFormat = "0.###############";
            this.BottomLatInput.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BottomLatInput.FreeTextEntryMode = true;
            this.BottomLatInput.Increment = 0D;
            this.BottomLatInput.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.BottomLatInput.Location = new System.Drawing.Point(113, 85);
            this.BottomLatInput.MaxValue = 1000000000D;
            this.BottomLatInput.MinValue = 0D;
            this.BottomLatInput.Name = "BottomLatInput";
            this.BottomLatInput.Size = new System.Drawing.Size(123, 23);
            this.BottomLatInput.TabIndex = 71;
            // 
            // LeftLngInput
            // 
            this.LeftLngInput.AllowEmptyState = false;
            // 
            // 
            // 
            this.LeftLngInput.BackgroundStyle.Class = "DateTimeInputBackground";
            this.LeftLngInput.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LeftLngInput.ButtonFreeText.Checked = true;
            this.LeftLngInput.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.LeftLngInput.DisplayFormat = "0.###############";
            this.LeftLngInput.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LeftLngInput.FreeTextEntryMode = true;
            this.LeftLngInput.Increment = 0D;
            this.LeftLngInput.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.LeftLngInput.Location = new System.Drawing.Point(11, 56);
            this.LeftLngInput.MaxValue = 1000000000D;
            this.LeftLngInput.MinValue = 0D;
            this.LeftLngInput.Name = "LeftLngInput";
            this.LeftLngInput.Size = new System.Drawing.Size(123, 23);
            this.LeftLngInput.TabIndex = 67;
            // 
            // RightLngInput
            // 
            this.RightLngInput.AllowEmptyState = false;
            // 
            // 
            // 
            this.RightLngInput.BackgroundStyle.Class = "DateTimeInputBackground";
            this.RightLngInput.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.RightLngInput.ButtonFreeText.Checked = true;
            this.RightLngInput.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.RightLngInput.DisplayFormat = "0.###############";
            this.RightLngInput.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RightLngInput.FreeTextEntryMode = true;
            this.RightLngInput.Increment = 0D;
            this.RightLngInput.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.RightLngInput.Location = new System.Drawing.Point(209, 56);
            this.RightLngInput.MaxValue = 1000000000D;
            this.RightLngInput.MinValue = 0D;
            this.RightLngInput.Name = "RightLngInput";
            this.RightLngInput.Size = new System.Drawing.Size(123, 23);
            this.RightLngInput.TabIndex = 69;
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonX2.Location = new System.Drawing.Point(137, 134);
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
            this.buttonX1.Location = new System.Drawing.Point(35, 134);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(72, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 65;
            this.buttonX1.Text = "确定";
            // 
            // CustomRect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 180);
            this.Controls.Add(this.panelEx1);
            this.Name = "CustomRect";
            this.Text = "CustomRect";
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TopLatInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomLatInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftLngInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightLngInput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX Default;
        private CustomControls.CustomDoubleInput TopLatInput;
        private CustomControls.CustomDoubleInput BottomLatInput;
        private CustomControls.CustomDoubleInput LeftLngInput;
        private CustomControls.CustomDoubleInput RightLngInput;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX buttonX1;
    }
}