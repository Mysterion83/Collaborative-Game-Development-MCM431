using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionStop : MonoBehaviour
{
    private Rigidbody rb;
      void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Debug.Log("hmm");
            rb.velocity = Vector3.zero;
        }
    }
}
