using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHasWineBottle : MonoBehaviour
{
    public bool hasWineBottle = false;

    private void FixedUpdate()
    {
        if (transform.GetChild(0) != null)
        {
            if (transform.GetChild(0).name.Substring(0, 10) == "WineBottle")
            {
                hasWineBottle = true;
            }
        }
        else
        {
            hasWineBottle = false;
        }
        
    }
}
