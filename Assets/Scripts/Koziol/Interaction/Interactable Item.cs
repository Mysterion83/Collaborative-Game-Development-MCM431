using UnityEngine;

public class InteractableItem : Interactable
{
    [SerializeField]
    private int _itemID;

    private InventoryManager _playerInventory;

    public void Start()
    {
        if (InventoryManager.Instance == null) Debug.LogError("Interactable _item: Inventory Manager not found");
    }
    public override void Interact()
    {
        InventoryManager.Instance.AddItem(_itemID);
        Destroy(gameObject);
    }

    public override void ScrollInteract(float mouseScrollDelta)
    {
        return;
    }
}