using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPickUp : MonoBehaviour
{
    public GameObject item;
    public TempStoreItems tempStore;
    
    [SerializeField]
     private string key_name;

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(tempStore.GotKeys);
        if(collision.gameObject.tag =="Player")
        {
            Destroy(gameObject);
            tempStore.addToGot(key_name);
        }
    }
}
