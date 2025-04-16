using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(WaterCisternPuzzle))]
public class WaterCisternDebug : Editor
{

    public override void OnInspectorGUI()
    {
        WaterCisternPuzzle waterCisternPuzzle = (WaterCisternPuzzle)target;
        if (GUILayout.Button("Update Pipe States A"))
        {
            waterCisternPuzzle.UpdatePipeStates();
        }
    }
}
