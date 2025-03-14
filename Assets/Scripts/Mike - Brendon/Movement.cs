using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 1;

    private float rotationX = 1;
    private float rotationY = 1;
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

        rotationX = rotationX + Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        rotationY = rotationY + Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(-rotationY, rotationX, 0);

        rotationY = Mathf.Clamp(rotationY, -maxRotation, maxRotation);
    }
}
