using UnityEngine;

public class InteractableItem : Interactable
{
    [SerializeField]
    private int _itemID;

    private InventoryManager _playerInventory;

    public void Start()
    {
        _playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryManager>();
        if (_playerInventory == null) Debug.LogError("Interactable _item: Inventory Manager not found");
    }
    public override void Interact()
    {
        _playerInventory.AddItem(_itemID);
        Destroy(gameObject);
    }

    public override void ScrollInteract(float mouseScrollDelta)
    {
        return;
    }
}
