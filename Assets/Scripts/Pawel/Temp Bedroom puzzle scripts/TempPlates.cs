using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlates : MonoBehaviour
{
    [SerializeField]
    public GameObject ObjectOn;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PickUpAble"))
        {
            ObjectOn.SetActive(true);
        }
    }
        void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PickUpAble"))
        {
            ObjectOn.SetActive(false);
        }
    }
}
