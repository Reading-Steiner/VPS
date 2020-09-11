using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPS
{
    public partial class MainTestVPS : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public MainTestVPS()
        {
            InitializeComponent();
        }

        private void CreateBarButton_Click(object sender, EventArgs e)
        {
            var distance = new Controls.DistanceBar();
            addBar(distance, new Point(0, 0));
        }

        private Bar createBar(Control control, string titleName = null, bool canClose = true)
        {
            PanelDockContainer newPdc = new PanelDockContainer();
            DockContainerItem newDci = new DockContainerItem();
            Bar bar = new Bar();
            //设置几个的属性，先在设计界面添加bar后从.Designer.cs把代码Copy过来，也就相差不多了

            InitializePDC(newPdc);//设置PanelDockContainer的属性
            control.Dock = DockStyle.Fill;
            newPdc.Controls.Add(control);//control是真正要显示的内容

            InitializeDCI(newDci);//设置DockContainerItem的属性
            if (!string.IsNullOrEmpty(titleName))
                newDci.Text = titleName;
            newDci.Control = newPdc;//***
            if (!canClose)
                newDci.CanClose = eDockContainerClose.No;
            else
                newDci.CanClose = eDockContainerClose.Yes;

            InitializeBar(bar);//设置bar的属性
            bar.Text = titleName;
            bar.Controls.Add(newPdc);//***
            bar.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] { newDci });//***

            return bar;
        }

        private void InitializePDC(PanelDockContainer newPdc)
        {
            newPdc.ColorSchemeStyle = eDotNetBarStyle.Office2007;
            newPdc.Name = Guid.NewGuid().ToString();
            newPdc.Style.Alignment = StringAlignment.Center;
            newPdc.Style.BackColor1.ColorSchemePart = eColorSchemePart.BarBackground;
            newPdc.Style.BackColor2.ColorSchemePart = eColorSchemePart.BarBackground2;
            newPdc.Style.BorderColor.ColorSchemePart = eColorSchemePart.BarDockedBorder;
            newPdc.Style.ForeColor.ColorSchemePart = eColorSchemePart.ItemText;
            newPdc.Style.GradientAngle = 90;
            newPdc.TabIndex = 0;
            newPdc.AllowDrop = false;
        }
        private void InitializeDCI(DockContainerItem newDci)
        {
            newDci.Name = Guid.NewGuid().ToString();
            newDci.Text = "";
        }
        private void InitializeBar(Bar bar)
        {
            bar.AlwaysDisplayDockTab = true;//Indicates whether tab that shows all dock containers on the bar is visible all the time.
            bar.CanCustomize = false;
            bar.CanDockBottom = true;
            bar.CanDockDocument = true;
            bar.CanDockLeft = true;
            bar.CanDockRight = true;
            bar.CanDockTop = true;
            bar.CanHide = true;
            bar.CanUndock = true;
            bar.ShowToolTips = true;
            bar.Stretch = true;//Specifies whether Bar will stretch to always fill the space in dock site.
            bar.TabNavigation = true;
            bar.TabStop = true;
            bar.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            //   bar.MinimumSize = new Size(300, 200);//要想无限加bar就不能设置最小值，否则bar加多了显示会有问题
            bar.DockTabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Top;//Gets or sets the dock tab alignment.
            bar.LayoutType = DevComponents.DotNetBar.eLayoutType.DockContainer;
            bar.Style = eDotNetBarStyle.Office2007;
        }

        public void addBar(Control control, Point point, string name = null)
        {
            Bar bar;
            bar = createBar(control, name);
            dotNetBarManager1.Bars.Add(bar);

            bar.MinimumSize = new Size(300, 200);//先给个MinimumSize，show出来，后面再加MinimumSize== Size.Empty

            int x = (int)(point.X + this.Location.X + (this.Width - bar.Width) / 2);
            int y = (int)(point.Y + this.Location.Y + (this.Height - bar.Height) / 2);
            Point location = new Point() { X = x, Y = y };

            dotNetBarManager1.Float(bar, location);//新建bar出现的位置
            bar.RecalcLayout();

            bar.MinimumSize = Size.Empty;

        }
    }
}
