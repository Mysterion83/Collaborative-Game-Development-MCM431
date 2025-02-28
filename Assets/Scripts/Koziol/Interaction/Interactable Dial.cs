using UnityEngine;

public class InteractableDial : Interactable
{
    [SerializeField]
    private float _sensitivity = 1f;
    [SerializeField]
    private float _dialValue = 0f;
    [SerializeField]
    private int _dialStates;
    [SerializeField]
    private int _currentState = 0;

    public override void Interact()
    {
        return;
    }
    public override void ScrollInteract(float mouseScrollDelta)
    {
        _dialValue += mouseScrollDelta * _sensitivity;
        if (_dialValue < 0f) _dialValue += 360f;
        else if (_dialValue >= 360f) _dialValue -= 360f;
        _currentState = Mathf.FloorToInt(_dialValue / (360f / _dialStates));
    }
    public float GetRawDialValue()
    {
        return _dialValue;
    }
    public int GetDialState()
    {
        return _currentState;
    }
}
