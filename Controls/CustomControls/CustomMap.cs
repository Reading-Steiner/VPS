using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VPS.Utilities;
using GMap.NET.WindowsForms;
using GMap.NET;
using System.Xml;
using System.Net;
using VPS.Maps;
using GMap.NET.MapProviders;

namespace VPS.Controls.CustomControls
{
    public partial class CustomMap : UserControl
    {
        public List<List<CustomData.WP.Position>> lists = new List<List<CustomData.WP.Position>>();
        public List<List<CustomData.WP.Position>> List
        {
            set
            {
                if (value != null)
                {
                    lists = new List<List<CustomData.WP.Position>>(value);
                    List<int> indexs = new List<int>();
                    for(int index = 0; index < lists.Count; index++)
                        indexs.Add(index);
                    ListList.DataSource = indexs;
                    if (lists.Count > 1)
                        ListList.Visible = true;
                    else
                        ListList.Visible = false;
                }
            }
        }

        public int currentIndex = -1;

        public GMapOverlay _overlay;
        internal GMapPolygon _polygon;


        public Color color = Color.Green;

        public CustomMap()
        {
            InitializeComponent();

            MainMap.CacheLocation = Settings.GetDataDirectory() + "gmapcache" + System.IO.Path.DirectorySeparatorChar;
            MainMap.MapScaleInfoEnabled = false;
            MainMap.ScalePen = new Pen(Color.Red);
            MainMap.DisableFocusOnMouseEnter = true;
            MainMap.ForceDoubleBuffer = false;
            MainMap.RoutesEnabled = true;
            MainMap.MinZoom = 0;
            MainMap.MaxZoom = 24;

            MainMap.OnMapTypeChanged += MainMap_OnMapTypeChanged;
            MainMap.OnMapZoomChanged += MainMap_OnMapZoomChanged;
            MainMap.OnTileLoadComplete += MainMap_OnTileLoadComplete;
            MainMap.OnTileLoadStart += MainMap_OnTileLoadStart;

            _overlay = new GMapOverlay("overlay");
            MainMap.Overlays.Add(_overlay);

            string mapType = "谷歌中国卫星地图";
            var index = GMapProviders.List.FindIndex(x => (x.Name == mapType));
            if (index != -1)
                MainMap.MapProvider = GMapProviders.List.Find(x => (x.Name == mapType));
            else
                MainMap.MapProvider = GMapProviders.List.Find(x => (x.Name == "GoogleSatelliteMap"));

            //setup drawnpolgon
            List<PointLatLng> polygonPoints2 = new List<PointLatLng>();
            _polygon = new GMapPolygon(polygonPoints2, "drawnpoly");
            _polygon.Stroke = new Pen(Color.Red, 2);
            _polygon.Fill = Brushes.Transparent;

            ListList.Visible = false;

            writeKML();
        }

        public void AddList(List<CustomData.WP.Position> list)
        {
            if (list != null)
            {
                lists.Add(new List<CustomData.WP.Position>(list));
                List<int> indexs = new List<int>();
                for (int index = 0; index < lists.Count; index++)
                    indexs.Add(index);
                ListList.DataSource = indexs;
                if(lists.Count > 1)
                    ListList.Visible = true;
                else
                    ListList.Visible = false;
            }
        }

        private void writeKML()
        {
            if (currentIndex >=0 && currentIndex < lists.Count)
            {
                List<CustomData.WP.Position> list = lists[currentIndex];

                _polygon.Points.Clear();
                _overlay.Clear();

                int tag = 0;
                list.ForEach(x =>
                {
                    _polygon.Points.Add(x.ToWGS84());
                    AddMarker(x, tag.ToString());
                    tag++;
                });

                _overlay.Polygons.Add(_polygon);
                MainMap.UpdatePolygonLocalPosition(_polygon);
                MainMap.SetZoomToFitRect(GetBoundingLayer(lists[currentIndex]));
            }
        }

        private void AddMarker(CustomData.WP.Position point, string info)
        {
            var marker = new CustomData.Markers.GMapMarkerCustom(point.ToWGS84(), info);
            _overlay.Markers.Add(marker);
        }

        private static RectLatLng GetBoundingLayer(List<CustomData.WP.Position> list)
        {
            RectLatLng ret = RectLatLng.Empty;

            double left = double.MaxValue;
            double top = double.MinValue;
            double right = double.MinValue;
            double bottom = double.MaxValue;

            if (list != null) 
            {
                foreach (var p in list)
                {
                    if (p.Lng < left)
                        left = p.Lng;

                    if (p.Lat > top)
                        top = p.Lat;

                    if (p.Lng > right)
                        right = p.Lng;

                    if (p.Lat < bottom)
                        bottom = p.Lat;
                }
            }

            if (left != double.MaxValue && right != double.MinValue && top != double.MinValue && bottom != double.MaxValue)
            {
                ret = RectLatLng.FromLTRB(left, top, right, bottom);
            }

            return ret;
        }

        private void MainMap_OnTileLoadComplete(long ElapsedMilliseconds)
        {
            //MainMap.ElapsedMilliseconds = ElapsedMilliseconds;

            MethodInvoker m = delegate
            {
            };
            try
            {
                if (!IsDisposed && IsHandleCreated) BeginInvoke(m);
            }
            catch (Exception ex)
            {
            }
        }

        private void MainMap_OnTileLoadStart()
        {
            MethodInvoker m = delegate {};
            try
            {
                if (IsHandleCreated) BeginInvoke(m);
            }
            catch (Exception ex)
            {
            }
        }

        private void MainMap_OnMapZoomChanged()
        {
            if (MainMap.Zoom > 0)
            {
                try
                {
                }
                catch (Exception ex)
                {
                }
                //textBoxZoomCurrent.Text = MainMap.Zoom.ToString();
            }
        }

        private void ListList_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentIndex = (int)ListList.SelectedValue;
            ListInfo.Text = "节点个数：" + lists.Count.ToString();
            writeKML();
        }

        private void MainMap_OnMapTypeChanged(GMapProvider type)
        {
            if (type == WMSProvider.Instance)
            {
                string url = "";
                if (Settings.Instance["WMSserver"] != null)
                    url = Settings.Instance["WMSserver"];
                if (DialogResult.Cancel == InputBox.Show("WMS Server", "请输入 WMS server URL", ref url))
                    return;

                // Build get capability request.
                string szCapabilityRequest = BuildGetCapabilitityRequest(url);

                XmlDocument xCapabilityResponse = MakeRequest(szCapabilityRequest);
                ProcessWmsCapabilitesRequest(xCapabilityResponse);

                Settings.Instance["WMSserver"] = url;
                WMSProvider.CustomWMSURL = url;
            }
        }

        private XmlDocument MakeRequest(string requestUrl)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                if (!String.IsNullOrEmpty(Settings.Instance.UserAgent))
                    ((HttpWebRequest)request).UserAgent = Settings.Instance.UserAgent;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;


                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(response.GetResponseStream());
                return (xmlDoc);
            }
            catch (Exception e)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Failed to make WMS Server request: " + e.Message);
                return null;
            }
        }

        private void ProcessWmsCapabilitesRequest(XmlDocument xCapabilitesResponse)
        {
            //Create namespace manager
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xCapabilitesResponse.NameTable);

            //check if the response is a valid xml document - if not, the server might still be able to serve us but all the checks below would fail. example: http://tiles.kartat.kapsi.fi/peruskartta
            //best sign is that there is no node WMT_MS_Capabilities
            if (xCapabilitesResponse.SelectNodes("//WMT_MS_Capabilities", nsmgr).Count == 0)
                return;


            //first, we have to make sure that the server is able to send us png imagery
            bool bPngCapable = false;
            XmlNodeList getMapElements = xCapabilitesResponse.SelectNodes("//GetMap", nsmgr);
            if (getMapElements.Count != 1)
                DevComponents.DotNetBar.MessageBoxEx.Show("Invalid WMS Server response: Invalid number of GetMap elements.");
            else
            {
                XmlNode getMapNode = getMapElements.Item(0);
                //search through all format nodes for image/png
                foreach (XmlNode formatNode in getMapNode.SelectNodes("//Format", nsmgr))
                {
                    if (formatNode.InnerText.Contains("image/png"))
                    {
                        bPngCapable = true;
                        break;
                    }
                }
            }


            if (!bPngCapable)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Invalid WMS Server response: Server unable to return PNG images.");
                return;
            }


            //now search through all layer -> srs nodes for EPSG:4326 compatibility
            bool bEpsgCapable = false;
            XmlNodeList srsELements = xCapabilitesResponse.SelectNodes("//SRS", nsmgr);
            foreach (XmlNode srsNode in srsELements)
            {
                if (srsNode.InnerText.Contains("EPSG:4326"))
                {
                    bEpsgCapable = true;
                    break;
                }
            }


            if (!bEpsgCapable)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show(
                    "Invalid WMS Server response: Server unable to return EPSG:4326 / WGS84 compatible images.");
                return;
            }


            // the server is capable of serving our requests - now check if there is a layer to be selected
            // Display layer title in the input box instead of layer name.
            // format: layer -> layer -> name
            //         layer -> layer -> title
            string szLayerSelection = "";
            int iSelect = 0;
            List<string> szListLayerName = new List<string>();
            // Loop through all layers.
            XmlNodeList layerElements = xCapabilitesResponse.SelectNodes("//Layer/Layer", nsmgr);
            foreach (XmlNode layerElement in layerElements)
            {
                // Get Name element.
                var nameNode = layerElement.SelectSingleNode("Name", nsmgr);

                // Skip if no name element is found.
                if (nameNode != null)
                {
                    var name = nameNode.InnerText;
                    // Set the default title as the layer name. 
                    var title = name;
                    // Get Title element.
                    var titleNode = layerElement.SelectSingleNode("Title", nsmgr);
                    if (titleNode != null)
                    {
                        var titleText = titleNode.InnerText;
                        if (!string.IsNullOrWhiteSpace(titleText))
                        {
                            title = titleText;
                        }
                    }
                    szListLayerName.Add(name);

                    szLayerSelection += string.Format("{0}: {1}\n ", iSelect, title);
                    //mixing control and formatting is not optimal...
                    iSelect++;
                }
            }

            //only select layer if there is one
            if (szListLayerName.Count != 0)
            {
                //now let the user select a layer
                string szUserSelection = "";
                if (DialogResult.Cancel ==
                    InputBox.Show("WMS Server",
                        "The following layers were detected:\n " + szLayerSelection +
                        "Please choose one by typing the associated number.", ref szUserSelection))
                    return;
                int iUserSelection = 0;
                try
                {
                    iUserSelection = Convert.ToInt32(szUserSelection);
                }
                catch (Exception ex)
                {
                    iUserSelection = 0; //ignore all errors and default to first layer
                }

                WMSProvider.szWmsLayer = szListLayerName[iUserSelection];
                Settings.Instance["WMSLayer"] = WMSProvider.szWmsLayer;
            }
        }

        private string BuildGetCapabilitityRequest(string serverUrl)
        {
            // What happens if the URL already has  '?'. 
            // For example: http://foo.com?Token=yyyy
            // In this example, the get capability request should be 
            // http://foo.com?Token=yyyy&version=1.1.0&Request=GetCapabilities&service=WMS but not
            // http://foo.com?Token=yyyy?version=1.1.0&Request=GetCapabilities&service=WMS

            // If the URL doesn't contain '?', append it.
            if (!serverUrl.Contains("?"))
            {
                serverUrl += "?";
            }
            else
            {
                // Check if the URL already has query strings.
                // If the URL doesn't have query strings, '?' comes at the end.
                if (!serverUrl.EndsWith("?"))
                {
                    // Already have query string, so add '&' before adding other query strings.
                    serverUrl += "&";
                }
            }
            return serverUrl + "version=1.1.0&Request=GetCapabilities&service=WMS";
        }
    }
}
