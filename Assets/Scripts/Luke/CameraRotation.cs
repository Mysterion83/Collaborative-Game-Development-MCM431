using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    // Rotation around the axis
    private float RotX = 0;
    private float RotY = 0;

    // Sensitivity multiplier
    public float sensitivity = 2.0f;

    // Clamp values for vertical rotation
    public float minY = -90f;
    public float maxY = 90f;

    // Update is called once per frame
    void Update()
    {
        // Get mouse movement input
        float MouseX = Input.GetAxis("Mouse X") * sensitivity;
        float MouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Update rotation angles
        RotX += MouseX;
        RotY -= MouseY;

        // Clamp the vertical rotation
        RotY = Mathf.Clamp(RotY, minY, maxY);

        // Set the rotation of the camera
        transform.rotation = Quaternion.Euler(RotY, RotX, 0);
    }
}