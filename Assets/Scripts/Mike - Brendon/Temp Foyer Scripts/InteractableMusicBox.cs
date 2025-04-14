using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableMusicBox : Interactable
{
    [SerializeField]
    private LevelTeleportSystem _levelTeleportSystem;
    public GameObject musicBoxUI; 

    public override void Interact()
    {
        _levelTeleportSystem.IsAllowedToTeleport = true;
        musicBoxUI.SetActive(true);
        Destroy(gameObject);
    }

    public override void ScrollInteract(float mouseScrollDelta)
    {
        return;
    }
}
