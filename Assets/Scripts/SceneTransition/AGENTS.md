[Root](../../../AGENTS.md) > `Assets/Scripts/SceneTransition/`

# SceneTransition

Addressable scene-loading service with fade and progress UI. `SceneService` implements `ISceneService`; `SceneLoadHandler` unloads the prior scene, fades, loads the configured `AssetReference`, updates a progress slider with UniTask, then fades in. `SceneStateHandler` tracks Complete/Loading/Unloading. Scene indices are 0=Title, 1=Menu, 2=Game.

Key files: `SceneService.cs`, `Handler/`, `SceneView.cs`, `ScriptableObject/SceneScriptableObject.cs`, `Type/`. Depends on Addressables, UniTask, DOTween, and Extenject. No tests discovered.
