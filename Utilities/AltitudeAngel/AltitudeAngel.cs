using AltitudeAngelWings;
using AltitudeAngelWings.Extra;
using AltitudeAngelWings.Service;
using VPS.GCSViews;
using System;
using System.Threading.Tasks;

namespace VPS.Utilities.AltitudeAngel
{
    internal static class AltitudeAngel
    {
        internal static void Configure()
        {
            AltitudeAngelPlugin.Configure();
            ServiceLocator.Register<IMissionPlanner>(l => new MissionPlannerAdaptor(
                new MapAdapter(FlightData.instance.MainMap),
                new MapAdapter(FlightPlanner.instance.MainMap),
                () => FlightPlanner.instance.GetFlightPlanLocations()));
            ServiceLocator.Register<IMissionPlannerState>(l => new MissionPlannerStateAdapter(
                () => MainV2.comPort.MAV.cs));
        }

        internal static async Task Initialize()
        {
            var settings = ServiceLocator.GetService<ISettings>();
            var service = ServiceLocator.GetService<IAltitudeAngelService>();
            if (settings.CheckEnableAltitudeAngel)
            {
                await service.SignInIfAuthenticated();
                return;
            }
            if (DevComponents.DotNetBar.MessageBoxEx.Show(
                    "是否启用 Altitude Angel 进行空域数据管理?\n\n了解更多 <a href=\"http://www.altitudeangel.com\">www.altitudeangel.com</a>",
                    "Altitude Angel - 启用", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                await service.SignInAsync();
            }
            settings.CheckEnableAltitudeAngel = true;
        }

        internal static void Dispose()
        {
            ServiceLocator.Clear();
        }
    }
}