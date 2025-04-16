using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CisternWater : MonoBehaviour
{
    Vector3 _upPosition;
    [SerializeField]
    float _verticalMovementAmount = 10f;
    // Start is called before the first frame update
    void Start()
    {
        _upPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        MoveWater(false);
    }
    public void MoveWater(bool Up)
    {
        if (Up)
        {
            transform.position = _upPosition;
        }
        else
        {
            transform.position = new Vector3(_upPosition.x, _upPosition.y - _verticalMovementAmount, _upPosition.z);
        }
    }
}
