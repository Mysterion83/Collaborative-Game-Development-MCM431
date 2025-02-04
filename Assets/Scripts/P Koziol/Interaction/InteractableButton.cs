using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableButton : Interactable
{
    [SerializeField]
    Interactable[] ObjectsToInteractWith;

    public override void Interact()
    {
        foreach (Interactable InteractObject in ObjectsToInteractWith)
        {
            InteractObject.Interact();
        }
    }

    public override void ScrollInteract(float MouseScrollDelta)
    {
        return;
    }
}
