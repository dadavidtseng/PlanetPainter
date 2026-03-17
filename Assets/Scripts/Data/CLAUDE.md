# Data

> [← Root](../../../CLAUDE.md) · `Assets/Scripts/Data/`

Game configuration, runtime data container, and persistence.

## GameData — Runtime Container

Injects: LevelSettings, PlayerSettings, DoorSettings, SwitchSettings

```csharp
// Difficulty-indexed access
int  difficulty { get; }
void SetDifficulty(int delta);
bool isValid { get; }
void SetValid(bool isValid);

// Level
GameObject levelObjects => levelSettings.levelObjects[difficulty];

// Player
Vector2 playerSpawnPosition => playerSettings.spawnPosition[difficulty];

// Door (per-index within difficulty)
int     GetDoorCount();
int     GetDoorIndex(int index);
int     GetDoorRegisteredSwitchIndex(int index);
int     GetDoorColorIndex(int index);
int     GetDoorTypeIndex(int index);
Vector2 GetDoorSpawnPosition(int index);

// Switch (per-index within difficulty)
int     GetSwitchCount();
int     GetSwitchIndex(int index);
int     GetSwitchColorIndex(int index);
Vector2 GetSwitchSpawnPosition(int index);
```

## GameDataScriptableObject

```csharp
[CreateAssetMenu(fileName = "GameData_SO", menuName = "Data/GameData_SO")]
public class GameDataScriptableObject : ScriptableObject {
    public LevelSettings levelSettings;    // GameObject[] levelObjects
    public PlayerSettings playerSettings;  // Vector2[] spawnPosition
    public DoorSettings doorSettings;      // DoorInfo[] doorInfos
    public SwitchSettings switchSettings;  // SwitchInfo[] switchInfos
}
```

`DoorInfo`: doorCount, doorIndex[], registeredSwitchIndex[], doorTypeIndex[], doorColorIndex[], spawnPosition[]
`SwitchInfo`: switchCount, switchIndex[], switchColorIndex[], spawnPosition[]

## GameDataUploadHandler

Empty stub — reserved for future persistence.

## Dependencies

- Zenject
- Assembly: `Project.Data`
