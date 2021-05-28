﻿using System;

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
            DevComponents.DotNetBar.SuperTooltipInfo superTooltipInfo1 = new DevComponents.DotNetBar.SuperTooltipInfo();
            DevComponents.DotNetBar.SuperTooltipInfo superTooltipInfo2 = new DevComponents.DotNetBar.SuperTooltipInfo();
            DevComponents.DotNetBar.SuperTooltipInfo superTooltipInfo3 = new DevComponents.DotNetBar.SuperTooltipInfo();
            DevComponents.DotNetBar.SuperTooltipInfo superTooltipInfo4 = new DevComponents.DotNetBar.SuperTooltipInfo();
            DevComponents.DotNetBar.SuperTooltipInfo superTooltipInfo5 = new DevComponents.DotNetBar.SuperTooltipInfo();
            DevComponents.DotNetBar.SuperTooltipInfo superTooltipInfo6 = new DevComponents.DotNetBar.SuperTooltipInfo();
            DevComponents.DotNetBar.SuperTooltipInfo superTooltipInfo7 = new DevComponents.DotNetBar.SuperTooltipInfo();
            DevComponents.DotNetBar.SuperTooltipInfo superTooltipInfo8 = new DevComponents.DotNetBar.SuperTooltipInfo();
            DevComponents.DotNetBar.SuperTooltipInfo superTooltipInfo9 = new DevComponents.DotNetBar.SuperTooltipInfo();
            DevComponents.DotNetBar.SuperTooltipInfo superTooltipInfo10 = new DevComponents.DotNetBar.SuperTooltipInfo();
            DevComponents.DotNetBar.SuperTooltipInfo superTooltipInfo11 = new DevComponents.DotNetBar.SuperTooltipInfo();
            DevComponents.DotNetBar.SuperTooltipInfo superTooltipInfo12 = new DevComponents.DotNetBar.SuperTooltipInfo();
            DevComponents.DotNetBar.SuperTooltipInfo superTooltipInfo13 = new DevComponents.DotNetBar.SuperTooltipInfo();
            DevComponents.DotNetBar.SuperTooltipInfo superTooltipInfo14 = new DevComponents.DotNetBar.SuperTooltipInfo();
            DevComponents.DotNetBar.SuperTooltipInfo superTooltipInfo15 = new DevComponents.DotNetBar.SuperTooltipInfo();
            DevComponents.DotNetBar.SuperTooltipInfo superTooltipInfo16 = new DevComponents.DotNetBar.SuperTooltipInfo();
            DevComponents.DotNetBar.SuperTooltipInfo superTooltipInfo17 = new DevComponents.DotNetBar.SuperTooltipInfo();
            DevComponents.DotNetBar.SuperTooltipInfo superTooltipInfo18 = new DevComponents.DotNetBar.SuperTooltipInfo();
            DevComponents.DotNetBar.SuperTooltipInfo superTooltipInfo19 = new DevComponents.DotNetBar.SuperTooltipInfo();
            DevComponents.DotNetBar.SuperTooltipInfo superTooltipInfo20 = new DevComponents.DotNetBar.SuperTooltipInfo();
            DevComponents.DotNetBar.SuperTooltipInfo superTooltipInfo21 = new DevComponents.DotNetBar.SuperTooltipInfo();
            DevComponents.DotNetBar.SuperTooltipInfo superTooltipInfo22 = new DevComponents.DotNetBar.SuperTooltipInfo();
            DevComponents.DotNetBar.SuperTooltipInfo superTooltipInfo23 = new DevComponents.DotNetBar.SuperTooltipInfo();
            DevComponents.DotNetBar.SuperTooltipInfo superTooltipInfo24 = new DevComponents.DotNetBar.SuperTooltipInfo();
            this.MenuConnect = new System.Windows.Forms.ToolStripButton();
            this.MenuInitConfig = new System.Windows.Forms.ToolStripButton();
            this.MenuConfigTune = new System.Windows.Forms.ToolStripButton();
            this.MenuSimulation = new System.Windows.Forms.ToolStripButton();
            this.MenuHelp = new System.Windows.Forms.ToolStripButton();
            this.MenuArduPilot = new System.Windows.Forms.ToolStripButton();
            this.MinMenuBar = new DevComponents.DotNetBar.RibbonControl();
            this.FuncRibbonPanel = new DevComponents.DotNetBar.RibbonPanel();
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
            this.DrawWPButton = new DevComponents.DotNetBar.ButtonItem();
            this.ClearWPButton = new DevComponents.DotNetBar.ButtonItem();
            this.SaveWPButton = new DevComponents.DotNetBar.ButtonItem();
            this.LoadWPButton = new DevComponents.DotNetBar.ButtonItem();
            this.itemContainer12 = new DevComponents.DotNetBar.ItemContainer();
            this.ZoomToWPButton = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem3 = new DevComponents.DotNetBar.ButtonItem();
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
            this.SavePolygonButton = new DevComponents.DotNetBar.ButtonItem();
            this.LoadPolygonButton = new DevComponents.DotNetBar.ButtonItem();
            this.itemContainer11 = new DevComponents.DotNetBar.ItemContainer();
            this.ZoomToPolygonButton = new DevComponents.DotNetBar.ButtonItem();
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
            this.buttonStyleOffice2007Silver = new DevComponents.DotNetBar.ButtonItem();
            this.buttonStyleOffice2007Black = new DevComponents.DotNetBar.ButtonItem();
            this.MenuSwitchButton = new DevComponents.DotNetBar.SwitchButtonItem();
            this.RibbonStateCommand = new DevComponents.DotNetBar.Command(this.components);
            this.StartButton = new DevComponents.DotNetBar.Office2007StartButton();
            this.StartContainer = new DevComponents.DotNetBar.ItemContainer();
            this.itemContainer2 = new DevComponents.DotNetBar.ItemContainer();
            this.StartItemContainer = new DevComponents.DotNetBar.ItemContainer();
            this.itemContainer8 = new DevComponents.DotNetBar.ItemContainer();
            this.OpenProjectItem = new DevComponents.DotNetBar.ButtonItem();
            this.SaveProjectItem = new DevComponents.DotNetBar.ButtonItem();
            this.CloseProjectItem = new DevComponents.DotNetBar.ButtonItem();
            this.itemContainer9 = new DevComponents.DotNetBar.ItemContainer();
            this.WorkSpaceItem = new DevComponents.DotNetBar.ButtonItem();
            this.itemContainer10 = new DevComponents.DotNetBar.ItemContainer();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.ImportWPItem = new DevComponents.DotNetBar.ButtonItem();
            this.ImportPolyItem = new DevComponents.DotNetBar.ButtonItem();
            this.ImportGirdConfig = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.ExportWPItem = new DevComponents.DotNetBar.ButtonItem();
            this.ExportPolyItem = new DevComponents.DotNetBar.ButtonItem();
            this.ExportGirdConfig = new DevComponents.DotNetBar.ButtonItem();
            this.StartFileContainer = new DevComponents.DotNetBar.GalleryContainer();
            this.RecentDocumentsLabel = new DevComponents.DotNetBar.LabelItem();
            this.StartBottomContainer = new DevComponents.DotNetBar.ItemContainer();
            this.CloseVPS = new DevComponents.DotNetBar.ButtonItem();
            this.qatCustomizeItem = new DevComponents.DotNetBar.QatCustomizeItem();
            this.styleManager = new DevComponents.DotNetBar.StyleManager(this.components);
            this.dockContainerItem1 = new DevComponents.DotNetBar.DockContainerItem();
            this.RibbonClientPanel = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.topMainInfo = new VPS.Controls.MainInfo.TopMainInfo();
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
            this.LayerReaderPanel = new DevComponents.DotNetBar.PanelDockContainer();
            this.LayerReader = new VPS.Controls.Layer.LayerReader();
            this.AutoGridParamPanel = new DevComponents.DotNetBar.PanelDockContainer();
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
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.MinMenuBar.SuspendLayout();
            this.FuncRibbonPanel.SuspendLayout();
            this.FileRibbonPanel.SuspendLayout();
            this.RibbonClientPanel.SuspendLayout();
            this.BottomDockSite.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BottomBar)).BeginInit();
            this.BottomBar.SuspendLayout();
            this.CommandsPanel.SuspendLayout();
            this.LayerManagerPanel.SuspendLayout();
            this.LeftDockSite.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LeftBar)).BeginInit();
            this.LeftBar.SuspendLayout();
            this.LayerReaderPanel.SuspendLayout();
            this.MainLeftBarPanel.SuspendLayout();
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
            this.MenuArduPilot.Name = "MenuArduPilot";
            this.MenuArduPilot.Size = new System.Drawing.Size(23, 23);
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
            this.MinMenuBar.Size = new System.Drawing.Size(1323, 146);
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
            this.FuncRibbonPanel.Controls.Add(this.AutoWPRibbonBar);
            this.FuncRibbonPanel.Controls.Add(this.WPRibbonBar);
            this.FuncRibbonPanel.Controls.Add(this.PolygonRibbonBar);
            this.FuncRibbonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FuncRibbonPanel.Location = new System.Drawing.Point(0, 56);
            this.FuncRibbonPanel.Name = "FuncRibbonPanel";
            this.FuncRibbonPanel.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.FuncRibbonPanel.Size = new System.Drawing.Size(1323, 87);
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
            this.FuncRibbonPanel.Visible = true;
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
            this.AutoWPRibbonBar.Location = new System.Drawing.Point(665, 0);
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
            superTooltipInfo1.BodyText = "开启航点自动生成模式，根据当前区域，调整参数、设计航线。";
            superTooltipInfo1.Color = DevComponents.DotNetBar.eTooltipColor.Office2003;
            superTooltipInfo1.FooterText = "Ctrl + G";
            superTooltipInfo1.HeaderText = "自动航点";
            this.SuperTooltip.SetSuperTooltip(this.AutoWPButton, superTooltipInfo1);
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
            this.DrawWPButton,
            this.ClearWPButton,
            this.SaveWPButton,
            this.LoadWPButton,
            this.itemContainer12});
            this.WPRibbonBar.Location = new System.Drawing.Point(334, 0);
            this.WPRibbonBar.Name = "WPRibbonBar";
            this.WPRibbonBar.Size = new System.Drawing.Size(331, 84);
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
            superTooltipInfo2.BodyText = "选中全部航点。";
            superTooltipInfo2.Color = DevComponents.DotNetBar.eTooltipColor.Office2003;
            superTooltipInfo2.FooterText = "Ctrl + A";
            superTooltipInfo2.HeaderText = "全部航点";
            this.SuperTooltip.SetSuperTooltip(this.AllWPButton, superTooltipInfo2);
            this.AllWPButton.Text = "全部选中";
            this.AllWPButton.Click += new System.EventHandler(this.AllWPButton_Click);
            // 
            // CancelWPButton
            // 
            this.CancelWPButton.Image = ((System.Drawing.Image)(resources.GetObject("CancelWPButton.Image")));
            this.CancelWPButton.Name = "CancelWPButton";
            superTooltipInfo3.BodyText = "取消所有被选中的航点的选中状态。";
            superTooltipInfo3.Color = DevComponents.DotNetBar.eTooltipColor.Office2003;
            superTooltipInfo3.FooterText = "Ctrl + C";
            superTooltipInfo3.HeaderText = "取消航点";
            this.SuperTooltip.SetSuperTooltip(this.CancelWPButton, superTooltipInfo3);
            this.CancelWPButton.Text = "取消选中";
            this.CancelWPButton.Click += new System.EventHandler(this.CancelWPButton_Click);
            // 
            // DeleteWPButton
            // 
            this.DeleteWPButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteWPButton.Image")));
            this.DeleteWPButton.Name = "DeleteWPButton";
            superTooltipInfo4.BodyText = "删除所有被选中的区域点。";
            superTooltipInfo4.Color = DevComponents.DotNetBar.eTooltipColor.Office2003;
            superTooltipInfo4.FooterText = "Ctrl + Delete";
            superTooltipInfo4.HeaderText = "删除航点";
            this.SuperTooltip.SetSuperTooltip(this.DeleteWPButton, superTooltipInfo4);
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
            superTooltipInfo5.BodyText = "选中第一个航点，该点为所有航点中序号最小的航点。";
            superTooltipInfo5.FooterText = "Ctrl + F";
            superTooltipInfo5.HeaderText = "第一个航点";
            this.SuperTooltip.SetSuperTooltip(this.FirstWPButton, superTooltipInfo5);
            this.FirstWPButton.Text = "First";
            this.FirstWPButton.Click += new System.EventHandler(this.FirstWPButton_Click);
            // 
            // NextWPButton
            // 
            this.NextWPButton.Image = ((System.Drawing.Image)(resources.GetObject("NextWPButton.Image")));
            this.NextWPButton.Name = "NextWPButton";
            superTooltipInfo6.BodyText = "选中下一个航点，该点为所有已选中航点中序号最大的航点的下一个航点。";
            superTooltipInfo6.Color = DevComponents.DotNetBar.eTooltipColor.Office2003;
            superTooltipInfo6.FooterText = "Ctrl +  PageDown";
            superTooltipInfo6.HeaderText = "下一个航点";
            this.SuperTooltip.SetSuperTooltip(this.NextWPButton, superTooltipInfo6);
            this.NextWPButton.Text = "Next>>";
            this.NextWPButton.Click += new System.EventHandler(this.NextWPButton_Click);
            // 
            // PrevWPButton
            // 
            this.PrevWPButton.Image = ((System.Drawing.Image)(resources.GetObject("PrevWPButton.Image")));
            this.PrevWPButton.Name = "PrevWPButton";
            superTooltipInfo7.BodyText = "选中上一个航点，该点为所有已选中航点中序号最小的航点的上一个航点。";
            superTooltipInfo7.Color = DevComponents.DotNetBar.eTooltipColor.Office2003;
            superTooltipInfo7.FooterText = "Ctrl +  PageUp";
            superTooltipInfo7.HeaderText = "上一个";
            this.SuperTooltip.SetSuperTooltip(this.PrevWPButton, superTooltipInfo7);
            this.PrevWPButton.Text = "Prev<<";
            this.PrevWPButton.Click += new System.EventHandler(this.PrevWPButton_Click);
            // 
            // DrawWPButton
            // 
            this.DrawWPButton.Image = ((System.Drawing.Image)(resources.GetObject("DrawWPButton.Image")));
            this.DrawWPButton.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.DrawWPButton.Name = "DrawWPButton";
            this.DrawWPButton.SubItemsExpandWidth = 14;
            superTooltipInfo8.BodyText = "开启添加航点模式，鼠标左键点击添加航点。";
            superTooltipInfo8.Color = DevComponents.DotNetBar.eTooltipColor.Office2003;
            superTooltipInfo8.FooterText = "Ctrl + E";
            superTooltipInfo8.HeaderText = "添加航点";
            this.SuperTooltip.SetSuperTooltip(this.DrawWPButton, superTooltipInfo8);
            this.DrawWPButton.Text = "添加航点";
            this.DrawWPButton.Click += new System.EventHandler(this.DrawWPButton_Click);
            // 
            // ClearWPButton
            // 
            this.ClearWPButton.Image = ((System.Drawing.Image)(resources.GetObject("ClearWPButton.Image")));
            this.ClearWPButton.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.ClearWPButton.Name = "ClearWPButton";
            this.ClearWPButton.SubItemsExpandWidth = 14;
            superTooltipInfo9.BodyText = "删除所有航点。";
            superTooltipInfo9.Color = DevComponents.DotNetBar.eTooltipColor.Office2003;
            superTooltipInfo9.FooterText = "Ctrl + D";
            superTooltipInfo9.HeaderText = "清空航点";
            this.SuperTooltip.SetSuperTooltip(this.ClearWPButton, superTooltipInfo9);
            this.ClearWPButton.Text = "清空航点";
            this.ClearWPButton.Click += new System.EventHandler(this.ClearWPButton_Click);
            // 
            // SaveWPButton
            // 
            this.SaveWPButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveWPButton.Image")));
            this.SaveWPButton.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.SaveWPButton.Name = "SaveWPButton";
            this.SaveWPButton.SubItemsExpandWidth = 14;
            superTooltipInfo10.BodyText = "将当前航点保存到文件。";
            superTooltipInfo10.Color = DevComponents.DotNetBar.eTooltipColor.Office2003;
            superTooltipInfo10.FooterText = "Ctrl + S";
            superTooltipInfo10.HeaderText = "保存航点";
            this.SuperTooltip.SetSuperTooltip(this.SaveWPButton, superTooltipInfo10);
            this.SaveWPButton.Text = "保存航点";
            this.SaveWPButton.Click += new System.EventHandler(this.SaveWPButton_Click);
            // 
            // LoadWPButton
            // 
            this.LoadWPButton.Image = ((System.Drawing.Image)(resources.GetObject("LoadWPButton.Image")));
            this.LoadWPButton.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.LoadWPButton.Name = "LoadWPButton";
            this.LoadWPButton.SubItemsExpandWidth = 14;
            superTooltipInfo11.BodyText = "从文件中加载航点。";
            superTooltipInfo11.Color = DevComponents.DotNetBar.eTooltipColor.Office2003;
            superTooltipInfo11.FooterText = "Ctrl + O";
            superTooltipInfo11.HeaderText = "加载航点";
            this.SuperTooltip.SetSuperTooltip(this.LoadWPButton, superTooltipInfo11);
            this.LoadWPButton.Text = "加载航点";
            this.LoadWPButton.Click += new System.EventHandler(this.LoadWPButton_Click);
            // 
            // itemContainer12
            // 
            // 
            // 
            // 
            this.itemContainer12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer12.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemContainer12.Name = "itemContainer12";
            this.itemContainer12.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.ZoomToWPButton,
            this.buttonItem3});
            // 
            // ZoomToWPButton
            // 
            this.ZoomToWPButton.Image = ((System.Drawing.Image)(resources.GetObject("ZoomToWPButton.Image")));
            this.ZoomToWPButton.Name = "ZoomToWPButton";
            this.ZoomToWPButton.Text = "buttonItem4";
            this.ZoomToWPButton.Click += new System.EventHandler(this.ZoomToWPButton_Click);
            // 
            // buttonItem3
            // 
            this.buttonItem3.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem3.Image")));
            this.buttonItem3.Name = "buttonItem3";
            this.buttonItem3.Text = "buttonItem3";
            this.buttonItem3.Click += new System.EventHandler(this.MakerStyleButton_Click);
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
            this.ClearPolygonButton,
            this.SavePolygonButton,
            this.LoadPolygonButton,
            this.itemContainer11});
            this.PolygonRibbonBar.Location = new System.Drawing.Point(3, 0);
            this.PolygonRibbonBar.Name = "PolygonRibbonBar";
            this.PolygonRibbonBar.Size = new System.Drawing.Size(331, 84);
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
            superTooltipInfo12.BodyText = "选中全部区域点。";
            superTooltipInfo12.Color = DevComponents.DotNetBar.eTooltipColor.Office2003;
            superTooltipInfo12.FooterText = "Alt + A";
            superTooltipInfo12.HeaderText = "全部区域点";
            this.SuperTooltip.SetSuperTooltip(this.AllPolygonButton, superTooltipInfo12);
            this.AllPolygonButton.Text = "全部选中";
            this.AllPolygonButton.Click += new System.EventHandler(this.AllPolygonButton_Click);
            // 
            // CancelPolygonButton
            // 
            this.CancelPolygonButton.Image = ((System.Drawing.Image)(resources.GetObject("CancelPolygonButton.Image")));
            this.CancelPolygonButton.Name = "CancelPolygonButton";
            superTooltipInfo13.BodyText = "取消所有被选中的区域点的选中状态。";
            superTooltipInfo13.Color = DevComponents.DotNetBar.eTooltipColor.Office2003;
            superTooltipInfo13.FooterText = "Alt + C";
            superTooltipInfo13.HeaderText = "取消区域点";
            this.SuperTooltip.SetSuperTooltip(this.CancelPolygonButton, superTooltipInfo13);
            this.CancelPolygonButton.Text = "取消选中";
            this.CancelPolygonButton.Click += new System.EventHandler(this.CancelPolygonButton_Click);
            // 
            // DeletePolygonButton
            // 
            this.DeletePolygonButton.Image = ((System.Drawing.Image)(resources.GetObject("DeletePolygonButton.Image")));
            this.DeletePolygonButton.Name = "DeletePolygonButton";
            superTooltipInfo14.BodyText = "删除所有被选中的区域点。";
            superTooltipInfo14.Color = DevComponents.DotNetBar.eTooltipColor.Office2003;
            superTooltipInfo14.FooterText = "Alt + Delete";
            superTooltipInfo14.HeaderText = "删除区域点";
            this.SuperTooltip.SetSuperTooltip(this.DeletePolygonButton, superTooltipInfo14);
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
            superTooltipInfo15.BodyText = "选中第一个区域点，该点为所有区域点中序号最小的区域点。";
            superTooltipInfo15.Color = DevComponents.DotNetBar.eTooltipColor.Office2003;
            superTooltipInfo15.FooterText = "Alt + F";
            superTooltipInfo15.HeaderText = "第一个区域点";
            this.SuperTooltip.SetSuperTooltip(this.FirstPolygonButton, superTooltipInfo15);
            this.FirstPolygonButton.Text = "First";
            this.FirstPolygonButton.Click += new System.EventHandler(this.FirstPolygonButton_Click);
            // 
            // NextPolygonButton
            // 
            this.NextPolygonButton.Image = ((System.Drawing.Image)(resources.GetObject("NextPolygonButton.Image")));
            this.NextPolygonButton.Name = "NextPolygonButton";
            superTooltipInfo16.BodyText = "选中下一个区域点，该点为所有已选中区域点中序号最大的区域点的下一个区域点。";
            superTooltipInfo16.Color = DevComponents.DotNetBar.eTooltipColor.Office2003;
            superTooltipInfo16.FooterText = "Alt +  PageDown";
            superTooltipInfo16.HeaderText = "下一个区域点";
            this.SuperTooltip.SetSuperTooltip(this.NextPolygonButton, superTooltipInfo16);
            this.NextPolygonButton.Text = "Next>>";
            this.NextPolygonButton.Click += new System.EventHandler(this.NextPolygonButton_Click);
            // 
            // PrevPolygonButton
            // 
            this.PrevPolygonButton.Image = ((System.Drawing.Image)(resources.GetObject("PrevPolygonButton.Image")));
            this.PrevPolygonButton.Name = "PrevPolygonButton";
            superTooltipInfo17.BodyText = "选中上一个区域点，该点为所有已选中区域点中序号最小的区域点的上一个区域点。";
            superTooltipInfo17.Color = DevComponents.DotNetBar.eTooltipColor.Office2003;
            superTooltipInfo17.FooterText = "Alt +  PageUp";
            superTooltipInfo17.HeaderText = "上一个区域点";
            this.SuperTooltip.SetSuperTooltip(this.PrevPolygonButton, superTooltipInfo17);
            this.PrevPolygonButton.Text = "Prev<<";
            this.PrevPolygonButton.Click += new System.EventHandler(this.PrevPolygonButton_Click);
            // 
            // DrawPolygonButton
            // 
            this.DrawPolygonButton.Image = ((System.Drawing.Image)(resources.GetObject("DrawPolygonButton.Image")));
            this.DrawPolygonButton.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.DrawPolygonButton.Name = "DrawPolygonButton";
            this.DrawPolygonButton.SubItemsExpandWidth = 14;
            superTooltipInfo18.BodyText = "开启划定区域点模式，鼠标左键点击添加区域点。";
            superTooltipInfo18.Color = DevComponents.DotNetBar.eTooltipColor.Office2003;
            superTooltipInfo18.FooterText = "Alt + E";
            superTooltipInfo18.HeaderText = "划定区域";
            this.SuperTooltip.SetSuperTooltip(this.DrawPolygonButton, superTooltipInfo18);
            this.DrawPolygonButton.Text = "划定区域";
            this.DrawPolygonButton.Click += new System.EventHandler(this.DrawPolygonButton_Click);
            // 
            // ClearPolygonButton
            // 
            this.ClearPolygonButton.Image = ((System.Drawing.Image)(resources.GetObject("ClearPolygonButton.Image")));
            this.ClearPolygonButton.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.ClearPolygonButton.Name = "ClearPolygonButton";
            this.ClearPolygonButton.SubItemsExpandWidth = 14;
            superTooltipInfo19.BodyText = "删除所有区域点。";
            superTooltipInfo19.Color = DevComponents.DotNetBar.eTooltipColor.Office2003;
            superTooltipInfo19.FooterText = "Alt + D";
            superTooltipInfo19.HeaderText = "清空区域";
            this.SuperTooltip.SetSuperTooltip(this.ClearPolygonButton, superTooltipInfo19);
            this.ClearPolygonButton.Text = "清空区域";
            this.ClearPolygonButton.Click += new System.EventHandler(this.ClearPolygonButton_Click);
            // 
            // SavePolygonButton
            // 
            this.SavePolygonButton.Image = ((System.Drawing.Image)(resources.GetObject("SavePolygonButton.Image")));
            this.SavePolygonButton.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.SavePolygonButton.Name = "SavePolygonButton";
            this.SavePolygonButton.SubItemsExpandWidth = 14;
            this.SavePolygonButton.Text = "保存区域";
            this.SavePolygonButton.Click += new System.EventHandler(this.SavePolygonButton_Click);
            // 
            // LoadPolygonButton
            // 
            this.LoadPolygonButton.Image = ((System.Drawing.Image)(resources.GetObject("LoadPolygonButton.Image")));
            this.LoadPolygonButton.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.LoadPolygonButton.Name = "LoadPolygonButton";
            this.LoadPolygonButton.SubItemsExpandWidth = 14;
            this.LoadPolygonButton.Text = "加载区域";
            this.LoadPolygonButton.Click += new System.EventHandler(this.LoadPolygonButton_Click);
            // 
            // itemContainer11
            // 
            // 
            // 
            // 
            this.itemContainer11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer11.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemContainer11.Name = "itemContainer11";
            this.itemContainer11.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.ZoomToPolygonButton});
            // 
            // ZoomToPolygonButton
            // 
            this.ZoomToPolygonButton.Image = ((System.Drawing.Image)(resources.GetObject("ZoomToPolygonButton.Image")));
            this.ZoomToPolygonButton.Name = "ZoomToPolygonButton";
            this.ZoomToPolygonButton.Text = "buttonItem3";
            this.ZoomToPolygonButton.Click += new System.EventHandler(this.ZoomToPolygonButton_Click);
            // 
            // FileRibbonPanel
            // 
            this.FileRibbonPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.FileRibbonPanel.Controls.Add(this.ribbonBar1);
            this.FileRibbonPanel.Controls.Add(this.ProjectRibbonBar);
            this.FileRibbonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileRibbonPanel.Location = new System.Drawing.Point(0, 0);
            this.FileRibbonPanel.Name = "FileRibbonPanel";
            this.FileRibbonPanel.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.FileRibbonPanel.Size = new System.Drawing.Size(1323, 143);
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
            this.ribbonBar1.Location = new System.Drawing.Point(137, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(233, 140);
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
            superTooltipInfo20.BodyText = "加载一幅Tiff栅格影像，做为项目的工作区。";
            superTooltipInfo20.Color = DevComponents.DotNetBar.eTooltipColor.Office2003;
            superTooltipInfo20.FooterText = "F5";
            superTooltipInfo20.HeaderText = "加载工作区";
            this.SuperTooltip.SetSuperTooltip(this.LoadTiffButton, superTooltipInfo20);
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
            superTooltipInfo21.BodyText = "移动地图到达工作区所在位置。";
            superTooltipInfo21.Color = DevComponents.DotNetBar.eTooltipColor.Office2003;
            superTooltipInfo21.FooterText = "F6";
            superTooltipInfo21.HeaderText = "定位工作区";
            this.SuperTooltip.SetSuperTooltip(this.ZoomTiffButton, superTooltipInfo21);
            this.ZoomTiffButton.Text = "定位工作区";
            this.ZoomTiffButton.Click += new System.EventHandler(this.ZoomTiffButton_Click);
            // 
            // TiffManagerButton
            // 
            this.TiffManagerButton.Image = ((System.Drawing.Image)(resources.GetObject("TiffManagerButton.Image")));
            this.TiffManagerButton.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.TiffManagerButton.Name = "TiffManagerButton";
            this.TiffManagerButton.SubItemsExpandWidth = 14;
            superTooltipInfo22.BodyText = "管理历史工作区。";
            superTooltipInfo22.Color = DevComponents.DotNetBar.eTooltipColor.Office2003;
            superTooltipInfo22.FooterText = "F7";
            superTooltipInfo22.HeaderText = "管理工作区";
            this.SuperTooltip.SetSuperTooltip(this.TiffManagerButton, superTooltipInfo22);
            this.TiffManagerButton.Text = "管理工作区";
            this.TiffManagerButton.Click += new System.EventHandler(this.ManagerTiffButton_Click);
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
            this.ProjectRibbonBar.Size = new System.Drawing.Size(134, 140);
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
            superTooltipInfo23.BodyText = "打开飞行计划的项目工程文件。";
            superTooltipInfo23.Color = DevComponents.DotNetBar.eTooltipColor.Office2003;
            superTooltipInfo23.FooterText = "F1";
            superTooltipInfo23.HeaderText = "打开工程";
            this.SuperTooltip.SetSuperTooltip(this.OpenProjectButton, superTooltipInfo23);
            this.OpenProjectButton.Text = "打开工程";
            this.OpenProjectButton.Click += new System.EventHandler(this.LoadProjectButton_Click);
            // 
            // SaveProjectButton
            // 
            this.SaveProjectButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveProjectButton.Image")));
            this.SaveProjectButton.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.SaveProjectButton.Name = "SaveProjectButton";
            this.SaveProjectButton.SubItemsExpandWidth = 14;
            superTooltipInfo24.BodyText = "将当前工作进度保存为项目工程文件。";
            superTooltipInfo24.Color = DevComponents.DotNetBar.eTooltipColor.Office2003;
            superTooltipInfo24.FooterText = "F2";
            superTooltipInfo24.HeaderText = "保存工程";
            this.SuperTooltip.SetSuperTooltip(this.SaveProjectButton, superTooltipInfo24);
            this.SaveProjectButton.Text = "保存工程";
            this.SaveProjectButton.Click += new System.EventHandler(this.SaveProjectButton_Click);
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
            this.buttonStyleOffice2007Silver,
            this.buttonStyleOffice2007Black});
            this.buttonChangeStyle.Text = "界面风格";
            // 
            // buttonStyleOffice2010Blue
            // 
            this.buttonStyleOffice2010Blue.Command = this.AppCommandTheme;
            this.buttonStyleOffice2010Blue.CommandParameter = "Office2010Blue";
            this.buttonStyleOffice2010Blue.Name = "buttonStyleOffice2010Blue";
            this.buttonStyleOffice2010Blue.OptionGroup = "style";
            this.buttonStyleOffice2010Blue.Text = "Office 2010 <font color=\"Blue\"><b>(蓝色样式)(B)</b></font>";
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
            this.buttonStyleOffice2010Silver.Text = "Office 2010 <font color=\"Silver\"><b>(银色样式)(S)</b></font>";
            // 
            // buttonStyleOffice2010Black
            // 
            this.buttonStyleOffice2010Black.Command = this.AppCommandTheme;
            this.buttonStyleOffice2010Black.CommandParameter = "Office2010Black";
            this.buttonStyleOffice2010Black.Name = "buttonStyleOffice2010Black";
            this.buttonStyleOffice2010Black.OptionGroup = "style";
            this.buttonStyleOffice2010Black.Text = "Office 2010 <font color=\"Black\"><b>(黑色样式)(L)</b></font>";
            // 
            // buttonStyleOffice2007Blue
            // 
            this.buttonStyleOffice2007Blue.Command = this.AppCommandTheme;
            this.buttonStyleOffice2007Blue.CommandParameter = "Office2007Blue";
            this.buttonStyleOffice2007Blue.Name = "buttonStyleOffice2007Blue";
            this.buttonStyleOffice2007Blue.OptionGroup = "style";
            this.buttonStyleOffice2007Blue.Text = "Office 2007 <font color=\"Blue\"><b>(蓝色样式)(B)</b></font>";
            // 
            // buttonStyleOffice2007Silver
            // 
            this.buttonStyleOffice2007Silver.Command = this.AppCommandTheme;
            this.buttonStyleOffice2007Silver.CommandParameter = "Office2007Silver";
            this.buttonStyleOffice2007Silver.Name = "buttonStyleOffice2007Silver";
            this.buttonStyleOffice2007Silver.OptionGroup = "style";
            this.buttonStyleOffice2007Silver.Text = "Office 2007 <font color=\"Silver\"><b>(银色样式)(S)</b></font>";
            // 
            // buttonStyleOffice2007Black
            // 
            this.buttonStyleOffice2007Black.Command = this.AppCommandTheme;
            this.buttonStyleOffice2007Black.CommandParameter = "Office2007Black";
            this.buttonStyleOffice2007Black.Name = "buttonStyleOffice2007Black";
            this.buttonStyleOffice2007Black.OptionGroup = "style";
            this.buttonStyleOffice2007Black.Text = "Office 2007 <font color=\"Black\"><b>(黑色样式)(L)</b></font>";
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
            this.StartItemContainer.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer8,
            this.itemContainer9,
            this.itemContainer10});
            // 
            // itemContainer8
            // 
            // 
            // 
            // 
            this.itemContainer8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer8.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.itemContainer8.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemContainer8.Name = "itemContainer8";
            this.itemContainer8.ResizeItemsToFit = false;
            this.itemContainer8.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.OpenProjectItem,
            this.SaveProjectItem,
            this.CloseProjectItem});
            // 
            // OpenProjectItem
            // 
            this.OpenProjectItem.Name = "OpenProjectItem";
            this.OpenProjectItem.Text = "打开工程";
            this.OpenProjectItem.Click += new System.EventHandler(this.OpenProjectItem_Click);
            // 
            // SaveProjectItem
            // 
            this.SaveProjectItem.Name = "SaveProjectItem";
            this.SaveProjectItem.Text = "保存工程";
            this.SaveProjectItem.Click += new System.EventHandler(this.SaveProjectItem_Click);
            // 
            // CloseProjectItem
            // 
            this.CloseProjectItem.Name = "CloseProjectItem";
            this.CloseProjectItem.Text = "关闭工程";
            this.CloseProjectItem.Click += new System.EventHandler(this.CloseProjectItem_Click);
            // 
            // itemContainer9
            // 
            // 
            // 
            // 
            this.itemContainer9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer9.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.itemContainer9.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemContainer9.Name = "itemContainer9";
            this.itemContainer9.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.WorkSpaceItem});
            // 
            // WorkSpaceItem
            // 
            this.WorkSpaceItem.Name = "WorkSpaceItem";
            this.WorkSpaceItem.Text = "新建工作区";
            this.WorkSpaceItem.Click += new System.EventHandler(this.WorkSpaceItem_Click);
            // 
            // itemContainer10
            // 
            // 
            // 
            // 
            this.itemContainer10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer10.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.itemContainer10.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemContainer10.Name = "itemContainer10";
            this.itemContainer10.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem1,
            this.buttonItem2});
            // 
            // buttonItem1
            // 
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.ImportWPItem,
            this.ImportPolyItem,
            this.ImportGirdConfig});
            this.buttonItem1.Text = "导入";
            // 
            // ImportWPItem
            // 
            this.ImportWPItem.Name = "ImportWPItem";
            this.ImportWPItem.Text = "加载航点";
            this.ImportWPItem.Click += new System.EventHandler(this.ImportWPItem_Click);
            // 
            // ImportPolyItem
            // 
            this.ImportPolyItem.Name = "ImportPolyItem";
            this.ImportPolyItem.Text = "加载区域点";
            this.ImportPolyItem.Click += new System.EventHandler(this.ImportPolyItem_Click);
            // 
            // ImportGirdConfig
            // 
            this.ImportGirdConfig.Name = "ImportGirdConfig";
            this.ImportGirdConfig.Text = "加载自动航点参数";
            this.ImportGirdConfig.Click += new System.EventHandler(this.ImportGirdConfig_Click);
            // 
            // buttonItem2
            // 
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.ExportWPItem,
            this.ExportPolyItem,
            this.ExportGirdConfig});
            this.buttonItem2.Text = "导出";
            // 
            // ExportWPItem
            // 
            this.ExportWPItem.Name = "ExportWPItem";
            this.ExportWPItem.Text = "导出航点";
            this.ExportWPItem.Click += new System.EventHandler(this.ExportWPItem_Click);
            // 
            // ExportPolyItem
            // 
            this.ExportPolyItem.Name = "ExportPolyItem";
            this.ExportPolyItem.Text = "导出区域点";
            this.ExportPolyItem.Click += new System.EventHandler(this.ExportPolyItem_Click);
            // 
            // ExportGirdConfig
            // 
            this.ExportGirdConfig.Name = "ExportGirdConfig";
            this.ExportGirdConfig.Text = "导出自动航点参数";
            this.ExportGirdConfig.Click += new System.EventHandler(this.ExportGirdConfig_Click);
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
            this.StartBottomContainer.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.CloseVPS});
            // 
            // CloseVPS
            // 
            this.CloseVPS.Name = "CloseVPS";
            this.CloseVPS.Text = "关闭";
            // 
            // qatCustomizeItem
            // 
            this.qatCustomizeItem.Name = "qatCustomizeItem";
            this.qatCustomizeItem.Tooltip = "自定义快捷访问工具栏";
            // 
            // styleManager
            // 
            this.styleManager.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue;
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
            this.RibbonClientPanel.Controls.Add(this.topMainInfo);
            this.RibbonClientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RibbonClientPanel.Location = new System.Drawing.Point(340, 147);
            this.RibbonClientPanel.Name = "RibbonClientPanel";
            this.RibbonClientPanel.Size = new System.Drawing.Size(988, 387);
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
            // topMainInfo
            // 
            this.topMainInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.topMainInfo.Location = new System.Drawing.Point(0, 0);
            this.topMainInfo.Name = "topMainInfo";
            this.topMainInfo.Size = new System.Drawing.Size(988, 23);
            this.topMainInfo.TabIndex = 0;
            this.topMainInfo.Visible = false;
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
            ((DevComponents.DotNetBar.DocumentBaseContainer)(new DevComponents.DotNetBar.DocumentBarContainer(this.BottomBar, 988, 323)))}, DevComponents.DotNetBar.eOrientation.Vertical);
            this.BottomDockSite.Location = new System.Drawing.Point(340, 534);
            this.BottomDockSite.Name = "BottomDockSite";
            this.BottomDockSite.Size = new System.Drawing.Size(988, 326);
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
            this.BottomBar.Size = new System.Drawing.Size(988, 323);
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
            this.CommandsPanel.Size = new System.Drawing.Size(982, 297);
            this.CommandsPanel.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.CommandsPanel.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.CommandsPanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.CommandsPanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.CommandsPanel.Style.GradientAngle = 90;
            this.CommandsPanel.TabIndex = 0;
            this.CommandsPanel.Visible = true;
            // 
            // Commands
            // 
            this.Commands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Commands.Location = new System.Drawing.Point(0, 0);
            this.Commands.Name = "Commands";
            this.Commands.Size = new System.Drawing.Size(982, 297);
            this.Commands.TabIndex = 0;
            // 
            // LayerManagerPanel
            // 
            this.LayerManagerPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.LayerManagerPanel.Controls.Add(this.layerManager1);
            this.LayerManagerPanel.Location = new System.Drawing.Point(3, 23);
            this.LayerManagerPanel.Name = "LayerManagerPanel";
            this.LayerManagerPanel.Size = new System.Drawing.Size(982, 297);
            this.LayerManagerPanel.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.LayerManagerPanel.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.LayerManagerPanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.LayerManagerPanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.LayerManagerPanel.Style.GradientAngle = 90;
            this.LayerManagerPanel.TabIndex = 0;
            this.LayerManagerPanel.Visible = true;
            // 
            // layerManager1
            // 
            this.layerManager1.Dock = System.Windows.Forms.DockStyle.Top;
            this.layerManager1.Location = new System.Drawing.Point(0, 0);
            this.layerManager1.Name = "layerManager1";
            this.layerManager1.Size = new System.Drawing.Size(982, 278);
            this.layerManager1.TabIndex = 0;
            // 
            // panelDockContainer1
            // 
            this.panelDockContainer1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelDockContainer1.Location = new System.Drawing.Point(3, 23);
            this.panelDockContainer1.Name = "panelDockContainer1";
            this.panelDockContainer1.Size = new System.Drawing.Size(982, 297);
            this.panelDockContainer1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelDockContainer1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.panelDockContainer1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.panelDockContainer1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.panelDockContainer1.Style.GradientAngle = 90;
            this.panelDockContainer1.TabIndex = 0;
            this.panelDockContainer1.Visible = true;
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
            ((DevComponents.DotNetBar.DocumentBaseContainer)(new DevComponents.DotNetBar.DocumentBarContainer(this.LeftBar, 332, 713)))}, DevComponents.DotNetBar.eOrientation.Horizontal);
            this.LeftDockSite.Location = new System.Drawing.Point(5, 147);
            this.LeftDockSite.Name = "LeftDockSite";
            this.LeftDockSite.Size = new System.Drawing.Size(335, 713);
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
            this.LeftBar.Controls.Add(this.LayerReaderPanel);
            this.LeftBar.Controls.Add(this.AutoGridParamPanel);
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
            this.LeftBar.Size = new System.Drawing.Size(332, 713);
            this.LeftBar.Stretch = true;
            this.LeftBar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.LeftBar.TabIndex = 0;
            this.LeftBar.TabStop = false;
            this.LeftBar.Text = "主页";
            this.LeftBar.WrapItemsDock = true;
            // 
            // LayerReaderPanel
            // 
            this.LayerReaderPanel.AutoScroll = true;
            this.LayerReaderPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.LayerReaderPanel.Controls.Add(this.LayerReader);
            this.LayerReaderPanel.Location = new System.Drawing.Point(3, 23);
            this.LayerReaderPanel.Name = "LayerReaderPanel";
            this.LayerReaderPanel.Size = new System.Drawing.Size(326, 687);
            this.LayerReaderPanel.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.LayerReaderPanel.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.LayerReaderPanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.LayerReaderPanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.LayerReaderPanel.Style.GradientAngle = 90;
            this.LayerReaderPanel.TabIndex = 0;
            this.LayerReaderPanel.Visible = true;
            // 
            // LayerReader
            // 
            this.LayerReader.AutoScroll = true;
            this.LayerReader.AutoSize = true;
            this.LayerReader.Dock = System.Windows.Forms.DockStyle.Top;
            this.LayerReader.Location = new System.Drawing.Point(0, 0);
            this.LayerReader.Name = "LayerReader";
            this.LayerReader.Size = new System.Drawing.Size(326, 547);
            this.LayerReader.TabIndex = 0;
            // 
            // AutoGridParamPanel
            // 
            this.AutoGridParamPanel.AutoScroll = true;
            this.AutoGridParamPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.AutoGridParamPanel.Location = new System.Drawing.Point(3, 23);
            this.AutoGridParamPanel.Name = "AutoGridParamPanel";
            this.AutoGridParamPanel.Size = new System.Drawing.Size(326, 687);
            this.AutoGridParamPanel.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.AutoGridParamPanel.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.AutoGridParamPanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.AutoGridParamPanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.AutoGridParamPanel.Style.GradientAngle = 90;
            this.AutoGridParamPanel.TabIndex = 0;
            this.AutoGridParamPanel.Visible = true;
            // 
            // MainLeftBarPanel
            // 
            this.MainLeftBarPanel.AutoScroll = true;
            this.MainLeftBarPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.MainLeftBarPanel.Controls.Add(this.MainLeftInfo);
            this.MainLeftBarPanel.Location = new System.Drawing.Point(3, 23);
            this.MainLeftBarPanel.Name = "MainLeftBarPanel";
            this.MainLeftBarPanel.Size = new System.Drawing.Size(326, 687);
            this.MainLeftBarPanel.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.MainLeftBarPanel.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.MainLeftBarPanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.MainLeftBarPanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.MainLeftBarPanel.Style.GradientAngle = 90;
            this.MainLeftBarPanel.TabIndex = 0;
            this.MainLeftBarPanel.Visible = true;
            // 
            // MainLeftInfo
            // 
            this.MainLeftInfo.AutoSize = true;
            this.MainLeftInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.MainLeftInfo.Location = new System.Drawing.Point(0, 0);
            this.MainLeftInfo.Name = "MainLeftInfo";
            this.MainLeftInfo.Size = new System.Drawing.Size(326, 549);
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
            this.RightDockSite.Location = new System.Drawing.Point(1328, 147);
            this.RightDockSite.Name = "RightDockSite";
            this.RightDockSite.Size = new System.Drawing.Size(0, 713);
            this.RightDockSite.TabIndex = 3;
            this.RightDockSite.TabStop = false;
            // 
            // ToolbarBottomDockSite
            // 
            this.ToolbarBottomDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.ToolbarBottomDockSite.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ToolbarBottomDockSite.Location = new System.Drawing.Point(5, 860);
            this.ToolbarBottomDockSite.Name = "ToolbarBottomDockSite";
            this.ToolbarBottomDockSite.Size = new System.Drawing.Size(1323, 0);
            this.ToolbarBottomDockSite.TabIndex = 9;
            this.ToolbarBottomDockSite.TabStop = false;
            // 
            // ToolbarLeftDockSite
            // 
            this.ToolbarLeftDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.ToolbarLeftDockSite.Dock = System.Windows.Forms.DockStyle.Left;
            this.ToolbarLeftDockSite.Location = new System.Drawing.Point(5, 147);
            this.ToolbarLeftDockSite.Name = "ToolbarLeftDockSite";
            this.ToolbarLeftDockSite.Size = new System.Drawing.Size(0, 713);
            this.ToolbarLeftDockSite.TabIndex = 6;
            this.ToolbarLeftDockSite.TabStop = false;
            // 
            // ToolbarRightDockSite
            // 
            this.ToolbarRightDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.ToolbarRightDockSite.Dock = System.Windows.Forms.DockStyle.Right;
            this.ToolbarRightDockSite.Location = new System.Drawing.Point(1328, 147);
            this.ToolbarRightDockSite.Name = "ToolbarRightDockSite";
            this.ToolbarRightDockSite.Size = new System.Drawing.Size(0, 713);
            this.ToolbarRightDockSite.TabIndex = 7;
            this.ToolbarRightDockSite.TabStop = false;
            // 
            // ToolbarTopDockSite
            // 
            this.ToolbarTopDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.ToolbarTopDockSite.Dock = System.Windows.Forms.DockStyle.Top;
            this.ToolbarTopDockSite.Location = new System.Drawing.Point(5, 147);
            this.ToolbarTopDockSite.Name = "ToolbarTopDockSite";
            this.ToolbarTopDockSite.Size = new System.Drawing.Size(1323, 0);
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
            this.TopDockSite.Size = new System.Drawing.Size(988, 0);
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
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(163)))), ((int)(((byte)(26))))));
            // 
            // MainV2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 862);
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
            this.RibbonClientPanel.ResumeLayout(false);
            this.BottomDockSite.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BottomBar)).EndInit();
            this.BottomBar.ResumeLayout(false);
            this.CommandsPanel.ResumeLayout(false);
            this.LayerManagerPanel.ResumeLayout(false);
            this.LeftDockSite.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LeftBar)).EndInit();
            this.LeftBar.ResumeLayout(false);
            this.LayerReaderPanel.ResumeLayout(false);
            this.LayerReaderPanel.PerformLayout();
            this.MainLeftBarPanel.ResumeLayout(false);
            this.MainLeftBarPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ToolStripButton MenuInitConfig;
        public System.Windows.Forms.ToolStripButton MenuSimulation;
        public System.Windows.Forms.ToolStripButton MenuConfigTune;
        public System.Windows.Forms.ToolStripButton MenuConnect;
        public System.Windows.Forms.ToolStripButton MenuHelp;
        public System.Windows.Forms.ToolStripButton MenuArduPilot;
        private DevComponents.DotNetBar.RibbonControl MinMenuBar;
        private DevComponents.DotNetBar.RibbonPanel FileRibbonPanel;
        private DevComponents.DotNetBar.RibbonBar ProjectRibbonBar;
        private DevComponents.DotNetBar.RibbonTabItem FileRibbonTabItem;
        private DevComponents.DotNetBar.Office2007StartButton StartButton;
        private DevComponents.DotNetBar.ItemContainer StartContainer;
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
        private DevComponents.DotNetBar.ButtonItem ClearWPButton;
        private DevComponents.DotNetBar.ButtonItem ClearPolygonButton;
        private DevComponents.DotNetBar.RibbonBar AutoWPRibbonBar;
        private DevComponents.DotNetBar.ButtonItem AutoWPButton;
        private DevComponents.DotNetBar.ButtonItem UndoButton;
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
        private Controls.MainInfo.TopMainInfo topMainInfo;
        private DevComponents.DotNetBar.ButtonItem TiffManagerButton;
        private DevComponents.DotNetBar.ButtonItem DrawWPButton;
        private DevComponents.DotNetBar.ButtonItem SaveWPButton;
        private DevComponents.DotNetBar.ButtonItem LoadWPButton;
        private DevComponents.DotNetBar.ButtonItem SavePolygonButton;
        private DevComponents.DotNetBar.ButtonItem LoadPolygonButton;
        private DevComponents.DotNetBar.ItemContainer StartItemContainer;
        private DevComponents.DotNetBar.ItemContainer itemContainer8;
        private DevComponents.DotNetBar.ButtonItem OpenProjectItem;
        private DevComponents.DotNetBar.ButtonItem SaveProjectItem;
        private DevComponents.DotNetBar.ButtonItem CloseProjectItem;
        private DevComponents.DotNetBar.ButtonItem WorkSpaceItem;
        private DevComponents.DotNetBar.ItemContainer itemContainer9;
        private DevComponents.DotNetBar.ItemContainer itemContainer10;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.ButtonItem ImportWPItem;
        private DevComponents.DotNetBar.ButtonItem ImportPolyItem;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;
        private DevComponents.DotNetBar.ButtonItem ExportWPItem;
        private DevComponents.DotNetBar.ButtonItem ExportPolyItem;
        private DevComponents.DotNetBar.ButtonItem CloseVPS;
        private DevComponents.DotNetBar.ButtonItem ImportGirdConfig;
        private DevComponents.DotNetBar.ButtonItem ExportGirdConfig;
        private DevComponents.DotNetBar.ItemContainer itemContainer12;
        private DevComponents.DotNetBar.ButtonItem ZoomToWPButton;
        private DevComponents.DotNetBar.ItemContainer itemContainer11;
        private DevComponents.DotNetBar.ButtonItem ZoomToPolygonButton;
        private DevComponents.DotNetBar.ButtonItem buttonItem3;
    }
}