﻿using System;
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
        public CustomPosition()
        {
            InitializeComponent();

            Position = new Utilities.PointLatLngAlt();
            Position.Tag = VPS.WP.WPCommands.DefaultWPCommand;
            Position.Tag2 = AltMode.Relative.ToString();

            defaultPosition = Position;
            AltFrameSelecter.DataSource = Enum.GetValues(typeof(AltMode));
            AltFrameSelecter.SelectedIndex = 0;
        }

        public CustomPosition(Utilities.PointLatLngAlt position)
        {
            InitializeComponent();

            AltFrameSelecter.DataSource = Enum.GetValues(typeof(AltMode));
            if (Enum.TryParse(position.Tag2, out AltMode mode))
                this.AltFrameSelecter.SelectedItem = mode;
            else
                this.AltFrameSelecter.SelectedItem = (AltMode)Enum.Parse(typeof(AltMode), "Relative");

            Position = position;
            defaultPosition = new Utilities.PointLatLngAlt(position) ;
        }

        public enum AltMode
        {
            Relative,
            Absolute,
            Terrain
        }

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
                if (Enum.TryParse(value.Tag2, out AltMode mode))
                    this.AltFrameSelecter.SelectedItem = mode;
                else
                    this.AltFrameSelecter.SelectedItem = (AltMode)Enum.Parse(typeof(AltMode), "Relative");
            }
            get
            {
                return Position;
            }
        }

        private void CustomPosition_Load(object sender, EventArgs e)
        {
            WGS84Position = Position;
        }

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
