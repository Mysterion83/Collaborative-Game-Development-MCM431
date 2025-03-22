using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WineBottlePlacement : Interactable
{
    public GameObject wineBottle;
    public GameObject specialWineBottle;
    public Vector3 placementOffset;
    public bool isAgingWine;
    public bool isAgingWineActive = false;

    private void Place()
    {
        InventoryManager.Instance.RemoveTargetItem(InventoryManager.Instance.currentSelectedItemID);
        GameObject placedWineBottle = null;

        if (InventoryManager.Instance.currentSelectedItemID == 4)
        {
            placedWineBottle = Instantiate(wineBottle, transform);
        }
        else if (InventoryManager.Instance.currentSelectedItemID == 5)
        {
            placedWineBottle = Instantiate(specialWineBottle, transform);
        }

        placedWineBottle.transform.position = transform.position + placementOffset;
    }

    public override void Interact()
    {
        if ((InventoryManager.Instance.currentSelectedItemID == 4 || InventoryManager.Instance.currentSelectedItemID == 5) && transform.childCount == (isAgingWine? 1 : 0) && !isAgingWineActive) 
        {
            Place();
        }
    }

    public override void ScrollInteract(float mouseScrollDelta)
    {
        return;
    }
}
