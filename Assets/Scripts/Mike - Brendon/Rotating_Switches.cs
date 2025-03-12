using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating_Switches : MonoBehaviour
{
    public List<GameObject> rotatingObjects = new List<GameObject>();
    public List<Vector3> rotatingAngles = new List<Vector3>();
    public List<bool> rotatingDirections = new List<bool>();
    public float rotationSpeed = 1f;

    public void Rotate()
    {
        Debug.Log("1");
        for (int i = 0; i < rotatingObjects.Count; i++)
        {
            Debug.Log("2");
            if (rotatingObjects[i] != null && rotatingAngles[i] != null && rotatingDirections[i] != null)
            {
                Debug.Log("3");
                rotatingObjects[i].transform.rotation = Quaternion.Lerp(rotatingObjects[i].transform.rotation, Quaternion.Euler(new Vector3(rotatingAngles[i].x, rotatingAngles[i].y * (rotatingDirections[i] ? -1f : 1f), rotatingAngles[i].z)), Time.deltaTime * rotationSpeed);
            }
        }
    }

// Update is called once per frame
void Update()
    {
        
    }
}
