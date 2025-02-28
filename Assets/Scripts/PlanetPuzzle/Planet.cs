using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public Vector3 currentPosition;

    void Start()
    {
        UpdatePosition();
    }

    public void UpdatePosition()
    {
        currentPosition = transform.localPosition;
    }
}
