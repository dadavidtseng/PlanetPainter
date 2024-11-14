using UnityEngine;
using Zenject;

namespace Title
{
    public class TitleStateHandler
    {
        [Inject] private readonly SignalBus signalBus;

        private TitleState state = TitleState.Title;

        public void ChangeState(TitleState nextState)
        {
            if (state == nextState)
                return;

            var preState = state;

            state = nextState;

            signalBus.Fire(new OnTitleStateChanged(preState, state));

            // if (consoleSettings.consoleSettings.printOnGameStateChanged)
            Debug.Log($"<color=#ff0000><b>TITLE STATE | preState: {preState}, state: {state}</b></color>");
        }

        public TitleState GetState() => state;
    }
}