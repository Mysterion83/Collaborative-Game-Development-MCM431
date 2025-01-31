using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Add Item")]
public class ItemSO : ScriptableObject
{
    [Header("Item Details")]
    private int itemID;
    [SerializeField] private string itemName;
    [TextArea] [SerializeField] private string itemDescription;
    [SerializeField] private Sprite itemSprite;
    [SerializeField] GameObject ItemModel;

    public int GetItemID()
    {
        return this.itemID;
    }
}
