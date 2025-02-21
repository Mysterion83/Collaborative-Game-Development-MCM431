using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlateManager : PuzzleManager
{

    void Update()
    {
        activated = CheckSwitches();
        PlayAnimation();
    }
}
