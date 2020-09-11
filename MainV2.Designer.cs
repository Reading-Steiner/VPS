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
            this.MinMenuBar = new DevComponents.DotNetBar.RibbonControl();
            this.FuncRibbonPanel = new DevComponents.DotNetBar.RibbonPanel();
            this.WPFileRibbonBar = new DevComponents.DotNetBar.RibbonBar();
            this.SaveWPButton = new DevComponents.DotNetBar.ButtonItem();
            this.LoadWPButton = new DevComponents.DotNetBar.ButtonItem();
            this.AutoWPRibbonBar = new DevComponents.DotNetBar.RibbonBar();
            this.AutoWPButton = new DevComponents.DotNetBar.ButtonItem();
            this.WPRibbonBar = new DevComponents.DotNetBar.RibbonBar();
            this.itemContainer1 = new DevComponents.DotNetBar.ItemContainer();
            this.itemContainer3 = new DevComponents.DotNetBar.ItemContainer();
            this.FirstWPButton = new DevComponents.DotNetBar.ButtonItem();
            this.NextWPButton = new DevComponents.DotNetBar.ButtonItem();
            this.PrevWPButton = new DevComponents.DotNetBar.ButtonItem();
            this.itemContainer4 = new DevComponents.DotNetBar.ItemContainer();
            this.DeleteWPButton = new DevComponents.DotNetBar.ButtonItem();
            this.CancelWPButton = new DevComponents.DotNetBar.ButtonItem();
            this.AddWPButton = new DevComponents.DotNetBar.ButtonItem();
            this.ClearWPButton = new DevComponents.DotNetBar.ButtonItem();
            this.PolygonRibbonBar = new DevComponents.DotNetBar.RibbonBar();
            this.itemContainer5 = new DevComponents.DotNetBar.ItemContainer();
            this.itemContainer6 = new DevComponents.DotNetBar.ItemContainer();
            this.FirstPolygonButton = new DevComponents.DotNetBar.ButtonItem();
            this.NextPolygonButton = new DevComponents.DotNetBar.ButtonItem();
            this.PrevPolygonButton = new DevComponents.DotNetBar.ButtonItem();
            this.itemContainer7 = new DevComponents.DotNetBar.ItemContainer();
            this.DeletePolygonButton = new DevComponents.DotNetBar.ButtonItem();
            this.CancelPolygonButton = new DevComponents.DotNetBar.ButtonItem();
            this.DrawPolygonButton = new DevComponents.DotNetBar.ButtonItem();
            this.ClearPolygonButton = new DevComponents.DotNetBar.ButtonItem();
            this.FileRibbonPanel = new DevComponents.DotNetBar.RibbonPanel();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.LoadTiffButton = new DevComponents.DotNetBar.ButtonItem();
            this.ZoomTiffButton = new DevComponents.DotNetBar.ButtonItem();
            this.TiffManagerButton = new DevComponents.DotNetBar.ButtonItem();
            this.ProjectRibbonBar = new DevComponents.DotNetBar.RibbonBar();
            this.OpenProjectButton = new DevComponents.DotNetBar.ButtonItem();
            this.SaveProjectButton = new DevComponents.DotNetBar.ButtonItem();
            this.UndoButton = new DevComponents.DotNetBar.ButtonItem();
            this.ZoomToButton = new DevComponents.DotNetBar.ButtonItem();
            this.FileRibbonTabItem = new DevComponents.DotNetBar.RibbonTabItem();
            this.FuncRibbonTabItem = new DevComponents.DotNetBar.RibbonTabItem();
            this.buttonChangeStyle = new DevComponents.DotNetBar.ButtonItem();
            this.buttonStyleOffice2010Blue = new DevComponents.DotNetBar.ButtonItem();
            this.AppCommandTheme = new DevComponents.DotNetBar.Command(this.components);
            this.buttonStyleOffice2010Silver = new DevComponents.DotNetBar.ButtonItem();
            this.buttonStyleOffice2010Black = new DevComponents.DotNetBar.ButtonItem();
            this.buttonStyleOffice2007Blue = new DevComponents.DotNetBar.ButtonItem();
            this.buttonStyleOffice2007Black = new DevComponents.DotNetBar.ButtonItem();
            this.buttonStyleOffice2007Silver = new DevComponents.DotNetBar.ButtonItem();
            this.MenuSwitchButton = new DevComponents.DotNetBar.SwitchButtonItem();
            this.RibbonStateCommand = new DevComponents.DotNetBar.Command(this.components);
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
            this.dotNetBarManager1 = new DevComponents.DotNetBar.DotNetBarManager(this.components);
            this.BottomDockSite = new DevComponents.DotNetBar.DockSite();
            this.LeftDockSite = new DevComponents.DotNetBar.DockSite();
            this.RightDockSite = new DevComponents.DotNetBar.DockSite();
            this.ToolbarBottomDockSite = new DevComponents.DotNetBar.DockSite();
            this.ToolbarLeftDockSite = new DevComponents.DotNetBar.DockSite();
            this.ToolbarRightDockSite = new DevComponents.DotNetBar.DockSite();
            this.ToolbarTopDockSite = new DevComponents.DotNetBar.DockSite();
            this.TopDockSite = new DevComponents.DotNetBar.DockSite();
            this.LayerReader = new DevComponents.DotNetBar.PanelDockContainer();
            this.layerReaderPanel = new VPS.Controls.Layer.LayerReader();
            this.microChartItem1 = new DevComponents.DotNetBar.MicroChartItem();
            this.microChartItem2 = new DevComponents.DotNetBar.MicroChartItem();
            this.dockContainerItem4 = new DevComponents.DotNetBar.DockContainerItem();
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
            this.MinMenuBar.SuspendLayout();
            this.FuncRibbonPanel.SuspendLayout();
            this.FileRibbonPanel.SuspendLayout();
            this.LayerReader.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuFlightPlannerOpen
            // 
            this.MenuFlightPlannerOpen.AutoSize = false;
            this.MenuFlightPlannerOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuFlightPlannerOpen.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.MenuFlightPlannerOpen.Image = ((System.Drawing.Image)(resources.GetObject("MenuFlightPlannerOpen.Image")));
            this.MenuFlightPlannerOpen.Margin = new System.Windows.Forms.Padding(0);
            this.MenuFlightPlannerOpen.Name = "MenuFlightPlannerOpen";
            this.MenuFlightPlannerOpen.Padding = new System.Windows.Forms.Padding(0, 0, 43, 38);
            this.MenuFlightPlannerOpen.Size = new System.Drawing.Size(40, 34);
            this.MenuFlightPlannerOpen.Click += new System.EventHandler(this.MenuFlightPlannerOpen_Click);
            // 
            // MenuFlightPlannerClose
            // 
            this.MenuFlightPlannerClose.AutoSize = false;
            this.MenuFlightPlannerClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuFlightPlannerClose.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.MenuFlightPlannerClose.Image = ((System.Drawing.Image)(resources.GetObject("MenuFlightPlannerClose.Image")));
            this.MenuFlightPlannerClose.Margin = new System.Windows.Forms.Padding(0);
            this.MenuFlightPlannerClose.Name = "MenuFlightPlannerClose";
            this.MenuFlightPlannerClose.Padding = new System.Windows.Forms.Padding(0, 0, 43, 38);
            this.MenuFlightPlannerClose.Size = new System.Drawing.Size(43, 38);
            this.MenuFlightPlannerClose.Click += new System.EventHandler(this.MenuFlightPlannerClose_Click);
            // 
            // Separator1
            // 
            this.Separator1.Name = "Separator1";
            this.Separator1.Size = new System.Drawing.Size(6, 43);
            // 
            // Separator2
            // 
            this.Separator2.Name = "Separator2";
            this.Separator2.Size = new System.Drawing.Size(6, 43);
            // 
            // Separator3
            // 
            this.Separator3.Name = "Separator3";
            this.Separator3.Size = new System.Drawing.Size(6, 43);
            // 
            // Separator4
            // 
            this.Separator4.Name = "Separator4";
            this.Separator4.Size = new System.Drawing.Size(6, 43);
            // 
            // Separator5
            // 
            this.Separator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Separator5.Name = "Separator5";
            this.Separator5.Size = new System.Drawing.Size(6, 43);
            // 
            // MenuConnect
            // 
            this.MenuConnect.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.MenuConnect.AutoSize = false;
            this.MenuConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuConnect.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.MenuConnect.Image = ((System.Drawing.Image)(resources.GetObject("MenuConnect.Image")));
            this.MenuConnect.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.MenuConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuConnect.Margin = new System.Windows.Forms.Padding(0);
            this.MenuConnect.Name = "MenuConnect";
            this.MenuConnect.Size = new System.Drawing.Size(38, 38);
            this.MenuConnect.Text = "CONNECT";
            this.MenuConnect.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MenuConnect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuConnect.Click += new System.EventHandler(this.MenuConnect_Click);
            // 
            // MenuInitConfig
            // 
            this.MenuInitConfig.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.MenuInitConfig.Image = ((System.Drawing.Image)(resources.GetObject("MenuInitConfig.Image")));
            this.MenuInitConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuInitConfig.Margin = new System.Windows.Forms.Padding(0);
            this.MenuInitConfig.Name = "MenuInitConfig";
            this.MenuInitConfig.Size = new System.Drawing.Size(49, 47);
            this.MenuInitConfig.Text = "SETUP";
            this.MenuInitConfig.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MenuInitConfig.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuInitConfig.ToolTipText = "Hardware Config";
            this.MenuInitConfig.Click += new System.EventHandler(this.MenuSetup_Click);
            // 
            // MenuConfigTune
            // 
            this.MenuConfigTune.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.MenuConfigTune.Image = ((System.Drawing.Image)(resources.GetObject("MenuConfigTune.Image")));
            this.MenuConfigTune.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuConfigTune.Margin = new System.Windows.Forms.Padding(0);
            this.MenuConfigTune.Name = "MenuConfigTune";
            this.MenuConfigTune.Size = new System.Drawing.Size(51, 47);
            this.MenuConfigTune.Text = "CONFIG";
            this.MenuConfigTune.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MenuConfigTune.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuConfigTune.ToolTipText = "Software Config";
            this.MenuConfigTune.Click += new System.EventHandler(this.MenuTuning_Click);
            // 
            // MenuSimulation
            // 
            this.MenuSimulation.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.MenuSimulation.Image = ((System.Drawing.Image)(resources.GetObject("MenuSimulation.Image")));
            this.MenuSimulation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuSimulation.Margin = new System.Windows.Forms.Padding(0);
            this.MenuSimulation.Name = "MenuSimulation";
            this.MenuSimulation.Size = new System.Drawing.Size(77, 47);
            this.MenuSimulation.Text = "SIMULATION";
            this.MenuSimulation.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MenuSimulation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuSimulation.ToolTipText = "Simulation";
            this.MenuSimulation.Click += new System.EventHandler(this.MenuSimulation_Click);
            // 
            // MenuHelp
            // 
            this.MenuHelp.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.MenuHelp.Image = ((System.Drawing.Image)(resources.GetObject("MenuHelp.Image")));
            this.MenuHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuHelp.Margin = new System.Windows.Forms.Padding(0);
            this.MenuHelp.Name = "MenuHelp";
            this.MenuHelp.Size = new System.Drawing.Size(49, 47);
            this.MenuHelp.Text = "HELP";
            this.MenuHelp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MenuHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuHelp.ToolTipText = "Help";
            this.MenuHelp.Click += new System.EventHandler(this.MenuHelp_Click);
            // 
            // MenuArduPilot
            // 
            this.MenuArduPilot.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.MenuArduPilot.AutoSize = false;
            this.MenuArduPilot.BackColor = System.Drawing.Color.Transparent;
            this.MenuArduPilot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MenuArduPilot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuArduPilot.ForeColor = System.Drawing.Color.White;
            this.MenuArduPilot.Image = ((System.Drawing.Image)(resources.GetObject("MenuArduPilot.Image")));
            this.MenuArduPilot.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuArduPilot.Margin = new System.Windows.Forms.Padding(0);
            this.MenuArduPilot.Name = "MenuArduPilot";
            this.MenuArduPilot.Size = new System.Drawing.Size(255, 40);
            this.MenuArduPilot.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.MenuArduPilot.Click += new System.EventHandler(this.MenuArduPilot_Click);
            // 
            // MinMenuBar
            // 
            // 
            // 
            // 
            this.MinMenuBar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.MinMenuBar.CaptionVisible = true;
            this.MinMenuBar.Controls.Add(this.FuncRibbonPanel);
            this.MinMenuBar.Controls.Add(this.FileRibbonPanel);
            this.MinMenuBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.MinMenuBar.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.UndoButton,
            this.ZoomToButton,
            this.FileRibbonTabItem,
            this.FuncRibbonTabItem,
            this.buttonChangeStyle,
            this.MenuSwitchButton});
            this.MinMenuBar.KeyTipsFont = new System.Drawing.Font("Tahoma", 7F);
            this.MinMenuBar.Location = new System.Drawing.Point(5, 1);
            this.MinMenuBar.Name = "MinMenuBar";
            this.MinMenuBar.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.MinMenuBar.QuickToolbarItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.StartButton,
            this.qatCustomizeItem});
            this.MinMenuBar.Size = new System.Drawing.Size(950, 146);
            this.MinMenuBar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.MinMenuBar.SystemText.MaximizeRibbonText = "显示功能区";
            this.MinMenuBar.SystemText.MinimizeRibbonText = "隐藏功能区";
            this.MinMenuBar.SystemText.QatAddItemText = "添加到工具栏";
            this.MinMenuBar.SystemText.QatCustomizeMenuLabel = "<b>工具栏选项</b>";
            this.MinMenuBar.SystemText.QatCustomizeText = "自定义工具栏...";
            this.MinMenuBar.SystemText.QatDialogAddButton = "添加 >>";
            this.MinMenuBar.SystemText.QatDialogCancelButton = "取消";
            this.MinMenuBar.SystemText.QatDialogCaption = "自定义工具栏";
            this.MinMenuBar.SystemText.QatDialogCategoriesLabel = "选择指令:";
            this.MinMenuBar.SystemText.QatDialogOkButton = "确定";
            this.MinMenuBar.SystemText.QatDialogPlacementCheckbox = "下移工具栏";
            this.MinMenuBar.SystemText.QatDialogRemoveButton = "移除";
            this.MinMenuBar.SystemText.QatPlaceAboveRibbonText = "上移工具栏";
            this.MinMenuBar.SystemText.QatPlaceBelowRibbonText = "下移工具栏";
            this.MinMenuBar.SystemText.QatRemoveItemText = "移除";
            this.MinMenuBar.TabGroupHeight = 14;
            this.MinMenuBar.TabIndex = 0;
            this.MinMenuBar.Text = "MinMenu";
            // 
            // FuncRibbonPanel
            // 
            this.FuncRibbonPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.FuncRibbonPanel.Controls.Add(this.WPFileRibbonBar);
            this.FuncRibbonPanel.Controls.Add(this.AutoWPRibbonBar);
            this.FuncRibbonPanel.Controls.Add(this.WPRibbonBar);
            this.FuncRibbonPanel.Controls.Add(this.PolygonRibbonBar);
            this.FuncRibbonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FuncRibbonPanel.Location = new System.Drawing.Point(0, 56);
            this.FuncRibbonPanel.Name = "FuncRibbonPanel";
            this.FuncRibbonPanel.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.FuncRibbonPanel.Size = new System.Drawing.Size(950, 87);
            // 
            // 
            // 
            this.FuncRibbonPanel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.FuncRibbonPanel.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.FuncRibbonPanel.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.FuncRibbonPanel.TabIndex = 2;
            // 
            // WPFileRibbonBar
            // 
            this.WPFileRibbonBar.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.WPFileRibbonBar.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.WPFileRibbonBar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.WPFileRibbonBar.ContainerControlProcessDialogKey = true;
            this.WPFileRibbonBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.WPFileRibbonBar.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.SaveWPButton,
            this.LoadWPButton});
            this.WPFileRibbonBar.Location = new System.Drawing.Point(562, 0);
            this.WPFileRibbonBar.Name = "WPFileRibbonBar";
            this.WPFileRibbonBar.Size = new System.Drawing.Size(134, 84);
            this.WPFileRibbonBar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.WPFileRibbonBar.TabIndex = 3;
            this.WPFileRibbonBar.Text = "航点文件";
            // 
            // 
            // 
            this.WPFileRibbonBar.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.WPFileRibbonBar.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // SaveWPButton
            // 
            this.SaveWPButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveWPButton.Image")));
            this.SaveWPButton.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.SaveWPButton.Name = "SaveWPButton";
            this.SaveWPButton.SubItemsExpandWidth = 14;
            this.SaveWPButton.Text = "保存航点";
            this.SaveWPButton.Click += new System.EventHandler(this.SaveWPButton_Click);
            // 
            // LoadWPButton
            // 
            this.LoadWPButton.Image = ((System.Drawing.Image)(resources.GetObject("LoadWPButton.Image")));
            this.LoadWPButton.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.LoadWPButton.Name = "LoadWPButton";
            this.LoadWPButton.SubItemsExpandWidth = 14;
            this.LoadWPButton.Text = "加载航点";
            this.LoadWPButton.Click += new System.EventHandler(this.LoadWPButton_Click);
            // 
            // AutoWPRibbonBar
            // 
            this.AutoWPRibbonBar.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.AutoWPRibbonBar.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.AutoWPRibbonBar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.AutoWPRibbonBar.ContainerControlProcessDialogKey = true;
            this.AutoWPRibbonBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.AutoWPRibbonBar.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.AutoWPButton});
            this.AutoWPRibbonBar.Location = new System.Drawing.Point(491, 0);
            this.AutoWPRibbonBar.Name = "AutoWPRibbonBar";
            this.AutoWPRibbonBar.Size = new System.Drawing.Size(71, 84);
            this.AutoWPRibbonBar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.AutoWPRibbonBar.TabIndex = 2;
            this.AutoWPRibbonBar.Text = "自动航点";
            // 
            // 
            // 
            this.AutoWPRibbonBar.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.AutoWPRibbonBar.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // AutoWPButton
            // 
            this.AutoWPButton.Image = ((System.Drawing.Image)(resources.GetObject("AutoWPButton.Image")));
            this.AutoWPButton.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.AutoWPButton.Name = "AutoWPButton";
            this.AutoWPButton.SubItemsExpandWidth = 14;
            this.AutoWPButton.Text = "自动航点";
            this.AutoWPButton.Click += new System.EventHandler(this.AutoWPButton_Click);
            // 
            // WPRibbonBar
            // 
            this.WPRibbonBar.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.WPRibbonBar.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.WPRibbonBar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.WPRibbonBar.ContainerControlProcessDialogKey = true;
            this.WPRibbonBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.WPRibbonBar.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer1,
            this.AddWPButton,
            this.ClearWPButton});
            this.WPRibbonBar.Location = new System.Drawing.Point(247, 0);
            this.WPRibbonBar.Name = "WPRibbonBar";
            this.WPRibbonBar.Size = new System.Drawing.Size(244, 84);
            this.WPRibbonBar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.WPRibbonBar.TabIndex = 1;
            this.WPRibbonBar.Text = "设计航线";
            // 
            // 
            // 
            this.WPRibbonBar.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.WPRibbonBar.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // itemContainer1
            // 
            // 
            // 
            // 
            this.itemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer1.Name = "itemContainer1";
            this.itemContainer1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer3,
            this.itemContainer4});
            // 
            // itemContainer3
            // 
            // 
            // 
            // 
            this.itemContainer3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer3.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemContainer3.Name = "itemContainer3";
            this.itemContainer3.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.FirstWPButton,
            this.NextWPButton,
            this.PrevWPButton});
            // 
            // FirstWPButton
            // 
            this.FirstWPButton.Name = "FirstWPButton";
            this.FirstWPButton.Text = "First";
            this.FirstWPButton.Click += new System.EventHandler(this.FirstWPButton_Click);
            // 
            // NextWPButton
            // 
            this.NextWPButton.Name = "NextWPButton";
            this.NextWPButton.Text = "Next>>";
            this.NextWPButton.Click += new System.EventHandler(this.NextWPButton_Click);
            // 
            // PrevWPButton
            // 
            this.PrevWPButton.Name = "PrevWPButton";
            this.PrevWPButton.Text = "Prev<<";
            this.PrevWPButton.Click += new System.EventHandler(this.PrevWPButton_Click);
            // 
            // itemContainer4
            // 
            // 
            // 
            // 
            this.itemContainer4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer4.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemContainer4.Name = "itemContainer4";
            this.itemContainer4.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.DeleteWPButton,
            this.CancelWPButton});
            // 
            // DeleteWPButton
            // 
            this.DeleteWPButton.Name = "DeleteWPButton";
            this.DeleteWPButton.Text = "删除选中";
            this.DeleteWPButton.Click += new System.EventHandler(this.DeleteSelectedWPButton_Click);
            // 
            // CancelWPButton
            // 
            this.CancelWPButton.Name = "CancelWPButton";
            this.CancelWPButton.Text = "取消选中";
            this.CancelWPButton.Click += new System.EventHandler(this.CancelWPButton_Click);
            // 
            // AddWPButton
            // 
            this.AddWPButton.Image = ((System.Drawing.Image)(resources.GetObject("AddWPButton.Image")));
            this.AddWPButton.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.AddWPButton.Name = "AddWPButton";
            this.AddWPButton.SubItemsExpandWidth = 14;
            this.AddWPButton.Text = "添加航点";
            this.AddWPButton.Click += new System.EventHandler(this.AddWPButton_Click);
            // 
            // ClearWPButton
            // 
            this.ClearWPButton.Image = ((System.Drawing.Image)(resources.GetObject("ClearWPButton.Image")));
            this.ClearWPButton.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.ClearWPButton.Name = "ClearWPButton";
            this.ClearWPButton.SubItemsExpandWidth = 14;
            this.ClearWPButton.Text = "清空航点";
            this.ClearWPButton.Click += new System.EventHandler(this.ClearWPButton_Click);
            // 
            // PolygonRibbonBar
            // 
            this.PolygonRibbonBar.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.PolygonRibbonBar.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.PolygonRibbonBar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.PolygonRibbonBar.ContainerControlProcessDialogKey = true;
            this.PolygonRibbonBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.PolygonRibbonBar.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer5,
            this.DrawPolygonButton,
            this.ClearPolygonButton});
            this.PolygonRibbonBar.Location = new System.Drawing.Point(3, 0);
            this.PolygonRibbonBar.Name = "PolygonRibbonBar";
            this.PolygonRibbonBar.Size = new System.Drawing.Size(244, 84);
            this.PolygonRibbonBar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.PolygonRibbonBar.TabIndex = 0;
            this.PolygonRibbonBar.Text = "区域";
            // 
            // 
            // 
            this.PolygonRibbonBar.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.PolygonRibbonBar.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // itemContainer5
            // 
            // 
            // 
            // 
            this.itemContainer5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer5.Name = "itemContainer5";
            this.itemContainer5.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer6,
            this.itemContainer7});
            // 
            // itemContainer6
            // 
            // 
            // 
            // 
            this.itemContainer6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer6.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemContainer6.Name = "itemContainer6";
            this.itemContainer6.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.FirstPolygonButton,
            this.NextPolygonButton,
            this.PrevPolygonButton});
            // 
            // FirstPolygonButton
            // 
            this.FirstPolygonButton.Name = "FirstPolygonButton";
            this.FirstPolygonButton.Text = "First";
            this.FirstPolygonButton.Click += new System.EventHandler(this.FirstPolygonButton_Click);
            // 
            // NextPolygonButton
            // 
            this.NextPolygonButton.Name = "NextPolygonButton";
            this.NextPolygonButton.Text = "Next>>";
            this.NextPolygonButton.Click += new System.EventHandler(this.NextPolygonButton_Click);
            // 
            // PrevPolygonButton
            // 
            this.PrevPolygonButton.Name = "PrevPolygonButton";
            this.PrevPolygonButton.Text = "Prev<<";
            this.PrevPolygonButton.Click += new System.EventHandler(this.PrevPolygonButton_Click);
            // 
            // itemContainer7
            // 
            // 
            // 
            // 
            this.itemContainer7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer7.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemContainer7.Name = "itemContainer7";
            this.itemContainer7.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.DeletePolygonButton,
            this.CancelPolygonButton});
            // 
            // DeletePolygonButton
            // 
            this.DeletePolygonButton.Name = "DeletePolygonButton";
            this.DeletePolygonButton.Text = "删除选中";
            this.DeletePolygonButton.Click += new System.EventHandler(this.DeleteSelectedPolygonButton_Click);
            // 
            // CancelPolygonButton
            // 
            this.CancelPolygonButton.Name = "CancelPolygonButton";
            this.CancelPolygonButton.Text = "取消选中";
            this.CancelPolygonButton.Click += new System.EventHandler(this.CancelPolygonButton_Click);
            // 
            // DrawPolygonButton
            // 
            this.DrawPolygonButton.Image = ((System.Drawing.Image)(resources.GetObject("DrawPolygonButton.Image")));
            this.DrawPolygonButton.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.DrawPolygonButton.Name = "DrawPolygonButton";
            this.DrawPolygonButton.SubItemsExpandWidth = 14;
            this.DrawPolygonButton.Text = "划定区域";
            this.DrawPolygonButton.Click += new System.EventHandler(this.DrawPolygonButton_Click);
            // 
            // ClearPolygonButton
            // 
            this.ClearPolygonButton.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.ClearPolygonButton.Name = "ClearPolygonButton";
            this.ClearPolygonButton.SubItemsExpandWidth = 14;
            this.ClearPolygonButton.Text = "清空区域";
            this.ClearPolygonButton.Click += new System.EventHandler(this.ClearPolygonButton_Click);
            // 
            // FileRibbonPanel
            // 
            this.FileRibbonPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.FileRibbonPanel.Controls.Add(this.ribbonBar1);
            this.FileRibbonPanel.Controls.Add(this.ProjectRibbonBar);
            this.FileRibbonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileRibbonPanel.Location = new System.Drawing.Point(0, 56);
            this.FileRibbonPanel.Name = "FileRibbonPanel";
            this.FileRibbonPanel.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.FileRibbonPanel.Size = new System.Drawing.Size(950, 87);
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
            this.FileRibbonPanel.TabIndex = 1;
            this.FileRibbonPanel.Visible = false;
            // 
            // ribbonBar1
            // 
            this.ribbonBar1.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.LoadTiffButton,
            this.ZoomTiffButton,
            this.TiffManagerButton});
            this.ribbonBar1.Location = new System.Drawing.Point(133, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(227, 84);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar1.TabIndex = 1;
            this.ribbonBar1.Text = "工作区";
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // LoadTiffButton
            // 
            this.LoadTiffButton.Name = "LoadTiffButton";
            this.LoadTiffButton.SubItemsExpandWidth = 14;
            this.LoadTiffButton.Text = "添加工作区";
            this.LoadTiffButton.Click += new System.EventHandler(this.LoadTiffButton_Click);
            // 
            // ZoomTiffButton
            // 
            this.ZoomTiffButton.Name = "ZoomTiffButton";
            this.ZoomTiffButton.SubItemsExpandWidth = 14;
            this.ZoomTiffButton.Text = "定位工作区";
            this.ZoomTiffButton.Click += new System.EventHandler(this.ZoomTiffButton_Click);
            // 
            // TiffManagerButton
            // 
            this.TiffManagerButton.Name = "TiffManagerButton";
            this.TiffManagerButton.SubItemsExpandWidth = 14;
            this.TiffManagerButton.Text = "管理工作区";
            this.TiffManagerButton.Click += new System.EventHandler(this.TiffManagerButton_Click);
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
            this.ProjectRibbonBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.ProjectRibbonBar.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.OpenProjectButton,
            this.SaveProjectButton});
            this.ProjectRibbonBar.Location = new System.Drawing.Point(3, 0);
            this.ProjectRibbonBar.Name = "ProjectRibbonBar";
            this.ProjectRibbonBar.Size = new System.Drawing.Size(130, 84);
            this.ProjectRibbonBar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ProjectRibbonBar.TabIndex = 0;
            this.ProjectRibbonBar.Text = "工程";
            // 
            // 
            // 
            this.ProjectRibbonBar.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ProjectRibbonBar.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // OpenProjectButton
            // 
            this.OpenProjectButton.Name = "OpenProjectButton";
            this.OpenProjectButton.SubItemsExpandWidth = 14;
            this.OpenProjectButton.Text = "打开工程";
            this.OpenProjectButton.Click += new System.EventHandler(this.LoadProjectButton_Click);
            // 
            // SaveProjectButton
            // 
            this.SaveProjectButton.Name = "SaveProjectButton";
            this.SaveProjectButton.SubItemsExpandWidth = 14;
            this.SaveProjectButton.Text = "保存工程";
            this.SaveProjectButton.Click += new System.EventHandler(this.SaveProjectButton_Click);
            // 
            // UndoButton
            // 
            this.UndoButton.KeyTips = "CTRL+Z";
            this.UndoButton.Name = "UndoButton";
            this.UndoButton.Text = "撤销";
            // 
            // ZoomToButton
            // 
            this.ZoomToButton.Name = "ZoomToButton";
            this.ZoomToButton.Text = "定位";
            this.ZoomToButton.Click += new System.EventHandler(this.ZoomTiffButton_Click);
            // 
            // FileRibbonTabItem
            // 
            this.FileRibbonTabItem.Name = "FileRibbonTabItem";
            this.FileRibbonTabItem.Panel = this.FileRibbonPanel;
            this.FileRibbonTabItem.Text = "文件";
            // 
            // FuncRibbonTabItem
            // 
            this.FuncRibbonTabItem.Checked = true;
            this.FuncRibbonTabItem.Name = "FuncRibbonTabItem";
            this.FuncRibbonTabItem.Panel = this.FuncRibbonPanel;
            this.FuncRibbonTabItem.Text = "航线规划";
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
            this.buttonChangeStyle.Text = "Style";
            // 
            // buttonStyleOffice2010Blue
            // 
            this.buttonStyleOffice2010Blue.Command = this.AppCommandTheme;
            this.buttonStyleOffice2010Blue.CommandParameter = "Office2010Blue";
            this.buttonStyleOffice2010Blue.Name = "buttonStyleOffice2010Blue";
            this.buttonStyleOffice2010Blue.OptionGroup = "style";
            this.buttonStyleOffice2010Blue.Text = "Office 2010 Blue";
            // 
            // AppCommandTheme
            // 
            this.AppCommandTheme.Name = "AppCommandTheme";
            this.AppCommandTheme.Executed += new System.EventHandler(this.AppCommandTheme_Executed);
            // 
            // buttonStyleOffice2010Silver
            // 
            this.buttonStyleOffice2010Silver.Command = this.AppCommandTheme;
            this.buttonStyleOffice2010Silver.CommandParameter = "Office2010Silver";
            this.buttonStyleOffice2010Silver.Name = "buttonStyleOffice2010Silver";
            this.buttonStyleOffice2010Silver.OptionGroup = "style";
            this.buttonStyleOffice2010Silver.Text = "Office 2010 <font color=\"Silver\"><b>Silver</b></font>";
            // 
            // buttonStyleOffice2010Black
            // 
            this.buttonStyleOffice2010Black.Command = this.AppCommandTheme;
            this.buttonStyleOffice2010Black.CommandParameter = "Office2010Black";
            this.buttonStyleOffice2010Black.Name = "buttonStyleOffice2010Black";
            this.buttonStyleOffice2010Black.OptionGroup = "style";
            this.buttonStyleOffice2010Black.Text = "Office 2010 Black";
            // 
            // buttonStyleOffice2007Blue
            // 
            this.buttonStyleOffice2007Blue.Command = this.AppCommandTheme;
            this.buttonStyleOffice2007Blue.CommandParameter = "Office2007Blue";
            this.buttonStyleOffice2007Blue.Name = "buttonStyleOffice2007Blue";
            this.buttonStyleOffice2007Blue.OptionGroup = "style";
            this.buttonStyleOffice2007Blue.Text = "Office 2007 <font color=\"Blue\"><b>Blue</b></font>";
            // 
            // buttonStyleOffice2007Black
            // 
            this.buttonStyleOffice2007Black.Command = this.AppCommandTheme;
            this.buttonStyleOffice2007Black.CommandParameter = "Office2007Black";
            this.buttonStyleOffice2007Black.Name = "buttonStyleOffice2007Black";
            this.buttonStyleOffice2007Black.OptionGroup = "style";
            this.buttonStyleOffice2007Black.Text = "Office 2007 <font color=\"black\"><b>Black</b></font>";
            // 
            // buttonStyleOffice2007Silver
            // 
            this.buttonStyleOffice2007Silver.Command = this.AppCommandTheme;
            this.buttonStyleOffice2007Silver.CommandParameter = "Office2007Silver";
            this.buttonStyleOffice2007Silver.Name = "buttonStyleOffice2007Silver";
            this.buttonStyleOffice2007Silver.OptionGroup = "style";
            this.buttonStyleOffice2007Silver.Text = "Office 2007 <font color=\"Silver\"><b>Silver</b></font>";
            // 
            // MenuSwitchButton
            // 
            this.MenuSwitchButton.ButtonHeight = 20;
            this.MenuSwitchButton.ButtonWidth = 62;
            this.MenuSwitchButton.Command = this.RibbonStateCommand;
            this.MenuSwitchButton.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.MenuSwitchButton.Margin.Bottom = 2;
            this.MenuSwitchButton.Margin.Left = 4;
            this.MenuSwitchButton.Name = "MenuSwitchButton";
            this.MenuSwitchButton.OffText = "显示";
            this.MenuSwitchButton.OnText = "隐藏";
            this.MenuSwitchButton.Tooltip = "显示/隐藏功能区";
            // 
            // RibbonStateCommand
            // 
            this.RibbonStateCommand.Name = "RibbonStateCommand";
            this.RibbonStateCommand.Executed += new System.EventHandler(this.RibbonStateCommand_Executed);
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
            this.StartButton.Text = "&File";
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
            this.RecentDocumentsLabel.Text = "Recent Documents";
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
            this.qatCustomizeItem.Tooltip = "自定义快捷访问工具栏";
            // 
            // styleManager
            // 
            this.styleManager.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Black;
            this.styleManager.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(163)))), ((int)(((byte)(26))))));
            // 
            // dockContainerItem1
            // 
            this.dockContainerItem1.Name = "dockContainerItem1";
            this.dockContainerItem1.Text = "dockContainerItem1";
            // 
            // RibbonClientPanel
            // 
            this.RibbonClientPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.RibbonClientPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.RibbonClientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RibbonClientPanel.Location = new System.Drawing.Point(5, 147);
            this.RibbonClientPanel.Name = "RibbonClientPanel";
            this.RibbonClientPanel.Size = new System.Drawing.Size(950, 384);
            // 
            // 
            // 
            this.RibbonClientPanel.Style.Class = "RibbonClientPanel";
            this.RibbonClientPanel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.RibbonClientPanel.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.RibbonClientPanel.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.RibbonClientPanel.TabIndex = 1;
            this.RibbonClientPanel.Text = "ClientPanel";
            // 
            // dotNetBarManager1
            // 
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlC);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlA);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlV);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlX);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlZ);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlY);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.Del);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.Ins);
            this.dotNetBarManager1.BottomDockSite = this.BottomDockSite;
            this.dotNetBarManager1.EnableFullSizeDock = false;
            this.dotNetBarManager1.LeftDockSite = this.LeftDockSite;
            this.dotNetBarManager1.ParentForm = null;
            this.dotNetBarManager1.RightDockSite = this.RightDockSite;
            this.dotNetBarManager1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dotNetBarManager1.ToolbarBottomDockSite = this.ToolbarBottomDockSite;
            this.dotNetBarManager1.ToolbarLeftDockSite = this.ToolbarLeftDockSite;
            this.dotNetBarManager1.ToolbarRightDockSite = this.ToolbarRightDockSite;
            this.dotNetBarManager1.ToolbarTopDockSite = this.ToolbarTopDockSite;
            this.dotNetBarManager1.TopDockSite = this.TopDockSite;
            // 
            // BottomDockSite
            // 
            this.BottomDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.BottomDockSite.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.BottomDockSite.Location = new System.Drawing.Point(5, 531);
            this.BottomDockSite.Name = "BottomDockSite";
            this.BottomDockSite.Size = new System.Drawing.Size(950, 0);
            this.BottomDockSite.TabIndex = 5;
            this.BottomDockSite.TabStop = false;
            // 
            // LeftDockSite
            // 
            this.LeftDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.LeftDockSite.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.LeftDockSite.Location = new System.Drawing.Point(5, 147);
            this.LeftDockSite.Name = "LeftDockSite";
            this.LeftDockSite.Size = new System.Drawing.Size(0, 384);
            this.LeftDockSite.TabIndex = 2;
            this.LeftDockSite.TabStop = false;
            // 
            // RightDockSite
            // 
            this.RightDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.RightDockSite.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.RightDockSite.Location = new System.Drawing.Point(955, 147);
            this.RightDockSite.Name = "RightDockSite";
            this.RightDockSite.Size = new System.Drawing.Size(0, 384);
            this.RightDockSite.TabIndex = 3;
            this.RightDockSite.TabStop = false;
            // 
            // ToolbarBottomDockSite
            // 
            this.ToolbarBottomDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.ToolbarBottomDockSite.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ToolbarBottomDockSite.Location = new System.Drawing.Point(5, 531);
            this.ToolbarBottomDockSite.Name = "ToolbarBottomDockSite";
            this.ToolbarBottomDockSite.Size = new System.Drawing.Size(950, 0);
            this.ToolbarBottomDockSite.TabIndex = 9;
            this.ToolbarBottomDockSite.TabStop = false;
            // 
            // ToolbarLeftDockSite
            // 
            this.ToolbarLeftDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.ToolbarLeftDockSite.Dock = System.Windows.Forms.DockStyle.Left;
            this.ToolbarLeftDockSite.Location = new System.Drawing.Point(5, 147);
            this.ToolbarLeftDockSite.Name = "ToolbarLeftDockSite";
            this.ToolbarLeftDockSite.Size = new System.Drawing.Size(0, 384);
            this.ToolbarLeftDockSite.TabIndex = 6;
            this.ToolbarLeftDockSite.TabStop = false;
            // 
            // ToolbarRightDockSite
            // 
            this.ToolbarRightDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.ToolbarRightDockSite.Dock = System.Windows.Forms.DockStyle.Right;
            this.ToolbarRightDockSite.Location = new System.Drawing.Point(955, 147);
            this.ToolbarRightDockSite.Name = "ToolbarRightDockSite";
            this.ToolbarRightDockSite.Size = new System.Drawing.Size(0, 384);
            this.ToolbarRightDockSite.TabIndex = 7;
            this.ToolbarRightDockSite.TabStop = false;
            // 
            // ToolbarTopDockSite
            // 
            this.ToolbarTopDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.ToolbarTopDockSite.Dock = System.Windows.Forms.DockStyle.Top;
            this.ToolbarTopDockSite.Location = new System.Drawing.Point(5, 147);
            this.ToolbarTopDockSite.Name = "ToolbarTopDockSite";
            this.ToolbarTopDockSite.Size = new System.Drawing.Size(950, 0);
            this.ToolbarTopDockSite.TabIndex = 8;
            this.ToolbarTopDockSite.TabStop = false;
            // 
            // TopDockSite
            // 
            this.TopDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.TopDockSite.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.TopDockSite.Location = new System.Drawing.Point(5, 147);
            this.TopDockSite.Name = "TopDockSite";
            this.TopDockSite.Size = new System.Drawing.Size(950, 0);
            this.TopDockSite.TabIndex = 4;
            this.TopDockSite.TabStop = false;
            // 
            // LayerReader
            // 
            this.LayerReader.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.LayerReader.Controls.Add(this.layerReaderPanel);
            this.LayerReader.Location = new System.Drawing.Point(3, 23);
            this.LayerReader.Name = "LayerReader";
            this.LayerReader.Size = new System.Drawing.Size(32, 358);
            this.LayerReader.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.LayerReader.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.LayerReader.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.LayerReader.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.LayerReader.Style.GradientAngle = 90;
            this.LayerReader.TabIndex = 0;
            // 
            // layerReaderPanel
            // 
            this.layerReaderPanel.AutoScroll = true;
            this.layerReaderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layerReaderPanel.Location = new System.Drawing.Point(0, 0);
            this.layerReaderPanel.Name = "layerReaderPanel";
            this.layerReaderPanel.Size = new System.Drawing.Size(32, 358);
            this.layerReaderPanel.TabIndex = 0;
            // 
            // microChartItem1
            // 
            this.microChartItem1.Name = "microChartItem1";
            // 
            // microChartItem2
            // 
            this.microChartItem2.Name = "microChartItem2";
            // 
            // dockContainerItem4
            // 
            this.dockContainerItem4.Name = "dockContainerItem4";
            this.dockContainerItem4.Text = "dockContainerItem4";
            // 
            // MenuLoadLayer
            // 
            this.MenuLoadLayer.AutoSize = false;
            this.MenuLoadLayer.BottomTransparent = 5;
            this.MenuLoadLayer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuLoadLayer.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.MenuLoadLayer.HightLightBackgroundColor = System.Drawing.Color.Lime;
            this.MenuLoadLayer.Image = ((System.Drawing.Image)(resources.GetObject("MenuLoadLayer.Image")));
            this.MenuLoadLayer.Margin = new System.Windows.Forms.Padding(0);
            this.MenuLoadLayer.MyChecked = false;
            this.MenuLoadLayer.Name = "MenuLoadLayer";
            this.MenuLoadLayer.Padding = new System.Windows.Forms.Padding(0, 0, 43, 38);
            this.MenuLoadLayer.Size = new System.Drawing.Size(43, 38);
            this.MenuLoadLayer.TopTransparent = 8;
            this.MenuLoadLayer.Click += new System.EventHandler(this.MenuLoadLayer_Click);
            // 
            // MenuZoomToLayer
            // 
            this.MenuZoomToLayer.AutoSize = false;
            this.MenuZoomToLayer.BottomTransparent = 5;
            this.MenuZoomToLayer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuZoomToLayer.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.MenuZoomToLayer.HightLightBackgroundColor = System.Drawing.Color.Lime;
            this.MenuZoomToLayer.Image = ((System.Drawing.Image)(resources.GetObject("MenuZoomToLayer.Image")));
            this.MenuZoomToLayer.Margin = new System.Windows.Forms.Padding(0);
            this.MenuZoomToLayer.MyChecked = false;
            this.MenuZoomToLayer.Name = "MenuZoomToLayer";
            this.MenuZoomToLayer.Padding = new System.Windows.Forms.Padding(0, 0, 43, 38);
            this.MenuZoomToLayer.Size = new System.Drawing.Size(43, 38);
            this.MenuZoomToLayer.TopTransparent = 8;
            this.MenuZoomToLayer.Click += new System.EventHandler(this.MenuZoomToLayer_Click);
            // 
            // MenuLayerManager
            // 
            this.MenuLayerManager.AutoSize = false;
            this.MenuLayerManager.BottomTransparent = 5;
            this.MenuLayerManager.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuLayerManager.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.MenuLayerManager.HightLightBackgroundColor = System.Drawing.Color.Lime;
            this.MenuLayerManager.Image = ((System.Drawing.Image)(resources.GetObject("MenuLayerManager.Image")));
            this.MenuLayerManager.Margin = new System.Windows.Forms.Padding(0);
            this.MenuLayerManager.MyChecked = false;
            this.MenuLayerManager.Name = "MenuLayerManager";
            this.MenuLayerManager.Padding = new System.Windows.Forms.Padding(0, 0, 43, 38);
            this.MenuLayerManager.Size = new System.Drawing.Size(43, 38);
            this.MenuLayerManager.TopTransparent = 8;
            this.MenuLayerManager.Click += new System.EventHandler(this.MenuLayerManager_Click);
            // 
            // MenuDrawPolygon
            // 
            this.MenuDrawPolygon.AutoSize = false;
            this.MenuDrawPolygon.BottomTransparent = 5;
            this.MenuDrawPolygon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuDrawPolygon.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.MenuDrawPolygon.HightLightBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.MenuDrawPolygon.Image = ((System.Drawing.Image)(resources.GetObject("MenuDrawPolygon.Image")));
            this.MenuDrawPolygon.Margin = new System.Windows.Forms.Padding(0);
            this.MenuDrawPolygon.MyChecked = false;
            this.MenuDrawPolygon.Name = "MenuDrawPolygon";
            this.MenuDrawPolygon.Padding = new System.Windows.Forms.Padding(0, 0, 43, 38);
            this.MenuDrawPolygon.Size = new System.Drawing.Size(43, 38);
            this.MenuDrawPolygon.TopTransparent = 8;
            this.MenuDrawPolygon.Click += new System.EventHandler(this.MenuDrawPolygon_Click);
            // 
            // MenuClearPolygon
            // 
            this.MenuClearPolygon.AutoSize = false;
            this.MenuClearPolygon.BottomTransparent = 5;
            this.MenuClearPolygon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuClearPolygon.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.MenuClearPolygon.HightLightBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.MenuClearPolygon.Image = ((System.Drawing.Image)(resources.GetObject("MenuClearPolygon.Image")));
            this.MenuClearPolygon.Margin = new System.Windows.Forms.Padding(0);
            this.MenuClearPolygon.MyChecked = false;
            this.MenuClearPolygon.Name = "MenuClearPolygon";
            this.MenuClearPolygon.Padding = new System.Windows.Forms.Padding(0, 0, 43, 38);
            this.MenuClearPolygon.Size = new System.Drawing.Size(40, 38);
            this.MenuClearPolygon.TopTransparent = 8;
            this.MenuClearPolygon.Click += new System.EventHandler(this.MenuClearPolygon_Click);
            // 
            // MenuSurveyGrid
            // 
            this.MenuSurveyGrid.AutoSize = false;
            this.MenuSurveyGrid.BottomTransparent = 5;
            this.MenuSurveyGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuSurveyGrid.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.MenuSurveyGrid.HightLightBackgroundColor = System.Drawing.Color.Aqua;
            this.MenuSurveyGrid.Image = ((System.Drawing.Image)(resources.GetObject("MenuSurveyGrid.Image")));
            this.MenuSurveyGrid.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.MenuSurveyGrid.Margin = new System.Windows.Forms.Padding(0);
            this.MenuSurveyGrid.MyChecked = false;
            this.MenuSurveyGrid.Name = "MenuSurveyGrid";
            this.MenuSurveyGrid.Padding = new System.Windows.Forms.Padding(0, 0, 43, 38);
            this.MenuSurveyGrid.Size = new System.Drawing.Size(42, 34);
            this.MenuSurveyGrid.TopTransparent = 8;
            this.MenuSurveyGrid.Click += new System.EventHandler(this.MenuSurveyGrid_Click);
            // 
            // MenuClearWP
            // 
            this.MenuClearWP.AutoSize = false;
            this.MenuClearWP.BottomTransparent = 5;
            this.MenuClearWP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuClearWP.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.MenuClearWP.HightLightBackgroundColor = System.Drawing.Color.Aqua;
            this.MenuClearWP.Image = ((System.Drawing.Image)(resources.GetObject("MenuClearWP.Image")));
            this.MenuClearWP.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.MenuClearWP.Margin = new System.Windows.Forms.Padding(0);
            this.MenuClearWP.MyChecked = false;
            this.MenuClearWP.Name = "MenuClearWP";
            this.MenuClearWP.Padding = new System.Windows.Forms.Padding(0, 0, 43, 38);
            this.MenuClearWP.Size = new System.Drawing.Size(49, 38);
            this.MenuClearWP.TopTransparent = 8;
            this.MenuClearWP.Click += new System.EventHandler(this.MenuClearWP_Click);
            // 
            // MenuReadWP
            // 
            this.MenuReadWP.AutoSize = false;
            this.MenuReadWP.BottomTransparent = 5;
            this.MenuReadWP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuReadWP.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.MenuReadWP.HightLightBackgroundColor = System.Drawing.Color.Aqua;
            this.MenuReadWP.Image = ((System.Drawing.Image)(resources.GetObject("MenuReadWP.Image")));
            this.MenuReadWP.Margin = new System.Windows.Forms.Padding(0);
            this.MenuReadWP.MyChecked = false;
            this.MenuReadWP.Name = "MenuReadWP";
            this.MenuReadWP.Padding = new System.Windows.Forms.Padding(0, 0, 43, 38);
            this.MenuReadWP.Size = new System.Drawing.Size(49, 38);
            this.MenuReadWP.TopTransparent = 8;
            this.MenuReadWP.Click += new System.EventHandler(this.MenuReadWP_Click);
            // 
            // MenuSaveWP
            // 
            this.MenuSaveWP.AutoSize = false;
            this.MenuSaveWP.BottomTransparent = 5;
            this.MenuSaveWP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuSaveWP.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.MenuSaveWP.HightLightBackgroundColor = System.Drawing.Color.Aqua;
            this.MenuSaveWP.Image = ((System.Drawing.Image)(resources.GetObject("MenuSaveWP.Image")));
            this.MenuSaveWP.Margin = new System.Windows.Forms.Padding(0);
            this.MenuSaveWP.MyChecked = false;
            this.MenuSaveWP.Name = "MenuSaveWP";
            this.MenuSaveWP.Padding = new System.Windows.Forms.Padding(0, 0, 43, 38);
            this.MenuSaveWP.Size = new System.Drawing.Size(49, 38);
            this.MenuSaveWP.TopTransparent = 8;
            this.MenuSaveWP.Click += new System.EventHandler(this.MenuSaveWP_Click);
            // 
            // toolStripConnectionControl
            // 
            this.toolStripConnectionControl.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripConnectionControl.AutoSize = false;
            this.toolStripConnectionControl.BackColor = System.Drawing.Color.Transparent;
            this.toolStripConnectionControl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolStripConnectionControl.BackgroundImage")));
            this.toolStripConnectionControl.ForeColor = System.Drawing.Color.Black;
            this.toolStripConnectionControl.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripConnectionControl.Name = "toolStripConnectionControl";
            this.toolStripConnectionControl.Padding = new System.Windows.Forms.Padding(0, 0, 200, 38);
            this.toolStripConnectionControl.Size = new System.Drawing.Size(200, 38);
            // 
            // MenuWPGobalConfig
            // 
            this.MenuWPGobalConfig.BottomTransparent = 4;
            this.MenuWPGobalConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuWPGobalConfig.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.MenuWPGobalConfig.HightLightBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.MenuWPGobalConfig.Image = ((System.Drawing.Image)(resources.GetObject("MenuWPGobalConfig.Image")));
            this.MenuWPGobalConfig.Margin = new System.Windows.Forms.Padding(0);
            this.MenuWPGobalConfig.MyChecked = false;
            this.MenuWPGobalConfig.Name = "MenuWPGobalConfig";
            this.MenuWPGobalConfig.Size = new System.Drawing.Size(49, 43);
            this.MenuWPGobalConfig.Text = "Config";
            this.MenuWPGobalConfig.TopTransparent = 8;
            this.MenuWPGobalConfig.Click += new System.EventHandler(this.WPGobalConfig_Click);
            // 
            // MainV2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 533);
            this.Controls.Add(this.RibbonClientPanel);
            this.Controls.Add(this.TopDockSite);
            this.Controls.Add(this.BottomDockSite);
            this.Controls.Add(this.LeftDockSite);
            this.Controls.Add(this.RightDockSite);
            this.Controls.Add(this.ToolbarTopDockSite);
            this.Controls.Add(this.ToolbarBottomDockSite);
            this.Controls.Add(this.ToolbarLeftDockSite);
            this.Controls.Add(this.ToolbarRightDockSite);
            this.Controls.Add(this.MinMenuBar);
            this.EnableGlass = false;
            this.FlattenMDIBorder = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(960, 534);
            this.Name = "MainV2";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainV2_KeyDown);
            this.Resize += new System.EventHandler(this.MainV2_Resize);
            this.MinMenuBar.ResumeLayout(false);
            this.MinMenuBar.PerformLayout();
            this.FuncRibbonPanel.ResumeLayout(false);
            this.FileRibbonPanel.ResumeLayout(false);
            this.LayerReader.ResumeLayout(false);
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
        private DevComponents.DotNetBar.RibbonControl MinMenuBar;
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
        private DevComponents.DotNetBar.ButtonItem OpenProjectButton;
        private DevComponents.DotNetBar.ButtonItem SaveProjectButton;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel RibbonClientPanel;
        private DevComponents.DotNetBar.Command AppCommandTheme;
        private DevComponents.DotNetBar.ButtonItem buttonChangeStyle;
        private DevComponents.DotNetBar.ButtonItem buttonStyleOffice2010Blue;
        private DevComponents.DotNetBar.ButtonItem buttonStyleOffice2010Silver;
        private DevComponents.DotNetBar.ButtonItem buttonStyleOffice2010Black;
        private DevComponents.DotNetBar.ButtonItem buttonStyleOffice2007Blue;
        private DevComponents.DotNetBar.ButtonItem buttonStyleOffice2007Black;
        private DevComponents.DotNetBar.ButtonItem buttonStyleOffice2007Silver;
        private DevComponents.DotNetBar.RibbonBar ribbonBar1;
        private DevComponents.DotNetBar.ButtonItem LoadTiffButton;
        private DevComponents.DotNetBar.ButtonItem ZoomTiffButton;
        private DevComponents.DotNetBar.ButtonItem TiffManagerButton;
        private DevComponents.DotNetBar.SwitchButtonItem MenuSwitchButton;
        private DevComponents.DotNetBar.Command RibbonStateCommand;
        private DevComponents.DotNetBar.DotNetBarManager dotNetBarManager1;
        private DevComponents.DotNetBar.DockSite BottomDockSite;
        private DevComponents.DotNetBar.DockSite LeftDockSite;
        private DevComponents.DotNetBar.DockSite RightDockSite;
        private DevComponents.DotNetBar.DockSite ToolbarBottomDockSite;
        private DevComponents.DotNetBar.DockSite ToolbarLeftDockSite;
        private DevComponents.DotNetBar.DockSite ToolbarRightDockSite;
        private DevComponents.DotNetBar.DockSite ToolbarTopDockSite;
        private DevComponents.DotNetBar.DockSite TopDockSite;
        private DevComponents.DotNetBar.RibbonPanel FuncRibbonPanel;
        private DevComponents.DotNetBar.RibbonTabItem FuncRibbonTabItem;
        private DevComponents.DotNetBar.RibbonBar PolygonRibbonBar;
        private DevComponents.DotNetBar.ButtonItem DrawPolygonButton;
        private DevComponents.DotNetBar.RibbonBar WPRibbonBar;
        private DevComponents.DotNetBar.ButtonItem AddWPButton;
        private DevComponents.DotNetBar.ButtonItem ClearWPButton;
        private DevComponents.DotNetBar.ButtonItem ClearPolygonButton;
        private DevComponents.DotNetBar.RibbonBar AutoWPRibbonBar;
        private DevComponents.DotNetBar.ButtonItem AutoWPButton;
        private DevComponents.DotNetBar.ButtonItem UndoButton;
        private DevComponents.DotNetBar.RibbonBar WPFileRibbonBar;
        private DevComponents.DotNetBar.ButtonItem SaveWPButton;
        private DevComponents.DotNetBar.ButtonItem LoadWPButton;
        private DevComponents.DotNetBar.ItemContainer itemContainer1;
        private DevComponents.DotNetBar.ItemContainer itemContainer3;
        private DevComponents.DotNetBar.ButtonItem FirstWPButton;
        private DevComponents.DotNetBar.ButtonItem NextWPButton;
        private DevComponents.DotNetBar.ButtonItem PrevWPButton;
        private DevComponents.DotNetBar.ItemContainer itemContainer4;
        private DevComponents.DotNetBar.ButtonItem DeleteWPButton;
        private DevComponents.DotNetBar.ButtonItem CancelWPButton;
        private DevComponents.DotNetBar.ItemContainer itemContainer5;
        private DevComponents.DotNetBar.ItemContainer itemContainer6;
        private DevComponents.DotNetBar.ButtonItem FirstPolygonButton;
        private DevComponents.DotNetBar.ButtonItem NextPolygonButton;
        private DevComponents.DotNetBar.ButtonItem PrevPolygonButton;
        private DevComponents.DotNetBar.ItemContainer itemContainer7;
        private DevComponents.DotNetBar.ButtonItem DeletePolygonButton;
        private DevComponents.DotNetBar.ButtonItem CancelPolygonButton;
        private DevComponents.DotNetBar.ButtonItem ZoomToButton;
        private DevComponents.DotNetBar.MicroChartItem microChartItem1;
        private DevComponents.DotNetBar.MicroChartItem microChartItem2;
        private DevComponents.DotNetBar.PanelDockContainer LayerReader;
        private Controls.Layer.LayerReader layerReaderPanel;
        private DevComponents.DotNetBar.DockContainerItem dockContainerItem4;
    }
}