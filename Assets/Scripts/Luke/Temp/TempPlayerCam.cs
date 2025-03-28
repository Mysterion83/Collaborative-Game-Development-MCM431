using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayerCam : MonoBehaviour
{
    public float MouseSensitivity = 2f;

    private bool isPaused = false;

    public Transform Orientation;
    public Transform CameraPosition;

    private float xRotation = 0f;
    private float yRotation = 0f;


    // Start is called before the first frame update
    void Start()
    {
        LockCursor();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0f || isPaused)
            return;

        // Handle mouse look
        float MouseX = Input.GetAxis("Mouse X") * MouseSensitivity;
        float MouseY = Input.GetAxis("Mouse Y") * MouseSensitivity;

        // Update the rotation of the camera & locks the vertical rotatation to 90 degrees
        yRotation += MouseX;
        xRotation -= MouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //rotates the camera based on mouse movement
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        Orientation.rotation = Quaternion.Euler(0f, yRotation, 0f);

        // Teleport the camera to the player's position every frame
        transform.position = CameraPosition.position;
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
