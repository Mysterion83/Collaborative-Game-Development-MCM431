using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 1;

    private float _rotationX = 1;
    private float _rotationY = 1;
    public float rotationSpeed = 1;

    public float maxRotation = 1;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        transform.Translate(x * movementSpeed * Time.deltaTime, 0, z * movementSpeed * Time.deltaTime);

        _rotationX = _rotationX + Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        _rotationY = _rotationY + Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(-_rotationY, _rotationX, 0);

        _rotationY = Mathf.Clamp(_rotationY, -maxRotation, maxRotation);
    }
}
