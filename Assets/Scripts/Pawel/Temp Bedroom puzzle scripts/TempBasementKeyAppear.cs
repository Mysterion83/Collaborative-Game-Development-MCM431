using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempBasementKeyAppear : MonoBehaviour
{
    [SerializeField]
    public GameObject ba,se,me,nt;
    public GameObject key;
    void Update()
    {
        if ((ba.GetComponent<Switches>().switchON) && (se.GetComponent<Switches>().switchON) && (me.GetComponent<Switches>().switchON) && (nt.GetComponent<Switches>().switchON))
        {
            key.SetActive(true);
        }
    }
}
