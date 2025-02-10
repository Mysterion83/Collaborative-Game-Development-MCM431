using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // Movement speed variables
    public float MoveSpeed = 5f;
    public float SprintSpeed = 10f;
    public float JumpForce = 5f;
    public float MouseSensitivity = 2f;

    private CharacterController Controller; // Reference to the CharacterController component
    private Vector3 Velocity; // Stores the player's velocity for movement and gravity
    private bool isGrounded; // Checks if the player is on the ground

    private float xRotation = 0f; // Stores the vertical rotation of the camera

    void Start()
    {
        // Get the CharacterController component attached to the player
        Controller = GetComponent<CharacterController>();
        
        // Lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        // Check if the player is grounded
        isGrounded = Controller.isGrounded;

        // Reset vertical velocity when grounded to prevent falling through the ground
        if (isGrounded && Velocity.y < 0)
        {
            Velocity.y = -2f;
        }

        // Handle movement input
        float MoveX = Input.GetAxis("Horizontal");
        float MoveZ = Input.GetAxis("Vertical");

        // Create a movement vector based on the player's orientation
        Vector3 move = transform.right * MoveX + transform.forward * MoveZ;

        // Move the player using the CharacterController
        // Use sprint speed if Left Shift is held down
        Controller.Move(move * (Input.GetKey(KeyCode.LeftShift) ? SprintSpeed : MoveSpeed) * Time.fixedDeltaTime);

        // Handle jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Apply jump force to the vertical velocity
            Velocity.y += Mathf.Sqrt(JumpForce * -2f * Physics.gravity.y);
        }

        // Apply gravity to the player
        Velocity.y += Physics.gravity.y * Time.fixedDeltaTime; // Continuously apply gravity over time
        Controller.Move(Velocity * Time.fixedDeltaTime); // Move the player based on the updated velocity

        // Handle mouse look
        float MouseX = Input.GetAxis("Mouse X") * MouseSensitivity;
        float MouseY = Input.GetAxis("Mouse Y") * MouseSensitivity;

        // Update the vertical rotation of the camera
        xRotation -= MouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Clamp the vertical rotation to prevent flipping

        // Apply the vertical rotation to the camera
        Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        
        // Rotate the player based on horizontal mouse movement
        transform.Rotate(Vector3.up * MouseX);
    }
}
