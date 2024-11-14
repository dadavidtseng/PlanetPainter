using System;
using System.Collections.Generic;
using System.Linq;
using Map.Types;
using Player;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Map
{
    public class MapOutlookHandler : ITickable
    {
        [Inject] private readonly MapView        view;
        [Inject] private readonly IPlayerService playerService;

        private List<TileInfo> tileInfos = new();

        public void Tick()
        {
            var playerColor = playerService.GetPlayerColor();

            if (playerColor == PlayerColor.Original)
                return;

            var paintSplashTilemap = view.GetPaintSplashTilemap();
            var unPaintableTilemap = view.GetUnPaintableTilemap();
            var bounds             = playerService.GetPlayerBounds();

            var min = paintSplashTilemap.WorldToCell(bounds.min);
            var max = paintSplashTilemap.WorldToCell(bounds.max);

            for (var x = min.x; x <= max.x; x++)
            {
                for (var y = min.y; y <= max.y; y++)
                {
                    var tilePosition = new Vector3Int(x, y, 0);

                    if (unPaintableTilemap.HasTile(tilePosition))
                        continue;

                    if (!paintSplashTilemap.HasTile(tilePosition))
                    {
                        var randomNum = Random.Range(0, 6);
                        var newTile   = view.GetPaintSplashTileBaseList()[(int)playerColor].paintSplash[randomNum];

                        paintSplashTilemap.SetTile(tilePosition, newTile);
                        
                        tileInfos.Add(new TileInfo
                                      {
                                          position = tilePosition,
                                          color    = (TileColor)playerColor
                                      });
                    }

                    if (paintSplashTilemap.HasTile(tilePosition))
                    {
                        var tileInfo = tileInfos.FirstOrDefault(tile => tile.position == tilePosition);
                        
                        if (tileInfo.color != (TileColor)playerColor)
                        {
                            var randomNum = Random.Range(0, 6);
                            var newTile   = view.GetPaintSplashTileBaseList()[(int)playerColor].paintSplash[randomNum];
                            
                            paintSplashTilemap.SetTile(tilePosition, newTile);
                            
                            tileInfos.Remove(tileInfo);
                            
                            tileInfos.Add(new TileInfo
                                          {
                                              position = tilePosition,
                                              color    = (TileColor)playerColor
                                          });
                        }
                    }
                }
            }
        }
    }

    public struct TileInfo : IEquatable<TileInfo>
    {
        public Vector3Int position;
        public TileColor  color;

        public bool Equals(TileInfo other)
        {
            return position.Equals(other.position) && color == other.color;
        }

        public override bool Equals(object obj)
        {
            return obj is TileInfo other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(position, (int)color);
        }
    }
}