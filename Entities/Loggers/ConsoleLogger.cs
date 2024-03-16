using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Loggers;

public sealed class ConsoleLogger : ILogger
{
    private List<string> _logs;

    public ConsoleLogger()
    {
        _logs = new List<string>();
    }

    public void LogInformation(string text)
    {
        _logs.Add(text);
    }

    public void WriteLogs()
    {
        foreach (string message in _logs)
        {
            Console.WriteLine($"{DateTime.Now} : {message}");
        }
    }
}