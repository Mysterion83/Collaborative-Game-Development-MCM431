using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempOnText : MonoBehaviour
{
    [SerializeField]
    public GameObject letters;


    void Update()
    {
        letters.SetActive(gameObject.GetComponent<Switches>().switchON);
    }
}
