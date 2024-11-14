using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Map
{
    public class MapView : MonoBehaviour
    {
        [SerializeField] private Tilemap               paintSplashTilemap;
        [SerializeField] private Tilemap               unPaintableTilemap;
        [SerializeField] private Tilemap               paintableTilemap;
        [SerializeField] private Tilemap[]             unPaintableTilemapList;
        [SerializeField] private PaintSplashTileBase[] paintSplashTileBaseList;

        public Tilemap               GetPaintSplashTilemap()      => paintSplashTilemap;
        public Tilemap               GetUnPaintableTilemap()      => unPaintableTilemap;
        public Tilemap               GetPaintableSTilemap()       => paintableTilemap;
        public Tilemap[]             GetUnPaintableTilemapList()  => unPaintableTilemapList;
        public PaintSplashTileBase[] GetPaintSplashTileBaseList() => paintSplashTileBaseList;
    }


    [Serializable]
    public class PaintSplashTileBase
    {
        public int        index;
        public TileBase[] paintSplash;
    }
}