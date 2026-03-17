# Door

> [← Root](../../../CLAUDE.md) · `Assets/Scripts/Door/`

Colored doors that block player progress. Uses Zenject memory pool for lifecycle management.

## DI Bindings (via GameInstaller)

```csharp
Container.Bind<DoorRepository>().AsSingle();
Container.BindInterfacesAndSelfTo<DoorSpawner>().AsSingle();
Container.BindFactory<int, int, DoorType, DoorColor, Vector2, DoorFacade, DoorFacade.DoorFactory>()
    .FromPoolableMemoryPool(poolBinder => poolBinder
        .WithInitialSize(1)
        .FromSubContainerResolve()
        .ByNewPrefabInstaller<DoorInstaller>(doorPrefab)
        .UnderTransformGroup("Doors"));
```

## Entity Lifecycle

1. `DoorSpawner.Initialize()` reads `GameData` config (door count, indices, colors, positions)
2. `DoorFactory.Create(doorIndex, switchIndex, DoorType, DoorColor, position)` spawns pooled instance
3. `DoorFacade.OnSpawned()` sets view position/sprite, applies rotation/flip by DoorType, registers with `DoorRepository`
4. `DoorFacade.OnDespawned()` unregisters from repository

## DoorView — Interaction Logic

Injects: SignalBus, GameData, DoorFacade, DoorRepository, SwitchRepository, IPlayerService, IGameService

- Subscribes to `OnSwitchColorChanged` signal
- Lock state: if signal's switch index matches registered switch AND color matches → unlock (fade lock sprite to 0)
- Trigger enter: sets `canInteract` if unlocked AND player color matches door color
- `Interact()`: changes sprite to open, disables block collider, marks interacted
- If all doors open → `GameState.GameOver` → `GameState.Result` (0.5s delay)

## Enums

- `DoorColor`: Red, Blue, Yellow
- `DoorType`: Front, Back, Left, Right (affects sprite set and rotation)

## Dependencies

- Zenject (MemoryPool, PlaceholderFactory, SignalBus)
- Data, Switch, Player, Game modules
- Assembly: `Project.Door`
