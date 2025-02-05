using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableButton : Interactable
{
    [SerializeField]
    private Interactable[] _objectsToInteractWith;

    public override void Interact()
    {
        foreach (Interactable interactObject in _objectsToInteractWith)
        {
            interactObject.Interact();
        }
    }

    public override void ScrollInteract(float mouseScrollDelta)
    {
        return;
    }
}
