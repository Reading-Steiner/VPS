using System;
using System.IO;

namespace VPS
{
    partial class MainV2
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
            Console.WriteLine("mainv2_Dispose");
            if (PluginThreadrunner != null)
                PluginThreadrunner.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainV2));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.MenuFlightPlannerOpen = new System.Windows.Forms.ToolStripButton();
            this.MenuFlightPlannerClose = new System.Windows.Forms.ToolStripButton();
            this.Separator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuLoadLayer = new VPS.Controls.HLToolStripButton();
            this.MenuZoomToLayer = new VPS.Controls.HLToolStripButton();
            this.MenuLayerManager = new VPS.Controls.HLToolStripButton();
            this.Separator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuDrawPolygon = new VPS.Controls.HLToolStripButton();
            this.MenuClearPolygon = new VPS.Controls.HLToolStripButton();
            this.Separator3 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuSurveyGrid = new VPS.Controls.HLToolStripButton();
            this.MenuClearWP = new VPS.Controls.HLToolStripButton();
            this.MenuReadWP = new VPS.Controls.HLToolStripButton();
            this.MenuSaveWP = new VPS.Controls.HLToolStripButton();
            this.Separator4 = new System.Windows.Forms.ToolStripSeparator();
            this.Separator5 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuConnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripConnectionControl = new VPS.Controls.ToolStripConnectionControl();
            this.MenuWPGobalConfig = new VPS.Controls.HLToolStripButton();
            this.MenuInitConfig = new System.Windows.Forms.ToolStripButton();
            this.MenuConfigTune = new System.Windows.Forms.ToolStripButton();
            this.MenuSimulation = new System.Windows.Forms.ToolStripButton();
            this.MenuHelp = new System.Windows.Forms.ToolStripButton();
            this.MenuArduPilot = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.status1 = new VPS.Controls.Status();
            this.MainMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            resources.ApplyResources(this.MainMenu, "MainMenu");
            this.MainMenu.GripMargin = new System.Windows.Forms.Padding(0);
            this.MainMenu.ImageScalingSize = new System.Drawing.Size(45, 39);
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {});
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.ShowItemToolTips = true;
            this.MainMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MainMenu_ItemClicked);
            this.MainMenu.MouseLeave += new System.EventHandler(this.MainMenu_MouseLeave);
            // 
            // MenuFlightPlannerOpen
            // 
            resources.ApplyResources(this.MenuFlightPlannerOpen, "MenuFlightPlannerOpen");
            this.MenuFlightPlannerOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuFlightPlannerOpen.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.MenuFlightPlannerOpen.Margin = new System.Windows.Forms.Padding(0);
            this.MenuFlightPlannerOpen.Name = "MenuFlightPlannerOpen";
            this.MenuFlightPlannerOpen.Padding = new System.Windows.Forms.Padding(0, 0, 43, 38);
            this.MenuFlightPlannerOpen.Click += new System.EventHandler(this.MenuFlightPlannerOpen_Click);
            // 
            // MenuFlightPlannerClose
            // 
            resources.ApplyResources(this.MenuFlightPlannerClose, "MenuFlightPlannerClose");
            this.MenuFlightPlannerClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuFlightPlannerClose.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.MenuFlightPlannerClose.Margin = new System.Windows.Forms.Padding(0);
            this.MenuFlightPlannerClose.Name = "MenuFlightPlannerClose";
            this.MenuFlightPlannerClose.Padding = new System.Windows.Forms.Padding(0, 0, 43, 38);
            this.MenuFlightPlannerClose.Click += new System.EventHandler(this.MenuFlightPlannerClose_Click);
            // 
            // Separator1
            // 
            this.Separator1.Name = "Separator1";
            resources.ApplyResources(this.Separator1, "Separator1");
            // 
            // MenuLoadLayer
            // 
            resources.ApplyResources(this.MenuLoadLayer, "MenuLoadLayer");
            this.MenuLoadLayer.BottomTransparent = 5;
            this.MenuLoadLayer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuLoadLayer.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.MenuLoadLayer.HightLightBackgroundColor = System.Drawing.Color.Lime;
            this.MenuLoadLayer.Margin = new System.Windows.Forms.Padding(0);
            this.MenuLoadLayer.MyChecked = false;
            this.MenuLoadLayer.Name = "MenuLoadLayer";
            this.MenuLoadLayer.Padding = new System.Windows.Forms.Padding(0, 0, 43, 38);
            this.MenuLoadLayer.TopTransparent = 8;
            this.MenuLoadLayer.Click += new System.EventHandler(this.MenuLoadLayer_Click);
            // 
            // MenuZoomToLayer
            // 
            resources.ApplyResources(this.MenuZoomToLayer, "MenuZoomToLayer");
            this.MenuZoomToLayer.BottomTransparent = 5;
            this.MenuZoomToLayer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuZoomToLayer.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.MenuZoomToLayer.HightLightBackgroundColor = System.Drawing.Color.Lime;
            this.MenuZoomToLayer.Margin = new System.Windows.Forms.Padding(0);
            this.MenuZoomToLayer.MyChecked = false;
            this.MenuZoomToLayer.Name = "MenuZoomToLayer";
            this.MenuZoomToLayer.Padding = new System.Windows.Forms.Padding(0, 0, 43, 38);
            this.MenuZoomToLayer.TopTransparent = 8;
            this.MenuZoomToLayer.Click += new System.EventHandler(this.MenuZoomToLayer_Click);
            // 
            // MenuLayerManager
            // 
            resources.ApplyResources(this.MenuLayerManager, "MenuLayerManager");
            this.MenuLayerManager.BottomTransparent = 5;
            this.MenuLayerManager.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuLayerManager.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.MenuLayerManager.HightLightBackgroundColor = System.Drawing.Color.Lime;
            this.MenuLayerManager.Margin = new System.Windows.Forms.Padding(0);
            this.MenuLayerManager.MyChecked = false;
            this.MenuLayerManager.Name = "MenuLayerManager";
            this.MenuLayerManager.Padding = new System.Windows.Forms.Padding(0, 0, 43, 38);
            this.MenuLayerManager.TopTransparent = 8;
            this.MenuLayerManager.Click += new System.EventHandler(this.MenuLayerManager_Click);
            // 
            // Separator2
            // 
            this.Separator2.Name = "Separator2";
            resources.ApplyResources(this.Separator2, "Separator2");
            // 
            // MenuDrawPolygon
            // 
            resources.ApplyResources(this.MenuDrawPolygon, "MenuDrawPolygon");
            this.MenuDrawPolygon.BottomTransparent = 5;
            this.MenuDrawPolygon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuDrawPolygon.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.MenuDrawPolygon.HightLightBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.MenuDrawPolygon.Margin = new System.Windows.Forms.Padding(0);
            this.MenuDrawPolygon.MyChecked = false;
            this.MenuDrawPolygon.Name = "MenuDrawPolygon";
            this.MenuDrawPolygon.Padding = new System.Windows.Forms.Padding(0, 0, 43, 38);
            this.MenuDrawPolygon.TopTransparent = 8;
            this.MenuDrawPolygon.Click += new System.EventHandler(this.MenuDrawPolygon_Click);
            // 
            // MenuClearPolygon
            // 
            resources.ApplyResources(this.MenuClearPolygon, "MenuClearPolygon");
            this.MenuClearPolygon.BottomTransparent = 5;
            this.MenuClearPolygon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuClearPolygon.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.MenuClearPolygon.HightLightBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.MenuClearPolygon.Margin = new System.Windows.Forms.Padding(0);
            this.MenuClearPolygon.MyChecked = false;
            this.MenuClearPolygon.Name = "MenuClearPolygon";
            this.MenuClearPolygon.Padding = new System.Windows.Forms.Padding(0, 0, 43, 38);
            this.MenuClearPolygon.TopTransparent = 8;
            this.MenuClearPolygon.Click += new System.EventHandler(this.MenuClearPolygon_Click);
            // 
            // Separator3
            // 
            this.Separator3.Name = "Separator3";
            resources.ApplyResources(this.Separator3, "Separator3");
            // 
            // MenuSurveyGrid
            // 
            resources.ApplyResources(this.MenuSurveyGrid, "MenuSurveyGrid");
            this.MenuSurveyGrid.BottomTransparent = 5;
            this.MenuSurveyGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuSurveyGrid.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.MenuSurveyGrid.HightLightBackgroundColor = System.Drawing.Color.Aqua;
            this.MenuSurveyGrid.Margin = new System.Windows.Forms.Padding(0);
            this.MenuSurveyGrid.MyChecked = false;
            this.MenuSurveyGrid.Name = "MenuSurveyGrid";
            this.MenuSurveyGrid.Padding = new System.Windows.Forms.Padding(0, 0, 43, 38);
            this.MenuSurveyGrid.TopTransparent = 8;
            this.MenuSurveyGrid.Click += new System.EventHandler(this.MenuSurveyGrid_Click);
            // 
            // MenuClearWP
            // 
            resources.ApplyResources(this.MenuClearWP, "MenuClearWP");
            this.MenuClearWP.BottomTransparent = 5;
            this.MenuClearWP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuClearWP.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.MenuClearWP.HightLightBackgroundColor = System.Drawing.Color.Aqua;
            this.MenuClearWP.Margin = new System.Windows.Forms.Padding(0);
            this.MenuClearWP.MyChecked = false;
            this.MenuClearWP.Name = "MenuClearWP";
            this.MenuClearWP.Padding = new System.Windows.Forms.Padding(0, 0, 43, 38);
            this.MenuClearWP.TopTransparent = 8;
            this.MenuClearWP.Click += new System.EventHandler(this.MenuClearWP_Click);
            // 
            // MenuReadWP
            // 
            resources.ApplyResources(this.MenuReadWP, "MenuReadWP");
            this.MenuReadWP.BottomTransparent = 5;
            this.MenuReadWP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuReadWP.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.MenuReadWP.HightLightBackgroundColor = System.Drawing.Color.Aqua;
            this.MenuReadWP.Margin = new System.Windows.Forms.Padding(0);
            this.MenuReadWP.MyChecked = false;
            this.MenuReadWP.Name = "MenuReadWP";
            this.MenuReadWP.Padding = new System.Windows.Forms.Padding(0, 0, 43, 38);
            this.MenuReadWP.TopTransparent = 8;
            this.MenuReadWP.Click += new System.EventHandler(this.MenuReadWP_Click);
            // 
            // MenuSaveWP
            // 
            resources.ApplyResources(this.MenuSaveWP, "MenuSaveWP");
            this.MenuSaveWP.BottomTransparent = 5;
            this.MenuSaveWP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuSaveWP.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.MenuSaveWP.HightLightBackgroundColor = System.Drawing.Color.Aqua;
            this.MenuSaveWP.Margin = new System.Windows.Forms.Padding(0);
            this.MenuSaveWP.MyChecked = false;
            this.MenuSaveWP.Name = "MenuSaveWP";
            this.MenuSaveWP.Padding = new System.Windows.Forms.Padding(0, 0, 43, 38);
            this.MenuSaveWP.TopTransparent = 8;
            this.MenuSaveWP.Click += new System.EventHandler(this.MenuSaveWP_Click);
            // 
            // Separator4
            // 
            this.Separator4.Name = "Separator4";
            resources.ApplyResources(this.Separator4, "Separator4");
            // 
            // Separator5
            // 
            this.Separator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Separator5.Name = "Separator5";
            resources.ApplyResources(this.Separator5, "Separator5");
            // 
            // MenuConnect
            // 
            this.MenuConnect.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            resources.ApplyResources(this.MenuConnect, "MenuConnect");
            this.MenuConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuConnect.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.MenuConnect.Margin = new System.Windows.Forms.Padding(0);
            this.MenuConnect.Name = "MenuConnect";
            this.MenuConnect.Click += new System.EventHandler(this.MenuConnect_Click);
            // 
            // toolStripConnectionControl
            // 
            this.toolStripConnectionControl.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            resources.ApplyResources(this.toolStripConnectionControl, "toolStripConnectionControl");
            this.toolStripConnectionControl.BackColor = System.Drawing.Color.Transparent;
            this.toolStripConnectionControl.ForeColor = System.Drawing.Color.Black;
            this.toolStripConnectionControl.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripConnectionControl.Name = "toolStripConnectionControl";
            this.toolStripConnectionControl.Padding = new System.Windows.Forms.Padding(0, 0, 200, 38);
            this.toolStripConnectionControl.MouseLeave += new System.EventHandler(this.MainMenu_MouseLeave);
            // 
            // MenuWPGobalConfig
            // 
            this.MenuWPGobalConfig.BottomTransparent = 4;
            this.MenuWPGobalConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuWPGobalConfig.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.MenuWPGobalConfig.HightLightBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            resources.ApplyResources(this.MenuWPGobalConfig, "MenuWPGobalConfig");
            this.MenuWPGobalConfig.Margin = new System.Windows.Forms.Padding(0);
            this.MenuWPGobalConfig.MyChecked = false;
            this.MenuWPGobalConfig.Name = "MenuWPGobalConfig";
            this.MenuWPGobalConfig.TopTransparent = 8;
            this.MenuWPGobalConfig.Click += new System.EventHandler(this.WPGobalConfig_Click);
            // 
            // MenuInitConfig
            // 
            this.MenuInitConfig.ForeColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.MenuInitConfig, "MenuInitConfig");
            this.MenuInitConfig.Margin = new System.Windows.Forms.Padding(0);
            this.MenuInitConfig.Name = "MenuInitConfig";
            this.MenuInitConfig.Click += new System.EventHandler(this.MenuSetup_Click);
            // 
            // MenuConfigTune
            // 
            this.MenuConfigTune.ForeColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.MenuConfigTune, "MenuConfigTune");
            this.MenuConfigTune.Margin = new System.Windows.Forms.Padding(0);
            this.MenuConfigTune.Name = "MenuConfigTune";
            this.MenuConfigTune.Click += new System.EventHandler(this.MenuTuning_Click);
            // 
            // MenuSimulation
            // 
            this.MenuSimulation.ForeColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.MenuSimulation, "MenuSimulation");
            this.MenuSimulation.Margin = new System.Windows.Forms.Padding(0);
            this.MenuSimulation.Name = "MenuSimulation";
            this.MenuSimulation.Click += new System.EventHandler(this.MenuSimulation_Click);
            // 
            // MenuHelp
            // 
            this.MenuHelp.ForeColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.MenuHelp, "MenuHelp");
            this.MenuHelp.Margin = new System.Windows.Forms.Padding(0);
            this.MenuHelp.Name = "MenuHelp";
            this.MenuHelp.Click += new System.EventHandler(this.MenuHelp_Click);
            // 
            // MenuArduPilot
            // 
            this.MenuArduPilot.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            resources.ApplyResources(this.MenuArduPilot, "MenuArduPilot");
            this.MenuArduPilot.BackColor = System.Drawing.Color.Transparent;
            this.MenuArduPilot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuArduPilot.ForeColor = System.Drawing.Color.White;
            this.MenuArduPilot.Image = global::VPS.Properties.Resources._0d92fed790a3a70170e61a86db103f399a595c70;
            this.MenuArduPilot.Margin = new System.Windows.Forms.Padding(0);
            this.MenuArduPilot.Name = "MenuArduPilot";
            this.MenuArduPilot.Click += new System.EventHandler(this.MenuArduPilot_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.status1);
            this.panel1.Controls.Add(this.MainMenu);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            this.panel1.MouseLeave += new System.EventHandler(this.MainMenu_MouseLeave);
            // 
            // status1
            // 
            resources.ApplyResources(this.status1, "status1");
            this.status1.Name = "status1";
            this.status1.Percent = 0D;
            // 
            // MainV2
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainV2";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainV2_KeyDown);
            this.Resize += new System.EventHandler(this.MainV2_Resize);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ToolStripSeparator Separator1;
        public System.Windows.Forms.ToolStripSeparator Separator2;
        public System.Windows.Forms.ToolStripSeparator Separator3;
        public System.Windows.Forms.ToolStripSeparator Separator4;
        public System.Windows.Forms.ToolStripSeparator Separator5;
        public System.Windows.Forms.ToolStripButton MenuFlightPlannerOpen;
        public System.Windows.Forms.ToolStripButton MenuFlightPlannerClose;

        public Controls.HLToolStripButton MenuWPGobalConfig;
        public Controls.HLToolStripButton MenuLoadLayer;
        public Controls.HLToolStripButton MenuZoomToLayer;
        public Controls.HLToolStripButton MenuLayerManager;
        public Controls.HLToolStripButton MenuDrawPolygon;
        public Controls.HLToolStripButton MenuClearPolygon;
        public Controls.HLToolStripButton MenuSurveyGrid;
        public Controls.HLToolStripButton MenuClearWP;
        public Controls.HLToolStripButton MenuReadWP;
        public Controls.HLToolStripButton MenuSaveWP;

        public System.Windows.Forms.ToolStripButton MenuInitConfig;
        public System.Windows.Forms.ToolStripButton MenuSimulation;
        public System.Windows.Forms.ToolStripButton MenuConfigTune;
        public System.Windows.Forms.ToolStripButton MenuConnect;
        private Controls.ToolStripConnectionControl toolStripConnectionControl;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.MenuStrip MainMenu;
        public System.Windows.Forms.ToolStripButton MenuHelp;
        public System.Windows.Forms.ToolStripButton MenuArduPilot;
        public Controls.Status status1;
    }
}