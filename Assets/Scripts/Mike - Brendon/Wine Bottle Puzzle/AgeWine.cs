using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgeWine : MonoBehaviour
{
    private LevelTeleportSystem _levelTeleportSystem;
    private CheckHasWineBottle _checkHasWineBottle;

    public Vector3 bottleOffset;
    public GameObject agedWineBottle;

    private void Start()
    {
        _levelTeleportSystem = GameObject.FindGameObjectWithTag("Player").GetComponent<LevelTeleportSystem>();
        _checkHasWineBottle = GameObject.FindGameObjectWithTag("Level One").transform.Find("WinePlaceholder").gameObject.GetComponent<CheckHasWineBottle>();
    }
    private void Update()
    {
        if (_checkHasWineBottle.hasWineBottle && _levelTeleportSystem.CurrentLevel == LevelEnum.LevelTwo)
        {
            GameObject _agedWineBottle = Instantiate(agedWineBottle, transform);
            _agedWineBottle.transform.position = transform.position + bottleOffset;
        }
    }
}
