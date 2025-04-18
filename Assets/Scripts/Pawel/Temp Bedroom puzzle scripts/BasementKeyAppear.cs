using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempBasementKeyAppear : MonoBehaviour
{
    [SerializeField]
    public GameObject pl1,pl2,pl3;
    public GameObject key;
    void Update()
    {
        if ((pl1.GetComponent<Switches>().switchON) && (pl2.GetComponent<Switches>().switchON) && (pl3.GetComponent<Switches>().switchON))
        {
            key.SetActive(true);
        }
    }
}
