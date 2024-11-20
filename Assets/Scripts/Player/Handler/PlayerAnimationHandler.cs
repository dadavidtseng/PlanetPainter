using System;
using Game;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerAnimationHandler : IInitializable, IDisposable
    {
        [Inject] private readonly SignalBus          signalBus;
        [Inject] private readonly IGameService       gameService;
        [Inject] private readonly PlayerView         view;
        [Inject] private readonly PlayerStateHandler stateHandler;
        [Inject] private readonly PlayerColorHandler colorHandler;

        public void Initialize()
        {
            view.SetAnimationFloat((int)colorHandler.GetColor(), (int)stateHandler.GetState());

            signalBus.Subscribe<OnPlayerStateChanged>(OnPlayerStateChanged);
            signalBus.Subscribe<OnPlayerColorChanged>(OnPlayerColorChanged);
            signalBus.Subscribe<OnGameStateChanged>(OnGameStateChanged);
        }

        private void OnPlayerColorChanged(OnPlayerColorChanged e)
        {
            view.SetAnimationFloat((int)e.color, (int)stateHandler.GetPreState());
        }

        private void OnGameStateChanged(OnGameStateChanged e)
        {
            if (e.state == GameState.Result)
                view.PlayResultAnimation();
        }

        private void OnPlayerStateChanged(OnPlayerStateChanged e)
        {
            if (e.state == PlayerState.IsMoving)
                view.SetAnimationFloat((int)colorHandler.GetColor(), (int)e.preState);
            if (e.state != PlayerState.IsMoving)
                view.SetAnimationFloat((int)colorHandler.GetColor(), (int)e.state);
        }

        public void Dispose()
        {
            signalBus.Unsubscribe<OnPlayerStateChanged>(OnPlayerStateChanged);
            signalBus.Unsubscribe<OnPlayerColorChanged>(OnPlayerColorChanged);
        }
    }
}