using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating_Switches : MonoBehaviour
{
    public List<GameObject> rotatingObjects = new List<GameObject>(); // Objects to rotate
    public List<Vector3> rotationAmount = new List<Vector3>(); // Rotation angles
    public List<bool> Clockwise = new List<bool>(); // Direction of rotation
    public float rotationDuration = 1f; // Time to rotate

    private bool isRotating = false;

    IEnumerator RotateOverTime(GameObject obj, Vector3 angle)
    {
        isRotating = true;
        Quaternion startRotation = obj.transform.rotation;
        Quaternion endRotation = obj.transform.rotation * Quaternion.Euler(angle);
        float elapsedTime = 0;

        while (elapsedTime < rotationDuration)
        {
            obj.transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / rotationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        obj.transform.rotation = endRotation; // Ensure it reaches the exact rotation
        isRotating = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isRotating) // Temporary Interaction system just to make sure it works
        {
            for (int i = 0; i < rotatingObjects.Count; i++)
            {
                if (i < rotationAmount.Count && i < Clockwise.Count)
                {
                    // Determine rotation direction
                    Vector3 rotation = Clockwise[i] ? rotationAmount[i] : -rotationAmount[i];
                    StartCoroutine(RotateOverTime(rotatingObjects[i], rotation));
                }
            }
        }
    }
}
