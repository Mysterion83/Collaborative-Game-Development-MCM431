using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Rotating_Switches : MonoBehaviour
{
    public List<GameObject> rotatingObjects = new List<GameObject>(); // Objects to rotate
    public List<Vector3> rotationAmount = new List<Vector3>(); // Rotation angles
    public List<bool> isClockwise = new List<bool>(); // Direction of rotation
    private List<Animator> animators = new List<Animator>();
    private List<Vector3> rotationTargets = new List<Vector3>();
    private List<bool> isRotating = new List<bool>(); //checks if planets are still under rotation to prevent players from spamming interact
    private List<bool> hasResetRotation = new List<bool>(); //checks if a rotation has been complete to prevent bugs
    
    private static bool isAllRotating = false;

    //animation
    public string animBoolName;
    public string animBoolClockwiseName;
    public string animFloatName;
    public string animStateName;

    private void Start()
    {
        //setting up all of the lists with initial elements
        for (int i = 0; i < rotatingObjects.Count; i++)
        {
            if (rotatingObjects[i] != null)
            {
                animators.Add(rotatingObjects[i].GetComponent<Animator>());
                rotationTargets.Add((isClockwise[i] ? rotationAmount[i] : new Vector3(0, 360 - rotationAmount[i].y, 0)));
                isRotating.Add(false);
                hasResetRotation.Add(false);
                if (isClockwise[i])
                {
                    animators[i].SetBool(animBoolClockwiseName, true);
                }
                else
                {
                    animators[i].SetBool(animBoolClockwiseName, false);
                }
            }
        }
    }

    private void RotateAll()
    {
        for (int i = 0; i < animators.Count; i++)
        {
            //activates animations
            animators[i].SetBool(animBoolName, true);
            animators[i].SetFloat(animFloatName, 1);

            isRotating[i] = true;
        }
    }

    private void resetRotateAll()
    {
        for (int i = 0; i < animators.Count; i++)
        {
            //disables animations
            animators[i].SetBool(animBoolName,false);
            isRotating[i] = false;
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
            if ((rotationTargets[i].y + rotationAmount[i].y * (isClockwise[i] ? 1 : -1)) * (isClockwise[i] ? 1 : -1) >= (isClockwise[i] ? 360 : 0))
            {
                rotationTargets[i] -= new Vector3(0, 360, 0) * (isClockwise[i] ? 1 : -1);
                hasResetRotation[i] = true;
            }
            rotationTargets[i] += rotationAmount[i] * (isClockwise[i] ? 1 : -1);
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isAllRotating) // Temporary Interaction system just to make sure it works
        {
            RotateAll();
        }

        if(!CheckAllNotRotating())
        {
            for (int i = 0; i < animators.Count; i++)
            {
                //checks if the planet is about to complete a rotation
                if (hasResetRotation[i])
                {
                    //checks if planet reaches a point past 360 degrees
                    float trueYRotation = rotatingObjects[i].transform.eulerAngles.y;
                    if(rotatingObjects[i].transform.eulerAngles.y + rotationAmount[i].y * (isClockwise[i] ? 1 : -1) >= (isClockwise[i] ? 360 : -360))
                    {
                        trueYRotation -= (isClockwise[i] ? 360 : -360);
                    }
                    if (trueYRotation * (isClockwise[i] ? 1 : -1) >= rotationTargets[i].y * (isClockwise[i] ? 1 : -1))
                    {
                        hasResetRotation[i] = false;
                        animators[i].SetFloat(animFloatName, 0);
                        animators[i].SetBool(animBoolName, false);
                        isRotating[i] = false;
                        UpdateRotationAmount();
                    }
                }
                else
                {
                    //checks if planet reaches the target point
                    if ((rotatingObjects[i].transform.eulerAngles.y + (rotatingObjects[i].transform.eulerAngles.y <= 0 && !isClockwise[i] ? 360:0)) * (isClockwise[i] ? 1 : -1) >= rotationTargets[i].y * (isClockwise[i] ? 1 : -1))
                    {
                        animators[i].SetFloat(animFloatName, 0);
                        animators[i].SetBool(animBoolName, false);
                        isRotating[i] = false;
                        UpdateRotationAmount();
                    }
                }
            }
        }
    }
}
