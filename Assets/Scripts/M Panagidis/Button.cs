using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Interactable
{
    private Switches switches;
    public bool buttonON = false;

    public override void Interact()
    {
        buttonON = !buttonON;
    }

    public override void ScrollInteract(float mouseScrollDelta)
    {
        return;
    }

    private void Start()
    {
        switches = gameObject.GetComponent<Switches>();
    }

    public void Update()
    {
        switches.switchON = buttonON;
    }
}

