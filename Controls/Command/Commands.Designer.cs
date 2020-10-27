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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommandsPanel));
            this.MainPanel = new DevComponents.DotNetBar.PanelEx();
            this.AutoWarnAlt = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.BaseAlt = new DevComponents.Editors.IntegerInput();
            this.HomeLng = new DevComponents.Editors.DoubleInput();
            this.HomeAlt = new DevComponents.Editors.DoubleInput();
            this.HomeLat = new DevComponents.Editors.DoubleInput();
            this.CoordSystem = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.WpRad = new DevComponents.Editors.IntegerInput();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.WarnAlt = new DevComponents.Editors.IntegerInput();
            this.DefaultAlt = new DevComponents.Editors.IntegerInput();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.AltFrame = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.CommandDataList = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Command = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.Lat = new DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn();
            this.Lon = new DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn();
            this.Zone = new DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn();
            this.East = new DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn();
            this.North = new DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn();
            this.MGRS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RelativeAlt = new DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn();
            this.AbsoluteAlt = new DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn();
            this.TerrainAlt = new DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn();
            this.Grad = new DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn();
            this.Angle = new DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn();
            this.Dist = new DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn();
            this.AZ = new DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn();
            this.Up = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.Down = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.Delete = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.Frame = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BaseAlt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HomeLng)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HomeAlt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HomeLat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WpRad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarnAlt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DefaultAlt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CommandDataList)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.MainPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.MainPanel.Controls.Add(this.AutoWarnAlt);
            this.MainPanel.Controls.Add(this.labelX10);
            this.MainPanel.Controls.Add(this.BaseAlt);
            this.MainPanel.Controls.Add(this.HomeLng);
            this.MainPanel.Controls.Add(this.HomeAlt);
            this.MainPanel.Controls.Add(this.HomeLat);
            this.MainPanel.Controls.Add(this.CoordSystem);
            this.MainPanel.Controls.Add(this.labelX9);
            this.MainPanel.Controls.Add(this.labelX8);
            this.MainPanel.Controls.Add(this.labelX7);
            this.MainPanel.Controls.Add(this.labelX6);
            this.MainPanel.Controls.Add(this.labelX5);
            this.MainPanel.Controls.Add(this.WpRad);
            this.MainPanel.Controls.Add(this.labelX4);
            this.MainPanel.Controls.Add(this.labelX3);
            this.MainPanel.Controls.Add(this.WarnAlt);
            this.MainPanel.Controls.Add(this.DefaultAlt);
            this.MainPanel.Controls.Add(this.labelX2);
            this.MainPanel.Controls.Add(this.labelX1);
            this.MainPanel.Controls.Add(this.AltFrame);
            this.MainPanel.Controls.Add(this.CommandDataList);
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
            this.AutoWarnAlt.Location = new System.Drawing.Point(21, 188);
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
            this.labelX10.Location = new System.Drawing.Point(21, 219);
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
            this.BaseAlt.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.BaseAlt.Location = new System.Drawing.Point(21, 240);
            this.BaseAlt.MaxValue = 10000000;
            this.BaseAlt.MinValue = -10000000;
            this.BaseAlt.Name = "BaseAlt";
            this.BaseAlt.ShowUpDown = true;
            this.BaseAlt.Size = new System.Drawing.Size(80, 21);
            this.BaseAlt.TabIndex = 22;
            this.BaseAlt.ValueChanged += new System.EventHandler(this.BaseAlt_ValueChanged);
            // 
            // HomeLng
            // 
            this.HomeLng.AllowEmptyState = false;
            this.HomeLng.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.HomeLng.BackgroundStyle.Class = "DateTimeInputBackground";
            this.HomeLng.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.HomeLng.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.HomeLng.DisplayFormat = "0.######";
            this.HomeLng.Increment = 1D;
            this.HomeLng.IsInputReadOnly = true;
            this.HomeLng.Location = new System.Drawing.Point(1200, 216);
            this.HomeLng.MaxValue = 400D;
            this.HomeLng.MinValue = -400D;
            this.HomeLng.Name = "HomeLng";
            this.HomeLng.Size = new System.Drawing.Size(80, 21);
            this.HomeLng.TabIndex = 21;
            this.HomeLng.ValueChanged += new System.EventHandler(this.HomeLng_ValueChanged);
            // 
            // HomeAlt
            // 
            this.HomeAlt.AllowEmptyState = false;
            this.HomeAlt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.HomeAlt.BackgroundStyle.Class = "DateTimeInputBackground";
            this.HomeAlt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.HomeAlt.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.HomeAlt.DisplayFormat = "0.######";
            this.HomeAlt.Increment = 1D;
            this.HomeAlt.IsInputReadOnly = true;
            this.HomeAlt.Location = new System.Drawing.Point(1200, 244);
            this.HomeAlt.MaxValue = 100000000D;
            this.HomeAlt.MinValue = -100000000D;
            this.HomeAlt.Name = "HomeAlt";
            this.HomeAlt.Size = new System.Drawing.Size(80, 21);
            this.HomeAlt.TabIndex = 20;
            this.HomeAlt.ValueChanged += new System.EventHandler(this.HomeAlt_ValueChanged);
            // 
            // HomeLat
            // 
            this.HomeLat.AllowEmptyState = false;
            this.HomeLat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.HomeLat.BackgroundStyle.Class = "DateTimeInputBackground";
            this.HomeLat.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.HomeLat.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.HomeLat.DisplayFormat = "0.######";
            this.HomeLat.Increment = 1D;
            this.HomeLat.IsInputReadOnly = true;
            this.HomeLat.Location = new System.Drawing.Point(1200, 188);
            this.HomeLat.MaxValue = 200D;
            this.HomeLat.MinValue = -200D;
            this.HomeLat.Name = "HomeLat";
            this.HomeLat.Size = new System.Drawing.Size(80, 21);
            this.HomeLat.TabIndex = 19;
            this.HomeLat.ValueChanged += new System.EventHandler(this.HomeLat_ValueChanged);
            // 
            // CoordSystem
            // 
            this.CoordSystem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CoordSystem.DisplayMember = "Text";
            this.CoordSystem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CoordSystem.FormattingEnabled = true;
            this.CoordSystem.ItemHeight = 15;
            this.CoordSystem.Location = new System.Drawing.Point(1164, 37);
            this.CoordSystem.Name = "CoordSystem";
            this.CoordSystem.Size = new System.Drawing.Size(114, 21);
            this.CoordSystem.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CoordSystem.TabIndex = 18;
            this.CoordSystem.SelectedIndexChanged += new System.EventHandler(this.CoordSystem_SelectedIndexChanged);
            // 
            // labelX9
            // 
            this.labelX9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX9.AutoSize = true;
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX9.Location = new System.Drawing.Point(1164, 15);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(65, 20);
            this.labelX9.TabIndex = 17;
            this.labelX9.Text = "坐标系统";
            // 
            // labelX8
            // 
            this.labelX8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX8.AutoSize = true;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX8.Location = new System.Drawing.Point(1159, 247);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(36, 20);
            this.labelX8.TabIndex = 15;
            this.labelX8.Text = "高度";
            // 
            // labelX7
            // 
            this.labelX7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX7.AutoSize = true;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX7.Location = new System.Drawing.Point(1159, 218);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(36, 20);
            this.labelX7.TabIndex = 14;
            this.labelX7.Text = "经度";
            // 
            // labelX6
            // 
            this.labelX6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX6.AutoSize = true;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX6.Location = new System.Drawing.Point(1159, 191);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(36, 20);
            this.labelX6.TabIndex = 13;
            this.labelX6.Text = "纬度";
            // 
            // labelX5
            // 
            this.labelX5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX5.AutoSize = true;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX5.Location = new System.Drawing.Point(1164, 164);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(65, 20);
            this.labelX5.TabIndex = 9;
            this.labelX5.Text = "初始位置";
            // 
            // WpRad
            // 
            this.WpRad.AllowEmptyState = false;
            this.WpRad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.WpRad.BackgroundStyle.Class = "DateTimeInputBackground";
            this.WpRad.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.WpRad.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.WpRad.Location = new System.Drawing.Point(1164, 103);
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
            this.labelX4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX4.Location = new System.Drawing.Point(1164, 81);
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
            this.labelX3.Location = new System.Drawing.Point(21, 140);
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
            this.WarnAlt.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.WarnAlt.Location = new System.Drawing.Point(21, 164);
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
            this.DefaultAlt.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.DefaultAlt.Location = new System.Drawing.Point(21, 103);
            this.DefaultAlt.MaxValue = 10000000;
            this.DefaultAlt.MinValue = -10000000;
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
            this.labelX2.Location = new System.Drawing.Point(21, 81);
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
            this.labelX1.Location = new System.Drawing.Point(21, 15);
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
            this.AltFrame.Location = new System.Drawing.Point(21, 37);
            this.AltFrame.Name = "AltFrame";
            this.AltFrame.Size = new System.Drawing.Size(114, 21);
            this.AltFrame.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.AltFrame.TabIndex = 1;
            this.AltFrame.SelectedIndexChanged += new System.EventHandler(this.AltFrame_SelectedIndexChanged);
            // 
            // CommandDataList
            // 
            this.CommandDataList.AllowUserToAddRows = false;
            this.CommandDataList.AllowUserToDeleteRows = false;
            this.CommandDataList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CommandDataList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CommandDataList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CommandDataList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CommandDataList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.CommandDataList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CommandDataList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Command,
            this.Lat,
            this.Lon,
            this.Zone,
            this.East,
            this.North,
            this.MGRS,
            this.RelativeAlt,
            this.AbsoluteAlt,
            this.TerrainAlt,
            this.Grad,
            this.Angle,
            this.Dist,
            this.AZ,
            this.Up,
            this.Down,
            this.Delete,
            this.Frame});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.CommandDataList.DefaultCellStyle = dataGridViewCellStyle2;
            this.CommandDataList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.CommandDataList.EnableHeadersVisualStyles = false;
            this.CommandDataList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.CommandDataList.HighlightSelectedColumnHeaders = false;
            this.CommandDataList.Location = new System.Drawing.Point(156, 3);
            this.CommandDataList.Name = "CommandDataList";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CommandDataList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.CommandDataList.RowTemplate.Height = 23;
            this.CommandDataList.Size = new System.Drawing.Size(984, 272);
            this.CommandDataList.TabIndex = 0;
            this.CommandDataList.GridColorChanged += new System.EventHandler(this.CommandDataList_GridColorChanged);
            this.CommandDataList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CommandDataList_CellContentClick);
            this.CommandDataList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.CommandDataList_CellPainting);
            this.CommandDataList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.CommandDataList_CellValueChanged);
            this.CommandDataList.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.CommandDataList_RowPrePaint);
            // 
            // Command
            // 
            this.Command.DisplayMember = "Text";
            this.Command.DropDownHeight = 106;
            this.Command.DropDownWidth = 121;
            this.Command.FillWeight = 166.0131F;
            this.Command.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Command.HeaderText = "命令";
            this.Command.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Command.IntegralHeight = false;
            this.Command.ItemHeight = 16;
            this.Command.Items.AddRange(new object[] {
            "WayPoint"});
            this.Command.Name = "Command";
            this.Command.ReadOnly = true;
            this.Command.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Command.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            // 
            // Lat
            // 
            // 
            // 
            // 
            this.Lat.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.Lat.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.Lat.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Lat.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText;
            this.Lat.DisplayFormat = "0.######";
            this.Lat.FillWeight = 124.5098F;
            this.Lat.HeaderText = "纬度";
            this.Lat.Increment = 1D;
            this.Lat.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.Lat.MaxValue = 200D;
            this.Lat.MinValue = -200D;
            this.Lat.Name = "Lat";
            this.Lat.ReadOnly = true;
            // 
            // Lon
            // 
            // 
            // 
            // 
            this.Lon.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.Lon.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.Lon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Lon.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText;
            this.Lon.DisplayFormat = "0.######";
            this.Lon.FillWeight = 124.5098F;
            this.Lon.HeaderText = "经度";
            this.Lon.Increment = 1D;
            this.Lon.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.Lon.MaxValue = 400D;
            this.Lon.MinValue = -400D;
            this.Lon.Name = "Lon";
            this.Lon.ReadOnly = true;
            // 
            // Zone
            // 
            // 
            // 
            // 
            this.Zone.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.Zone.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.Zone.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Zone.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText;
            this.Zone.FillWeight = 83.00654F;
            this.Zone.HeaderText = "区";
            this.Zone.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.Zone.MaxValue = 100;
            this.Zone.MinValue = 0;
            this.Zone.Name = "Zone";
            this.Zone.ReadOnly = true;
            this.Zone.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Zone.Visible = false;
            // 
            // East
            // 
            // 
            // 
            // 
            this.East.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.East.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.East.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.East.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText;
            this.East.DisplayFormat = "0.######";
            this.East.FillWeight = 124.5098F;
            this.East.HeaderText = "东";
            this.East.Increment = 1D;
            this.East.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.East.MaxValue = 10000000D;
            this.East.MinValue = -10000000D;
            this.East.Name = "East";
            this.East.ReadOnly = true;
            this.East.Visible = false;
            // 
            // North
            // 
            // 
            // 
            // 
            this.North.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.North.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.North.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.North.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText;
            this.North.DisplayFormat = "0.######";
            this.North.FillWeight = 124.5098F;
            this.North.HeaderText = "北";
            this.North.Increment = 1D;
            this.North.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.North.MaxValue = 10000000D;
            this.North.MinValue = -10000000D;
            this.North.Name = "North";
            this.North.ReadOnly = true;
            this.North.Visible = false;
            // 
            // MGRS
            // 
            this.MGRS.FillWeight = 166.0131F;
            this.MGRS.HeaderText = "MGRS";
            this.MGRS.Name = "MGRS";
            this.MGRS.ReadOnly = true;
            this.MGRS.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MGRS.Visible = false;
            // 
            // RelativeAlt
            // 
            // 
            // 
            // 
            this.RelativeAlt.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.RelativeAlt.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.RelativeAlt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.RelativeAlt.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText;
            this.RelativeAlt.FillWeight = 83.00654F;
            this.RelativeAlt.HeaderText = "相对高度";
            this.RelativeAlt.Increment = 1D;
            this.RelativeAlt.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.RelativeAlt.MaxValue = 100000000D;
            this.RelativeAlt.MinValue = -100000000D;
            this.RelativeAlt.Name = "RelativeAlt";
            this.RelativeAlt.ReadOnly = true;
            // 
            // AbsoluteAlt
            // 
            // 
            // 
            // 
            this.AbsoluteAlt.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.AbsoluteAlt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.AbsoluteAlt.HeaderText = "绝对高度";
            this.AbsoluteAlt.Name = "AbsoluteAlt";
            this.AbsoluteAlt.ReadOnly = true;
            this.AbsoluteAlt.Visible = false;
            // 
            // TerrainAlt
            // 
            // 
            // 
            // 
            this.TerrainAlt.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.TerrainAlt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TerrainAlt.HeaderText = "地面高度";
            this.TerrainAlt.Name = "TerrainAlt";
            this.TerrainAlt.ReadOnly = true;
            this.TerrainAlt.Visible = false;
            // 
            // Grad
            // 
            // 
            // 
            // 
            this.Grad.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.Grad.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.Grad.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Grad.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText;
            this.Grad.DisplayFormat = "0.######";
            this.Grad.FillWeight = 83.00654F;
            this.Grad.HeaderText = "坡度";
            this.Grad.Increment = 1D;
            this.Grad.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.Grad.MaxValue = 400D;
            this.Grad.MinValue = 0D;
            this.Grad.Name = "Grad";
            this.Grad.ReadOnly = true;
            // 
            // Angle
            // 
            // 
            // 
            // 
            this.Angle.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.Angle.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.Angle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Angle.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText;
            this.Angle.DisplayFormat = "0.######";
            this.Angle.FillWeight = 83.00654F;
            this.Angle.HeaderText = "角度";
            this.Angle.Increment = 1D;
            this.Angle.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.Angle.MaxValue = 400D;
            this.Angle.MinValue = 0D;
            this.Angle.Name = "Angle";
            this.Angle.ReadOnly = true;
            // 
            // Dist
            // 
            // 
            // 
            // 
            this.Dist.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.Dist.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.Dist.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Dist.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText;
            this.Dist.DisplayFormat = "0.######";
            this.Dist.FillWeight = 83.00654F;
            this.Dist.HeaderText = "距离";
            this.Dist.Increment = 1D;
            this.Dist.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.Dist.MaxValue = 10000000D;
            this.Dist.MinValue = 0D;
            this.Dist.Name = "Dist";
            this.Dist.ReadOnly = true;
            // 
            // AZ
            // 
            // 
            // 
            // 
            this.AZ.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.AZ.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.AZ.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.AZ.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText;
            this.AZ.DisplayFormat = "0.######";
            this.AZ.FillWeight = 83.00654F;
            this.AZ.HeaderText = "方位";
            this.AZ.Increment = 1D;
            this.AZ.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.AZ.MaxValue = 400D;
            this.AZ.MinValue = -400D;
            this.AZ.Name = "AZ";
            this.AZ.ReadOnly = true;
            // 
            // Up
            // 
            this.Up.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Up.HeaderText = "";
            this.Up.Image = ((System.Drawing.Image)(resources.GetObject("Up.Image")));
            this.Up.Name = "Up";
            this.Up.Text = null;
            this.Up.Width = 23;
            // 
            // Down
            // 
            this.Down.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Down.FillWeight = 388.8889F;
            this.Down.HeaderText = "";
            this.Down.Image = ((System.Drawing.Image)(resources.GetObject("Down.Image")));
            this.Down.Name = "Down";
            this.Down.Text = null;
            this.Down.Width = 23;
            // 
            // Delete
            // 
            this.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Delete.FillWeight = 83.00654F;
            this.Delete.HeaderText = "";
            this.Delete.Image = ((System.Drawing.Image)(resources.GetObject("Delete.Image")));
            this.Delete.ImageFixedSize = new System.Drawing.Size(23, 23);
            this.Delete.Name = "Delete";
            this.Delete.Text = null;
            this.Delete.Width = 23;
            // 
            // Frame
            // 
            this.Frame.HeaderText = "高度框架";
            this.Frame.Name = "Frame";
            this.Frame.ReadOnly = true;
            this.Frame.Visible = false;
            // 
            // CommandsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainPanel);
            this.Name = "CommandsPanel";
            this.Size = new System.Drawing.Size(1300, 278);
            this.Leave += new System.EventHandler(this.CommandsPanel_Leave);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BaseAlt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HomeLng)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HomeAlt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HomeLat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WpRad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarnAlt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DefaultAlt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CommandDataList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.PanelEx MainPanel;
        private DevComponents.DotNetBar.Controls.DataGridViewX CommandDataList;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.Editors.IntegerInput WarnAlt;
        private DevComponents.Editors.IntegerInput DefaultAlt;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx AltFrame;
        private DevComponents.Editors.DoubleInput HomeLng;
        private DevComponents.Editors.DoubleInput HomeAlt;
        private DevComponents.Editors.DoubleInput HomeLat;
        private DevComponents.DotNetBar.Controls.ComboBoxEx CoordSystem;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.Editors.IntegerInput WpRad;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.CheckBoxX AutoWarnAlt;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.Editors.IntegerInput BaseAlt;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn Command;
        private DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn Lat;
        private DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn Lon;
        private DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn Zone;
        private DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn East;
        private DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn North;
        private System.Windows.Forms.DataGridViewTextBoxColumn MGRS;
        private DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn RelativeAlt;
        private DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn AbsoluteAlt;
        private DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn TerrainAlt;
        private DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn Grad;
        private DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn Angle;
        private DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn Dist;
        private DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn AZ;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn Up;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn Down;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frame;
    }
}
