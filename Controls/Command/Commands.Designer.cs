namespace VPS.Controls.Command
{
    partial class CommandsPanel
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
            this.components = new System.ComponentModel.Container();
            VPS.Utilities.PointLatLngAlt pointLatLngAlt1 = new VPS.Utilities.PointLatLngAlt();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommandsPanel));
            this.MainPanel = new DevComponents.DotNetBar.PanelEx();
            this.HomePositionDisplay = new VPS.Controls.MyControls.MyPositionDisplay();
            this.CommandDataList = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.AutoWarnAlt = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.BaseAlt = new VPS.Controls.MyControls.MyIntegerInput(this.components);
            this.CoordSystem = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.WpRad = new VPS.Controls.MyControls.MyIntegerInput(this.components);
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.WarnAlt = new VPS.Controls.MyControls.MyIntegerInput(this.components);
            this.DefaultAlt = new VPS.Controls.MyControls.MyIntegerInput(this.components);
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.AltFrame = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BaseAlt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WpRad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarnAlt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DefaultAlt)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.MainPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.MainPanel.Controls.Add(this.HomePositionDisplay);
            this.MainPanel.Controls.Add(this.CommandDataList);
            this.MainPanel.Controls.Add(this.AutoWarnAlt);
            this.MainPanel.Controls.Add(this.labelX10);
            this.MainPanel.Controls.Add(this.BaseAlt);
            this.MainPanel.Controls.Add(this.CoordSystem);
            this.MainPanel.Controls.Add(this.labelX9);
            this.MainPanel.Controls.Add(this.labelX5);
            this.MainPanel.Controls.Add(this.WpRad);
            this.MainPanel.Controls.Add(this.labelX4);
            this.MainPanel.Controls.Add(this.labelX3);
            this.MainPanel.Controls.Add(this.WarnAlt);
            this.MainPanel.Controls.Add(this.DefaultAlt);
            this.MainPanel.Controls.Add(this.labelX2);
            this.MainPanel.Controls.Add(this.labelX1);
            this.MainPanel.Controls.Add(this.AltFrame);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1300, 278);
            this.MainPanel.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.MainPanel.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.MainPanel.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.MainPanel.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.MainPanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.MainPanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.MainPanel.Style.GradientAngle = 90;
            this.MainPanel.TabIndex = 1;
            // 
            // HomePositionDisplay
            // 
            this.HomePositionDisplay.AutoSize = true;
            this.HomePositionDisplay.Location = new System.Drawing.Point(11, 226);
            this.HomePositionDisplay.Name = "HomePositionDisplay";
            this.HomePositionDisplay.Size = new System.Drawing.Size(185, 45);
            this.HomePositionDisplay.TabIndex = 26;
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
            // CommandDataList
            // 
            this.CommandDataList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CommandDataList.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.CommandDataList.Location = new System.Drawing.Point(210, 3);
            this.CommandDataList.Name = "CommandDataList";
            this.CommandDataList.Size = new System.Drawing.Size(1087, 272);
            this.CommandDataList.TabIndex = 25;
            this.CommandDataList.CellClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridCellClickEventArgs>(this.CommandDataList_CellClick);
            this.CommandDataList.DataBindingComplete += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridDataBindingCompleteEventArgs>(this.CommandDataList_DataBindingComplete);
            // 
            // AutoWarnAlt
            // 
            this.AutoWarnAlt.AutoSize = true;
            // 
            // 
            // 
            this.AutoWarnAlt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.AutoWarnAlt.Checked = true;
            this.AutoWarnAlt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoWarnAlt.CheckValue = "Y";
            this.AutoWarnAlt.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AutoWarnAlt.Location = new System.Drawing.Point(68, 148);
            this.AutoWarnAlt.Name = "AutoWarnAlt";
            this.AutoWarnAlt.Size = new System.Drawing.Size(128, 20);
            this.AutoWarnAlt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.AutoWarnAlt.TabIndex = 24;
            this.AutoWarnAlt.Text = "自动生成警告线";
            this.AutoWarnAlt.CheckedChanged += new System.EventHandler(this.AutoWarnAlt_CheckedChanged);
            // 
            // labelX10
            // 
            this.labelX10.AutoSize = true;
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX10.Location = new System.Drawing.Point(11, 90);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(65, 20);
            this.labelX10.TabIndex = 23;
            this.labelX10.Text = "航飞基准";
            // 
            // BaseAlt
            // 
            this.BaseAlt.AllowEmptyState = false;
            // 
            // 
            // 
            this.BaseAlt.BackgroundStyle.Class = "DateTimeInputBackground";
            this.BaseAlt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.BaseAlt.ButtonFreeText.Checked = true;
            this.BaseAlt.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.BaseAlt.DisplayFormat = "0 m";
            this.BaseAlt.FreeTextEntryMode = true;
            this.BaseAlt.Location = new System.Drawing.Point(82, 89);
            this.BaseAlt.MaxValue = 10000000;
            this.BaseAlt.MinValue = -10000000;
            this.BaseAlt.Name = "BaseAlt";
            this.BaseAlt.ShowUpDown = true;
            this.BaseAlt.Size = new System.Drawing.Size(80, 21);
            this.BaseAlt.TabIndex = 22;
            this.BaseAlt.ValueChanged += new System.EventHandler(this.BaseAlt_ValueChanged);
            // 
            // CoordSystem
            // 
            this.CoordSystem.DisplayMember = "Text";
            this.CoordSystem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CoordSystem.FormattingEnabled = true;
            this.CoordSystem.ItemHeight = 15;
            this.CoordSystem.Location = new System.Drawing.Point(82, 9);
            this.CoordSystem.Name = "CoordSystem";
            this.CoordSystem.Size = new System.Drawing.Size(114, 21);
            this.CoordSystem.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CoordSystem.TabIndex = 18;
            this.CoordSystem.SelectedIndexChanged += new System.EventHandler(this.CoordSystem_SelectedIndexChanged);
            // 
            // labelX9
            // 
            this.labelX9.AutoSize = true;
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX9.Location = new System.Drawing.Point(11, 10);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(65, 20);
            this.labelX9.TabIndex = 17;
            this.labelX9.Text = "坐标系统";
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX5.Location = new System.Drawing.Point(11, 200);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(65, 20);
            this.labelX5.TabIndex = 9;
            this.labelX5.Text = "初始位置";
            // 
            // WpRad
            // 
            this.WpRad.AllowEmptyState = false;
            // 
            // 
            // 
            this.WpRad.BackgroundStyle.Class = "DateTimeInputBackground";
            this.WpRad.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.WpRad.ButtonFreeText.Checked = true;
            this.WpRad.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.WpRad.DisplayFormat = "0 m";
            this.WpRad.FreeTextEntryMode = true;
            this.WpRad.Location = new System.Drawing.Point(82, 174);
            this.WpRad.MaxValue = 1000;
            this.WpRad.MinValue = 0;
            this.WpRad.Name = "WpRad";
            this.WpRad.ShowUpDown = true;
            this.WpRad.Size = new System.Drawing.Size(80, 21);
            this.WpRad.TabIndex = 8;
            this.WpRad.Value = 20;
            this.WpRad.ValueChanged += new System.EventHandler(this.WpRad_ValueChanged);
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX4.Location = new System.Drawing.Point(11, 174);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(65, 20);
            this.labelX4.TabIndex = 7;
            this.labelX4.Text = "航点半径";
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX3.Location = new System.Drawing.Point(11, 122);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(65, 20);
            this.labelX3.TabIndex = 6;
            this.labelX3.Text = "高度警告";
            // 
            // WarnAlt
            // 
            this.WarnAlt.AllowEmptyState = false;
            // 
            // 
            // 
            this.WarnAlt.BackgroundStyle.Class = "DateTimeInputBackground";
            this.WarnAlt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.WarnAlt.ButtonFreeText.Checked = true;
            this.WarnAlt.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.WarnAlt.DisplayFormat = "0 m";
            this.WarnAlt.FreeTextEntryMode = true;
            this.WarnAlt.Location = new System.Drawing.Point(82, 121);
            this.WarnAlt.MaxValue = 10000000;
            this.WarnAlt.MinValue = -10000000;
            this.WarnAlt.Name = "WarnAlt";
            this.WarnAlt.ShowUpDown = true;
            this.WarnAlt.Size = new System.Drawing.Size(80, 21);
            this.WarnAlt.TabIndex = 5;
            this.WarnAlt.ValueChanged += new System.EventHandler(this.WarnAlt_ValueChanged);
            // 
            // DefaultAlt
            // 
            this.DefaultAlt.AllowEmptyState = false;
            // 
            // 
            // 
            this.DefaultAlt.BackgroundStyle.Class = "DateTimeInputBackground";
            this.DefaultAlt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.DefaultAlt.ButtonFreeText.Checked = true;
            this.DefaultAlt.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.DefaultAlt.DisplayFormat = "0 m";
            this.DefaultAlt.FreeTextEntryMode = true;
            this.DefaultAlt.FreeTextEntryToggleKey = System.Windows.Forms.Keys.Space;
            this.DefaultAlt.InputMouseWheelEnabled = false;
            this.DefaultAlt.Location = new System.Drawing.Point(82, 63);
            this.DefaultAlt.LockUpdateChecked = false;
            this.DefaultAlt.MaxValue = 10000000;
            this.DefaultAlt.MinValue = -10000000;
            this.DefaultAlt.MouseWheelValueChangeEnabled = false;
            this.DefaultAlt.Name = "DefaultAlt";
            this.DefaultAlt.ShowUpDown = true;
            this.DefaultAlt.Size = new System.Drawing.Size(80, 21);
            this.DefaultAlt.TabIndex = 4;
            this.DefaultAlt.Value = 200;
            this.DefaultAlt.ValueChanged += new System.EventHandler(this.DefaultAlt_ValueChanged);
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.Location = new System.Drawing.Point(11, 64);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(65, 20);
            this.labelX2.TabIndex = 3;
            this.labelX2.Text = "默认高度";
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.Location = new System.Drawing.Point(11, 38);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(65, 20);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "高度框架";
            // 
            // AltFrame
            // 
            this.AltFrame.DisplayMember = "Text";
            this.AltFrame.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.AltFrame.FormattingEnabled = true;
            this.AltFrame.ItemHeight = 15;
            this.AltFrame.Location = new System.Drawing.Point(82, 36);
            this.AltFrame.Name = "AltFrame";
            this.AltFrame.Size = new System.Drawing.Size(114, 21);
            this.AltFrame.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.AltFrame.TabIndex = 1;
            this.AltFrame.SelectedIndexChanged += new System.EventHandler(this.AltFrame_SelectedIndexChanged);
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList.Images.SetKeyName(0, "Up.png");
            this.ImageList.Images.SetKeyName(1, "Down.png");
            this.ImageList.Images.SetKeyName(2, "Delete.png");
            // 
            // CommandsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainPanel);
            this.Name = "CommandsPanel";
            this.Size = new System.Drawing.Size(1300, 278);
            this.Load += new System.EventHandler(this.CommandsPanel_Load);
            this.Leave += new System.EventHandler(this.CommandsPanel_Leave);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BaseAlt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WpRad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarnAlt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DefaultAlt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.PanelEx MainPanel;
        private DevComponents.DotNetBar.LabelX labelX3;
        private VPS.Controls.MyControls.MyIntegerInput WarnAlt;
        private VPS.Controls.MyControls.MyIntegerInput DefaultAlt;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx AltFrame;
        private DevComponents.DotNetBar.Controls.ComboBoxEx CoordSystem;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.LabelX labelX5;
        private VPS.Controls.MyControls.MyIntegerInput WpRad;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.CheckBoxX AutoWarnAlt;
        private DevComponents.DotNetBar.LabelX labelX10;
        private VPS.Controls.MyControls.MyIntegerInput BaseAlt;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl CommandDataList;
        private System.Windows.Forms.ImageList ImageList;
        private MyControls.MyPositionDisplay HomePositionDisplay;
    }
}
