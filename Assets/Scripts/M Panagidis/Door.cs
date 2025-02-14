using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public List<GameObject> switches = new List<GameObject>();
    private List<Switches> switchesScripts = new List<Switches>();

    private bool activated = false;

    public Animator animator;
    public string animBoolName;

    public bool CheckSwitches()
    {
        bool SwitchOn = true;
        for (int i = 0; i < switches.Count; i++)
        {
            if (switches[i] != null)
            {
                if (!switchesScripts[i].switchON)
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
        for (int i = 0; i < switches.Count; i++)
        {
            if (switches[i] != null)
            {
                switchesScripts.Add(switches[i].GetComponent<Switches>());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        activated = CheckSwitches();
        if (activated)
        {
            animator.SetBool(animBoolName, true); 
        }
        else
        {
            animator.SetBool(animBoolName, false);
        }
    }
}
