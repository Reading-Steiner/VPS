using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin;
using VPS.Utilities;

namespace VPS.Controls
{
    public partial class LayerTile : CCSkinMain
    {
        string path;
        string name;
        public LayerTile(string path)
        {
            InitializeComponent();
            this.path = path;
            Initial();
            this.TileRasterX.ChangeText += GeneralTileCount;
            this.TileRasterY.ChangeText += GeneralTileCount;

            this.LimitCoordTopPanel.TextChange += GeneralTileCount;
            this.LimitCoordBottomPanel.TextChange += GeneralTileCount;
            this.LimitCoordLeftPanel.TextChange += GeneralTileCount;
            this.LimitCoordRightPanel.TextChange += GeneralTileCount;

            this.LimitSizeTopPanel.TextChange += GeneralTileCount;
            this.LimitSizeBottomPanel.TextChange += GeneralTileCount;
            this.LimitSizeLeftPanel.TextChange += GeneralTileCount;
            this.LimitSizeRightPanel.TextChange += GeneralTileCount;

            this.LimitCoordTopPanel.TextChange += GeneralLimitRectBoxInfo;
            this.LimitCoordBottomPanel.TextChange += GeneralLimitRectBoxInfo;

            this.TileDisplayBox.Paint += TileDisplayBox_Paint;

            OnEnterEditInfoState();
        }

        void Initial()
        {
            var GDALInfo = GDAL.GDAL.LoadImageInfo(path);
            {
                //this.ImageFileSizeWidth.SetTextContent(GDALInfo.RasterXSize.ToString());
                //this.ImageFileSizeHeight.SetTextContent(GDALInfo.RasterYSize.ToString());

                ImageSize = new Rectangle(0, 0, GDALInfo.RasterXSize, GDALInfo.RasterYSize);
                LimitSize = new Rectangle(0, 0, GDALInfo.RasterXSize, GDALInfo.RasterYSize);

                ImageRect = GDALInfo.Rect;
                LimitCoord = GDALInfo.Rect;
            }
            {
                var FileInfo = new FileInfo(path);
                int level = 0;
                float length = FileInfo.Length;
                while (length > 1024 && level < 4)
                {
                    level++;
                    length /= 1024;
                }
                this.ImageFileSize.SetTextContent(length.ToString("0.00"));
                this.DefaultTilePath.TextContent =
                    Utilities.Settings.GetUserDataDirectory() +
                    ((UInt64)(FileInfo.Name.GetHashCode() + 
                    DateTime.Now.ToString().GetHashCode())).ToString("X") +
                    Path.DirectorySeparatorChar;
                switch (level)
                {
                    case 0: this.boardLabel6.SetTextContent("B"); break;
                    case 1: this.boardLabel6.SetTextContent("KB"); break;
                    case 2: this.boardLabel6.SetTextContent("MB"); break;
                    case 3: this.boardLabel6.SetTextContent("GB"); break;
                    case 4: this.boardLabel6.SetTextContent("TB"); break;
                    default: this.boardLabel6.SetTextContent("TB"); break;
                }

                string toolTips = "";
                toolTips += "名称    " + FileInfo.Name + Environment.NewLine;
                toolTips += "项目类型  " + FileInfo.Extension + Environment.NewLine;
                toolTips += "位置    " + FileInfo.DirectoryName + Environment.NewLine;
                toolTips += "创建日期  " + FileInfo.CreationTimeUtc + Environment.NewLine;
                toolTips += "修改日期  " + FileInfo.LastWriteTimeUtc + Environment.NewLine;
                toolTips += "大小    " + FileInfo.Length + " Byte" + Environment.NewLine;
                toolTips += "特征    " + FileInfo.Attributes;
                this.ImageInfo.SetToolTip(this.ImageInfoLabel, toolTips);
                this.name = FileInfo.Name;
                TileName.SetTextContent(FileInfo.Name + ".{y}_{x}");
                toolTips = "";
                toolTips += "命名规则" + Environment.NewLine;
                toolTips += "“{}”内为系统生成部分" + Environment.NewLine;
                toolTips += "可包含 数字 四则运算（+-*/） 行列索引（x、y）." + Environment.NewLine;
                toolTips += "“{}”外为固定部分" + Environment.NewLine;
                toolTips += "不会因为任何条件而发生变化." + Environment.NewLine;
                this.TileNameBoxInfo.SetToolTip(this.TileNameBox, toolTips);
            }

            using (var ds = OSGeo.GDAL.Gdal.Open(path, OSGeo.GDAL.Access.GA_ReadOnly))
            {
                this.ImageProjection.Text = ds.GetProjection();
                double[] geoTransform = new double[6];
                ds.GetGeoTransform(geoTransform);
                string toolTips = "";
                toolTips += "基准坐标" + Environment.NewLine;
                toolTips += geoTransform[0] + "  " + geoTransform[3] + Environment.NewLine;
                toolTips += "仿射变换规则" + Environment.NewLine;
                toolTips += geoTransform[0] + "  " + 
                    geoTransform[1] + "  " + 
                    geoTransform[2] + Environment.NewLine;
                toolTips += geoTransform[3] + "  " + 
                    geoTransform[4] + "  " + 
                    geoTransform[5] + Environment.NewLine;
                this.ImageRectBoxInfo.SetToolTip(this.ImageLatLngBox, toolTips);
            }
            this.OriginalPath.SetTextContent(path);
            this.ImageInfoLabel.Enabled = true;
            this.UseDefaultPath.Checked = true;
            this.FileOpen.Enabled = false;
            this.DefaultLimitCheck.Checked = true;
            this.UseCoordInfoCheck.Checked = true;
            GeneralLimitRectBoxInfo();
            this.GeneralTileCount();

            this.TileFunc.SelectedIndex = 0;

            this.DisplayPanel.Visible = false;
            this.InfoPanel.Visible = true;
        }

        private GMap.NET.RectLatLng ImageRect
        {
            get { return _imageRect; }
            set
            {
                if (value.Top < 0)
                {
                    this.ImageTop.SetTextContent((-value.Top).ToString("0.00000"));
                    this.ImageTopVector.SetTextContent("S");
                }
                else
                {
                    this.ImageTop.SetTextContent(value.Top.ToString("0.00000"));
                    this.ImageTopVector.SetTextContent("N");
                }

                if (value.Bottom < 0)
                {
                    this.ImageBottom.SetTextContent((-value.Bottom).ToString("0.00000"));
                    this.ImageBottomVector.SetTextContent("S");
                }
                else
                {
                    this.ImageBottom.SetTextContent(value.Bottom.ToString("0.00000"));
                    this.ImageBottomVector.SetTextContent("N");
                }

                if (value.Left < 0)
                {
                    this.ImageLeft.SetTextContent((-value.Left).ToString("0.00000"));
                    this.ImageLeftVector.SetTextContent("W");
                }
                else
                {
                    this.ImageLeft.SetTextContent(value.Left.ToString("0.00000"));
                    this.ImageLeftVector.SetTextContent("E");
                }
                if (value.Right < 0)
                {
                    this.ImageRight.SetTextContent((-value.Right).ToString("0.00000"));
                    this.ImageRightVector.SetTextContent("W");
                }
                else
                {
                    this.ImageRight.SetTextContent(value.Right.ToString("0.00000"));
                    this.ImageRightVector.SetTextContent("E");
                }
                _imageRect = value;
            }
        }

        private Rectangle ImageSize
        {
            get { return _imageSize; }
            set
            {
                _imageSize.X = 0;
                _imageSize.Y = 0;
                _imageSize.Width = value.Width;
                ImageFileSizeWidth.SetTextContent(value.Width.ToString());
                _imageSize.Height = value.Height;
                ImageFileSizeHeight.SetTextContent(value.Height.ToString());
            }
        }

        GMap.NET.RectLatLng _limitCoord;
        GMap.NET.RectLatLng _imageRect;
        Rectangle _limitSize;
        Rectangle _imageSize;

        private Rectangle LimitSize
        {
            get { return _limitSize; }
            set
            {
                LimitSizeTop = value.Top;
                LimitSizeBottom = value.Bottom;
                LimitSizeLeft = value.Left;
                LimitSizeRight = value.Right;
            }
        }

        private int LimitSizeTop
        {
            set
            {
                _limitSize.Y = value;
                this.LimitSizeTopPanel.SetTextContent(value.ToString());
            }
        }

        private int LimitSizeBottom
        {
            set
            {
                _limitSize.Height = value - _limitSize.Y;
                this.LimitSizeBottomPanel.SetTextContent(value.ToString());
            }
        }

        private int LimitSizeLeft
        {
            set
            {
                _limitSize.X = value;
                this.LimitSizeLeftPanel.SetTextContent(value.ToString());
            }
        }

        private int LimitSizeRight
        {
            set
            {
                _limitSize.Width = value - _limitSize.X;
                this.LimitSizeRightPanel.SetTextContent(value.ToString());
            }
        }

        private GMap.NET.RectLatLng LimitCoord
        {
            get { return _limitCoord; }
            set
            {
                LimitCoordTop = value.Top;
                LimitCoordBottom = value.Bottom;
                LimitCoordLeft = value.Left;
                LimitCoordRight = value.Right;
            }
        }

        private double LimitCoordTop
        {
            set
            {
                _limitCoord.Lat = value;
                if (value < 0)
                {
                    this.LimitCoordTopPanel.SetTextContent((-value).ToString("0.00000"));
                    this.LimitCoordTopVector.SetTextContent("S");
                }
                else
                {
                    this.LimitCoordTopPanel.SetTextContent(value.ToString("0.00000"));
                    this.LimitCoordTopVector.SetTextContent("N");
                }

                
            }
        }

        private double LimitCoordBottom
        {
            set
            {
                _limitCoord.HeightLat = _limitCoord.Lat - value;
                if (value < 0)
                {
                    this.LimitCoordBottomPanel.SetTextContent((-value).ToString("0.00000"));
                    this.LimitCoordBottomVector .SetTextContent("S");
                }
                else
                {
                    this.LimitCoordBottomPanel.SetTextContent(value.ToString("0.00000"));
                    this.LimitCoordBottomVector.SetTextContent("N");
                }
                
            }
        }

        private double LimitCoordLeft
        {
            set
            {
                _limitCoord.Lng = value;
                if (value < 0)
                {
                    this.LimitCoordLeftPanel.SetTextContent((-value).ToString("0.00000"));
                    this.LimitCoordLeftVector.SetTextContent("W");
                }
                else
                {
                    this.LimitCoordLeftPanel.SetTextContent(value.ToString("0.00000"));
                    this.LimitCoordLeftVector.SetTextContent("E");
                }
                
            }
        }


        private double LimitCoordRight
        {
            set
            {
                _limitCoord.WidthLng = value - _limitCoord.Lng;
                if (value < 0)
                {
                    this.LimitCoordRightPanel.SetTextContent((-value).ToString("0.00000"));
                    this.LimitCoordRightVector.SetTextContent("W");
                }
                else
                {
                    this.LimitCoordRightPanel.SetTextContent(value.ToString("0.00000"));
                    this.LimitCoordRightVector.SetTextContent("E");
                }
            }
        }

        private void DefaultLimitCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (DefaultLimitCheck.Checked)
            {
                LimitCoord = ImageRect;
                if (LimitCoordTopEdit.Visible)
                {
                    LimitCoordTopEdit.Visible = false;
                    LimitCoordTopEdit.ChangeText -= LimitCoordTopEditOver;
                }
                if (LimitCoordBottomEdit.Visible)
                {
                    LimitCoordBottomEdit.Visible = false;
                    LimitCoordBottomEdit.ChangeText -= LimitCoordBottomEditOver;
                }
                if (LimitCoordLeftEdit.Visible)
                {
                    LimitCoordLeftEdit.Visible = false;
                    LimitCoordLeftEdit.ChangeText -= LimitCoordLeftEditOver;
                }
                if (LimitCoordRightEdit.Visible)
                {
                    LimitCoordRightEdit.Visible = false;
                    LimitCoordRightEdit.ChangeText -= LimitCoordRightEditOver;
                }
                LimitSize = ImageSize;
                if (LimitSizeTopEdit.Visible)
                {
                    LimitSizeTopEdit.Visible = false;
                    LimitSizeTopEdit.ChangeText -= LimitCoordTopEditOver;
                }
                if (LimitSizeBottomEdit.Visible)
                {
                    LimitSizeBottomEdit.Visible = false;
                    LimitSizeBottomEdit.ChangeText -= LimitCoordBottomEditOver;
                }
                if (LimitSizeLeftEdit.Visible)
                {
                    LimitSizeLeftEdit.Visible = false;
                    LimitSizeLeftEdit.ChangeText -= LimitCoordLeftEditOver;
                }
                if (LimitSizeRightEdit.Visible)
                {
                    LimitSizeRightEdit.Visible = false;
                    LimitSizeRightEdit.ChangeText -= LimitCoordRightEditOver;
                }
            }
            else
            {

            }
        }

        private void UseDefaultPath_CheckedChanged(object sender, EventArgs e)
        {
            if (this.UseDefaultPath.Checked)
            {
                TilePath.AllowEdit = false;
                FileOpen.Enabled = false;
            }
            else
            {}
        }

        private void CoordInfoCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (this.UseCoordInfoCheck.Checked)
            {
                LimitCoordBox.Visible = true;
                LimitSizeBox.Visible = false;
                if (this.DefaultLimitCheck.Checked)
                    LimitCoord = ImageRect;
                else
                {
                    GetCoordRectFromLimitSize(out double top, out double bottom, out double left, out double right);
                    LimitCoord = new GMap.NET.RectLatLng(top, left, right - left, top - bottom);
                }
            }
            else
            {
                LimitCoordBox.Visible = false;
                LimitSizeBox.Visible = true;
                if (this.DefaultLimitCheck.Checked)
                    LimitSize = ImageSize;
                else
                {
                    GetRasterSizeFromLimitCoord(out int xOffset, out int yOffset, out int xSize, out int ySize);
                    LimitSize = new Rectangle(xOffset, yOffset, xSize, ySize);
                }
            }
        }

        private void UsePath_CheckedChanged(object sender, EventArgs e)
        {
            if (this.UsePath.Checked)
            {
                TilePath.AllowEdit = true;
                FileOpen.Enabled = true;
            }
            else
            {}
        }

        private void LimitCoordLeft_Click(object sender, EventArgs e)
        {
            if (!DefaultLimitCheck.Checked)
            {
                LimitCoordLeftEdit.SetTextContent(_limitCoord.Left.ToString());
                LimitCoordLeftEdit.Visible = true;
                LimitCoordLeftEdit.Focus();
                LimitCoordLeftEdit.ChangeText -= LimitCoordLeftEditOver;
                LimitCoordLeftEdit.ChangeText += LimitCoordLeftEditOver;
            }
        }

        private void LimitCoordLeftEditOver()
        {
            double left = System.Convert.ToDouble(LimitCoordLeftEdit.GetTextContent());
            if (left >= ImageRect.Left && left <= ImageRect.Right && left <= LimitCoord.Right)
            {
                LimitCoordLeft = left;
            }
            LimitCoordLeftEdit.Visible = false;
            LimitCoordRightEdit.ChangeText -= LimitCoordRightEditOver;
        }

        private void LimitCoordRight_Click(object sender, EventArgs e)
        {
            if (!DefaultLimitCheck.Checked)
            {
                LimitCoordRightEdit.SetTextContent(_limitCoord.Right.ToString());
                LimitCoordRightEdit.Visible = true;
                LimitCoordRightEdit.Focus();
                LimitCoordRightEdit.ChangeText -= LimitCoordRightEditOver;
                LimitCoordRightEdit.ChangeText += LimitCoordRightEditOver;
            }
        }

        private void LimitCoordRightEditOver()
        {
            double right = System.Convert.ToDouble(LimitCoordRightEdit.GetTextContent());
            if (right >= ImageRect.Left && right <= ImageRect.Right && right >= LimitCoord.Left)
            {
                LimitCoordRight = right;
            }
            LimitCoordRightEdit.Visible = false;
            LimitCoordRightEdit.ChangeText -= LimitCoordRightEditOver;
        }

        private void LimitCoordTop_Click(object sender, EventArgs e)
        {
            if (!DefaultLimitCheck.Checked)
            {
                LimitCoordTopEdit.SetTextContent(_limitCoord.Top.ToString());
                LimitCoordTopEdit.Visible = true;
                LimitCoordTopEdit.Focus();
                LimitCoordTopEdit.ChangeText -= LimitCoordTopEditOver;
                LimitCoordTopEdit.ChangeText += LimitCoordTopEditOver;
            }
        }

        private void LimitCoordTopEditOver()
        {
            double top = System.Convert.ToDouble(LimitCoordTopEdit.GetTextContent());
            if (top >= ImageRect.Bottom && top <= ImageRect.Top && top >= LimitCoord.Bottom)
            {
                LimitCoordTop = top;
            }
            LimitCoordTopEdit.Visible = false;
            LimitCoordTopEdit.ChangeText -= LimitCoordTopEditOver;
        }

        private void LimitCoordBottom_Click(object sender, EventArgs e)
        {
            if (!DefaultLimitCheck.Checked)
            {
                LimitCoordBottomEdit.SetTextContent(_limitCoord.Bottom.ToString());
                LimitCoordBottomEdit.Visible = true;
                LimitCoordBottomEdit.Focus();
                LimitCoordBottomEdit.ChangeText -= LimitCoordBottomEditOver;
                LimitCoordBottomEdit.ChangeText += LimitCoordBottomEditOver;
            }
        }

        private void LimitCoordBottomEditOver()
        {
            double bottom = System.Convert.ToDouble(LimitCoordBottomEdit.GetTextContent());
            if (bottom >= ImageRect.Bottom && bottom <= ImageRect.Top && bottom <= LimitCoord.Top)
            {
                LimitCoordBottom = bottom;
            }
            LimitCoordBottomEdit.Visible = false;
            LimitCoordBottomEdit.ChangeText -= LimitCoordBottomEditOver;
        }

        private void LimitSizeTop_Click(object sender, EventArgs e)
        {
            if (!DefaultLimitCheck.Checked)
            {
                LimitSizeTopEdit.SetTextContent(LimitSize.Top.ToString());
                LimitSizeTopEdit.Visible = true;
                LimitSizeTopEdit.Focus();
                LimitSizeTopEdit.ChangeText -= LimitSizeTopEditOver;
                LimitSizeTopEdit.ChangeText += LimitSizeTopEditOver;
            }
        }

        private void LimitSizeTopEditOver()
        {
            int top = System.Convert.ToInt32(LimitSizeTopEdit.GetTextContent());
            if (top >= 0 && top <= ImageSize.Bottom &&
                top <= LimitSize.Bottom)
            {
                LimitSizeTop = top;
            }
            LimitSizeTopEdit.Visible = false;
            LimitSizeTopEdit.ChangeText -= LimitSizeTopEditOver;
        }

        private void LimitSizeBottom_Click(object sender, EventArgs e)
        {
            if (!DefaultLimitCheck.Checked)
            {
                LimitSizeBottomEdit.SetTextContent(LimitSize.Bottom.ToString());
                LimitSizeBottomEdit.Visible = true;
                LimitSizeBottomEdit.Focus();
                LimitSizeBottomEdit.ChangeText -= LimitSizeBottomEditOver;
                LimitSizeBottomEdit.ChangeText += LimitSizeBottomEditOver;
            }
        }

        private void LimitSizeBottomEditOver()
        {
            int bottom = System.Convert.ToInt32(LimitSizeBottomEdit.GetTextContent());
            if (bottom >= 0 && bottom <= ImageSize.Bottom &&
                bottom >= LimitSize.Top)
            {
                LimitSizeBottom = bottom;
            }
            LimitSizeBottomEdit.Visible = false;
            LimitSizeBottomEdit.ChangeText -= LimitSizeBottomEditOver;
        }

        private void LimitSizeLeft_Click(object sender, EventArgs e)
        {
            if (!DefaultLimitCheck.Checked)
            {
                LimitSizeLeftEdit.SetTextContent(LimitSize.Left.ToString());
                LimitSizeLeftEdit.Visible = true;
                LimitSizeLeftEdit.Focus();
                LimitSizeLeftEdit.ChangeText -= LimitSizeLeftEditOver;
                LimitSizeLeftEdit.ChangeText += LimitSizeLeftEditOver;
            }
        }

        private void LimitSizeLeftEditOver()
        {
            int left = System.Convert.ToInt32(LimitSizeLeftEdit.GetTextContent());
            if (left >= 0 && left <= ImageSize.Right &&
                left <= LimitSize.Right)
            {
                LimitSizeLeft = left;
            }
            LimitSizeLeftEdit.Visible = false;
            LimitSizeLeftEdit.ChangeText -= LimitSizeLeftEditOver;
        }

        private void LimitSizeRight_Click(object sender, EventArgs e)
        {
            if (!DefaultLimitCheck.Checked)
            {
                LimitSizeRightEdit.SetTextContent(LimitSize.Right.ToString());
                LimitSizeRightEdit.Visible = true;
                LimitSizeRightEdit.Focus();
                LimitSizeRightEdit.ChangeText -= LimitSizeRightEditOver;
                LimitSizeRightEdit.ChangeText += LimitSizeRightEditOver;
            }
        }

        private void LimitSizeRightEditOver()
        {
            int right = System.Convert.ToInt32(LimitSizeRightEdit.GetTextContent());
            if (right >= 0 && right <= ImageSize.Right &&
                right >= LimitSize.Left)
            {
                LimitSizeRight = right;
            }
            LimitSizeRightEdit.Visible = false;
            LimitSizeRightEdit.ChangeText -= LimitSizeRightEditOver;
        }

        private void LayerTile_Click(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void TileFunc_Click(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void skinTabPage1_Click(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void skinTabPage2_Click(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void LimitPXBox_Click(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void GetRasterSize(out int xOffset, out int yOffset, out int xSize, out int ySize)
        {

            if (this.UseCoordInfoCheck.Checked)
            {
                GetRasterSizeFromLimitCoord(out xOffset, out yOffset, out xSize, out ySize);
            }
            else
            {
                GetRasterSizeFromLimitSize(out xOffset, out yOffset, out xSize, out ySize);
            }
        }

        private void GetRasterSizeFromLimitCoord(out int xOffset, out int yOffset, out int xSize, out int ySize)
        {
            if (this.DefaultLimitCheck.Checked)
            {
                xOffset = 0;
                yOffset = 0;
                xSize = System.Convert.ToInt32(ImageFileSizeWidth.GetTextContent());
                ySize = System.Convert.ToInt32(ImageFileSizeHeight.GetTextContent());
            }
            else
            {
                double ox = 0.0;
                ox = (this.LimitCoord.Left - this.ImageRect.Left) / (geoTransform[1] + geoTransform[2]);
                double oy = 0.0;
                oy = (this.LimitCoord.Top - this.ImageRect.Top) / (geoTransform[4] + geoTransform[5]);
                double x = 0.0;
                x = (this.LimitCoord.Right - this.LimitCoord.Left) / (geoTransform[1] + geoTransform[2]);
                double y = 0.0;
                y = (this.LimitCoord.Top - this.LimitCoord.Bottom) / (geoTransform[4] + geoTransform[5]);
                xOffset = Math.Abs((int)ox == ox ? (int)ox : (int)ox + 1);
                yOffset = Math.Abs((int)oy == oy ? (int)oy : (int)oy + 1);
                xSize = Math.Abs((int)x == x ? (int)x : (int)x + 1);
                ySize = Math.Abs((int)y == y ? (int)y : (int)y + 1);
            }
        }

        private void GetRasterSizeFromLimitSize(out int xOffset, out int yOffset, out int xSize, out int ySize)
        {
            if (this.DefaultLimitCheck.Checked)
            {
                xOffset = 0;
                yOffset = 0;
                xSize = System.Convert.ToInt32(ImageFileSizeWidth.GetTextContent());
                ySize = System.Convert.ToInt32(ImageFileSizeHeight.GetTextContent());
            }
            else
            {
                xOffset = System.Convert.ToInt32(LimitSizeLeftPanel.GetTextContent());
                yOffset = System.Convert.ToInt32(LimitSizeTopPanel.GetTextContent());
                xSize = Math.Abs(System.Convert.ToInt32(LimitSizeRightPanel.GetTextContent()) - xOffset);
                ySize = Math.Abs(System.Convert.ToInt32(LimitSizeBottomPanel.GetTextContent()) - yOffset);
            }
        }

        private void GetCoordRect(out double top, out double bottom, out double left, out double right)
        {
            if (this.UseCoordInfoCheck.Checked)
            {
                GetCoordRectFromLimitCoord(out top, out bottom, out left, out right);
            }
            else
            {
                GetCoordRectFromLimitSize(out top, out bottom, out left, out right);
            }
        }

        private void GetCoordRectFromLimitCoord(out double top, out double bottom, out double left, out double right)
        {
            if (this.DefaultLimitCheck.Checked)
            {
                top = this.ImageRect.Top;
                bottom = this.ImageRect.Bottom;
                left = this.ImageRect.Left;
                right = this.ImageRect.Right;
            }
            else
            {
                top = this.LimitCoord.Top;
                bottom = this.LimitCoord.Bottom;
                left = this.LimitCoord.Left;
                right = this.LimitCoord.Right;
            }
        }

        private void GetCoordRectFromLimitSize(out double top, out double bottom, out double left, out double right)
        {
            if (this.DefaultLimitCheck.Checked)
            {
                top = ImageRect.Top;
                bottom = ImageRect.Bottom;
                left = ImageRect.Left;
                right = ImageRect.Right;
            }
            else
            {
                top = geoTransform[3] + geoTransform[5] * LimitSize.Top;
                bottom = geoTransform[3] + geoTransform[5] * LimitSize.Bottom;
                left = geoTransform[0] + geoTransform[1] * LimitSize.Left;
                right = geoTransform[0] + geoTransform[1] * LimitSize.Right;
            }
        }

        double[] geoTransform = new double[6];
        private void GeneralLimitRectBoxInfo()
        {
            using (var ds = OSGeo.GDAL.Gdal.Open(path, OSGeo.GDAL.Access.GA_ReadOnly))
            {
                ds.GetGeoTransform(geoTransform);
                double xOffset = this.LimitCoord.Left - geoTransform[0] / 
                    (geoTransform[1] + geoTransform[2]);
                double yOffset = this.LimitCoord.Top - geoTransform[3] /
                    (geoTransform[4] + geoTransform[5]);
                string toolTips = "";
                toolTips += "基准坐标" + Environment.NewLine;
                toolTips += geoTransform[0] + "  " + 
                    geoTransform[3] + Environment.NewLine;
                toolTips += "偏移" + Environment.NewLine;
                toolTips += xOffset + "  " + yOffset + Environment.NewLine;
                toolTips += "仿射变换规则" + Environment.NewLine;
                toolTips += this.LimitCoord.Left + "  " + 
                    geoTransform[1] + "  " + 
                    geoTransform[2] + Environment.NewLine;
                toolTips += this.LimitCoord.Top + "  " + 
                    geoTransform[4] + "  " + 
                    geoTransform[5] + Environment.NewLine;
                this.LimitRectBoxInfo.SetToolTip(this.LimitRectBox, toolTips);
            }
        }

        private void GeneralTileCount()
        {
            GetRasterSize(out int xOffset, out int yOffset, out int rasterXSize, out int rasterYSize);
            int tileXSize = System.Convert.ToInt32(this.TileRasterX.GetTextContent());
            int tileYSize = System.Convert.ToInt32(this.TileRasterY.GetTextContent());
            this.TileRowCount.SetTextContent(
                ((int)(rasterXSize / tileXSize) + (int)(rasterXSize % tileXSize == 0 ? 0 : 1)).ToString());
            this.TileColumnCount.SetTextContent(
                ((int)(rasterYSize / tileYSize) + (int)(rasterYSize % tileYSize == 0 ? 0 : 1)).ToString());
        }


        private string GetPath()
        {
            if (UsePath.Checked)
            {
                string useTilePath = "";
                if (this.TilePath.GetTextContent().EndsWith("\\"))
                    useTilePath = this.TilePath.GetTextContent();
                else
                    useTilePath = this.TilePath.GetTextContent() + "\\";

                if (Directory.Exists(useTilePath))
                    return useTilePath;
                try
                {
                    Directory.CreateDirectory(useTilePath);

                    return useTilePath;
                }
                catch
                {
                    Directory.CreateDirectory(this.DefaultTilePath.GetTextContent());
                    if (this.DefaultTilePath.GetTextContent().EndsWith("\\"))
                        return this.DefaultTilePath.GetTextContent();
                    else
                        return this.DefaultTilePath.GetTextContent() + "\\";
                }

            }

            Directory.CreateDirectory(this.DefaultTilePath.GetTextContent());
            if (this.DefaultTilePath.GetTextContent().EndsWith("\\"))
                return this.DefaultTilePath.GetTextContent();
            else
                return this.DefaultTilePath.GetTextContent() + "\\";
        }

        private string GetTileName(int xIndex, int yIndex)
        {
            string TileFormat = this.TileName.GetTextContent();
            var res = Regex.Matches(TileFormat, "[{][^{}]*[}]");
            foreach(Match data in res)
            {
                string str = data.Value;
                string newStr = str.Replace("{", "").
                    Replace("}", "").
                    Replace("x", xIndex.ToString()).
                    Replace("y", yIndex.ToString());
                int a = (int)new DataTable().Compute(newStr, "");
                TileFormat = TileFormat.Replace(str, a.ToString());
            }
            return TileFormat;
        }
        private static object stopHandle = new object();
        bool loadStop = false;
        public delegate void delegateHandler();
        public delegateHandler OnPreViewSucceed;
        public delegateHandler OnPreViewFailure;

        private void GeneralPreViewTile()
        {
            int tileXCount = System.Convert.ToInt32(this.TileRowCount.GetTextContent());
            int tileYCount = System.Convert.ToInt32(this.TileColumnCount.GetTextContent());
            int tileXSize = System.Convert.ToInt32(this.TileRasterX.GetTextContent());
            int tileYSize = System.Convert.ToInt32(this.TileRasterY.GetTextContent());
            int width = TileDisplayBox.Width / (tileXCount + 2);
            int height = width * tileYSize / tileXSize;
            SetDisplayBoxSize(width * (tileXCount + 2), height * tileYCount);
            for (int i = 0; i <= tileYCount; i++)
            {
                for (int j = 0; j <= tileXCount; j++)
                {
                    AddTile(
                        GDAL.GDAL.LoadTile(
                            path,
                            j * tileXSize, i * tileYSize, tileXSize, tileYSize),
                        j, i, width, height);
                    lock (stopHandle)
                        if (loadStop)
                        {
                            OnPreViewFailure?.Invoke();
                            ClearTile();
                            return;
                        }
                }
            }
            OnPreViewSucceed?.Invoke();
        }

        private void OnPreViewStop()
        {
            loadStop = false;
        }

        private void OnPreViewOver()
        {
            OnLeaveTilePreViewState();
            OnEnterTilePreViewOverState();
        }

        private void OnPreViewAccept()
        {
            OnLeaveEditInfoState();
            OnEnterTilePreViewState();

            SetMsg("加载");
            Thread generalTileThread = new Thread(this.GeneralPreViewTile);
            generalTileThread.Start();
        }

        private void OnPreViewSkin()
        {
            lock (stopHandle)
                this.loadStop = true;
            OnLeaveTilePreViewState();
            OnEnterTilePreViewOverState();
        }

        private void OnPreViewAbort()
        {
            lock (stopHandle)
                this.loadStop = true;
            OnLeaveTilePreViewState();
            OnEnterEditInfoState();
        }

        private static object saveHandle = new object();
        bool saveStop = false;
        public delegateHandler OnTileFailure;
        public delegateHandler OnTileSucceed;
        private void GeneralTile()
        {
            string savePath = GetPath();

            int tileXCount = System.Convert.ToInt32(this.TileRowCount.GetTextContent());
            int tileYCount = System.Convert.ToInt32(this.TileColumnCount.GetTextContent());
            int tileXSize = System.Convert.ToInt32(this.TileRasterX.GetTextContent());
            int tileYSize = System.Convert.ToInt32(this.TileRasterY.GetTextContent());
            for (int i = 0; i <= tileYCount; i++)
            {
                for (int j = 0; j <= tileXCount; j++)
                {
                    string saveFullName = savePath + GetTileName(j, i) + ".tif.tif";
                    GDAL.GDAL.SaveTiffTile(path, saveFullName,
                        j * tileXSize, i * tileYSize, tileXSize, tileYSize);
                    lock(saveHandle)
                        if (saveStop)
                        {
                            OnTileFailure?.Invoke();
                            return;
                        }
                }
            }
            OnTileSucceed?.Invoke();
        }

        private void OnTileStop()
        {
            saveStop = false;
        }

        private void OnTileOver()
        {
            OnLeaveTileSaveState();
            OnEnterTileSaveOverState();
        }

        private void FileOpen_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog ofd = new FolderBrowserDialog())
            {
                var ret = ofd.ShowDialog();
                if (ret == DialogResult.OK)
                    this.TilePath.SetTextContent(ofd.SelectedPath);
            }
        }

        private void OnCancel()
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void OnAccept()
        {
            this.DialogResult = DialogResult.OK;
        }

        

        private void OnTileAccept()
        {
            OnLeaveTilePreViewOverState();
            OnEnterTileSaveState();

            Thread generalTileThread = new Thread(this.GeneralTile);
            generalTileThread.Start();
        }

        private void OnLoadTileStop()
        {
            lock (saveHandle)
                this.saveStop = true;
            OnLeaveTileSaveState();
            OnEnterTilePreViewOverState();
        }


        List<BitmapDisplay> loadTiles = new List<BitmapDisplay>();
        private static object addHandle = new object();
        private void AddTile(Bitmap _bitmap, int x, int y, int width, int height)
        {
            if (_bitmap != null)
            {
                lock (addHandle)
                {
                    loadTiles.Add(new BitmapDisplay()
                    {
                        bitmap = _bitmap,
                        rect = new Rectangle((x + 1) * width, y * height, width, height),
                        tag = 0,
                    });
                }
                TileDisplayBox.Invalidate();
            }
        }

        private void ClearTile()
        {
            lock (addHandle)
            {
                loadTiles.Clear();
            }
            TileDisplayBox.Invalidate();
        }

        private delegate void SetDisplayBoxSizeCallbake(int width, int height);
        private void SetDisplayBoxSize(int width, int height)
        {
            if (this.TileDisplayBox.InvokeRequired)
            {
                SetDisplayBoxSizeCallbake callbake = new SetDisplayBoxSizeCallbake(SetDisplayBoxSize);
                this.TileDisplayBox.Invoke(callbake, new object[] { width, height });
            }
            else
            {
                this.TileDisplayBox.Width = width;
                this.TileDisplayBox.Height = height;
            }
        }


        private void TileDisplayBox_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            for (int i = 0; i < loadTiles.Count; i++)
            {
                g.DrawImage(loadTiles[i].bitmap, loadTiles[i].rect);
            }
        }

        private void gradualButton1_Click(object sender, EventArgs e)
        {
            TileName.SetTextContent(this.name + ".{y}_{x}");
        }


        #region 状态
        void OnEnterEditInfoState()
        {
            this.DisplayPanel.Visible = false;
            this.InfoPanel.Visible = true;
            this.RetButton.OKText = "切片并预览";
            this.RetButton.CancelText = "取消";
            this.RetButton.OnOK += OnPreViewAccept;
            this.RetButton.OnCancel += OnCancel;
        }

        void OnLeaveEditInfoState()
        {
            this.DisplayPanel.Visible = true;
            this.InfoPanel.Visible = false;
            this.RetButton.OnOK -= OnPreViewAccept;
            this.RetButton.OnCancel -= OnCancel;
        }

        void OnEnterTilePreViewState()
        {
            this.RetButton.OKText = "跳过预览";
            this.RetButton.CancelText = "终止";
            this.RetButton.OnOK += OnPreViewSkin;
            this.RetButton.OnCancel += OnPreViewAbort;

            OnPreViewSucceed += OnPreViewOver;
            OnPreViewFailure += OnPreViewStop;
        }

        void OnLeaveTilePreViewState()
        {
            OnPreViewSucceed -= OnPreViewOver;
            OnPreViewFailure -= OnPreViewStop;
            this.RetButton.OnCancel -= OnPreViewAbort;
        }

        void OnEnterTilePreViewOverState()
        {
            this.RetButton.OKText = "切片并保存";
            this.RetButton.CancelText = "取消";
            this.RetButton.OnOK += OnTileAccept;
            this.RetButton.OnCancel += OnCancel;
        }

        void OnLeaveTilePreViewOverState()
        {
            this.RetButton.OnOK -= OnTileAccept;
            this.RetButton.OnCancel -= OnCancel;
        }

        void OnEnterTileSaveState()
        {
            this.RetButton.OKText = "保存中";
            this.RetButton.CancelText = "终止";
            this.RetButton.OnCancel += OnLoadTileStop;

            OnTileSucceed += OnTileOver;
            OnTileFailure += OnTileStop;
        }

        void OnLeaveTileSaveState()
        {
            this.RetButton.OnCancel -= OnLoadTileStop;

            OnTileSucceed -= OnTileOver;
            OnTileFailure -= OnTileStop;
        }

        void OnEnterTileSaveOverState()
        {
            this.RetButton.OKText = "确定";
            this.RetButton.CancelText = "取消";
            this.RetButton.OnOK += OnAccept;
            this.RetButton.OnCancel += OnCancel;
        }

        void OnLeaveTileSaveOverState()
        {
            this.RetButton.OnCancel -= OnCancel;
        }
        #endregion

        void SetMsg(string msg)
        {
            MsgDisplayBox.Lines[MsgDisplayBox.Lines.Length] = msg;
        }
    }

    struct BitmapDisplay
    {
        public Bitmap bitmap;
        public Rectangle rect;
        public int tag;
    }
}
