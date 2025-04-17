using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class OpenDoor : Interactable
{
    private Animator _hinge;
    public bool locked = false;
    private string _unlockedText;
    void Start()
    {
        _hinge = transform.parent.parent.gameObject.GetComponent<Animator>();
        _unlockedText = TooltipText;
    }
    void Update()
    {
        if(locked)
        {
            TooltipText = "Locked";
        }
        else if(InventoryManager.Instance.currentSelectedItemID == 13) //wine cellar key
        {
            TooltipText = "Unlock door with Wine Cellar Key";
        }
        else
        {
            TooltipText = _unlockedText;
        }
    }
    public override void Interact()
    {
        if(locked)
        {
            if(InventoryManager.Instance.currentSelectedItemID == 13)
            {
                locked = false;
                InventoryManager.Instance.RemoveTargetItem(InventoryManager.Instance.currentSelectedItemID);
            }
        }
        else
        {
            _hinge.SetBool("isOpen", !_hinge.GetBool("isOpen"));
        }
    }
    public override void ScrollInteract(float mouseScrollDelta)
    {
        return;
    }
}
