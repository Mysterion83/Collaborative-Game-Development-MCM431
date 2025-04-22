using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class CisternWater : MonoBehaviour
{
    Vector3 _upPosition;
    [SerializeField]
    float _verticalMovementAmount = 10f;
    [SerializeField]
    WaterSurface _waterSurface;
    [SerializeField]
    bool _isWaterActive = false;
    // Start is called before the first frame update
    void Start()
    {
        _waterSurface = GetComponent<WaterSurface>();
        if (_waterSurface == null)
        {
            Debug.LogError("WaterSurface component is missing on this GameObject.");
            return;
        }
        _upPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        MoveWater(false);
    }
    public void MoveWater(bool Up)
    {
        if (Up)
        {
            transform.position = _upPosition;
            _waterSurface.enabled = true;
            _isWaterActive = true;
        }
        else
        {
            transform.position = new Vector3(_upPosition.x, _upPosition.y - _verticalMovementAmount, _upPosition.z);
            _waterSurface.enabled = false;
            _isWaterActive = false;
        }
    }
    public void DisableWater()
    {
        _waterSurface.enabled = false;
        _isWaterActive = false;
    }
    public void EnableWater()
    {
        _waterSurface.enabled = true;
        _isWaterActive = true;
    }


}
