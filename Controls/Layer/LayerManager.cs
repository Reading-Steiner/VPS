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
using System.Reflection;
using System.Collections;

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

            //CustomData.Layer.MemoryLayerCache.LayerInfosChange += BindingDataSource;
        }

        private void LayerManager_Load(object sender, EventArgs e)
        {
            MainDataTable = CreateMainTable();
            TiffDataTable = CreateTiffTable();

            BindingDataSource();
            set.Tables.Add(MainDataTable);
            set.Tables.Add(TiffDataTable);

            set.Relations.Add("1", set.Tables[MainLayerHandle].Columns["识别码"],
                               set.Tables[TiffLayerHandle].Columns["识别码"], false);

            LayerDataList.PrimaryGrid.DataSource = set;
            LayerDataList.PrimaryGrid.DataMember = MainLayerHandle;
        }

        public static string GetDisplayName(PropertyInfo propertyInfo)
        {
            var Attributes = propertyInfo.GetCustomAttributes(false);
            if (Attributes.Count() > 0) {
                var info = Attributes.OfType<DisplayNameAttribute>();
                if (info != null && info.Count() > 0)
                    return info.ElementAt(0).DisplayName;
                else
                    return propertyInfo.Name;
            }
            else
                return propertyInfo.Name;
        }

        public static bool IsNullable(Type t)
        {
            return !t.IsValueType || (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

        public static Type GetCoreType(Type t)
        {
            if (t != null && IsNullable(t))
            {
                if (!t.IsValueType)
                {
                    return t;
                }
                else
                {
                    return Nullable.GetUnderlyingType(t);
                }
            }
            else
            {
                return t;
            }
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
        DataTable MainDataTable = new DataTable(MainLayerHandle);

        public DataTable CreateMainTable()
        {
            DataTable table = new DataTable(MainLayerHandle);

            PropertyInfo[] props = typeof(LayerMangerMainDataSource).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in props)
            {
                Type t = GetCoreType(prop.PropertyType);
                table.Columns.Add(GetDisplayName(prop), t);
            }

            table.Columns.Add("删除", typeof(string));
            table.Columns.Add("默认", typeof(bool));

            return table;
        }

        public DataTable BindingMainTable(List<LayerMangerMainDataSource> items)
        {
            MainDataTable.Clear();

            PropertyInfo[] props = typeof(LayerMangerMainDataSource).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var item in items)
            {
                var values = new object[props.Length + 2];

                for (int i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }
                values[props.Length] = "";
                if (CustomData.WP.WPGlobalData.instance != null &&
                    CustomData.WP.WPGlobalData.instance.IsDefaultLayer(values[1].ToString()))
                {
                    values[props.Length + 1] = "True";
                }
                else
                {
                    values[props.Length + 1] = "false";
                }

                MainDataTable.Rows.Add(values);
            }

            return MainDataTable;
        }
        #endregion

        #region 生成主表行
        private void FillMainTable(CustomData.Layer.LayerInfo emp)
        {
            LayerMangerMainDataSource ds = new LayerMangerMainDataSource();

            ds.Key = emp.GetOnlyCode();
            ds.Layer = emp.Layer;
            ds.ModifyTime = emp.ModifyTime;
            ds.CreateTime = emp.CreateTime;

            if (emp is CustomData.Layer.TiffLayerInfo)
            {
                ds.Type = "本地文件";
            }

            MainDataSource.Add(ds);
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

            panel.Columns[3].MinimumWidth = 160;
            panel.Columns[3].ReadOnly = true;

            panel.Columns[4].MinimumWidth = 160;
            panel.Columns[4].ReadOnly = true;

            panel.Columns[5].MinimumWidth = 25;
            panel.Columns[5].Width = 25;
            panel.Columns[5].EditorType = typeof(CustomControls.ImagePanel);
            panel.Columns[5].EditorParams = new object[] { ImageList.Images["Delete.png"] };

            panel.Columns[6].MinimumWidth = 25;
            panel.Columns[6].Width = 25;
            panel.Columns[6].EditorType = typeof(CustomControls.ImageCheckBox);
            panel.Columns[6].EditorParams = new object[] { ImageList.Images["Default.png"] };
            panel.Columns[6].ReadOnly = true;
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
        DataTable TiffDataTable = new DataTable(TiffLayerHandle);

        public DataTable CreateTiffTable()
        {
            DataTable table = new DataTable(TiffLayerHandle);

            PropertyInfo[] props = typeof(LayerMangerTiffDataSource).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in props)
            {
                Type t = GetCoreType(prop.PropertyType);
                table.Columns.Add(GetDisplayName(prop), t);
            }

            return table;
        }

        public DataTable BindingLayerTable(List<LayerMangerTiffDataSource> items)
        {
            TiffDataTable.Clear();

            PropertyInfo[] props = typeof(LayerMangerTiffDataSource).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var item in items)
            {
                var values = new object[props.Length];

                for (int i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }

                TiffDataTable.Rows.Add(values);
            }

            return TiffDataTable;
        }
        #endregion

        #region 生成Tiff行
        private void FillLayerTable(CustomData.Layer.TiffLayerInfo emp)
        {
            LayerMangerTiffDataSource ds = new LayerMangerTiffDataSource();

            ds.Key = emp.GetOnlyCode();
            ds.HomePosition = new LoadAndSave.Position(emp.Home);
            ds.AltFrame = emp.Home.AltMode;
            ds.Scale = emp.ScaleFormat;
            ds.Transparent = emp.Transparent;

            TiffDataSource.Add(ds);
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
            //panel.Columns[3].Visible = false;

            panel.Columns[4].MinimumWidth = 200;
        }
        #endregion

        #endregion

        #endregion

        #region 绑定数据源
        DataSet set = new DataSet(MainHandle);

        List<LayerMangerMainDataSource> MainDataSource = new List<LayerMangerMainDataSource>();
        List<LayerMangerTiffDataSource> TiffDataSource = new List<LayerMangerTiffDataSource>();

        const string MainHandle = "LayerManager";
        public void BindingDataSource()
        {
            if (isEdit)
                return;
            StartEdit();

            LoadLayerInfoData();

            BeginLoadData();

            BindingMainTable(MainDataSource);
            BindingLayerTable(TiffDataSource);

            EndLoadData();

            EndEdit();
        }
        #endregion

        #region 绑定数据 BeginLoadData
        private void BeginLoadData()
        {
            MainDataTable.BeginLoadData();
            TiffDataTable.BeginLoadData();
        }
        #endregion

        #region 绑定数据 EndLoadData
        private void EndLoadData()
        {
            TiffDataTable.EndLoadData();
            MainDataTable.EndLoadData();
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
        #endregion

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
        public void LoadLayerInfoData()
        {
            MainDataSource.Clear();
            TiffDataSource.Clear();

            // Add 50 rows to fiddle with
            List<CustomData.Layer.LayerInfo> emp = GetDataSource();
            for (int i = 0; i < emp.Count; i++)
            {
                FillMainTable(emp[i]);

                if (emp[i] is CustomData.Layer.TiffLayerInfo)
                {
                    FillLayerTable(emp[i] as CustomData.Layer.TiffLayerInfo);
                }

            }
        }
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
            ExchangeInfo(e.NewActiveRow.GridPanel.GetCell(e.NewActiveRow.RowIndex, 0).Value.ToString());
        }

        private void ExchangeInfo(string hash)
        {
            CustomData.Layer.LayerInfo info = CustomData.Layer.MemoryLayerCache.GetLayerFromMemoryCacheWithHashCode(hash);
            if (info is CustomData.Layer.TiffLayerInfo)
            {
                TiffLayerDisplay display = new TiffLayerDisplay(info as CustomData.Layer.TiffLayerInfo);
                display.Dock = DockStyle.Fill;

                panelEx2.Controls.Clear();
                panelEx2.Controls.Add(display);
            }
        }

        private void DefaultLayer_Click(object sender, EventArgs e)
        {
            string key = LayerDataList.ActiveRow.GridPanel.GetCell(LayerDataList.ActiveRow.RowIndex, 0).Value.ToString();
        }

        private void InvalidGrid_Click(object sender, EventArgs e)
        {
            BindingDataSource();
        }
    }

    [TypeConverter(typeof(LoadAndSave.PropertySorter))]
    public class LayerMangerMainDataSource
    {
        [Category("图层信息"), DisplayName("识别码"), ReadOnly(false)]
        [LoadAndSave.PropertyOrder(0b00010001)]
        //[Browsable(false)]
        public string Key { get; set; }

        [Category("图层信息"), DisplayName("图层"), ReadOnly(false)]
        [LoadAndSave.PropertyOrder(0b00010010)]
        public string Layer { get; set; }

        [Category("图层信息"), DisplayName("图层类型"), ReadOnly(false)]
        [LoadAndSave.PropertyOrder(0b00010011)]
        public string Type { get; set; }

        [Category("图层信息"), DisplayName("创建时间"), ReadOnly(false)]
        [LoadAndSave.PropertyOrder(0b00010011)]
        public string CreateTime { get; set; }

        [Category("图层信息"), DisplayName("修改时间"), ReadOnly(false)]
        [LoadAndSave.PropertyOrder(0b00010011)]
        public string ModifyTime { get; set; }
    }

    [TypeConverter(typeof(LoadAndSave.PropertySorter))]
    public class LayerMangerTiffDataSource
    {
        [Category("图层信息"), DisplayName("识别码"), ReadOnly(false)]
        [LoadAndSave.PropertyOrder(0b00010001)]
        //[Browsable(false)]
        public string Key { get; set; }

        [Category("图层信息"), DisplayName("初始位置"), ReadOnly(false)]
        [LoadAndSave.PropertyOrder(0b00010010)]
        public LoadAndSave.Position HomePosition { get; set; }

        [Category("图层信息"), DisplayName("高度框架"), ReadOnly(false)]
        [LoadAndSave.PropertyOrder(0b00010011)]
        public string AltFrame { get; set; }

        [Category("图层信息"), DisplayName("图层比例尺"), ReadOnly(false)]
        [LoadAndSave.PropertyOrder(0b00010100)]
        public string Scale { get; set; }

        [Category("图层信息"), DisplayName("图层透明色"), ReadOnly(false)]
        [LoadAndSave.PropertyOrder(0b00010101)]
        public Color Transparent { get; set; }
    }

}
