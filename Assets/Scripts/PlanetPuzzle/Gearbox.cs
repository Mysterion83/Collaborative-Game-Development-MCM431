using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gearbox : InteractableLockedButton
{
    private int gearsCollected = 0;
    public int requiredGears = 3;
    public GameObject objectToLock;
    private bool isLocked = true;

    [SerializeField] int gear1ID;
    [SerializeField] int gear2ID;
    [SerializeField] int gear3ID;

    private void Start()
    {
        // Ensure the object is locked at the start
        LockObject();
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
            if (_requiredItemID == gear1ID || _requiredItemID == gear2ID || _requiredItemID == gear3ID)
            {
                AddGear();
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

    public void AddGear()
    {
        gearsCollected++;
        Debug.Log("Gears collected: " + gearsCollected);

        if (gearsCollected >= requiredGears && isLocked)
        {
            UnlockObject();
        }
    }

    private void UnlockObject()
    {
        // Logic to unlock the object
        if (objectToLock != null)
        {
            objectToLock.SetActive(true); // Enable the object
            Debug.Log("Object unlocked!");
        }

        // Unlock the object after activation
        isLocked = false;
    }

    public void LockObject()
    {
        // Logic to lock the object
        if (objectToLock != null)
        {
            objectToLock.SetActive(false); // Disable the object
            Debug.Log("Object is now locked.");
        }

        // Set the lock state
        isLocked = true;
    }
}
