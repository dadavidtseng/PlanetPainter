# Interactable

> [← Root](../../../CLAUDE.md) · `Assets/Scripts/Interactable/`

Base class for all interactive objects in the game world.

## BaseInteractableView

```csharp
public class BaseInteractableView : MonoBehaviour {
    [SerializeField] protected SpriteRenderer spriteRenderer;
    [SerializeField] protected bool canInteract;
    [SerializeField] protected bool isInteracted;

    public virtual void Interact();
    public bool CanInteract();
    public void SetCanInteract(bool canInteract);
    public bool IsInteracted();
    protected void SetIsInteracted(bool isInteracted);
}
```

Extended by: `DoorView`, `SwitchView`

## Dependencies

- Assembly: `Project.Interactable`
