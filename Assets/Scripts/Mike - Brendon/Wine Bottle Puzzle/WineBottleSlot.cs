using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WineBottleSlot : Interactable
{
    public GameObject[] wineBottles;
    public GameObject specialWineBottle;

    public Vector3 placementOffset;
    public Vector3 rotationOffset;

    public bool isAgingWine;
    public bool isAgingWineActive = false;
    public bool isBroken = false;

    private bool _canUpdateWineBottle = false;

    public int minWineBottleID;
    public int maxWineBottleID;
    public int specialWineBottleID;

    public Collider _slotCollider;
    public InteractableItem wineBottleScript;

    public string pickupTooltip;
    public string specialPickupTooltip;
    public string agedPickupTooltip;
    public string placeTooltip;
    private void Place()
    {
        GameObject placedWineBottle = null;

        //Checking for IDs between 6 and 9 for normal wine bottles
        if (InventoryManager.Instance.currentSelectedItemID >= minWineBottleID && InventoryManager.Instance.currentSelectedItemID <= maxWineBottleID)
        {
            placedWineBottle = Instantiate(wineBottles[InventoryManager.Instance.currentSelectedItemID - minWineBottleID], transform);
        }
        else if (InventoryManager.Instance.currentSelectedItemID == specialWineBottleID)
        {
            placedWineBottle = Instantiate(specialWineBottle, transform);
        }

        placedWineBottle.transform.position = transform.position + placementOffset;
        placedWineBottle.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x + rotationOffset.x, transform.rotation.y + rotationOffset.y, transform.rotation.z + rotationOffset.z));

        wineBottleScript = placedWineBottle.GetComponent<InteractableItem>();

        if(transform.GetChild((isAgingWine ? 1 : 0)).name.Substring(0, 7) == "Special")
        {
            TooltipText = specialPickupTooltip;
        }
        else
        {
            TooltipText = pickupTooltip;
        }

        InventoryManager.Instance.RemoveTargetItem(InventoryManager.Instance.currentSelectedItemID);
    }
    void Start()
    {
        _slotCollider = GetComponent<Collider>();
        

        if (transform.childCount >= 1 && transform.GetChild(0).name.Substring(0,6) == "Broken")
        {
            isBroken = true;
        }
        else
        {
            isBroken = false;
        }

        if(isBroken)
        {
            _slotCollider.enabled = false;
        }

        if (!isAgingWine && transform.childCount >= 1)
        {
            if(transform.GetChild((isAgingWine ? 1 : 0)).name.Substring(0, 7) == "Special")
            {
                TooltipText = specialPickupTooltip;
            }
            else
            {
                TooltipText = pickupTooltip;
            }

            wineBottleScript = transform.GetChild((isAgingWine ? 1 : 0)).gameObject.GetComponent<InteractableItem>();
            transform.GetChild(0).position = transform.position + placementOffset;
            transform.GetChild(0).rotation = Quaternion.Euler(new Vector3(transform.rotation.x + rotationOffset.x, transform.rotation.y + rotationOffset.y, transform.rotation.z + rotationOffset.z));
        }
    }
    public override void Interact()
    {
        // If there is a space for the bottle
        if (transform.childCount == (isAgingWine && !isAgingWineActive ? 1 : 0))
        {
            // If the player has special or normal wine bottle and if there is not a bottle on the rack, places bottle
            if ((InventoryManager.Instance.currentSelectedItemID == specialWineBottleID ^ (InventoryManager.Instance.currentSelectedItemID >= minWineBottleID && InventoryManager.Instance.currentSelectedItemID <= maxWineBottleID)) && !isAgingWineActive)
            {
                Place();
            }
        }
        else
        {
            wineBottleScript.Interact();
            TooltipText = placeTooltip;
        }
    }

    public override void ScrollInteract(float mouseScrollDelta)
    {
        return;
    }
}
