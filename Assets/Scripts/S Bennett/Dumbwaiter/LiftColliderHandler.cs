using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftColliderHandler : MonoBehaviour
{
    public bool isInsideLift;

    private void OnTriggerEnter(Collider other)
    {
        isInsideLift = true;
    }
    private void OnTriggerExit(Collider other)
    {
        isInsideLift = false;
    }
}
