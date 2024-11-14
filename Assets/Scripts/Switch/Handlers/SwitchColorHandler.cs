using Player;
using UnityEngine;
using Zenject;

namespace Switch
{
    public class SwitchColorHandler
    {
        [Inject] private readonly SignalBus      signalBus;
        [Inject] private readonly SwitchFacade   facade;
        [Inject] private readonly IPlayerService playerService;

        private SwitchColor color = SwitchColor.Gray;

        public void ChangeColor()
        {
            var nextColor = (SwitchColor)playerService.GetPlayerColor();

            if (color == nextColor)
                return;

            var preColor = color;

            color = nextColor;

            var index = facade.GetSwitchIndex();

            signalBus.Fire(new OnSwitchColorChanged(index, preColor, color));
            Debug.Log($"SWITCH COLOR | preColor: {preColor}, color: {color}");
        }

        public SwitchColor GetColor() => color;
    }
}