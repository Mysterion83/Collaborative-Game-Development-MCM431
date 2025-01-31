using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    GameObject Inventory;
    bool inventoryOpen = true;
    
    public ItemSlot[] itemSlot;

    void Start()
    {
        Inventory = GameObject.FindGameObjectWithTag("Inventory");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Add an item
            throw new NotImplementedException();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!inventoryOpen)
            {
                inventoryOpen = true;
                Inventory.SetActive(true);
            }
            else if (inventoryOpen)
            {
                inventoryOpen = false;
                Inventory.SetActive(false);
            }
        }
    }

    // Attempts to add an item to the inventory by looping through each slot //
    // If the slot is empty, it will add the item to the nearest available slot //
    public void AddItem(string itemName, string itemDescription, Sprite itemSprite)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (!itemSlot[i].slotHasItem)
            {
                itemSlot[i].AddItem(itemName, itemDescription, itemSprite);
                return;
            }
        }
    }

    // Called when an item is selected within the inventory // 
    // Any currently not selected item will be deselected 1 by 1 //
    public void DeselectAllItemSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++) 
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
    }
}
