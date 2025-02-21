using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CommandConsole : MonoBehaviour
{
    private bool _consoleEnabled;

    private string _userInput;

    public static DebugCommand LOG;

    public List<DebugCommand> CommandList;

    public void Awake()
    {
        LOG = new DebugCommand("log", "Logs a message to the console", "log", () =>
        {
            Debug.Log("Hello World");
        });

        CommandList = new List<DebugCommand>()
        {
            LOG
        };
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            _consoleEnabled = !_consoleEnabled;
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (_consoleEnabled)
            {
                HandleInput();
                _userInput = "";
            }
        }
    }

    private void OnGUI()
    {
        if (!_consoleEnabled) return;

        float y = 0f;

        GUI.Box(new Rect(0, y, Screen.width, 30), "");
        GUI.backgroundColor = new Color(0, 0, 0, 0);
        _userInput = GUI.TextField(new Rect(10f, y + 5f, Screen.width - 20f, 20f), _userInput);
    }
    private void HandleInput()
    {
        for (int i = 0; i < CommandList.Count; i++)
        {
            DebugCommandBase commandBase = CommandList[i] as DebugCommandBase;

            if (_userInput.Contains(commandBase.CommandID))
            {
                CommandList[i].Invoke();
            }
        }
    }
}
