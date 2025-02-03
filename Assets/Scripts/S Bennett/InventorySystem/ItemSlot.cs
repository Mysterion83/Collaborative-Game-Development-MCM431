using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    // Class References //
    private InventoryManager inventoryManager;
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
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
        inspectPanel = GameObject.Find("InspectPanel").GetComponent<ItemInspectPanel>();
        itemInspectImage.sprite = emptySprite;
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

    // Checks if the mouse has clicked this particular item slot //
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
    }

    // Called when this specific item slot is clicked //
    // Passes the currently stored item slot data for this specific item slot to the item inspector //
    // If the slot is empty when selected, it will reset the item inspect panel //
    private void OnLeftClick()
    {
        inventoryManager.DeselectAllItemSlots();
        thisItemSelected = true;
        selectedShader.SetActive(true);

        if (!slotHasItem)
        {
            inspectPanel.ResetInspectPanel();
            return;
        }

        inspectPanel.UpdateInspectPanel(itemName, itemDescription, itemInspectImage);
    }
}