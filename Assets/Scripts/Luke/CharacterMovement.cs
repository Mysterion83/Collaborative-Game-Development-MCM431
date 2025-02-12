using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public float SprintSpeed = 10f;
    public float JumpForce = 5f;

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        // Check if the player is grounded
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);

        // Handle movement input
        float MoveX = Input.GetAxis("Horizontal");
        float MoveZ = Input.GetAxis("Vertical");

        // Create a movement vector based on the player's orientation
        Vector3 move = transform.right * MoveX + transform.forward * MoveZ;

        // Move the player using the Rigidbody
        rb.MovePosition(rb.position + move * (Input.GetKey(KeyCode.LeftShift) ? SprintSpeed : MoveSpeed) * Time.fixedDeltaTime);

        // Handle jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Apply jump force to the Rigidbody
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
    }
}
