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
public class DebugCommand<T1> : DebugCommandBase
{
    private Action<T1> command;
    public DebugCommand(string commandID, string commandDescription, string commandFormat, Action<T1> command) : base(commandID, commandDescription, commandFormat)
    {
        this.command = command;
    }
    public void Invoke(T1 arg1)
    {
        command.Invoke(arg1);
    }
}
public class DebugCommand<T1, T2> : DebugCommandBase
{
    private Action<T1, T2> command;
    public DebugCommand(string commandID, string commandDescription, string commandFormat, Action<T1, T2> command) : base(commandID, commandDescription, commandFormat)
    {
        this.command = command;
    }
    public void Invoke(T1 arg1, T2 arg2)
    {
        command.Invoke(arg1, arg2);
    }
}
public class DebugCommand<T1, T2, T3> : DebugCommandBase
{
    private Action<T1, T2, T3> command;
    public DebugCommand(string commandID, string commandDescription, string commandFormat, Action<T1, T2, T3> command) : base(commandID, commandDescription, commandFormat)
    {
        this.command = command;
    }
    public void Invoke(T1 arg1, T2 arg2, T3 arg3)
    {
        command.Invoke(arg1, arg2, arg3);
    }
}
public class DebugCommand<T1, T2, T3, T4> : DebugCommandBase
{
    private Action<T1, T2, T3, T4> command;
    public DebugCommand(string commandID, string commandDescription, string commandFormat, Action<T1, T2, T3, T4> command) : base(commandID, commandDescription, commandFormat)
    {
        this.command = command;
    }
    public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
    {
        command.Invoke(arg1, arg2, arg3, arg4);
    }
}