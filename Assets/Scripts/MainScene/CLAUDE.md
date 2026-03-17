# MainScene

> [← Root](../../../CLAUDE.md) · `Assets/Scripts/MainScene/`

Bootstrap scene and root Zenject installer. Entry point for the application.

## Bootstrap.cs

```csharp
public class Bootstrap : MonoBehaviour
{
    [Inject] private readonly ISceneService sceneService;
    void Start() => sceneService.LoadScene(0); // loads Title
}
```

## MainInstaller.cs — Root DI Container

Cross-scene singleton bindings:

| Binding | Type | Scope |
|---------|------|-------|
| `AudioService` | InterfacesAndSelfTo | AsSingle |
| `AudioView` | FromComponentInHierarchy | AsSingle |
| `GameData` | Bind | AsSingle |
| `LevelSettings` | BindInstance | IfNotBound |
| `PlayerSettings` | BindInstance | IfNotBound |
| `DoorSettings` | BindInstance | IfNotBound |
| `SwitchSettings` | BindInstance | IfNotBound |
| `NotifyService` | InterfacesAndSelfTo | AsSingle |
| `NotifyView` | FromComponentInHierarchy | AsSingle |
| `SceneService` | InterfacesAndSelfTo | AsSingle |
| `SceneView` | FromComponentInHierarchy | AsSingle |
| `SceneLoadHandler` | Bind | AsSingle |
| `SceneStateHandler` | Bind | AsSingle |
| `ConsoleScriptableObject` | BindInstance | IfNotBound |

Serialized fields: `SceneScriptableObject`, `GameDataScriptableObject`, `ConsoleScriptableObject`

## Dependencies

- Zenject (MonoInstaller, ProjectContext)
- All service modules (Audio, Scene, Notify, Data)
- Assembly: `Project.MainScene`
