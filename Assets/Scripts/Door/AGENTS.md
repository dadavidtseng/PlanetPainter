[Root](../../../AGENTS.md) > `Assets/Scripts/Door/`

# Door

Implements colored, interactive doors with Extenject memory pooling. `DoorSpawner` reads `GameData`, `DoorFacade` manages pooled lifecycle and repository registration, and `DoorView` unlocks from matching `OnSwitchColorChanged` signals before checking player color on interaction. Opening the final door advances `GameState` to GameOver/Result.

Key files: `DoorSpawner.cs`, `DoorFacade.cs`, `DoorView.cs`, `DoorRepository.cs`, `DoorInstaller.cs`, `Type/`. Depends on Data, Switch, Player, Game, Interactable. No tests discovered.
