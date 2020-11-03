using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar.SuperGrid;

namespace VPS.Controls.Layer
{
    public partial class LayerManager : UserControl
    {
        bool isEdit = false;
        void StartEdit() { isEdit = true; }
        void EndEdit() { isEdit = false; }

        public LayerManager()
        {
            StartEdit();
            InitializeComponent();
            EndEdit();
            BindingData();
            VPS.Layer.MemoryLayerCache.LayerInfosChange += BindingData;
        }

        #region LayerManager 数据绑定

        #region 从数据源获取数据

        public List<VPS.Layer.LayerInfo> GetDataSource()
        {
            List<VPS.Layer.LayerInfo> dataSource = new List<VPS.Layer.LayerInfo>();
            for (int index = 0; index < VPS.Layer.MemoryLayerCache.TotalCount; index++)
            {
                var info = VPS.Layer.MemoryLayerCache.GetLayerFromMemoryCache(index, true);
                if (info != null)
                {
                    dataSource.Add(info);
                }
            }
            return dataSource;
        }
        #endregion

        #region 生成表格

        #region Main

        #region 生成主表
        const string MainLayerHandle = "MainLayer";
        public DataTable GetMainTable()
        {
            DataTable table = new DataTable(MainLayerHandle);

            DataColumn col = new DataColumn();
            col.ColumnName = "Key";
            col.DataType = Type.GetType("System.String");
            table.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = "数据位置";
            col.DataType = Type.GetType("System.String");
            table.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = "数据源类型";
            col.DataType = Type.GetType("System.String");
            table.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = "修改时间";
            col.DataType = Type.GetType("System.String");
            table.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = "创建时间";
            col.DataType = Type.GetType("System.String");
            table.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = "删除";
            col.DataType = Type.GetType("System.String");
            table.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = "默认";
            col.DataType = Type.GetType("System.String");
            table.Columns.Add(col);
            return table;
        }
        #endregion

        #region 生成主表行
        private void FillMainTable(VPS.Layer.LayerInfo emp)
        {
            DataRow row = table.NewRow();

            row[0] = emp.GetOnlyCode();
            row[1] = emp.Layer;
            row[3] = emp.ModifyTime;
            row[4] = emp.CreateTime;

            row[5] = "";
            if (emp.Layer == Utilities.Settings.Instance["defaultTiffLayer"])
            {
                row[6] = "True";
            }
            else
            {
                row[6] = "false";
            }

            if (emp is VPS.Layer.TiffLayerInfo)
            {
                row[2] = "本地文件";
            }

            table.Rows.Add(row);

            row.AcceptChanges();
        }
        #endregion

        #region 行默认填充单元
        private void MainLayerPanelDefaultValue(GridPanel panel)
        {

        }
        #endregion

        #region 主表显示格式设置
        private void CustomizeMainLayerPanel(GridPanel panel)
        {
            panel.FrozenColumnCount = 1;
            panel.ColumnHeader.RowHeight = 30;
            panel.MinRowHeight = 25;

            panel.ColumnAutoSizeMode = ColumnAutoSizeMode.None;
            panel.Columns[0].MinimumWidth = 80;
            panel.Columns[0].ReadOnly = true;

            panel.Columns[1].MinimumWidth = 400;
            panel.Columns[1].ReadOnly = true;

            panel.Columns[2].MinimumWidth = 80;
            panel.Columns[2].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            panel.Columns[2].ReadOnly = true;

            panel.Columns[3].MinimumWidth = 200;
            panel.Columns[3].ReadOnly = true;

            panel.Columns[4].MinimumWidth = 200;
            panel.Columns[4].ReadOnly = true;

            panel.Columns[5].EditorType = typeof(ImageLabel);
            panel.Columns[5].EditorParams = new object[] { ImageList.Images["Delete.png"] };
            panel.Columns[5].MinimumWidth = 25;
            panel.Columns[5].Width = 25;

            panel.Columns[6].EditorType = typeof(ImageCheckBox);
            panel.Columns[6].EditorParams = new object[] { ImageList.Images["Default.png"] };
            panel.Columns[6].MinimumWidth = 25;
            panel.Columns[6].Width = 25;
        }
        #endregion

        #endregion

        #region File

        #region 生成 文件表

        const string FileLayerHandle = "FileLayer";
        public DataTable GetFileTable()
        {
            DataTable table = new DataTable(FileLayerHandle);

            DataColumn col = new DataColumn();
            col.ColumnName = "Key";
            col.DataType = Type.GetType("System.String");
            table.Columns.Add(col);


            col = new DataColumn();
            col.ColumnName = "文件";
            col.DataType = typeof(Utilities.PointLatLngAlt);
            table.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = "文件类型";
            col.DataType = Type.GetType("System.String");
            table.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = "文件大小";
            col.DataType = Type.GetType("System.String");
            table.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = "有效文件";
            col.DataType = typeof(Color);
            table.Columns.Add(col);


            return table;
        }
        #endregion

        #endregion

        #region Tiff

        #region 生成Tiff表

        const string TiffLayerHandle = "TiffLayer";
        public DataTable GetLayerTable()
        {
            DataTable table = new DataTable(TiffLayerHandle);

            DataColumn col = new DataColumn();
            col.ColumnName = "Key";
            col.DataType = Type.GetType("System.String");
            table.Columns.Add(col);


            col = new DataColumn();
            col.ColumnName = "图层原点";
            col.DataType = typeof(Utilities.PointLatLngAlt);
            table.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = "高度框架";
            col.DataType = Type.GetType("System.String");
            table.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = "图层比例尺";
            col.DataType = Type.GetType("System.String");
            table.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = "图层透明色";
            col.DataType = typeof(Color);
            table.Columns.Add(col);


            return table;
        }
        #endregion

        #region 生成Tiff行
        private void FillLayerTable(VPS.Layer.TiffLayerInfo emp)
        {
            DataRow row = table.NewRow();

            DataRow fileRow = layerTable.NewRow();
            fileRow[0] = emp.GetOnlyCode();
            fileRow[1] = emp.Origin;
            fileRow[2] = emp.Origin.Tag2;
            fileRow[3] = emp.ScaleFormat;
            fileRow[4] = emp.Transparent;

            layerTable.Rows.Add(fileRow);

            fileRow.AcceptChanges();
            layerTable.EndLoadData();
        }
        #endregion

        #region Tiff表显示格式设置
        private void CustomizeTiffLayerPanel(GridPanel panel)
        {
            panel.FrozenColumnCount = 1;
            panel.ColumnHeader.RowHeight = 30;
            panel.ColumnAutoSizeMode = ColumnAutoSizeMode.None;

            panel.Columns[0].MinimumWidth = 80;
            panel.Columns[0].Visible = false;
            panel.Columns[0].ReadOnly = true;

            panel.Columns[1].MinimumWidth = 250;
            panel.Columns[0].ReadOnly = true;

            panel.Columns[2].EditorType = typeof(GridComboBoxExEditControl);
            panel.Columns[2].EditorParams = new object[] { };
            panel.Columns[2].MinimumWidth = 80;
            panel.Columns[2].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;


            panel.Columns[3].MinimumWidth = 80;
            panel.Columns[3].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            panel.Columns[3].Visible = false;

            panel.Columns[4].MinimumWidth = 200;
        }
        #endregion

        #endregion

        #region 绑定数据源
        DataSet set = null;
        DataTable table = null;
        DataTable layerTable = null;

        public void BindingDataSource()
        {
            DataSet set = new DataSet("LayerManager");

            table = GetMainTable();
            layerTable = GetLayerTable();

            set.Tables.Add(table);
            set.Tables.Add(layerTable);

            set.Relations.Add("1", set.Tables[MainLayerHandle].Columns["Key"],
                               set.Tables[TiffLayerHandle].Columns["Key"], false);
            LayerDataList.PrimaryGrid.DataSource = set;
            LayerDataList.PrimaryGrid.DataMember = MainLayerHandle;
        }
        #endregion

        #region 绑定数据 BeginLoadData
        private void BeginLoadData()
        {
            table.BeginLoadData();
            layerTable.BeginLoadData();
        }
        #endregion

        #region 绑定数据 EndLoadData
        private void EndLoadData()
        {
            layerTable.EndLoadData();
            table.EndLoadData();
        }
        #endregion

        #region 绑定成功后的响应函数（填充默认单元）
        private void LayerDataList_RowSetDefaultValues(object sender, GridRowSetDefaultValuesEventArgs e)
        {
            GridPanel panel = e.GridPanel;
            switch (panel.DataMember)
            {
                case MainLayerHandle:
                    MainLayerPanelDefaultValue(panel);
                    break;
            }
        }
        #region 绑定成功后的响应函数（设置表格格式）
        private void LayerDataList_DataBindingComplete(object sender, DevComponents.DotNetBar.SuperGrid.GridDataBindingCompleteEventArgs e)
        {
            GridPanel panel = e.GridPanel;

            switch (panel.DataMember)
            {
                case MainLayerHandle:
                    CustomizeMainLayerPanel(panel);
                    break;

                case TiffLayerHandle:
                    CustomizeTiffLayerPanel(panel);
                    break;
            }
        }
        #endregion

        #region 绑定数据 入口函数
        public void BindingData()
        {
            if (isEdit)
                return;
            StartEdit();

            if (set == null)
                BindingDataSource();

            BeginLoadData();

            // Add 50 rows to fiddle with
            var emp = GetDataSource();
            for (int i = 0; i < emp.Count; i++)
            {
                FillMainTable(emp[i]);

                if (emp[i] is VPS.Layer.TiffLayerInfo)
                {
                    FillLayerTable(emp[i] as VPS.Layer.TiffLayerInfo);
                }

            }
            EndLoadData();

            EndEdit();
        }
        #endregion

        #endregion

        #endregion

        #region LayerManager Cell点击
        private void LayerDataList_CellClick(object sender, GridCellClickEventArgs e)
        {
            var cell = e.GridCell;

            if (cell != null)
            {
                switch (cell.GridColumn.Name)
                {
                    case "删除":
                        if (DevComponents.DotNetBar.MessageBoxEx.Show(
                            "图层：" + cell.GridRow[0].Value.ToString(),
                            "确认删除?",
                            MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Warning) == DialogResult.OK)
                        {
                            DeleteLayer(cell.GridRow[0].Value.ToString());
                        }

                        break;

                }
            }
        }

        #region 删除Row
        private void DeleteLayer(string key)
        {
            StartEdit();
            VPS.Layer.MemoryLayerCache.DeleteLayerInMenoryCacheWithHashCode(key);
            for (int index = 0; index < LayerDataList.PrimaryGrid.Rows.Count; index++)
            {
                if (LayerDataList.GetCell(index, 0).Value.ToString() == key)
                {
                    LayerDataList.PrimaryGrid.Rows.RemoveAt(index);
                    break;
                }
            }
            EndEdit();
        }
        #endregion

        #endregion
    }

    #region ControlItem
    internal class ImageLabel : GridLabelXEditControl
    {
        #region Private variables

        #endregion

        public ImageLabel(Image image)
        {
            Image = image;
        }

    }

    internal class ImageCheckBox : GridCheckBoxXEditControl
    {
        #region Private variables
        #endregion

        public ImageCheckBox(Image image)
        {
            this.CheckBoxImageChecked = image;
        }
    }

    internal class AltitudeFrame : GridComboBoxExEditControl
    {
        public AltitudeFrame()
        {
            this.DataSource = new List<string> (){ "Relative", "Absolute", "Terrain" };
        }
    }
    #endregion
}
