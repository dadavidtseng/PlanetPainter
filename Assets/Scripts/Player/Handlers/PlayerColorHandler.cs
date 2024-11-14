using Misc;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerColorHandler
    {
        [Inject] private readonly SignalBus               signalBus;
        [Inject] private readonly ConsoleScriptableObject consoleSettings;

        private PlayerColor color = PlayerColor.Original;

        public void ChangeColor(PlayerColor nextColor)
        {
            if (color == nextColor)
                return;

            var preColor = color;

            color = nextColor;

            signalBus.Fire(new OnPlayerColorChanged(preColor, color));

            if (consoleSettings.consoleSettings.printOnPlayerColorChanged)
                Debug.Log($"<color=#ff0000><b>PLAYER COLOR | preColor: {preColor}, color: {color}</b></color>");
        }

        public PlayerColor GetColor() => color;
    }
}