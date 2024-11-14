using System;
using Audio;
using Player;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using Zenject;

namespace GameScene
{
    public class BaseDpad : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [Inject] private readonly IAudioService  audioService;
        [Inject] private readonly IPlayerService playerService;

        protected bool canMove;

        protected virtual void Move()
        {
        }

        public virtual void OnPointerDown(PointerEventData eventData)
        {
            audioService.PlayButtonClickAudio();

            canMove = true;
            playerService.SetWalkingAnimationTrigger(canMove);
            playerService.StartStateAudio();
            playerService.SetPaintingAnimationTrigger(false);
        }

        public virtual void OnPointerUp(PointerEventData eventData)
        {
            canMove = false;
            playerService.SetWalkingAnimationTrigger(canMove);
            playerService.StopStateAudio();
        }
    }
}