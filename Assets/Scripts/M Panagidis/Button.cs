using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public bool buttonON = false;

    public void Update()
    {
        gameObject.GetComponent<Switches>().switchON = buttonON;
    }
}

