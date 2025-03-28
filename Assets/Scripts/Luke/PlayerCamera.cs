using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float MouseSensitivity = 2f;
    private float xRotation = 0f;
    private bool isPaused = false;

    void Start()
    {
        LockCursor();
    }

    void Update()
    {
        if (Time.timeScale == 0f || isPaused)
            return;
        // Handle mouse look
        float MouseX = Input.GetAxis("Mouse X") * MouseSensitivity;
        float MouseY = Input.GetAxis("Mouse Y") * MouseSensitivity;

        // Update the vertical rotation of the camera
        xRotation -= MouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Apply the vertical rotation to the camera
        Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        
        // Rotate the parent object based on horizontal mouse movement
        transform.Rotate(Vector3.up * MouseX);

        // Teleport the camera to the player's position every frame
        Camera.main.transform.position = transform.position + new Vector3(0,0.5f,0);
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void SetPaused(bool paused)
    {
        isPaused = paused;
    }
}
