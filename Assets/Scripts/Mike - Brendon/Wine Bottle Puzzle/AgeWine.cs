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
        if (_agedWineBottle != null)
        {
            if (_checkHasWineBottle.hasWineBottle)
            {
                _agedWineBottle.SetActive(true);
                _wineBottlePlacement.isAgingWineActive = true;
                Debug.Log("Hello");
            }
            else
            {
                _agedWineBottle.SetActive(false);
                _wineBottlePlacement.isAgingWineActive = false;
            }
        }
        else
        {
            if (!_checkHasWineBottle.hasDestroyedAgedWine)
            {
                _checkHasWineBottle.DestroyWineBottle();
                _wineBottlePlacement.isAgingWineActive = false;
                _wineBottlePlacement.isAgingWine = false;
                Debug.Log("Bye");
            }
        }
    }
}
