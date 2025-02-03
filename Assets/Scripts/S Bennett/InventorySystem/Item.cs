using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Attach this script to an item and attach its corresponding scriptable object //

    // Links the item with its scriptable object so upon interaction, //
    // the item data is transferred to the inventory slot via the items ID //
    // as long as there is an available item slot //

    public ItemSO item;
}
