# GameScene

> [← Root](../../../CLAUDE.md) · `Assets/Scripts/GameScene/`

Game HUD, D-pad controls, and in-game UI screens. Central scene installer for all gameplay systems.

## GameInstaller — Scene DI Container

Declares all gameplay signals and binds all gameplay systems:

**Signals:** `OnPlayerStateChanged`, `OnPlayerColorChanged`, `OnSwitchColorChanged`, `OnGameStateChanged`

**Bindings:** Camera, Game, Door (pooled factory), Switch (pooled factory), Map, Player (see individual module docs)

## BaseDpad

Injects: IAudioService, IPlayerService

```csharp
public class BaseDpad : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
```

- OnPointerDown: play audio, enable walking animation, start state audio, disable painting
- OnPointerUp: disable walking animation, stop state audio
- Subclasses override `Move()` with directional `playerService.Move(Vector3.left/right/up/down)`

## UI Components

| File | Injects | Key Behavior |
|------|---------|-------------|
| `UI_Game` | SignalBus, IAudioService | Plays BGM on awake; stops on Result state |
| `UI_Pause` | SignalBus, IAudioService, ISceneService, IGameService, GameData | Shows on Pause state; resume/restart/level select/main menu buttons; volume sliders |
| `UI_Result` | SignalBus, GameData, IAudioService, ISceneService, MapRepository | Shows 5s after Result state; star rating (1-4) by paint % thresholds (25/50/75); DOTween OutBounce stars |
| `UI_Tutorial` | IAudioService, IGameService, GameData | 5-page tutorial, only on difficulty==0; skip/finish transitions to Game state |
| `UI_Percentage` | SignalBus, MapRepository | Updates paint % text and slider every frame |
| `UI_InteractBtn` | IAudioService, IPlayerService, IGameService, DoorRepository, SwitchRepository | Iterates doors/switches to find interactable match; triggers interaction + painting animation |
| `UI_PauseBtn` | IGameService, ISceneService, IAudioService | Pauses game if state==Game |
| `UI_GameOver` | — | Empty placeholder |
| `UI_DpadLeft/Right/Up/DownBtn` | IPlayerService | Continuous movement while held; sets idle direction on pointer down/up |

## Star Rating Thresholds (UI_Result)

- 75%+ → 4 stars
- 50-75% → 3 stars
- 25-50% → 2 stars
- <25% → 1 star

Final level (difficulty==7): "Next Level" button becomes "Credit"

## Dependencies

- Zenject, DOTween, UniRx, TextMeshPro
- All gameplay modules (Game, Player, Map, Door, Switch, Audio, SceneTransition)
- Assembly: `Project.GameScene`
