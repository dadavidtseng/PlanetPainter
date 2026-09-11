[Root](../../../AGENTS.md) > `Assets/Scripts/Game/`

# Game

Owns the gameplay state machine. `GameService` implements `IGameService`; `GameStateHandler` changes state and publishes `OnGameStateChanged`; `GameLevelHandler` instantiates the configured level prefab during initialization. States are Tutorial, Game, Pause, GameOver, and Result.

Key files: `GameService.cs`, `IGameService.cs`, `Handler/`, `Type/`, `GameEvent.cs`, `Project.Game.asmdef`. Depends on Data and Extenject. No tests discovered.
