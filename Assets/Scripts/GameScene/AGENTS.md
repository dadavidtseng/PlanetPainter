[Root](../../../AGENTS.md) > `Assets/Scripts/GameScene/`

# GameScene

Composition root and presentation layer for gameplay. `GameInstaller` declares player/color/switch/game signals and binds Camera, Game, Door, Switch, Map, and Player sub-systems. `BaseDpad` and directional UI drive player movement; UI components cover HUD, percentage, tutorial, pause, result, and interaction flows. `UI_Result` rates paint completion at 25/50/75% thresholds.

Key files: `GameInstaller.cs`, `BaseDpad.cs`, `UI/`. Depends on all gameplay modules, Audio, SceneTransition, Extenject, DOTween, UniRx, and TextMeshPro. No tests discovered.
