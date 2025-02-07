using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    GameObject Inventory;
    bool inventoryOpen = true;
    
    [SerializeField] private ItemSlot[] itemSlots;

    void Start()
    {
        Inventory = GameObject.FindGameObjectWithTag("Inventory");
    }

    void Update()
    {
        HandleInventoryUI();
    }

    // Attempts to add an item to the inventory by looping through each slot //
    // If the slot is empty, it will add the item to the nearest available slot //
    public void AddItem(ItemSO inItem)
    {
        int slotFullCounter = 0;

        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (!itemSlots[i].slotHasItem)
            {
                itemSlots[i].AddItem(inItem);
                return;
            }
            else if (itemSlots[i].slotHasItem) slotFullCounter++;

            if (slotFullCounter == itemSlots.Length)
            {
                Debug.LogError("The player inventory is full and no items can be added");
            }
        }
    }

    // Removes an item from the inventory based on the item's ID //
    // Loops through the Item Slot array in reverse-order //
    public void RemoveItem(ItemSO itemToRemove)
    {
        int targetItemID = itemToRemove.GetItemID();

        for (int i = itemSlots.Length - 1; i > 0; i--)
        {
            Debug.Log("Iteration " + i);

            if (!itemSlots[i].slotHasItem) continue;

            int storedItemID = itemSlots[i].GetStoredItemID();
            Debug.Log("This Slot Contains a " + itemSlots[i].itemName);
            Debug.Log("This Item's ID is " + storedItemID);

            if (itemSlots[i].slotHasItem && targetItemID == storedItemID)
            {
                Debug.Log($"Match Found: {itemToRemove.GetItemName()} matches {itemSlots[i].itemName}, removing this item...");
                itemSlots[i].RemoveItem();
                Debug.Log("Item Removed");
            }
        }

        Debug.LogError($"Target item '{itemToRemove.GetItemName()}' does not exist within the inventory and could not be deleted");
    }

    // Called when an item is selected within the inventory // 
    // Any currently not selected item will be deselected one by one //
    public void DeselectAllItemSlots()
    {
        for (int i = 0; i < itemSlots.Length; i++) 
        {
            itemSlots[i].thisItemSelected = false;
            itemSlots[i].selectedShader.SetActive(false);
        }
    }

    // Temporary, allows the inventory to be opened and closed //
    // Call this in a UI class when implemented //
    public void HandleInventoryUI()
    {
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
}
