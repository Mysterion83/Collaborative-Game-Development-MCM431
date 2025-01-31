using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTeleportSystem : MonoBehaviour
{
    [SerializeField]
    GameObject LevelOneObject;
    [SerializeField]
    GameObject LevelTwoObject;

    [SerializeField]
    LevelEnum LevelEnum;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Teleport();
    }

    void Teleport()
    {
        Vector3 LocalPosition = gameObject.transform.localPosition;
        if (LevelEnum == LevelEnum.LevelOne)
        {
            LevelEnum = LevelEnum.LevelTwo;
            gameObject.transform.parent = LevelTwoObject.transform;
        }
        else 
        {
            LevelEnum = LevelEnum.LevelOne;
            gameObject.transform.parent = LevelOneObject.transform;
        }
        transform.localPosition = LocalPosition;
    }
}
