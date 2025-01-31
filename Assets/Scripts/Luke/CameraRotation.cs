using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    // Rotation around the axis
    private float RotX = 0;
    private float RotY = 0;

    // Update is called once per frame
    void Update()
    {
        // Get mouse movement input
       float MouseX = Input.GetAxis("Mouse X");
       float MouseY = Input.GetAxis("Mouse Y");
       transform.Rotate(-MouseY, MouseX, 0);

       // Rotation angles And set game Object rotation
       RotX = RotX + Input.GetAxis("Mouse X");
       RotY = RotY + Input.GetAxis("Mouse Y");
       transform.rotation = Quaternion.Euler(-RotY, RotX, 0);
    }
}
