using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateIsTeleport : MonoBehaviour
{
    //temporary script to check if player can teleport

    public InventoryManager inventoryManager;
    public LevelTeleportSystem levelTeleportSystem;

    void Update()
    {
        if (inventoryManager.HasItem(0))
        {
            levelTeleportSystem.IsAllowedToTeleport = true;
        }
        else
        {
            levelTeleportSystem.IsAllowedToTeleport = false;
        }
    }
}
