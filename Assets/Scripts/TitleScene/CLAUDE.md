# TitleScene

> [← Root](../../../CLAUDE.md) · `Assets/Scripts/TitleScene/`

Title screen UI: main menu, settings, credits, and quit confirmation.

## TitleInstaller — Scene DI Container

```csharp
Container.BindInterfacesAndSelfTo<TitleService>().AsSingle();
Container.Bind<TitleStateHandler>().AsSingle();
Container.DeclareSignal<OnTitleStateChanged>();
```

## UI Components

| File | Injects | Key Behavior |
|------|---------|-------------|
| `UI_Title` | ISceneService, IAudioService, ITitleService, GameData | Plays title BGM; auto-shows credits if difficulty==7 (post-game); DOTween shake on button clicks (0.3s, 10f strength); start button Y-position loop |
| `UI_Setting` | SignalBus, IAudioService, ITitleService | Shows on Setting state; BGM/SFX volume sliders |
| `UI_Credit` | SignalBus, IAudioService, ITitleService | Shows on Credit state; back button |
| `UI_Quit` | SignalBus, IAudioService, ITitleService | Shows on Quit state; `Application.Quit()` or cancel |

## Post-Game Flow

When `gameData.difficulty == 7` (all 8 levels complete), `UI_Title` auto-transitions to Credit screen and sets difficulty to 8.

## Dependencies

- Zenject, DOTween
- Title, SceneTransition, Audio, Data modules
- Assembly: `Project.TitleScene`
