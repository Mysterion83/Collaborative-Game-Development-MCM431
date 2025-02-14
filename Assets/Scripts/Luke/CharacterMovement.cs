using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public float SprintSpeed = 10f;
    public float JumpForce = 5f;

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Check if the player is grounded
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);

        // Handle movement input
        float MoveX = Input.GetAxis("Horizontal");
        float MoveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * MoveX + transform.forward * MoveZ;

        // Normalise the movement vector to ensure consistent speed
        if (move.magnitude > 1)
        {
            move.Normalize();
        }

        float currentSpeed = GetCurrentSpeed();
        rb.AddForce(move * currentSpeed, ForceMode.Acceleration);

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
        float speed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = SprintSpeed;
        }
        else
        {
            speed = MoveSpeed;
        }
        return speed;
    }
}
