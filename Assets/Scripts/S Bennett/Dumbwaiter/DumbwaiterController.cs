using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbwaiterController : Interactable
{
    [Header("Object References")]
    [SerializeField] GameObject Player;
    [SerializeField] GameObject LiftPlatform;
    [SerializeField] GameObject LiftButton;

    [Header("Component References")]
    [SerializeField] LiftColliderHandler liftColliderHandler;
    [SerializeField] Animator animator;

    public override void Interact()
    {
        if (liftColliderHandler.isInsideLift)
        {
            // Untag the button so it can only be pressed once
            LiftButton.tag = "Untagged";

            // Reset Player position to prevent the player from falling through the lift platform
            Vector3 liftPos = LiftPlatform.transform.position;
            Player.transform.position = new Vector3(liftPos.x, liftPos.y + 2, liftPos.z);

            // Play the lift animation
            animator.SetTrigger("TrLiftUp");
        }  
    }
    public override void ScrollInteract(float mouseScrollDelta)
    {
        return;
    }
}
