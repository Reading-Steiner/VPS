using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace VPS.Controls.CustomForms
{
    public partial class CustomPosition : Office2007Form
    {
        #region 构造函数
        public CustomPosition()
        {
            InitializeComponent();

            var position = new VPS.CustomData.WP.VPSPosition();
            Position.Command = CustomData.WP.WPCommands.DefaultWPCommand;
            Position.AltMode = CustomData.EnumCollect.AltFrame.Relative;

            AltFrameSelecter.DataSource = 
                Enum.GetValues(typeof(CustomData.EnumCollect.AltFrame.Mode));

            CopyWGS84Position(position);
            defaultPosition = GetWGS84Position();
            
        }

        public CustomPosition(VPS.CustomData.WP.VPSPosition position)
        {
            InitializeComponent();

            AltFrameSelecter.DataSource = 
                Enum.GetValues(typeof(CustomData.EnumCollect.AltFrame.Mode));

            CopyWGS84Position(position);
            defaultPosition = GetWGS84Position();
        }
        #endregion

        #region Load
        private void CustomPosition_Load(object sender, EventArgs e)
        {
            this.LngInput.Value = Position.Lng;
            this.LatInput.Value = Position.Lat;
            this.AltInput.Value = (int)Position.Alt;
            this.AltFrameSelecter.SelectedItem = 
                CustomData.EnumCollect.AltFrame.GetAltFrame(Position.AltMode);
        }
        #endregion

        #region 数据
        private VPS.CustomData.WP.VPSPosition defaultPosition = new VPS.CustomData.WP.VPSPosition();
        private VPS.CustomData.WP.VPSPosition Position = new VPS.CustomData.WP.VPSPosition();

        public VPS.CustomData.WP.VPSPosition GetWGS84Position()
        {
            return new VPS.CustomData.WP.VPSPosition(Position);
        }

        public void SetWGS84Position(Utilities.PointLatLngAlt value)
        {
            Position = new VPS.CustomData.WP.VPSPosition(value);
            this.LngInput.Value = value.Lng;
            this.LatInput.Value = value.Lat;
            this.AltInput.Value = (int)value.Alt;
            this.AltFrameSelecter.SelectedItem =
                CustomData.EnumCollect.AltFrame.GetAltFrame(Position.AltMode);
        }

        public void CopyWGS84Position(VPS.CustomData.WP.VPSPosition value)
        {
            Position = value;
            this.LngInput.Value = value.Lng;
            this.LatInput.Value = value.Lat;
            this.AltInput.Value = (int)value.Alt;
            this.AltFrameSelecter.SelectedItem =
                CustomData.EnumCollect.AltFrame.GetAltFrame(Position.AltMode);
        }
        #endregion

        #region 数据变化响应函数
        string AltFormat = "地面海拔  {0} m";
        private void LngInput_ValueChanged(object sender, EventArgs e)
        {
            Position.Lng = LngInput.Value;
            double alt = Utilities.srtm.getAltitude(Position.Lat, Position.Lng).alt * CurrentState.multiplieralt;
            GeoAltitude.Text = string.Format(AltFormat, alt.ToString("0.##"));
        }

        private void LatInput_ValueChanged(object sender, EventArgs e)
        {
            Position.Lat = LatInput.Value;
            double alt = Utilities.srtm.getAltitude(Position.Lat, Position.Lng).alt * CurrentState.multiplieralt;
            GeoAltitude.Text = string.Format(AltFormat, alt.ToString("0.##"));
        }

        private void AltFrameSelecter_SelectedIndexChanged(object sender, EventArgs e)
        {
            Position.AltMode = AltFrameSelecter.SelectedItem.ToString();
        }

        private void AltInput_ValueChanged(object sender, EventArgs e)
        {
            Position.Alt = AltInput.Value;
        }
        #endregion

        #region 数据还原函数
        private void Default_Click(object sender, EventArgs e)
        {
            Position.FromPosition(defaultPosition);
        }
        #endregion
    }
}
