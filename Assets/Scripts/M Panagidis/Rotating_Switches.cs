using System;
using Unity.VisualScripting;
using UnityEngine;

public class Rotating_Switches : Interactable
{
    public GameObject[] rotatingObjects = new GameObject[99]; // Objects to rotate
    public Vector3[] rotationAmount = new Vector3[99]; // Rotation angles
    public bool[] isClockwise = new bool[99]; // Direction of rotation
    private Animator[] _animators = new Animator[99];
    private Vector3[] _rotationTargets = new Vector3[99];
    private bool[] _isRotating = new bool[99]; //checks if planets are still under rotation to prevent players from spamming interact
    private bool[] _hasResetRotation = new bool[99]; //checks if a rotation has been complete to prevent bugs
    
    private static bool _isAllRotating = false;

    //animation
    public string animBoolName;
    public string animBoolClockwiseName;
    public string animFloatName;
    public string animStateName;

    private void Start()
    {
        CheckArraySize();
        //setting up all of the lists with initial elements
        for (int i = 0; i < rotatingObjects.Length; i++)
        {
            if (rotatingObjects[i] != null)
            {
                _animators[i] = rotatingObjects[i].GetComponent<Animator>();
                _rotationTargets[i] = (isClockwise[i] ? rotationAmount[i] : new Vector3(0, 360 - rotationAmount[i].y, 0));
                _isRotating[i] = false;
                _hasResetRotation[i] = false;
                if (isClockwise[i])
                {
                    _animators[i].SetBool(animBoolClockwiseName, true);
                }
                else
                {
                    _animators[i].SetBool(animBoolClockwiseName, false);
                }
            }
        }
    }

    private void CheckArraySize()
    {
        int count = 0;
        for (int i = 0; i < rotatingObjects.Length; i++)
        {
            if (rotatingObjects[i] != null)
            {
                count++;
            }
            else
                break;
        }
        Array.Resize(ref rotatingObjects, count);
        Array.Resize(ref rotationAmount, count);
        Array.Resize(ref isClockwise, count);
        Array.Resize(ref _animators, count);
        Array.Resize(ref _rotationTargets, count);
        Array.Resize(ref _isRotating, count);
        Array.Resize(ref _hasResetRotation, count);

    }

    private void RotateAll()
    {
        for (int i = 0; i < _animators.Length; i++)
        {
            //activates animations
            _animators[i].SetBool(animBoolName, true);
            _animators[i].SetFloat(animFloatName, 1);

            _isRotating[i] = true;
        }
    }

    private bool CheckAllNotRotating()
    {
        bool allNotRotating = true;
        for (int i = 0; i < _isRotating.Length; i++)
        {
            if (_isRotating[i])
            {
                allNotRotating = false;
                break;
            }
        }
        return allNotRotating;
    }

    private void UpdateRotationAmount()
    {
        for (int i = 0; i < _rotationTargets.Length; i++)
        {
            if ((_rotationTargets[i].y + rotationAmount[i].y * (isClockwise[i] ? 1 : -1)) * (isClockwise[i] ? 1 : -1) >= (isClockwise[i] ? 360 : 0))
            {
                _rotationTargets[i] -= new Vector3(0, 360, 0) * (isClockwise[i] ? 1 : -1);
                _hasResetRotation[i] = true;
            }
            _rotationTargets[i] += rotationAmount[i] * (isClockwise[i] ? 1 : -1);
        }
    }

    public override void Interact()
    {
        if (!_isAllRotating)
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
            for (int i = 0; i < _animators.Length; i++)
            {
                //checks if the planet is about to complete a rotation
                if (_hasResetRotation[i])
                {
                    //checks if planet reaches a point past 360 degrees
                    float trueYRotation = rotatingObjects[i].transform.eulerAngles.y;
                    if(rotatingObjects[i].transform.eulerAngles.y + rotationAmount[i].y * (isClockwise[i] ? 1 : -1) >= (isClockwise[i] ? 360 : -360))
                    {
                        trueYRotation -= (isClockwise[i] ? 360 : -360);
                    }
                    if (trueYRotation * (isClockwise[i] ? 1 : -1) >= _rotationTargets[i].y * (isClockwise[i] ? 1 : -1))
                    {
                        _hasResetRotation[i] = false;
                        _animators[i].SetFloat(animFloatName, 0);
                        _animators[i].SetBool(animBoolName, false);
                        _isRotating[i] = false;
                        UpdateRotationAmount();
                    }
                }
                else
                {
                    //checks if planet reaches the target point
                    if ((rotatingObjects[i].transform.eulerAngles.y + (rotatingObjects[i].transform.eulerAngles.y <= 0 && !isClockwise[i] ? 360:0)) * (isClockwise[i] ? 1 : -1) >= _rotationTargets[i].y * (isClockwise[i] ? 1 : -1))
                    {
                        _animators[i].SetFloat(animFloatName, 0);
                        _animators[i].SetBool(animBoolName, false);
                        _isRotating[i] = false;
                        UpdateRotationAmount();
                    }
                }
            }
        }
    }
}
