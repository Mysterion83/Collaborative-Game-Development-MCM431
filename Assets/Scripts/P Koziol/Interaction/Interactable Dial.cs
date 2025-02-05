using UnityEngine;

public class InteractableDial : Interactable
{
    [SerializeField]
    private float _sensitivity = 1f;
    [SerializeField]
    private float _dialValue = 0f;

    public override void Interact()
    {
        return;
    }
    public override void ScrollInteract(float mouseScrollDelta)
    {
        _dialValue += mouseScrollDelta * _sensitivity;
        if (_dialValue < 0f) _dialValue += 360f;
        else if (_dialValue > 360f) _dialValue -= 360f;
    }
    public float GetDialValue()
    {
        return _dialValue;
    }
}
