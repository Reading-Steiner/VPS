using System.Windows.Forms;
using System;

namespace VPS.Controls
{
    partial class LayerReader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LayerReader));
            this.TopLabel = new System.Windows.Forms.Label();
            this.RightLabel = new System.Windows.Forms.Label();
            this.BottomLabel = new System.Windows.Forms.Label();
            this.LeftLabel = new System.Windows.Forms.Label();
            this.LayerPrevView = new CCWin.SkinControl.SkinPictureBox();
            this.Transparent = new DotSpatial.Symbology.Forms.ColorButton();
            this.skinGroupBox1 = new CCWin.SkinControl.SkinGroupBox();
            this.ImageTileBox = new CCWin.SkinControl.SkinCheckBox();
            this.TransparentLabel = new VPS.Controls.BoardLabel();
            this.skinGroupBox2 = new CCWin.SkinControl.SkinGroupBox();
            this.AltitudeLabel = new VPS.Controls.BoardLabel();
            this.LatitudeLabel = new VPS.Controls.BoardLabel();
            this.Longitude = new VPS.Controls.BoardEditableLabel();
            this.LongitudeLabel = new VPS.Controls.BoardLabel();
            this.Latitude = new VPS.Controls.BoardEditableLabel();
            this.Altitude = new VPS.Controls.BoardEditableLabel();
            this.skinGroupBox3 = new CCWin.SkinControl.SkinGroupBox();
            this.boardEditableLabel1 = new VPS.Controls.BoardEditableLabel();
            this.boardLabel2 = new VPS.Controls.BoardLabel();
            this.MapScale = new VPS.Controls.BoardEditableLabel();
            this.boardEditableLabel2 = new VPS.Controls.BoardEditableLabel();
            this.boardLabel1 = new VPS.Controls.BoardLabel();
            this.ScaleLabel = new VPS.Controls.BoardLabel();
            this.RetButton = new VPS.Controls.ReturnButton();
            this.FilePath = new VPS.Controls.BoardEditableLabel();
            this.FileOpen = new VPS.Controls.GradualButton();
            ((System.ComponentModel.ISupportInitialize)(this.LayerPrevView)).BeginInit();
            this.skinGroupBox1.SuspendLayout();
            this.skinGroupBox2.SuspendLayout();
            this.skinGroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopLabel
            // 
            resources.ApplyResources(this.TopLabel, "TopLabel");
            this.TopLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TopLabel.Name = "TopLabel";
            // 
            // RightLabel
            // 
            resources.ApplyResources(this.RightLabel, "RightLabel");
            this.RightLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.RightLabel.Name = "RightLabel";
            // 
            // BottomLabel
            // 
            resources.ApplyResources(this.BottomLabel, "BottomLabel");
            this.BottomLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BottomLabel.Name = "BottomLabel";
            // 
            // LeftLabel
            // 
            resources.ApplyResources(this.LeftLabel, "LeftLabel");
            this.LeftLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LeftLabel.Name = "LeftLabel";
            // 
            // LayerPrevView
            // 
            resources.ApplyResources(this.LayerPrevView, "LayerPrevView");
            this.LayerPrevView.BackColor = System.Drawing.Color.Transparent;
            this.LayerPrevView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LayerPrevView.Name = "LayerPrevView";
            this.LayerPrevView.TabStop = false;
            // 
            // Transparent
            // 
            resources.ApplyResources(this.Transparent, "Transparent");
            this.Transparent.BevelRadius = 0;
            this.Transparent.Color = System.Drawing.Color.Black;
            this.Transparent.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Transparent.LaunchDialogOnClick = true;
            this.Transparent.Name = "Transparent";
            this.Transparent.RoundingRadius = 0;
            this.Transparent.ColorChanged += new System.EventHandler(this.Transparent_ColorChanged);
            // 
            // skinGroupBox1
            // 
            resources.ApplyResources(this.skinGroupBox1, "skinGroupBox1");
            this.skinGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.skinGroupBox1.Controls.Add(this.ImageTileBox);
            this.skinGroupBox1.Controls.Add(this.TransparentLabel);
            this.skinGroupBox1.Controls.Add(this.Transparent);
            this.skinGroupBox1.ForeColor = System.Drawing.Color.Black;
            this.skinGroupBox1.Name = "skinGroupBox1";
            this.skinGroupBox1.Radius = 8;
            this.skinGroupBox1.RectBackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox1.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinGroupBox1.TabStop = false;
            this.skinGroupBox1.TitleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.skinGroupBox1.TitleRadius = 6;
            this.skinGroupBox1.TitleRectBackColor = System.Drawing.SystemColors.Control;
            this.skinGroupBox1.TitleRoundStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // ImageTileBox
            // 
            resources.ApplyResources(this.ImageTileBox, "ImageTileBox");
            this.ImageTileBox.BackColor = System.Drawing.Color.Transparent;
            this.ImageTileBox.BaseColor = System.Drawing.Color.Black;
            this.ImageTileBox.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.ImageTileBox.DownBack = null;
            this.ImageTileBox.ForeColor = System.Drawing.Color.Black;
            this.ImageTileBox.LightEffectBack = System.Drawing.Color.Transparent;
            this.ImageTileBox.MouseBack = null;
            this.ImageTileBox.Name = "ImageTileBox";
            this.ImageTileBox.NormlBack = null;
            this.ImageTileBox.SelectedDownBack = null;
            this.ImageTileBox.SelectedMouseBack = null;
            this.ImageTileBox.SelectedNormlBack = null;
            this.ImageTileBox.UseVisualStyleBackColor = false;
            // 
            // TransparentLabel
            // 
            resources.ApplyResources(this.TransparentLabel, "TransparentLabel");
            this.TransparentLabel.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.TransparentLabel.BackColor = System.Drawing.SystemColors.Control;
            this.TransparentLabel.BoardColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.TransparentLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TransparentLabel.Name = "TransparentLabel";
            this.TransparentLabel.Pattern = "^\\S*$";
            this.TransparentLabel.RederStyle = VPS.Controls.BoardLabel.Style.Inner;
            this.TransparentLabel.RederWidth = 1;
            this.TransparentLabel.TextContent = "透明色";
            // 
            // skinGroupBox2
            // 
            resources.ApplyResources(this.skinGroupBox2, "skinGroupBox2");
            this.skinGroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.skinGroupBox2.Controls.Add(this.AltitudeLabel);
            this.skinGroupBox2.Controls.Add(this.LatitudeLabel);
            this.skinGroupBox2.Controls.Add(this.Longitude);
            this.skinGroupBox2.Controls.Add(this.LongitudeLabel);
            this.skinGroupBox2.Controls.Add(this.Latitude);
            this.skinGroupBox2.Controls.Add(this.Altitude);
            this.skinGroupBox2.ForeColor = System.Drawing.Color.Black;
            this.skinGroupBox2.Name = "skinGroupBox2";
            this.skinGroupBox2.RectBackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox2.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinGroupBox2.TabStop = false;
            this.skinGroupBox2.TitleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.skinGroupBox2.TitleRectBackColor = System.Drawing.SystemColors.Control;
            this.skinGroupBox2.TitleRoundStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // AltitudeLabel
            // 
            resources.ApplyResources(this.AltitudeLabel, "AltitudeLabel");
            this.AltitudeLabel.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.AltitudeLabel.BackColor = System.Drawing.SystemColors.Control;
            this.AltitudeLabel.BoardColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.AltitudeLabel.ForeColor = System.Drawing.Color.Black;
            this.AltitudeLabel.Name = "AltitudeLabel";
            this.AltitudeLabel.Pattern = "^\\S*$";
            this.AltitudeLabel.RederStyle = VPS.Controls.BoardLabel.Style.Inner;
            this.AltitudeLabel.RederWidth = 1;
            this.AltitudeLabel.TextContent = "地面高程";
            // 
            // LatitudeLabel
            // 
            resources.ApplyResources(this.LatitudeLabel, "LatitudeLabel");
            this.LatitudeLabel.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.LatitudeLabel.BackColor = System.Drawing.SystemColors.Control;
            this.LatitudeLabel.BoardColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.LatitudeLabel.ForeColor = System.Drawing.Color.Black;
            this.LatitudeLabel.Name = "LatitudeLabel";
            this.LatitudeLabel.Pattern = "^\\S*$";
            this.LatitudeLabel.RederStyle = VPS.Controls.BoardLabel.Style.Inner;
            this.LatitudeLabel.RederWidth = 1;
            this.LatitudeLabel.TextContent = "纬度";
            // 
            // Longitude
            // 
            resources.ApplyResources(this.Longitude, "Longitude");
            this.Longitude.AllowEdit = true;
            this.Longitude.BackColor = System.Drawing.SystemColors.Control;
            this.Longitude.BoardColor = System.Drawing.SystemColors.InactiveCaption;
            this.Longitude.Name = "Longitude";
            this.Longitude.Pattern = "^[+-]?\\d+[.]?\\d*$";
            this.Longitude.RederStyle = VPS.Controls.BoardEditableLabel.Style.Inner;
            this.Longitude.RederWidth = 2;
            this.Longitude.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.Longitude.TextContent = "0";
            this.Longitude.TextPosition = new System.Drawing.Point(3, 5);
            // 
            // LongitudeLabel
            // 
            resources.ApplyResources(this.LongitudeLabel, "LongitudeLabel");
            this.LongitudeLabel.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.LongitudeLabel.BackColor = System.Drawing.SystemColors.Control;
            this.LongitudeLabel.BoardColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.LongitudeLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LongitudeLabel.Name = "LongitudeLabel";
            this.LongitudeLabel.Pattern = "^\\S*$";
            this.LongitudeLabel.RederStyle = VPS.Controls.BoardLabel.Style.Inner;
            this.LongitudeLabel.RederWidth = 1;
            this.LongitudeLabel.TextContent = "经度";
            // 
            // Latitude
            // 
            resources.ApplyResources(this.Latitude, "Latitude");
            this.Latitude.AllowEdit = true;
            this.Latitude.BackColor = System.Drawing.SystemColors.Control;
            this.Latitude.BoardColor = System.Drawing.SystemColors.InactiveCaption;
            this.Latitude.Name = "Latitude";
            this.Latitude.Pattern = "^[+-]?\\d+[.]?\\d*$";
            this.Latitude.RederStyle = VPS.Controls.BoardEditableLabel.Style.Inner;
            this.Latitude.RederWidth = 2;
            this.Latitude.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.Latitude.TextContent = "0";
            this.Latitude.TextPosition = new System.Drawing.Point(3, 5);
            // 
            // Altitude
            // 
            resources.ApplyResources(this.Altitude, "Altitude");
            this.Altitude.AllowEdit = true;
            this.Altitude.BackColor = System.Drawing.SystemColors.Control;
            this.Altitude.BoardColor = System.Drawing.SystemColors.InactiveCaption;
            this.Altitude.Name = "Altitude";
            this.Altitude.Pattern = "^[+-]?\\d+[.]?\\d*$";
            this.Altitude.RederStyle = VPS.Controls.BoardEditableLabel.Style.Inner;
            this.Altitude.RederWidth = 2;
            this.Altitude.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.Altitude.TextContent = "0";
            this.Altitude.TextPosition = new System.Drawing.Point(3, 5);
            // 
            // skinGroupBox3
            // 
            resources.ApplyResources(this.skinGroupBox3, "skinGroupBox3");
            this.skinGroupBox3.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.skinGroupBox3.Controls.Add(this.boardEditableLabel1);
            this.skinGroupBox3.Controls.Add(this.boardLabel2);
            this.skinGroupBox3.Controls.Add(this.MapScale);
            this.skinGroupBox3.Controls.Add(this.boardEditableLabel2);
            this.skinGroupBox3.Controls.Add(this.boardLabel1);
            this.skinGroupBox3.Controls.Add(this.ScaleLabel);
            this.skinGroupBox3.ForeColor = System.Drawing.Color.Black;
            this.skinGroupBox3.Name = "skinGroupBox3";
            this.skinGroupBox3.RectBackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox3.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinGroupBox3.TabStop = false;
            this.skinGroupBox3.TitleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.skinGroupBox3.TitleRectBackColor = System.Drawing.SystemColors.Control;
            this.skinGroupBox3.TitleRoundStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // boardEditableLabel1
            // 
            resources.ApplyResources(this.boardEditableLabel1, "boardEditableLabel1");
            this.boardEditableLabel1.AllowEdit = true;
            this.boardEditableLabel1.BackColor = System.Drawing.SystemColors.Control;
            this.boardEditableLabel1.BoardColor = System.Drawing.SystemColors.InactiveCaption;
            this.boardEditableLabel1.Name = "boardEditableLabel1";
            this.boardEditableLabel1.Pattern = "^[+-]?\\d+[.]?\\d*$";
            this.boardEditableLabel1.RederStyle = VPS.Controls.BoardEditableLabel.Style.Inner;
            this.boardEditableLabel1.RederWidth = 2;
            this.boardEditableLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.boardEditableLabel1.TextContent = "0";
            this.boardEditableLabel1.TextPosition = new System.Drawing.Point(3, 5);
            // 
            // boardLabel2
            // 
            resources.ApplyResources(this.boardLabel2, "boardLabel2");
            this.boardLabel2.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.boardLabel2.BackColor = System.Drawing.SystemColors.Control;
            this.boardLabel2.BoardColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.boardLabel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.boardLabel2.Name = "boardLabel2";
            this.boardLabel2.Pattern = "^\\S*$";
            this.boardLabel2.RederStyle = VPS.Controls.BoardLabel.Style.Inner;
            this.boardLabel2.RederWidth = 1;
            this.boardLabel2.TextContent = "×";
            // 
            // MapScale
            // 
            resources.ApplyResources(this.MapScale, "MapScale");
            this.MapScale.AllowEdit = true;
            this.MapScale.BackColor = System.Drawing.SystemColors.Control;
            this.MapScale.BoardColor = System.Drawing.SystemColors.InactiveCaption;
            this.MapScale.Name = "MapScale";
            this.MapScale.Pattern = "^(\\d+[.]?\\d*)\\s*[:：]\\s*(\\d*[.]?\\d*)$";
            this.MapScale.RederStyle = VPS.Controls.BoardEditableLabel.Style.Inner;
            this.MapScale.RederWidth = 2;
            this.MapScale.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.MapScale.TextContent = "1：200";
            this.MapScale.TextPosition = new System.Drawing.Point(3, 5);
            // 
            // boardEditableLabel2
            // 
            resources.ApplyResources(this.boardEditableLabel2, "boardEditableLabel2");
            this.boardEditableLabel2.AllowEdit = true;
            this.boardEditableLabel2.BackColor = System.Drawing.SystemColors.Control;
            this.boardEditableLabel2.BoardColor = System.Drawing.SystemColors.InactiveCaption;
            this.boardEditableLabel2.Name = "boardEditableLabel2";
            this.boardEditableLabel2.Pattern = "^[+-]?\\d+[.]?\\d*$";
            this.boardEditableLabel2.RederStyle = VPS.Controls.BoardEditableLabel.Style.Inner;
            this.boardEditableLabel2.RederWidth = 2;
            this.boardEditableLabel2.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.boardEditableLabel2.TextContent = "0";
            this.boardEditableLabel2.TextPosition = new System.Drawing.Point(3, 5);
            // 
            // boardLabel1
            // 
            resources.ApplyResources(this.boardLabel1, "boardLabel1");
            this.boardLabel1.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.boardLabel1.BackColor = System.Drawing.SystemColors.Control;
            this.boardLabel1.BoardColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.boardLabel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.boardLabel1.Name = "boardLabel1";
            this.boardLabel1.Pattern = "^\\S*$";
            this.boardLabel1.RederStyle = VPS.Controls.BoardLabel.Style.Inner;
            this.boardLabel1.RederWidth = 1;
            this.boardLabel1.TextContent = "沙盘规模";
            // 
            // ScaleLabel
            // 
            resources.ApplyResources(this.ScaleLabel, "ScaleLabel");
            this.ScaleLabel.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ScaleLabel.BackColor = System.Drawing.SystemColors.Control;
            this.ScaleLabel.BoardColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ScaleLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ScaleLabel.Name = "ScaleLabel";
            this.ScaleLabel.Pattern = "^\\S*$";
            this.ScaleLabel.RederStyle = VPS.Controls.BoardLabel.Style.Inner;
            this.ScaleLabel.RederWidth = 1;
            this.ScaleLabel.TextContent = "沙盘比例尺";
            // 
            // RetButton
            // 
            resources.ApplyResources(this.RetButton, "RetButton");
            this.RetButton.BottomRederBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.RetButton.CancelText = "取消";
            this.RetButton.DownButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.RetButton.GlowButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.RetButton.MouseButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.RetButton.Name = "RetButton";
            this.RetButton.OKText = "确定";
            this.RetButton.RederButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.RetButton.TopRederBackColor = System.Drawing.Color.Transparent;
            // 
            // FilePath
            // 
            resources.ApplyResources(this.FilePath, "FilePath");
            this.FilePath.AllowEdit = true;
            this.FilePath.BoardColor = System.Drawing.Color.CornflowerBlue;
            this.FilePath.Name = "FilePath";
            this.FilePath.Pattern = "^\\S*$";
            this.FilePath.RederStyle = VPS.Controls.BoardEditableLabel.Style.Inner;
            this.FilePath.RederWidth = 2;
            this.FilePath.TabStop = false;
            this.FilePath.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.FilePath.TextContent = "";
            this.FilePath.TextPosition = new System.Drawing.Point(5, 5);
            // 
            // FileOpen
            // 
            resources.ApplyResources(this.FileOpen, "FileOpen");
            this.FileOpen.ColorGradualStyle = VPS.Controls.GradualButton.GradualStyle.Square;
            this.FileOpen.DownBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.FileOpen.DownTopColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.FileOpen.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FileOpen.Name = "FileOpen";
            this.FileOpen.NormalBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.FileOpen.NormalTopColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.FileOpen.StayBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.FileOpen.StayTopColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.FileOpen.UseVisualStyleBackColor = true;
            this.FileOpen.Click += new System.EventHandler(this.FileOpen_Click);
            // 
            // LayerReader
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BorderColor = System.Drawing.Color.Navy;
            this.CaptionBackColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.CloseBoxSize = new System.Drawing.Size(25, 18);
            this.Controls.Add(this.RetButton);
            this.Controls.Add(this.skinGroupBox3);
            this.Controls.Add(this.skinGroupBox2);
            this.Controls.Add(this.skinGroupBox1);
            this.Controls.Add(this.LayerPrevView);
            this.Controls.Add(this.LeftLabel);
            this.Controls.Add(this.BottomLabel);
            this.Controls.Add(this.RightLabel);
            this.Controls.Add(this.TopLabel);
            this.Controls.Add(this.FilePath);
            this.Controls.Add(this.FileOpen);
            this.EffectBack = System.Drawing.SystemColors.Window;
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LayerReader";
            this.Radius = 20;
            this.TitleCenter = true;
            ((System.ComponentModel.ISupportInitialize)(this.LayerPrevView)).EndInit();
            this.skinGroupBox1.ResumeLayout(false);
            this.skinGroupBox1.PerformLayout();
            this.skinGroupBox2.ResumeLayout(false);
            this.skinGroupBox2.PerformLayout();
            this.skinGroupBox3.ResumeLayout(false);
            this.skinGroupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private GradualButton FileOpen;
        private BoardEditableLabel FilePath;
        private BoardLabel ScaleLabel;
        private BoardEditableLabel MapScale;
        
        private BoardLabel TransparentLabel;
        private DotSpatial.Symbology.Forms.ColorButton Transparent;

        private CCWin.SkinControl.SkinPictureBox LayerPrevView;
        private System.Windows.Forms.Label TopLabel;
        private System.Windows.Forms.Label RightLabel;
        private System.Windows.Forms.Label BottomLabel;
        private System.Windows.Forms.Label LeftLabel;
        private BoardEditableLabel boardEditableLabel2;
        private BoardEditableLabel boardEditableLabel1;
        private BoardLabel boardLabel1;
        private BoardLabel boardLabel2;
        private CCWin.SkinControl.SkinGroupBox skinGroupBox1;
        private CCWin.SkinControl.SkinCheckBox ImageTileBox;
        private CCWin.SkinControl.SkinGroupBox skinGroupBox2;
        private BoardLabel AltitudeLabel;
        private BoardLabel LatitudeLabel;
        private BoardEditableLabel Longitude;
        private BoardLabel LongitudeLabel;
        private BoardEditableLabel Latitude;
        private BoardEditableLabel Altitude;
        private CCWin.SkinControl.SkinGroupBox skinGroupBox3;
        private ReturnButton RetButton;
    }
}