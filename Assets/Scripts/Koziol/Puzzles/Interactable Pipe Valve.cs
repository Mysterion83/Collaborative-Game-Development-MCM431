using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePipeValve : InteractableSwitch
{
    [SerializeField]
    WaterCisternPuzzle _waterCisternPuzzle;
    public override void Interact()
    {
        base.Interact();
        UpdateGuage();
        _waterCisternPuzzle.UpdatePipeStates();
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
