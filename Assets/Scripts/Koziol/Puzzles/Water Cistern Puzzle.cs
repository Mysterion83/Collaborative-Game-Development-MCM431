using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCisternPuzzle : Interactable
{
    private bool[,] WaterLevelStates = new bool[3, 4];

    private InteractablePipeValve PipeA;
    private InteractablePipeValve PipeB;






    void UpdatePipeStates()
    {
        if (PipeA.State && PipeB.State)
        {

        }
        else if (PipeA.State)
        {

        }
        else if (PipeB.State)
        {

        }
    }

    public override void Interact()
    {
        UpdatePipeStates();
    }
    public override void ScrollInteract(float mouseScrollDelta)
    {
        return;
    }

}
