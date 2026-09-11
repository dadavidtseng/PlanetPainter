[Root](../../../AGENTS.md) > `Assets/Scripts/MainCamera/`

# MainCamera

Provides `ICameraService` through `CameraService` and a scene `CameraView`. Player movement calls the service to follow the active player; the view chooses a difficulty-specific frame sprite from `GameData` and resets to `(0, 0, -10)`. Bound by `GameInstaller`. Depends on Data and Extenject. No tests discovered.
