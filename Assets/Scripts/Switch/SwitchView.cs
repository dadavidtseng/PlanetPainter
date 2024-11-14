using Interactable;
using Player;
using UnityEngine;
using Zenject;

namespace Switch
{
    public class SwitchView : BaseInteractableView
    {
        [Inject] private readonly SwitchFacade       facade;
        [Inject] private readonly SwitchColorHandler colorHandler;
        [Inject] private readonly IPlayerService     playerService;

        [SerializeField] private BoxCollider2D blockCollider;
        [SerializeField] private BoxCollider2D detectCollider;
        [SerializeField] private Sprite[]      targetSprites;

        public override void Interact()
        {
            if (playerService.GetPlayerColor() == PlayerColor.Original)
                return;

            colorHandler.ChangeColor();

            Debug.Log($"SWITCH #{facade.GetSwitchIndex()} | Interact");
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player"))
                return;

            SetCanInteract(true);
            Debug.Log($"SWITCH #{facade.GetSwitchIndex()} | canInteract: {canInteract}");
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.CompareTag("Player"))
                return;

            SetCanInteract(false);
            Debug.Log($"SWITCH #{facade.GetSwitchIndex()} | canInteract: {canInteract}");
        }

        private Transform GetTransform()                      => transform;
        public  void      SetPosition(Vector2 targetPosition) => GetTransform().position = targetPosition;
        public  void      SetSprite(Sprite    targetSprite)   => spriteRenderer.sprite = targetSprite;
        public  Sprite[]  GetTargetSprites()                  => targetSprites;
    }
}