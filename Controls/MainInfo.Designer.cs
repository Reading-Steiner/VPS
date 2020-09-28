namespace VPS.Controls
{
    partial class MainInfo
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
            this.MainInfoPanel = new DevComponents.DotNetBar.PanelEx();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.skinLine2 = new CCWin.SkinControl.SkinLine();
            this.label2 = new System.Windows.Forms.Label();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.LastAZ = new DevComponents.DotNetBar.LabelX();
            this.HomeAZ = new DevComponents.DotNetBar.LabelX();
            this.LastDistance = new DevComponents.DotNetBar.LabelX();
            this.HomeDistance = new DevComponents.DotNetBar.LabelX();
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.CoordSystem = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.WGS84Item = new DevComponents.Editors.ComboItem();
            this.UTMItem = new DevComponents.Editors.ComboItem();
            this.MGRSItem = new DevComponents.Editors.ComboItem();
            this.MGRSBox = new DevComponents.DotNetBar.PanelEx();
            this.labelX20 = new DevComponents.DotNetBar.LabelX();
            this.MGRS = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.UTMBox = new DevComponents.DotNetBar.PanelEx();
            this.CurrentZone = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.CurrentNorth = new DevComponents.Editors.DoubleInput();
            this.CurrentEast = new DevComponents.Editors.DoubleInput();
            this.labelX19 = new DevComponents.DotNetBar.LabelX();
            this.labelX18 = new DevComponents.DotNetBar.LabelX();
            this.labelX17 = new DevComponents.DotNetBar.LabelX();
            this.WGS84Box = new DevComponents.DotNetBar.PanelEx();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.CurrentLng = new DevComponents.Editors.DoubleInput();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.CurrentLat = new DevComponents.Editors.DoubleInput();
            this.CurrentAlt = new DevComponents.Editors.DoubleInput();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.skinLine1 = new CCWin.SkinControl.SkinLine();
            this.label1 = new System.Windows.Forms.Label();
            this.CameraInfo = new DevComponents.DotNetBar.PanelEx();
            this.HomeAlt = new DevComponents.Editors.DoubleInput();
            this.HomeLat = new DevComponents.Editors.DoubleInput();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.HomeLng = new DevComponents.Editors.DoubleInput();
            this.panelEx6 = new DevComponents.DotNetBar.PanelEx();
            this.skinLine7 = new CCWin.SkinControl.SkinLine();
            this.label6 = new System.Windows.Forms.Label();
            this.panelEx4 = new DevComponents.DotNetBar.PanelEx();
            this.TotalDistance = new DevComponents.DotNetBar.LabelX();
            this.labelX16 = new DevComponents.DotNetBar.LabelX();
            this.MainInfoPanel.SuspendLayout();
            this.panelEx3.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.MGRSBox.SuspendLayout();
            this.UTMBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentNorth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentEast)).BeginInit();
            this.WGS84Box.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentLng)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentLat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentAlt)).BeginInit();
            this.panelEx1.SuspendLayout();
            this.CameraInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HomeAlt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HomeLat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HomeLng)).BeginInit();
            this.panelEx6.SuspendLayout();
            this.panelEx4.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainInfoPanel
            // 
            this.MainInfoPanel.AutoSize = true;
            this.MainInfoPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.MainInfoPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.MainInfoPanel.Controls.Add(this.panelEx4);
            this.MainInfoPanel.Controls.Add(this.panelEx3);
            this.MainInfoPanel.Controls.Add(this.panelEx2);
            this.MainInfoPanel.Controls.Add(this.panelEx1);
            this.MainInfoPanel.Controls.Add(this.CameraInfo);
            this.MainInfoPanel.Controls.Add(this.panelEx6);
            this.MainInfoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainInfoPanel.Location = new System.Drawing.Point(0, 0);
            this.MainInfoPanel.Name = "MainInfoPanel";
            this.MainInfoPanel.Size = new System.Drawing.Size(310, 334);
            this.MainInfoPanel.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.MainInfoPanel.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.MainInfoPanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.MainInfoPanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.MainInfoPanel.Style.GradientAngle = 90;
            this.MainInfoPanel.TabIndex = 0;
            // 
            // panelEx3
            // 
            this.panelEx3.AutoSize = true;
            this.panelEx3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelEx3.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.skinLine2);
            this.panelEx3.Controls.Add(this.label2);
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx3.Location = new System.Drawing.Point(0, 286);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(310, 21);
            this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 38;
            // 
            // skinLine2
            // 
            this.skinLine2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.skinLine2.BackColor = System.Drawing.Color.Transparent;
            this.skinLine2.LineColor = System.Drawing.Color.Black;
            this.skinLine2.LineHeight = 1;
            this.skinLine2.Location = new System.Drawing.Point(59, 8);
            this.skinLine2.Name = "skinLine2";
            this.skinLine2.Size = new System.Drawing.Size(241, 10);
            this.skinLine2.TabIndex = 27;
            this.skinLine2.Text = "skinLine2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 26;
            this.label2.Text = "航线";
            // 
            // panelEx2
            // 
            this.panelEx2.AutoSize = true;
            this.panelEx2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.LastAZ);
            this.panelEx2.Controls.Add(this.HomeAZ);
            this.panelEx2.Controls.Add(this.LastDistance);
            this.panelEx2.Controls.Add(this.HomeDistance);
            this.panelEx2.Controls.Add(this.labelX11);
            this.panelEx2.Controls.Add(this.labelX10);
            this.panelEx2.Controls.Add(this.labelX9);
            this.panelEx2.Controls.Add(this.labelX8);
            this.panelEx2.Controls.Add(this.CoordSystem);
            this.panelEx2.Controls.Add(this.UTMBox);
            this.panelEx2.Controls.Add(this.WGS84Box);
            this.panelEx2.Controls.Add(this.MGRSBox);
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx2.Location = new System.Drawing.Point(0, 126);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(310, 160);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 37;
            // 
            // LastAZ
            // 
            this.LastAZ.AutoSize = true;
            // 
            // 
            // 
            this.LastAZ.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LastAZ.Location = new System.Drawing.Point(211, 139);
            this.LastAZ.Name = "LastAZ";
            this.LastAZ.Size = new System.Drawing.Size(13, 16);
            this.LastAZ.TabIndex = 52;
            this.LastAZ.Text = "0";
            // 
            // HomeAZ
            // 
            this.HomeAZ.AutoSize = true;
            // 
            // 
            // 
            this.HomeAZ.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.HomeAZ.Location = new System.Drawing.Point(211, 115);
            this.HomeAZ.Name = "HomeAZ";
            this.HomeAZ.Size = new System.Drawing.Size(13, 16);
            this.HomeAZ.TabIndex = 51;
            this.HomeAZ.Text = "0";
            // 
            // LastDistance
            // 
            this.LastDistance.AutoSize = true;
            // 
            // 
            // 
            this.LastDistance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LastDistance.Location = new System.Drawing.Point(112, 139);
            this.LastDistance.Name = "LastDistance";
            this.LastDistance.Size = new System.Drawing.Size(13, 16);
            this.LastDistance.TabIndex = 50;
            this.LastDistance.Text = "0";
            // 
            // HomeDistance
            // 
            this.HomeDistance.AutoSize = true;
            // 
            // 
            // 
            this.HomeDistance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.HomeDistance.Location = new System.Drawing.Point(112, 115);
            this.HomeDistance.Name = "HomeDistance";
            this.HomeDistance.Size = new System.Drawing.Size(13, 16);
            this.HomeDistance.TabIndex = 49;
            this.HomeDistance.Text = "0";
            // 
            // labelX11
            // 
            this.labelX11.AutoSize = true;
            // 
            // 
            // 
            this.labelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX11.Location = new System.Drawing.Point(223, 91);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(31, 18);
            this.labelX11.TabIndex = 48;
            this.labelX11.Text = "角度";
            // 
            // labelX10
            // 
            this.labelX10.AutoSize = true;
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Location = new System.Drawing.Point(33, 139);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(56, 18);
            this.labelX10.TabIndex = 47;
            this.labelX10.Text = "上一个点";
            // 
            // labelX9
            // 
            this.labelX9.AutoSize = true;
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Location = new System.Drawing.Point(33, 115);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(56, 18);
            this.labelX9.TabIndex = 46;
            this.labelX9.Text = "初始位置";
            // 
            // labelX8
            // 
            this.labelX8.AutoSize = true;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(125, 91);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(50, 18);
            this.labelX8.TabIndex = 45;
            this.labelX8.Text = "距离[m]";
            // 
            // CoordSystem
            // 
            this.CoordSystem.DisplayMember = "Text";
            this.CoordSystem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CoordSystem.FormattingEnabled = true;
            this.CoordSystem.ItemHeight = 15;
            this.CoordSystem.Items.AddRange(new object[] {
            this.WGS84Item,
            this.UTMItem,
            this.MGRSItem});
            this.CoordSystem.Location = new System.Drawing.Point(33, 6);
            this.CoordSystem.Name = "CoordSystem";
            this.CoordSystem.Size = new System.Drawing.Size(89, 21);
            this.CoordSystem.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CoordSystem.TabIndex = 43;
            this.CoordSystem.SelectedIndexChanged += new System.EventHandler(this.CoordSystem_SelectedIndexChanged);
            // 
            // WGS84Item
            // 
            this.WGS84Item.Text = "WGS84";
            // 
            // UTMItem
            // 
            this.UTMItem.Text = "UTM";
            // 
            // MGRSItem
            // 
            this.MGRSItem.Text = "comboItem1";
            // 
            // MGRSBox
            // 
            this.MGRSBox.CanvasColor = System.Drawing.SystemColors.Control;
            this.MGRSBox.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.MGRSBox.Controls.Add(this.labelX20);
            this.MGRSBox.Controls.Add(this.MGRS);
            this.MGRSBox.Location = new System.Drawing.Point(125, 3);
            this.MGRSBox.Name = "MGRSBox";
            this.MGRSBox.Size = new System.Drawing.Size(140, 82);
            this.MGRSBox.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.MGRSBox.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.MGRSBox.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.MGRSBox.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.MGRSBox.Style.GradientAngle = 90;
            this.MGRSBox.TabIndex = 55;
            this.MGRSBox.Visible = false;
            // 
            // labelX20
            // 
            this.labelX20.AutoSize = true;
            // 
            // 
            // 
            this.labelX20.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX20.Location = new System.Drawing.Point(7, 8);
            this.labelX20.Name = "labelX20";
            this.labelX20.Size = new System.Drawing.Size(31, 16);
            this.labelX20.TabIndex = 52;
            this.labelX20.Text = "MGRS";
            // 
            // MGRS
            // 
            // 
            // 
            // 
            this.MGRS.Border.Class = "TextBoxBorder";
            this.MGRS.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.MGRS.Location = new System.Drawing.Point(7, 30);
            this.MGRS.Name = "MGRS";
            this.MGRS.Size = new System.Drawing.Size(123, 21);
            this.MGRS.TabIndex = 51;
            // 
            // UTMBox
            // 
            this.UTMBox.CanvasColor = System.Drawing.SystemColors.Control;
            this.UTMBox.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.UTMBox.Controls.Add(this.CurrentZone);
            this.UTMBox.Controls.Add(this.CurrentNorth);
            this.UTMBox.Controls.Add(this.CurrentEast);
            this.UTMBox.Controls.Add(this.labelX19);
            this.UTMBox.Controls.Add(this.labelX18);
            this.UTMBox.Controls.Add(this.labelX17);
            this.UTMBox.Location = new System.Drawing.Point(125, 3);
            this.UTMBox.Name = "UTMBox";
            this.UTMBox.Size = new System.Drawing.Size(140, 82);
            this.UTMBox.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.UTMBox.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.UTMBox.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.UTMBox.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.UTMBox.Style.GradientAngle = 90;
            this.UTMBox.TabIndex = 54;
            this.UTMBox.Visible = false;
            // 
            // CurrentZone
            // 
            // 
            // 
            // 
            this.CurrentZone.Border.Class = "TextBoxBorder";
            this.CurrentZone.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.CurrentZone.Location = new System.Drawing.Point(50, 3);
            this.CurrentZone.Name = "CurrentZone";
            this.CurrentZone.Size = new System.Drawing.Size(79, 21);
            this.CurrentZone.TabIndex = 56;
            this.CurrentZone.Text = "0";
            this.CurrentZone.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // CurrentNorth
            // 
            this.CurrentNorth.AllowEmptyState = false;
            // 
            // 
            // 
            this.CurrentNorth.BackgroundStyle.Class = "DateTimeInputBackground";
            this.CurrentNorth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.CurrentNorth.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.CurrentNorth.Increment = 0.01D;
            this.CurrentNorth.IsInputReadOnly = true;
            this.CurrentNorth.Location = new System.Drawing.Point(50, 57);
            this.CurrentNorth.Name = "CurrentNorth";
            this.CurrentNorth.Size = new System.Drawing.Size(80, 21);
            this.CurrentNorth.TabIndex = 51;
            // 
            // CurrentEast
            // 
            this.CurrentEast.AllowEmptyState = false;
            // 
            // 
            // 
            this.CurrentEast.BackgroundStyle.Class = "DateTimeInputBackground";
            this.CurrentEast.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.CurrentEast.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.CurrentEast.Increment = 0.01D;
            this.CurrentEast.IsInputReadOnly = true;
            this.CurrentEast.Location = new System.Drawing.Point(50, 30);
            this.CurrentEast.Name = "CurrentEast";
            this.CurrentEast.Size = new System.Drawing.Size(80, 21);
            this.CurrentEast.TabIndex = 49;
            // 
            // labelX19
            // 
            this.labelX19.AutoSize = true;
            // 
            // 
            // 
            this.labelX19.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX19.Location = new System.Drawing.Point(7, 60);
            this.labelX19.Name = "labelX19";
            this.labelX19.Size = new System.Drawing.Size(37, 18);
            this.labelX19.TabIndex = 48;
            this.labelX19.Text = "北[m]";
            // 
            // labelX18
            // 
            this.labelX18.AutoSize = true;
            // 
            // 
            // 
            this.labelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX18.Location = new System.Drawing.Point(7, 33);
            this.labelX18.Name = "labelX18";
            this.labelX18.Size = new System.Drawing.Size(37, 18);
            this.labelX18.TabIndex = 47;
            this.labelX18.Text = "东[m]";
            // 
            // labelX17
            // 
            this.labelX17.AutoSize = true;
            // 
            // 
            // 
            this.labelX17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX17.Location = new System.Drawing.Point(7, 6);
            this.labelX17.Name = "labelX17";
            this.labelX17.Size = new System.Drawing.Size(19, 18);
            this.labelX17.TabIndex = 46;
            this.labelX17.Text = "区";
            // 
            // WGS84Box
            // 
            this.WGS84Box.CanvasColor = System.Drawing.SystemColors.Control;
            this.WGS84Box.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.WGS84Box.Controls.Add(this.labelX5);
            this.WGS84Box.Controls.Add(this.CurrentLng);
            this.WGS84Box.Controls.Add(this.labelX6);
            this.WGS84Box.Controls.Add(this.labelX4);
            this.WGS84Box.Controls.Add(this.CurrentLat);
            this.WGS84Box.Controls.Add(this.CurrentAlt);
            this.WGS84Box.Location = new System.Drawing.Point(125, 3);
            this.WGS84Box.Name = "WGS84Box";
            this.WGS84Box.Size = new System.Drawing.Size(140, 82);
            this.WGS84Box.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.WGS84Box.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.WGS84Box.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.WGS84Box.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.WGS84Box.Style.GradientAngle = 90;
            this.WGS84Box.TabIndex = 53;
            this.WGS84Box.Visible = false;
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(7, 33);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(31, 18);
            this.labelX5.TabIndex = 2;
            this.labelX5.Text = "经度";
            // 
            // CurrentLng
            // 
            this.CurrentLng.AllowEmptyState = false;
            // 
            // 
            // 
            this.CurrentLng.BackgroundStyle.Class = "DateTimeInputBackground";
            this.CurrentLng.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.CurrentLng.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.CurrentLng.Increment = 0.01D;
            this.CurrentLng.IsInputReadOnly = true;
            this.CurrentLng.Location = new System.Drawing.Point(50, 30);
            this.CurrentLng.Name = "CurrentLng";
            this.CurrentLng.Size = new System.Drawing.Size(80, 21);
            this.CurrentLng.TabIndex = 38;
            // 
            // labelX6
            // 
            this.labelX6.AutoSize = true;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(7, 6);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(31, 18);
            this.labelX6.TabIndex = 38;
            this.labelX6.Text = "纬度";
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(7, 60);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(31, 18);
            this.labelX4.TabIndex = 40;
            this.labelX4.Text = "高度";
            // 
            // CurrentLat
            // 
            this.CurrentLat.AllowEmptyState = false;
            // 
            // 
            // 
            this.CurrentLat.BackgroundStyle.Class = "DateTimeInputBackground";
            this.CurrentLat.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.CurrentLat.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.CurrentLat.Increment = 0.01D;
            this.CurrentLat.IsInputReadOnly = true;
            this.CurrentLat.Location = new System.Drawing.Point(50, 3);
            this.CurrentLat.Name = "CurrentLat";
            this.CurrentLat.Size = new System.Drawing.Size(80, 21);
            this.CurrentLat.TabIndex = 41;
            // 
            // CurrentAlt
            // 
            this.CurrentAlt.AllowEmptyState = false;
            // 
            // 
            // 
            this.CurrentAlt.BackgroundStyle.Class = "DateTimeInputBackground";
            this.CurrentAlt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.CurrentAlt.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.CurrentAlt.Increment = 0.01D;
            this.CurrentAlt.IsInputReadOnly = true;
            this.CurrentAlt.Location = new System.Drawing.Point(50, 57);
            this.CurrentAlt.Name = "CurrentAlt";
            this.CurrentAlt.Size = new System.Drawing.Size(80, 21);
            this.CurrentAlt.TabIndex = 42;
            // 
            // panelEx1
            // 
            this.panelEx1.AutoSize = true;
            this.panelEx1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.skinLine1);
            this.panelEx1.Controls.Add(this.label1);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(0, 105);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(310, 21);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 36;
            // 
            // skinLine1
            // 
            this.skinLine1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.skinLine1.BackColor = System.Drawing.Color.Transparent;
            this.skinLine1.LineColor = System.Drawing.Color.Black;
            this.skinLine1.LineHeight = 1;
            this.skinLine1.Location = new System.Drawing.Point(59, 8);
            this.skinLine1.Name = "skinLine1";
            this.skinLine1.Size = new System.Drawing.Size(241, 10);
            this.skinLine1.TabIndex = 27;
            this.skinLine1.Text = "skinLine1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 26;
            this.label1.Text = "当前位置";
            // 
            // CameraInfo
            // 
            this.CameraInfo.AutoSize = true;
            this.CameraInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CameraInfo.CanvasColor = System.Drawing.SystemColors.Control;
            this.CameraInfo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CameraInfo.Controls.Add(this.HomeAlt);
            this.CameraInfo.Controls.Add(this.HomeLat);
            this.CameraInfo.Controls.Add(this.labelX2);
            this.CameraInfo.Controls.Add(this.labelX1);
            this.CameraInfo.Controls.Add(this.labelX3);
            this.CameraInfo.Controls.Add(this.HomeLng);
            this.CameraInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.CameraInfo.Location = new System.Drawing.Point(0, 21);
            this.CameraInfo.Name = "CameraInfo";
            this.CameraInfo.Size = new System.Drawing.Size(310, 84);
            this.CameraInfo.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.CameraInfo.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.CameraInfo.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.CameraInfo.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.CameraInfo.Style.GradientAngle = 90;
            this.CameraInfo.TabIndex = 35;
            // 
            // HomeAlt
            // 
            this.HomeAlt.AllowEmptyState = false;
            // 
            // 
            // 
            this.HomeAlt.BackgroundStyle.Class = "DateTimeInputBackground";
            this.HomeAlt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.HomeAlt.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.HomeAlt.Increment = 0.01D;
            this.HomeAlt.IsInputReadOnly = true;
            this.HomeAlt.Location = new System.Drawing.Point(76, 60);
            this.HomeAlt.Name = "HomeAlt";
            this.HomeAlt.Size = new System.Drawing.Size(80, 21);
            this.HomeAlt.TabIndex = 42;
            // 
            // HomeLat
            // 
            this.HomeLat.AllowEmptyState = false;
            // 
            // 
            // 
            this.HomeLat.BackgroundStyle.Class = "DateTimeInputBackground";
            this.HomeLat.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.HomeLat.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.HomeLat.Increment = 0.01D;
            this.HomeLat.IsInputReadOnly = true;
            this.HomeLat.Location = new System.Drawing.Point(76, 6);
            this.HomeLat.Name = "HomeLat";
            this.HomeLat.Size = new System.Drawing.Size(80, 21);
            this.HomeLat.TabIndex = 41;
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(33, 63);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(31, 18);
            this.labelX2.TabIndex = 40;
            this.labelX2.Text = "高度";
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(33, 9);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(31, 18);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "纬度";
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(33, 36);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(31, 18);
            this.labelX3.TabIndex = 38;
            this.labelX3.Text = "经度";
            // 
            // HomeLng
            // 
            this.HomeLng.AllowEmptyState = false;
            // 
            // 
            // 
            this.HomeLng.BackgroundStyle.Class = "DateTimeInputBackground";
            this.HomeLng.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.HomeLng.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.HomeLng.Increment = 0.01D;
            this.HomeLng.IsInputReadOnly = true;
            this.HomeLng.Location = new System.Drawing.Point(76, 33);
            this.HomeLng.Name = "HomeLng";
            this.HomeLng.Size = new System.Drawing.Size(80, 21);
            this.HomeLng.TabIndex = 38;
            // 
            // panelEx6
            // 
            this.panelEx6.AutoSize = true;
            this.panelEx6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelEx6.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx6.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx6.Controls.Add(this.skinLine7);
            this.panelEx6.Controls.Add(this.label6);
            this.panelEx6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx6.Location = new System.Drawing.Point(0, 0);
            this.panelEx6.Name = "panelEx6";
            this.panelEx6.Size = new System.Drawing.Size(310, 21);
            this.panelEx6.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx6.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx6.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx6.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx6.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx6.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx6.Style.GradientAngle = 90;
            this.panelEx6.TabIndex = 34;
            // 
            // skinLine7
            // 
            this.skinLine7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.skinLine7.BackColor = System.Drawing.Color.Transparent;
            this.skinLine7.LineColor = System.Drawing.Color.Black;
            this.skinLine7.LineHeight = 1;
            this.skinLine7.Location = new System.Drawing.Point(59, 8);
            this.skinLine7.Name = "skinLine7";
            this.skinLine7.Size = new System.Drawing.Size(241, 10);
            this.skinLine7.TabIndex = 27;
            this.skinLine7.Text = "skinLine7";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 26;
            this.label6.Text = "初始位置";
            // 
            // panelEx4
            // 
            this.panelEx4.AutoSize = true;
            this.panelEx4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelEx4.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx4.Controls.Add(this.TotalDistance);
            this.panelEx4.Controls.Add(this.labelX16);
            this.panelEx4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx4.Location = new System.Drawing.Point(0, 307);
            this.panelEx4.Name = "panelEx4";
            this.panelEx4.Size = new System.Drawing.Size(310, 27);
            this.panelEx4.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx4.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.panelEx4.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.panelEx4.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.panelEx4.Style.GradientAngle = 90;
            this.panelEx4.TabIndex = 53;
            // 
            // TotalDistance
            // 
            this.TotalDistance.AutoSize = true;
            // 
            // 
            // 
            this.TotalDistance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TotalDistance.Location = new System.Drawing.Point(112, 6);
            this.TotalDistance.Name = "TotalDistance";
            this.TotalDistance.Size = new System.Drawing.Size(13, 16);
            this.TotalDistance.TabIndex = 55;
            this.TotalDistance.Text = "0";
            // 
            // labelX16
            // 
            this.labelX16.AutoSize = true;
            // 
            // 
            // 
            this.labelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX16.Location = new System.Drawing.Point(33, 6);
            this.labelX16.Name = "labelX16";
            this.labelX16.Size = new System.Drawing.Size(56, 18);
            this.labelX16.TabIndex = 54;
            this.labelX16.Text = "航线长度";
            // 
            // MainInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.MainInfoPanel);
            this.Name = "MainInfo";
            this.Size = new System.Drawing.Size(310, 334);
            this.MainInfoPanel.ResumeLayout(false);
            this.MainInfoPanel.PerformLayout();
            this.panelEx3.ResumeLayout(false);
            this.panelEx3.PerformLayout();
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            this.MGRSBox.ResumeLayout(false);
            this.MGRSBox.PerformLayout();
            this.UTMBox.ResumeLayout(false);
            this.UTMBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentNorth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentEast)).EndInit();
            this.WGS84Box.ResumeLayout(false);
            this.WGS84Box.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentLng)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentLat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentAlt)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.CameraInfo.ResumeLayout(false);
            this.CameraInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HomeAlt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HomeLat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HomeLng)).EndInit();
            this.panelEx6.ResumeLayout(false);
            this.panelEx6.PerformLayout();
            this.panelEx4.ResumeLayout(false);
            this.panelEx4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx MainInfoPanel;
        private DevComponents.DotNetBar.PanelEx panelEx6;
        private DevComponents.DotNetBar.PanelEx CameraInfo;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.Editors.DoubleInput HomeLng;
        private CCWin.SkinControl.SkinLine skinLine7;
        private DevComponents.Editors.DoubleInput HomeAlt;
        private DevComponents.Editors.DoubleInput HomeLat;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.Label label6;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.Editors.DoubleInput CurrentAlt;
        private DevComponents.Editors.DoubleInput CurrentLat;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.Editors.DoubleInput CurrentLng;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private CCWin.SkinControl.SkinLine skinLine1;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx CoordSystem;
        private DevComponents.DotNetBar.LabelX LastAZ;
        private DevComponents.DotNetBar.LabelX HomeAZ;
        private DevComponents.DotNetBar.LabelX LastDistance;
        private DevComponents.DotNetBar.LabelX HomeDistance;
        private DevComponents.DotNetBar.LabelX labelX11;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.Editors.ComboItem WGS84Item;
        private DevComponents.Editors.ComboItem UTMItem;
        private DevComponents.Editors.ComboItem MGRSItem;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        private CCWin.SkinControl.SkinLine skinLine2;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.PanelEx UTMBox;
        private DevComponents.Editors.DoubleInput CurrentNorth;
        private DevComponents.Editors.DoubleInput CurrentEast;
        private DevComponents.DotNetBar.LabelX labelX19;
        private DevComponents.DotNetBar.LabelX labelX18;
        private DevComponents.DotNetBar.LabelX labelX17;
        private DevComponents.DotNetBar.PanelEx WGS84Box;
        private DevComponents.DotNetBar.PanelEx MGRSBox;
        private DevComponents.DotNetBar.LabelX labelX20;
        private DevComponents.DotNetBar.Controls.TextBoxX MGRS;
        private DevComponents.DotNetBar.Controls.TextBoxX CurrentZone;
        private DevComponents.DotNetBar.PanelEx panelEx4;
        private DevComponents.DotNetBar.LabelX TotalDistance;
        private DevComponents.DotNetBar.LabelX labelX16;
    }
}
