using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPS.Controls.CustomGridControl
{
    public partial class GridPosition : Form
    {
        public GridPosition()
        {
            InitializeComponent();

            var position = new VPS.Controls.LoadAndSave.Position();
            position.Command = CustomData.WP.WPCommands.DefaultWPCommand;
            position.AltMode = CustomData.EnumCollect.AltFrame.Relative;

            AltFrameSelecter.DataSource =
                Enum.GetValues(typeof(CustomData.EnumCollect.AltFrame.Mode));

            LocationPosition = position;
            defaultPosition = LocationPosition;
        }

        private VPS.Controls.LoadAndSave.Position defaultPosition = new LoadAndSave.Position();
        private VPS.Controls.LoadAndSave.Position position = new LoadAndSave.Position();

        public VPS.Controls.LoadAndSave.Position LocationPosition
        {
            set
            {
                position = value;
                LngInput.Value = position.Lng;
                LatInput.Value = position.Lat;
                AltInput.Value = (int)position.Alt;
                AltFrameSelecter.SelectedItem = 
                    CustomData.EnumCollect.AltFrame.GetAltFrame(position.AltMode);
            }
            get
            {
                return position;
            }
        }

        #region 数据变化响应函数
        string AltFormat = "地面海拔  {0} m";
        private void LngInput_ValueChanged(object sender, EventArgs e)
        {
            position.Lng = LngInput.Value;
            double alt = Utilities.srtm.getAltitude(position.Lat, position.Lng).alt * CurrentState.multiplieralt;
            GeoAltitude.Text = string.Format(AltFormat, alt.ToString("0.##"));
        }

        private void LatInput_ValueChanged(object sender, EventArgs e)
        {
            position.Lat = LatInput.Value;
            double alt = Utilities.srtm.getAltitude(position.Lat, position.Lng).alt * CurrentState.multiplieralt;
            GeoAltitude.Text = string.Format(AltFormat, alt.ToString("0.##"));
        }

        private void AltFrameSelecter_SelectedIndexChanged(object sender, EventArgs e)
        {
            position.AltMode = AltFrameSelecter.SelectedItem.ToString();
        }

        private void AltInput_ValueChanged(object sender, EventArgs e)
        {
            position.Alt = AltInput.Value;
        }
        #endregion

        #region 数据还原函数
        private void Default_Click(object sender, EventArgs e)
        {
            LocationPosition = defaultPosition;
        }
        #endregion
    }
}
