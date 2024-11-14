using Misc;
using UnityEngine;
using Zenject;

namespace Game
{
    public class GameStateHandler
    {
        [Inject] private readonly SignalBus               signalBus;
        [Inject] private readonly ConsoleScriptableObject consoleSettings;

        private GameState state = GameState.Tutorial;

        public void ChangeState(GameState nextState)
        {
            if (state == nextState)
                return;

            var preState = state;

            state = nextState;

            signalBus.Fire(new OnGameStateChanged(preState, state));

            if (consoleSettings.consoleSettings.printOnGameStateChanged)
                Debug.Log($"<color=#ff0000><b>GAME STATE | preState: {preState}, state: {state}</b></color>");
        }

        public GameState GetGameState() => state;
    }
}