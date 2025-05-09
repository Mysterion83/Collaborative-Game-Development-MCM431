using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public float SprintSpeed = 10f;
    public float JumpForce = 5f;

    public float GroundedDrag = 2f;
    public float AirDrag = 0f;

    private Rigidbody rb;
    private bool isGrounded;
    public float CurrentSpeed;
    private float MovementSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Check if the player is grounded
        isGrounded = CheckIfGrounded();

        // Handle movement input
        float MoveX = Input.GetAxisRaw("Horizontal");
        float MoveZ = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * MoveX + transform.forward * MoveZ;

        // Normalise the movement vector to ensure consistent speed
        if (move.magnitude > 1)
        {
            move.Normalize();
        }

        // Update CurrentSpeed based on the Rigidbody's velocity
        CurrentSpeed = rb.velocity.magnitude;

        MovementSpeed = GetCurrentSpeed();

        ApplyDrag();

        // Apply movement only if grounded
        if (isGrounded)
        {
            rb.AddForce(move * MovementSpeed * Time.fixedDeltaTime, ForceMode.Acceleration);
        }
    }

    void Update()
    {
        // Handle jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Apply jump force to the Rigidbody
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
    }

    // Method to determine the current speed based on input
    private float GetCurrentSpeed()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            return SprintSpeed;
        }
        else
        {
            return MoveSpeed;
        }
    }

    // Method to check if the player is grounded
    private bool CheckIfGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }

    // Method to apply drag to the Rigidbody
    private void ApplyDrag()
    {
        if (isGrounded)
        {
            rb.drag = GroundedDrag; // Set drag when grounded
        }
        else
        {
            rb.drag = AirDrag; // Set a drag value when not grounded
        }
    }
}
