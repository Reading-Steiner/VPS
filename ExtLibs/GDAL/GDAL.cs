﻿using GMap.NET;
using log4net;
using OSGeo.GDAL;
using OSGeo.OGR;
using OSGeo.OSR;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace GDAL
{
    public static class GDAL
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static List<GeoBitmap> _cache = new List<GeoBitmap>();

        static GDAL()
        {
            log.InfoFormat("GDAL static ctor");
            GdalConfiguration.ConfigureGdal();
        }

        public delegate void ProgressMessageOutTime(string message, int time);
        public delegate void ProgressMessage(string message);
        public delegate void Progress(double percent);
        public delegate void Meaasge(string message);

        public static event ProgressMessage OnProgressStart;
        public static event ProgressMessage OnProgressInfo;
        public static event ProgressMessageOutTime OnProgressEnd;
        public static event ProgressMessage OnProgressSuccess;
        public static event ProgressMessage OnProgressFailure;
        public static event Progress OnProgress;
        public static event Meaasge OnInfoMessage;
        public static event Meaasge OnWarnMessage;

        public static void ScanDirectory(string path)
        {
            if (!Directory.Exists(path))
                return;

            var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);

            int i = 0;
            foreach (var file in files)
            {
                i++;
                try
                {
                    // 1kb file check
                    if (new FileInfo(file).Length < 1024 * 1)
                        continue;

                    OnProgressInfo?.Invoke(file);
                    OnProgress?.Invoke((i - 1) / (double)files.Length);

                    var info = GDAL.LoadImageInfo(file);

                    _cache.Add(info);
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                }
            }

            // lowest res first
            _cache.Sort((a, b) => { return b.Resolution.CompareTo(a.Resolution); });
        }

        public static GeoBitmap LoadImageInfo(string file)
        {
            using (var ds = OSGeo.GDAL.Gdal.Open(file, OSGeo.GDAL.Access.GA_ReadOnly))
            {
                log.InfoFormat("Raster dataset parameters:");
                log.InfoFormat("  Projection: " + ds.GetProjectionRef());
                log.InfoFormat("  RasterCount: " + ds.RasterCount);
                log.InfoFormat("  RasterSize (" + ds.RasterXSize + "," + ds.RasterYSize + ")");

                OSGeo.GDAL.Driver drv = ds.GetDriver();

                log.InfoFormat("Using driver " + drv.LongName);

                string[] metadata = ds.GetMetadata("");
                if (metadata.Length > 0)
                {
                    log.InfoFormat("  Metadata:");
                    for (int iMeta = 0; iMeta < metadata.Length; iMeta++)
                    {
                         log.InfoFormat("    " + iMeta + ":  " + metadata[iMeta]);
                    }
                    log.InfoFormat("");
                }

                metadata = ds.GetMetadata("IMAGE_STRUCTURE");
                if (metadata.Length > 0)
                {
                    log.InfoFormat("  Image Structure Metadata:");
                    for (int iMeta = 0; iMeta < metadata.Length; iMeta++)
                    {
                        log.InfoFormat("    " + iMeta + ":  " + metadata[iMeta]);
                    }
                    log.InfoFormat("");
                }

                metadata = ds.GetMetadata("SUBDATASETS");
                if (metadata.Length > 0)
                {
                    log.InfoFormat("  Subdatasets:");
                    for (int iMeta = 0; iMeta < metadata.Length; iMeta++)
                    {
                        log.InfoFormat("    " + iMeta + ":  " + metadata[iMeta]);
                    }
                    log.InfoFormat("");
                }

                metadata = ds.GetMetadata("GEOLOCATION");
                if (metadata.Length > 0)
                {
                    log.InfoFormat("  Geolocation:");
                    for (int iMeta = 0; iMeta < metadata.Length; iMeta++)
                    {
                        log.InfoFormat("    " + iMeta + ":  " + metadata[iMeta]);
                    }
                    log.InfoFormat("");
                }

                log.InfoFormat("Corner Coordinates:");
                log.InfoFormat("  Upper Left (" + GDALInfoGetPosition(ds, 0.0, 0.0) + ")");
                log.InfoFormat("  Lower Left (" + GDALInfoGetPosition(ds, 0.0, ds.RasterYSize) + ")");
                log.InfoFormat("  Upper Right (" + GDALInfoGetPosition(ds, ds.RasterXSize, 0.0) + ")");
                log.InfoFormat("  Lower Right (" + GDALInfoGetPosition(ds, ds.RasterXSize, ds.RasterYSize) + ")");
                log.InfoFormat("  Center (" + GDALInfoGetPosition(ds, ds.RasterXSize / 2, ds.RasterYSize / 2) + ")");
                log.InfoFormat("");

                string projection = ds.GetProjectionRef();
                if (projection != null)
                {
                    SpatialReference srs = new SpatialReference(null);
                    if (srs.ImportFromWkt(ref projection) == 0)
                    {
                        string wkt;
                        srs.ExportToPrettyWkt(out wkt, 0);
                        log.InfoFormat("Coordinate System is:");
                        log.InfoFormat(wkt);
                    }
                    else
                    {
                        log.InfoFormat("Coordinate System is:");
                        log.InfoFormat(projection);
                    }
                }

                if (ds.GetGCPCount() > 0)
                {
                    log.InfoFormat("GCP Projection: ", ds.GetGCPProjection());
                    GCP[] GCPs = ds.GetGCPs();
                    for (int i = 0; i < ds.GetGCPCount(); i++)
                    {
                        log.InfoFormat("GCP[" + i + "]: Id=" + GCPs[i].Id + ", Info=" + GCPs[i].Info);
                        log.InfoFormat("          (" + GCPs[i].GCPPixel + "," + GCPs[i].GCPLine + ") -> ("
                                     + GCPs[i].GCPX + "," + GCPs[i].GCPY + "," + GCPs[i].GCPZ + ")");
                        log.InfoFormat("");
                    }
                    log.InfoFormat("");

                    double[] transform = new double[6];
                    Gdal.GCPsToGeoTransform(GCPs, transform, 0);
                    log.InfoFormat("GCP Equivalent geotransformation parameters: ", ds.GetGCPProjection());
                    for (int i = 0; i < 6; i++)
                        log.InfoFormat("t[" + i + "] = " + transform[i].ToString());
                    log.InfoFormat("");
                }

                var TL = GDALInfoGetPositionDouble(ds, 0.0, 0.0);
                var BR = GDALInfoGetPositionDouble(ds, ds.RasterXSize, ds.RasterYSize);
                var resolution = Math.Abs(BR[0] - TL[0]) / ds.RasterXSize;

                if (resolution == 1)
                    throw new Exception("Invalid coords");

                double[] adfGeoTransform = new double[6];
                ds.GetGeoTransform(adfGeoTransform);
                return new GeoBitmap(file, resolution, ds.RasterXSize, ds.RasterYSize, TL[0], TL[1], BR[0], BR[1], adfGeoTransform);
            }
        }

        static object locker = new object();

        public static Bitmap GetBitmap(double lng1, double lat1, double lng2, double lat2, long width, long height)
        {
            if (_cache.Count == 0)
                return null;

            Bitmap output = new Bitmap((int)width, (int)height, PixelFormat.Format32bppArgb);

            int a = 0;

            using (Graphics g = Graphics.FromImage(output))
            {
                g.Clear(Color.Transparent);

                RectLatLng request = new RectLatLng(lat1, lng1, lng2 - lng1, lat2 - lat1);

                //g.DrawString(request.ToString(), Control.DefaultFont, Brushes.Wheat, 0, 0);

                bool cleared = false;

                foreach (var image in _cache)
                {
                    // calc the pixel coord within the image rect
                    var ImageTop = (float)map(request.Top, image.Rect.Top, image.Rect.Bottom, 0, image.RasterYSize);
                    var ImageLeft = (float)map(request.Left, image.Rect.Left, image.Rect.Right, 0, image.RasterXSize);

                    var ImageBottom = (float)map(request.Bottom, image.Rect.Top, image.Rect.Bottom, 0, image.RasterYSize);
                    var ImageRight = (float)map(request.Right, image.Rect.Left, image.Rect.Right, 0, image.RasterXSize);

                    RectangleF rect = new RectangleF(ImageLeft, ImageTop, ImageRight - ImageLeft, ImageBottom - ImageTop);

                    var res = (request.Right - request.Left) / width;


                    if (rect.Left <= image.RasterXSize && rect.Top <= image.RasterYSize && rect.Right >= 0 && rect.Bottom >= 0)
                    {
                        if (!cleared)
                        {
                            //g.Clear(Color.Red);
                            cleared = true;
                        }

                        //if (image.Resolution < (res / 3))
                            //continue;

                        //Console.WriteLine("{0} <= {1} && {2} <= {3} || {4} >= {5} && {6} >= {7} ", rect.Left, image.RasterXSize, rect.Top, image.RasterYSize, rect.Right, 0, rect.Bottom, 0);

                        try
                        {
                            lock (locker)
                            {
                                if (image.DisplayBitmap == null)
                                    continue;

                                // this is wrong
                                g.DrawImage(image.DisplayBitmap, new RectangleF(0, 0, width, height), rect, GraphicsUnit.Pixel);

                            }
                            a++;

                            if (a >= 50)
                                return output;
                        }
                        catch (Exception ex)
                        {
                            log.Error(ex);
                            //throw new Exception("Bad Image "+image.File);
                        }
                    }
                }

                if (a == 0)
                {
                    return null;
                }

                return output;
            }
        }

        private static double map(double x, double in_min, double in_max, double out_min, double out_max)
        {
            return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
        }


        public static Bitmap LoadTile(string file, int xOffset, int yOffset, int xSize = 400, int ySize = 400)
        {
            lock (locker)
            {
                using (var ds = OSGeo.GDAL.Gdal.Open(file, OSGeo.GDAL.Access.GA_ReadOnly))
                {
                    //var opt = OSGeo.GDAL.GDALBuildVRTOptions.;
                    if (ds.RasterXSize <= xOffset ||
                        ds.RasterYSize <= yOffset ||
                        xOffset < 0 || yOffset < 0 || xSize <= 0 || ySize <= 0)
                        return null;
                    int rasterXSize = ds.RasterXSize >= xOffset + xSize ?
                        xSize : ds.RasterXSize - xOffset;
                    int rasterYSize = ds.RasterYSize >= yOffset + ySize ?
                        ySize : ds.RasterYSize - yOffset;

                    if (ds.RasterCount == 1)
                    {
                        Band band = ds.GetRasterBand(1);
                        if (band == null)
                            return null;

                        ColorTable ct = band.GetRasterColorTable();

                        PixelFormat format = PixelFormat.Format8bppIndexed;

                        // Create a Bitmap to store the GDAL image in
                        Bitmap bitmap = new Bitmap(rasterXSize, rasterYSize, format);

                        // Obtaining the bitmap buffer
                        BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, rasterXSize, rasterYSize),
                            ImageLockMode.ReadWrite, format);
                        try
                        {
                            if (ct != null)
                            {
                                int iCol = ct.GetCount();
                                ColorPalette pal = bitmap.Palette;
                                for (int i = 0; i < rasterYSize; i++)
                                {
                                    for (int j = 0; j < rasterXSize; j++)
                                    {
                                        ColorEntry ce = ct.GetColorEntry((yOffset + i) * ds.RasterXSize + xOffset + j);
                                        pal.Entries[i] = Color.FromArgb(ce.c4, ce.c1, ce.c2, ce.c3);
                                    }
                                }

                                bitmap.Palette = pal;
                            }
                            else
                            {

                            }

                            //int stride = ds.RasterXSize;
                            IntPtr buf = bitmapData.Scan0;

                            band.ReadRaster(xOffset, yOffset, rasterXSize, rasterYSize, buf, rasterXSize, rasterYSize,
                                DataType.GDT_Byte, 0, 0);

                        }
                        finally
                        {
                            bitmap.UnlockBits(bitmapData);
                        }


                        return bitmap;
                    }

                    {
                        Bitmap bitmap = new Bitmap(rasterXSize, rasterYSize, PixelFormat.Format32bppArgb);

                        for (int a = 1; a <= ds.RasterCount; a++)
                        {
                            // Get the GDAL Band objects from the Dataset
                            Band band = ds.GetRasterBand(a);
                            if (band == null)
                                return null;

                            var cint = band.GetColorInterpretation();


                            // Obtaining the bitmap buffer
                            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, rasterXSize, rasterYSize),
                                ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
                            try
                            {

                                //int stride = bitmapData.Stride;
                                IntPtr buf = bitmapData.Scan0;
                                var buffer = new byte[rasterXSize * rasterYSize];

                                band.ReadRaster(xOffset, yOffset, rasterXSize, rasterYSize, buffer, rasterXSize, rasterYSize, 0, 0);

                                int c = 0;
                                if (cint == ColorInterp.GCI_AlphaBand)
                                    foreach (var b in buffer)
                                    {
                                        Marshal.WriteByte(buf, 3 + c * 4, (byte)b);
                                        c++;
                                    }
                                else if (cint == ColorInterp.GCI_RedBand)
                                    foreach (var b in buffer)
                                    {
                                        Marshal.WriteByte(buf, 2 + c * 4, (byte)b);
                                        c++;
                                    }
                                else if (cint == ColorInterp.GCI_GreenBand)
                                    foreach (var b in buffer)
                                    {
                                        Marshal.WriteByte(buf, 1 + c * 4, (byte)b);
                                        c++;
                                    }
                                else if (cint == ColorInterp.GCI_BlueBand)
                                    foreach (var b in buffer)
                                    {
                                        Marshal.WriteByte(buf, 0 + c * 4, (byte)b);
                                        c++;
                                    }
                                else
                                {

                                }
                            }
                            finally
                            {
                                bitmap.UnlockBits(bitmapData);
                            }
                        }

                        //bitmap.Save("gdal.bmp", ImageFormat.Bmp);
                        return bitmap;
                    }
                }
            }
        }

        public static void CreateVRT(string vrt, List<string> tiffs)
        {
            var vrtDataset = Gdal.wrapper_GDALBuildVRT_names(vrt, tiffs.ToArray(), new GDALBuildVRTOptions(new[] { "-overwrite" }), null, null);
            vrtDataset.Dispose();
        }

        public static bool SaveTiffTile(string file, string saveFile, int xOffset, int yOffset, int xSize = 400, int ySize = 400)
        {

            lock (locker)
            {
                //Gdal.AllRegister();
                using (var ds = OSGeo.GDAL.Gdal.Open(file, OSGeo.GDAL.Access.GA_ReadOnly))
                {
                    //var opt = OSGeo.GDAL.GDALBuildVRTOptions.;
                    if (ds.RasterXSize <= xOffset ||
                        ds.RasterYSize <= yOffset ||
                        xOffset < 0 || yOffset < 0 || xSize <= 0 || ySize <= 0)
                        return false;
                    int rasterXSize = ds.RasterXSize >= xOffset + xSize ?
                        xSize : ds.RasterXSize - xOffset;
                    int rasterYSize = ds.RasterYSize >= yOffset + ySize ?
                        ySize : ds.RasterYSize - yOffset;

                    var driver = OSGeo.GDAL.Gdal.GetDriverByName("GTiff");
                    Dataset tiff = driver.Create(saveFile, rasterXSize, rasterYSize, ds.RasterCount, DataType.GDT_Byte, null);
                    foreach (var domain in ds.GetMetadataDomainList())
                    {
                        tiff.SetMetadata(ds.GetMetadata(domain), domain);
                    }

                    tiff.SetProjection(ds.GetProjection());

                    double[] adfGeoTransform = { 0, 0, 0, 0, 0, 0 };
                    ds.GetGeoTransform(adfGeoTransform);
                    double left = adfGeoTransform[0] + xOffset * adfGeoTransform[1] + yOffset * adfGeoTransform[2];
                    double top = adfGeoTransform[3] + xOffset * adfGeoTransform[4] + yOffset * adfGeoTransform[5];
                    adfGeoTransform[0] = left;
                    adfGeoTransform[3] = top;
                    tiff.SetGeoTransform(adfGeoTransform);

                    if (ds.RasterCount == 1)
                    {
                        Band band = ds.GetRasterBand(1);
                        Band tiffBand = tiff.GetRasterBand(1);
                        if (band == null)
                            return false;

                        try
                        {
                            //int stride = ds.RasterXSize;
                            var buffer = new byte[rasterXSize * rasterYSize];

                            band.ReadRaster(xOffset, yOffset, rasterXSize, rasterYSize,
                                buffer, rasterXSize, rasterYSize, 0, 0);
                            tiffBand.WriteRaster(0, 0, rasterXSize, rasterYSize,
                                buffer, rasterXSize, rasterYSize, 0, 0);

                            tiffBand.FlushCache();
                        }
                        finally
                        {
                            tiff.FlushCache();
                        }

                        return true;
                    }

                    {
                        Bitmap bitmap = new Bitmap(rasterXSize, rasterYSize, PixelFormat.Format32bppArgb);

                        for (int a = 1; a <= ds.RasterCount; a++)
                        {
                            // Get the GDAL Band objects from the Dataset
                            Band band = ds.GetRasterBand(a);
                            Band tiffBand = tiff.GetRasterBand(a);
                            if (band == null)
                                return false;

                            try
                            {
                                //int stride = bitmapData.Stride;
                                var buffer = new byte[rasterXSize * rasterYSize];
                                band.ReadRaster(xOffset, yOffset, rasterXSize, rasterYSize, buffer, rasterXSize, rasterYSize, 0, 0);
                                tiffBand.WriteRaster(0, 0, rasterXSize, rasterYSize, buffer, rasterXSize, rasterYSize, 0, 0);
                                tiffBand.FlushCache();
                            }
                            finally
                            {
                                tiff.FlushCache();
                            }
                        }
                        
                        //bitmap.Save("gdal.bmp", ImageFormat.Bmp);
                        return true;
                    }
                }
            }
        }


        public static Bitmap LoadTileImage(string file, int xOffset, int yOffset, int xSize = 400, int ySize = 400)
        {
            lock (locker)
            {
                using (var ds = OSGeo.GDAL.Gdal.Open(file, OSGeo.GDAL.Access.GA_ReadOnly))
                {
                    if (ds.RasterXSize <= xOffset ||
                        ds.RasterYSize <= yOffset ||
                        xOffset < 0 || yOffset < 0 || xSize <= 0 || ySize <= 0) 
                        return null;
                    int rasterXSize = ds.RasterXSize >= xOffset + xSize ?
                        xSize : ds.RasterXSize - xOffset;
                    int rasterYSize = ds.RasterYSize >= yOffset + ySize ?
                        ySize : ds.RasterYSize - yOffset;

                    if (ds.RasterCount == 1)
                    {
                        Band band = ds.GetRasterBand(1);
                        if (band == null)
                            return null;

                        ColorTable ct = band.GetRasterColorTable();

                        PixelFormat format = PixelFormat.Format8bppIndexed;

                        // Create a Bitmap to store the GDAL image in
                        Bitmap bitmap = new Bitmap(rasterXSize, rasterYSize, format);

                        // Obtaining the bitmap buffer
                        BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, rasterXSize, rasterYSize),
                            ImageLockMode.ReadWrite, format);
                        try
                        {
                            if (ct != null)
                            {
                                int iCol = ct.GetCount();
                                ColorPalette pal = bitmap.Palette;
                                for (int i = 0; i < rasterYSize; i++)
                                {
                                    for (int j = 0; j < rasterXSize; j++)
                                    {
                                        ColorEntry ce = ct.GetColorEntry((yOffset + i) * ds.RasterXSize + xOffset + j);
                                        pal.Entries[i] = Color.FromArgb(ce.c4, ce.c1, ce.c2, ce.c3);
                                    }
                                }

                                bitmap.Palette = pal;
                            }
                            else
                            {

                            }

                            //int stride = ds.RasterXSize;
                            IntPtr buf = bitmapData.Scan0;

                            band.ReadRaster(xOffset, yOffset, rasterXSize, rasterYSize, buf, rasterXSize, rasterYSize,
                                DataType.GDT_Byte, 0, 0);
                        }
                        finally
                        {
                            bitmap.UnlockBits(bitmapData);
                        }


                        return bitmap;
                    }

                    {
                        Bitmap bitmap = new Bitmap(rasterXSize, rasterYSize, PixelFormat.Format32bppArgb);

                        for (int a = 1; a <= ds.RasterCount; a++)
                        {
                            // Get the GDAL Band objects from the Dataset
                            Band band = ds.GetRasterBand(a);
                            if (band == null)
                                return null;

                            var cint = band.GetColorInterpretation();


                            // Obtaining the bitmap buffer
                            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, rasterXSize, rasterYSize),
                                ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
                            try
                            {

                                //int stride = bitmapData.Stride;
                                IntPtr buf = bitmapData.Scan0;
                                var buffer = new byte[rasterXSize * rasterYSize];

                                band.ReadRaster(xOffset, yOffset, rasterXSize, rasterYSize, buffer, rasterXSize, rasterYSize, 0, 0);

                                int c = 0;
                                if (cint == ColorInterp.GCI_AlphaBand)
                                    foreach (var b in buffer)
                                    {
                                        Marshal.WriteByte(buf, 3 + c * 4, (byte)b);
                                        c++;
                                    }
                                else if (cint == ColorInterp.GCI_RedBand)
                                    foreach (var b in buffer)
                                    {
                                        Marshal.WriteByte(buf, 2 + c * 4, (byte)b);
                                        c++;
                                    }
                                else if (cint == ColorInterp.GCI_GreenBand)
                                    foreach (var b in buffer)
                                    {
                                        Marshal.WriteByte(buf, 1 + c * 4, (byte)b);
                                        c++;
                                    }
                                else if (cint == ColorInterp.GCI_BlueBand)
                                    foreach (var b in buffer)
                                    {
                                        Marshal.WriteByte(buf, 0 + c * 4, (byte)b);
                                        c++;
                                    }
                                else
                                {

                                }
                            }
                            finally
                            {
                                bitmap.UnlockBits(bitmapData);
                            }
                        }

                        //bitmap.Save("gdal.bmp", ImageFormat.Bmp);
                        return bitmap;
                    }
                }
            }
        }

        public static Bitmap LoadImage(string file, int xSize = 16384, int ySize = 16384)
        {
            lock (locker)
            {
                using (var ds = OSGeo.GDAL.Gdal.Open(file, OSGeo.GDAL.Access.GA_ReadOnly))
                {
                    int rasterXSize = ds.RasterXSize;
                    int rasterYSize = ds.RasterYSize;
                    while (rasterXSize > xSize || rasterYSize > ySize)
                    {
                        rasterXSize = rasterXSize >> 1;
                        rasterYSize = rasterYSize >> 1;
                    }
                    // 8bit geotiff - single band
                    if (ds.RasterCount == 1)
                    {
                        Band band = ds.GetRasterBand(1);
                        if (band == null)
                            return null;

                        ColorTable ct = band.GetRasterColorTable();

                        PixelFormat format = PixelFormat.Format8bppIndexed;

                        // Create a Bitmap to store the GDAL image in
                        Bitmap bitmap = new Bitmap(rasterXSize, rasterYSize, format);

                        // Obtaining the bitmap buffer
                        BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, rasterXSize, rasterYSize),
                            ImageLockMode.ReadWrite, format);
                        try
                        {
                            if (ct != null)
                            {
                                int iCol = ct.GetCount();
                                ColorPalette pal = bitmap.Palette;
                                for (int i = 0; i < iCol; i++)
                                {
                                    ColorEntry ce = ct.GetColorEntry(i);
                                    pal.Entries[i] = Color.FromArgb(ce.c4, ce.c1, ce.c2, ce.c3);
                                }

                                bitmap.Palette = pal;
                            }
                            else
                            {

                            }

                            int stride = bitmapData.Stride;
                            IntPtr buf = bitmapData.Scan0;

                            band.ReadRaster(0, 0, ds.RasterXSize, ds.RasterYSize, buf, rasterXSize, rasterYSize,
                                DataType.GDT_Byte, 1, stride);
                        }
                        finally
                        {
                            bitmap.UnlockBits(bitmapData);
                        }


                        return bitmap;
                    }

                    {
                        Bitmap bitmap = new Bitmap(rasterXSize, rasterYSize, PixelFormat.Format32bppArgb);

                        for (int a = 1; a <= ds.RasterCount; a++)
                        {
                            // Get the GDAL Band objects from the Dataset
                            Band band = ds.GetRasterBand(a);
                            if (band == null)
                                return null;

                            var cint = band.GetColorInterpretation();


                            // Obtaining the bitmap buffer
                            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, rasterXSize, rasterYSize),
                                ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
                            try
                            {

                                int stride = bitmapData.Stride;
                                IntPtr buf = bitmapData.Scan0;
                                var buffer = new byte[rasterXSize * rasterYSize];

                                band.ReadRaster(0, 0, ds.RasterXSize, ds.RasterYSize, buffer, rasterXSize,
                                    rasterYSize, 1, rasterXSize);

                                int c = 0;
                                if (cint == ColorInterp.GCI_AlphaBand)
                                    foreach (var b in buffer)
                                    {
                                        Marshal.WriteByte(buf, 3 + c * 4, (byte)b);
                                        c++;
                                    }
                                else if (cint == ColorInterp.GCI_RedBand)
                                    foreach (var b in buffer)
                                    {
                                        Marshal.WriteByte(buf, 2 + c * 4, (byte)b);
                                        c++;
                                    }
                                else if (cint == ColorInterp.GCI_GreenBand)
                                    foreach (var b in buffer)
                                    {
                                        Marshal.WriteByte(buf, 1 + c * 4, (byte)b);
                                        c++;
                                    }
                                else if (cint == ColorInterp.GCI_BlueBand)
                                    foreach (var b in buffer)
                                    {
                                        Marshal.WriteByte(buf, 0 + c * 4, (byte)b);
                                        c++;
                                    }
                                else
                                {

                                }
                            }
                            finally
                            {
                                bitmap.UnlockBits(bitmapData);
                            }
                        }

                        //bitmap.Save("gdal.bmp", ImageFormat.Bmp);
                        return bitmap;
                    }
                }
            }
        }

        private static string GDALInfoGetPosition(Dataset ds, double x, double y)
        {
            double[] adfGeoTransform = new double[6];
            double dfGeoX, dfGeoY;
            ds.GetGeoTransform(adfGeoTransform);

            dfGeoX = adfGeoTransform[0] + adfGeoTransform[1] * x + adfGeoTransform[2] * y;
            dfGeoY = adfGeoTransform[3] + adfGeoTransform[4] * x + adfGeoTransform[5] * y;

            return dfGeoX.ToString() + ", " + dfGeoY.ToString();
        }

        private static double[] GDALInfoGetPositionDouble(Dataset ds, double x, double y)
        {
            double[] adfGeoTransform = new double[6];
            double dfGeoX, dfGeoY;
            ds.GetGeoTransform(adfGeoTransform);

            dfGeoX = adfGeoTransform[0] + adfGeoTransform[1] * x + adfGeoTransform[2] * y;
            dfGeoY = adfGeoTransform[3] + adfGeoTransform[4] * x + adfGeoTransform[5] * y;
            
            return new double[] { dfGeoX, dfGeoY };
        }

        public class GeoBitmap
        {
            Bitmap _previewBitmap = null;
            Bitmap _displayBitmap = null;
            //List<Tile> _tiles = null;

            //public struct Tile
            //{
            //    public Bitmap _tile;
            //    public RectLatLng _position;
            //    public Tile(Bitmap tile, RectLatLng position)
            //    {
            //        _tile = tile;
            //        _position = position;
            //    }
            //} 

            // load on demand
            //public List<Tile> BitmapTile
            //{
            //    get
            //    {
            //        return _tiles;
            //    }
            //    set
            //    {
            //        _tiles = value;
            //    }
            //}

            public Bitmap DisplayBitmap
            {
                get
                {
                    lock (this)
                    {
                        if (_previewBitmap == null) _previewBitmap = LoadImage(File, 1024, 1024);
                        if (_displayBitmap == null) _displayBitmap = LoadImage(File, 4096, 4096);
                        return _displayBitmap;
                    }
                }
            }

            public Bitmap PreviewBitmap
            {
                get
                {
                    lock (this)
                    {
                        if (_previewBitmap == null) _previewBitmap = LoadImage(File, 1024, 1024);
                        return _previewBitmap;
                    }
                }
            }

            public void SetTransparent(Color color)
            {
                DisplayBitmap.MakeTransparent(color);
                PreviewBitmap.MakeTransparent(color);
                //for (int i = 0; i <  BitmapTile.Count; i++)
                //{
                //    BitmapTile[i]._tile.MakeTransparent(color);
                //}
            }

            public GMap.NET.RectLatLng Rect;
            public string File;
            public int RasterXSize;
            public int RasterYSize;
            public double Resolution;
            public double[] Projection;

            public GeoBitmap(string file, double resolution, int rasterXSize, int rasterYSize, double Left, double Top, double Right, double Bottom, double[] projection)
            {
                this.File = file;
                this.Resolution = resolution;
                this.RasterXSize = rasterXSize;
                this.RasterYSize = rasterYSize;
                Rect = new GMap.NET.RectLatLng(Top, Left, Right - Left, Top - Bottom);
                this.Projection = projection;
            }

            public double[] GetPosition(double x,double y)
            {
                double dfGeoX, dfGeoY;

                dfGeoX = Projection[0] + Projection[1] * x + Projection[2] * y;
                dfGeoY = Projection[3] + Projection[4] * x + Projection[5] * y;

                return new double[] { dfGeoX, dfGeoY };
            }
        }

        //http://www.gisremotesensing.com/2015/09/vector-to-raster-conversion-using-gdal-c.html
        public static void Rasterize(string inputFeature, string outRaster, string fieldName, int cellSize)
        {
            // Define pixel_size and NoData value of new raster  
            int rasterCellSize = cellSize;
            const double noDataValue = -9999;
            string outputRasterFile = outRaster;
            //Register the vector drivers  
            Ogr.RegisterAll();
            //Reading the vector data  
            DataSource dataSource = Ogr.Open(inputFeature, 0);
            var count = dataSource.GetLayerCount();
            Layer layer = dataSource.GetLayerByIndex(0);
            var litems = layer.GetFeatureCount(0);
            var lname = layer.GetName();
            Envelope envelope = new Envelope();
            layer.GetExtent(envelope, 0);
            //Compute the out raster cell resolutions  
            int x_res = Convert.ToInt32((envelope.MaxX - envelope.MinX) / rasterCellSize);
            int y_res = Convert.ToInt32((envelope.MaxY - envelope.MinY) / rasterCellSize);
            Console.WriteLine("Extent: " + envelope.MaxX + " " + envelope.MinX + " " + envelope.MaxY + " " + envelope.MinY);
            Console.WriteLine("X resolution: " + x_res);
            Console.WriteLine("X resolution: " + y_res);
            //Register the raster drivers  
            Gdal.AllRegister();
            //Check if output raster exists & delete (optional)  
            if (File.Exists(outputRasterFile))
            {
                File.Delete(outputRasterFile);
            }
            //Create new tiff   
            OSGeo.GDAL.Driver outputDriver = Gdal.GetDriverByName("GTiff");
            Dataset outputDataset = outputDriver.Create(outputRasterFile, x_res, y_res, 1, DataType.GDT_Float64, null);
            //Extrac srs from input feature   
            string inputShapeSrs;
            SpatialReference spatialRefrence = layer.GetSpatialRef();
            spatialRefrence.ExportToWkt(out inputShapeSrs);
            //Assign input feature srs to outpur raster  
            outputDataset.SetProjection(inputShapeSrs);
            //Geotransform  
            double[] argin = new double[] { envelope.MinX, rasterCellSize, 0, envelope.MaxY, 0, -rasterCellSize };
            outputDataset.SetGeoTransform(argin);
            //Set no data  
            Band band = outputDataset.GetRasterBand(1);
            band.SetNoDataValue(noDataValue);
            //close tiff  
            outputDataset.FlushCache();
            outputDataset.Dispose();
            //Feature to raster rasterize layer options  
            //No of bands (1)  
            int[] bandlist = new int[] { 1 };
            //Values to be burn on raster (10.0)  
            double[] burnValues = new double[] { 10.0 };
            Dataset myDataset = Gdal.Open(outputRasterFile, Access.GA_Update);
            //additional options  
            string[] rasterizeOptions;
            //rasterizeOptions = new string[] { "ALL_TOUCHED=TRUE", "ATTRIBUTE=" + fieldName }; //To set all touched pixels into raster pixel  
            rasterizeOptions = new string[] { "ATTRIBUTE=" + fieldName };
            //Rasterize layer  
            //Gdal.RasterizeLayer(myDataset, 1, bandlist, layer, IntPtr.Zero, IntPtr.Zero, 1, burnValues, null, null, null); // To burn the given burn values instead of feature attributes  
            Gdal.RasterizeLayer(myDataset, 1, bandlist, layer, IntPtr.Zero, IntPtr.Zero, 1, burnValues, rasterizeOptions, new Gdal.GDALProgressFuncDelegate(ProgressFunc), "Raster conversion");
        }

        private static int ProgressFunc(double complete, IntPtr message, IntPtr data)
        {
            Console.Write("Processing ... " + complete * 100 + "% Completed.");
            if (message != IntPtr.Zero)
            {
                Console.Write(" Message:" + System.Runtime.InteropServices.Marshal.PtrToStringAnsi(message));
            }
            if (data != IntPtr.Zero)
            {
                Console.Write(" Data:" + System.Runtime.InteropServices.Marshal.PtrToStringAnsi(data));
            }
            Console.WriteLine("");
            return 1;
        }
    }
}