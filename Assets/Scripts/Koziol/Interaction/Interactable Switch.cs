using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableSwitch : Interactable
{
    public bool State { get { return _state; } }
    protected bool _state;
    public override void Interact()
    {
        _state = !_state;
    }
    public override void ScrollInteract(float mouseScrollDelta)
    {
        return;
    }
}
