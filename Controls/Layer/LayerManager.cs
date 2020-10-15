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

        }

        public List<GMap.NET.Internals.LayerInfo> GetDataSource()
        {
            List<GMap.NET.Internals.LayerInfo> dataSource = new List<GMap.NET.Internals.LayerInfo>();
            for (int index = 0; index < GMap.NET.CacheProviders.MemoryLayerCache.Count; index++)
            {
                var info = GMap.NET.CacheProviders.MemoryLayerCache.GetLayerFromMemoryCache(index);
                if (info != null) 
                {
                    dataSource.Add(info.GetValueOrDefault());
                }
            }
            return dataSource;
        }

        public void BindingDataSource()
        {
            LayerDataList.PrimaryGrid.DataSource = GetDataSource();
            LayerDataList.PrimaryGrid.DataMember = null;
        }
    }
}
