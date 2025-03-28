using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHasWineBottle : MonoBehaviour
{
    public bool hasWineBottle = false;
    public bool hasDestroyedAgedWine = false;

    void FixedUpdate()
    {
        if (transform.childCount > 0)
        {
            if (transform.GetChild(0).name.Substring(0, 17) == "SpecialWineBottle")
            {
                hasWineBottle = true;
            }
        }
        else
        {
            hasWineBottle = false;
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
