using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLights : MonoBehaviour
{
    public Light flickeringLight; // Reference to the Light component

    public float MaxWait = 1;
    public float MinWait = 0;
    public float MaxFlicker = 0.2f;
    public float MinFlicker = 0;

    float Timer;
    float Interval;

    private void Start()
    {
        if (flickeringLight == null)
        {
            flickeringLight = GetComponent<Light>();
        }
    }

    private void Update()
    {
        Timer += Time.deltaTime;
        if (Timer > Interval)
        {
            ToggleLight();
        }
    }

    void ToggleLight()
    {
        flickeringLight.enabled = !flickeringLight.enabled;
        if (flickeringLight.enabled)
        {
            Interval = Random.Range(MinWait, MaxWait);
        }
        else
        {
            Interval = Random.Range(MinFlicker, MaxFlicker);
        }
        Timer = 0;
    }
}
