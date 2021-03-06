﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace GMap.NET.WindowsForms.Markers
{
    //可能需要纠偏
    [Serializable]
    public class GMapMarkerLayer : GMapPolygon
    {
        Bitmap displayBitmap;
        List<Bitmap> tiles = new List<Bitmap>();
        List<RectLatLng> tilesPosition = new List<RectLatLng>();
        int count = 0;
        public GMapMarkerLayer(PointLatLng p1, PointLatLng p2, Bitmap display, List<Bitmap> tiles = null, List<RectLatLng> position = null)
         : base(new List<PointLatLng>(), p1.ToString() + p2.ToString())
        {
            double maxLat = p1.Lat > p2.Lat ? p1.Lat : p2.Lat;
            double minLat = p1.Lat < p2.Lat ? p1.Lat : p2.Lat;
            double maxLng = p1.Lng > p2.Lng ? p1.Lng : p2.Lng;
            double minLng = p1.Lng < p2.Lng ? p1.Lng : p2.Lng;
            this.Points.Add(new PointLatLng(maxLat, minLng));
            this.Points.Add(new PointLatLng(maxLat, maxLng));
            this.Points.Add(new PointLatLng(minLat, maxLng));
            this.Points.Add(new PointLatLng(minLat, minLng));
            this.displayBitmap = display;
            if (tiles != null && position != null)
            {
                for (int i = 0; i < tiles.Count; i++)
                {
                    AddTile(tiles[i], position[i]);
                }
            }
        }

        public void AddTile(Bitmap tile, RectLatLng position)
        {
            this.tiles.Add(tile);
            this.tilesPosition.Add(position);
            this.Points.Add(position.LocationTopLeft);
            this.Points.Add(position.LocationRightBottom);
            count++;
        }

        public override void Dispose()
        {
            displayBitmap.Dispose();
            for(int i = 0; i < tiles.Count; i++)
                tiles[i].Dispose();
            tiles.Clear();
            tilesPosition.Clear();
            base.Dispose();
        }
        public override void OnRender(IGraphics g)
        {
#if !PocketPC
            if (IsVisible)
            {
                if (IsVisible)
                {
                    GPoint pos1 = this.LocalPoints[0];
                    GPoint pos2 = this.LocalPoints[2];
                    if (this.displayBitmap != null)
                    {
                        g.DrawImage(
                            this.displayBitmap,
                            pos1.X, pos1.Y,
                            pos2.X - pos1.X, pos2.Y - pos1.Y);
                    }
                    if (tiles != null && pos2.X - pos1.X > 2048)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            GPoint leftTop = LocalPoints[4 + 2 * i];
                            GPoint rightBottom = LocalPoints[5 + 2 * i];
                            
                            g.DrawImage(
                                this.tiles[i],
                                leftTop.X, leftTop.Y,
                                rightBottom.X - leftTop.X, rightBottom.Y - leftTop.Y);
                        }
                    }
                }
            }
#else
            if (this.bitmap != null)
            {
                DrawImageUnscaled(g, this.displayBitmap, LocalPosition.X, LocalPosition.Y);
            }
#endif
        }

    }
}
