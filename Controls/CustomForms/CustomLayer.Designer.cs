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
            this.DisplayImage = new System.Windows.Forms.PictureBox();
            this.colorPickerButton = new DevComponents.DotNetBar.ColorPickerButton();
            this.colorCombControl = new DevComponents.DotNetBar.ColorPickers.ColorCombControl();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayImage)).BeginInit();
            this.SuspendLayout();
            // 
            // DisplayImage
            // 
            this.DisplayImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DisplayImage.Location = new System.Drawing.Point(2, 32);
            this.DisplayImage.Name = "DisplayImage";
            this.DisplayImage.Size = new System.Drawing.Size(300, 300);
            this.DisplayImage.TabIndex = 3;
            this.DisplayImage.TabStop = false;
            // 
            // colorPickerButton
            // 
            this.colorPickerButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.colorPickerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.colorPickerButton.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.colorPickerButton.Image = ((System.Drawing.Image)(resources.GetObject("colorPickerButton.Image")));
            this.colorPickerButton.Location = new System.Drawing.Point(60, 3);
            this.colorPickerButton.Name = "colorPickerButton";
            this.colorPickerButton.SelectedColorImageRectangle = new System.Drawing.Rectangle(2, 2, 12, 12);
            this.colorPickerButton.Size = new System.Drawing.Size(37, 23);
            this.colorPickerButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.colorPickerButton.TabIndex = 4;
            this.colorPickerButton.SelectedColorChanged += new System.EventHandler(this.colorPickerButton_SelectedColorChanged);
            // 
            // colorCombControl
            // 
            this.colorCombControl.BackColor = System.Drawing.Color.Transparent;
            this.colorCombControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.colorCombControl.Location = new System.Drawing.Point(103, 6);
            this.colorCombControl.Name = "colorCombControl";
            this.colorCombControl.Size = new System.Drawing.Size(65, 18);
            this.colorCombControl.TabIndex = 5;
            this.colorCombControl.Text = "colorCombControl1";
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.Location = new System.Drawing.Point(4, 6);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(50, 20);
            this.labelX1.TabIndex = 6;
            this.labelX1.Text = "透明色";
            // 
            // CustomLayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 333);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.colorCombControl);
            this.Controls.Add(this.colorPickerButton);
            this.Controls.Add(this.DisplayImage);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.Name = "CustomLayer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "图层";
            ((System.ComponentModel.ISupportInitialize)(this.DisplayImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox DisplayImage;
        private DevComponents.DotNetBar.ColorPickerButton colorPickerButton;
        private DevComponents.DotNetBar.ColorPickers.ColorCombControl colorCombControl;
        private DevComponents.DotNetBar.LabelX labelX1;
    }
}