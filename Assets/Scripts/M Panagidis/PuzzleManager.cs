using System;
using Unity.VisualScripting;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    protected bool[] switches;
    protected int arraySize;
    protected bool activated;

    [SerializeField]
    protected Animator animator;
    [SerializeField]
    protected string animBoolName;

    public bool CheckSwitches()
    {
        bool SwitchOn = true;
        for (int i = 0; i < switches.Length; i++)
        {
            if (!switches[i])
            {
                SwitchOn = false; 
                break;
            }
        }
        return SwitchOn;
    }

    public int AddSwitch()
    {
        arraySize++;
        Array.Resize(ref switches, arraySize);
        return arraySize - 1;
    }

    public void SetState(int index, bool state)
    {
        switches[index] = state;
    }

    public void PlayAnimation()
    {
        if (activated)
        {
            animator.SetBool(animBoolName, true);
        }
        else
        {
            animator.SetBool(animBoolName, false);
        }
    }
}
