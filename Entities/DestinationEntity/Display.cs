using System;
using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.DisplayDrivers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.DestinationEntity;

public class Display
{
    private string _name;
    private Message? _message;
    private IColorfullDriver _driver;
    private FileDriver _fileDriver;

    public Display(string name, int accessLevel, IColorfullDriver driver, FileDriver fileDriver, Message? message = null)
    {
        _name = name;
        if (accessLevel <= 0) throw new ArgumentException("Access level must be positive value!");
        AccessLevel = accessLevel;
        _driver = driver;
        _fileDriver = fileDriver;
        _message = message;
    }

    public int AccessLevel { get; }

    public void ShowMessageWithColor(Color color)
    {
        if (_message is null) throw new ArgumentException($"Display \"{_name}\" does not have message!");
        _driver.ClearAllOutput();
        _driver.SetColor(color);
        _driver.WriteText(_message.ToString());
    }

    public void ShowMessageToFile(string fileName)
    {
        _fileDriver.SetFilePathForOutputWritingText(fileName);
        _fileDriver.ClearAllOutput();
        if (_message is null) throw new ArgumentException("Driver does not contain message now!");
        _fileDriver.WriteText(_message.ToString());
    }

    internal void ReceiveMessage(Message? message)
    {
        _message = message;
    }
}