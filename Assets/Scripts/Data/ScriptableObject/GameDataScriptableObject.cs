//----------------------------------------------------------------------------------------------------
// GameDataScriptableObject.cs
//----------------------------------------------------------------------------------------------------

//----------------------------------------------------------------------------------------------------

using System;
using UnityEngine;

//----------------------------------------------------------------------------------------------------
namespace Data
{
    [CreateAssetMenu(fileName = "GameData_SO", menuName = "Data/GameData_SO")]
    public class GameDataScriptableObject : ScriptableObject
    {
        public LevelSettings  levelSettings;
        public PlayerSettings playerSettings;
        public DoorSettings   doorSettings;
        public SwitchSettings switchSettings;
    }

    [Serializable]
    public class LevelSettings
    {
        public GameObject[] levelObjects;
    }

    [Serializable]
    public class PlayerSettings
    {
        public Vector2[] spawnPosition;
    }

    [Serializable]
    public class DoorSettings
    {
        public DoorInfo[] doorInfos;
    }

    [Serializable]
    public struct DoorInfo
    {
        public int       doorCount;
        public int[]     doorIndex;
        public int[]     registeredSwitchIndex;
        public int[]     doorTypeIndex;
        public int[]     doorColorIndex;
        public Vector2[] spawnPosition;
    }

    [Serializable]
    public class SwitchSettings
    {
        public SwitchInfo[] switchInfos;
    }

    [Serializable]
    public struct SwitchInfo
    {
        [Header("Switch Count")] public int       switchCount;
        [Header("Switch Index")] public int[]     switchIndex;
        public                          int[]     switchColorIndex;
        public                          Vector2[] spawnPosition;
    }
}