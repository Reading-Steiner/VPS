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
            this.LayerPrevView = new System.Windows.Forms.PictureBox();
            this.OriginGroup = new System.Windows.Forms.GroupBox();
            this.AltitudeLabel = new VPS.Controls.BoardLabel();
            this.LatitudeLabel = new VPS.Controls.BoardLabel();
            this.Longitude = new VPS.Controls.BoardEditableLabel();
            this.LongitudeLabel = new VPS.Controls.BoardLabel();
            this.Latitude = new VPS.Controls.BoardEditableLabel();
            this.Altitude = new VPS.Controls.BoardEditableLabel();
            this.Transparent = new DotSpatial.Symbology.Forms.ColorButton();
            this.MapGroup = new System.Windows.Forms.GroupBox();
            this.MapScale = new VPS.Controls.BoardEditableLabel();
            this.ScaleLabel = new VPS.Controls.BoardLabel();
            this.ViewGroup = new System.Windows.Forms.GroupBox();
            this.TransparentLabel = new VPS.Controls.BoardLabel();
            this.returnButton1 = new VPS.Controls.ReturnButton();
            this.FilePath = new VPS.Controls.BoardEditableLabel();
            this.FileOpen = new VPS.Controls.GradualButton();
            MainTitle = new VPS.Controls.BoardLabel();
            ((System.ComponentModel.ISupportInitialize)(this.LayerPrevView)).BeginInit();
            this.OriginGroup.SuspendLayout();
            this.MapGroup.SuspendLayout();
            this.ViewGroup.SuspendLayout();
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
            this.LayerPrevView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LayerPrevView.Name = "LayerPrevView";
            this.LayerPrevView.TabStop = false;
            // 
            // OriginGroup
            // 
            resources.ApplyResources(this.OriginGroup, "OriginGroup");
            this.OriginGroup.Controls.Add(this.AltitudeLabel);
            this.OriginGroup.Controls.Add(this.LatitudeLabel);
            this.OriginGroup.Controls.Add(this.Longitude);
            this.OriginGroup.Controls.Add(this.LongitudeLabel);
            this.OriginGroup.Controls.Add(this.Latitude);
            this.OriginGroup.Controls.Add(this.Altitude);
            this.OriginGroup.ForeColor = System.Drawing.Color.Black;
            this.OriginGroup.Name = "OriginGroup";
            this.OriginGroup.TabStop = false;
            // 
            // AltitudeLabel
            // 
            resources.ApplyResources(this.AltitudeLabel, "AltitudeLabel");
            this.AltitudeLabel.BackColor = System.Drawing.SystemColors.Control;
            this.AltitudeLabel.BoardColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.AltitudeLabel.ForeColor = System.Drawing.Color.Black;
            this.AltitudeLabel.Name = "AltitudeLabel";
            this.AltitudeLabel.Pattern = "^\\S*$";
            this.AltitudeLabel.RederStyle = VPS.Controls.BoardLabel.Style.Inner;
            this.AltitudeLabel.RederWidth = 1;
            this.AltitudeLabel.TextContent = "相对高度";
            this.AltitudeLabel.TextPosition = new System.Drawing.Point(10, 5);
            // 
            // LatitudeLabel
            // 
            resources.ApplyResources(this.LatitudeLabel, "LatitudeLabel");
            this.LatitudeLabel.BackColor = System.Drawing.SystemColors.Control;
            this.LatitudeLabel.BoardColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.LatitudeLabel.ForeColor = System.Drawing.Color.Black;
            this.LatitudeLabel.Name = "LatitudeLabel";
            this.LatitudeLabel.Pattern = "^\\S*$";
            this.LatitudeLabel.RederStyle = VPS.Controls.BoardLabel.Style.Inner;
            this.LatitudeLabel.RederWidth = 1;
            this.LatitudeLabel.TextContent = "纬度";
            this.LatitudeLabel.TextPosition = new System.Drawing.Point(23, 5);
            // 
            // Longitude
            // 
            resources.ApplyResources(this.Longitude, "Longitude");
            this.Longitude.AllowEdit = true;
            this.Longitude.BoardColor = System.Drawing.SystemColors.InactiveCaption;
            this.Longitude.Name = "Longitude";
            this.Longitude.Pattern = "^\\S*$";
            this.Longitude.RederStyle = VPS.Controls.BoardEditableLabel.Style.Inner;
            this.Longitude.RederWidth = 2;
            this.Longitude.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.Longitude.TextContent = "";
            this.Longitude.TextPosition = new System.Drawing.Point(122, 89);
            // 
            // LongitudeLabel
            // 
            resources.ApplyResources(this.LongitudeLabel, "LongitudeLabel");
            this.LongitudeLabel.BackColor = System.Drawing.SystemColors.Control;
            this.LongitudeLabel.BoardColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.LongitudeLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LongitudeLabel.Name = "LongitudeLabel";
            this.LongitudeLabel.Pattern = "^\\S*$";
            this.LongitudeLabel.RederStyle = VPS.Controls.BoardLabel.Style.Inner;
            this.LongitudeLabel.RederWidth = 1;
            this.LongitudeLabel.TextContent = "经度";
            this.LongitudeLabel.TextPosition = new System.Drawing.Point(23, 5);
            // 
            // Latitude
            // 
            resources.ApplyResources(this.Latitude, "Latitude");
            this.Latitude.AllowEdit = true;
            this.Latitude.BoardColor = System.Drawing.SystemColors.InactiveCaption;
            this.Latitude.Name = "Latitude";
            this.Latitude.Pattern = "^\\S*$";
            this.Latitude.RederStyle = VPS.Controls.BoardEditableLabel.Style.Inner;
            this.Latitude.RederWidth = 2;
            this.Latitude.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.Latitude.TextContent = "";
            this.Latitude.TextPosition = new System.Drawing.Point(122, 89);
            // 
            // Altitude
            // 
            resources.ApplyResources(this.Altitude, "Altitude");
            this.Altitude.AllowEdit = true;
            this.Altitude.BoardColor = System.Drawing.SystemColors.InactiveCaption;
            this.Altitude.Name = "Altitude";
            this.Altitude.Pattern = "^\\S*$";
            this.Altitude.RederStyle = VPS.Controls.BoardEditableLabel.Style.Inner;
            this.Altitude.RederWidth = 2;
            this.Altitude.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.Altitude.TextContent = "";
            this.Altitude.TextPosition = new System.Drawing.Point(122, 89);
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
            // MapGroup
            // 
            resources.ApplyResources(this.MapGroup, "MapGroup");
            this.MapGroup.BackColor = System.Drawing.Color.Transparent;
            this.MapGroup.Controls.Add(this.MapScale);
            this.MapGroup.Controls.Add(this.ScaleLabel);
            this.MapGroup.ForeColor = System.Drawing.Color.Black;
            this.MapGroup.Name = "MapGroup";
            this.MapGroup.TabStop = false;
            // 
            // MapScale
            // 
            resources.ApplyResources(this.MapScale, "MapScale");
            this.MapScale.AllowEdit = true;
            this.MapScale.BoardColor = System.Drawing.SystemColors.InactiveCaption;
            this.MapScale.Name = "MapScale";
            this.MapScale.Pattern = "^\\S*$";
            this.MapScale.RederStyle = VPS.Controls.BoardEditableLabel.Style.Inner;
            this.MapScale.RederWidth = 2;
            this.MapScale.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.MapScale.TextContent = "";
            this.MapScale.TextPosition = new System.Drawing.Point(122, 89);
            // 
            // ScaleLabel
            // 
            resources.ApplyResources(this.ScaleLabel, "ScaleLabel");
            this.ScaleLabel.BackColor = System.Drawing.SystemColors.Control;
            this.ScaleLabel.BoardColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ScaleLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ScaleLabel.Name = "ScaleLabel";
            this.ScaleLabel.Pattern = "^\\S*$";
            this.ScaleLabel.RederStyle = VPS.Controls.BoardLabel.Style.Inner;
            this.ScaleLabel.RederWidth = 1;
            this.ScaleLabel.TextContent = "比例尺";
            this.ScaleLabel.TextPosition = new System.Drawing.Point(18, 5);
            // 
            // ViewGroup
            // 
            resources.ApplyResources(this.ViewGroup, "ViewGroup");
            this.ViewGroup.Controls.Add(this.TransparentLabel);
            this.ViewGroup.Controls.Add(this.Transparent);
            this.ViewGroup.ForeColor = System.Drawing.Color.Black;
            this.ViewGroup.Name = "ViewGroup";
            this.ViewGroup.TabStop = false;
            // 
            // TransparentLabel
            // 
            resources.ApplyResources(this.TransparentLabel, "TransparentLabel");
            this.TransparentLabel.BackColor = System.Drawing.SystemColors.Control;
            this.TransparentLabel.BoardColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.TransparentLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TransparentLabel.Name = "TransparentLabel";
            this.TransparentLabel.Pattern = "^\\S*$";
            this.TransparentLabel.RederStyle = VPS.Controls.BoardLabel.Style.Inner;
            this.TransparentLabel.RederWidth = 1;
            this.TransparentLabel.TextContent = "透明色";
            this.TransparentLabel.TextPosition = new System.Drawing.Point(18, 5);
            // 
            // returnButton1
            // 
            resources.ApplyResources(this.returnButton1, "returnButton1");
            this.returnButton1.CancelText = "取消";
            this.returnButton1.Name = "returnButton1";
            this.returnButton1.OKText = "确定";
            this.returnButton1.RederBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.returnButton1.RederButtonColor = System.Drawing.Color.CornflowerBlue;
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
            this.FilePath.TextPosition = new System.Drawing.Point(15, 10);
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
            // MainTitle
            // 
            resources.ApplyResources(MainTitle, "MainTitle");
            MainTitle.BackColor = System.Drawing.SystemColors.Control;
            MainTitle.BoardColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            MainTitle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            MainTitle.Name = "MainTitle";
            MainTitle.Pattern = "^\\S*$";
            MainTitle.RederStyle = VPS.Controls.BoardLabel.Style.Inner;
            MainTitle.RederWidth = 2;
            MainTitle.TabStop = false;
            MainTitle.Tag = "oad the geographic image file";
            MainTitle.TextContent = "加载地理图像文件";
            MainTitle.TextPosition = new System.Drawing.Point(24, 6);
            // 
            // LayerReader
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(MainTitle);
            this.Controls.Add(this.returnButton1);
            this.Controls.Add(this.ViewGroup);
            this.Controls.Add(this.MapGroup);
            this.Controls.Add(this.OriginGroup);
            this.Controls.Add(this.LayerPrevView);
            this.Controls.Add(this.LeftLabel);
            this.Controls.Add(this.BottomLabel);
            this.Controls.Add(this.RightLabel);
            this.Controls.Add(this.TopLabel);
            this.Controls.Add(this.FilePath);
            this.Controls.Add(this.FileOpen);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LayerReader";
            ((System.ComponentModel.ISupportInitialize)(this.LayerPrevView)).EndInit();
            this.OriginGroup.ResumeLayout(false);
            this.OriginGroup.PerformLayout();
            this.MapGroup.ResumeLayout(false);
            this.MapGroup.PerformLayout();
            this.ViewGroup.ResumeLayout(false);
            this.ViewGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private GradualButton FileOpen;
        private BoardEditableLabel FilePath;

        private GroupBox MapGroup;
        private BoardLabel ScaleLabel;
        private BoardEditableLabel MapScale;

        private GroupBox OriginGroup;
        private BoardLabel LongitudeLabel;
        private BoardEditableLabel Longitude;
        private BoardEditableLabel Latitude;
        private BoardLabel LatitudeLabel;
        private BoardEditableLabel Altitude;
        private BoardLabel AltitudeLabel;
        

        private GroupBox ViewGroup;
        private BoardLabel TransparentLabel;
        private DotSpatial.Symbology.Forms.ColorButton Transparent;

        private System.Windows.Forms.PictureBox LayerPrevView;
        private System.Windows.Forms.Label TopLabel;
        private System.Windows.Forms.Label RightLabel;
        private System.Windows.Forms.Label BottomLabel;
        private System.Windows.Forms.Label LeftLabel;

        private ReturnButton returnButton1;
    }
}