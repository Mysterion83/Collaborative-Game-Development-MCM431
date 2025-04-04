using UnityEngine;

public class InteractableSingleUseButton : InteractableButton
{
    public override void Interact()
    {
        base.Interact();
        tag = "Untagged";
    }
}
