namespace VPS.Controls
{
    partial class GobalWPConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GobalWPConfig));
            this.returnButton1 = new VPS.Controls.ReturnButton();
            this.CameraTopHead = new VPS.Controls.BoardComboBox();
            this.boardLabel4 = new VPS.Controls.BoardLabel();
            this.boardLabel27 = new VPS.Controls.BoardLabel();
            this.boardLabel14 = new VPS.Controls.BoardLabel();
            this.boardLabel29 = new VPS.Controls.BoardLabel();
            this.boardLabel28 = new VPS.Controls.BoardLabel();
            this.boardLabel9 = new VPS.Controls.BoardLabel();
            this.Dy = new VPS.Controls.BoardEditableLabel();
            this.Bx = new VPS.Controls.BoardEditableLabel();
            this.boardLabel26 = new VPS.Controls.BoardLabel();
            this.SideOverlap = new VPS.Controls.BoardEditableLabel();
            this.GSD = new VPS.Controls.BoardEditableLabel();
            this.RelativeAltitude = new VPS.Controls.BoardEditableLabel();
            this.boardLabel10 = new VPS.Controls.BoardLabel();
            this.boardEditableLabel2 = new VPS.Controls.BoardEditableLabel();
            this.CourseOverlap = new VPS.Controls.BoardEditableLabel();
            this.PresetScale = new VPS.Controls.BoardComboBox();
            this.CameraFocus = new VPS.Controls.BoardEditableLabel();
            this.CMB_camera = new VPS.Controls.BoardComboBox();
            this.boardLabel25 = new VPS.Controls.BoardLabel();
            this.boardLabel24 = new VPS.Controls.BoardLabel();
            this.boardLabel23 = new VPS.Controls.BoardLabel();
            this.boardLabel22 = new VPS.Controls.BoardLabel();
            this.boardLabel21 = new VPS.Controls.BoardLabel();
            this.boardLabel20 = new VPS.Controls.BoardLabel();
            this.boardLabel19 = new VPS.Controls.BoardLabel();
            this.boardLabel18 = new VPS.Controls.BoardLabel();
            this.boardLabel12 = new VPS.Controls.BoardLabel();
            this.CameraSensorHeight = new VPS.Controls.BoardEditableLabel();
            this.CameraSensorWidth = new VPS.Controls.BoardEditableLabel();
            this.boardLabel15 = new VPS.Controls.BoardLabel();
            this.boardLabel16 = new VPS.Controls.BoardLabel();
            this.boardLabel17 = new VPS.Controls.BoardLabel();
            this.boardLabel11 = new VPS.Controls.BoardLabel();
            this.ImageHeight = new VPS.Controls.BoardEditableLabel();
            this.ImageWidth = new VPS.Controls.BoardEditableLabel();
            this.boardLabel8 = new VPS.Controls.BoardLabel();
            this.boardLabel7 = new VPS.Controls.BoardLabel();
            this.boardLabel6 = new VPS.Controls.BoardLabel();
            this.boardLabel5 = new VPS.Controls.BoardLabel();
            this.boardLabel3 = new VPS.Controls.BoardLabel();
            this.boardLabel2 = new VPS.Controls.BoardLabel();
            this.boardLabel1 = new VPS.Controls.BoardLabel();
            this.SuspendLayout();
            // 
            // returnButton1
            // 
            this.returnButton1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.returnButton1.BottomRederBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.returnButton1.CancelText = "取消";
            this.returnButton1.DownButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.returnButton1.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.returnButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.returnButton1.GlowButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.returnButton1.Location = new System.Drawing.Point(1, 524);
            this.returnButton1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.returnButton1.MouseButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.returnButton1.Name = "returnButton1";
            this.returnButton1.OKText = "确定";
            this.returnButton1.RederButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.returnButton1.Size = new System.Drawing.Size(630, 46);
            this.returnButton1.TabIndex = 43;
            this.returnButton1.TopRederBackColor = System.Drawing.Color.Transparent;
            // 
            // CameraTopHead
            // 
            this.CameraTopHead.AllowEdit = false;
            this.CameraTopHead.BoardColor = System.Drawing.SystemColors.ControlDarkDark;
            this.CameraTopHead.DataSource = ((System.Collections.Generic.List<string>)(resources.GetObject("CameraTopHead.DataSource")));
            this.CameraTopHead.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CameraTopHead.Location = new System.Drawing.Point(121, 127);
            this.CameraTopHead.Margin = new System.Windows.Forms.Padding(2);
            this.CameraTopHead.Name = "CameraTopHead";
            this.CameraTopHead.Pattern = "^.*$";
            this.CameraTopHead.RederWidth = 6;
            this.CameraTopHead.Size = new System.Drawing.Size(106, 29);
            this.CameraTopHead.TabIndex = 4;
            this.CameraTopHead.TextContent = "";
            // 
            // boardLabel4
            // 
            this.boardLabel4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.boardLabel4.BoardColor = System.Drawing.SystemColors.InactiveCaption;
            this.boardLabel4.Enabled = false;
            this.boardLabel4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.boardLabel4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.boardLabel4.Location = new System.Drawing.Point(27, 127);
            this.boardLabel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.boardLabel4.Name = "boardLabel4";
            this.boardLabel4.Pattern = "^\\S*$";
            this.boardLabel4.RederStyle = VPS.Controls.BoardLabel.Style.Inner;
            this.boardLabel4.RederWidth = 2;
            this.boardLabel4.Size = new System.Drawing.Size(74, 29);
            this.boardLabel4.TabIndex = 3;
            this.boardLabel4.TextContent = "安装";
            // 
            // boardLabel27
            // 
            this.boardLabel27.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.boardLabel27.BackColor = System.Drawing.SystemColors.Control;
            this.boardLabel27.BoardColor = System.Drawing.SystemColors.InactiveCaption;
            this.boardLabel27.Enabled = false;
            this.boardLabel27.Font = new System.Drawing.Font("Times New Roman", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boardLabel27.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.boardLabel27.Location = new System.Drawing.Point(585, 490);
            this.boardLabel27.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.boardLabel27.Name = "boardLabel27";
            this.boardLabel27.Pattern = "^\\S*$";
            this.boardLabel27.RederStyle = VPS.Controls.BoardLabel.Style.Inner;
            this.boardLabel27.RederWidth = 2;
            this.boardLabel27.Size = new System.Drawing.Size(25, 25);
            this.boardLabel27.TabIndex = 42;
            this.boardLabel27.TextContent = "m";
            // 
            // boardLabel14
            // 
            this.boardLabel14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.boardLabel14.BackColor = System.Drawing.SystemColors.Control;
            this.boardLabel14.BoardColor = System.Drawing.SystemColors.InactiveCaption;
            this.boardLabel14.Enabled = false;
            this.boardLabel14.Font = new System.Drawing.Font("Times New Roman", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boardLabel14.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.boardLabel14.Location = new System.Drawing.Point(585, 449);
            this.boardLabel14.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.boardLabel14.Name = "boardLabel14";
            this.boardLabel14.Pattern = "^\\S*$";
            this.boardLabel14.RederStyle = VPS.Controls.BoardLabel.Style.Inner;
            this.boardLabel14.RederWidth = 2;
            this.boardLabel14.Size = new System.Drawing.Size(25, 25);
            this.boardLabel14.TabIndex = 39;
            this.boardLabel14.TextContent = "m";
            // 
            // boardLabel29
            // 
            this.boardLabel29.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.boardLabel29.BackColor = System.Drawing.SystemColors.Control;
            this.boardLabel29.BoardColor = System.Drawing.SystemColors.InactiveCaption;
            this.boardLabel29.Enabled = false;
            this.boardLabel29.Font = new System.Drawing.Font("Times New Roman", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boardLabel29.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.boardLabel29.Location = new System.Drawing.Point(585, 364);
            this.boardLabel29.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.boardLabel29.Name = "boardLabel29";
            this.boardLabel29.Pattern = "^\\S*$";
            this.boardLabel29.RederStyle = VPS.Controls.BoardLabel.Style.Inner;
            this.boardLabel29.RederWidth = 2;
            this.boardLabel29.Size = new System.Drawing.Size(25, 25);
            this.boardLabel29.TabIndex = 33;
            this.boardLabel29.TextContent = "m";
            // 
            // boardLabel28
            // 
            this.boardLabel28.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.boardLabel28.BackColor = System.Drawing.SystemColors.Control;
            this.boardLabel28.BoardColor = System.Drawing.SystemColors.InactiveCaption;
            this.boardLabel28.Enabled = false;
            this.boardLabel28.Font = new System.Drawing.Font("Times New Roman", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boardLabel28.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.boardLabel28.Location = new System.Drawing.Point(276, 490);
            this.boardLabel28.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.boardLabel28.Name = "boardLabel28";
            this.boardLabel28.Pattern = "^\\S*$";
            this.boardLabel28.RederStyle = VPS.Controls.BoardLabel.Style.Inner;
            this.boardLabel28.RederWidth = 2;
            this.boardLabel28.Size = new System.Drawing.Size(25, 25);
            this.boardLabel28.TabIndex = 30;
            this.boardLabel28.TextContent = "m";
            // 
            // boardLabel9
            // 
            this.boardLabel9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.boardLabel9.BackColor = System.Drawing.SystemColors.Control;
            this.boardLabel9.BoardColor = System.Drawing.SystemColors.InactiveCaption;
            this.boardLabel9.Enabled = false;
            this.boardLabel9.Font = new System.Drawing.Font("Times New Roman", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boardLabel9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.boardLabel9.Location = new System.Drawing.Point(276, 408);
            this.boardLabel9.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.boardLabel9.Name = "boardLabel9";
            this.boardLabel9.Pattern = "^\\S*$";
            this.boardLabel9.RederStyle = VPS.Controls.BoardLabel.Style.Inner;
            this.boardLabel9.RederWidth = 2;
            this.boardLabel9.Size = new System.Drawing.Size(25, 25);
            this.boardLabel9.TabIndex = 24;
            this.boardLabel9.TextContent = "%";
            // 
            // Dy
            // 
            this.Dy.AllowEdit = true;
            this.Dy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Dy.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Dy.BoardColor = System.Drawing.SystemColors.InactiveCaption;
            this.Dy.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Dy.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Dy.Location = new System.Drawing.Point(486, 490);
            this.Dy.Name = "Dy";
            this.Dy.Pattern = "^\\d+[.]?\\d*$";
            this.Dy.RederStyle = VPS.Controls.BoardEditableLabel.Style.Inner;
            this.Dy.RederWidth = 2;
            this.Dy.Size = new System.Drawing.Size(103, 25);
            this.Dy.TabIndex = 41;
            this.Dy.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.Dy.TextContent = "96";
            this.Dy.TextPosition = new System.Drawing.Point(4, 6);
            // 
            // Bx
            // 
            this.Bx.AllowEdit = true;
            this.Bx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Bx.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Bx.BoardColor = System.Drawing.SystemColors.InactiveCaption;
            this.Bx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Bx.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Bx.Location = new System.Drawing.Point(486, 449);
            this.Bx.Name = "Bx";
            this.Bx.Pattern = "^\\d+[.]?\\d*$";
            this.Bx.RederStyle = VPS.Controls.BoardEditableLabel.Style.Inner;
            this.Bx.RederWidth = 2;
            this.Bx.Size = new System.Drawing.Size(103, 25);
            this.Bx.TabIndex = 38;
            this.Bx.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.Bx.TextContent = "32";
            this.Bx.TextPosition = new System.Drawing.Point(4, 6);
            // 
            // boardLabel26
            // 
            this.boardLabel26.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.boardLabel26.BackColor = System.Drawing.SystemColors.Control;
            this.boardLabel26.BoardColor = System.Drawing.SystemColors.InactiveCaption;
            this.boardLabel26.Enabled = false;
            this.boardLabel26.Font = new System.Drawing.Font("Times New Roman", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boardLabel26.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.boardLabel26.Location = new System.Drawing.Point(585, 408);
            this.boardLabel26.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.boardLabel26.Name = "boardLabel26";
            this.boardLabel26.Pattern = "^\\S*$";
            this.boardLabel26.RederStyle = VPS.Controls.BoardLabel.Style.Inner;
            this.boardLabel26.RederWidth = 2;
            this.boardLabel26.Size = new System.Drawing.Size(25, 25);
            this.boardLabel26.TabIndex = 36;
            this.boardLabel26.TextContent = "%";
            // 
            // SideOverlap
            // 
            this.SideOverlap.AllowEdit = true;
            this.SideOverlap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SideOverlap.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.SideOverlap.BoardColor = System.Drawing.SystemColors.InactiveCaption;
            this.SideOverlap.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SideOverlap.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.SideOverlap.Location = new System.Drawing.Point(486, 408);
            this.SideOverlap.Name = "SideOverlap";
            this.SideOverlap.Pattern = "^\\d+[.]?\\d*$";
            this.SideOverlap.RederStyle = VPS.Controls.BoardEditableLabel.Style.Inner;
            this.SideOverlap.RederWidth = 2;
            this.SideOverlap.Size = new System.Drawing.Size(103, 25);
            this.SideOverlap.TabIndex = 35;
            this.SideOverlap.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.SideOverlap.TextContent = "30";
            this.SideOverlap.TextPosition = new System.Drawing.Point(4, 6);
            // 
            // GSD
            // 
            this.GSD.AllowEdit = true;
            this.GSD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.GSD.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.GSD.BoardColor = System.Drawing.SystemColors.InactiveCaption;
            this.GSD.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GSD.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.GSD.Location = new System.Drawing.Point(486, 364);
            this.GSD.Name = "GSD";
            this.GSD.Pattern = "^\\d+[.]?\\d*$";
            this.GSD.RederStyle = VPS.Controls.BoardEditableLabel.Style.Inner;
            this.GSD.RederWidth = 2;
            this.GSD.Size = new System.Drawing.Size(103, 25);
            this.GSD.TabIndex = 32;
            this.GSD.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.GSD.TextContent = "0.040";
            this.GSD.TextPosition = new System.Drawing.Point(4, 6);
            // 
            // RelativeAltitude
            // 
            this.RelativeAltitude.AllowEdit = true;
            this.RelativeAltitude.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RelativeAltitude.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.RelativeAltitude.BoardColor = System.Drawing.SystemColors.InactiveCaption;
            this.RelativeAltitude.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RelativeAltitude.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.RelativeAltitude.Location = new System.Drawing.Point(177, 490);
            this.RelativeAltitude.Name = "RelativeAltitude";
            this.RelativeAltitude.Pattern = "^\\d+$";
            this.RelativeAltitude.RederStyle = VPS.Controls.BoardEditableLabel.Style.Inner;
            this.RelativeAltitude.RederWidth = 2;
            this.RelativeAltitude.Size = new System.Drawing.Size(103, 25);
            this.RelativeAltitude.TabIndex = 29;
            this.RelativeAltitude.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.RelativeAltitude.TextContent = "100";
            this.RelativeAltitude.TextPosition = new System.Drawing.Point(4, 6);
            // 
            // boardLabel10
            // 
            this.boardLabel10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.boardLabel10.BackColor = System.Drawing.SystemColors.Control;
            this.boardLabel10.BoardColor = System.Drawing.SystemColors.InactiveCaption;
            this.boardLabel10.Enabled = false;
            this.boardLabel10.Font = new System.Drawing.Font("Times New Roman", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boardLabel10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.boardLabel10.Location = new System.Drawing.Point(276, 449);
            this.boardLabel10.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.boardLabel10.Name = "boardLabel10";
            this.boardLabel10.Pattern = "^\\S*$";
            this.boardLabel10.RederStyle = VPS.Controls.BoardLabel.Style.Inner;
            this.boardLabel10.RederWidth = 2;
            this.boardLabel10.Size = new System.Drawing.Size(25, 25);
            this.boardLabel10.TabIndex = 27;
            this.boardLabel10.TextContent = "m";
            // 
            // boardEditableLabel2
            // 
            this.boardEditableLabel2.AllowEdit = true;
            this.boardEditableLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.boardEditableLabel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.boardEditableLabel2.BoardColor = System.Drawing.SystemColors.InactiveCaption;
            this.boardEditableLabel2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.boardEditableLabel2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.boardEditableLabel2.Location = new System.Drawing.Point(177, 449);
            this.boardEditableLabel2.Name = "boardEditableLabel2";
            this.boardEditableLabel2.Pattern = "^\\d+[.]?\\d*$";
            this.boardEditableLabel2.RederStyle = VPS.Controls.BoardEditableLabel.Style.Inner;
            this.boardEditableLabel2.RederWidth = 2;
            this.boardEditableLabel2.Size = new System.Drawing.Size(103, 25);
            this.boardEditableLabel2.TabIndex = 26;
            this.boardEditableLabel2.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.boardEditableLabel2.TextContent = "20";
            this.boardEditableLabel2.TextPosition = new System.Drawing.Point(4, 6);
            // 
            // CourseOverlap
            // 
            this.CourseOverlap.AllowEdit = true;
            this.CourseOverlap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CourseOverlap.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CourseOverlap.BoardColor = System.Drawing.SystemColors.InactiveCaption;
            this.CourseOverlap.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CourseOverlap.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CourseOverlap.Location = new System.Drawing.Point(177, 408);
            this.CourseOverlap.Name = "CourseOverlap";
            this.CourseOverlap.Pattern = "^\\d+[.]?\\d*$";
            this.CourseOverlap.RederStyle = VPS.Controls.BoardEditableLabel.Style.Inner;
            this.CourseOverlap.RederWidth = 2;
            this.CourseOverlap.Size = new System.Drawing.Size(103, 25);
            this.CourseOverlap.TabIndex = 23;
            this.CourseOverlap.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.CourseOverlap.TextContent = "60";
            this.CourseOverlap.TextPosition = new System.Drawing.Point(4, 6);
            // 
            // PresetScale
            // 
            this.PresetScale.AllowEdit = true;
            this.PresetScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PresetScale.BoardColor = System.Drawing.SystemColors.ControlDarkDark;
            this.PresetScale.DataSource = ((System.Collections.Generic.List<string>)(resources.GetObject("PresetScale.DataSource")));
            this.PresetScale.Location = new System.Drawing.Point(177, 359);
            this.PresetScale.Name = "PresetScale";
            this.PresetScale.Pattern = "^\\d+[:]\\d*$";
            this.PresetScale.RederWidth = 6;
            this.PresetScale.Size = new System.Drawing.Size(124, 30);
            this.PresetScale.TabIndex = 21;
            this.PresetScale.TextContent = "1:500";
            // 
            // CameraFocus
            // 
            this.CameraFocus.AllowEdit = true;
            this.CameraFocus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CameraFocus.BoardColor = System.Drawing.SystemColors.ControlDarkDark;
            this.CameraFocus.Location = new System.Drawing.Point(445, 164);
            this.CameraFocus.Name = "CameraFocus";
            this.CameraFocus.Pattern = "^\\d+[.]?\\d*$";
            this.CameraFocus.RederStyle = VPS.Controls.BoardEditableLabel.Style.Inner;
            this.CameraFocus.RederWidth = 5;
            this.CameraFocus.Size = new System.Drawing.Size(119, 23);
            this.CameraFocus.TabIndex = 18;
            this.CameraFocus.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.CameraFocus.TextContent = "0";
            this.CameraFocus.TextPosition = new System.Drawing.Point(5, 5);
            // 
            // CMB_camera
            // 
            this.CMB_camera.AllowEdit = false;
            this.CMB_camera.BoardColor = System.Drawing.SystemColors.ControlDarkDark;
            this.CMB_camera.DataSource = ((System.Collections.Generic.List<string>)(resources.GetObject("CMB_camera.DataSource")));
            this.CMB_camera.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CMB_camera.Location = new System.Drawing.Point(121, 83);
            this.CMB_camera.Margin = new System.Windows.Forms.Padding(2);
            this.CMB_camera.Name = "CMB_camera";
            this.CMB_camera.Pattern = "^.*$";
            this.CMB_camera.RederWidth = 6;
            this.CMB_camera.Size = new System.Drawing.Size(226, 29);
            this.CMB_camera.TabIndex = 2;
            this.CMB_camera.TextContent = "";
            // 
            // boardLabel25
            // 
            this.boardLabel25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.boardLabel25.BackColor = System.Drawing.SystemColors.Control;
            this.boardLabel25.BoardColor = System.Drawing.SystemColors.InactiveCaption;
            this.boardLabel25.Enabled = false;
            this.boardLabel25.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.boardLabel25.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.boardLabel25.Location = new System.Drawing.Point(334, 485);
            this.boardLabel25.Name = "boardLabel25";
            this.boardLabel25.Pattern = "^\\S*$";
            this.boardLabel25.RederStyle = VPS.Controls.BoardLabel.Style.Inner;
            this.boardLabel25.RederWidth = 2;
            this.boardLabel25.Size = new System.Drawing.Size(119, 30);
            this.boardLabel25.TabIndex = 40;
            this.boardLabel25.TextContent = "航线间距Dy";
            // 
            // boardLabel24
            // 
            this.boardLabel24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.boardLabel24.BackColor = System.Drawing.SystemColors.Control;
            this.boardLabel24.BoardColor = System.Drawing.SystemColors.InactiveCaption;
            this.boardLabel24.Enabled = false;
            this.boardLabel24.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.boardLabel24.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.boardLabel24.Location = new System.Drawing.Point(334, 444);
            this.boardLabel24.Name = "boardLabel24";
            this.boardLabel24.Pattern = "^\\S*$";
            this.boardLabel24.RederStyle = VPS.Controls.BoardLabel.Style.Inner;
            this.boardLabel24.RederWidth = 2;
            this.boardLabel24.Size = new System.Drawing.Size(119, 30);
            this.boardLabel24.TabIndex = 37;
            this.boardLabel24.TextContent = "摄影基线Bx";
            // 
            // boardLabel23
            // 
            this.boardLabel23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.boardLabel23.BackColor = System.Drawing.SystemColors.Control;
            this.boardLabel23.BoardColor = System.Drawing.SystemColors.InactiveCaption;
            this.boardLabel23.Enabled = false;
            this.boardLabel23.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.boardLabel23.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.boardLabel23.Location = new System.Drawing.Point(334, 403);
            this.boardLabel23.Name = "boardLabel23";
            this.boardLabel23.Pattern = "^\\S*$";
            this.boardLabel23.RederStyle = VPS.Controls.BoardLabel.Style.Inner;
            this.boardLabel23.RederWidth = 2;
            this.boardLabel23.Size = new System.Drawing.Size(119, 30);
            this.boardLabel23.TabIndex = 34;
            this.boardLabel23.TextContent = "旁向重叠度";
            // 
            // boardLabel22
            // 
            this.boardLabel22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.boardLabel22.BackColor = System.Drawing.SystemColors.Control;
            this.boardLabel22.BoardColor = System.Drawing.SystemColors.InactiveCaption;
            this.boardLabel22.Enabled = false;
            this.boardLabel22.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.boardLabel22.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.boardLabel22.Location = new System.Drawing.Point(334, 359);
            this.boardLabel22.Name = "boardLabel22";
            this.boardLabel22.Pattern = "^\\S*$";
            this.boardLabel22.RederStyle = VPS.Controls.BoardLabel.Style.Inner;
            this.boardLabel22.RederWidth = 2;
            this.boardLabel22.Size = new System.Drawing.Size(119, 30);
            this.boardLabel22.TabIndex = 31;
            this.boardLabel22.TextContent = "地面采样间隔";
            // 
            // boardLabel21
            // 
            this.boardLabel21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.boardLabel21.BackColor = System.Drawing.SystemColors.Control;
            this.boardLabel21.BoardColor = System.Drawing.SystemColors.InactiveCaption;
            this.boardLabel21.Enabled = false;
            this.boardLabel21.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.boardLabel21.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.boardLabel21.Location = new System.Drawing.Point(27, 485);
            this.boardLabel21.Name = "boardLabel21";
            this.boardLabel21.Pattern = "^\\S*$";
            this.boardLabel21.RederStyle = VPS.Controls.BoardLabel.Style.Inner;
            this.boardLabel21.RederWidth = 2;
            this.boardLabel21.Size = new System.Drawing.Size(119, 30);
            this.boardLabel21.TabIndex = 28;
            this.boardLabel21.TextContent = "相对航高";
            // 
            // boardLabel20
            // 
            this.boardLabel20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.boardLabel20.BackColor = System.Drawing.SystemColors.Control;
            this.boardLabel20.BoardColor = System.Drawing.SystemColors.InactiveCaption;
            this.boardLabel20.Enabled = false;
            this.boardLabel20.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.boardLabel20.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.boardLabel20.Location = new System.Drawing.Point(27, 444);
            this.boardLabel20.Name = "boardLabel20";
            this.boardLabel20.Pattern = "^\\S*$";
            this.boardLabel20.RederStyle = VPS.Controls.BoardLabel.Style.Inner;
            this.boardLabel20.RederWidth = 2;
            this.boardLabel20.Size = new System.Drawing.Size(119, 30);
            this.boardLabel20.TabIndex = 25;
            this.boardLabel20.TextContent = "航摄基准";
            // 
            // boardLabel19
            // 
            this.boardLabel19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.boardLabel19.BackColor = System.Drawing.SystemColors.Control;
            this.boardLabel19.BoardColor = System.Drawing.SystemColors.InactiveCaption;
            this.boardLabel19.Enabled = false;
            this.boardLabel19.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.boardLabel19.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.boardLabel19.Location = new System.Drawing.Point(27, 403);
            this.boardLabel19.Name = "boardLabel19";
            this.boardLabel19.Pattern = "^\\S*$";
            this.boardLabel19.RederStyle = VPS.Controls.BoardLabel.Style.Inner;
            this.boardLabel19.RederWidth = 2;
            this.boardLabel19.Size = new System.Drawing.Size(119, 30);
            this.boardLabel19.TabIndex = 22;
            this.boardLabel19.TextContent = "航向重叠度";
            // 
            // boardLabel18
            // 
            this.boardLabel18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.boardLabel18.BackColor = System.Drawing.SystemColors.Control;
            this.boardLabel18.BoardColor = System.Drawing.SystemColors.InactiveCaption;
            this.boardLabel18.Enabled = false;
            this.boardLabel18.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.boardLabel18.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.boardLabel18.Location = new System.Drawing.Point(27, 359);
            this.boardLabel18.Name = "boardLabel18";
            this.boardLabel18.Pattern = "^\\S*$";
            this.boardLabel18.RederStyle = VPS.Controls.BoardLabel.Style.Inner;
            this.boardLabel18.RederWidth = 2;
            this.boardLabel18.Size = new System.Drawing.Size(119, 30);
            this.boardLabel18.TabIndex = 20;
            this.boardLabel18.TextContent = "成图比例尺";
            // 
            // boardLabel12
            // 
            this.boardLabel12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boardLabel12.BackColor = System.Drawing.SystemColors.Control;
            this.boardLabel12.BoardColor = System.Drawing.SystemColors.InactiveCaption;
            this.boardLabel12.Enabled = false;
            this.boardLabel12.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.boardLabel12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.boardLabel12.Location = new System.Drawing.Point(323, 286);
            this.boardLabel12.Name = "boardLabel12";
            this.boardLabel12.Pattern = "^\\S*$";
            this.boardLabel12.RederStyle = VPS.Controls.BoardLabel.Style.Inner;
            this.boardLabel12.RederWidth = 2;
            this.boardLabel12.Size = new System.Drawing.Size(24, 25);
            this.boardLabel12.TabIndex = 15;
            this.boardLabel12.TextContent = "×";
            // 
            // CameraSensorHeight
            // 
            this.CameraSensorHeight.AllowEdit = true;
            this.CameraSensorHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CameraSensorHeight.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CameraSensorHeight.BoardColor = System.Drawing.SystemColors.InactiveCaption;
            this.CameraSensorHeight.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CameraSensorHeight.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CameraSensorHeight.Location = new System.Drawing.Point(353, 286);
            this.CameraSensorHeight.Name = "CameraSensorHeight";
            this.CameraSensorHeight.Pattern = "^\\d+[.]?\\d*$";
            this.CameraSensorHeight.RederStyle = VPS.Controls.BoardEditableLabel.Style.Inner;
            this.CameraSensorHeight.RederWidth = 2;
            this.CameraSensorHeight.Size = new System.Drawing.Size(61, 25);
            this.CameraSensorHeight.TabIndex = 16;
            this.CameraSensorHeight.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.CameraSensorHeight.TextContent = "24";
            this.CameraSensorHeight.TextPosition = new System.Drawing.Point(4, 6);
            // 
            // CameraSensorWidth
            // 
            this.CameraSensorWidth.AllowEdit = true;
            this.CameraSensorWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CameraSensorWidth.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CameraSensorWidth.BoardColor = System.Drawing.SystemColors.InactiveCaption;
            this.CameraSensorWidth.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CameraSensorWidth.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CameraSensorWidth.Location = new System.Drawing.Point(255, 286);
            this.CameraSensorWidth.Name = "CameraSensorWidth";
            this.CameraSensorWidth.Pattern = "^\\d+[.]?\\d*$";
            this.CameraSensorWidth.RederStyle = VPS.Controls.BoardEditableLabel.Style.Inner;
            this.CameraSensorWidth.RederWidth = 2;
            this.CameraSensorWidth.Size = new System.Drawing.Size(62, 25);
            this.CameraSensorWidth.TabIndex = 14;
            this.CameraSensorWidth.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.CameraSensorWidth.TextContent = "35.9";
            this.CameraSensorWidth.TextPosition = new System.Drawing.Point(4, 6);
            // 
            // boardLabel15
            // 
            this.boardLabel15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boardLabel15.BackColor = System.Drawing.SystemColors.Control;
            this.boardLabel15.BoardColor = System.Drawing.SystemColors.InactiveCaption;
            this.boardLabel15.Enabled = false;
            this.boardLabel15.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.boardLabel15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.boardLabel15.Location = new System.Drawing.Point(372, 255);
            this.boardLabel15.Name = "boardLabel15";
            this.boardLabel15.Pattern = "^\\S*$";
            this.boardLabel15.RederStyle = VPS.Controls.BoardLabel.Style.Inner;
            this.boardLabel15.RederWidth = 2;
            this.boardLabel15.Size = new System.Drawing.Size(24, 25);
            this.boardLabel15.TabIndex = 13;
            this.boardLabel15.TextContent = "宽";
            // 
            // boardLabel16
            // 
            this.boardLabel16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boardLabel16.BackColor = System.Drawing.SystemColors.Control;
            this.boardLabel16.BoardColor = System.Drawing.SystemColors.InactiveCaption;
            this.boardLabel16.Enabled = false;
            this.boardLabel16.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.boardLabel16.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.boardLabel16.Location = new System.Drawing.Point(275, 255);
            this.boardLabel16.Name = "boardLabel16";
            this.boardLabel16.Pattern = "^\\S*$";
            this.boardLabel16.RederStyle = VPS.Controls.BoardLabel.Style.Inner;
            this.boardLabel16.RederWidth = 2;
            this.boardLabel16.Size = new System.Drawing.Size(24, 25);
            this.boardLabel16.TabIndex = 12;
            this.boardLabel16.TextContent = "长";
            // 
            // boardLabel17
            // 
            this.boardLabel17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boardLabel17.BackColor = System.Drawing.SystemColors.Control;
            this.boardLabel17.BoardColor = System.Drawing.SystemColors.InactiveCaption;
            this.boardLabel17.Enabled = false;
            this.boardLabel17.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.boardLabel17.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.boardLabel17.Location = new System.Drawing.Point(255, 224);
            this.boardLabel17.Name = "boardLabel17";
            this.boardLabel17.Pattern = "^\\S*$";
            this.boardLabel17.RederStyle = VPS.Controls.BoardLabel.Style.Inner;
            this.boardLabel17.RederWidth = 2;
            this.boardLabel17.Size = new System.Drawing.Size(159, 25);
            this.boardLabel17.TabIndex = 11;
            this.boardLabel17.TextContent = "相机传感器尺寸[mm]";
            // 
            // boardLabel11
            // 
            this.boardLabel11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boardLabel11.BackColor = System.Drawing.SystemColors.Control;
            this.boardLabel11.BoardColor = System.Drawing.SystemColors.InactiveCaption;
            this.boardLabel11.Enabled = false;
            this.boardLabel11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.boardLabel11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.boardLabel11.Location = new System.Drawing.Point(323, 193);
            this.boardLabel11.Name = "boardLabel11";
            this.boardLabel11.Pattern = "^\\S*$";
            this.boardLabel11.RederStyle = VPS.Controls.BoardLabel.Style.Inner;
            this.boardLabel11.RederWidth = 2;
            this.boardLabel11.Size = new System.Drawing.Size(24, 25);
            this.boardLabel11.TabIndex = 9;
            this.boardLabel11.TextContent = "×";
            // 
            // ImageHeight
            // 
            this.ImageHeight.AllowEdit = true;
            this.ImageHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ImageHeight.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ImageHeight.BoardColor = System.Drawing.SystemColors.InactiveCaption;
            this.ImageHeight.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ImageHeight.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ImageHeight.Location = new System.Drawing.Point(353, 193);
            this.ImageHeight.Name = "ImageHeight";
            this.ImageHeight.Pattern = "^\\d+[.]?\\d*$";
            this.ImageHeight.RederStyle = VPS.Controls.BoardEditableLabel.Style.Inner;
            this.ImageHeight.RederWidth = 2;
            this.ImageHeight.Size = new System.Drawing.Size(61, 25);
            this.ImageHeight.TabIndex = 10;
            this.ImageHeight.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.ImageHeight.TextContent = "4000";
            this.ImageHeight.TextPosition = new System.Drawing.Point(4, 6);
            // 
            // ImageWidth
            // 
            this.ImageWidth.AllowEdit = true;
            this.ImageWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ImageWidth.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ImageWidth.BoardColor = System.Drawing.SystemColors.InactiveCaption;
            this.ImageWidth.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ImageWidth.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ImageWidth.Location = new System.Drawing.Point(255, 193);
            this.ImageWidth.Name = "ImageWidth";
            this.ImageWidth.Pattern = "^\\d+[.]?\\d*$";
            this.ImageWidth.RederStyle = VPS.Controls.BoardEditableLabel.Style.Inner;
            this.ImageWidth.RederWidth = 2;
            this.ImageWidth.Size = new System.Drawing.Size(62, 25);
            this.ImageWidth.TabIndex = 8;
            this.ImageWidth.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.ImageWidth.TextContent = "6000";
            this.ImageWidth.TextPosition = new System.Drawing.Point(4, 6);
            // 
            // boardLabel8
            // 
            this.boardLabel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boardLabel8.BackColor = System.Drawing.SystemColors.Control;
            this.boardLabel8.BoardColor = System.Drawing.SystemColors.InactiveCaption;
            this.boardLabel8.Enabled = false;
            this.boardLabel8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.boardLabel8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.boardLabel8.Location = new System.Drawing.Point(372, 162);
            this.boardLabel8.Name = "boardLabel8";
            this.boardLabel8.Pattern = "^\\S*$";
            this.boardLabel8.RederStyle = VPS.Controls.BoardLabel.Style.Inner;
            this.boardLabel8.RederWidth = 2;
            this.boardLabel8.Size = new System.Drawing.Size(24, 25);
            this.boardLabel8.TabIndex = 7;
            this.boardLabel8.TextContent = "宽";
            // 
            // boardLabel7
            // 
            this.boardLabel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boardLabel7.BackColor = System.Drawing.SystemColors.Control;
            this.boardLabel7.BoardColor = System.Drawing.SystemColors.InactiveCaption;
            this.boardLabel7.Enabled = false;
            this.boardLabel7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.boardLabel7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.boardLabel7.Location = new System.Drawing.Point(275, 162);
            this.boardLabel7.Name = "boardLabel7";
            this.boardLabel7.Pattern = "^\\S*$";
            this.boardLabel7.RederStyle = VPS.Controls.BoardLabel.Style.Inner;
            this.boardLabel7.RederWidth = 2;
            this.boardLabel7.Size = new System.Drawing.Size(24, 25);
            this.boardLabel7.TabIndex = 6;
            this.boardLabel7.TextContent = "长";
            // 
            // boardLabel6
            // 
            this.boardLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boardLabel6.BackColor = System.Drawing.SystemColors.Control;
            this.boardLabel6.BoardColor = System.Drawing.SystemColors.InactiveCaption;
            this.boardLabel6.Enabled = false;
            this.boardLabel6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.boardLabel6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.boardLabel6.Location = new System.Drawing.Point(445, 131);
            this.boardLabel6.Name = "boardLabel6";
            this.boardLabel6.Pattern = "^\\S*$";
            this.boardLabel6.RederStyle = VPS.Controls.BoardLabel.Style.Inner;
            this.boardLabel6.RederWidth = 2;
            this.boardLabel6.Size = new System.Drawing.Size(119, 25);
            this.boardLabel6.TabIndex = 17;
            this.boardLabel6.TextContent = "镜头焦距[mm]";
            // 
            // boardLabel5
            // 
            this.boardLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boardLabel5.BackColor = System.Drawing.SystemColors.Control;
            this.boardLabel5.BoardColor = System.Drawing.SystemColors.InactiveCaption;
            this.boardLabel5.Enabled = false;
            this.boardLabel5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.boardLabel5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.boardLabel5.Location = new System.Drawing.Point(255, 131);
            this.boardLabel5.Name = "boardLabel5";
            this.boardLabel5.Pattern = "^\\S*$";
            this.boardLabel5.RederStyle = VPS.Controls.BoardLabel.Style.Inner;
            this.boardLabel5.RederWidth = 2;
            this.boardLabel5.Size = new System.Drawing.Size(159, 25);
            this.boardLabel5.TabIndex = 5;
            this.boardLabel5.TextContent = "图像最高分辨率[pix]";
            // 
            // boardLabel3
            // 
            this.boardLabel3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.boardLabel3.BoardColor = System.Drawing.SystemColors.InactiveCaption;
            this.boardLabel3.Enabled = false;
            this.boardLabel3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.boardLabel3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.boardLabel3.Location = new System.Drawing.Point(27, 83);
            this.boardLabel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.boardLabel3.Name = "boardLabel3";
            this.boardLabel3.Pattern = "^\\S*$";
            this.boardLabel3.RederStyle = VPS.Controls.BoardLabel.Style.Inner;
            this.boardLabel3.RederWidth = 2;
            this.boardLabel3.Size = new System.Drawing.Size(74, 29);
            this.boardLabel3.TabIndex = 1;
            this.boardLabel3.TextContent = "型号";
            // 
            // boardLabel2
            // 
            this.boardLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.boardLabel2.BackColor = System.Drawing.SystemColors.Control;
            this.boardLabel2.BoardColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(180)))), ((int)(((byte)(128)))));
            this.boardLabel2.Enabled = false;
            this.boardLabel2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.boardLabel2.ForeColor = System.Drawing.Color.Coral;
            this.boardLabel2.Location = new System.Drawing.Point(15, 311);
            this.boardLabel2.Margin = new System.Windows.Forms.Padding(5);
            this.boardLabel2.Name = "boardLabel2";
            this.boardLabel2.Pattern = "^\\S*$";
            this.boardLabel2.RederStyle = VPS.Controls.BoardLabel.Style.Outside;
            this.boardLabel2.RederWidth = 5;
            this.boardLabel2.Size = new System.Drawing.Size(197, 38);
            this.boardLabel2.TabIndex = 19;
            this.boardLabel2.TextContent = "重叠度参数";
            // 
            // boardLabel1
            // 
            this.boardLabel1.BackColor = System.Drawing.SystemColors.Control;
            this.boardLabel1.BoardColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(180)))), ((int)(((byte)(128)))));
            this.boardLabel1.Enabled = false;
            this.boardLabel1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.boardLabel1.ForeColor = System.Drawing.Color.Coral;
            this.boardLabel1.Location = new System.Drawing.Point(15, 34);
            this.boardLabel1.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.boardLabel1.Name = "boardLabel1";
            this.boardLabel1.Pattern = "^\\S*$";
            this.boardLabel1.RederStyle = VPS.Controls.BoardLabel.Style.Outside;
            this.boardLabel1.RederWidth = 5;
            this.boardLabel1.Size = new System.Drawing.Size(197, 38);
            this.boardLabel1.TabIndex = 0;
            this.boardLabel1.TextContent = "相机型号参数";
            // 
            // GobalWPConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CanResize = false;
            this.CaptionBackColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(632, 570);
            this.Controls.Add(this.returnButton1);
            this.Controls.Add(this.CameraTopHead);
            this.Controls.Add(this.boardLabel4);
            this.Controls.Add(this.boardLabel27);
            this.Controls.Add(this.boardLabel14);
            this.Controls.Add(this.boardLabel29);
            this.Controls.Add(this.boardLabel28);
            this.Controls.Add(this.boardLabel9);
            this.Controls.Add(this.Dy);
            this.Controls.Add(this.Bx);
            this.Controls.Add(this.boardLabel26);
            this.Controls.Add(this.SideOverlap);
            this.Controls.Add(this.GSD);
            this.Controls.Add(this.RelativeAltitude);
            this.Controls.Add(this.boardLabel10);
            this.Controls.Add(this.boardEditableLabel2);
            this.Controls.Add(this.CourseOverlap);
            this.Controls.Add(this.PresetScale);
            this.Controls.Add(this.CameraFocus);
            this.Controls.Add(this.CMB_camera);
            this.Controls.Add(this.boardLabel25);
            this.Controls.Add(this.boardLabel24);
            this.Controls.Add(this.boardLabel23);
            this.Controls.Add(this.boardLabel22);
            this.Controls.Add(this.boardLabel21);
            this.Controls.Add(this.boardLabel20);
            this.Controls.Add(this.boardLabel19);
            this.Controls.Add(this.boardLabel18);
            this.Controls.Add(this.boardLabel12);
            this.Controls.Add(this.CameraSensorHeight);
            this.Controls.Add(this.CameraSensorWidth);
            this.Controls.Add(this.boardLabel15);
            this.Controls.Add(this.boardLabel16);
            this.Controls.Add(this.boardLabel17);
            this.Controls.Add(this.boardLabel11);
            this.Controls.Add(this.ImageHeight);
            this.Controls.Add(this.ImageWidth);
            this.Controls.Add(this.boardLabel8);
            this.Controls.Add(this.boardLabel7);
            this.Controls.Add(this.boardLabel6);
            this.Controls.Add(this.boardLabel5);
            this.Controls.Add(this.boardLabel3);
            this.Controls.Add(this.boardLabel2);
            this.Controls.Add(this.boardLabel1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.EffectCaption = CCWin.TitleType.Title;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GobalWPConfig";
            this.Radius = 12;
            this.ShowDrawIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GobalWPConfig";
            this.TitleCenter = true;
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.BoardLabel boardLabel1;
        private Controls.BoardLabel boardLabel2;
        private Controls.BoardLabel boardLabel3;
        private Controls.BoardLabel boardLabel5;
        private Controls.BoardLabel boardLabel6;
        private Controls.BoardLabel boardLabel7;
        private Controls.BoardLabel boardLabel8;
        private Controls.BoardEditableLabel ImageWidth;
        private Controls.BoardEditableLabel ImageHeight;
        private Controls.BoardLabel boardLabel11;
        private Controls.BoardLabel boardLabel12;
        private Controls.BoardEditableLabel CameraSensorHeight;
        private Controls.BoardEditableLabel CameraSensorWidth;
        private Controls.BoardLabel boardLabel15;
        private Controls.BoardLabel boardLabel16;
        private Controls.BoardLabel boardLabel17;
        private Controls.BoardLabel boardLabel18;
        private Controls.BoardLabel boardLabel19;
        private Controls.BoardLabel boardLabel20;
        private Controls.BoardLabel boardLabel21;
        private Controls.BoardLabel boardLabel22;
        private Controls.BoardLabel boardLabel23;
        private Controls.BoardLabel boardLabel24;
        private Controls.BoardLabel boardLabel25;
        private Controls.BoardComboBox CMB_camera;
        private Controls.BoardEditableLabel CameraFocus;
        private Controls.BoardComboBox PresetScale;
        private Controls.BoardEditableLabel CourseOverlap;
        private Controls.BoardLabel boardLabel10;
        private Controls.BoardEditableLabel boardEditableLabel2;
        private Controls.BoardEditableLabel RelativeAltitude;
        private Controls.BoardEditableLabel GSD;
        private Controls.BoardLabel boardLabel26;
        private Controls.BoardEditableLabel SideOverlap;
        private Controls.BoardEditableLabel Bx;
        private Controls.BoardEditableLabel Dy;
        private Controls.BoardLabel boardLabel9;
        private Controls.BoardLabel boardLabel28;
        private Controls.BoardLabel boardLabel29;
        private Controls.BoardLabel boardLabel14;
        private Controls.BoardLabel boardLabel27;
        private Controls.BoardLabel boardLabel4;
        private Controls.BoardComboBox CameraTopHead;
        private Controls.ReturnButton returnButton1;
    }
}