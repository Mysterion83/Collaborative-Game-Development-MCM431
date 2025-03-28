using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    public void PickUp()
    {
        Destroy(gameObject);
    }
}
