using Player;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace GameScene
{
    public class UI_DpadLeftBtn : BaseDpad
    {
        [Inject] private readonly IPlayerService playerService;

        private void Update()
        {
            if (canMove)
                Move();
        }

        protected override void Move()
        {
            playerService.Move(Vector3.left);
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            playerService.ChangePlayerState(PlayerState.IdleLeft);
            playerService.ChangePlayerState(PlayerState.IsMoving);
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
            playerService.ChangePlayerState(PlayerState.IdleLeft);
        }
    }
}