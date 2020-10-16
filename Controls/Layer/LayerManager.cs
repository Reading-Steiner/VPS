using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPS.Controls.Layer
{
    public partial class LayerManager : UserControl
    {
        public LayerManager()
        {
            InitializeComponent();
            BindingDataSource();
        }

        public List<VPS.Layer.LayerInfo> GetDataSource()
        {
            List<VPS.Layer.LayerInfo> dataSource = new List<VPS.Layer.LayerInfo>();
            for (int index = 0; index < VPS.Layer.MemoryLayerCache.Count; index++)
            {
                var info = VPS.Layer.MemoryLayerCache.GetLayerFromMemoryCache(index);
                if (info != null) 
                {
                    dataSource.Add(info.GetValueOrDefault());
                }
            }
            return dataSource;
        }

        public DataTable GetMainTable()
        {
            DataTable table = new DataTable("LayerTitle");

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
            return table;
        }

        public DataTable GetFileTable()
        {
            DataTable table = new DataTable("FileLayerTitle");

            DataColumn col = new DataColumn();
            col.ColumnName = "Key";
            col.DataType = Type.GetType("System.String");
            table.Columns.Add(col);


            col = new DataColumn();
            col.ColumnName = "图层原点";
            col.DataType = new Utilities.PointLatLngAlt().GetType();
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
            col.DataType = new Color().GetType();
            table.Columns.Add(col);


            return table;
        }

        public void BindingDataSource()
        {
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
                row[2] = emp[i].LayerType;

                table.Rows.Add(row);

                row.AcceptChanges();

                switch (emp[i].LayerType)
                {
                    case "file":
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
            }
            table.EndLoadData();

            set.Relations.Add("1", set.Tables["LayerTitle"].Columns["Key"],
                                           set.Tables["FileLayerTitle"].Columns["Key"], false);
            LayerDataList.PrimaryGrid.DataSource = set;

        }
    }
}
