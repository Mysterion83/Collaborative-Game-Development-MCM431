using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    GameObject Inventory;
    bool inventoryOpen = true;
    private int currentSlotSelected = 0;

    [SerializeField] private ItemSlot[] itemSlots;
    private ItemSO[] items;

    public int currentSelectedItemID;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Inventory = GameObject.FindGameObjectWithTag("Inventory");
        itemSlots[0].SetSlotActive();

        AssignItemIDs();
    }

    void Update()
    {
        HandleInventoryUI();
        CycleItemSlots();
    }

    public ItemSO GetItemSO(int targetItemID)
    {
        for (int i = 0; i < items.Length; i++)
        {
            ItemSO currentItem = items[i];

            if (currentItem.GetItemID() == targetItemID) return currentItem;
        }

        return null;
    }

    // Loads all resources in alphabetical order and assigns their ID based on its array position, from 0
    private void AssignItemIDs()
    {
        Object[] itemObjects = Resources.LoadAll("Items");
        items = new ItemSO[itemObjects.Length];

        itemObjects.CopyTo(items, 0);

        for (int i = 0; i < items.Length; i++)
        {
            items[i].SetItemID(i);
        }
    }

    // Checks if the inventory has a specific item based on its ID
    public bool HasItem(int targetItemID)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            int storedItemID = itemSlots[i].GetStoredItemID();

            if (itemSlots[i].slotHasItem && targetItemID == storedItemID)
            {
                return true;
            }
        }
        return false;
    }

    // Attempts to add an item to the inventory by looping through each slot //
    // If the slot is empty, it will add the item to the nearest available slot //
    public void AddItem(int targetItemID)
    {
        int slotFullCounter = 0;

        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (!itemSlots[i].slotHasItem)
            {
                ItemSO itemToAdd = GetItemSO(targetItemID);
                itemSlots[i].AddItem(itemToAdd);
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
    // Checks if an item was not removed and returns an error if this case is met //
    public void RemoveTargetItem(int targetItemID)
    {
        bool targetItemDeleted = false;
        ItemSO itemToRemove = GetItemSO(targetItemID);

        for (int i = itemSlots.Length - 1; i >= 0; i--)
        {
            int storedItemID = itemSlots[i].GetStoredItemID();

            if (itemSlots[i].slotHasItem && targetItemID == storedItemID)
            {
                itemSlots[i].RemoveItem();
                targetItemDeleted = true;
            }

            if (targetItemDeleted == false && i == 0)
            {
               Debug.LogError($"Target item '{itemToRemove.GetItemName()}' does not exist within the inventory and could not be deleted");
               break;
            }
        }
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

    private void CycleItemSlots()
    {
        ScrollWheelInputs();
        NumKeyInputs();

        DeselectAllItemSlots();
        itemSlots[currentSlotSelected].SetSlotActive();
        currentSelectedItemID = itemSlots[currentSlotSelected].GetStoredItemID();
    }

    private void ScrollWheelInputs()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            currentSlotSelected++;

            if (currentSlotSelected > itemSlots.Length - 1)
            {
                currentSlotSelected = 0;
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            currentSlotSelected--;

            if (currentSlotSelected < 0)
            {
                currentSlotSelected = itemSlots.Length - 1;
            }
        }
    }

    private void NumKeyInputs()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentSlotSelected = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentSlotSelected = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentSlotSelected = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentSlotSelected = 3;
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
