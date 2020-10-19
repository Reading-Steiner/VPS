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
            BindingDataSource();
            VPS.Layer.MemoryLayerCache.LayerInfosChange += BindingDataSource;
        }

        public List<VPS.Layer.LayerInfo> GetDataSource()
        {
            List<VPS.Layer.LayerInfo> dataSource = new List<VPS.Layer.LayerInfo>();
            for (int index = 0; index < VPS.Layer.MemoryLayerCache.TotalCount; index++)
            {
                var info = VPS.Layer.MemoryLayerCache.GetLayerFromMemoryCache(index, true);
                if (info != null) 
                {
                    dataSource.Add(info.GetValueOrDefault());
                }
            }
            return dataSource;
        }

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
            col.ColumnName = "删除";
            col.DataType = Type.GetType("System.String");
            table.Columns.Add(col);
            return table;
        }

        const string FileLayerHandle = "FileLayer";
        public DataTable GetFileTable()
        {
            DataTable table = new DataTable(FileLayerHandle);

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

        public void BindingDataSource()
        {
            if (isEdit)
                return;
            StartEdit();
            DataSet set = new DataSet("LayerManager");

            var table = GetMainTable();
            var fileTable = GetFileTable();

            set.Tables.Add(table);
            set.Tables.Add(fileTable);
            table.BeginLoadData();

            // Add 50 rows to fiddle with
            var emp = GetDataSource();
            for (int i = 0; i < emp.Count; i++)
            {
                DataRow row = table.NewRow();

                row[0] = emp[i].GetHashCode();
                row[1] = emp[i].Layer;
                

                

                switch (emp[i].LayerType)
                {
                    case "file":
                        row[2] = "本地文件";
                        fileTable.BeginLoadData();
                        DataRow fileRow = fileTable.NewRow();
                        fileRow[0] = emp[i].GetHashCode();
                        fileRow[1] = emp[i].Origin;
                        fileRow[2] = emp[i].Origin.Tag2;
                        fileRow[3] = emp[i].ScaleFormat;
                        fileRow[4] = emp[i].Transparent;

                        fileTable.Rows.Add(fileRow);

                        fileRow.AcceptChanges();
                        fileTable.EndLoadData();
                        break;
                }

                row[3] = "";


                table.Rows.Add(row);

                row.AcceptChanges();
            }
            table.EndLoadData();

            set.Relations.Add("1", set.Tables[MainLayerHandle].Columns["Key"],
                                           set.Tables[FileLayerHandle].Columns["Key"], false);
            LayerDataList.PrimaryGrid.DataSource = set;
            LayerDataList.PrimaryGrid.DataMember = MainLayerHandle;
            EndEdit();
        }

        private void LayerDataList_DataBindingComplete(object sender, DevComponents.DotNetBar.SuperGrid.GridDataBindingCompleteEventArgs e)
        {
            GridPanel panel = e.GridPanel;

            switch (panel.DataMember)
            {
                case MainLayerHandle:
                    CustomizeMainLayerPanel(panel);
                    break;

                case FileLayerHandle:
                    CustomizeFileLayerPanel(panel);
                    break;
            }
        }

        private void CustomizeMainLayerPanel(GridPanel panel)
        {
            panel.FrozenColumnCount = 1;
            panel.ColumnHeader.RowHeight = 30;

            panel.ColumnAutoSizeMode = ColumnAutoSizeMode.None;
            panel.Columns[0].MinimumWidth = 80;

            panel.Columns[1].MinimumWidth = 400;

            panel.Columns[2].MinimumWidth = 80;
            panel.Columns[2].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;

            panel.Columns[3].EditorType = typeof(ImageLabel);
            panel.Columns[3].EditorParams = new object[] { ImageList.Images["Delete.png"] };
            panel.Columns[3].MinimumWidth = 25;
            panel.Columns[3].Width = 25;
            //panel.Columns[3].EditControl.EditorCellBitmap = ImageList.Images["Delete.png"];

        }

        private void CustomizeFileLayerPanel(GridPanel panel)
        {
            panel.FrozenColumnCount = 1;
            panel.ColumnHeader.RowHeight = 30;
            panel.ColumnAutoSizeMode = ColumnAutoSizeMode.None;

            panel.Columns[0].MinimumWidth = 80;
            panel.Columns[0].Visible = false;

            panel.Columns[1].MinimumWidth = 250;

            panel.Columns[2].MinimumWidth = 80;
            panel.Columns[2].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;

            panel.Columns[3].MinimumWidth = 80;
            panel.Columns[3].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;

            panel.Columns[4].MinimumWidth = 200;
            panel.Columns[4].CellStyles.Default.TextColor = FromString(panel.GetCell(0, 4).Value.ToString());


        }

        private Color FromString(string fromat)
        {
            List<int> color = new List<int>();
            foreach(var str in System.Text.RegularExpressions.Regex.Matches(fromat, @"[0-9]+")) {

                color.Add(int.Parse(str.ToString()));
            }
            return Color.FromArgb(
                color.Count > 0 ? color[0] : 0,
                color.Count > 1 ? color[1] : 0,
                color.Count > 2 ? color[2] : 0,
                color.Count > 3 ? color[3] : 0
                );
        }

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
    }

    internal class ImageLabel : GridLabelXEditControl
    {
        #region Private variables

        #endregion

        public ImageLabel(Image image)
        {
            Image = image;
        }

    }
}
