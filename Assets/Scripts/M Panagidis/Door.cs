using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public List<GameObject> switches = new List<GameObject>();

    private bool activated = false;

    public Vector3 targetRotation = new Vector3(0, 80, 0);
    public Vector3 defaultRotation = new Vector3(0, 0, 0);
    public float rotationSpeed = 1;

    public bool CheckSwitches()
    {
        bool SwitchOn = true;
        for (int i = 0; i < switches.Count; i++)
        {
            if (switches[i] != null)
            {
                if (!switches[i].GetComponent<Switches>().switchON)
                {
                    SwitchOn = false;
                    break;
                }
            }
        }
        return SwitchOn;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        activated = CheckSwitches();
        if (activated)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetRotation), Time.deltaTime * rotationSpeed); 
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(defaultRotation), Time.deltaTime * rotationSpeed);

        }
    }
}
