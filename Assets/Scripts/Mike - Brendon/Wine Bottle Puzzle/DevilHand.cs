using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilHand : Interactable
{
    public GameObject agedWine;
    public GameObject key;

    public Vector3 agedWinePlacementOffset;
    public Vector3 agedWineRotationOffset;
    public Vector3 keyPlacementOffset;
    public Vector3 keyRotationOffset;

    private Animator _devilHandAnimator;

    private string _agedWineTooltip;
    private bool _solved = false;
    private void Place()
    {
        GameObject placedWineBottle = null;

        placedWineBottle = Instantiate(agedWine, transform);

        placedWineBottle.transform.position = transform.position + agedWinePlacementOffset;
        placedWineBottle.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x + agedWineRotationOffset.x, transform.rotation.y + agedWineRotationOffset.y, transform.rotation.z + agedWineRotationOffset.z));
        placedWineBottle.transform.localScale = new Vector3(1f / 7f, 1f / 7f, 1f / 7f);
        placedWineBottle.GetComponent<Collider>().enabled = false;

        InventoryManager.Instance.RemoveTargetItem(InventoryManager.Instance.currentSelectedItemID);
    }
    void Start()
    {
        _agedWineTooltip = TooltipText;
        _devilHandAnimator = GetComponent<Animator>();
    }
    void Update()
    {
        //updates the tooltip depending on if the player has the special wine bottle or not
        if(InventoryManager.Instance.currentSelectedItemID != 0 && !_solved)
        {
            TooltipText = "Missing Item";
        }
        else if(InventoryManager.Instance.currentSelectedItemID == 0)
        {
            TooltipText = _agedWineTooltip;
        }
        else
        {
            TooltipText = "";
        }
    }

    //During the animation that plays when the puzzle is solved,
    //changes the wine bottle in the hand to a key for the player to pick up
    public void ChangeToKey()
    {
        Destroy(transform.GetChild(0).gameObject);

        GameObject newKey = Instantiate(key, transform);

        newKey.transform.position = transform.position + keyPlacementOffset;
        newKey.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x + keyRotationOffset.x, transform.rotation.y + keyRotationOffset.y, transform.rotation.z + keyRotationOffset.z));
        newKey.transform.localScale = new Vector3(1f / 7f, 1f / 7f, 1f / 7f);
    }
    public override void Interact()
    {
        if(InventoryManager.Instance.currentSelectedItemID == 0)
        {
            Place();
            _solved = true;

            _devilHandAnimator.SetBool("Solved", _solved);
        }
    }
    public override void ScrollInteract(float mouseScrollDelta)
    {
        return;
    }
}
