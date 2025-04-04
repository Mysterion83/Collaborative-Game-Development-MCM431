using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryStairsController : Interactable
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public override void Interact()
    {
        animator.SetTrigger("TrLowerStairs");
    }
    public override void ScrollInteract(float mouseScrollDelta)
    {
        return;
    }
}
