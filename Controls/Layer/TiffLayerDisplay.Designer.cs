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
            this.myPositionDisplay1 = new VPS.Controls.MyControls.MyPositionDisplay();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.myPositionDisplay1);
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
            // myPositionDisplay1
            // 
            this.myPositionDisplay1.AutoSize = true;
            this.myPositionDisplay1.Location = new System.Drawing.Point(24, 15);
            this.myPositionDisplay1.MinimumSize = new System.Drawing.Size(100, 60);
            this.myPositionDisplay1.Name = "myPositionDisplay1";
            this.myPositionDisplay1.PositionName = "位置";
            this.myPositionDisplay1.Size = new System.Drawing.Size(195, 67);
            this.myPositionDisplay1.TabIndex = 0;
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
            this.myPositionDisplay1.WGS84Position = pointLatLngAlt1;
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
        private MyControls.MyPositionDisplay myPositionDisplay1;
    }
}
