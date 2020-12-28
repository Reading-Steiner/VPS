namespace VPS.GCSViews
{
    partial class MapControl_2D
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
            this.GMapControl = new GMap.NET.WindowsForms.GMapControl();
            this.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.GMapZoomBar = new System.Windows.Forms.TrackBar();
            this.ChooseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MovableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemovableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GMapZoomBar)).BeginInit();
            this.SuspendLayout();
            // 
            // GMapControl
            // 
            this.GMapControl.Bearing = 0F;
            this.GMapControl.CanDragMap = false;
            this.GMapControl.ContextMenuStrip = this.ContextMenuStrip;
            this.GMapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GMapControl.EmptyTileColor = System.Drawing.Color.DimGray;
            this.GMapControl.GrayScaleMode = false;
            this.GMapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.GMapControl.HoldInvalidation = false;
            this.GMapControl.LevelsKeepInMemmory = 5;
            this.GMapControl.Location = new System.Drawing.Point(0, 0);
            this.GMapControl.MarkersEnabled = true;
            this.GMapControl.MaxZoom = 19;
            this.GMapControl.MinZoom = 1;
            this.GMapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            this.GMapControl.Name = "GMapControl";
            this.GMapControl.NegativeMode = false;
            this.GMapControl.PolygonsEnabled = true;
            this.GMapControl.RetryLoadTile = 0;
            this.GMapControl.RoutesEnabled = false;
            this.GMapControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Fractional;
            this.GMapControl.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.GMapControl.ShowTileGridLines = false;
            this.GMapControl.Size = new System.Drawing.Size(840, 540);
            this.GMapControl.TabIndex = 1;
            this.GMapControl.Zoom = 1D;
            // 
            // ContextMenuStrip
            // 
            this.ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChooseToolStripMenuItem,
            this.toolStripSeparator1});
            this.ContextMenuStrip.Name = "ContextMenuStripMain";
            this.ContextMenuStrip.Size = new System.Drawing.Size(181, 54);
            this.ContextMenuStrip.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.ContextMenuStrip_Closed);
            this.ContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStrip_Opening);
            // 
            // GMapZoomBar
            // 
            this.GMapZoomBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.GMapZoomBar.LargeChange = 1;
            this.GMapZoomBar.Location = new System.Drawing.Point(840, 0);
            this.GMapZoomBar.Maximum = 24;
            this.GMapZoomBar.Minimum = 1;
            this.GMapZoomBar.Name = "GMapZoomBar";
            this.GMapZoomBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.GMapZoomBar.Size = new System.Drawing.Size(45, 540);
            this.GMapZoomBar.TabIndex = 3;
            this.GMapZoomBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.GMapZoomBar.Value = 3;
            // 
            // ChooseToolStripMenuItem
            // 
            this.ChooseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MovableToolStripMenuItem,
            this.RemovableToolStripMenuItem});
            this.ChooseToolStripMenuItem.Name = "ChooseToolStripMenuItem";
            this.ChooseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ChooseToolStripMenuItem.Text = "选中";
            // 
            // MovableToolStripMenuItem
            // 
            this.MovableToolStripMenuItem.Name = "MovableToolStripMenuItem";
            this.MovableToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.MovableToolStripMenuItem.Text = "移动";
            // 
            // RemovableToolStripMenuItem
            // 
            this.RemovableToolStripMenuItem.Name = "RemovableToolStripMenuItem";
            this.RemovableToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.RemovableToolStripMenuItem.Text = "删除";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // MapControl_2D
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GMapControl);
            this.Controls.Add(this.GMapZoomBar);
            this.Name = "MapControl_2D";
            this.Size = new System.Drawing.Size(885, 540);
            this.ContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GMapZoomBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl GMapControl;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStrip;
        private System.Windows.Forms.TrackBar GMapZoomBar;
        private System.Windows.Forms.ToolStripMenuItem ChooseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MovableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemovableToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}
