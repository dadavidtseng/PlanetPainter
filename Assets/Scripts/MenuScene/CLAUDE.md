# MenuScene

> [← Root](../../../CLAUDE.md) · `Assets/Scripts/MenuScene/`

Level selection UI and storyboard display.

## MenuInstaller — Scene DI Container

```csharp
Container.BindInterfacesAndSelfTo<MenuService>().AsSingle();
Container.Bind<MenuStateHandler>().AsSingle();
Container.DeclareSignal<OnMenuStateChanged>();
```

## UI_Menu

Injects: SignalBus, GameData, IAudioService, IMenuService, ISceneService

- Plays menu BGM on awake
- Disables level buttons beyond current `gameData.difficulty`
- Animates hand image with looping Y-position tween
- `Button_LoadLevel(int levelIndex)`: sets difficulty, loads scene 2 (Game)
- `Button_Back()`: loads scene 0 (Title)
- `Button_OpenStoryBoard()`: changes to StoryBoard state

## UI_StoryBoard (`[ExecuteInEditMode]`)

Injects: SignalBus, IAudioService, IMenuService

- Complex book page-flip animation system
- Supports left-to-right and right-to-left flipping
- Calculates curl geometry based on mouse position
- Clipping planes and shadow effects for 3D appearance
- Tweens page animations (0.15s duration)
- Fires `OnFlip` UnityEvent on page completion

## Enums

- `StoryBoardMode`: RightToLeft, LeftToRight

## Dependencies

- Zenject, DOTween, TextMeshPro
- Menu, SceneTransition, Audio, Data modules
- Assembly: `Project.MenuScene`
