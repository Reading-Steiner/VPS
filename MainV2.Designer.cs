using System;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainV2));
            this.MenuFlightPlannerOpen = new System.Windows.Forms.ToolStripButton();
            this.MenuFlightPlannerClose = new System.Windows.Forms.ToolStripButton();
            this.Separator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Separator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Separator3 = new System.Windows.Forms.ToolStripSeparator();
            this.Separator4 = new System.Windows.Forms.ToolStripSeparator();
            this.Separator5 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuConnect = new System.Windows.Forms.ToolStripButton();
            this.MenuInitConfig = new System.Windows.Forms.ToolStripButton();
            this.MenuConfigTune = new System.Windows.Forms.ToolStripButton();
            this.MenuSimulation = new System.Windows.Forms.ToolStripButton();
            this.MenuHelp = new System.Windows.Forms.ToolStripButton();
            this.MenuArduPilot = new System.Windows.Forms.ToolStripButton();
            this.MinMenu = new DevComponents.DotNetBar.RibbonControl();
            this.FileRibbonPanel = new DevComponents.DotNetBar.RibbonPanel();
            this.ProjectRibbonBar = new DevComponents.DotNetBar.RibbonBar();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.FileRibbonTabItem = new DevComponents.DotNetBar.RibbonTabItem();
            this.StartButton = new DevComponents.DotNetBar.Office2007StartButton();
            this.StartContainer = new DevComponents.DotNetBar.ItemContainer();
            this.itemContainer2 = new DevComponents.DotNetBar.ItemContainer();
            this.StartItemContainer = new DevComponents.DotNetBar.ItemContainer();
            this.StartFileContainer = new DevComponents.DotNetBar.GalleryContainer();
            this.RecentDocumentsLabel = new DevComponents.DotNetBar.LabelItem();
            this.StartBottomContainer = new DevComponents.DotNetBar.ItemContainer();
            this.qatCustomizeItem = new DevComponents.DotNetBar.QatCustomizeItem();
            this.styleManager = new DevComponents.DotNetBar.StyleManager(this.components);
            this.dockContainerItem1 = new DevComponents.DotNetBar.DockContainerItem();
            this.RibbonClientPanel = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.AppCommandTheme = new DevComponents.DotNetBar.Command(this.components);
            this.MenuLoadLayer = new VPS.Controls.HLToolStripButton();
            this.MenuZoomToLayer = new VPS.Controls.HLToolStripButton();
            this.MenuLayerManager = new VPS.Controls.HLToolStripButton();
            this.MenuDrawPolygon = new VPS.Controls.HLToolStripButton();
            this.MenuClearPolygon = new VPS.Controls.HLToolStripButton();
            this.MenuSurveyGrid = new VPS.Controls.HLToolStripButton();
            this.MenuClearWP = new VPS.Controls.HLToolStripButton();
            this.MenuReadWP = new VPS.Controls.HLToolStripButton();
            this.MenuSaveWP = new VPS.Controls.HLToolStripButton();
            this.toolStripConnectionControl = new VPS.Controls.ToolStripConnectionControl();
            this.MenuWPGobalConfig = new VPS.Controls.HLToolStripButton();
            this.buttonChangeStyle = new DevComponents.DotNetBar.ButtonItem();
            this.buttonStyleOffice2010Blue = new DevComponents.DotNetBar.ButtonItem();
            this.buttonStyleOffice2010Silver = new DevComponents.DotNetBar.ButtonItem();
            this.buttonStyleOffice2010Black = new DevComponents.DotNetBar.ButtonItem();
            this.buttonStyleOffice2007Blue = new DevComponents.DotNetBar.ButtonItem();
            this.buttonStyleOffice2007Black = new DevComponents.DotNetBar.ButtonItem();
            this.buttonStyleOffice2007Silver = new DevComponents.DotNetBar.ButtonItem();
            this.MinMenu.SuspendLayout();
            this.FileRibbonPanel.SuspendLayout();
            this.SuspendLayout();
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
            // Separator2
            // 
            this.Separator2.Name = "Separator2";
            resources.ApplyResources(this.Separator2, "Separator2");
            // 
            // Separator3
            // 
            this.Separator3.Name = "Separator3";
            resources.ApplyResources(this.Separator3, "Separator3");
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
            // MinMenu
            // 
            // 
            // 
            // 
            this.MinMenu.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.MinMenu.CaptionVisible = true;
            this.MinMenu.Controls.Add(this.FileRibbonPanel);
            resources.ApplyResources(this.MinMenu, "MinMenu");
            this.MinMenu.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.FileRibbonTabItem,
            this.buttonChangeStyle});
            this.MinMenu.KeyTipsFont = new System.Drawing.Font("Tahoma", 7F);
            this.MinMenu.Name = "MinMenu";
            this.MinMenu.QuickToolbarItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.StartButton,
            this.qatCustomizeItem});
            this.MinMenu.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.MinMenu.SystemText.MaximizeRibbonText = resources.GetString("MinMenu.SystemText.MaximizeRibbonText");
            this.MinMenu.SystemText.MinimizeRibbonText = resources.GetString("MinMenu.SystemText.MinimizeRibbonText");
            this.MinMenu.SystemText.QatAddItemText = resources.GetString("MinMenu.SystemText.QatAddItemText");
            this.MinMenu.SystemText.QatCustomizeMenuLabel = resources.GetString("MinMenu.SystemText.QatCustomizeMenuLabel");
            this.MinMenu.SystemText.QatCustomizeText = resources.GetString("MinMenu.SystemText.QatCustomizeText");
            this.MinMenu.SystemText.QatDialogAddButton = resources.GetString("MinMenu.SystemText.QatDialogAddButton");
            this.MinMenu.SystemText.QatDialogCancelButton = resources.GetString("MinMenu.SystemText.QatDialogCancelButton");
            this.MinMenu.SystemText.QatDialogCaption = resources.GetString("MinMenu.SystemText.QatDialogCaption");
            this.MinMenu.SystemText.QatDialogCategoriesLabel = resources.GetString("MinMenu.SystemText.QatDialogCategoriesLabel");
            this.MinMenu.SystemText.QatDialogOkButton = resources.GetString("MinMenu.SystemText.QatDialogOkButton");
            this.MinMenu.SystemText.QatDialogPlacementCheckbox = resources.GetString("MinMenu.SystemText.QatDialogPlacementCheckbox");
            this.MinMenu.SystemText.QatDialogRemoveButton = resources.GetString("MinMenu.SystemText.QatDialogRemoveButton");
            this.MinMenu.SystemText.QatPlaceAboveRibbonText = resources.GetString("MinMenu.SystemText.QatPlaceAboveRibbonText");
            this.MinMenu.SystemText.QatPlaceBelowRibbonText = resources.GetString("MinMenu.SystemText.QatPlaceBelowRibbonText");
            this.MinMenu.SystemText.QatRemoveItemText = resources.GetString("MinMenu.SystemText.QatRemoveItemText");
            this.MinMenu.TabGroupHeight = 14;
            // 
            // FileRibbonPanel
            // 
            this.FileRibbonPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.FileRibbonPanel.Controls.Add(this.ProjectRibbonBar);
            resources.ApplyResources(this.FileRibbonPanel, "FileRibbonPanel");
            this.FileRibbonPanel.Name = "FileRibbonPanel";
            // 
            // 
            // 
            this.FileRibbonPanel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.FileRibbonPanel.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.FileRibbonPanel.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // ProjectRibbonBar
            // 
            this.ProjectRibbonBar.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ProjectRibbonBar.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ProjectRibbonBar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ProjectRibbonBar.ContainerControlProcessDialogKey = true;
            resources.ApplyResources(this.ProjectRibbonBar, "ProjectRibbonBar");
            this.ProjectRibbonBar.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem1,
            this.buttonItem2});
            this.ProjectRibbonBar.Name = "ProjectRibbonBar";
            this.ProjectRibbonBar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            // 
            // 
            // 
            this.ProjectRibbonBar.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ProjectRibbonBar.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // buttonItem1
            // 
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.SubItemsExpandWidth = 14;
            resources.ApplyResources(this.buttonItem1, "buttonItem1");
            // 
            // buttonItem2
            // 
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.SubItemsExpandWidth = 14;
            resources.ApplyResources(this.buttonItem2, "buttonItem2");
            // 
            // FileRibbonTabItem
            // 
            this.FileRibbonTabItem.Checked = true;
            this.FileRibbonTabItem.Name = "FileRibbonTabItem";
            this.FileRibbonTabItem.Panel = this.FileRibbonPanel;
            resources.ApplyResources(this.FileRibbonTabItem, "FileRibbonTabItem");
            // 
            // StartButton
            // 
            this.StartButton.AutoExpandOnClick = true;
            this.StartButton.CanCustomize = false;
            this.StartButton.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Image;
            this.StartButton.Image = ((System.Drawing.Image)(resources.GetObject("StartButton.Image")));
            this.StartButton.ImagePaddingHorizontal = 2;
            this.StartButton.ImagePaddingVertical = 2;
            this.StartButton.Name = "StartButton";
            this.StartButton.ShowSubItems = false;
            this.StartButton.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.StartContainer});
            resources.ApplyResources(this.StartButton, "StartButton");
            // 
            // StartContainer
            // 
            // 
            // 
            // 
            this.StartContainer.BackgroundStyle.Class = "RibbonFileMenuContainer";
            this.StartContainer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.StartContainer.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.StartContainer.Name = "StartContainer";
            this.StartContainer.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer2,
            this.StartBottomContainer});
            // 
            // itemContainer2
            // 
            // 
            // 
            // 
            this.itemContainer2.BackgroundStyle.Class = "RibbonFileMenuTwoColumnContainer";
            this.itemContainer2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer2.ItemSpacing = 0;
            this.itemContainer2.Name = "itemContainer2";
            this.itemContainer2.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.StartItemContainer,
            this.StartFileContainer});
            // 
            // StartItemContainer
            // 
            // 
            // 
            // 
            this.StartItemContainer.BackgroundStyle.Class = "RibbonFileMenuColumnOneContainer";
            this.StartItemContainer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.StartItemContainer.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.StartItemContainer.MinimumSize = new System.Drawing.Size(120, 0);
            this.StartItemContainer.Name = "StartItemContainer";
            // 
            // StartFileContainer
            // 
            // 
            // 
            // 
            this.StartFileContainer.BackgroundStyle.Class = "RibbonFileMenuColumnTwoContainer";
            this.StartFileContainer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.StartFileContainer.EnableGalleryPopup = false;
            this.StartFileContainer.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.StartFileContainer.MinimumSize = new System.Drawing.Size(180, 240);
            this.StartFileContainer.MultiLine = false;
            this.StartFileContainer.Name = "StartFileContainer";
            this.StartFileContainer.PopupUsesStandardScrollbars = false;
            this.StartFileContainer.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.RecentDocumentsLabel});
            // 
            // RecentDocumentsLabel
            // 
            this.RecentDocumentsLabel.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom;
            this.RecentDocumentsLabel.BorderType = DevComponents.DotNetBar.eBorderType.Etched;
            this.RecentDocumentsLabel.CanCustomize = false;
            this.RecentDocumentsLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.RecentDocumentsLabel.Name = "RecentDocumentsLabel";
            this.RecentDocumentsLabel.PaddingBottom = 2;
            this.RecentDocumentsLabel.PaddingTop = 2;
            this.RecentDocumentsLabel.Stretch = true;
            resources.ApplyResources(this.RecentDocumentsLabel, "RecentDocumentsLabel");
            // 
            // StartBottomContainer
            // 
            // 
            // 
            // 
            this.StartBottomContainer.BackgroundStyle.Class = "RibbonFileMenuBottomContainer";
            this.StartBottomContainer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.StartBottomContainer.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Right;
            this.StartBottomContainer.Name = "StartBottomContainer";
            // 
            // qatCustomizeItem
            // 
            this.qatCustomizeItem.Name = "qatCustomizeItem";
            // 
            // styleManager
            // 
            this.styleManager.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Black;
            this.styleManager.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(163)))), ((int)(((byte)(26))))));
            // 
            // dockContainerItem1
            // 
            this.dockContainerItem1.Name = "dockContainerItem1";
            resources.ApplyResources(this.dockContainerItem1, "dockContainerItem1");
            // 
            // RibbonClientPanel
            // 
            this.RibbonClientPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.RibbonClientPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            resources.ApplyResources(this.RibbonClientPanel, "RibbonClientPanel");
            this.RibbonClientPanel.Name = "RibbonClientPanel";
            this.RibbonClientPanel.Style.Class = "RibbonClientPanel";
            this.RibbonClientPanel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.RibbonClientPanel.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // AppCommandTheme
            // 
            this.AppCommandTheme.Name = "AppCommandTheme";
            this.AppCommandTheme.Executed += new System.EventHandler(this.AppCommandTheme_Executed);
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
            // toolStripConnectionControl
            // 
            this.toolStripConnectionControl.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            resources.ApplyResources(this.toolStripConnectionControl, "toolStripConnectionControl");
            this.toolStripConnectionControl.BackColor = System.Drawing.Color.Transparent;
            this.toolStripConnectionControl.ForeColor = System.Drawing.Color.Black;
            this.toolStripConnectionControl.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripConnectionControl.Name = "toolStripConnectionControl";
            this.toolStripConnectionControl.Padding = new System.Windows.Forms.Padding(0, 0, 200, 38);
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
            // buttonChangeStyle
            // 
            this.buttonChangeStyle.AutoExpandOnClick = true;
            this.buttonChangeStyle.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.buttonChangeStyle.Name = "buttonChangeStyle";
            this.buttonChangeStyle.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonStyleOffice2010Blue,
            this.buttonStyleOffice2010Silver,
            this.buttonStyleOffice2010Black,
            this.buttonStyleOffice2007Blue,
            this.buttonStyleOffice2007Black,
            this.buttonStyleOffice2007Silver});
            resources.ApplyResources(this.buttonChangeStyle, "buttonChangeStyle");
            // 
            // buttonStyleOffice2010Blue
            // 
            this.buttonStyleOffice2010Blue.Command = this.AppCommandTheme;
            resources.ApplyResources(this.buttonStyleOffice2010Blue, "buttonStyleOffice2010Blue");
            this.buttonStyleOffice2010Blue.Name = "buttonStyleOffice2010Blue";
            this.buttonStyleOffice2010Blue.OptionGroup = "style";
            // 
            // buttonStyleOffice2010Silver
            // 
            this.buttonStyleOffice2010Silver.Command = this.AppCommandTheme;
            resources.ApplyResources(this.buttonStyleOffice2010Silver, "buttonStyleOffice2010Silver");
            this.buttonStyleOffice2010Silver.Name = "buttonStyleOffice2010Silver";
            this.buttonStyleOffice2010Silver.OptionGroup = "style";
            // 
            // buttonStyleOffice2010Black
            // 
            this.buttonStyleOffice2010Black.Command = this.AppCommandTheme;
            resources.ApplyResources(this.buttonStyleOffice2010Black, "buttonStyleOffice2010Black");
            this.buttonStyleOffice2010Black.Name = "buttonStyleOffice2010Black";
            this.buttonStyleOffice2010Black.OptionGroup = "style";
            // 
            // buttonStyleOffice2007Blue
            // 
            this.buttonStyleOffice2007Blue.Command = this.AppCommandTheme;
            resources.ApplyResources(this.buttonStyleOffice2007Blue, "buttonStyleOffice2007Blue");
            this.buttonStyleOffice2007Blue.Name = "buttonStyleOffice2007Blue";
            this.buttonStyleOffice2007Blue.OptionGroup = "style";
            // 
            // buttonStyleOffice2007Black
            // 
            this.buttonStyleOffice2007Black.Command = this.AppCommandTheme;
            resources.ApplyResources(this.buttonStyleOffice2007Black, "buttonStyleOffice2007Black");
            this.buttonStyleOffice2007Black.Name = "buttonStyleOffice2007Black";
            this.buttonStyleOffice2007Black.OptionGroup = "style";
            // 
            // buttonStyleOffice2007Silver
            // 
            this.buttonStyleOffice2007Silver.Command = this.AppCommandTheme;
            resources.ApplyResources(this.buttonStyleOffice2007Silver, "buttonStyleOffice2007Silver");
            this.buttonStyleOffice2007Silver.Name = "buttonStyleOffice2007Silver";
            this.buttonStyleOffice2007Silver.OptionGroup = "style";
            // 
            // MainV2
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.RibbonClientPanel);
            this.Controls.Add(this.MinMenu);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "MainV2";
            this.ShowIcon = false;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainV2_KeyDown);
            this.Resize += new System.EventHandler(this.MainV2_Resize);
            this.MinMenu.ResumeLayout(false);
            this.MinMenu.PerformLayout();
            this.FileRibbonPanel.ResumeLayout(false);
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
        public System.Windows.Forms.ToolStripButton MenuHelp;
        public System.Windows.Forms.ToolStripButton MenuArduPilot;
        private DevComponents.DotNetBar.RibbonControl MinMenu;
        private DevComponents.DotNetBar.RibbonPanel FileRibbonPanel;
        private DevComponents.DotNetBar.RibbonBar ProjectRibbonBar;
        private DevComponents.DotNetBar.RibbonTabItem FileRibbonTabItem;
        private DevComponents.DotNetBar.Office2007StartButton StartButton;
        private DevComponents.DotNetBar.ItemContainer StartContainer;
        private DevComponents.DotNetBar.ItemContainer StartItemContainer;
        private DevComponents.DotNetBar.QatCustomizeItem qatCustomizeItem;
        private DevComponents.DotNetBar.StyleManager styleManager;
        private DevComponents.DotNetBar.GalleryContainer StartFileContainer;
        private DevComponents.DotNetBar.LabelItem RecentDocumentsLabel;
        private DevComponents.DotNetBar.ItemContainer StartBottomContainer;
        private DevComponents.DotNetBar.DockContainerItem dockContainerItem1;
        private DevComponents.DotNetBar.ItemContainer itemContainer2;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel RibbonClientPanel;
        private DevComponents.DotNetBar.Command AppCommandTheme;
        private DevComponents.DotNetBar.ButtonItem buttonChangeStyle;
        private DevComponents.DotNetBar.ButtonItem buttonStyleOffice2010Blue;
        private DevComponents.DotNetBar.ButtonItem buttonStyleOffice2010Silver;
        private DevComponents.DotNetBar.ButtonItem buttonStyleOffice2010Black;
        private DevComponents.DotNetBar.ButtonItem buttonStyleOffice2007Blue;
        private DevComponents.DotNetBar.ButtonItem buttonStyleOffice2007Black;
        private DevComponents.DotNetBar.ButtonItem buttonStyleOffice2007Silver;
    }
}