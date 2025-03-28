using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayerMovement : MonoBehaviour
{
    private float MoveSpeed;
    public float WalkSpeed;
    public float SprintSpeed;
    public float CurrentSpeed;

    public float GroundedDrag;

    public float JumpForce;
    public float JumpCooldown;
    public float AirMultiplier;
    bool ReadyJump;

    public KeyCode JumpKey = KeyCode.Space;
    public KeyCode SprintKey = KeyCode.LeftShift;

    public float PlayerHeight;
    public LayerMask Ground;
    bool isGrounded;

    public Transform Orientation;

    float MoveXInput;
    float MoveZInput;

    Vector3 MoveDirection;

    private Rigidbody rb;

    public MovementState State;

    public enum MovementState
    {
        Walking,
        Sprinting,
        Air
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        ReadyJump = true;
    }

    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, PlayerHeight * 1f, Ground);

        Inputs();
        SpeedController();
        StateHandler();

        if (isGrounded)
            rb.drag = GroundedDrag;
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();

        // Update CurrentSpeed based on the Rigidbody's velocity
        CurrentSpeed = rb.velocity.magnitude;
    }

    private void Inputs()
    {
        // Handle movement input
        MoveXInput = Input.GetAxisRaw("Horizontal");
        MoveZInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(JumpKey) && ReadyJump && isGrounded)
        {
            ReadyJump = false;

            Jump();

            Invoke(nameof(ResetJump), JumpCooldown);
        }
    }

    private void StateHandler()
    {
        // Mode Sprinting
        if(isGrounded && Input.GetKey(SprintKey))
        {
            State = MovementState.Sprinting;
            MoveSpeed = SprintSpeed;
        }

        // Mode Walking
        else if(isGrounded)
        {
            State = MovementState.Walking;
            MoveSpeed = WalkSpeed;
        }

        // Mode Air
        else
        {
            State = MovementState.Air;
        }
    }

    private void MovePlayer()
    {
        MoveDirection = Orientation.forward * MoveZInput + Orientation.right * MoveXInput;

        // on ground
        if(isGrounded)
            rb.AddForce(MoveDirection.normalized * MoveSpeed * 10f, ForceMode.Force);

        // in air
        else if(!isGrounded)
            rb.AddForce(MoveDirection.normalized * MoveSpeed * 10f * AirMultiplier, ForceMode.Force);
    }

    private void SpeedController()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVel.magnitude > MoveSpeed)
        {

            Vector3 limitVel = flatVel.normalized * MoveSpeed;
            rb.velocity = new Vector3(limitVel.x, rb.velocity.y, limitVel.z);
        }
    }

    private void Jump()
    {
            // Apply jump force to the Rigidbody & reset y velocity
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(transform.up * JumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        ReadyJump = true;
    }
}