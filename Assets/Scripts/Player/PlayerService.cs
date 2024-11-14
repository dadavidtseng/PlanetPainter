using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerService : IPlayerService
    {
        [Inject] private readonly PlayerView         view;
        [Inject] private readonly PlayerMoveHandler  moveHandler;
        [Inject] private readonly PlayerStateHandler stateHandler;
        [Inject] private readonly PlayerColorHandler colorHandler;

        //  General-info
        public Transform GetPlayerTransform() => view.GetTransform();
        public Vector3   GetPlayerPosition()  => view.GetPosition();
        public Bounds    GetPlayerBounds()    => view.GetColliderBound();

        //  MoveHandler-related
        public void Move(Vector3 direction) => moveHandler.Move(direction);

        //  StateHandler-related
        public PlayerState GetPlayerState()                         => stateHandler.GetState();
        public void        ChangePlayerState(PlayerState nextState) => stateHandler.ChangeState(nextState);

        //  ColorHandler-related
        public PlayerColor GetPlayerColor()                         => colorHandler.GetColor();
        public void        ChangePlayerColor(PlayerColor nextColor) => colorHandler.ChangeColor(nextColor);

        public void SetWalkingAnimationTrigger(bool  isWalking)  => view.SetWalkingAnimationTrigger(isWalking);
        public void SetPaintingAnimationTrigger(bool isPainting) => view.SetPaintingAnimationTrigger(isPainting);

        public void StartStateAudio() => view.StartStateAudio();

        public void StopStateAudio()     => view.StopStateAudio();
    }
}