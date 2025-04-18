using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDocumentSmall : Interactable
{
    [SerializeField]
    [TextArea(10, 20)]
    private string _documentText;

    public override void Interact()
    {
        DocumentDisplayManagerSmallerText.Instance.DisplayDocument(_documentText);
    }
    public override void ScrollInteract(float mouseScrollDelta)
    {
        return;
    }

}
