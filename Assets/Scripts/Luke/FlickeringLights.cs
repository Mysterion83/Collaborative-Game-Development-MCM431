using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLights : MonoBehaviour
{
    public Light flickeringLight; // Reference to the Light component
    public float minIntensity = 0.5f; // Minimum intensity of the light
    public float maxIntensity = 1.5f; // Maximum intensity of the light
    public float flickerSpeed = 0.1f; // Speed of the flicker

    private void Start()
    {
        if (flickeringLight == null)
        {
            flickeringLight = GetComponent<Light>();
        }
    }

    private void Update()
    {
        // Change the intensity of the light over time
        float intensity = Mathf.Lerp(minIntensity, maxIntensity, Mathf.PingPong(Time.time * flickerSpeed, 1));
        flickeringLight.intensity = intensity;
    }
}
