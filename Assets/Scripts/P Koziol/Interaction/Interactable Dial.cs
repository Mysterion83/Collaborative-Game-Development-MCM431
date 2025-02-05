using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDial : Interactable
{
    [SerializeField]
    float Sensitivity = 1f;
    [SerializeField]
    float DialValue = 0f;

    public override void Interact()
    {
        return;
    }
    public override void ScrollInteract(float MouseScrollDelta)
    {
        DialValue += MouseScrollDelta * Sensitivity;
        if (DialValue < 0f) DialValue += 360f;
        else if (DialValue > 360f) DialValue -= 360f;
    }
    public float GetDialValue()
    {
        return DialValue;
    }
}
