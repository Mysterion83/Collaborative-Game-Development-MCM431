using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Rotating_Switches : Interactable
{
    public GameObject[] rotatingObjects; // Objects to rotate
    public Vector3[] rotationAmount; // Rotation angles
    public bool[] isClockwise; // Direction of rotation
    private Animator[] animators;
    private Vector3[] rotationTargets;
    private bool[] isRotating; //checks if planets are still under rotation to prevent players from spamming interact
    private bool[] hasResetRotation; //checks if a rotation has been complete to prevent bugs
    
    private static bool isAllRotating = false;

    //animation
    public string animBoolName;
    public string animBoolClockwiseName;
    public string animFloatName;
    public string animStateName;

    private void Start()
    {
        //setting up all of the lists with initial elements
        for (int i = 0; i < rotatingObjects.Length; i++)
        {
            if (rotatingObjects[i] != null)
            {
                animators[i] = rotatingObjects[i].GetComponent<Animator>();
                rotationTargets[i] = (isClockwise[i] ? rotationAmount[i] : new Vector3(0, 360 - rotationAmount[i].y, 0));
                isRotating[i] = false;
                hasResetRotation[i] = false;
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
        for (int i = 0; i < animators.Length; i++)
        {
            //activates animations
            animators[i].SetBool(animBoolName, true);
            animators[i].SetFloat(animFloatName, 1);

            isRotating[i] = true;
        }
    }

    private bool CheckAllNotRotating()
    {
        bool allNotRotating = true;
        for (int i = 0; i < isRotating.Length; i++)
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
        for (int i = 0; i < rotationTargets.Length; i++)
        {
            if ((rotationTargets[i].y + rotationAmount[i].y * (isClockwise[i] ? 1 : -1)) * (isClockwise[i] ? 1 : -1) >= (isClockwise[i] ? 360 : 0))
            {
                rotationTargets[i] -= new Vector3(0, 360, 0) * (isClockwise[i] ? 1 : -1);
                hasResetRotation[i] = true;
            }
            rotationTargets[i] += rotationAmount[i] * (isClockwise[i] ? 1 : -1);
        }
    }

    public override void Interact()
    {
        if (!isAllRotating)
        {
            RotateAll();
        }
    }

    public override void ScrollInteract(float mouseScrollDelta)
    {
        return;
    }


    void Update()
    {
        if(!CheckAllNotRotating())
        {
            for (int i = 0; i < animators.Length; i++)
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
