using UnityEngine;

public class LightBreathingSystem : MonoBehaviour
{
    [SerializeField]
    private float _intensity;
    [SerializeField]
    private float _flickerSpeed;



    private Light _lightSource;

    private float _baseLightIntensity;
    private float _timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        _lightSource = GetComponent<Light>();
        if (_lightSource == null)
        {
            Debug.LogError("Light Flickering System: No Light Componment Found");
        }
        else
        {
            _baseLightIntensity = _lightSource.intensity;
        }
    }

    // Update is called once per frame
    void Update()
    {
        _timeElapsed += Time.deltaTime;
        _lightSource.intensity = (Mathf.Sin(_timeElapsed * _flickerSpeed) * _intensity) + _baseLightIntensity;
    }
}
