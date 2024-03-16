using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.OutputDevices;

public sealed class ConsoleShower : IMessageShower
{
    public void ShowMessage(string message)
    {
        ArgumentNullException.ThrowIfNull(message);
        Console.WriteLine(message.ToString());
    }
}