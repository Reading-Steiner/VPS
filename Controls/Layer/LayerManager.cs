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

            CustomData.Layer.MemoryLayerCache.LayerInfosChange += BindingDataSource;
        }

        private void LayerManager_Load(object sender, EventArgs e)
        {
            BindingDataSource();
        }

        #region LayerManager 数据绑定

        #region 从数据源获取数据

        public List<CustomData.Layer.LayerInfo> GetDataSource()
        {
            List<CustomData.Layer.LayerInfo> dataSource = new List<CustomData.Layer.LayerInfo>();
            for (int index = 0; index < CustomData.Layer.MemoryLayerCache.TotalCount; index++)
            {
                var info = CustomData.Layer.MemoryLayerCache.GetLayerFromMemoryCache(index, true);
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
        readonly string keyColumnName = "Key";
        readonly string urlColumnName = "数据位置";
        readonly string typeColumnName = "数据类型";
        readonly string alterColumnName = "修改时间";
        readonly string createColumnName = "创建时间";
        readonly string deleteColumnName = "删除图层";
        readonly string defaultColumnName = "默认图层";

        public DataTable GetMainTable()
        {
            DataTable table = new DataTable(MainLayerHandle);

            DataColumn col = new DataColumn();
            col.ColumnName = keyColumnName;
            col.DataType = Type.GetType("System.String");
            table.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = urlColumnName;
            col.DataType = Type.GetType("System.String");
            table.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = typeColumnName;
            col.DataType = Type.GetType("System.String");
            table.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = alterColumnName;
            col.DataType = Type.GetType("System.String");
            table.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = createColumnName;
            col.DataType = Type.GetType("System.String");
            table.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = deleteColumnName;
            col.DataType = Type.GetType("System.String");
            table.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = defaultColumnName;
            col.DataType = Type.GetType("System.String");
            table.Columns.Add(col);

            return table;
        }
        #endregion

        #region 生成主表行
        private void FillMainTable(DataTable table, CustomData.Layer.LayerInfo emp)
        {
            DataRow row = table.NewRow();

            row[keyColumnName] = emp.GetOnlyCode();
            row[urlColumnName] = emp.Layer;
            row[alterColumnName] = emp.ModifyTime;
            row[createColumnName] = emp.CreateTime;

            row[deleteColumnName] = "";


            if (CustomData.WP.WPGlobalData.instance != null &&
                CustomData.WP.WPGlobalData.instance.IsDefaultLayer(emp.Layer))
            {
                row[defaultColumnName] = "True";
            }
            else
            {
                row[defaultColumnName] = "false";
            }

            if (emp is CustomData.Layer.TiffLayerInfo)
            {
                row[typeColumnName] = "本地文件";
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
            panel.Columns[keyColumnName].MinimumWidth = 80;
            panel.Columns[keyColumnName].ReadOnly = true;

            panel.Columns[urlColumnName].MinimumWidth = 400;
            panel.Columns[urlColumnName].ReadOnly = true;

            panel.Columns[typeColumnName].MinimumWidth = 80;
            panel.Columns[typeColumnName].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            panel.Columns[typeColumnName].ReadOnly = true;

            panel.Columns[alterColumnName].MinimumWidth = 160;
            panel.Columns[alterColumnName].ReadOnly = true;

            panel.Columns[createColumnName].MinimumWidth = 160;
            panel.Columns[createColumnName].ReadOnly = true;

            panel.Columns[deleteColumnName].MinimumWidth = 25;
            panel.Columns[deleteColumnName].Width = 25;
            panel.Columns[deleteColumnName].EditorType = typeof(CustomControls.ImagePanel);
            panel.Columns[deleteColumnName].EditorParams = new object[] { ImageList.Images["Delete.png"] };

            panel.Columns[defaultColumnName].MinimumWidth = 25;
            panel.Columns[defaultColumnName].Width = 25;
            panel.Columns[defaultColumnName].EditorType = typeof(CustomControls.ImageCheckBox);
            panel.Columns[defaultColumnName].EditorParams = new object[] { ImageList.Images["Default.png"] };
            panel.Columns[defaultColumnName].ReadOnly = true;
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
            col.DataType = typeof(CustomData.WP.Position);
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
        readonly string homeColumnName = "初始位置";
        readonly string frameColumnName = "高度框架";
        readonly string scaleColumnName = "图层比例尺";
        readonly string transColumnName = "图层透明色";

        public DataTable GetLayerTable()
        {
            DataTable table = new DataTable(TiffLayerHandle);

            DataColumn col = new DataColumn();
            col.ColumnName = keyColumnName;
            col.DataType = Type.GetType("System.String");
            table.Columns.Add(col);


            col = new DataColumn();
            col.ColumnName = homeColumnName;
            col.DataType = typeof(CustomData.WP.Position);
            table.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = frameColumnName;
            col.DataType = Type.GetType("System.String");
            table.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = scaleColumnName;
            col.DataType = Type.GetType("System.String");
            table.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = transColumnName;
            col.DataType = typeof(Color);
            table.Columns.Add(col);


            return table;
        }
        #endregion

        #region 生成Tiff行
        private void FillLayerTable(DataTable table, CustomData.Layer.TiffLayerInfo emp)
        {
            DataRow fileRow = table.NewRow();

            fileRow[keyColumnName] = emp.GetOnlyCode();
            fileRow[homeColumnName] = emp.Home;
            fileRow[frameColumnName] = emp.Home.AltMode;
            fileRow[scaleColumnName] = emp.ScaleFormat;
            fileRow[transColumnName] = emp.Transparent;

            table.Rows.Add(fileRow);

            fileRow.AcceptChanges();
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

        #endregion

        #region 绑定数据源
        DataSet set = new DataSet(MainHandle);
        DataTable table = new DataTable(MainLayerHandle);
        DataTable layerTable = new DataTable(TiffLayerHandle);

        const string MainHandle = "LayerManager";
        public void BindingDataSource()
        {
            set = new DataSet(MainHandle);

            table = GetMainTable();
            layerTable = GetLayerTable();

            BindingData();

            set.Tables.Add(table);
            set.Tables.Add(layerTable);

            set.Relations.Add("1", set.Tables[MainLayerHandle].Columns[keyColumnName],
                               set.Tables[TiffLayerHandle].Columns[keyColumnName], false);
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

            BeginLoadData();

            // Add 50 rows to fiddle with
            List<CustomData.Layer.LayerInfo> emp = GetDataSource();
            for (int i = 0; i < emp.Count; i++)
            {
                FillMainTable(table, emp[i]);

                if (emp[i] is CustomData.Layer.TiffLayerInfo)
                {
                    FillLayerTable(layerTable, emp[i] as CustomData.Layer.TiffLayerInfo);
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
            CustomData.Layer.MemoryLayerCache.DeleteLayerInMenoryCacheWithHashCode(key);
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

        private void LayerDataList_RowActivated(object sender, GridRowActivatedEventArgs e)
        {
            ExchangeInfo(LayerDataList.GetCell(e.NewActiveRow.RowIndex, 0).Value.ToString());
        }

        private void ExchangeInfo(string hash)
        {
            CustomData.Layer.LayerInfo info = CustomData.Layer.MemoryLayerCache.GetLayerFromMemoryCacheWithHashCode(hash);
            if (info is CustomData.Layer.TiffLayerInfo)
            {
                TiffLayerDisplay display = new TiffLayerDisplay();
                display.Dock = DockStyle.Fill;

                display.SetLayer(info as CustomData.Layer.TiffLayerInfo);

                panelEx2.Controls.Clear();
                panelEx2.Controls.Add(display);
            }
        }
    }

}
