using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;

namespace Map
{
    public class MapPercentageHandler : IInitializable, ITickable
    {
        [Inject] private MapView view;

        private float paintPercentage;

        private float totalTiles;

        public void Initialize()
        {
            totalTiles = GetTileCount(view.GetPaintableSTilemap()) - GetTileCount(view.GetUnPaintableTilemap());
        }

        public void Tick()
        {
            var tileCount = GetTileCount(view.GetPaintSplashTilemap());

            paintPercentage = Mathf.Round(tileCount / (totalTiles) * 100);
        }

        private int GetTileCount(Tilemap tilemap)
        {
            int count = 0;

            // 遍歷Tilemap的每個格子範圍
            foreach (var position in tilemap.cellBounds.allPositionsWithin)
            {
                // 檢查該位置是否有Tile
                if (tilemap.HasTile(position))
                {
                    count++;
                }
            }

            return count;
        }

        public float GetPaintPercentage() => paintPercentage;
    }
}