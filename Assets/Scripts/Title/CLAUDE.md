# Title

> [← Root](../../../CLAUDE.md) · `Assets/Scripts/Title/`

Title screen state management.

## Interface — `ITitleService`

```csharp
void       ChangeTitleState(TitleState nextState);
TitleState GetTitleState();
```

## DI Bindings (via TitleInstaller)

```csharp
Container.BindInterfacesAndSelfTo<TitleService>().AsSingle();
Container.Bind<TitleStateHandler>().AsSingle();
```

## Signal — `OnTitleStateChanged`

```csharp
public struct OnTitleStateChanged {
    public readonly TitleState preState;
    public readonly TitleState state;
}
```

Subscribers: `UI_Setting`, `UI_Credit`, `UI_Quit`

## Enums

- `TitleState`: Title, Setting, Credit, Quit

## Dependencies

- Zenject (SignalBus)
- Assembly: `Project.Title`
