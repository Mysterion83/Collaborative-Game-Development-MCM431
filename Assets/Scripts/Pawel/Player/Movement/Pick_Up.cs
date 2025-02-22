using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Up : MonoBehaviour
{
    bool holdable;
    [SerializeField]
    GameObject DefaultGroup;
    [SerializeField]
    GameObject hand;
    [SerializeField]
    float starting_x;
    [SerializeField]
    float starting_y;
    [SerializeField]
    float starting_z;
    


    private HoldingCheck holdingCheck;

    void Start()
    {
        holdingCheck = GameObject.Find("Player").GetComponent<HoldingCheck>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log(holdable);
        }
        
       
        if ((Input.GetKeyDown(KeyCode.F)) && (holdable == true)) //&& (holdingCheck.Holding_Check == false))
        {
            this.transform.parent = hand.transform;
            this.transform.localEulerAngles = new Vector3(0,0,0);
            this.GetComponent<Rigidbody>().isKinematic = true;
            holdingCheck.Holding_Check = true;

        }
        if(Input.GetKeyUp(KeyCode.F))
        {
            this.transform.parent = DefaultGroup.transform;
            this.GetComponent<Rigidbody>().isKinematic = false;
            holdingCheck.Holding_Check = false;

        }
        if ((Input.GetKeyDown(KeyCode.K)) && (Input.GetKeyDown(KeyCode.L)))
        {
            this.transform.localEulerAngles = new Vector3(0,0,0);
            this.transform.position = new Vector3 (starting_x, starting_y, starting_z);
        }
        
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag =="Hands")
        {
        holdable = true;
        }
    }
    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag =="Hands")
        {
        holdable = false;
        }
    }



}
