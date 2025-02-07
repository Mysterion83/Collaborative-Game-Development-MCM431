using UnityEngine;

public class InteractableButton : Interactable
{
    [SerializeField]
    private Interactable[] _objectsToInteractWith;

    public override void Interact()
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
