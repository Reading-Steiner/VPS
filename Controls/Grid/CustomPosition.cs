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

namespace VPS.Controls.Grid
{
    public partial class CustomPosition : Office2007Form
    {
        #region 构造函数
        public CustomPosition()
        {
            InitializeComponent();

            var position = new Utilities.PointLatLngAlt();
            Position.Tag = VPS.WP.WPCommands.DefaultWPCommand;
            Position.Tag2 = VPS.EnumCollect.AltFrame.Relative;

            AltFrameSelecter.DataSource = Enum.GetValues(typeof(VPS.EnumCollect.AltFrame.Mode));

            WGS84Position = position;
            defaultPosition = WGS84Position;
            
        }

        public CustomPosition(Utilities.PointLatLngAlt position)
        {
            InitializeComponent();

            AltFrameSelecter.DataSource = Enum.GetValues(typeof(VPS.EnumCollect.AltFrame.Mode));

            WGS84Position = position;
            defaultPosition = WGS84Position;
        }
        #endregion

        #region Load
        private void CustomPosition_Load(object sender, EventArgs e)
        {
            this.LngInput.Value = Position.Lng;
            this.LatInput.Value = Position.Lat;
            this.AltInput.Value = (int)Position.Alt;
            this.AltFrameSelecter.SelectedItem = VPS.EnumCollect.AltFrame.GetAltFrame(Position.Tag2);
        }
        #endregion

        #region 数据
        private Utilities.PointLatLngAlt defaultPosition = new Utilities.PointLatLngAlt();
        private Utilities.PointLatLngAlt Position = new Utilities.PointLatLngAlt();

        public Utilities.PointLatLngAlt WGS84Position
        {
            set
            {
                Position = new Utilities.PointLatLngAlt(value);
                this.LngInput.Value = value.Lng;
                this.LatInput.Value = value.Lat;
                this.AltInput.Value = (int)value.Alt;
                this.AltFrameSelecter.SelectedItem = VPS.EnumCollect.AltFrame.GetAltFrame(Position.Tag2);
            }
            get
            {
                return new Utilities.PointLatLngAlt(Position);
            }
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
            Position.Tag2 = AltFrameSelecter.SelectedItem.ToString();
        }

        private void AltInput_ValueChanged(object sender, EventArgs e)
        {
            Position.Alt = AltInput.Value;
        }
        #endregion

        #region 数据还原函数
        private void Default_Click(object sender, EventArgs e)
        {
            WGS84Position = defaultPosition;
        }
        #endregion
    }
}
