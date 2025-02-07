using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    InventoryManager inventoryManager;
    public ItemSO TestItem1;
    public ItemSO TestItem2;
    public ItemSO TestItem3;
    public ItemSO TestItem4;

    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    private void Update()
    {
        // Temporary, only here for testing purposes to see if Items can be added to the inventory //
        if (Input.GetKeyDown(KeyCode.Space))
        {
            inventoryManager.AddItem(TestItem1);
            inventoryManager.AddItem(TestItem2);
            inventoryManager.AddItem(TestItem3);
            inventoryManager.AddItem(TestItem4);
        }
        // Temporary, only here for testing purposes to see if Items can be removed from the inventory //
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            inventoryManager.RemoveItem(TestItem4);
            inventoryManager.RemoveItem(TestItem3);
            inventoryManager.RemoveItem(TestItem2);
            inventoryManager.RemoveItem(TestItem1);

        }
    }

    // Checks to see if the player collides with an item //
    // Upon colliding with the item, it will destroy it //
    public void OnTriggerEnter(Collider other)
    {
        Item item = other.GetComponent<Item>();
        if (item)
        {
            Destroy(other.gameObject);
        }
    }
}
