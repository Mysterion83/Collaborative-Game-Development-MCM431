using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleCommandBase
{
    private string _commandID;
    private string _commandDescription;
    private string _commandFormat;

    public string CommandID { get { return _commandID; } }
    public string CommandDescription { get { return _commandDescription; } }
    public string CommandFormat { get { return _commandFormat; } }

    public ConsoleCommandBase(string commandID, string commandDescription, string commandFormat)
    {
        _commandID = commandID;
        _commandDescription = commandDescription;
        _commandFormat = commandFormat;
    }
}
public class ConsoleCommand : ConsoleCommandBase
{
    private Action command;

    public ConsoleCommand(string commandID, string commandDescription, string commandFormat, Action command) : base(commandID, commandDescription, commandFormat)
    {
        this.command = command;
    }

    public void Invoke()
    {
        command.Invoke();
    }
}
public class ConsoleCommand<T1> : ConsoleCommandBase
{
    private Action<T1> command;
    public ConsoleCommand(string commandID, string commandDescription, string commandFormat, Action<T1> command) : base(commandID, commandDescription, commandFormat)
    {
        this.command = command;
    }
    public void Invoke(T1 arg1)
    {
        command.Invoke(arg1);
    }
}
public class ConsoleCommand<T1, T2> : ConsoleCommandBase
{
    private Action<T1, T2> command;
    public ConsoleCommand(string commandID, string commandDescription, string commandFormat, Action<T1, T2> command) : base(commandID, commandDescription, commandFormat)
    {
        this.command = command;
    }
    public void Invoke(T1 arg1, T2 arg2)
    {
        command.Invoke(arg1, arg2);
    }
}
public class ConsoleCommand<T1, T2, T3> : ConsoleCommandBase
{
    private Action<T1, T2, T3> command;
    public ConsoleCommand(string commandID, string commandDescription, string commandFormat, Action<T1, T2, T3> command) : base(commandID, commandDescription, commandFormat)
    {
        this.command = command;
    }
    public void Invoke(T1 arg1, T2 arg2, T3 arg3)
    {
        command.Invoke(arg1, arg2, arg3);
    }
}
public class ConsoleCommand<T1, T2, T3, T4> : ConsoleCommandBase
{
    private Action<T1, T2, T3, T4> command;
    public ConsoleCommand(string commandID, string commandDescription, string commandFormat, Action<T1, T2, T3, T4> command) : base(commandID, commandDescription, commandFormat)
    {
        this.command = command;
    }
    public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
    {
        command.Invoke(arg1, arg2, arg3, arg4);
    }
}