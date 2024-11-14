using UnityEngine;

namespace Player
{
    public interface IPlayerService
    {
        //  General-info
        Transform GetPlayerTransform();
        Vector3   GetPlayerPosition();
        Bounds    GetPlayerBounds();

        //  MoveHandler-related
        void Move(Vector3 direction);

        //  StateHandler-related
        void        ChangePlayerState(PlayerState nextState);
        PlayerState GetPlayerState();

        //  ColorHandler-related
        PlayerColor GetPlayerColor();
        void        ChangePlayerColor(PlayerColor nextColor);

        // AnimationHandler-related
        void SetWalkingAnimationTrigger(bool  isWalking);
        void SetPaintingAnimationTrigger(bool isPainting);

        void StartStateAudio();
        void StopStateAudio();
    }
}