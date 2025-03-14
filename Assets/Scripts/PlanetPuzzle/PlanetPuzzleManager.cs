using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetPuzzleManager : Interactable
{
    [Header("Planet Data")]
    [SerializeField] private GameObject[] planets; 

    [Header("Rotation Parameters")]
    [SerializeField] private GameObject RotationPoint;
    [SerializeField] private int targetPointRotation;
    [SerializeField] private int pointRotationSpeed;
    [SerializeField] private float rotationAmount;
    [SerializeField] private float[] rotationSpeeds;

    [Header("Items")]
    [SerializeField] private GameObject key;

    public bool isSolved {get {return _isSolved;}}
    private bool _isSolved;
    private bool canRotate = false;

    public override void Interact()
    {
        if (planets.Length == 0) Debug.LogWarning("Interactable Button: Button Does not have any planet interactables to interact with", gameObject);
        canRotate = true;
    }

    public override void ScrollInteract(float mouseScrollDelta)
    {
        return;
    }

    private void Start()
    {
        key.SetActive(false);
    }

    private void Update()
    {
        CheckSolved();

        if (Input.GetKey(KeyCode.E) && canRotate)
        {
            RotatePlanets();

            if (Input.GetKeyUp(KeyCode.E))
            {
                canRotate = false;
            }
        }
    }

    private void CheckSolved()
    {
        if (_isSolved)
        {
            key.SetActive(true);
            enabled = false;
        }
    }

    private void RotatePlanets()
    {
        if (RotationPoint.transform.eulerAngles.y >= targetPointRotation)
        {
            _isSolved = true;
            canRotate = false;
            return;
        }
        else
        {
            RotationPoint.transform.Rotate(new Vector3(0, rotationAmount, 0), pointRotationSpeed * Time.deltaTime);

            planets[0].transform.RotateAround(RotationPoint.transform.position, new Vector3(0, rotationAmount, 0), rotationSpeeds[0] * Time.deltaTime);
            planets[1].transform.RotateAround(RotationPoint.transform.position, new Vector3(0, rotationAmount, 0), rotationSpeeds[1] * Time.deltaTime);
            planets[2].transform.RotateAround(RotationPoint.transform.position, new Vector3(0, rotationAmount, 0), rotationSpeeds[2] * Time.deltaTime);
            planets[3].transform.RotateAround(RotationPoint.transform.position, new Vector3(0, rotationAmount, 0), rotationSpeeds[3] * Time.deltaTime);
        }
    }
}
