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

    public bool hasWineBottle = false;
    public bool hasSpecialWineBottle = false;
    private bool _canUpdateWineBottle = false;

    public int minWineBottleID;
    public int maxWineBottleID;
    public int specialWineBottleID;

    public Collider _slotCollider;
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
            hasSpecialWineBottle = true;
        }

        placedWineBottle.transform.position = transform.position + placementOffset;
        placedWineBottle.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x + rotationOffset.x, transform.rotation.y + rotationOffset.y, transform.rotation.z + rotationOffset.z));

        hasWineBottle = true;

        InventoryManager.Instance.RemoveTargetItem(InventoryManager.Instance.currentSelectedItemID);
    }

    //Gets the next wine bottle ID that is to be placed
    //Overcomes the problem where multiple items are deleted after using RemoveTargetItem()
    private GameObject GetNewWineBottleID()
    {
        for(int i = 0; i < wineBottles.Length; i++)
        {
            if(!InventoryManager.Instance.HasItem(i + minWineBottleID))
            {
                return wineBottles[i];
            }
        }

        return null;
    }

    //Updates the wine bottle held within the slot to a new wine bottle of the next wine bottle ID
    private void UpdateWineBottleIDs(GameObject newWineBottle)
    {
        if(newWineBottle != null)
        {
            Destroy(transform.GetChild((isAgingWine ? 1 : 0)).gameObject);
            GameObject wineBottle = Instantiate(newWineBottle, transform);

            wineBottle.transform.position = transform.position + placementOffset;
            wineBottle.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x + rotationOffset.x, transform.rotation.y + rotationOffset.y, transform.rotation.z + rotationOffset.z));
        }
    }
    void Start()
    {
        _slotCollider = GetComponent<Collider>();

        if(transform.childCount >= 1 && transform.GetChild(0).name.Substring(0,6) == "Broken")
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

        if ((!hasWineBottle || !hasSpecialWineBottle) && !isAgingWine && transform.childCount >= 1)
        {
            hasWineBottle = true;
            if (transform.GetChild(0).name.Substring(0, 7) == "Special")
            { 
                hasSpecialWineBottle = true;
            }
            transform.GetChild(0).position = transform.position + placementOffset;
            transform.GetChild(0).rotation = Quaternion.Euler(new Vector3(transform.rotation.x + rotationOffset.x, transform.rotation.y + rotationOffset.y, transform.rotation.z + rotationOffset.z));
        }
    }
    void FixedUpdate()
    {
        //Determines whether the wine bottle should be updated to the next ID when the player picks up/places a wine bottle
        if (!isBroken)
        {
            if (hasWineBottle)
            {
                if (transform.childCount == (isAgingWine ? 1 : 0))
                {
                    _canUpdateWineBottle = false;
                    hasWineBottle = false;
                    hasSpecialWineBottle = false;
                }
                else
                {
                    _canUpdateWineBottle = true;
                }
            }
            else
            {
                _canUpdateWineBottle = false;
            }

            if (!_canUpdateWineBottle)
            {
                _slotCollider.enabled = true;
            }
            else
            {
                _slotCollider.enabled = false;

                if (!hasSpecialWineBottle && !isAgingWine)
                {
                    UpdateWineBottleIDs(GetNewWineBottleID());
                }
            }
        }
    }
    public override void Interact()
    {
        // If the player has special or normal wine bottle and if there is not a bottle on the rack, places bottle
        if ((InventoryManager.Instance.currentSelectedItemID == specialWineBottleID || (InventoryManager.Instance.currentSelectedItemID >= minWineBottleID && InventoryManager.Instance.currentSelectedItemID <= maxWineBottleID)) && transform.childCount == (isAgingWine? 1 : 0) && !isAgingWineActive) 
        {
            Place();
        }
    }

    public override void ScrollInteract(float mouseScrollDelta)
    {
        return;
    }
}
