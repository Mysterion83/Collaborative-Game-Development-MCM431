using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory System/Add Item (Scriptable Object)")]
public class ItemSO : ScriptableObject
{
    // These details can be edited within the inspector //

    [Header("Item Details")]
    private readonly int itemID;
    [SerializeField] private Sprite itemSprite;
    [SerializeField] private string itemName;
    [TextArea(10, 15)][SerializeField] private string itemDescription;

    public int GetItemID()
    {
        return itemID;
    }
    public string GetItemName()
    {
        return itemName;
    }
    public string GetItemDescription()
    {
        return itemDescription;
    }
    public Sprite GetItemSprite()
    {
        return itemSprite;
    }
}
