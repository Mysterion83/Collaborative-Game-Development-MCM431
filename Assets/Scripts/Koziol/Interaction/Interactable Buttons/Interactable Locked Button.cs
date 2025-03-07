using UnityEngine;

public class InteractableLockedButton : InteractableButton
{
    [SerializeField]
    protected int _requiredItemID;
    [SerializeField]
    protected bool _DoesRemoveItem;

    private void Start()
    {
        if (InventoryManager.Instance == null) Debug.LogError("Interactable Locked Button: Inventory Manager not found");
    }

    public override void Interact()
    {
        if (!InventoryManager.Instance.HasItem(_requiredItemID))
        {
            return;
        }
        if (_DoesRemoveItem)
        {
            InventoryManager.Instance.RemoveTargetItem(_requiredItemID);
        }
        base.Interact();
    }
}
