using UnityEngine;

namespace Interactable
{
    public class BaseInteractableView : MonoBehaviour
    {
        [SerializeField] protected SpriteRenderer spriteRenderer;

        protected bool canInteract;
        protected bool isInteracted;

        public virtual void Interact()
        {
        }

        public bool CanInteract() => canInteract;

        public  void SetCanInteract(bool canInteract) => this.canInteract = canInteract;

        public    bool IsInteracted()                     => isInteracted;
        protected void SetIsInteracted(bool isInteracted) => this.isInteracted = isInteracted;
    }
}