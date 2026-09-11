[Root](../../../AGENTS.md) > `Assets/Scripts/Data/`

# Data

Provides the runtime `GameData` container and authored level configuration. `GameDataScriptableObject` groups `LevelSettings`, `PlayerSettings`, `DoorSettings`, and `SwitchSettings`; `GameData` exposes difficulty-indexed accessors for level objects, spawns, colors, and counts. `GameDataUploadHandler` is currently a persistence stub. Bound from `MainInstaller`; consumed by Game, Player, Door, Switch, Menu, and UI modules.

Key files: `GameData.cs`, `ScriptableObject/GameDataScriptableObject.cs`, `Project.Data.asmdef`. No tests discovered.
