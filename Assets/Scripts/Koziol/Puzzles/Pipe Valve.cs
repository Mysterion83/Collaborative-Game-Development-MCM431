using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeValve : InteractableSwitch
{
    public override void Interact()
    {
        base.Interact();
        UpdateGuage();
    }
    public override void ScrollInteract(float mouseScrollDelta)
    {
        return;
    }
    private void UpdateGuage()
    {
        if (_state)
        {

        }
        else
        {

        }
    }
}
