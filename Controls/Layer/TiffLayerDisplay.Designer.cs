namespace VPS.Controls.Layer
{
    partial class TiffLayerDisplay
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            VPS.Utilities.PointLatLngAlt pointLatLngAlt1 = new VPS.Utilities.PointLatLngAlt();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.HomePositionDisplay = new VPS.Controls.MyControls.MyPositionDisplay();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.HomePositionDisplay);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(300, 240);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // HomePositionDisplay
            // 
            this.HomePositionDisplay.AutoSize = true;
            this.HomePositionDisplay.IsReadOnly = false;
            this.HomePositionDisplay.Location = new System.Drawing.Point(17, 3);
            this.HomePositionDisplay.MinimumSize = new System.Drawing.Size(100, 60);
            this.HomePositionDisplay.Name = "HomePositionDisplay";
            this.HomePositionDisplay.PositionName = "位置";
            this.HomePositionDisplay.Size = new System.Drawing.Size(195, 67);
            this.HomePositionDisplay.TabIndex = 0;
            pointLatLngAlt1.Alt = 0D;
            pointLatLngAlt1.color = System.Drawing.Color.White;
            pointLatLngAlt1.Lat = 0D;
            pointLatLngAlt1.Lng = 0D;
            pointLatLngAlt1.Param1 = 0D;
            pointLatLngAlt1.Param2 = 0D;
            pointLatLngAlt1.Param3 = 0D;
            pointLatLngAlt1.Param4 = 0D;
            pointLatLngAlt1.Tag = "";
            pointLatLngAlt1.Tag2 = "";
            this.HomePositionDisplay.WGS84Position = pointLatLngAlt1;
            // 
            // TiffLayerDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelEx1);
            this.Name = "TiffLayerDisplay";
            this.Size = new System.Drawing.Size(300, 240);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private MyControls.MyPositionDisplay HomePositionDisplay;
    }
}
