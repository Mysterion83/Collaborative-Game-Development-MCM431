using UnityEngine;

public class InteractableLockedButton : InteractableButton
{
    [SerializeField]
    private int _requiredItemID;
    [SerializeField]
    private bool _DoesRemoveItem;

    InventoryManager _playerInventory;

    private void Start()
    {
        _playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<InventoryManager>();
        if (_playerInventory == null) Debug.LogError("Interactable Locked Button: Inventory Manager not found");
    }

    public override void Interact()
    {
        if (!_playerInventory.HasItem(_requiredItemID))
        {
            return;
        }
        if (_DoesRemoveItem)
        {
            _playerInventory.RemoveTargetItem(_requiredItemID);
        }
        base.Interact();
    }
}
