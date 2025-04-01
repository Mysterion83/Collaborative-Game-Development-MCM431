using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningKitchen : Interactable
{
    [SerializeField]
    private int _litOvens = 0;
    public bool burnEstate = false;

    public override void Interact()
    {
        _litOvens++;
        if (_litOvens == 2)
        {
            burnEstate = true;
            //Play Cutscene
        }
    }

    public override void ScrollInteract(float mouseScrollDelta)
    {
        return;
    }
}
