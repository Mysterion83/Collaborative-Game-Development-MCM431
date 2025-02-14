using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private Switches switches;
    public bool buttonON = false;

    private void Start()
    {
        switches = gameObject.GetComponent<Switches>();
    }
    public void Update()
    {
        switches.switchON = buttonON;
    }
}

