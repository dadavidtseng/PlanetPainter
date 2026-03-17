# Switch

> [← Root](../../../CLAUDE.md) · `Assets/Scripts/Switch/`

Color-changing switches that unlock matching doors. Uses Zenject memory pool.

## DI Bindings (via GameInstaller)

```csharp
Container.Bind<SwitchRepository>().AsSingle();
Container.BindInterfacesAndSelfTo<SwitchSpawner>().AsSingle();
Container.BindFactory<int, SwitchColor, Vector2, SwitchFacade, SwitchFacade.SwitchFactory>()
    .FromPoolableMemoryPool(poolBinder => poolBinder
        .WithInitialSize(2)
        .FromSubContainerResolve()
        .ByNewPrefabInstaller<SwitchInstaller>(switchPrefab)
        .UnderTransformGroup("Switches"));
```

## Entity Lifecycle

1. `SwitchSpawner.Initialize()` reads `GameData` config
2. `SwitchFactory.Create(index, SwitchColor, position)` spawns pooled instance
3. `SwitchFacade.OnSpawned()` sets view position/sprite, registers with `SwitchRepository`

## Signal — `OnSwitchColorChanged`

```csharp
public struct OnSwitchColorChanged {
    public readonly int index;
    public readonly SwitchColor preColor;
    public readonly SwitchColor color;
}
```

Subscribers: `DoorView` (unlock logic), `SwitchOutlookHandler` (visual update)

## SwitchColorHandler

Injects: SignalBus, SwitchFacade, IPlayerService

- `ChangeColor()`: casts `PlayerColor` → `SwitchColor`, fires signal if changed
- Initial color: `Gray`

## SwitchView — Interaction Logic

Injects: SwitchFacade, SwitchColorHandler, IPlayerService

- Trigger enter/exit: toggles `canInteract`
- `Interact()`: returns if player color is `Original`; calls `colorHandler.ChangeColor()`

## Enums

- `SwitchColor`: Red, Blue, Yellow, Gray

## Dependencies

- Zenject (MemoryPool, PlaceholderFactory, SignalBus)
- Data, Player modules
- Assembly: `Project.Switch`
