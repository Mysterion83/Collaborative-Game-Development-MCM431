using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Library_Door : MonoBehaviour
{
    //public float Cooldown;
    //public bool Open = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Open()
    {
        //Debug.Log("Cheese");
        if (this.transform.eulerAngles.y != 90)
        {
            transform.Rotate(new Vector3(0, 1, 0));
            //Debug.Log(this.transform.eulerAngles.y);

            Open();
        }
    }
}

