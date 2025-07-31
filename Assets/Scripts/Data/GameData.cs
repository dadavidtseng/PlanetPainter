//----------------------------------------------------------------------------------------------------
// GameData.cs
//----------------------------------------------------------------------------------------------------

//----------------------------------------------------------------------------------------------------

using UnityEngine;
using Zenject;

//----------------------------------------------------------------------------------------------------
namespace Data
{
    public class GameData
    {
        [Inject] private LevelSettings  levelSettings;
        [Inject] private PlayerSettings playerSettings;
        [Inject] private DoorSettings   doorSettings;
        [Inject] private SwitchSettings switchSettings;

        public GameObject levelObjects                            => levelSettings.levelObjects[difficulty];
        public Vector2    playerSpawnPosition                     => playerSettings.spawnPosition[difficulty];
        public int        GetDoorCount()                          => doorSettings.doorInfos[difficulty].doorCount;
        public int        GetDoorIndex(int index)                 => doorSettings.doorInfos[difficulty].doorIndex[index];
        public int        GetDoorRegisteredSwitchIndex(int index) => doorSettings.doorInfos[difficulty].registeredSwitchIndex[index];
        public int        GetDoorColorIndex(int index)            => doorSettings.doorInfos[difficulty].doorColorIndex[index];
        public int        GetDoorTypeIndex(int index)             => doorSettings.doorInfos[difficulty].doorTypeIndex[index];
        public Vector2    GetDoorSpawnPosition(int index)         => doorSettings.doorInfos[difficulty].spawnPosition[index];
        public int        GetSwitchCount()                        => switchSettings.switchInfos[difficulty].switchCount;
        public int        GetSwitchIndex(int index)               => switchSettings.switchInfos[difficulty].switchIndex[index];
        public int        GetSwitchColorIndex(int index)          => switchSettings.switchInfos[difficulty].switchColorIndex[index];
        public Vector2    GetSwitchSpawnPosition(int index)       => switchSettings.switchInfos[difficulty].spawnPosition[index];

        public int  difficulty               { get; private set; }
        public void SetDifficulty(int delta) => difficulty = delta;
        public bool isValid                  { get; private set; }
        public void SetValid(bool isValid)   => this.isValid = isValid;
    }
}