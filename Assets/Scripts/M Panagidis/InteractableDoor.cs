using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDoor : Interactable
{
    public Animator animator;
    public string animBoolName;
    public string animOpenName;
    private bool _isInAnimation = false;

    public bool unlocked = false;

    public override void Interact()
    {
        if (!_isInAnimation)
        {
            _isInAnimation = true;
            if (unlocked)
            {
                if (animator.GetCurrentAnimatorStateInfo(0).IsName(animOpenName))
                {
                    animator.SetBool(animBoolName, false);
                }
                else
                {
                    animator.SetBool(animBoolName, true);
                }
            }
            else
            {
                animator.SetBool(animBoolName, false);
            }
        }
        _isInAnimation = false;
    }

    public override void ScrollInteract(float mouseScrollDelta)
    {
        return;
    }
}
