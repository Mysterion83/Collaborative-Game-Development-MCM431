using System;
using UnityEngine;

[Obsolete("MovementSystem is a temporary system. Do not use it in production code and prefabs.", false)]
public class MovementSystem : MonoBehaviour
{
    [SerializeField]
    Rigidbody _rb;
    [SerializeField]
    float _movementSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 RawInput = GetRawInput();

        RawInput = RawInput.normalized;

        RawInput *= _movementSpeed;

        _rb.velocity = new Vector3(RawInput.x, _rb.velocity.y, RawInput.z);
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
