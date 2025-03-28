using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableMusicBox : Interactable
{
    [SerializeField]
    private LevelTeleportSystem _levelTeleportSystem;

    public override void Interact()
    {
        _levelTeleportSystem.IsAllowedToTeleport = true;
        Destroy(gameObject);
    }

    public override void ScrollInteract(float mouseScrollDelta)
    {
        return;
    }
}
