using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Rotating_Switches : MonoBehaviour
{
    public List<GameObject> rotatingObjects = new List<GameObject>(); // Objects to rotate
    public List<Vector3> rotationAmount = new List<Vector3>(); // Rotation angles
    public List<bool> Clockwise = new List<bool>(); // Direction of rotation
    public List<Animator> animators = new List<Animator>();
    public List<bool> isRotating = new List<bool>();
    private List<Animator> tempAnimators = new List<Animator>();
    private List<Vector3> rotationTargets = new List<Vector3>();
    
    private static bool isAllRotating = false;

    public string animBoolName;

    private int exitCount = 100;

    private void Start()
    {
        for (int i = 0; i < rotatingObjects.Count; i++)
        {
            if (rotatingObjects[i] != null)
            {
                animators.Add(rotatingObjects[i].GetComponent<Animator>());
                isRotating.Add(false);
                rotationTargets.Add(rotationAmount[i]);
            }
        }
    }

    private void ClearAnimators()
    {
        for (int i = 0; i < tempAnimators.Count; i++)
        {
            tempAnimators.RemoveAt(i);
        }
    }

    private void RotateAll()
    {
        ClearAnimators();
        for (int i = 0; i < isRotating.Count; i++)
        {
            isRotating[i] = true;
            tempAnimators.Add(animators[i]);
        }
    }

    private bool CheckAllNotRotating()
    {
        bool allNotRotating = true;
        for (int i = 0; i < isRotating.Count; i++)
        {
            if (isRotating[i])
            {
                allNotRotating = false;
                break;
            }
        }
        return allNotRotating;
    }

    private void UpdateRotationAmount()
    {
        for (int i = 0; i < rotationTargets.Count; i++)
        {
            rotationTargets[i] += rotationAmount[i];
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isAllRotating) // Temporary Interaction system just to make sure it works
        {
            RotateAll();
        }
        while (!CheckAllNotRotating() || exitCount != 0)
        {
            for (int i = 0; i < isRotating.Count; i++)
            {
                if (isRotating[i])
                {
                    tempAnimators[i].SetBool(animBoolName, true);
                }
                else
                {
                    tempAnimators[i].SetBool(animBoolName, false);

                }
                if (rotatingObjects[i].transform.rotation == Quaternion.Euler(rotationTargets[i]))
                {
                    isRotating[i] = false;
                }
            }
            exitCount--;
        }
        exitCount = 100;
        UpdateRotationAmount();
    }
}
