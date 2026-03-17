# Player

> [← Root](../../../CLAUDE.md) · `Assets/Scripts/Player/`

Player character: movement, color absorption, painting, animation, and state management.

## Interface — `IPlayerService`

```csharp
Transform   GetPlayerTransform();
Vector3     GetPlayerPosition();
Bounds      GetPlayerBounds();
void        Move(Vector3 direction);
void        ChangePlayerState(PlayerState nextState);
PlayerState GetPlayerState();
PlayerColor GetPlayerColor();
void        ChangePlayerColor(PlayerColor nextColor);
void        SetWalkingAnimationTrigger(bool isWalking);
void        SetPaintingAnimationTrigger(bool isPainting);
void        StartStateAudio();
void        StopStateAudio();
```

## DI Bindings (via GameInstaller)

```csharp
Container.BindInterfacesAndSelfTo<PlayerService>().AsSingle();
Container.Bind<PlayerView>().FromComponentInHierarchy().AsSingle();
Container.BindInterfacesAndSelfTo<PlayerAnimationHandler>().AsSingle();
Container.BindInterfacesAndSelfTo<PlayerMoveHandler>().AsSingle();
Container.BindInterfacesAndSelfTo<PlayerOutlookHandler>().AsSingle();
Container.Bind<PlayerCollisionHandler>().AsSingle();
Container.Bind<PlayerStateHandler>().AsSingle();
Container.Bind<PlayerColorHandler>().AsSingle();
```

## Handlers

| Handler | Interfaces | Injects | Responsibility |
|---------|-----------|---------|----------------|
| `PlayerMoveHandler` | `ITickable` | SignalBus, PlayerView, PlayerStateHandler, ICameraService, ISceneService, IGameService | Input reading, movement (speed=5f), camera follow |
| `PlayerStateHandler` | — | SignalBus, ConsoleScriptableObject | State transitions, fires `OnPlayerStateChanged` |
| `PlayerColorHandler` | — | SignalBus, ConsoleScriptableObject | Color transitions, fires `OnPlayerColorChanged` |
| `PlayerAnimationHandler` | `IInitializable, IDisposable` | SignalBus, IGameService, PlayerView, PlayerStateHandler, PlayerColorHandler | Subscribes to state/color/game signals, updates animator |
| `PlayerCollisionHandler` | — | PlayerView, PlayerColorHandler, PlayerMoveHandler, IAudioService | Trigger/collision handling with DOTween sequences |
| `PlayerOutlookHandler` | `IInitializable, IDisposable` | SignalBus, PlayerView | Subscribes to `OnPlayerColorChanged` (TODO: refactor) |

## Collision Logic (PlayerCollisionHandler)

| Trigger Tag | Effect |
|-------------|--------|
| `WaterBox` | Reset color to `Original`, play water sound |
| `PainterBox_Red/Blue/Yellow` | Change to matching color, play particle + sound |
| `BlockerBox_Red/Blue/Yellow` | If color mismatch: speed=0, knockback, play sound |
| `Wall` (collision) | Speed=0, knockback, play sound |

## State Machine

```
IdleUp/Down/Left/Right → IsMoving → (CanAttack→IsAttacking | CanPaint→IsPainting | CanAbsorb→IsAbsorbing) → Idle
                                                                                                              ↓ Dead
```

## Enums

- `PlayerState`: IdleUp, IdleDown, IdleLeft, IdleRight, IsMoving, CanAttack, IsAttacking, CanPaint, IsPainting, CanAbsorb, IsAbsorbing, Dead
- `PlayerColor`: Red, Blue, Yellow, Original

## Dependencies

- Zenject (SignalBus, ITickable, IInitializable)
- Game, Map, MainCamera, SceneTransition, Audio modules
- Assembly: `Project.Player`
