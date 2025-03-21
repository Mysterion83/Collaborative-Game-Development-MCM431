using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WineBottlePlacement : Interactable
{
    public GameObject wineBottle;
    public Vector3 placementOffset;

    private void Place()
    {
        InventoryManager.Instance.RemoveTargetItem(4);
        GameObject placedWineBottle = Instantiate(wineBottle, transform);
        placedWineBottle.transform.position = transform.position + placementOffset;
    }

    public override void Interact()
    {
        if (InventoryManager.Instance.currentSelectedItemID == 4)
        {
            Place();
        }
    }

    public override void ScrollInteract(float mouseScrollDelta)
    {
        return;
    }
}
