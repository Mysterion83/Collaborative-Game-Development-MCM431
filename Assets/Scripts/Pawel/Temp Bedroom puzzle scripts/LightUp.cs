using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUp : MonoBehaviour
{
    [SerializeField]
    public GameObject plate,lightsource;
    void Update()
    {
        if ((plate.GetComponent<Switches>().switchON))
        {
            lightsource.SetActive(true);
        }
        else
        {
            lightsource.SetActive(false);
        }
    }
}
