using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Serialized variable for move speed
    [SerializeField]
    private float MoveSpeed = 5f;

    // Serialized variable for the force applied to the player when jumping
    [SerializeField]
    private float JumpForce = 5f;

    // Reference to the Rigidbody component
    private Rigidbody rb;

    private bool IsJumping;

    void Start()
    {
        // Get the Rigidbody component attached to this GameObject
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !IsJumping)
        {
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            IsJumping = true;
        }

        // Get input from the keyboard
        float MoveHorizontal = Input.GetAxisRaw("Horizontal");
        float MoveVertical = Input.GetAxisRaw("Vertical");

        // Create a movement vector
        Vector3 Movement = new Vector3(MoveHorizontal, 0f, MoveVertical).normalized;

        // Move the player using the Rigidbody
        MovePlayer(Movement);
    }

    private void MovePlayer(Vector3 Movement)
    {
        // Apply movement to the Rigidbody
        rb.MovePosition(transform.position + Movement * MoveSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsJumping = false;
        }
    }
}