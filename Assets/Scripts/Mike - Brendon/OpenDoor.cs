using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : Interactable
{
    private Animator hinge;
    void Start()
    {
        hinge = transform.parent.parent.gameObject.GetComponent<Animator>();
    }
    public override void Interact()
    {
        hinge.SetBool("isOpen", !hinge.GetBool("isOpen"));
    }
    public override void ScrollInteract(float mouseScrollDelta)
    {
        return;
    }
}
