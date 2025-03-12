using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    // Class References //
    private ItemInspectPanel inspectPanel;

    // Item Data //
    public int itemID;
    public string itemName;
    public Sprite itemSprite;
    public string itemDescription;
    public bool slotHasItem;

    // Item Slot Data //
    [SerializeField] private Sprite emptySprite;
    public Image itemInspectImage;
    
    // Item Selection //
    public GameObject selectedShader;
    public bool thisItemSelected;

    private void Start()
    {
        itemInspectImage.sprite = emptySprite;
    }

    public int GetStoredItemID()
    {
        return itemID;
    }

    public void AddItem(ItemSO inItem)
    {
        itemID = inItem.GetItemID();
        itemName = inItem.GetItemName();
        itemDescription = inItem.GetItemDescription();
        itemSprite = inItem.GetItemSprite();

        slotHasItem = true;
        itemInspectImage.sprite = itemSprite;
    }

    public void RemoveItem()
    {
        itemID = -1;
        itemName = "";
        itemDescription = "";
        itemSprite = emptySprite;

        slotHasItem = false;
        itemInspectImage.sprite = emptySprite;
    }

    // Called when this specific item slot is clicked //
    // Passes the currently stored item slot data for this specific item slot to the item inspector //
    // If the slot is empty when selected, it will reset the item inspect panel //
    public void SetSlotActive()
    {
        InventoryManager.Instance.DeselectAllItemSlots();
        thisItemSelected = true;
        selectedShader.SetActive(true);
    }
}