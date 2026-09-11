[Root](../../../AGENTS.md) > `Assets/Scripts/MainScene/`

# MainScene

Application bootstrap and cross-scene DI root. `Bootstrap.Start()` loads the Title scene through `ISceneService`; `MainInstaller` binds Audio, Notify, SceneTransition, GameData, settings ScriptableObjects, and debug configuration as project singletons. Serialized inputs include scene, game-data, and console ScriptableObjects.

Key files: `Bootstrap.cs`, `MainInstaller.cs`, `Project.MainScene.asmdef`. Depends on all service modules and Extenject. No tests discovered.
