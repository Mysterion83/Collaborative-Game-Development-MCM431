using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet_Puzzle : MonoBehaviour
{
    public List<GameObject> planets = new List<GameObject>();
    private List<Planet> planetScripts = new List<Planet>();

    private bool activated = false;
    private Switches switches;
    public float errorRange = 1f;

    public bool CheckPlanet()
    {
        bool SwitchOn = true;
        for (int i = 0; i < planets.Count; i++)
        {
            if (planets[i] != null)
            {
                if (!planetScripts[i].isCorrectRotation)
                {
                    SwitchOn = false;
                    break;
                }
            }
        }
        return SwitchOn;
    }

    // Start is called before the first frame update
    void Start()
    {
        switches = gameObject.GetComponent<Switches>();
        for (int i = 0; i < planets.Count; i++)
        {
            if (planets[i] != null)
            {
                planetScripts.Add(planets[i].GetComponent<Planet>());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        activated = CheckPlanet();
        switches.switchON = activated;
    }
}
