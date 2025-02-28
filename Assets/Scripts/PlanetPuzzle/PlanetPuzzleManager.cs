using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetPuzzleManager : Interactable
{
    [SerializeField] private Planet[] planets; 
    public Vector3[] planetPositions;

    public bool isSolved {get {return _isSolved;}}
    private bool _isSolved;
    
    void Start()
    {
        planetPositions = new Vector3[planets.Length];
    }

    public override void Interact()
    {
        if (planets.Length == 0) Debug.LogWarning("Interactable Button: Button Does not have any planet interactables to interact with", gameObject);
        CheckPositions();
    }

    public override void ScrollInteract(float mouseScrollDelta)
    {
        return;
    }

    private void CheckPositions()
    {
        for (int i = 0; i < planetPositions.Length; i++)
        {
            planets[i].UpdatePosition();
            planetPositions[i] = planets[i].currentPosition;
        }
    }
}
