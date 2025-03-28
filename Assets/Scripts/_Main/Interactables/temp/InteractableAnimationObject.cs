using System;
using UnityEngine;

[Obsolete("InteractableAnimationObject is a temporary Interactable. Do not use it in production code and prefabs.", false)]
public class InteractableAnimationObject : Interactable
{
    [SerializeField]
    private Animator _animator = null;
    [SerializeField]
    private bool _isOn = false;
    [SerializeField]
    private string AnimBoolName = "";
    
    public override void Interact()
    {
        if (!_isOn)
        {
            _isOn = true;
            _animator.SetBool(AnimBoolName, true);
        }
        else
        {
            _isOn = false;
            _animator.SetBool(AnimBoolName, false);
        }
    }
    public bool GetIsOn()
    {
        return _isOn;
    }

    public override void ScrollInteract(float mouseScrollDelta)
    {
        return;
    }
}
