using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public bool isCorrectRotation = false;
    public float correctRotation;
    private int index;

    [SerializeField]
    private Planet_Puzzle puzzleManager;

    void Start()
    {
        index = puzzleManager.AddSwitch();
    }
    private bool CheckRotation()
    {
        if(gameObject.transform.eulerAngles.y <= correctRotation + puzzleManager.GetErrorRange() && gameObject.transform.eulerAngles.y >= correctRotation - puzzleManager.GetErrorRange())
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
        isCorrectRotation = CheckRotation();
        puzzleManager.SetState(index, isCorrectRotation);
    }
}
