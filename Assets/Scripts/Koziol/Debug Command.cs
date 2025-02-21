using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCommandBase
{
    private string _commandID;
    private string _commandDescription;
    private string _commandFormat;

    public string CommandID { get { return _commandID; } }
    public string CommandDescription { get { return _commandDescription; } }
    public string CommandFormat { get { return _commandFormat; } }

    public DebugCommandBase(string commandID, string commandDescription, string commandFormat)
    {
        _commandID = commandID;
        _commandDescription = commandDescription;
        _commandFormat = commandFormat;
    }
}
public class DebugCommand : DebugCommandBase
{
    private Action command;

    public DebugCommand(string commandID, string commandDescription, string commandFormat, Action command) : base(commandID, commandDescription, commandFormat)
    {
        this.command = command;
    }

    public void Invoke()
    {
        command.Invoke();
    }
}