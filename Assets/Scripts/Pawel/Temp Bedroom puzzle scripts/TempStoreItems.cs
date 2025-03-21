using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempStoreItems : MonoBehaviour
{
    public List<string> GotKeys;
    public void addToGot(string addKey)
    {
        GotKeys.Add(addKey);
    }

}
