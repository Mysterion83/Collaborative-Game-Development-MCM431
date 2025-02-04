using UnityEngine;

public class InteractableAnimationObject : Interactable
{
    [SerializeField]
    Animator animator;
    [SerializeField]
    bool isOn;
    [SerializeField]
    string AnimBoolName;


    public override void Interact()
    {
        if (!isOn)
        {
            isOn = true;
            animator.SetBool(AnimBoolName, true);
        }
        else
        {
            isOn = false;
            animator.SetBool(AnimBoolName, false);
        }
    }
    public bool GetIsOn()
    {
        return isOn;
    }


    public override void ScrollInteract(float MouseScrollDelta)
    {
        return;
    }
}