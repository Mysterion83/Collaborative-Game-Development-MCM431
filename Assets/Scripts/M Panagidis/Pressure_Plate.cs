using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressure_Plate : MonoBehaviour
{
    public bool plateON = false;
    private int _index;

    [SerializeField]
    private PuzzleManager _puzzleManager;


    public void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Heavy"))
        {
            plateON = true;
            _puzzleManager.SetState(_index, plateON);
        }
    }

    public void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Heavy"))
        {
            plateON = false;
            _puzzleManager.SetState(_index, plateON);

        }
    }

    private void Start()
    {
        _index = _puzzleManager.AddSwitch();
    }
}
