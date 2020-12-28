using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPS.Controls.CustomForms
{
    public partial class CustomMarkerStyle : DevComponents.DotNetBar.Office2007Form
    {
        public CustomMarkerStyle(VPS.Controls.Icon.Marker.Style style)
        {
            InitializeComponent();

            iconStyle = style;
            InitCustomMarkerStyle();
            InitCustomLineStyle();
            this.CommandType.SelectedValueChanged += new System.EventHandler(this.CommandType_SelectedValueChanged);
            InitCustomCommandType();
            this.LineType.SelectedValueChanged += new System.EventHandler(this.LineType_SelectedValueChanged);
            InitCustomLineType();

            this.MarkerStyle.SelectedValueChanged += MarkerStyle1_SelectedValueChanged;
            this.MarkerSelectedColor.SelectedColorChanged += MarkerSelectedColor_SelectedColorChanged;
            this.MarkerFont.FontChanged += MarkerFont_FontChanged;

            this.LineStyle.SelectedValueChanged += LineStyle_SelectedValueChanged;
            this.LineWidth.ValueChanged += LineWidth_ValueChanged;
            this.LineColor.SelectedColorChanged += LineColor_SelectedColorChanged;

        }

        private void InitCustomMarkerStyle()
        {
            var EnumDataList = VPS.Controls.Icon.Marker.CustomMarkerIcon(iconStyle);

            List<KeyValuePair<string, Image>> EnumDataImageList = new List<KeyValuePair<string, Image>>();
            for (int index = 0; index < EnumDataList.Count; index++)
            {
                KeyValuePair<string, Image> pair = new KeyValuePair<string, Image>(
                    EnumDataList[index].Value,
                    VPS.Controls.Icon.Marker.GetIcon(EnumDataList[index].Value));

                EnumDataImageList.Add(pair);
            }

            MarkerStyle.DisplayMembers = "Value";
            MarkerStyle.ValueMember = "Key";
            MarkerStyle.DataSource = EnumDataImageList;
        }

        private void InitCustomCommandType()
        {
            List<KeyValuePair<string, string>> EnumDataList = new List<KeyValuePair<string, string>>();
            EnumDataList.Add(new KeyValuePair<string, string>(CustomData.WP.WPCommands.DefaultWPCommand, "航点"));
            EnumDataList.Add(new KeyValuePair<string, string>(CustomData.WP.WPCommands.ClickWPCommand, "航摄点"));
            EnumDataList.Add(new KeyValuePair<string, string>(CustomData.WP.WPCommands.HomeCommand, "初始位置"));

            CommandType.DisplayMember = "Value";
            CommandType.ValueMember = "Key";
            CommandType.DataSource = EnumDataList;
        }

        private void InitCustomLineStyle()
        {
            var EnumDataList = Utilities.EnumTranslator.EnumToList<DashStyle>();

            List<KeyValuePair<string, Image>> EnumDataImageList = new List<KeyValuePair<string, Image>>();
            for (int index = 0; index < EnumDataList.Count; index++)
            {
                Bitmap bit = new Bitmap(50, 30);
                Graphics g = Graphics.FromImage(bit);

                Pen pen = new Pen(Color.Black, 2);
                pen.DashStyle = (DashStyle)
                    Enum.Parse(typeof(DashStyle), EnumDataList[index].Value);
                g.DrawLine(pen, new Point(5, 15), new Point(50, 15));

                KeyValuePair<string, Image> pair = new KeyValuePair<string, Image>(
                    EnumDataList[index].Value,
                    bit);

                EnumDataImageList.Add(pair);
            }

            LineStyle.DisplayMembers = "Value";
            LineStyle.ValueMember = "Key";
            LineStyle.DataSource = EnumDataImageList;
        }

        private void InitCustomLineType()
        {
            List<KeyValuePair<string, string>> EnumDataList = new List<KeyValuePair<string, string>>();
            EnumDataList.Add(new KeyValuePair<string, string>(CustomData.WP.WPLines.DefaultWPLine, "航线"));
            EnumDataList.Add(new KeyValuePair<string, string>(CustomData.WP.WPLines.HomeWPLine, "初始航线"));

            LineType.DisplayMember = "Value";
            LineType.ValueMember = "Key";
            LineType.DataSource = EnumDataList;
        }

        #region IconStyle
        private VPS.Controls.Icon.Marker.Style iconStyle = VPS.Controls.Icon.Marker.Style.all;
        #endregion


        private void MarkerFont_FontChanged(object sender, EventArgs e)
        {
            if (CommandType.SelectedValue != null &&
                MarkerSelectedColor.SelectedColor != null && MarkerStyle.SelectedValue != null) 
            {
                string selectedMarkerType = CommandType.SelectedValue.ToString();
                VPS.Maps.GMapMarkerStyle.SetGMapMarkerStyle(
                    selectedMarkerType,
                    new VPS.Maps.GMapMarkerStyle(
                        MarkerSelectedColor.SelectedColor,
                        MarkerFont.GetFont(),
                        (GMarkerGoogleType)Enum.Parse(typeof(GMarkerGoogleType), MarkerStyle.SelectedValue.ToString())
                    )
                );
            }
        }

        private void MarkerSelectedColor_SelectedColorChanged(object sender, EventArgs e)
        {
            if (CommandType.SelectedValue != null &&
                MarkerSelectedColor.SelectedColor != null && MarkerStyle.SelectedValue != null)
            {
                string selectedMarkerType = CommandType.SelectedValue.ToString();
                VPS.Maps.GMapMarkerStyle.SetGMapMarkerStyle(
                    selectedMarkerType,
                    new VPS.Maps.GMapMarkerStyle(
                        MarkerSelectedColor.SelectedColor,
                        MarkerFont.GetFont(),
                        (GMarkerGoogleType)Enum.Parse(typeof(GMarkerGoogleType), MarkerStyle.SelectedValue.ToString())
                    )
                );
            }
        }

        private void MarkerStyle1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CommandType.SelectedValue != null &&
                MarkerSelectedColor.SelectedColor != null && MarkerStyle.SelectedValue != null)
            {
                string selectedMarkerType = CommandType.SelectedValue.ToString();
                VPS.Maps.GMapMarkerStyle.SetGMapMarkerStyle(
                    selectedMarkerType,
                    new VPS.Maps.GMapMarkerStyle(
                        MarkerSelectedColor.SelectedColor,
                        MarkerFont.GetFont(),
                        (GMarkerGoogleType)Enum.Parse(typeof(GMarkerGoogleType), MarkerStyle.SelectedValue.ToString())
                    )
                );
            }
        }

        private void CommandType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CommandType.SelectedValue != null)
            {
                string selectedMarkerType = CommandType.SelectedValue.ToString();
                if (!Maps.GMapMarkerStyle.ExistGMapMarkerStyle(selectedMarkerType))
                {
                    if (selectedMarkerType == CustomData.WP.WPCommands.DefaultWPCommand)
                        Maps.GMapMarkerStyle.SetGMapMarkerStyle(selectedMarkerType, 
                            Maps.GMapMarkerStyle.DefaultWPStyle);
                    else if (selectedMarkerType == CustomData.WP.WPCommands.HomeCommand)
                        Maps.GMapMarkerStyle.SetGMapMarkerStyle(selectedMarkerType, 
                            Maps.GMapMarkerStyle.DefaultHomeStyle);
                    else if (selectedMarkerType == CustomData.WP.WPCommands.ClickWPCommand)
                        Maps.GMapMarkerStyle.SetGMapMarkerStyle(selectedMarkerType, 
                            Maps.GMapMarkerStyle.DefaultClickStyle);
                    else
                        Maps.GMapMarkerStyle.SetGMapMarkerStyle(selectedMarkerType, 
                            Maps.GMapMarkerStyle.DefaultWPStyle);
                }
                var style = Maps.GMapMarkerStyle.GetGMapMarkerStyle(selectedMarkerType);

                MarkerSelectedColor.SelectedColor = style.SedColor;
                MarkerFont.SetFont(style.TipFont);
                MarkerStyle.SelectedValue = style.Type.ToString();
            }
        }

        private void LineType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (LineType.SelectedValue != null)
            {
                string selectedLineType = LineType.SelectedValue.ToString();
                if (!Maps.GMapOverlayStyle.ExistGMapOverlayStyle(selectedLineType))
                {
                    if (selectedLineType == CustomData.WP.WPLines.DefaultWPLine)
                        Maps.GMapOverlayStyle.SetGMapOverlayStyle(selectedLineType, 
                            Maps.GMapOverlayStyle.DefaultWPStyle);
                    else if (selectedLineType == CustomData.WP.WPLines.HomeWPLine)
                        Maps.GMapOverlayStyle.SetGMapOverlayStyle(selectedLineType, 
                            Maps.GMapOverlayStyle.DefaultHomeStyle);
                    else
                        Maps.GMapOverlayStyle.SetGMapOverlayStyle(selectedLineType, 
                            Maps.GMapOverlayStyle.DefaultWPStyle);
                }

                var style = Maps.GMapOverlayStyle.GetGMapOverlayStyle(selectedLineType);

                LineColor.SelectedColor = style.lineColor;
                LineWidth.Value = style.lineWidth;
                LineStyle.SelectedValue = style.lineStyle.ToString();
            }
        }

        private void LineWidth_ValueChanged(object sender, EventArgs e)
        {
            if (LineType.SelectedValue != null &&
                LineColor.SelectedColor != null && LineStyle.SelectedValue != null)
            {
                string selectedLineType = LineType.SelectedValue.ToString();
                VPS.Maps.GMapOverlayStyle.SetGMapOverlayStyle(
                    selectedLineType,
                    new VPS.Maps.GMapOverlayStyle(
                        LineColor.SelectedColor,
                        LineWidth.Value,
                        (DashStyle)Enum.Parse(typeof(DashStyle), LineStyle.SelectedValue.ToString())
                    )
                );
            }
        }

        private void LineStyle_SelectedValueChanged(object sender, EventArgs e)
        {
            if (LineType.SelectedValue != null &&
                LineColor.SelectedColor != null && LineStyle.SelectedValue != null)
            {
                string selectedLineType = LineType.SelectedValue.ToString();
                VPS.Maps.GMapOverlayStyle.SetGMapOverlayStyle(
                    selectedLineType,
                    new VPS.Maps.GMapOverlayStyle(
                        LineColor.SelectedColor,
                        LineWidth.Value,
                        (DashStyle)Enum.Parse(typeof(DashStyle), LineStyle.SelectedValue.ToString())
                    )
                );
            }
        }

        private void LineColor_SelectedColorChanged(object sender, EventArgs e)
        {
            if (LineType.SelectedValue != null &&
                LineColor.SelectedColor != null && LineStyle.SelectedValue != null)
            {
                string selectedLineType = LineType.SelectedValue.ToString();
                VPS.Maps.GMapOverlayStyle.SetGMapOverlayStyle(
                    selectedLineType,
                    new VPS.Maps.GMapOverlayStyle(
                        LineColor.SelectedColor,
                        LineWidth.Value,
                        (DashStyle)Enum.Parse(typeof(DashStyle), LineStyle.SelectedValue.ToString())
                    )
                );
            }
        }
    }
}
