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

    // Item Data //
    private string itemName;
    private Sprite itemSprite;
    public bool slotHasItem;
    private string itemDescription;
    private Sprite emptySprite;

    // Item Slot Data //
    [SerializeField] private Image itemImage;

    // Item Description Data // 
    private Image itemDescriptionImage;
    private TMP_Text ItemNameText;
    private TMP_Text ItemDescriptionText;

    // Item Selection //
    public GameObject selectedShader;
    public bool thisItemSelected;

    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    public void AddItem(string itemName, string itemDescription, Sprite itemSprite)
    {
        this.itemName = itemName;
        this.itemDescription = itemDescription;
        this.itemSprite = itemSprite;

        slotHasItem = true;
        itemImage.sprite = itemSprite;
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
    // If the slot is empty when selected, it will reset the inspector to its default, empty state //
    private void OnLeftClick()
    {
        inventoryManager.DeselectAllItemSlots();
        selectedShader.SetActive(true);
        thisItemSelected = true;

        ItemNameText.text = itemName;
        ItemDescriptionText.text = itemDescription;
        itemDescriptionImage.sprite = itemSprite;

        if (itemDescriptionImage == null)
        {
            itemDescriptionImage.sprite = emptySprite;
        }
    }
}
