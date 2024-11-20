using Misc;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerStateHandler
    {
        [Inject] private readonly SignalBus               signalBus;
        [Inject] private readonly ConsoleScriptableObject consoleSettings;

        private PlayerState preState;
        private PlayerState state = PlayerState.IdleLeft;

        public void ChangeState(PlayerState nextState)
        {
            if (state == nextState)
                return;

            preState = state;

            state = nextState;

            signalBus.Fire(new OnPlayerStateChanged(preState, state));

            // if (consoleSettings.consoleSettings.printOnPlayerStateChanged)
            //     Debug.Log($"<color=#ff0000><b>PLAYER STATE | preState: {preState}, state: {state}</b></color>");
        }

        public PlayerState GetState()    => state;
        public PlayerState GetPreState() => preState;
    }
}