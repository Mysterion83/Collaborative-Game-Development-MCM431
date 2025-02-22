using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class ItemPickUp : MonoBehaviour
{
    [SerializeField] Transform holdingPosition;
    private GameObject heldObject;
    private Rigidbody heldObjectRB;

    [SerializeField] private float pickUpRange = 5.0f;
    [SerializeField] private float pickUpForce = 150.0f;
    [SerializeField] KeyCode pickUpKey = KeyCode.F;

    private void Update()
    {
        if(Input.GetKeyDown(pickUpKey))
        {
            Debug.Log(heldObject);

            if(heldObject == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
                {
                    pickup(hit.transform.gameObject);
                }
            }
            else
            {
              drop();
            }

        }
        if(heldObject != null)
        {
            moveObject();
        }
    }
    void pickup(GameObject pickObject)
    {
        if(pickObject.GetComponent<Rigidbody>())
        {
            heldObjectRB = pickObject.GetComponent<Rigidbody>();
            heldObjectRB.useGravity = false;
            heldObjectRB.drag = 5;
            heldObjectRB.constraints = RigidbodyConstraints.FreezeRotation;

            heldObjectRB.transform.parent = holdingPosition;
            heldObject = pickObject;
        }


    }

        void drop()
    {
 
        heldObjectRB.useGravity = true;
        heldObjectRB.drag = 1;
        heldObjectRB.constraints = RigidbodyConstraints.None;

        heldObjectRB.transform.parent = null;
        heldObject = null;
    }

    void moveObject()
    {
        if (Vector3.Distance(heldObject.transform.position, holdingPosition.position) > 0.1f)
        {
            Vector3 moveDir = (holdingPosition.position - heldObject.transform.position);
            heldObjectRB.AddForce(moveDir * pickUpForce);

        }
    }


}
