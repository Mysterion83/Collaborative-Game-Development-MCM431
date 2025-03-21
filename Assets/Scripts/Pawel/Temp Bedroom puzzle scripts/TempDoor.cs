using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempDoor : MonoBehaviour
{
    public GameObject DoorPresent, DoorPast;
    public TempStoreItems tempStore;
    [SerializeField]
    private string keyname;
    private void OnCollisionEnter(Collision collision)
    {
    
        if((collision.gameObject.tag =="Player") && (tempStore.GotKeys.Contains(keyname)) )
        {
                DoorPresent.SetActive(false);
                DoorPast.SetActive(false);
        }
    }
}
