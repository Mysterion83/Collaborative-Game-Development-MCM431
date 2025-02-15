using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    private Switches switches;
    public bool isCorrectRotation = false;
    public float correctRotation;

    public GameObject planetPuzzle;
    private Planet_Puzzle planetPuzzleScript;

    void Start()
    {
        switches = gameObject.GetComponent<Switches>();
        planetPuzzleScript = planetPuzzle.GetComponent<Planet_Puzzle>();
    }
    private bool checkRotation()
    {
        if(gameObject.transform.eulerAngles.y <= correctRotation + planetPuzzleScript.errorRange && gameObject.transform.eulerAngles.y >= correctRotation - planetPuzzleScript.errorRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void Update()
    {
        isCorrectRotation = checkRotation();
        switches.switchON = isCorrectRotation;
    }
}
