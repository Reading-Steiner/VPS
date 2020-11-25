using DotSpatial.Projections;
using OSGeo.OGR;
using OSGeo.OSR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using VPS.Utilities;

namespace VPS.CustomFile
{
    class SHP
    {

        static SHP()
        {
            GdalConfiguration.ConfigureGdal();
        }

        public delegate void Progress(double percent, string message);
        public delegate void Meaasge(string message);

        public static event Progress OnProgress;
        public static event Meaasge OnChangeTarget;
        public static event Meaasge OnSuccess;
        public static event Meaasge OnFailure;
        public static event Meaasge OnInfoMessage;
        public static event Meaasge OnWarnMessage;

        //[DllImport("gdal232.dll", CallingConvention = CallingConvention.Cdecl)]
        //public static extern IntPtr OGR_F_GetFieldAsString(HandleRef handle, int fieldIdx);

        public static SHPDataSet ReadSHP(string file)
        {
            ProjectionInfo pStart = new ProjectionInfo();
            ProjectionInfo pESRIEnd = KnownCoordinateSystems.Geographic.World.WGS1984;

            // 为了支持中文路径
            OSGeo.GDAL.Gdal.SetConfigOption("GDAL_FILENAME_IS_UTF8", "YES");
            // 为了使属性表字段支持中文
            OSGeo.GDAL.Gdal.SetConfigOption("SHAPE_ENCODING", "CP936");

            Driver dr = Ogr.GetDriverByName("ESRI shapefile");

            if (dr == null)
            {
                OnWarnMessage?.Invoke("ESRI shapefile 设备文件出现问题");
                return null;
            }

            DataSource ds = dr.Open(file, 0);

            if (ds == null)
            {
                OnWarnMessage?.Invoke("shapefile 文件无法打开或为空");
                ds.Dispose();
                return null;
            }

            int layerCount = ds.GetLayerCount();
            Layer oLayer = ds.GetLayerByIndex(0);

            //投影信息
            SpatialReference coord = oLayer.GetSpatialRef();
            string coordString;
            coord.ExportToWkt(out coordString);
            pStart.ParseEsriString(coordString);

            wkbGeometryType oTempGeometryType = oLayer.GetGeomType();
            string typeString = oTempGeometryType.ToString();


            FeatureDefn oDefn = oLayer.GetLayerDefn();
            int iFieldCount = oDefn.GetFieldCount();

            SHPDataSet data = new SHPDataSet(typeString, coordString);
            //读取shp文件
            Feature feat;

            while ((feat = oLayer.GetNextFeature()) != null)
            {
                Geometry geometry = feat.GetGeometryRef();
                wkbGeometryType goetype = geometry.GetGeometryType();

                switch ((wkbGeometryType)((int)goetype & 0xffff))
                {
                    case wkbGeometryType.wkbUnknown:
                        break;
                    case wkbGeometryType.wkbPoint:
                        {
                            var pnt = new double[3];
                            geometry.GetPoint(0, pnt);
                            double[] arrayXY = new double[] { pnt[0], pnt[1] };
                            double[] arrayZ = new double[] { pnt[2] };
                            Reproject.ReprojectPoints(
                                arrayXY, arrayZ,
                                pStart, pESRIEnd, 0, 1);
                            data.AddPoint(new PointLatLngAlt(arrayXY[1], arrayXY[0], arrayZ[0]));
                        }
                        //NewPoint?.Invoke(new point(pnt));
                        break;
                    case wkbGeometryType.wkbLineString:
                        {
                            List<PointLatLngAlt> ls = new List<PointLatLngAlt>();
                            var pointcount = geometry.GetPointCount();
                            for (int p = 0; p < pointcount; p++)
                            {
                                double[] pnt = new double[3];
                                geometry.GetPoint(p, pnt);
                                double[] arrayXY = new double[] { pnt[0], pnt[1] };
                                double[] arrayZ = new double[] { pnt[2] };
                                Reproject.ReprojectPoints(
                                    arrayXY, arrayZ,
                                    pStart, pESRIEnd, 0, 1);
                                ls.Add(new PointLatLngAlt(arrayXY[1], arrayXY[0], arrayZ[0]));
                            }
                            data.AddPolygon(ls);
                            //NewLineString?.Invoke(ls);
                            break;
                        }
                    case wkbGeometryType.wkbPolygon:
                        {
                            for (int i = 0; i < geometry.GetGeometryCount(); i++)
                            {
                                List<PointLatLngAlt> poly = new List<PointLatLngAlt>();

                                var geom = geometry.GetGeometryRef(i);
                                var pointcount = geom.GetPointCount();
                                for (int p = 0; p < pointcount; p++)
                                {
                                    double[] pnt = new double[3];
                                    geom.GetPoint(p, pnt);
                                    double[] arrayXY = new double[] { pnt[0], pnt[1] };
                                    double[] arrayZ = new double[] { pnt[2] };
                                    Reproject.ReprojectPoints(
                                        arrayXY, arrayZ,
                                        pStart, pESRIEnd, 0, 1);
                                    poly.Add(new PointLatLngAlt(arrayXY[1], arrayXY[0], arrayZ[0]));
                                }

                                //NewPolygon?.Invoke(poly);
                            }

                            break;
                        }
                    case wkbGeometryType.wkbMultiPoint:
                    case wkbGeometryType.wkbMultiLineString:
                    case wkbGeometryType.wkbMultiPolygon:
                    case wkbGeometryType.wkbGeometryCollection:
                    case wkbGeometryType.wkbLinearRing:
                        {
                            
                            for (int i = 0; i < geometry.GetGeometryCount(); i++)
                            {
                                List<PointLatLngAlt> poly = new List<PointLatLngAlt>();

                                var geom2 = geometry.GetGeometryRef(i);
                                var pointcount1 = geom2.GetPointCount();
                                for (int p = 0; p < pointcount1; p++)
                                {
                                    double[] pnt2 = new double[3];
                                    geom2.GetPoint(p, pnt2);
                                    double[] arrayXY = new double[] { pnt2[0], pnt2[1] };
                                    double[] arrayZ = new double[] { pnt2[2] };
                                    Reproject.ReprojectPoints(
                                        arrayXY, arrayZ,
                                        pStart, pESRIEnd, 0, 1);
                                    poly.Add(new PointLatLngAlt(arrayXY[1], arrayXY[0], arrayZ[0]));
                                }
                            }

                            break;
                        }
                    case wkbGeometryType.wkbNone:

                        break;
                }
            }
            return data;
        }


        public class SHPDataSet
        {
            public string coordinates;
            public string featureType;
            public List<List<PointLatLngAlt>> points;

            public SHPDataSet(string featureType, string coordinates)
            {
                this.coordinates = coordinates;
                this.featureType = featureType;

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

            public void AddPoint(int indedx,PointLatLngAlt point)
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

    }//END class
}

