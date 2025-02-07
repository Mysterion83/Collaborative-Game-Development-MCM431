using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressure_Plate : MonoBehaviour
{
    public bool plateON = false;

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

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Switches>().switchON = plateON;
    }
}
