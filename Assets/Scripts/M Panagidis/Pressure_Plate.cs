using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressure_Plate : MonoBehaviour
{
    public bool plateON = false;
    private Switches switches;

    public void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Heavy"))
        {
            plateON = true;
        }
    }

    public void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Heavy"))
        {
            plateON = false;
        }
    }

    private void Start()
    {
        switches = gameObject.GetComponent<Switches>();
    }
    // Update is called once per frame
    void Update()
    {
        switches.switchON = plateON;
    }
}
