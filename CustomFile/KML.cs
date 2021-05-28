﻿using DotSpatial.Projections;
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

        public delegate void ProgressMessageOutTime(string message, int time);
        public delegate void ProgressMessage(string message);
        public delegate void Progress(double percent);
        public delegate void Meaasge(string message);

        public event ProgressMessage OnProgressStart;
        public event ProgressMessage OnProgressInfo;
        public event ProgressMessageOutTime OnProgressEnd;
        public event ProgressMessage OnProgressSuccess;
        public event ProgressMessage OnProgressFailure;
        public event Progress OnProgress;
        public event Meaasge OnInfoMessage;
        public event Meaasge OnWarnMessage;


        public delegate void ListChange(List<CustomData.WP.VPSPosition> list);
        public static event ListChange OnAddList;

        //[DllImport("gdal232.dll", CallingConvention = CallingConvention.Cdecl)]
        //public static extern IntPtr OGR_F_GetFieldAsString(HandleRef handle, int fieldIdx);
        int progress = 0;
        public KMLDataSet ReadKML(string file)
        {
            string kml = "";
            string tempdir = "";

            OnProgressStart?.Invoke("加载 KML");

            KMLDataSet dataSet = new KMLDataSet();

            if (file.ToLower().EndsWith("kmz"))
            {
                OnProgressInfo?.Invoke("解析 KMZ");
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

                    OnInfoMessage?.Invoke(string.Format("【{0}】为空或不包含 KML！", file));
                    OnProgressFailure?.Invoke("KML 加载失败");
                    return dataSet;
                }

                OnProgressStart?.Invoke("加载 KML");
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

            progress = 0;

            parser.ParseString(kml, false);

            OnInfoMessage?.Invoke(string.Format("【{0}】 加载成功！", file));
            OnProgressSuccess?.Invoke("KML 加载完成");
            return dataSet;
        }

        private void OnElementAdded(object sender, ElementEventArgs e)
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
                    var list = new List<CustomData.WP.VPSPosition>();
                    foreach (var loc in ls.Coordinates)
                    {
                        var point = new CustomData.WP.VPSPosition(loc.Latitude, loc.Longitude, (int)loc.Altitude);
                        point.Command = CustomData.WP.WPCommands.DefaultWPCommand;
                        point.AltMode = altmode;
                        list.Add(point);
                    }
                    OnAddList?.Invoke(list);
                    OnProgress?.Invoke((double)(progress + 1) / (progress + 2));
                    progress++;
                }
            }
            catch { }
            finally
            {
            }
        }

        public void SaveKML(string file)
        {

        }


        public class KMLDataSet
        {
            public string coordinates;
            public List<List<CustomData.WP.VPSPosition>> points;

            public KMLDataSet()
            {
                this.coordinates = KnownCoordinateSystems.Geographic.World.WGS1984.ToEsriString();

                points = new List<List<CustomData.WP.VPSPosition>>();
            }

            public void AddPolygon(List<CustomData.WP.VPSPosition> poly)
            {
                points.Add(poly);
            }

            public void AddPoint(CustomData.WP.VPSPosition point)
            {
                if (points.Count > 0)
                    points[points.Count - 1].Add(point);
                else
                {
                    points.Add(new List<CustomData.WP.VPSPosition>());
                    points[points.Count - 1].Add(point);
                }

            }

            public void AddPoint(int indedx, CustomData.WP.VPSPosition point)
            {
                if (points.Count > 0)
                    points[points.Count - 1].Add(point);
                else
                {
                    points.Add(new List<CustomData.WP.VPSPosition>());
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
