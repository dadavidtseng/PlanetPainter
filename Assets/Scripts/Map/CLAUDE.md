# Map

> [← Root](../../../CLAUDE.md) · `Assets/Scripts/Map/`

Tilemap painting system and paint percentage tracking.

## Interface — `IMapService`

```csharp
float GetPaintPercentage();
```

## DI Bindings (via GameInstaller + MapInstaller)

```csharp
// GameInstaller
Container.Bind<MapRepository>().AsSingle();

// MapInstaller (sub-container on level prefab)
Container.BindInterfacesAndSelfTo<MapService>().AsSingle();
Container.Bind<MapView>().FromComponentInHierarchy().AsSingle();
Container.BindInterfacesAndSelfTo<MapOutlookHandler>().AsSingle();
Container.BindInterfacesAndSelfTo<MapPercentageHandler>().AsSingle();
```

## Handlers

| Handler | Interfaces | Injects | Responsibility |
|---------|-----------|---------|----------------|
| `MapOutlookHandler` | `ITickable` | MapView, IPlayerService | Paints tiles under player bounds each frame |
| `MapPercentageHandler` | `IInitializable, ITickable` | MapView | Counts total paintable tiles, updates percentage each frame |

## MapOutlookHandler — Paint Logic

- Gets player bounds → converts to tilemap cell coordinates
- For each cell in bounds: skips unpaintable tiles, adds random paint splash variant
- Overwrites existing tile if player color changed
- Tracks painted tiles via `List<TileInfo>` (position + TileColor)

## MapView — Tilemap References

```csharp
Tilemap paintSplashTilemap;      // painted overlay
Tilemap unPaintableTilemap;      // blocked areas
Tilemap paintableTilemap;        // valid paint area
Tilemap[] unPaintableTilemapList;
PaintSplashTileBase[] paintSplashTileBaseList; // { index, TileBase[] paintSplash }
```

## Enums

- `TileColor`: Red, Blue, Yellow, None

## Dependencies

- Zenject (ITickable, IInitializable)
- Player module (IPlayerService for position/bounds)
- Assembly: `Project.Map`
