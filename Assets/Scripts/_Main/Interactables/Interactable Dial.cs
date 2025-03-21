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

    bool RotateObject = true;
    RotationAxis _rotationAxis = RotationAxis.Y;


    [SerializeField]
    private Interactable[] _objectsToInteractWith;



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
        foreach (Interactable obj in _objectsToInteractWith)
        {
            obj.Interact();
        }
        switch (_rotationAxis)
        {
            case RotationAxis.X:
                transform.localRotation = Quaternion.Euler(_dialValue, 0, 0);
                break;
            case RotationAxis.Y:
                transform.localRotation = Quaternion.Euler(0, _dialValue, 0);
                break;
            case RotationAxis.Z:
                transform.localRotation = Quaternion.Euler(0, 0, _dialValue);
                break;
        }
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

enum RotationAxis
{
    X,
    Y, 
    Z
}