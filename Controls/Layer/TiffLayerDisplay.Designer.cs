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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TiffLayerDisplay));
            VPS.Utilities.PointLatLngAlt pointLatLngAlt2 = new VPS.Utilities.PointLatLngAlt();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.StateDisplay = new VPS.Controls.Layer.TiffLayerDisplay.CustomLayerVaildState();
            this.IdDisplay = new DevComponents.DotNetBar.LabelX();
            this.LayerDisplay = new DevComponents.DotNetBar.LabelX();
            this.ModifyTimeDisplay = new DevComponents.DotNetBar.LabelX();
            this.CreateTimeDisplay = new DevComponents.DotNetBar.LabelX();
            this.LayerRectDisplay = new VPS.Controls.CustomControls.RectDisplay();
            this.HomePositionDisplay = new VPS.Controls.CustomControls.PositionDisplay();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.panelEx1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.LayerDisplay);
            this.panelEx1.Controls.Add(this.ModifyTimeDisplay);
            this.panelEx1.Controls.Add(this.CreateTimeDisplay);
            this.panelEx1.Controls.Add(this.LayerRectDisplay);
            this.panelEx1.Controls.Add(this.HomePositionDisplay);
            this.panelEx1.Controls.Add(this.panelEx2);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(500, 250);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // StateDisplay
            // 
            this.StateDisplay.AutoSize = true;
            this.StateDisplay.BackColor = System.Drawing.Color.Transparent;
            this.StateDisplay.Location = new System.Drawing.Point(3, 0);
            this.StateDisplay.Name = "StateDisplay";
            this.StateDisplay.Size = new System.Drawing.Size(69, 24);
            this.StateDisplay.TabIndex = 7;
            // 
            // IdDisplay
            // 
            // 
            // 
            // 
            this.IdDisplay.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.IdDisplay.Location = new System.Drawing.Point(377, 3);
            this.IdDisplay.Name = "IdDisplay";
            this.IdDisplay.Size = new System.Drawing.Size(110, 16);
            this.IdDisplay.TabIndex = 6;
            this.IdDisplay.Text = "0";
            this.IdDisplay.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // LayerDisplay
            // 
            this.LayerDisplay.AutoSize = true;
            // 
            // 
            // 
            this.LayerDisplay.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LayerDisplay.Location = new System.Drawing.Point(3, 3);
            this.LayerDisplay.Name = "LayerDisplay";
            this.LayerDisplay.Size = new System.Drawing.Size(44, 18);
            this.LayerDisplay.TabIndex = 5;
            this.LayerDisplay.Text = "图层：";
            // 
            // ModifyTimeDisplay
            // 
            this.ModifyTimeDisplay.AutoSize = true;
            // 
            // 
            // 
            this.ModifyTimeDisplay.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ModifyTimeDisplay.Location = new System.Drawing.Point(245, 204);
            this.ModifyTimeDisplay.Name = "ModifyTimeDisplay";
            this.ModifyTimeDisplay.Size = new System.Drawing.Size(68, 18);
            this.ModifyTimeDisplay.TabIndex = 4;
            this.ModifyTimeDisplay.Text = "修改日期：";
            // 
            // CreateTimeDisplay
            // 
            this.CreateTimeDisplay.AutoSize = true;
            // 
            // 
            // 
            this.CreateTimeDisplay.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.CreateTimeDisplay.Location = new System.Drawing.Point(3, 204);
            this.CreateTimeDisplay.Name = "CreateTimeDisplay";
            this.CreateTimeDisplay.Size = new System.Drawing.Size(68, 18);
            this.CreateTimeDisplay.TabIndex = 3;
            this.CreateTimeDisplay.Text = "创建日期：";
            // 
            // LayerRectDisplay
            // 
            this.LayerRectDisplay.AutoSize = true;
            this.LayerRectDisplay.IsReadOnly = true;
            this.LayerRectDisplay.Location = new System.Drawing.Point(3, 32);
            this.LayerRectDisplay.MinimumSize = new System.Drawing.Size(209, 23);
            this.LayerRectDisplay.Name = "LayerRectDisplay";
            this.LayerRectDisplay.PositionName = "区域";
            this.LayerRectDisplay.Size = new System.Drawing.Size(209, 89);
            this.LayerRectDisplay.TabIndex = 1;
            this.LayerRectDisplay.WGS84Rect = ((GMap.NET.RectLatLng)(resources.GetObject("LayerRectDisplay.WGS84Rect")));
            // 
            // HomePositionDisplay
            // 
            this.HomePositionDisplay.AutoSize = true;
            this.HomePositionDisplay.IsReadOnly = true;
            this.HomePositionDisplay.Location = new System.Drawing.Point(245, 32);
            this.HomePositionDisplay.MinimumSize = new System.Drawing.Size(100, 60);
            this.HomePositionDisplay.Name = "HomePositionDisplay";
            this.HomePositionDisplay.PositionName = "初始位置";
            this.HomePositionDisplay.Size = new System.Drawing.Size(206, 67);
            this.HomePositionDisplay.TabIndex = 0;
            pointLatLngAlt2.Alt = 0D;
            pointLatLngAlt2.color = System.Drawing.Color.White;
            pointLatLngAlt2.Lat = 0D;
            pointLatLngAlt2.Lng = 0D;
            pointLatLngAlt2.Param1 = 0D;
            pointLatLngAlt2.Param2 = 0D;
            pointLatLngAlt2.Param3 = 0D;
            pointLatLngAlt2.Param4 = 0D;
            pointLatLngAlt2.Tag = "";
            pointLatLngAlt2.Tag2 = "";
            this.HomePositionDisplay.WGS84Position = pointLatLngAlt2;
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.IdDisplay);
            this.panelEx2.Controls.Add(this.StateDisplay);
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx2.Location = new System.Drawing.Point(0, 228);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(500, 22);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.StyleMouseDown.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.StyleMouseDown.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.panelEx2.StyleMouseDown.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.panelEx2.StyleMouseDown.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBorder;
            this.panelEx2.StyleMouseDown.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedText;
            this.panelEx2.StyleMouseOver.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.StyleMouseOver.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemHotBackground;
            this.panelEx2.StyleMouseOver.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemHotBackground2;
            this.panelEx2.StyleMouseOver.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemHotBorder;
            this.panelEx2.StyleMouseOver.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemHotText;
            this.panelEx2.TabIndex = 8;
            // 
            // TiffLayerDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelEx1);
            this.Name = "TiffLayerDisplay";
            this.Size = new System.Drawing.Size(500, 250);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private CustomControls.PositionDisplay HomePositionDisplay;
        private CustomControls.RectDisplay LayerRectDisplay;
        private DevComponents.DotNetBar.LabelX ModifyTimeDisplay;
        private DevComponents.DotNetBar.LabelX CreateTimeDisplay;
        private DevComponents.DotNetBar.LabelX LayerDisplay;
        private DevComponents.DotNetBar.LabelX IdDisplay;
        private CustomLayerVaildState StateDisplay;
        private DevComponents.DotNetBar.PanelEx panelEx2;
    }
}
