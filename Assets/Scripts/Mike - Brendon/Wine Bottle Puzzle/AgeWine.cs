using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgeWine : MonoBehaviour
{
    public GameObject pastWineHolder; 
    private CheckHasWineBottle _checkHasWineBottle;
    private GameObject _agedWineBottle;
    private WineBottlePlacement _wineBottlePlacement;

    private void Start()
    {
        _agedWineBottle = transform.GetChild(0).gameObject;
        _checkHasWineBottle = pastWineHolder.GetComponent<CheckHasWineBottle>();
        _wineBottlePlacement = GetComponent <WineBottlePlacement>();
    }

    private void Update()
    {
        //Manages Interactability and visibility of the wine bottle
        if (_agedWineBottle != null)
        {
            if (_checkHasWineBottle.hasWineBottle)
            {
                _agedWineBottle.SetActive(true);
                _wineBottlePlacement.isAgingWineActive = true;
            }
            else
            {
                _agedWineBottle.SetActive(false);
                _wineBottlePlacement.isAgingWineActive = false;
            }
        }
        else
        {
            //Destroys original wine bottle and allows bottle placement
            if (!_checkHasWineBottle.hasDestroyedAgedWine)
            {
                _checkHasWineBottle.DestroyWineBottle();
                _wineBottlePlacement.isAgingWineActive = false;
                _wineBottlePlacement.isAgingWine = false;
            }
        }
    }
}
