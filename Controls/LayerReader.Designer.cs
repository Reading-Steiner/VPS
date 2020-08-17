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
            this.FileOpen = new VPS.Controls.GradualButton();
            this.FilePath = new System.Windows.Forms.TextBox();
            this.TopLabel = new System.Windows.Forms.Label();
            this.RightLabel = new System.Windows.Forms.Label();
            this.BottomLabel = new System.Windows.Forms.Label();
            this.LeftLabel = new System.Windows.Forms.Label();
            this.LayerPrevView = new System.Windows.Forms.PictureBox();
            this.Longitude = new System.Windows.Forms.TextBox();
            this.Latitude = new System.Windows.Forms.TextBox();
            this.Altitude = new System.Windows.Forms.TextBox();
            this.Scale = new System.Windows.Forms.TextBox();
            this.LongitudeLabel = new System.Windows.Forms.Label();
            this.OriginGroup = new System.Windows.Forms.GroupBox();
            this.AltitudeLabel = new System.Windows.Forms.Label();
            this.LatitudeLabel = new System.Windows.Forms.Label();
            this.ScaleLabel = new System.Windows.Forms.Label();
            this.Transparent = new DotSpatial.Symbology.Forms.ColorButton();
            this.TransparentLabel = new System.Windows.Forms.Label();
            this.MapGroup = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ViewGroup = new System.Windows.Forms.GroupBox();
            this.returnButton1 = new VPS.Controls.ReturnButton();
            ((System.ComponentModel.ISupportInitialize)(this.LayerPrevView)).BeginInit();
            this.OriginGroup.SuspendLayout();
            this.MapGroup.SuspendLayout();
            this.ViewGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // FileOpen
            // 
            resources.ApplyResources(this.FileOpen, "FileOpen");
            this.FileOpen.ColorGradualStyle = VPS.Controls.GradualButton.GradualStyle.Square;
            this.FileOpen.DownBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.FileOpen.DownTopColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.FileOpen.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FileOpen.Name = "FileOpen";
            this.FileOpen.NormalBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.FileOpen.NormalTopColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.FileOpen.StayBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.FileOpen.StayTopColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.FileOpen.UseVisualStyleBackColor = true;
            this.FileOpen.Click += new System.EventHandler(this.FileOpen_Click);
            // 
            // FilePath
            // 
            resources.ApplyResources(this.FilePath, "FilePath");
            this.FilePath.Name = "FilePath";
            this.FilePath.ReadOnly = true;
            this.FilePath.TabStop = false;
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
            // Longitude
            // 
            resources.ApplyResources(this.Longitude, "Longitude");
            this.Longitude.Name = "Longitude";
            // 
            // Latitude
            // 
            resources.ApplyResources(this.Latitude, "Latitude");
            this.Latitude.Name = "Latitude";
            // 
            // Altitude
            // 
            resources.ApplyResources(this.Altitude, "Altitude");
            this.Altitude.Name = "Altitude";
            // 
            // Scale
            // 
            resources.ApplyResources(this.Scale, "Scale");
            this.Scale.Name = "Scale";
            // 
            // LongitudeLabel
            // 
            resources.ApplyResources(this.LongitudeLabel, "LongitudeLabel");
            this.LongitudeLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LongitudeLabel.Name = "LongitudeLabel";
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
            this.OriginGroup.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.OriginGroup.Name = "OriginGroup";
            this.OriginGroup.TabStop = false;
            // 
            // AltitudeLabel
            // 
            resources.ApplyResources(this.AltitudeLabel, "AltitudeLabel");
            this.AltitudeLabel.ForeColor = System.Drawing.Color.Black;
            this.AltitudeLabel.Name = "AltitudeLabel";
            // 
            // LatitudeLabel
            // 
            resources.ApplyResources(this.LatitudeLabel, "LatitudeLabel");
            this.LatitudeLabel.ForeColor = System.Drawing.Color.Black;
            this.LatitudeLabel.Name = "LatitudeLabel";
            // 
            // ScaleLabel
            // 
            resources.ApplyResources(this.ScaleLabel, "ScaleLabel");
            this.ScaleLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ScaleLabel.Name = "ScaleLabel";
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
            // TransparentLabel
            // 
            resources.ApplyResources(this.TransparentLabel, "TransparentLabel");
            this.TransparentLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TransparentLabel.Name = "TransparentLabel";
            // 
            // MapGroup
            // 
            resources.ApplyResources(this.MapGroup, "MapGroup");
            this.MapGroup.BackColor = System.Drawing.Color.Transparent;
            this.MapGroup.Controls.Add(this.Scale);
            this.MapGroup.Controls.Add(this.ScaleLabel);
            this.MapGroup.Controls.Add(this.label1);
            this.MapGroup.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.MapGroup.Name = "MapGroup";
            this.MapGroup.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Name = "label1";
            // 
            // ViewGroup
            // 
            resources.ApplyResources(this.ViewGroup, "ViewGroup");
            this.ViewGroup.Controls.Add(this.TransparentLabel);
            this.ViewGroup.Controls.Add(this.Transparent);
            this.ViewGroup.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.ViewGroup.Name = "ViewGroup";
            this.ViewGroup.TabStop = false;
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
            // LayerReader
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
        private System.Windows.Forms.TextBox FilePath;
        private System.Windows.Forms.Label TopLabel;
        private System.Windows.Forms.Label RightLabel;
        private System.Windows.Forms.Label BottomLabel;
        private System.Windows.Forms.Label LeftLabel;
        private System.Windows.Forms.PictureBox LayerPrevView;
        private TextBox Longitude;
        private TextBox Latitude;
        private TextBox Altitude;
#pragma warning disable CS0108 // “LayerReader.Scale”隐藏继承的成员“Control.Scale(float)”。如果是有意隐藏，请使用关键字 new。
        private TextBox Scale;
#pragma warning restore CS0108 // “LayerReader.Scale”隐藏继承的成员“Control.Scale(float)”。如果是有意隐藏，请使用关键字 new。
        private Label LongitudeLabel;
        private GroupBox OriginGroup;
        private Label AltitudeLabel;
        private Label LatitudeLabel;
        private Label ScaleLabel;
        private DotSpatial.Symbology.Forms.ColorButton Transparent;
        private Label TransparentLabel;
        private GroupBox MapGroup;
        private GroupBox ViewGroup;
        private Label label1;
        private ReturnButton returnButton1;
    }
}