using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemInspectPanel : MonoBehaviour
{
    // Item Description Data // 
    [SerializeField] private Image itemImage;
    [SerializeField] private TMP_Text ItemNameText;
    [SerializeField] private TMP_Text ItemDescriptionText;
    [SerializeField] private Sprite emptySprite;

    // Displays item data passed in from a selected ItemSlot //
    public void UpdateInspectPanel(string inItemName, string inItemDescription, Image inItemImage)
    {
        ItemNameText.text = inItemName;
        ItemDescriptionText.text = inItemDescription;
        itemImage.sprite = inItemImage.sprite;
    }

    // Resets the item description panel to its default, empty state //
    public void ResetInspectPanel()
    {
        ItemNameText.text = "";
        ItemDescriptionText.text = "";
        itemImage.sprite = emptySprite;
    }
}
