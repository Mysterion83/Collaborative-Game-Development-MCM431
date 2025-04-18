using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressure_Plate_Cubes : MonoBehaviour
{
    public bool plateON = false;
    public string cube_name;


    public void OnTriggerStay(Collider collider)
    {
        if ((collider.gameObject.layer == LayerMask.NameToLayer("Heavy")) && collider.gameObject.name == cube_name)
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
