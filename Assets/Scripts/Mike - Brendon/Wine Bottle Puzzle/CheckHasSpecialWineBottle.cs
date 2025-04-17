using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHasSpecialWineBottle : MonoBehaviour
{
    public bool hasSpecialWineBottle = false;
    public bool hasDestroyedAgedWine = false;

    void FixedUpdate()
    {
        // Checking if the current bottle is the special wine bottle
        if (transform.childCount > 0)
        {
            if (transform.GetChild(0).name.Substring(0, 7) == "Special")
            {
                hasSpecialWineBottle = true;
            }
        }
        else
        {
            hasSpecialWineBottle = false;
        }
    }

    public void DestroyWineBottle()
    {
        if (transform.childCount > 0)
        {
            Destroy(transform.GetChild(0).gameObject);
            hasDestroyedAgedWine = true;
        }
    }
}
