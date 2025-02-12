using System;
using System.Linq;
using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class DebugMenu : MonoBehaviour
{
    TextMeshProUGUI Text;

    Transform PlayerPosition;

    LevelTeleportSystem LTS;



    [SerializeField]
    int FramesStored;

    float[] FPSRecordings;
    int FPSrecordingPointer = 0;
    UInt64 TotalFrames = 1;

    float TotalRunTime = 0;

    bool debugActive;



    void Start()
    {
        LTS = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<LevelTeleportSystem>();
        FPSRecordings = new float[FramesStored];
        Text = GetComponentInChildren<TextMeshProUGUI>();
        PlayerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        debugActive = false;
    }

    /// <summary>
    /// Changes the debug text to reflect the current frame rate, Current Level, camera position and more.
    /// </summary>
    void Update()
    {
        TotalRunTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.F1))
        {
            ToggleDebugMenu();
        }
        if (debugActive)
        {
            UpdateFPSArray();
            Text.text = $"Debug Menu:\nFPS: Avg: {Mathf.Round(GetAverageFPS())} Min: {Mathf.Round(GetMinFPS())} Max: {Mathf.Round(GetMaxFPS())}\nTotal Frames: {TotalFrames}\nTotal Runtime: {TotalRunTime}s\n" +
                $"Current Level: {GetCurrentLevel()} \n" +
                $"Player Position (Global): x:{PlayerPosition.position.x}, y:{PlayerPosition.position.y}, z:{PlayerPosition.position.z}\n" +
                $"Player Position (Global, Rounded): [x]:{Mathf.Round(PlayerPosition.position.x)}, [y]:{Mathf.Round(PlayerPosition.position.y)}, [z]:{Mathf.Round(PlayerPosition.position.z)}\n" +
                $"Player Position (Local): x:{PlayerPosition.localPosition.x}, y:{PlayerPosition.localPosition.y}, z:{PlayerPosition.localPosition.z}\n" +
                $"Player Position (Local, Rounded): [x]:{Mathf.Round(PlayerPosition.localPosition.x)}, [y]:{Mathf.Round(PlayerPosition.localPosition.y)}, [z]:{Mathf.Round(PlayerPosition.localPosition.z)}";
        }
        else
        {
            Text.text = "";
        }
        TotalFrames++;

    }
    void ToggleDebugMenu()
    {
        debugActive = !debugActive;
    }
    void UpdateFPSArray()
    {
        FPSRecordings[FPSrecordingPointer] = 1.0f / Time.deltaTime;
        FPSrecordingPointer = (FPSrecordingPointer + 1) % FramesStored;
    }
    float GetAverageFPS()
    {
        float FpsTotal = 0;
        foreach (var f in FPSRecordings)
        {
            FpsTotal += f;
        }
        return FpsTotal / FPSRecordings.Length;
    }
    float GetMinFPS()
    {
        return FPSRecordings.Min();
    }
    float GetMaxFPS()
    {
        return FPSRecordings.Max();
    }
    string GetCurrentLevel()
    {
        if (LTS.CurrentLevel == LevelEnum.LevelOne) return "Present";
        return "Past";
    }
}