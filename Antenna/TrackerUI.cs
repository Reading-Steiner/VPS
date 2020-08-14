using System.Windows.Forms;
using VPS.Controls;
using VPS.Utilities;

namespace VPS.Antenna
{
    public partial class TrackerUI : UserControl, IDeactivate, IActivate
    {
        public TrackerGeneric TrackerGeneric { get; }

        public TrackerUI()
        {
            InitializeComponent();

            TrackerGeneric = new TrackerGeneric(this, () => MainV2.comPort);
        }

        public void Deactivate()
        {
            TrackerGeneric.Deactivate();
        }

        public void Activate()
        {
            TrackerGeneric.Activate();

            ThemeManager.ApplyThemeTo(this);
        }
    }
}