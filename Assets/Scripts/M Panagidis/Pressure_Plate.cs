using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressure_Plate : MonoBehaviour
{
    public bool plateON = false;
    private int index;

    [SerializeField]
    private PuzzleManager puzzleManager;


    public void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Heavy"))
        {
            plateON = true;
            puzzleManager.SetState(index, plateON);
        }
    }

    public void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Heavy"))
        {
            plateON = false;
            puzzleManager.SetState(index, plateON);

        }
    }

    private void Start()
    {
        index = puzzleManager.AddSwitch();
    }
}
