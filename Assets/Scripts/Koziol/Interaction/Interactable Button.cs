using UnityEngine;

public class InteractableButton : Interactable
{
    [SerializeField]
    private Interactable[] _objectsToInteractWith;

    public override void Interact()
    {
        if (_objectsToInteractWith.Length == 0) Debug.LogWarning("Interactable Button: Button Does not have any interactables to interact with", gameObject);
        InteractWithInteractables();
    }

    private void InteractWithInteractables()
    {
        foreach (Interactable interactableObject in _objectsToInteractWith)
        {
            interactableObject.Interact();
        }
    }

    public override void ScrollInteract(float mouseScrollDelta)
    {
        return;
    }
}
