using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public bool isCorrectRotation = false;
    public float correctRotation;
    private int _index;

    [SerializeField]
    private Planet_Puzzle _puzzleManager;

    void Start()
    {
        _index = _puzzleManager.AddSwitch();
    }
    private bool CheckRotation()
    {
        if(gameObject.transform.eulerAngles.y <= correctRotation + _puzzleManager.GetErrorRange() && gameObject.transform.eulerAngles.y >= correctRotation - _puzzleManager.GetErrorRange())
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
        _puzzleManager.SetState(_index, isCorrectRotation);
    }
}
