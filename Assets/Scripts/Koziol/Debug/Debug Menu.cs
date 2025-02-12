using System;
using System.Linq;
using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class DebugMenu : MonoBehaviour
{
    TextMeshProUGUI DebugText;

    Transform PlayerPosition;

    LevelTeleportSystem LTS;



    [SerializeField]
    int FramesStored;

    [SerializeField]
    int FramesForAvg;

    List<float> FPSRecordings;
    ulong TotalFrames = 1;

    float TotalRunTime = 0;

    bool debugActive;



    void Start()
    {
        FPSRecordings = new List<float>();

        DebugText = GetComponentInChildren<TextMeshProUGUI>();
        debugActive = false;

        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        if (Player != null)
        {
            Player.TryGetComponent<Transform>(out PlayerPosition);
            LTS = Player.GetComponentInChildren<LevelTeleportSystem>();
        }
        else Debug.LogError("Debug Menu: Could not find object with Player Tag");
    }

    /// <summary>
    /// Changes the debug DebugText to reflect the current frame rate, Current Level, camera position and more.
    /// </summary>
    void Update()
    {
        TotalRunTime += Time.deltaTime;
        UpdateFPSArray();
        if (Input.GetKeyDown(KeyCode.F1))
        {
            ToggleDebugMenu();
        }
        if (debugActive)
        {
            
            DebugText.text = 
                $"Debug Menu:\nFPS: Avg: {Mathf.Round(GetAverageFPS())} Min: {Mathf.Round(GetMinFPS())} Max: {Mathf.Round(GetMaxFPS())}\n" +
                $"Total Frames: {TotalFrames}\n" +
                $"Total Runtime: {TotalRunTime}s\n" +
                $"Current Level: {GetCurrentLevel()} \n" +
                $"Player Position (Global): {GetPlayerPosition(DebugPostionType.Global)}\n" +
                $"Player Position (Global, Rounded): {GetPlayerPosition(DebugPostionType.GlobalRounded)}\n" +
                $"Player Position (Local): {GetPlayerPosition(DebugPostionType.Local)}\n" +
                $"Player Position (Local, Rounded): {GetPlayerPosition(DebugPostionType.LocalRounded)}";
        }
        else
        {
            DebugText.text = "";
        }
        TotalFrames++;
    }
    void ToggleDebugMenu()
    {
        debugActive = !debugActive;
    }
    void UpdateFPSArray()
    {
        FPSRecordings.Add(1.0f / Time.deltaTime);
        while (FPSRecordings.Count > FramesStored)
        {
            FPSRecordings.RemoveAt(0);
        }

    }
    float GetAverageFPS()
    {
        float FpsTotal = 0;
        int FramesToCheck = FramesForAvg;
        if (FramesToCheck >= FPSRecordings.Count)
        {
            FramesToCheck = FPSRecordings.Count - 1;
        }
        while (FramesToCheck > 0) 
        {
            FpsTotal += FPSRecordings[FPSRecordings.Count - FramesToCheck - 1];
            FramesToCheck--;
        }
        return FpsTotal / FramesForAvg;
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
        if (LTS == null) return "N/A";
        if (LTS.CurrentLevel == LevelEnum.LevelOne) return "Present";
        return "Past";
    }
    string GetPlayerPosition(DebugPostionType PositionType)
    {
        if (PlayerPosition == null) return "N/A";
        float x = 0, y = 0, z = 0;
        switch (PositionType)
        {
            case DebugPostionType.Global:
                x = PlayerPosition.position.x; 
                y = PlayerPosition.position.y; 
                z = PlayerPosition.position.z;
                break;
            case DebugPostionType.GlobalRounded:
                x = Mathf.Round(PlayerPosition.position.x);
                y = Mathf.Round(PlayerPosition.position.y);
                z = Mathf.Round(PlayerPosition.position.z);
                break;
            case DebugPostionType.Local:
                x = PlayerPosition.localPosition.x;
                y = PlayerPosition.localPosition.y;
                z = PlayerPosition.localPosition.z;
                break;
            case DebugPostionType.LocalRounded:
                x = Mathf.Round(PlayerPosition.localPosition.x);
                y = Mathf.Round(PlayerPosition.localPosition.y);
                z = Mathf.Round(PlayerPosition.localPosition.z);
                break;
        }

        if (PositionType == DebugPostionType.Global | PositionType == DebugPostionType.Local)
        {
            return $"x: {x}, y: {y}, z: {z}";
        }
        return $"[x]: {x}, [y]: {y}, [z]: {z}";
    }
}