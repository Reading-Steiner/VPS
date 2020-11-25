using DotSpatial.Projections;
using Ionic.Zip;
using SharpKml.Base;
using SharpKml.Dom;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPS.Utilities;

namespace VPS.CustomFile
{
    class KML
    {
        static KML()
        {
        }

        public delegate void Progress(double percent, string message);
        public delegate void Meaasge(string message);

        public static event Progress OnProgress;
        public static event Meaasge OnChangeTarget;
        public static event Meaasge OnSuccess;
        public static event Meaasge OnFailure;
        public static event Meaasge OnInfoMessage;
        public static event Meaasge OnWarnMessage;


        public delegate void ListChange(List<PointLatLngAlt> list);
        public static event ListChange OnAddList;

        //[DllImport("gdal232.dll", CallingConvention = CallingConvention.Cdecl)]
        //public static extern IntPtr OGR_F_GetFieldAsString(HandleRef handle, int fieldIdx);

        public static KMLDataSet ReadKML(string file)
        {
            string kml = "";
            string tempdir = "";

            KMLDataSet dataSet = new KMLDataSet();

            if (file.ToLower().EndsWith("kmz"))
            {
                ZipFile input = new ZipFile(file);

                tempdir = Path.GetTempPath() + Path.DirectorySeparatorChar + Path.GetRandomFileName();
                input.ExtractAll(tempdir, ExtractExistingFileAction.OverwriteSilently);

                string[] kmls = Directory.GetFiles(tempdir, "*.kml");

                if (kmls.Length > 0)
                {
                    file = kmls[0];

                    input.Dispose();
                }
                else
                {
                    input.Dispose();
                    return dataSet;
                }
            }

            var sr = new StreamReader(File.OpenRead(file));
            kml = sr.ReadToEnd();
            sr.Close();

            // cleanup after out
            if (tempdir != "")
                Directory.Delete(tempdir, true);

            kml = kml.Replace("<Snippet/>", "");

            var parser = new Parser();
            parser.ElementAdded += OnElementAdded;
            OnAddList += dataSet.AddPolygon;
            parser.ParseString(kml, false);

            return dataSet;
        }

        static private void OnElementAdded(object sender, ElementEventArgs e)
        {
            try
            {
                Element element = e.Element;

                Document doc = element as Document;
                Placemark pm = element as Placemark;
                Folder folder = element as Folder;
                Polygon polygon = element as Polygon;
                LineString ls = element as LineString;

                if (doc != null)
                {
                    foreach (var feat in doc.Features)
                    {
                        //Console.WriteLine("feat " + feat.GetType());
                        //processKML((Element)feat);
                    }
                }
                else if (folder != null)
                {
                    foreach (Feature feat in folder.Features)
                    {
                        //Console.WriteLine("feat "+feat.GetType());
                        //processKML(feat);
                    }
                }
                else if (pm != null)
                {
                    //if (pm.Geometry is SharpKml.Dom.Point)
                    //{
                    //    var point = ((SharpKml.Dom.Point)pm.Geometry).Coordinate;
                    //    POI.POIAdd(new PointLatLngAlt(point.Latitude, point.Longitude), pm.Name);
                    //}
                }
                else if (polygon != null)
                {
                }
                else if (ls != null)
                {
                    string altmode = "";
                    switch (ls.AltitudeMode)
                    {
                        case AltitudeMode.Absolute:
                            altmode = CustomData.EnumCollect.AltFrame.Absolute;
                            break;
                        case AltitudeMode.ClampToGround:
                            altmode = CustomData.EnumCollect.AltFrame.Terrain;
                            break;
                        case AltitudeMode.RelativeToGround:
                            altmode = CustomData.EnumCollect.AltFrame.Terrain;
                            break;
                        default:
                            altmode = CustomData.EnumCollect.AltFrame.Absolute;
                            break;
                    }
                    List<PointLatLngAlt> list = new List<PointLatLngAlt>();
                    foreach (var loc in ls.Coordinates)
                    {
                        PointLatLngAlt point = new PointLatLngAlt(loc.Latitude, loc.Longitude, (int)loc.Altitude);
                        point.Tag = CustomData.WP.WPCommands.DefaultWPCommand;
                        point.Tag2 = altmode;
                        list.Add(point);
                    }
                    OnAddList?.Invoke(list);
                }
            }
            catch { }
            finally
            {
            }
        }


        public class KMLDataSet
        {
            public string coordinates;
            public List<List<PointLatLngAlt>> points;

            public KMLDataSet()
            {
                this.coordinates = KnownCoordinateSystems.Geographic.World.WGS1984.ToEsriString();

                points = new List<List<PointLatLngAlt>>();
            }

            public void AddPolygon(List<PointLatLngAlt> poly)
            {
                points.Add(poly);
            }

            public void AddPoint(PointLatLngAlt point)
            {
                if (points.Count > 0)
                    points[points.Count - 1].Add(point);
                else
                {
                    points.Add(new List<PointLatLngAlt>());
                    points[points.Count - 1].Add(point);
                }

            }

            public void AddPoint(int indedx, PointLatLngAlt point)
            {
                if (points.Count > 0)
                    points[points.Count - 1].Add(point);
                else
                {
                    points.Add(new List<PointLatLngAlt>());
                    points[points.Count - 1].Add(point);
                }

            }

            public void ClearPoygon()
            {
                points.Clear();
            }
        }
    }
}
