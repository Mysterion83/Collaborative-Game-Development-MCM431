using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCisternPuzzle : Interactable
{
    [SerializeField]
    private CisternWater[] _UnsortedWaterObjects = new CisternWater[12];

    private CisternWater[,] _WaterObjects = new CisternWater[3,4];

    [SerializeField]
    private InteractablePipeValve PipeA;
    [SerializeField]
    private InteractablePipeValve PipeB;

    private void Start()
    {
        int currentUnsortedObject = 0;
        for (int i = 0; i < _WaterObjects.GetLength(0); i++)
        {
            for (int j = 0; j < _WaterObjects.GetLength(1); j++)
            {
                _WaterObjects[i, j] = _UnsortedWaterObjects[currentUnsortedObject];
                currentUnsortedObject++;
            }
        }
    }



    public void UpdatePipeStates()
    {
        if (PipeA.State && PipeB.State)
        {
            DisableWater();
            _WaterObjects[1,0].MoveWater(true);
            _WaterObjects[1, 1].MoveWater(true);
            _WaterObjects[1, 2].MoveWater(true);
            _WaterObjects[1, 3].MoveWater(true);
        }
        else if (PipeA.State)
        {
            DisableWater();
            _WaterObjects[0, 0].MoveWater(true);
            _WaterObjects[2, 0].MoveWater(true);

            _WaterObjects[2, 1].MoveWater(true);

            _WaterObjects[0, 2].MoveWater(true);
            _WaterObjects[2, 2].MoveWater(true);

            _WaterObjects[0, 3].MoveWater(true);
            _WaterObjects[2, 3].MoveWater(true);
        }
        else if (PipeB.State)
        {
            DisableWater();
            _WaterObjects[0, 0].MoveWater(true);
            _WaterObjects[1, 0].MoveWater(true);

            _WaterObjects[1, 1].MoveWater(true);

            _WaterObjects[0, 2].MoveWater(true);
            _WaterObjects[1, 2].MoveWater(true);

            _WaterObjects[0, 3].MoveWater(true);
            _WaterObjects[1, 3].MoveWater(true);
        }
        else
        {
            DisableWater();
        }
    }
    void DisableWater()
    {
        for (int i = 0; i < _WaterObjects.GetLength(0); i++)
        {
            for (int j = 0; j < _WaterObjects.GetLength(1); j++)
            {
                _WaterObjects[i, j].MoveWater(false);
            }
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (CisternWater water in _UnsortedWaterObjects)
            {
                water.EnableWater();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (CisternWater water in _UnsortedWaterObjects)
            {
                water.DisableWater();
            }
        }
    }
}
