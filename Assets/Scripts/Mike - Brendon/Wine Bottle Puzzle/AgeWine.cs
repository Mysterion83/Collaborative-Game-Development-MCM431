using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgeWine : MonoBehaviour
{
    public GameObject pastWineSlot; 
    private CheckHasSpecialWineBottle _checkHasWineBottle;
    private GameObject _agedWineBottle;
    private WineBottleSlot _wineBottleSlot;

    private void Start()
    {
        _agedWineBottle = transform.GetChild(0).gameObject;
        _checkHasWineBottle = pastWineSlot.GetComponent<CheckHasSpecialWineBottle>();
        _wineBottleSlot = GetComponent<WineBottleSlot>();
    }

    private void Update()
    {
        //Manages Interactability and visibility of the wine bottle
        if (_agedWineBottle != null)
        {
            if (_checkHasWineBottle.hasSpecialWineBottle)
            {
                _agedWineBottle.SetActive(true);
                _wineBottleSlot.isAgingWineActive = true;
                _agedWineBottle.transform.position = transform.position + _wineBottleSlot.placementOffset;
                _agedWineBottle.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x + _wineBottleSlot.rotationOffset.x, transform.rotation.y + _wineBottleSlot.rotationOffset.y, transform.rotation.z + _wineBottleSlot.rotationOffset.z));

                _wineBottleSlot.TooltipText = _wineBottleSlot.agedPickupTooltip;
                _wineBottleSlot.wineBottleScript = _agedWineBottle.GetComponent<InteractableItem>();
            }
            else
            {
                _agedWineBottle.SetActive(false);
                _wineBottleSlot.isAgingWineActive = false;
            }
        }
        else
        {
            //Destroys original wine bottle and allows bottle placement
            if (!_checkHasWineBottle.hasDestroyedAgedWine)
            {
                _checkHasWineBottle.DestroyWineBottle();
                _wineBottleSlot.isAgingWineActive = false;
                _wineBottleSlot.isAgingWine = false;
            }
        }
    }
}
