[Root](../../../AGENTS.md) > `Assets/Scripts/Player/`

# Player

Core player behavior: movement, color changes, painting/interaction states, collision effects, camera following, and animation. `PlayerService` implements `IPlayerService`; handlers split movement, state, color, animation, outlook, and collision responsibilities. Signals include `OnPlayerStateChanged` and `OnPlayerColorChanged`. Collision tags cover WaterBox, PainterBox, BlockerBox, and Wall.

Key files: `PlayerService.cs`, `PlayerView.cs`, `Handler/`, `Type/`, `PlayerEvent.cs`. Depends on Game, Map, MainCamera, SceneTransition, Audio, Interactable, and Extenject. No tests discovered.
