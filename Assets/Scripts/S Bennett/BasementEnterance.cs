using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasementEnterance : InteractableLockedButton
{
    private int keysCollected = 0;
    public int requiredKeys = 2;
    //public GameObject objectToLock;
    private bool isLocked = true;

    [SerializeField] int keyID;
    [SerializeField] BasementDoor door;

    private void Start()
    {
        isLocked = true;
    }

    public override void Interact()
    {
        _requiredItemID = InventoryManager.Instance.currentSelectedItemID;

        if (!InventoryManager.Instance.HasItem(_requiredItemID))
        {
            return;
        }
        else if (InventoryManager.Instance.HasItem(_requiredItemID))
        {
            if (_requiredItemID == keyID)
            {
                AddKey();
            }
            else return;
        }
        if (_DoesRemoveItem)
        {
            InventoryManager.Instance.RemoveTargetItem(_requiredItemID);
        }
    }

    public override void ScrollInteract(float mouseScrollDelta)
    {
        return;
    }

    public void AddKey()
    {
        keysCollected++;
        Debug.Log("Keys collected: " + keysCollected);

        if (keysCollected >= requiredKeys && isLocked)
        {
            door.locked = false;
            gameObject.SetActive(false);
        }
    }
}
