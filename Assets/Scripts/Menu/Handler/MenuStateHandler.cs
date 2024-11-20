using UnityEngine;
using Zenject;

namespace Menu
{
    public class MenuStateHandler
    {
        [Inject] private readonly SignalBus signalBus;

        private MenuState state = MenuState.Menu;

        public void ChangeState(MenuState nextState)
        {
            if (state == nextState)
                return;

            var preState = state;

            state = nextState;

            signalBus.Fire(new OnMenuStateChanged(preState, state));

            // if (consoleSettings.consoleSettings.printOnGameStateChanged)
            Debug.Log($"<color=#ff0000><b>MENU STATE | preState: {preState}, state: {state}</b></color>");
        }

        public MenuState GetState() => state;
    }
}