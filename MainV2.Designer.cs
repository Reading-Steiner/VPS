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
            this.itemContainer4 = new DevComponents.DotNetBar.ItemContainer();
            this.AllWPButton = new DevComponents.DotNetBar.ButtonItem();
            this.CancelWPButton = new DevComponents.DotNetBar.ButtonItem();
            this.DeleteWPButton = new DevComponents.DotNetBar.ButtonItem();
            this.itemContainer1 = new DevComponents.DotNetBar.ItemContainer();
            this.itemContainer3 = new DevComponents.DotNetBar.ItemContainer();
            this.FirstWPButton = new DevComponents.DotNetBar.ButtonItem();
            this.NextWPButton = new DevComponents.DotNetBar.ButtonItem();
            this.PrevWPButton = new DevComponents.DotNetBar.ButtonItem();
            this.AddWPButton = new DevComponents.DotNetBar.ButtonItem();
            this.ClearWPButton = new DevComponents.DotNetBar.ButtonItem();
            this.PolygonRibbonBar = new DevComponents.DotNetBar.RibbonBar();
            this.itemContainer7 = new DevComponents.DotNetBar.ItemContainer();
            this.AllPolygonButton = new DevComponents.DotNetBar.ButtonItem();
            this.CancelPolygonButton = new DevComponents.DotNetBar.ButtonItem();
            this.DeletePolygonButton = new DevComponents.DotNetBar.ButtonItem();
            this.itemContainer5 = new DevComponents.DotNetBar.ItemContainer();
            this.itemContainer6 = new DevComponents.DotNetBar.ItemContainer();
            this.FirstPolygonButton = new DevComponents.DotNetBar.ButtonItem();
            this.NextPolygonButton = new DevComponents.DotNetBar.ButtonItem();
            this.PrevPolygonButton = new DevComponents.DotNetBar.ButtonItem();
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
            this.StartButton = new DevComponents.DotNetBar.Office2007StartButton();
            this.StartContainer = new DevComponents.DotNetBar.ItemContainer();
            this.itemContainer2 = new DevComponents.DotNetBar.ItemContainer();
            this.StartItemContainer = new DevComponents.DotNetBar.ItemContainer();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.StartFileContainer = new DevComponents.DotNetBar.GalleryContainer();
            this.RecentDocumentsLabel = new DevComponents.DotNetBar.LabelItem();
            this.StartBottomContainer = new DevComponents.DotNetBar.ItemContainer();
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
            this.qatCustomizeItem = new DevComponents.DotNetBar.QatCustomizeItem();
            this.styleManager = new DevComponents.DotNetBar.StyleManager(this.components);
            this.dockContainerItem1 = new DevComponents.DotNetBar.DockContainerItem();
            this.RibbonClientPanel = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.dotNetBarManager1 = new DevComponents.DotNetBar.DotNetBarManager(this.components);
            this.BottomDockSite = new DevComponents.DotNetBar.DockSite();
            this.BottomBar = new DevComponents.DotNetBar.Bar();
            this.CommandsPanel = new DevComponents.DotNetBar.PanelDockContainer();
            this.Commands = new VPS.Controls.Command.CommandsPanel();
            this.LayerManagerPanel = new DevComponents.DotNetBar.PanelDockContainer();
            this.layerManager1 = new VPS.Controls.Layer.LayerManager();
            this.panelDockContainer1 = new DevComponents.DotNetBar.PanelDockContainer();
            this.CommandsDockContainerItem = new DevComponents.DotNetBar.DockContainerItem();
            this.LayerManagerDockContainerItem = new DevComponents.DotNetBar.DockContainerItem();
            this.dockContainerItem4 = new DevComponents.DotNetBar.DockContainerItem();
            this.LeftDockSite = new DevComponents.DotNetBar.DockSite();
            this.LeftBar = new DevComponents.DotNetBar.Bar();
            this.AutoGridParamPanel = new DevComponents.DotNetBar.PanelDockContainer();
            this.GridConfig = new VPS.Controls.Grid.GridConfig();
            this.LayerReaderPanel = new DevComponents.DotNetBar.PanelDockContainer();
            this.LayerReader = new VPS.Controls.Layer.LayerReader();
            this.MainLeftBarPanel = new DevComponents.DotNetBar.PanelDockContainer();
            this.MainLeftInfo = new VPS.Controls.MainInfo.LeftMainInfo();
            this.LayerReaderDockContainerItem = new DevComponents.DotNetBar.DockContainerItem();
            this.AutoGridDockContainerItem = new DevComponents.DotNetBar.DockContainerItem();
            this.MainInfoDockContainerItem = new DevComponents.DotNetBar.DockContainerItem();
            this.RightDockSite = new DevComponents.DotNetBar.DockSite();
            this.ToolbarBottomDockSite = new DevComponents.DotNetBar.DockSite();
            this.ToolbarLeftDockSite = new DevComponents.DotNetBar.DockSite();
            this.ToolbarRightDockSite = new DevComponents.DotNetBar.DockSite();
            this.ToolbarTopDockSite = new DevComponents.DotNetBar.DockSite();
            this.TopDockSite = new DevComponents.DotNetBar.DockSite();
            this.microChartItem1 = new DevComponents.DotNetBar.MicroChartItem();
            this.microChartItem2 = new DevComponents.DotNetBar.MicroChartItem();
            this.SuperTooltip = new DevComponents.DotNetBar.SuperTooltip();
            this.toolStripConnectionControl = new VPS.Controls.ToolStripConnectionControl();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.controlContainerItem1 = new DevComponents.DotNetBar.ControlContainerItem();
            this.MinMenuBar.SuspendLayout();
            this.FuncRibbonPanel.SuspendLayout();
            this.FileRibbonPanel.SuspendLayout();
            this.BottomDockSite.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BottomBar)).BeginInit();
            this.BottomBar.SuspendLayout();
            this.CommandsPanel.SuspendLayout();
            this.LayerManagerPanel.SuspendLayout();
            this.LeftDockSite.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LeftBar)).BeginInit();
            this.LeftBar.SuspendLayout();
            this.AutoGridParamPanel.SuspendLayout();
            this.LayerReaderPanel.SuspendLayout();
            this.MainLeftBarPanel.SuspendLayout();
            this.ToolbarBottomDockSite.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.SuspendLayout();
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
            this.StartButton,
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
            this.qatCustomizeItem});
            this.MinMenuBar.Size = new System.Drawing.Size(1420, 146);
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
            this.FuncRibbonPanel.Location = new System.Drawing.Point(0, 53);
            this.FuncRibbonPanel.Name = "FuncRibbonPanel";
            this.FuncRibbonPanel.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.FuncRibbonPanel.Size = new System.Drawing.Size(1420, 90);
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
            this.WPFileRibbonBar.Location = new System.Drawing.Point(442, 0);
            this.WPFileRibbonBar.Name = "WPFileRibbonBar";
            this.WPFileRibbonBar.Size = new System.Drawing.Size(134, 87);
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
            this.SuperTooltip.SetSuperTooltip(this.SaveWPButton, new DevComponents.DotNetBar.SuperTooltipInfo("保存航点", "Ctrl + S", "将当前航点保存到文件。", null, null, DevComponents.DotNetBar.eTooltipColor.Office2003));
            this.SaveWPButton.Text = "保存航点";
            this.SaveWPButton.Click += new System.EventHandler(this.SaveWPButton_Click);
            // 
            // LoadWPButton
            // 
            this.LoadWPButton.Image = ((System.Drawing.Image)(resources.GetObject("LoadWPButton.Image")));
            this.LoadWPButton.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.LoadWPButton.Name = "LoadWPButton";
            this.LoadWPButton.SubItemsExpandWidth = 14;
            this.SuperTooltip.SetSuperTooltip(this.LoadWPButton, new DevComponents.DotNetBar.SuperTooltipInfo("加载航点", "Ctrl + O", "从文件中加载航点。", null, null, DevComponents.DotNetBar.eTooltipColor.Office2003));
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
            this.AutoWPRibbonBar.Location = new System.Drawing.Point(371, 0);
            this.AutoWPRibbonBar.Name = "AutoWPRibbonBar";
            this.AutoWPRibbonBar.Size = new System.Drawing.Size(71, 87);
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
            this.SuperTooltip.SetSuperTooltip(this.AutoWPButton, new DevComponents.DotNetBar.SuperTooltipInfo("自动航点", "Ctrl + G", "开启航点自动生成模式，根据当前区域，调整参数、设计航线。", null, null, DevComponents.DotNetBar.eTooltipColor.Office2003));
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
            this.itemContainer4,
            this.itemContainer1,
            this.AddWPButton,
            this.ClearWPButton});
            this.WPRibbonBar.Location = new System.Drawing.Point(187, 0);
            this.WPRibbonBar.Name = "WPRibbonBar";
            this.WPRibbonBar.Size = new System.Drawing.Size(184, 87);
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
            // itemContainer4
            // 
            // 
            // 
            // 
            this.itemContainer4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer4.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemContainer4.Name = "itemContainer4";
            this.itemContainer4.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.AllWPButton,
            this.CancelWPButton,
            this.DeleteWPButton});
            // 
            // AllWPButton
            // 
            this.AllWPButton.Image = ((System.Drawing.Image)(resources.GetObject("AllWPButton.Image")));
            this.AllWPButton.Name = "AllWPButton";
            this.SuperTooltip.SetSuperTooltip(this.AllWPButton, new DevComponents.DotNetBar.SuperTooltipInfo("全部航点", "Ctrl + A", "选中全部航点。", null, null, DevComponents.DotNetBar.eTooltipColor.Office2003));
            this.AllWPButton.Text = "全部选中";
            this.AllWPButton.Click += new System.EventHandler(this.AllWPButton_Click);
            // 
            // CancelWPButton
            // 
            this.CancelWPButton.Image = ((System.Drawing.Image)(resources.GetObject("CancelWPButton.Image")));
            this.CancelWPButton.Name = "CancelWPButton";
            this.SuperTooltip.SetSuperTooltip(this.CancelWPButton, new DevComponents.DotNetBar.SuperTooltipInfo("取消航点", "Ctrl + C", "取消所有被选中的航点的选中状态。", null, null, DevComponents.DotNetBar.eTooltipColor.Office2003));
            this.CancelWPButton.Text = "取消选中";
            this.CancelWPButton.Click += new System.EventHandler(this.CancelWPButton_Click);
            // 
            // DeleteWPButton
            // 
            this.DeleteWPButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteWPButton.Image")));
            this.DeleteWPButton.Name = "DeleteWPButton";
            this.SuperTooltip.SetSuperTooltip(this.DeleteWPButton, new DevComponents.DotNetBar.SuperTooltipInfo("删除航点", "Ctrl + Delete", "删除所有被选中的区域点。", null, null, DevComponents.DotNetBar.eTooltipColor.Office2003));
            this.DeleteWPButton.Text = "删除选中";
            this.DeleteWPButton.Click += new System.EventHandler(this.DeleteSelectedWPButton_Click);
            // 
            // itemContainer1
            // 
            // 
            // 
            // 
            this.itemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer1.Name = "itemContainer1";
            this.itemContainer1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer3});
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
            this.FirstWPButton.Image = ((System.Drawing.Image)(resources.GetObject("FirstWPButton.Image")));
            this.FirstWPButton.Name = "FirstWPButton";
            this.SuperTooltip.SetSuperTooltip(this.FirstWPButton, new DevComponents.DotNetBar.SuperTooltipInfo("第一个航点", "Ctrl + F", "选中第一个航点，该点为所有航点中序号最小的航点。", null, null, DevComponents.DotNetBar.eTooltipColor.Gray));
            this.FirstWPButton.Text = "First";
            this.FirstWPButton.Click += new System.EventHandler(this.FirstWPButton_Click);
            // 
            // NextWPButton
            // 
            this.NextWPButton.Image = ((System.Drawing.Image)(resources.GetObject("NextWPButton.Image")));
            this.NextWPButton.Name = "NextWPButton";
            this.SuperTooltip.SetSuperTooltip(this.NextWPButton, new DevComponents.DotNetBar.SuperTooltipInfo("下一个航点", "Ctrl +  PageDown", "选中下一个航点，该点为所有已选中航点中序号最大的航点的下一个航点。", null, null, DevComponents.DotNetBar.eTooltipColor.Office2003));
            this.NextWPButton.Text = "Next>>";
            this.NextWPButton.Click += new System.EventHandler(this.NextWPButton_Click);
            // 
            // PrevWPButton
            // 
            this.PrevWPButton.Image = ((System.Drawing.Image)(resources.GetObject("PrevWPButton.Image")));
            this.PrevWPButton.Name = "PrevWPButton";
            this.SuperTooltip.SetSuperTooltip(this.PrevWPButton, new DevComponents.DotNetBar.SuperTooltipInfo("上一个", "Ctrl +  PageUp", "选中上一个航点，该点为所有已选中航点中序号最小的航点的上一个航点。", null, null, DevComponents.DotNetBar.eTooltipColor.Office2003));
            this.PrevWPButton.Text = "Prev<<";
            this.PrevWPButton.Click += new System.EventHandler(this.PrevWPButton_Click);
            // 
            // AddWPButton
            // 
            this.AddWPButton.Image = ((System.Drawing.Image)(resources.GetObject("AddWPButton.Image")));
            this.AddWPButton.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.AddWPButton.Name = "AddWPButton";
            this.AddWPButton.SubItemsExpandWidth = 14;
            this.SuperTooltip.SetSuperTooltip(this.AddWPButton, new DevComponents.DotNetBar.SuperTooltipInfo("添加航点", "Ctrl + E", "开启添加航点模式，鼠标左键点击添加航点。", null, null, DevComponents.DotNetBar.eTooltipColor.Office2003));
            this.AddWPButton.Text = "添加航点";
            this.AddWPButton.Click += new System.EventHandler(this.AddWPButton_Click);
            // 
            // ClearWPButton
            // 
            this.ClearWPButton.Image = ((System.Drawing.Image)(resources.GetObject("ClearWPButton.Image")));
            this.ClearWPButton.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.ClearWPButton.Name = "ClearWPButton";
            this.ClearWPButton.SubItemsExpandWidth = 14;
            this.SuperTooltip.SetSuperTooltip(this.ClearWPButton, new DevComponents.DotNetBar.SuperTooltipInfo("清空航点", "Ctrl + D", "删除所有航点。", null, null, DevComponents.DotNetBar.eTooltipColor.Office2003));
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
            this.itemContainer7,
            this.itemContainer5,
            this.DrawPolygonButton,
            this.ClearPolygonButton});
            this.PolygonRibbonBar.Location = new System.Drawing.Point(3, 0);
            this.PolygonRibbonBar.Name = "PolygonRibbonBar";
            this.PolygonRibbonBar.Size = new System.Drawing.Size(184, 87);
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
            // itemContainer7
            // 
            // 
            // 
            // 
            this.itemContainer7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer7.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemContainer7.Name = "itemContainer7";
            this.itemContainer7.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.AllPolygonButton,
            this.CancelPolygonButton,
            this.DeletePolygonButton});
            // 
            // AllPolygonButton
            // 
            this.AllPolygonButton.Image = ((System.Drawing.Image)(resources.GetObject("AllPolygonButton.Image")));
            this.AllPolygonButton.Name = "AllPolygonButton";
            this.SuperTooltip.SetSuperTooltip(this.AllPolygonButton, new DevComponents.DotNetBar.SuperTooltipInfo("全部区域点", "Alt + A", "选中全部区域点。", null, null, DevComponents.DotNetBar.eTooltipColor.Office2003));
            this.AllPolygonButton.Text = "全部选中";
            this.AllPolygonButton.Click += new System.EventHandler(this.AllPolygonButton_Click);
            // 
            // CancelPolygonButton
            // 
            this.CancelPolygonButton.Image = ((System.Drawing.Image)(resources.GetObject("CancelPolygonButton.Image")));
            this.CancelPolygonButton.Name = "CancelPolygonButton";
            this.SuperTooltip.SetSuperTooltip(this.CancelPolygonButton, new DevComponents.DotNetBar.SuperTooltipInfo("取消区域点", "Alt + C", "取消所有被选中的区域点的选中状态。", null, null, DevComponents.DotNetBar.eTooltipColor.Office2003));
            this.CancelPolygonButton.Text = "取消选中";
            this.CancelPolygonButton.Click += new System.EventHandler(this.CancelPolygonButton_Click);
            // 
            // DeletePolygonButton
            // 
            this.DeletePolygonButton.Image = ((System.Drawing.Image)(resources.GetObject("DeletePolygonButton.Image")));
            this.DeletePolygonButton.Name = "DeletePolygonButton";
            this.SuperTooltip.SetSuperTooltip(this.DeletePolygonButton, new DevComponents.DotNetBar.SuperTooltipInfo("删除区域点", "Alt + Delete", "删除所有被选中的区域点。", null, null, DevComponents.DotNetBar.eTooltipColor.Office2003));
            this.DeletePolygonButton.Text = "删除选中";
            this.DeletePolygonButton.Click += new System.EventHandler(this.DeleteSelectedPolygonButton_Click);
            // 
            // itemContainer5
            // 
            // 
            // 
            // 
            this.itemContainer5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer5.Name = "itemContainer5";
            this.itemContainer5.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer6});
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
            this.FirstPolygonButton.Image = ((System.Drawing.Image)(resources.GetObject("FirstPolygonButton.Image")));
            this.FirstPolygonButton.Name = "FirstPolygonButton";
            this.SuperTooltip.SetSuperTooltip(this.FirstPolygonButton, new DevComponents.DotNetBar.SuperTooltipInfo("第一个区域点", "Alt + F", "选中第一个区域点，该点为所有区域点中序号最小的区域点。", null, null, DevComponents.DotNetBar.eTooltipColor.Office2003));
            this.FirstPolygonButton.Text = "First";
            this.FirstPolygonButton.Click += new System.EventHandler(this.FirstPolygonButton_Click);
            // 
            // NextPolygonButton
            // 
            this.NextPolygonButton.Image = ((System.Drawing.Image)(resources.GetObject("NextPolygonButton.Image")));
            this.NextPolygonButton.Name = "NextPolygonButton";
            this.SuperTooltip.SetSuperTooltip(this.NextPolygonButton, new DevComponents.DotNetBar.SuperTooltipInfo("下一个区域点", "Alt +  PageDown", "选中下一个区域点，该点为所有已选中区域点中序号最大的区域点的下一个区域点。", null, null, DevComponents.DotNetBar.eTooltipColor.Office2003));
            this.NextPolygonButton.Text = "Next>>";
            this.NextPolygonButton.Click += new System.EventHandler(this.NextPolygonButton_Click);
            // 
            // PrevPolygonButton
            // 
            this.PrevPolygonButton.Image = ((System.Drawing.Image)(resources.GetObject("PrevPolygonButton.Image")));
            this.PrevPolygonButton.Name = "PrevPolygonButton";
            this.SuperTooltip.SetSuperTooltip(this.PrevPolygonButton, new DevComponents.DotNetBar.SuperTooltipInfo("上一个区域点", "Alt +  PageUp", "选中上一个区域点，该点为所有已选中区域点中序号最小的区域点的上一个区域点。", null, null, DevComponents.DotNetBar.eTooltipColor.Office2003));
            this.PrevPolygonButton.Text = "Prev<<";
            this.PrevPolygonButton.Click += new System.EventHandler(this.PrevPolygonButton_Click);
            // 
            // DrawPolygonButton
            // 
            this.DrawPolygonButton.Image = ((System.Drawing.Image)(resources.GetObject("DrawPolygonButton.Image")));
            this.DrawPolygonButton.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.DrawPolygonButton.Name = "DrawPolygonButton";
            this.DrawPolygonButton.SubItemsExpandWidth = 14;
            this.SuperTooltip.SetSuperTooltip(this.DrawPolygonButton, new DevComponents.DotNetBar.SuperTooltipInfo("划定区域", "Alt + E", "开启划定区域点模式，鼠标左键点击添加区域点。", null, null, DevComponents.DotNetBar.eTooltipColor.Office2003));
            this.DrawPolygonButton.Text = "划定区域";
            this.DrawPolygonButton.Click += new System.EventHandler(this.DrawPolygonButton_Click);
            // 
            // ClearPolygonButton
            // 
            this.ClearPolygonButton.Image = ((System.Drawing.Image)(resources.GetObject("ClearPolygonButton.Image")));
            this.ClearPolygonButton.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.ClearPolygonButton.Name = "ClearPolygonButton";
            this.ClearPolygonButton.SubItemsExpandWidth = 14;
            this.SuperTooltip.SetSuperTooltip(this.ClearPolygonButton, new DevComponents.DotNetBar.SuperTooltipInfo("清空区域", "Alt + D", "删除所有区域点。", null, null, DevComponents.DotNetBar.eTooltipColor.Office2003));
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
            this.FileRibbonPanel.Size = new System.Drawing.Size(1420, 87);
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
            this.LoadTiffButton.Image = ((System.Drawing.Image)(resources.GetObject("LoadTiffButton.Image")));
            this.LoadTiffButton.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.LoadTiffButton.Name = "LoadTiffButton";
            this.LoadTiffButton.SubItemsExpandWidth = 14;
            this.SuperTooltip.SetSuperTooltip(this.LoadTiffButton, new DevComponents.DotNetBar.SuperTooltipInfo("加载工作区", "F5", "加载一幅Tiff栅格影像，做为项目的工作区。", null, null, DevComponents.DotNetBar.eTooltipColor.Office2003));
            this.LoadTiffButton.Text = "加载工作区";
            this.LoadTiffButton.Click += new System.EventHandler(this.LoadTiffButton_Click);
            // 
            // ZoomTiffButton
            // 
            this.ZoomTiffButton.Enabled = false;
            this.ZoomTiffButton.Image = ((System.Drawing.Image)(resources.GetObject("ZoomTiffButton.Image")));
            this.ZoomTiffButton.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.ZoomTiffButton.Name = "ZoomTiffButton";
            this.ZoomTiffButton.SubItemsExpandWidth = 14;
            this.SuperTooltip.SetSuperTooltip(this.ZoomTiffButton, new DevComponents.DotNetBar.SuperTooltipInfo("定位工作区", "F6", "移动地图到达工作区所在位置。", null, null, DevComponents.DotNetBar.eTooltipColor.Office2003));
            this.ZoomTiffButton.Text = "定位工作区";
            this.ZoomTiffButton.Click += new System.EventHandler(this.ZoomTiffButton_Click);
            // 
            // TiffManagerButton
            // 
            this.TiffManagerButton.Image = ((System.Drawing.Image)(resources.GetObject("TiffManagerButton.Image")));
            this.TiffManagerButton.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.TiffManagerButton.Name = "TiffManagerButton";
            this.TiffManagerButton.SubItemsExpandWidth = 14;
            this.SuperTooltip.SetSuperTooltip(this.TiffManagerButton, new DevComponents.DotNetBar.SuperTooltipInfo("管理工作区", "F7", "管理历史工作区。", null, null, DevComponents.DotNetBar.eTooltipColor.Office2003));
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
            this.OpenProjectButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenProjectButton.Image")));
            this.OpenProjectButton.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.OpenProjectButton.Name = "OpenProjectButton";
            this.OpenProjectButton.SubItemsExpandWidth = 14;
            this.SuperTooltip.SetSuperTooltip(this.OpenProjectButton, new DevComponents.DotNetBar.SuperTooltipInfo("打开工程", "F1", "打开飞行计划的项目工程文件。", null, null, DevComponents.DotNetBar.eTooltipColor.Office2003));
            this.OpenProjectButton.Text = "打开工程";
            this.OpenProjectButton.Click += new System.EventHandler(this.LoadProjectButton_Click);
            // 
            // SaveProjectButton
            // 
            this.SaveProjectButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveProjectButton.Image")));
            this.SaveProjectButton.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.SaveProjectButton.Name = "SaveProjectButton";
            this.SaveProjectButton.SubItemsExpandWidth = 14;
            this.SuperTooltip.SetSuperTooltip(this.SaveProjectButton, new DevComponents.DotNetBar.SuperTooltipInfo("保存工程", "F2", "将当前工作进度保存为项目工程文件。", null, null, DevComponents.DotNetBar.eTooltipColor.Office2003));
            this.SaveProjectButton.Text = "保存工程";
            this.SaveProjectButton.Click += new System.EventHandler(this.SaveProjectButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.AutoExpandOnClick = true;
            this.StartButton.CanCustomize = false;
            this.StartButton.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Image;
            this.StartButton.Image = ((System.Drawing.Image)(resources.GetObject("StartButton.Image")));
            this.StartButton.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.StartButton.ImagePaddingHorizontal = 0;
            this.StartButton.ImagePaddingVertical = 0;
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
            this.StartItemContainer.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem1,
            this.buttonItem2});
            // 
            // buttonItem1
            // 
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "工程";
            // 
            // buttonItem2
            // 
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.Text = "buttonItem2";
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
            this.RecentDocumentsLabel.Text = "最近打开文档";
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
            // UndoButton
            // 
            this.UndoButton.Enabled = false;
            this.UndoButton.Image = ((System.Drawing.Image)(resources.GetObject("UndoButton.Image")));
            this.UndoButton.KeyTips = "CTRL+Z";
            this.UndoButton.Name = "UndoButton";
            this.UndoButton.Text = "撤销";
            this.UndoButton.Click += new System.EventHandler(this.UndoButton_Click);
            // 
            // ZoomToButton
            // 
            this.ZoomToButton.Enabled = false;
            this.ZoomToButton.Image = ((System.Drawing.Image)(resources.GetObject("ZoomToButton.Image")));
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
            // qatCustomizeItem
            // 
            this.qatCustomizeItem.Name = "qatCustomizeItem";
            this.qatCustomizeItem.Tooltip = "自定义快捷访问工具栏";
            // 
            // styleManager
            // 
            this.styleManager.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue;
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
            this.RibbonClientPanel.Location = new System.Drawing.Point(340, 147);
            this.RibbonClientPanel.Name = "RibbonClientPanel";
            this.RibbonClientPanel.Size = new System.Drawing.Size(1085, 189);
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
            this.BottomDockSite.Controls.Add(this.BottomBar);
            this.BottomDockSite.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer(new DevComponents.DotNetBar.DocumentBaseContainer[] {
            ((DevComponents.DotNetBar.DocumentBaseContainer)(new DevComponents.DotNetBar.DocumentBarContainer(this.BottomBar, 1085, 323)))}, DevComponents.DotNetBar.eOrientation.Vertical);
            this.BottomDockSite.Location = new System.Drawing.Point(340, 336);
            this.BottomDockSite.Name = "BottomDockSite";
            this.BottomDockSite.Size = new System.Drawing.Size(1085, 326);
            this.BottomDockSite.TabIndex = 5;
            this.BottomDockSite.TabStop = false;
            // 
            // BottomBar
            // 
            this.BottomBar.AccessibleDescription = "DotNetBar Bar (BottomBar)";
            this.BottomBar.AccessibleName = "DotNetBar Bar";
            this.BottomBar.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.BottomBar.AutoSyncBarCaption = true;
            this.BottomBar.CanDockBottom = false;
            this.BottomBar.CanDockLeft = false;
            this.BottomBar.CanDockRight = false;
            this.BottomBar.CanDockTab = false;
            this.BottomBar.CanDockTop = false;
            this.BottomBar.CanMove = false;
            this.BottomBar.CanUndock = false;
            this.BottomBar.CloseSingleTab = true;
            this.BottomBar.Controls.Add(this.CommandsPanel);
            this.BottomBar.Controls.Add(this.LayerManagerPanel);
            this.BottomBar.Controls.Add(this.panelDockContainer1);
            this.BottomBar.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BottomBar.GrabHandleStyle = DevComponents.DotNetBar.eGrabHandleStyle.Caption;
            this.BottomBar.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.CommandsDockContainerItem,
            this.LayerManagerDockContainerItem,
            this.dockContainerItem4});
            this.BottomBar.LayoutType = DevComponents.DotNetBar.eLayoutType.DockContainer;
            this.BottomBar.Location = new System.Drawing.Point(0, 3);
            this.BottomBar.Name = "BottomBar";
            this.BottomBar.SelectedDockTab = 0;
            this.BottomBar.Size = new System.Drawing.Size(1085, 323);
            this.BottomBar.Stretch = true;
            this.BottomBar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BottomBar.TabIndex = 0;
            this.BottomBar.TabStop = false;
            this.BottomBar.Text = "航点";
            // 
            // CommandsPanel
            // 
            this.CommandsPanel.AutoScroll = true;
            this.CommandsPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CommandsPanel.Controls.Add(this.Commands);
            this.CommandsPanel.Location = new System.Drawing.Point(3, 23);
            this.CommandsPanel.Name = "CommandsPanel";
            this.CommandsPanel.Size = new System.Drawing.Size(1079, 272);
            this.CommandsPanel.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.CommandsPanel.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.CommandsPanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.CommandsPanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.CommandsPanel.Style.GradientAngle = 90;
            this.CommandsPanel.TabIndex = 0;
            // 
            // Commands
            // 
            this.Commands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Commands.Location = new System.Drawing.Point(0, 0);
            this.Commands.Name = "Commands";
            this.Commands.Size = new System.Drawing.Size(1079, 272);
            this.Commands.TabIndex = 0;
            // 
            // LayerManagerPanel
            // 
            this.LayerManagerPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.LayerManagerPanel.Controls.Add(this.layerManager1);
            this.LayerManagerPanel.Location = new System.Drawing.Point(3, 23);
            this.LayerManagerPanel.Name = "LayerManagerPanel";
            this.LayerManagerPanel.Size = new System.Drawing.Size(1079, 272);
            this.LayerManagerPanel.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.LayerManagerPanel.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.LayerManagerPanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.LayerManagerPanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.LayerManagerPanel.Style.GradientAngle = 90;
            this.LayerManagerPanel.TabIndex = 0;
            // 
            // layerManager1
            // 
            this.layerManager1.Dock = System.Windows.Forms.DockStyle.Top;
            this.layerManager1.Location = new System.Drawing.Point(0, 0);
            this.layerManager1.Name = "layerManager1";
            this.layerManager1.Size = new System.Drawing.Size(1079, 278);
            this.layerManager1.TabIndex = 0;
            // 
            // panelDockContainer1
            // 
            this.panelDockContainer1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelDockContainer1.Location = new System.Drawing.Point(3, 23);
            this.panelDockContainer1.Name = "panelDockContainer1";
            this.panelDockContainer1.Size = new System.Drawing.Size(1079, 272);
            this.panelDockContainer1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelDockContainer1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.panelDockContainer1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.panelDockContainer1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.panelDockContainer1.Style.GradientAngle = 90;
            this.panelDockContainer1.TabIndex = 0;
            // 
            // CommandsDockContainerItem
            // 
            this.CommandsDockContainerItem.Control = this.CommandsPanel;
            this.CommandsDockContainerItem.Name = "CommandsDockContainerItem";
            this.CommandsDockContainerItem.Text = "航点";
            // 
            // LayerManagerDockContainerItem
            // 
            this.LayerManagerDockContainerItem.Control = this.LayerManagerPanel;
            this.LayerManagerDockContainerItem.Name = "LayerManagerDockContainerItem";
            this.LayerManagerDockContainerItem.Text = "图层管理器";
            this.LayerManagerDockContainerItem.Visible = false;
            // 
            // dockContainerItem4
            // 
            this.dockContainerItem4.Control = this.panelDockContainer1;
            this.dockContainerItem4.Name = "dockContainerItem4";
            this.dockContainerItem4.Visible = false;
            // 
            // LeftDockSite
            // 
            this.LeftDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.LeftDockSite.Controls.Add(this.LeftBar);
            this.LeftDockSite.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer(new DevComponents.DotNetBar.DocumentBaseContainer[] {
            ((DevComponents.DotNetBar.DocumentBaseContainer)(new DevComponents.DotNetBar.DocumentBarContainer(this.LeftBar, 332, 515)))}, DevComponents.DotNetBar.eOrientation.Horizontal);
            this.LeftDockSite.Location = new System.Drawing.Point(5, 147);
            this.LeftDockSite.Name = "LeftDockSite";
            this.LeftDockSite.Size = new System.Drawing.Size(335, 515);
            this.LeftDockSite.TabIndex = 2;
            this.LeftDockSite.TabStop = false;
            // 
            // LeftBar
            // 
            this.LeftBar.AccessibleDescription = "DotNetBar Bar (LeftBar)";
            this.LeftBar.AccessibleName = "DotNetBar Bar";
            this.LeftBar.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.LeftBar.AutoSyncBarCaption = true;
            this.LeftBar.CanDockBottom = false;
            this.LeftBar.CanDockLeft = false;
            this.LeftBar.CanDockRight = false;
            this.LeftBar.CanDockTab = false;
            this.LeftBar.CanDockTop = false;
            this.LeftBar.CanMove = false;
            this.LeftBar.CanUndock = false;
            this.LeftBar.CloseSingleTab = true;
            this.LeftBar.Controls.Add(this.AutoGridParamPanel);
            this.LeftBar.Controls.Add(this.LayerReaderPanel);
            this.LeftBar.Controls.Add(this.MainLeftBarPanel);
            this.LeftBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftBar.EqualButtonSize = true;
            this.LeftBar.FadeEffect = true;
            this.LeftBar.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LeftBar.GrabHandleStyle = DevComponents.DotNetBar.eGrabHandleStyle.Caption;
            this.LeftBar.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.LayerReaderDockContainerItem,
            this.AutoGridDockContainerItem,
            this.MainInfoDockContainerItem});
            this.LeftBar.LayoutType = DevComponents.DotNetBar.eLayoutType.DockContainer;
            this.LeftBar.Location = new System.Drawing.Point(0, 0);
            this.LeftBar.Name = "LeftBar";
            this.LeftBar.SelectedDockTab = 1;
            this.LeftBar.Size = new System.Drawing.Size(332, 515);
            this.LeftBar.Stretch = true;
            this.LeftBar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.LeftBar.TabIndex = 0;
            this.LeftBar.TabStop = false;
            this.LeftBar.Text = "航飞参数";
            this.LeftBar.WrapItemsDock = true;
            // 
            // AutoGridParamPanel
            // 
            this.AutoGridParamPanel.AutoScroll = true;
            this.AutoGridParamPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.AutoGridParamPanel.Controls.Add(this.GridConfig);
            this.AutoGridParamPanel.Location = new System.Drawing.Point(3, 23);
            this.AutoGridParamPanel.Name = "AutoGridParamPanel";
            this.AutoGridParamPanel.Size = new System.Drawing.Size(326, 464);
            this.AutoGridParamPanel.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.AutoGridParamPanel.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.AutoGridParamPanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.AutoGridParamPanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.AutoGridParamPanel.Style.GradientAngle = 90;
            this.AutoGridParamPanel.TabIndex = 0;
            // 
            // GridConfig
            // 
            this.GridConfig.AutoSize = true;
            this.GridConfig.Dock = System.Windows.Forms.DockStyle.Top;
            this.GridConfig.Location = new System.Drawing.Point(0, 0);
            this.GridConfig.Name = "GridConfig";
            this.GridConfig.Size = new System.Drawing.Size(309, 559);
            this.GridConfig.TabIndex = 0;
            // 
            // LayerReaderPanel
            // 
            this.LayerReaderPanel.AutoScroll = true;
            this.LayerReaderPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.LayerReaderPanel.Controls.Add(this.LayerReader);
            this.LayerReaderPanel.Location = new System.Drawing.Point(3, 23);
            this.LayerReaderPanel.Name = "LayerReaderPanel";
            this.LayerReaderPanel.Size = new System.Drawing.Size(326, 464);
            this.LayerReaderPanel.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.LayerReaderPanel.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.LayerReaderPanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.LayerReaderPanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.LayerReaderPanel.Style.GradientAngle = 90;
            this.LayerReaderPanel.TabIndex = 0;
            // 
            // LayerReader
            // 
            this.LayerReader.AutoScroll = true;
            this.LayerReader.AutoSize = true;
            this.LayerReader.Dock = System.Windows.Forms.DockStyle.Top;
            this.LayerReader.Location = new System.Drawing.Point(0, 0);
            this.LayerReader.Name = "LayerReader";
            this.LayerReader.Size = new System.Drawing.Size(326, 460);
            this.LayerReader.TabIndex = 0;
            // 
            // MainLeftBarPanel
            // 
            this.MainLeftBarPanel.AutoScroll = true;
            this.MainLeftBarPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.MainLeftBarPanel.Controls.Add(this.MainLeftInfo);
            this.MainLeftBarPanel.Location = new System.Drawing.Point(3, 23);
            this.MainLeftBarPanel.Name = "MainLeftBarPanel";
            this.MainLeftBarPanel.Size = new System.Drawing.Size(326, 464);
            this.MainLeftBarPanel.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.MainLeftBarPanel.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.MainLeftBarPanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.MainLeftBarPanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.MainLeftBarPanel.Style.GradientAngle = 90;
            this.MainLeftBarPanel.TabIndex = 0;
            // 
            // MainLeftInfo
            // 
            this.MainLeftInfo.AutoSize = true;
            this.MainLeftInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.MainLeftInfo.Location = new System.Drawing.Point(0, 0);
            this.MainLeftInfo.Name = "MainLeftInfo";
            this.MainLeftInfo.Size = new System.Drawing.Size(326, 364);
            this.MainLeftInfo.TabIndex = 0;
            // 
            // LayerReaderDockContainerItem
            // 
            this.LayerReaderDockContainerItem.Control = this.LayerReaderPanel;
            this.LayerReaderDockContainerItem.Name = "LayerReaderDockContainerItem";
            this.LayerReaderDockContainerItem.Text = "加载图层";
            this.LayerReaderDockContainerItem.Visible = false;
            // 
            // AutoGridDockContainerItem
            // 
            this.AutoGridDockContainerItem.Control = this.AutoGridParamPanel;
            this.AutoGridDockContainerItem.Name = "AutoGridDockContainerItem";
            this.AutoGridDockContainerItem.Text = "航飞参数";
            this.AutoGridDockContainerItem.Visible = false;
            // 
            // MainInfoDockContainerItem
            // 
            this.MainInfoDockContainerItem.Control = this.MainLeftBarPanel;
            this.MainInfoDockContainerItem.Name = "MainInfoDockContainerItem";
            this.MainInfoDockContainerItem.Text = "主页";
            // 
            // RightDockSite
            // 
            this.RightDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.RightDockSite.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.RightDockSite.Location = new System.Drawing.Point(1425, 147);
            this.RightDockSite.Name = "RightDockSite";
            this.RightDockSite.Size = new System.Drawing.Size(0, 515);
            this.RightDockSite.TabIndex = 3;
            this.RightDockSite.TabStop = false;
            // 
            // ToolbarBottomDockSite
            // 
            this.ToolbarBottomDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.ToolbarBottomDockSite.Controls.Add(this.bar1);
            this.ToolbarBottomDockSite.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ToolbarBottomDockSite.Location = new System.Drawing.Point(5, 662);
            this.ToolbarBottomDockSite.Name = "ToolbarBottomDockSite";
            this.ToolbarBottomDockSite.Size = new System.Drawing.Size(1420, 23);
            this.ToolbarBottomDockSite.TabIndex = 9;
            this.ToolbarBottomDockSite.TabStop = false;
            // 
            // ToolbarLeftDockSite
            // 
            this.ToolbarLeftDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.ToolbarLeftDockSite.Dock = System.Windows.Forms.DockStyle.Left;
            this.ToolbarLeftDockSite.Location = new System.Drawing.Point(5, 147);
            this.ToolbarLeftDockSite.Name = "ToolbarLeftDockSite";
            this.ToolbarLeftDockSite.Size = new System.Drawing.Size(0, 538);
            this.ToolbarLeftDockSite.TabIndex = 6;
            this.ToolbarLeftDockSite.TabStop = false;
            // 
            // ToolbarRightDockSite
            // 
            this.ToolbarRightDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.ToolbarRightDockSite.Dock = System.Windows.Forms.DockStyle.Right;
            this.ToolbarRightDockSite.Location = new System.Drawing.Point(1425, 147);
            this.ToolbarRightDockSite.Name = "ToolbarRightDockSite";
            this.ToolbarRightDockSite.Size = new System.Drawing.Size(0, 538);
            this.ToolbarRightDockSite.TabIndex = 7;
            this.ToolbarRightDockSite.TabStop = false;
            // 
            // ToolbarTopDockSite
            // 
            this.ToolbarTopDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.ToolbarTopDockSite.Dock = System.Windows.Forms.DockStyle.Top;
            this.ToolbarTopDockSite.Location = new System.Drawing.Point(5, 147);
            this.ToolbarTopDockSite.Name = "ToolbarTopDockSite";
            this.ToolbarTopDockSite.Size = new System.Drawing.Size(1420, 0);
            this.ToolbarTopDockSite.TabIndex = 8;
            this.ToolbarTopDockSite.TabStop = false;
            // 
            // TopDockSite
            // 
            this.TopDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.TopDockSite.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.TopDockSite.Location = new System.Drawing.Point(340, 147);
            this.TopDockSite.Name = "TopDockSite";
            this.TopDockSite.Size = new System.Drawing.Size(1085, 0);
            this.TopDockSite.TabIndex = 4;
            this.TopDockSite.TabStop = false;
            // 
            // microChartItem1
            // 
            this.microChartItem1.Name = "microChartItem1";
            // 
            // microChartItem2
            // 
            this.microChartItem2.Name = "microChartItem2";
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
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(163)))), ((int)(((byte)(26))))));
            // 
            // bar1
            // 
            this.bar1.AccessibleDescription = "bar1 (bar1)";
            this.bar1.AccessibleName = "bar1";
            this.bar1.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.bar1.DockSide = DevComponents.DotNetBar.eDockSide.Bottom;
            this.bar1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.bar1.GrabHandleStyle = DevComponents.DotNetBar.eGrabHandleStyle.Office2003;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.controlContainerItem1});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(79, 23);
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 0;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // controlContainerItem1
            // 
            this.controlContainerItem1.AllowItemResize = false;
            this.controlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem1.Name = "controlContainerItem1";
            // 
            // MainV2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1430, 687);
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
            this.BottomDockSite.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BottomBar)).EndInit();
            this.BottomBar.ResumeLayout(false);
            this.CommandsPanel.ResumeLayout(false);
            this.LayerManagerPanel.ResumeLayout(false);
            this.LeftDockSite.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LeftBar)).EndInit();
            this.LeftBar.ResumeLayout(false);
            this.AutoGridParamPanel.ResumeLayout(false);
            this.AutoGridParamPanel.PerformLayout();
            this.LayerReaderPanel.ResumeLayout(false);
            this.LayerReaderPanel.PerformLayout();
            this.MainLeftBarPanel.ResumeLayout(false);
            this.MainLeftBarPanel.PerformLayout();
            this.ToolbarBottomDockSite.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

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
        private DevComponents.DotNetBar.Bar LeftBar;
        private DevComponents.DotNetBar.PanelDockContainer LayerReaderPanel;
        private DevComponents.DotNetBar.DockContainerItem LayerReaderDockContainerItem;
        private Controls.Layer.LayerReader LayerReader;
        private DevComponents.DotNetBar.PanelDockContainer AutoGridParamPanel;
        private Controls.Grid.GridConfig GridConfig;
        private DevComponents.DotNetBar.DockContainerItem AutoGridDockContainerItem;
        private DevComponents.DotNetBar.PanelDockContainer MainLeftBarPanel;
        private DevComponents.DotNetBar.DockContainerItem MainInfoDockContainerItem;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;
        private DevComponents.DotNetBar.SuperTooltip SuperTooltip;
        private DevComponents.DotNetBar.ButtonItem AllWPButton;
        private DevComponents.DotNetBar.ButtonItem AllPolygonButton;
        private DevComponents.DotNetBar.Bar BottomBar;
        private DevComponents.DotNetBar.PanelDockContainer CommandsPanel;
        private DevComponents.DotNetBar.DockContainerItem CommandsDockContainerItem;
        private Controls.Command.CommandsPanel Commands;
        private DevComponents.DotNetBar.PanelDockContainer panelDockContainer1;
        private DevComponents.DotNetBar.DockContainerItem dockContainerItem4;
        private Controls.MainInfo.LeftMainInfo MainLeftInfo;
        private DevComponents.DotNetBar.PanelDockContainer LayerManagerPanel;
        private Controls.Layer.LayerManager layerManager1;
        private DevComponents.DotNetBar.DockContainerItem LayerManagerDockContainerItem;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem1;
    }
}