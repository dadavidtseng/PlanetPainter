# MainCamera

> [← Root](../../../CLAUDE.md) · `Assets/Scripts/MainCamera/`

Camera follow service for tracking the player.

## Interface — `ICameraService`

```csharp
void      SetCameraPosition(Vector3 targetPosition);
Transform GetCameraTransform();
void      ResetCameraPosition();
```

## DI Bindings (via GameInstaller)

```csharp
Container.BindInterfacesAndSelfTo<CameraService>().AsSingle();
Container.Bind<CameraView>().FromComponentInHierarchy().AsSingle();
```

## CameraView

Injects: GameData

- Sets camera frame sprite based on `gameData.difficulty` at `Start()`
- Reset position: `(0, 0, -10)`
- Null-safe camera access

## Dependencies

- Zenject, Data module
- Assembly: `Project.Camera`
