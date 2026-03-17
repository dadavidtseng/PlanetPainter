# Game

> [← Root](../../../CLAUDE.md) · `Assets/Scripts/Game/`

Core game state machine managing gameplay flow.

## Interface — `IGameService`

```csharp
void      ChangeState(GameState nextState);
GameState GetGameState();
```

## DI Bindings (via GameInstaller)

```csharp
Container.BindInterfacesAndSelfTo<GameService>().AsSingle();
Container.Bind<GameStateHandler>().AsSingle();
Container.BindInterfacesAndSelfTo<GameLevelHandler>().AsSingle();
```

## Handlers

| Handler | Interfaces | Injects | Responsibility |
|---------|-----------|---------|----------------|
| `GameStateHandler` | — | SignalBus, ConsoleScriptableObject | State transitions, fires `OnGameStateChanged` |
| `GameLevelHandler` | `IInitializable` | GameData, DiContainer | Instantiates level prefab via `container.InstantiatePrefab()` |

## Signal — `OnGameStateChanged`

```csharp
public struct OnGameStateChanged {
    public readonly GameState preState;
    public readonly GameState state;
}
```

Subscribers: `PlayerAnimationHandler`, `UI_Game`, `UI_Pause`, `UI_Result`

## State Flow

```
Tutorial → Game ↔ Pause
             ↓
           GameOver → Result
```

## Enums

- `GameState`: Tutorial, Pause, Game, GameOver, Result
- `DpadState`: Left, Right, Down, Up, None

## Dependencies

- Zenject (SignalBus, IInitializable, DiContainer)
- Data module (GameData)
- Assembly: `Project.Game`
