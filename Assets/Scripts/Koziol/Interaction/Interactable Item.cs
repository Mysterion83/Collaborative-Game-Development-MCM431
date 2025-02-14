using UnityEngine;

public class InteractableItem : Interactable
{
    [SerializeField]
    private ItemSO Item;

    private InventoryManager _playerInventory;

    public void Start()
    {
        _playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryManager>();
        if (_playerInventory == null) Debug.LogError("Interactable Item: Inventory Manager not found");
    }
    public override void Interact()
    {
        _playerInventory.AddItem(Item);
        Destroy(gameObject);
    }

    public override void ScrollInteract(float mouseScrollDelta)
    {
        return;
    }
}
