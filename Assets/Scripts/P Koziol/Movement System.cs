using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSystem : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;
    [SerializeField]
    float MovementSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 RawInput = GetRawInput();

        RawInput = RawInput.normalized;

        RawInput *= MovementSpeed;

        rb.velocity = new Vector3(RawInput.x, rb.velocity.y, RawInput.z);
    }

    Vector3 GetRawInput()
    {
        Vector3 RawInput = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            RawInput += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            RawInput -= transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            RawInput += transform.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            RawInput -= transform.right;
        }
        return RawInput;
    }
}
