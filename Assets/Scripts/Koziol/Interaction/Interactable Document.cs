using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDocument : Interactable
{
    [SerializeField]
    [TextArea(10, 20)]
    string DocumentText;

    public override void Interact()
    {
        DocumentDisplayManager.Instance.DisplayDocument(DocumentText);
    }
    public override void ScrollInteract(float mouseScrollDelta)
    {
        return;
    }

}
