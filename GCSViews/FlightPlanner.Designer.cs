using VPS.Controls;
using System.Windows.Forms;

namespace VPS.GCSViews
{
    partial class FlightPlanner
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

            if (currentMarker != null) currentMarker.Dispose();
            if (drawnpolygon != null) drawnpolygon.Dispose();
            if (kmlpolygonsoverlay != null) kmlpolygonsoverlay.Dispose();
            if (wppolygon != null) wppolygon.Dispose();
            if (top != null) top.Dispose();
            if (geofencepolygon != null) geofencepolygon.Dispose();
            if (geofenceoverlay != null) geofenceoverlay.Dispose();
            if (drawnpolygonsoverlay != null) drawnpolygonsoverlay.Dispose();
            if (center != null) center.Dispose(); 

            base.Dispose(disposing);
        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FlightPlanner));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_status = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chk_grid = new System.Windows.Forms.CheckBox();
            this.comboBoxMapType = new System.Windows.Forms.ComboBox();
            this.lnk_kml = new System.Windows.Forms.LinkLabel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panelMap = new System.Windows.Forms.Panel();
            this.trackBar1 = new VPS.Controls.MyTrackBar();
            this.label11 = new System.Windows.Forms.Label();
            this.MainMap = new VPS.Controls.myGMAP();
            this.contextMenuStripMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteMarkerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.polygonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addPolygonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearPolygonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.savePolygonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadPolygonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromPolygonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromSHPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planningWPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addWPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.surveyGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearMissionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.saveWPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadWPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadWPFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadKMLFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSHPFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadAndAppendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelBASE = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStripPoly = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStripTiff = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tiffReadToolStripTiffMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiffManagerToolStripTiffMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomToTiffToolStripTiffMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3.SuspendLayout();
            this.panelMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.contextMenuStripMain.SuspendLayout();
            this.panelBASE.SuspendLayout();
            this.contextMenuStripTiff.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewImageColumn1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewImageColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.dataGridViewImageColumn1, "dataGridViewImageColumn1");
            this.dataGridViewImageColumn1.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn1.Image")));
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            // 
            // dataGridViewImageColumn2
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewImageColumn2.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.dataGridViewImageColumn2, "dataGridViewImageColumn2");
            this.dataGridViewImageColumn2.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn2.Image")));
            this.dataGridViewImageColumn2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            this.toolTip1.SetToolTip(this.label6, resources.GetString("label6.ToolTip"));
            // 
            // lbl_status
            // 
            resources.ApplyResources(this.lbl_status, "lbl_status");
            this.lbl_status.Name = "lbl_status";
            this.toolTip1.SetToolTip(this.lbl_status, resources.GetString("lbl_status.ToolTip"));
            // 
            // splitter1
            // 
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            this.toolTip1.SetToolTip(this.splitter1, resources.GetString("splitter1.ToolTip"));
            // 
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Controls.Add(this.chk_grid);
            this.panel3.Controls.Add(this.lbl_status);
            this.panel3.Controls.Add(this.comboBoxMapType);
            this.panel3.Controls.Add(this.lnk_kml);
            this.panel3.Name = "panel3";
            this.toolTip1.SetToolTip(this.panel3, resources.GetString("panel3.ToolTip"));
            // 
            // chk_grid
            // 
            resources.ApplyResources(this.chk_grid, "chk_grid");
            this.chk_grid.Name = "chk_grid";
            this.toolTip1.SetToolTip(this.chk_grid, resources.GetString("chk_grid.ToolTip"));
            this.chk_grid.UseVisualStyleBackColor = true;
            this.chk_grid.CheckedChanged += new System.EventHandler(this.Chk_grid_CheckedChanged);
            // 
            // comboBoxMapType
            // 
            resources.ApplyResources(this.comboBoxMapType, "comboBoxMapType");
            this.comboBoxMapType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMapType.FormattingEnabled = true;
            this.comboBoxMapType.Name = "comboBoxMapType";
            this.toolTip1.SetToolTip(this.comboBoxMapType, resources.GetString("comboBoxMapType.ToolTip"));
            // 
            // lnk_kml
            // 
            resources.ApplyResources(this.lnk_kml, "lnk_kml");
            this.lnk_kml.Name = "lnk_kml";
            this.lnk_kml.TabStop = true;
            this.toolTip1.SetToolTip(this.lnk_kml, resources.GetString("lnk_kml.ToolTip"));
            this.lnk_kml.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_kml_LinkClicked);
            // 
            // splitter2
            // 
            resources.ApplyResources(this.splitter2, "splitter2");
            this.splitter2.Name = "splitter2";
            this.splitter2.TabStop = false;
            this.toolTip1.SetToolTip(this.splitter2, resources.GetString("splitter2.ToolTip"));
            // 
            // panelMap
            // 
            resources.ApplyResources(this.panelMap, "panelMap");
            this.panelMap.Controls.Add(this.panel3);
            this.panelMap.Controls.Add(this.trackBar1);
            this.panelMap.Controls.Add(this.label11);
            this.panelMap.Controls.Add(this.MainMap);
            this.panelMap.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelMap.Name = "panelMap";
            this.toolTip1.SetToolTip(this.panelMap, resources.GetString("panelMap.ToolTip"));
            this.panelMap.Resize += new System.EventHandler(this.panelMap_Resize);
            // 
            // trackBar1
            // 
            resources.ApplyResources(this.trackBar1, "trackBar1");
            this.trackBar1.LargeChange = 0.005F;
            this.trackBar1.Maximum = 24F;
            this.trackBar1.Minimum = 1F;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.SmallChange = 0.001F;
            this.trackBar1.TickFrequency = 1F;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.toolTip1.SetToolTip(this.trackBar1, resources.GetString("trackBar1.ToolTip"));
            this.trackBar1.Value = 2F;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            this.toolTip1.SetToolTip(this.label11, resources.GetString("label11.ToolTip"));
            // 
            // MainMap
            // 
            resources.ApplyResources(this.MainMap, "MainMap");
            this.MainMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.MainMap.Bearing = 0F;
            this.MainMap.CanDragMap = false;
            this.MainMap.ContextMenuStrip = this.contextMenuStripMain;
            this.MainMap.Cursor = System.Windows.Forms.Cursors.Default;
            this.MainMap.EmptyTileColor = System.Drawing.Color.Gray;
            this.MainMap.GrayScaleMode = false;
            this.MainMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.MainMap.HoldInvalidation = false;
            this.MainMap.LevelsKeepInMemmory = 5;
            this.MainMap.MarkersEnabled = true;
            this.MainMap.MaxZoom = 19;
            this.MainMap.MinZoom = 0;
            this.MainMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            this.MainMap.Name = "MainMap";
            this.MainMap.NegativeMode = false;
            this.MainMap.PolygonsEnabled = true;
            this.MainMap.RetryLoadTile = 0;
            this.MainMap.RoutesEnabled = false;
            this.MainMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Fractional;
            this.MainMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.MainMap.ShowTileGridLines = false;
            this.toolTip1.SetToolTip(this.MainMap, resources.GetString("MainMap.ToolTip"));
            this.MainMap.Zoom = 0D;
            this.MainMap.Paint += new System.Windows.Forms.PaintEventHandler(this.MainMap_Paint);
            this.MainMap.Resize += new System.EventHandler(this.MainMap_Resize);
            // 
            // contextMenuStripMain
            // 
            resources.ApplyResources(this.contextMenuStripMain, "contextMenuStripMain");
            this.contextMenuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteMarkerToolStripMenuItem,
            this.toolStripSeparator1,
            this.polygonToolStripMenuItem,
            this.planningWPToolStripMenuItem});
            this.contextMenuStripMain.Name = "contextMenuStripMain";
            this.contextMenuStripMain.ShowImageMargin = false;
            this.toolTip1.SetToolTip(this.contextMenuStripMain, resources.GetString("contextMenuStripMain.ToolTip"));
            this.contextMenuStripMain.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.ContextMenuStripMain_Closed);
            this.contextMenuStripMain.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStripMain_Opening);
            // 
            // deleteMarkerToolStripMenuItem
            // 
            resources.ApplyResources(this.deleteMarkerToolStripMenuItem, "deleteMarkerToolStripMenuItem");
            this.deleteMarkerToolStripMenuItem.Name = "deleteMarkerToolStripMenuItem";
            this.deleteMarkerToolStripMenuItem.Click += new System.EventHandler(this.DeleteMarkerToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // polygonToolStripMenuItem
            // 
            resources.ApplyResources(this.polygonToolStripMenuItem, "polygonToolStripMenuItem");
            this.polygonToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addPolygonToolStripMenuItem,
            this.clearPolygonToolStripMenuItem,
            this.toolStripSeparator2,
            this.savePolygonToolStripMenuItem,
            this.loadPolygonToolStripMenuItem});
            this.polygonToolStripMenuItem.Name = "polygonToolStripMenuItem";
            // 
            // addPolygonPointToolStripMenuItem
            // 
            resources.ApplyResources(this.addPolygonToolStripMenuItem, "addPolygonPointToolStripMenuItem");
            this.addPolygonToolStripMenuItem.Name = "addPolygonPointToolStripMenuItem";
            this.addPolygonToolStripMenuItem.Click += new System.EventHandler(this.AddPolygonPointToolStripMenuItem_Click);
            // 
            // clearPolygonToolStripMenuItem
            // 
            resources.ApplyResources(this.clearPolygonToolStripMenuItem, "clearPolygonToolStripMenuItem");
            this.clearPolygonToolStripMenuItem.Name = "clearPolygonToolStripMenuItem";
            this.clearPolygonToolStripMenuItem.Click += new System.EventHandler(this.ClearPolygonToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // savePolygonToolStripMenuItem
            // 
            resources.ApplyResources(this.savePolygonToolStripMenuItem, "savePolygonToolStripMenuItem");
            this.savePolygonToolStripMenuItem.Name = "savePolygonToolStripMenuItem";
            this.savePolygonToolStripMenuItem.Click += new System.EventHandler(this.SavePolygonToolStripMenuItem_Click);
            // 
            // loadPolygonToolStripMenuItem
            // 
            resources.ApplyResources(this.loadPolygonToolStripMenuItem, "loadPolygonToolStripMenuItem");
            this.loadPolygonToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fromPolygonToolStripMenuItem,
            this.fromSHPToolStripMenuItem});
            this.loadPolygonToolStripMenuItem.Name = "loadPolygonToolStripMenuItem";
            // 
            // fromPolygonToolStripMenuItem
            // 
            resources.ApplyResources(this.fromPolygonToolStripMenuItem, "fromPolygonToolStripMenuItem");
            this.fromPolygonToolStripMenuItem.Name = "fromPolygonToolStripMenuItem";
            this.fromPolygonToolStripMenuItem.Click += new System.EventHandler(this.FromPolygonToolStripMenuItem_Click);
            // 
            // fromSHPToolStripMenuItem
            // 
            resources.ApplyResources(this.fromSHPToolStripMenuItem, "fromSHPToolStripMenuItem");
            this.fromSHPToolStripMenuItem.Name = "fromSHPToolStripMenuItem";
            this.fromSHPToolStripMenuItem.Click += new System.EventHandler(this.fromSHPToolStripMenuItem_Click);
            // 
            // planningWPToolStripMenuItem
            // 
            resources.ApplyResources(this.planningWPToolStripMenuItem, "planningWPToolStripMenuItem");
            this.planningWPToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addWPToolStripMenuItem,
            this.surveyGridToolStripMenuItem,
            this.clearMissionToolStripMenuItem,
            this.toolStripSeparator3,
            this.saveWPToolStripMenuItem,
            this.loadWPToolStripMenuItem});
            this.planningWPToolStripMenuItem.Name = "planningWPToolStripMenuItem";
            // 
            // drawWPToolStripMenuItem
            // 
            resources.ApplyResources(this.addWPToolStripMenuItem, "drawWPToolStripMenuItem");
            this.addWPToolStripMenuItem.Name = "drawWPToolStripMenuItem";
            this.addWPToolStripMenuItem.Click += new System.EventHandler(this.AddWPToolStripMenuItem_Click);
            // 
            // surveyGridToolStripMenuItem
            // 
            resources.ApplyResources(this.surveyGridToolStripMenuItem, "surveyGridToolStripMenuItem");
            this.surveyGridToolStripMenuItem.Name = "surveyGridToolStripMenuItem";
            this.surveyGridToolStripMenuItem.Click += new System.EventHandler(this.surveyGridToolStripMenuItem_Click);
            // 
            // clearMissionToolStripMenuItem
            // 
            resources.ApplyResources(this.clearMissionToolStripMenuItem, "clearMissionToolStripMenuItem");
            this.clearMissionToolStripMenuItem.Name = "clearMissionToolStripMenuItem";
            this.clearMissionToolStripMenuItem.Click += new System.EventHandler(this.clearMissionToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            // 
            // saveWPToolStripMenuItem
            // 
            resources.ApplyResources(this.saveWPToolStripMenuItem, "saveWPToolStripMenuItem");
            this.saveWPToolStripMenuItem.Name = "saveWPToolStripMenuItem";
            this.saveWPToolStripMenuItem.Click += new System.EventHandler(this.SaveWPFileToolStripMenuItem_Click);
            // 
            // loadWPToolStripMenuItem
            // 
            resources.ApplyResources(this.loadWPToolStripMenuItem, "loadWPToolStripMenuItem");
            this.loadWPToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadWPFileToolStripMenuItem,
            this.loadKMLFileToolStripMenuItem,
            this.loadSHPFileToolStripMenuItem});
            this.loadWPToolStripMenuItem.Name = "loadWPToolStripMenuItem";
            // 
            // loadWPFileToolStripMenuItem
            // 
            resources.ApplyResources(this.loadWPFileToolStripMenuItem, "loadWPFileToolStripMenuItem");
            this.loadWPFileToolStripMenuItem.Name = "loadWPFileToolStripMenuItem";
            this.loadWPFileToolStripMenuItem.Click += new System.EventHandler(this.LoadWPFileToolStripMenuItem_Click);
            // 
            // loadKMLFileToolStripMenuItem
            // 
            resources.ApplyResources(this.loadKMLFileToolStripMenuItem, "loadKMLFileToolStripMenuItem");
            this.loadKMLFileToolStripMenuItem.Name = "loadKMLFileToolStripMenuItem";
            this.loadKMLFileToolStripMenuItem.Click += new System.EventHandler(this.LoadKMLFileToolStripMenuItem_Click);
            // 
            // loadSHPFileToolStripMenuItem
            // 
            resources.ApplyResources(this.loadSHPFileToolStripMenuItem, "loadSHPFileToolStripMenuItem");
            this.loadSHPFileToolStripMenuItem.Name = "loadSHPFileToolStripMenuItem";
            this.loadSHPFileToolStripMenuItem.Click += new System.EventHandler(this.LoadSHPFileToolStripMenuItem_Click);
            // 
            // loadAndAppendToolStripMenuItem
            // 
            resources.ApplyResources(this.loadAndAppendToolStripMenuItem, "loadAndAppendToolStripMenuItem");
            this.loadAndAppendToolStripMenuItem.Name = "loadAndAppendToolStripMenuItem";
            // 
            // panelBASE
            // 
            resources.ApplyResources(this.panelBASE, "panelBASE");
            this.panelBASE.Controls.Add(this.splitter2);
            this.panelBASE.Controls.Add(this.splitter1);
            this.panelBASE.Controls.Add(this.panelMap);
            this.panelBASE.Controls.Add(this.label6);
            this.panelBASE.Name = "panelBASE";
            this.toolTip1.SetToolTip(this.panelBASE, resources.GetString("panelBASE.ToolTip"));
            // 
            // contextMenuStripPoly
            // 
            resources.ApplyResources(this.contextMenuStripPoly, "contextMenuStripPoly");
            this.contextMenuStripPoly.Name = "contextMenuStripPoly";
            this.contextMenuStripPoly.ShowImageMargin = false;
            this.toolTip1.SetToolTip(this.contextMenuStripPoly, resources.GetString("contextMenuStripPoly.ToolTip"));
            this.contextMenuStripPoly.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.ContextMenuStripPoly_Close);
            this.contextMenuStripPoly.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStripPoly_Opening);
            // 
            // contextMenuStripTiff
            // 
            resources.ApplyResources(this.contextMenuStripTiff, "contextMenuStripTiff");
            this.contextMenuStripTiff.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tiffReadToolStripTiffMenuItem,
            this.tiffManagerToolStripTiffMenuItem});
            this.contextMenuStripTiff.Name = "contextMenuStripTiff";
            this.toolTip1.SetToolTip(this.contextMenuStripTiff, resources.GetString("contextMenuStripTiff.ToolTip"));
            // 
            // tiffReadToolStripTiffMenuItem
            // 
            resources.ApplyResources(this.tiffReadToolStripTiffMenuItem, "tiffReadToolStripTiffMenuItem");
            this.tiffReadToolStripTiffMenuItem.Name = "tiffReadToolStripTiffMenuItem";
            this.tiffReadToolStripTiffMenuItem.Click += new System.EventHandler(this.TiffOverlayToolStripMenuItem_Click);
            // 
            // tiffManagerToolStripTiffMenuItem
            // 
            resources.ApplyResources(this.tiffManagerToolStripTiffMenuItem, "tiffManagerToolStripTiffMenuItem");
            this.tiffManagerToolStripTiffMenuItem.Name = "tiffManagerToolStripTiffMenuItem";
            this.tiffManagerToolStripTiffMenuItem.Click += new System.EventHandler(this.TiffManagerToolStripMenuItem_Click);
            // 
            // zoomToTiffToolStripTiffMenuItem
            // 
            resources.ApplyResources(this.zoomToTiffToolStripTiffMenuItem, "zoomToTiffToolStripTiffMenuItem");
            this.zoomToTiffToolStripTiffMenuItem.Name = "zoomToTiffToolStripTiffMenuItem";
            this.zoomToTiffToolStripTiffMenuItem.Click += new System.EventHandler(this.zoomToVehicleToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // toolStripMenuItem3
            // 
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            // 
            // testToolStripMenuItem
            // 
            resources.ApplyResources(this.testToolStripMenuItem, "testToolStripMenuItem");
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            // 
            // FlightPlanner
            // 
            resources.ApplyResources(this, "$this");
            this.AllowDrop = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panelBASE);
            this.Name = "FlightPlanner";
            this.toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FlightPlanner_FormClosing);
            this.Load += new System.EventHandler(this.FlightPlanner_Load);
            this.Resize += new System.EventHandler(this.Planner_Resize);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panelMap.ResumeLayout(false);
            this.panelMap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.contextMenuStripMain.ResumeLayout(false);
            this.panelBASE.ResumeLayout(false);
            this.contextMenuStripTiff.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion
        public Controls.myGMAP MainMap;
        public DataGridViewImageColumn dataGridViewImageColumn1;
        public DataGridViewImageColumn dataGridViewImageColumn2;
        public Label label6;
        public Label lbl_status;
        public Panel panelMap;
        public MyTrackBar trackBar1;
        public Label label11;
        public Splitter splitter1;
        public Panel panelBASE;
        public ToolTip toolTip1;

        public System.Windows.Forms.ContextMenuStrip contextMenuStripMain;
        public ToolStripMenuItem deleteMarkerToolStripMenuItem;
        public ToolStripMenuItem clearMissionToolStripMenuItem;
        public ToolStripSeparator toolStripSeparator1;
        public ToolStripSeparator toolStripSeparator2;
        public ToolStripSeparator toolStripSeparator3;
        public ToolStripMenuItem planningWPToolStripMenuItem;
        public ToolStripMenuItem surveyGridToolStripMenuItem;
        private ToolStripMenuItem polygonToolStripMenuItem;
        public ToolStripMenuItem addPolygonToolStripMenuItem;
        public ToolStripMenuItem clearPolygonToolStripMenuItem;
        private ToolStripMenuItem loadPolygonToolStripMenuItem;
        public ToolStripMenuItem fromPolygonToolStripMenuItem;
        public ToolStripMenuItem fromSHPToolStripMenuItem;

        public ContextMenuStrip contextMenuStripPoly;

        private ContextMenuStrip contextMenuStripTiff;
        private ToolStripMenuItem zoomToTiffToolStripTiffMenuItem;
        private ToolStripMenuItem tiffReadToolStripTiffMenuItem;
        private ToolStripMenuItem tiffManagerToolStripTiffMenuItem;

        public Timer timer1;

        public ComboBox comboBoxMapType;
        public ToolStripMenuItem loadWPToolStripMenuItem;
        public ToolStripMenuItem loadWPFileToolStripMenuItem;
        public ToolStripMenuItem saveWPToolStripMenuItem;
        //public ToolStripMenuItem trackerHomeToolStripMenuItem;
        //public ToolStripMenuItem reverseWPsToolStripMenuItem;
        public ToolStripMenuItem loadAndAppendToolStripMenuItem;
        public ToolStripMenuItem savePolygonToolStripMenuItem;

        public CheckBox chk_grid;
        //public ToolStripMenuItem insertWpToolStripMenuItem;
        public ToolStripMenuItem loadKMLFileToolStripMenuItem;
        public LinkLabel lnk_kml;
        //public ToolStripMenuItem pOIToolStripMenuItem;
        //public ToolStripMenuItem poiaddToolStripMenuItem;
        //public ToolStripMenuItem poideleteToolStripMenuItem;
        //public ToolStripMenuItem poieditToolStripMenuItem;
        //public ToolStripMenuItem enterUTMCoordToolStripMenuItem;
        public ToolStripMenuItem loadSHPFileToolStripMenuItem;
        public Panel panel3;
        //public ToolStripMenuItem switchDockingToolStripMenuItem;
        public Splitter splitter2;

        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem testToolStripMenuItem;
        private ToolStripMenuItem addWPToolStripMenuItem;
    }
}