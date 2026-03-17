# SceneTransition

> [← Root](../../../CLAUDE.md) · `Assets/Scripts/SceneTransition/`

Addressable scene loading with fade transitions and progress display.

## Interface — `ISceneService`

```csharp
void LoadScene(int sceneIndex, bool isFadeOut = true);
void FadeOut();
```

## DI Bindings (via MainInstaller)

```csharp
Container.BindInterfacesAndSelfTo<SceneService>().AsSingle();
Container.Bind<SceneView>().FromComponentInHierarchy().AsSingle();
Container.Bind<SceneLoadHandler>().AsSingle();
Container.Bind<SceneStateHandler>().AsSingle();
```

## SceneLoadHandler — Core Logic

Injects: SceneScriptableObject, SceneStateHandler, SceneView

- Maintains `Queue<AsyncOperationHandle<SceneInstance>>` of loaded scenes
- `LoadScene()`: unloads previous scene → fade out → load addressable scene → update progress bar via `UniTask.Yield()` → fade in
- State transitions: `Complete` → `Loading` → `Complete`

## SceneView

- `CanvasGroup` for fade (DOTween 0.5s)
- `Slider` for progress bar during load

## SceneScriptableObject

```csharp
[CreateAssetMenu(fileName = "SceneData_SO", menuName = "Scenes/SceneData_SO")]
public class SceneScriptableObject : ScriptableObject {
    public AssetReference[] sceneAssets;
}
```

Scene indices: 0=Title, 1=Menu, 2=Game

## Enums

- `SceneState`: Complete (0), Loading (1), Unloading (2)

## Dependencies

- Zenject, UniTask, Addressables, DOTween
- Assembly: `Project.SceneTransition`
