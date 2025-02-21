using System.Linq;
using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class DebugMenu : MonoBehaviour
{
    private TextMeshProUGUI _debugText;

    private Transform _playerPosition;

    private LevelTeleportSystem _lts;

    private CharacterMovement _playerMovement;



    [SerializeField]
    private int _framesStored;

    [SerializeField]
    private int _framesForAverage;

    private List<float> _fpsRecordings;
    private ulong _totalFrames = 1;

    private float _totalRunTime = 0;

    private bool _isDebugActive;



    void Start()
    {
        _fpsRecordings = new List<float>();

        _debugText = GetComponentInChildren<TextMeshProUGUI>();
        _isDebugActive = false;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.TryGetComponent<Transform>(out _playerPosition);
            _lts = player.GetComponentInChildren<LevelTeleportSystem>();
            _playerMovement = player.GetComponentInChildren<CharacterMovement>();
        }
        else Debug.LogError("Debug Menu: Could not find object with Player Tag");
    }

    /// <summary>
    /// Changes the debug _debugText to reflect the current frame rate, Current Level, camera position and more.
    /// </summary>
    void Update()
    {
        _totalRunTime += Time.deltaTime;
        UpdateFPSArray();
        if (Input.GetKeyDown(KeyCode.F1))
        {
            ToggleDebugMenu();
        }
        if (_isDebugActive)
        {
            _debugText.text =
                $"Debug Menu:\nFPS: Avg: {Mathf.Round(GetAverageFPS())} Min: {Mathf.Round(GetMinFPS())} Max: {Mathf.Round(GetMaxFPS())}\n" +
                $"Total Frames: {_totalFrames}\n" +
                $"Total Runtime: {_totalRunTime}s\n" +
                $"Current Level: {GetCurrentLevel()} \n" +
                $"Player Position (Global): {GetPlayerPosition(DebugPostionType.Global)}\n" +
                $"Player Position (Global, Rounded): {GetPlayerPosition(DebugPostionType.GlobalRounded)}\n" +
                $"Player Position (Local): {GetPlayerPosition(DebugPostionType.Local)}\n" +
                $"Player Position (Local, Rounded): {GetPlayerPosition(DebugPostionType.LocalRounded)}\n" +
                $"Movement Speed: {GetPlayerMovementspeed()} m/s";
        }
        else
        {
            _debugText.text = "";
        }
        _totalFrames++;
    }
    void ToggleDebugMenu()
    {
        _isDebugActive = !_isDebugActive;
    }
    void UpdateFPSArray()
    {
        _fpsRecordings.Add(1.0f / Time.deltaTime);
        while (_fpsRecordings.Count > _framesStored)
        {
            _fpsRecordings.RemoveAt(0);
        }

    }
    float GetAverageFPS()
    {
        float fpsTotal = 0;
        int framesToCheck = _framesForAverage;
        if (framesToCheck >= _fpsRecordings.Count)
        {
            framesToCheck = _fpsRecordings.Count - 1;
        }
        while (framesToCheck > 0) 
        {
            fpsTotal += _fpsRecordings[_fpsRecordings.Count - framesToCheck - 1];
            framesToCheck--;
        }
        return fpsTotal / _framesForAverage;
    }
    float GetMinFPS()
    {
        return _fpsRecordings.Min();
    }
    float GetMaxFPS()
    {
        return _fpsRecordings.Max();
    }
    string GetCurrentLevel()
    {
        if (_lts == null) return "N/A";
        if (_lts.CurrentLevel == LevelEnum.LevelOne) return "Present";
        return "Past";
    }
    string GetPlayerPosition(DebugPostionType positionType)
    {
        if (_playerPosition == null) return "N/A";
        float x = 0, y = 0, z = 0;
        switch (positionType)
        {
            case DebugPostionType.Global:
                x = _playerPosition.position.x; 
                y = _playerPosition.position.y; 
                z = _playerPosition.position.z;
                break;
            case DebugPostionType.GlobalRounded:
                x = Mathf.Round(_playerPosition.position.x);
                y = Mathf.Round(_playerPosition.position.y);
                z = Mathf.Round(_playerPosition.position.z);
                break;
            case DebugPostionType.Local:
                x = _playerPosition.localPosition.x;
                y = _playerPosition.localPosition.y;
                z = _playerPosition.localPosition.z;
                break;
            case DebugPostionType.LocalRounded:
                x = Mathf.Round(_playerPosition.localPosition.x);
                y = Mathf.Round(_playerPosition.localPosition.y);
                z = Mathf.Round(_playerPosition.localPosition.z);
                break;
        }

        if (positionType == DebugPostionType.Global | positionType == DebugPostionType.Local)
        {
            return $"x: {x}, y: {y}, z: {z}";
        }
        return $"[x]: {x}, [y]: {y}, [z]: {z}";
    }
    float GetPlayerMovementspeed()
    {
        return (Mathf.Round(_playerMovement.CurrentSpeed*100)/100);
    }
}