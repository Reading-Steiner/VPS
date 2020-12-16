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

        //[DllImport("gdal232.dll", CallingConvention = CallingConvention.Cdecl)]
        //public static extern IntPtr OGR_F_GetFieldAsString(HandleRef handle, int fieldIdx);

        public SHPDataSet ReadSHP(string file)
        {
            ProjectionInfo pStart = new ProjectionInfo();
            ProjectionInfo pESRIEnd = KnownCoordinateSystems.Geographic.World.WGS1984;

            // 为了支持中文路径
            OSGeo.GDAL.Gdal.SetConfigOption("GDAL_FILENAME_IS_UTF8", "YES");
            // 为了使属性表字段支持中文
            OSGeo.GDAL.Gdal.SetConfigOption("SHAPE_ENCODING", "CP936");

            string strVectorFile = file;

            OnProgressStart?.Invoke("打开 Shapefile");

            Driver oDriver = Ogr.GetDriverByName("ESRI shapefile");

            if (oDriver == null)
            {
                OnWarnMessage?.Invoke(string.Format("{0} 驱动不可用！", oDriver.name));
                OnProgressFailure?.Invoke("Shapefile 打开失败");
                return null;
            }

            DataSource oDS = oDriver.Open(strVectorFile, 0);

            if (oDS == null)
            {
                OnInfoMessage?.Invoke(string.Format("Shapefile 【{0}】无法打开或为空！", strVectorFile));
                OnProgressFailure?.Invoke("Shapefile 打开失败");
                oDS.Dispose();
                return null;
            }

            int layerCount = oDS.GetLayerCount();
            Layer oLayer = oDS.GetLayerByIndex(0);

            //投影信息
            SpatialReference coord = oLayer.GetSpatialRef();
            string coordString;
            if (coord != null)
            {
                
                coord.ExportToWkt(out coordString);
                pStart.ParseEsriString(coordString);
            }
            else
            {
                coordString = KnownCoordinateSystems.Geographic.World.WGS1984.ToEsriString();
                pStart = KnownCoordinateSystems.Geographic.World.WGS1984;
            }

            wkbGeometryType oTempGeometryType = oLayer.GetGeomType();
            string typeString = oTempGeometryType.ToString();


            FeatureDefn oDefn = oLayer.GetLayerDefn();
            int iFieldCount = oDefn.GetFieldCount();

            SHPDataSet data = new SHPDataSet(typeString, coordString);
            //读取shp文件
            Feature oFeature;
            long FeatrueCount = oLayer.GetFeatureCount(0);
            long CurrentFeatureIndex = 0;
            while ((oFeature = oLayer.GetNextFeature()) != null)
            {
                Geometry geometry = oFeature.GetGeometryRef();
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
                            var point = new CustomData.WP.Position(arrayXY[1], arrayXY[0], arrayZ[0]);
                            point.Command = CustomData.WP.WPCommands.DefaultWPCommand;
                            point.AltMode = CustomData.EnumCollect.AltFrame.Terrain;
                            data.AddPoint(point);
                            OnProgress?.Invoke(
                                (double)(CurrentFeatureIndex + 1) / FeatrueCount);
                        }
                        //NewPoint?.Invoke(new point(pnt));
                        break;
                    case wkbGeometryType.wkbLineString:
                        {
                            var ls = new List<CustomData.WP.Position>();
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
                                var point = new CustomData.WP.Position(arrayXY[1], arrayXY[0], arrayZ[0]);
                                point.Command = CustomData.WP.WPCommands.DefaultWPCommand;
                                point.AltMode = CustomData.EnumCollect.AltFrame.Terrain;
                                ls.Add(point);
                                OnProgress?.Invoke(
                                    (double)(CurrentFeatureIndex) / FeatrueCount + 
                                    (double)(p + 1) / pointcount / FeatrueCount);
                            }
                            data.AddPolygon(ls);
                            //NewLineString?.Invoke(ls);
                            break;
                        }
                    case wkbGeometryType.wkbPolygon:
                        {
                            for (int i = 0; i < geometry.GetGeometryCount(); i++)
                            {
                                var poly = new List<CustomData.WP.Position>();

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
                                    var point = new CustomData.WP.Position(arrayXY[1], arrayXY[0], arrayZ[0]);
                                    point.Command = CustomData.WP.WPCommands.DefaultWPCommand;
                                    point.AltMode = CustomData.EnumCollect.AltFrame.Terrain;
                                    poly.Add(point);
                                    OnProgress?.Invoke(
                                        (double)(CurrentFeatureIndex) / FeatrueCount + 
                                        (double)(p + 1) / pointcount / FeatrueCount);
                                }
                                data.AddPolygon(poly);
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

                            int lineCount = geometry.GetGeometryCount();
                            for (int i = 0; i < lineCount; i++)
                            {
                                var list = new List<CustomData.WP.Position>();

                                var geom2 = geometry.GetGeometryRef(i);
                                var pointcount = geom2.GetPointCount();
                                for (int p = 0; p < pointcount; p++)
                                {
                                    double[] pnt2 = new double[3];
                                    geom2.GetPoint(p, pnt2);
                                    double[] arrayXY = new double[] { pnt2[0], pnt2[1] };
                                    double[] arrayZ = new double[] { pnt2[2] };
                                    Reproject.ReprojectPoints(
                                        arrayXY, arrayZ,
                                        pStart, pESRIEnd, 0, 1);
                                    var point = new CustomData.WP.Position(arrayXY[1], arrayXY[0], arrayZ[0]);
                                    point.Command = CustomData.WP.WPCommands.DefaultWPCommand;
                                    point.AltMode = CustomData.EnumCollect.AltFrame.Terrain;
                                    list.Add(point);
                                    OnProgress?.Invoke(
                                        (double)(CurrentFeatureIndex) / FeatrueCount +
                                        (double)i / lineCount / FeatrueCount +
                                        (double)(p + 1) / pointcount / lineCount / FeatrueCount);
                                }
                                data.AddPolygon(list);
                            }

                            break;
                        }
                    case wkbGeometryType.wkbNone:
                        OnProgress?.Invoke(
                            (double)(CurrentFeatureIndex + 1) / FeatrueCount);
                        break;
                }
                CurrentFeatureIndex++;
            }

            OnInfoMessage?.Invoke(string.Format("【{0}】加载成功！", strVectorFile));
            OnProgressSuccess?.Invoke("Shapefile 加载完成");
            return data;
        }

        public void SaveSHP(string file, List<CustomData.WP.Position> list)
        {
            // 为了支持中文路径，请添加下面这句代码
            OSGeo.GDAL.Gdal.SetConfigOption("GDAL_FILENAME_IS_UTF8", "YES");
            // 为了使属性表字段支持中文，请添加下面这句
            OSGeo.GDAL.Gdal.SetConfigOption("SHAPE_ENCODING", "CP936");

            string strVectorFile = file;

            OnProgressStart?.Invoke("创建 Shapefile");

            //创建数据，这里以创建ESRI的shp文件为例
            string strDriverName = "ESRI Shapefile";
            int count = Ogr.GetDriverCount();
            Driver oDriver = Ogr.GetDriverByName(strDriverName);
            if (oDriver == null)
            {
                OnWarnMessage?.Invoke(string.Format("{0} 驱动不可用！", oDriver.name));
                OnProgressFailure?.Invoke("Shapefile 创建失败");
                return;
            }

            // 创建数据源
            DataSource oDS = oDriver.CreateDataSource(strVectorFile, null);
            if (oDS == null)
            {
                OnInfoMessage?.Invoke(string.Format("【{0}】创建失败！", strVectorFile));
                OnProgressFailure?.Invoke("Shapefile 创建失败");
                return;
            }
            // 创建图层，创建一个多边形图层，这里没有指定空间参考，如果需要的话，需要在这里进行指定
            Layer oLayer = oDS.CreateLayer("ShapefileLayer", 
                new SpatialReference(KnownCoordinateSystems.Geographic.World.WGS1984.ToEsriString()), 
                wkbGeometryType.wkbPolygon25D, null);
            if (oLayer == null)
            {
                OnInfoMessage?.Invoke(string.Format("【{0}】创建失败！", strVectorFile));
                OnProgressFailure?.Invoke("Shapefile 图层创建失败");
                return;
            }

            //创建属性列两列
            //OSGeo.OGR.FieldDefn oField = new OSGeo.OGR.FieldDefn("名称", OSGeo.OGR.FieldType.OFTString);
            //oField.SetWidth(16);
            //OSGeo.OGR.FieldDefn oField2 = new OSGeo.OGR.FieldDefn("高度", OSGeo.OGR.FieldType.OFTInteger);
            //oLayer.CreateField(oField, 1);
            //oLayer.CreateField(oField2, 0);

            FeatureDefn oDefn = oLayer.GetLayerDefn();

            // 创建岛要素
            Feature oFeature = new Feature(oDefn);
            //oFeature.SetField(0, "名称");
            //oFeature.SetField(1, "高度");
            //Geometry geomWYX = Geometry.CreateFromWkt("POLYGON ((30 0,60 0,60 30,30 30,30 0))");
            OSGeo.OGR.Geometry oLineGeo = new OSGeo.OGR.Geometry(OSGeo.OGR.wkbGeometryType.wkbLinearRing);
            for (int index = 0; index < list.Count; index++)
            {
                oLineGeo.AddPoint(list[index].Lng, list[index].Lat, list[index].Alt);
                OnProgress?.Invoke((double)(index + 1) / list.Count);
            }


            OSGeo.OGR.Geometry oPolygonGeo = new OSGeo.OGR.Geometry(OSGeo.OGR.wkbGeometryType.wkbPolygon);
            oPolygonGeo.AddGeometryDirectly(oLineGeo);
            oFeature.SetGeometry(oPolygonGeo);
            oLayer.CreateFeature(oFeature);

            oFeature.Dispose();
            oDS.Dispose();

            OnInfoMessage?.Invoke(string.Format("【{0}】创建成功！", strVectorFile));
            OnProgressSuccess?.Invoke("Shapefile 创建完成");
        }

        public class SHPDataSet
        {
            public string coordinates;
            public string featureType;
            public List<List<CustomData.WP.Position>> points;

            public SHPDataSet(string featureType, string coordinates)
            {
                this.coordinates = coordinates;
                this.featureType = featureType;

                points = new List<List<CustomData.WP.Position>>();
            }

            public void AddPolygon(List<CustomData.WP.Position> poly)
            {
                points.Add(poly);
            }

            public void AddPoint(CustomData.WP.Position point)
            {
                if (points.Count > 0)
                    points[points.Count - 1].Add(point);
                else
                {
                    points.Add(new List<CustomData.WP.Position>());
                    points[points.Count - 1].Add(point);
                }

            }

            public void AddPoint(int indedx, CustomData.WP.Position point)
            {
                if (points.Count > 0)
                    points[points.Count - 1].Add(point);
                else
                {
                    points.Add(new List<CustomData.WP.Position>());
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

