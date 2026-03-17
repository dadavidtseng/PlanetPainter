# Menu

> [← Root](../../../CLAUDE.md) · `Assets/Scripts/Menu/`

Menu state management for level selection flow.

## Interface — `IMenuService`

```csharp
void      ChangeMenuState(MenuState nextState);
MenuState GetMenuState();
```

Note: interface file is named `ITitleService.cs` but declares `IMenuService`.

## DI Bindings (via MenuInstaller)

```csharp
Container.BindInterfacesAndSelfTo<MenuService>().AsSingle();
Container.Bind<MenuStateHandler>().AsSingle();
```

## Signal — `OnMenuStateChanged`

```csharp
public struct OnMenuStateChanged {
    public readonly MenuState preState;
    public readonly MenuState state;
}
```

Subscribers: `UI_Menu`, `UI_StoryBoard`

## Enums

- `MenuState`: Menu, StoryBoard

## Dependencies

- Zenject (SignalBus)
- Assembly: `Project.Menu`
