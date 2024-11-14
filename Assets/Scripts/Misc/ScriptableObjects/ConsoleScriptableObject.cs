using System;
using UnityEngine;

namespace Misc
{
    [CreateAssetMenu(fileName = "ConsoleData_SO", menuName = "Data/ConsoleData_SO")]
    public class ConsoleScriptableObject : ScriptableObject
    {
        public ConsoleSettings consoleSettings;
    }

    [Serializable]
    public class ConsoleSettings
    {
        public bool printOnGameStateChanged;
        public bool printOnPlayerStateChanged;
        public bool printOnPlayerColorChanged;
    }
}
