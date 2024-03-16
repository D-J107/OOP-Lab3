using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.OutputDevices;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.DestinationEntity.Messengers;

public class Messenger : IMessenger
{
    private string _name;
    private IMessageShower _messageShower;
    private List<Message> _messages;

    public Messenger(string name, int accessLevel, IMessageShower? shower = null)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentException("User must have a name!");
        if (accessLevel <= 0) throw new ArgumentException("Access level must be positive value!");
        _name = name;
        AccessLevel = accessLevel;
        _messageShower = shower ?? new ConsoleShower();
        _messages = new List<Message>();
    }

    public int AccessLevel { get; }

    public void ShowAllMessages()
    {
        if (_messages.Count == 0)
        {
            _messageShower.ShowMessage("There no messages!");
            return;
        }

        foreach (Message currentMessage in _messages)
        {
            string showMe = GenerateMessage(currentMessage);
            _messageShower.ShowMessage(showMe);
        }
    }

    public void ShowMessageByName(string header)
    {
        foreach (Message currentMessage in _messages)
        {
            if (currentMessage.Header != header) continue;
            string showMe = GenerateMessage(currentMessage);
            _messageShower.ShowMessage(showMe);
            return;
        }
    }

    public void ReceiveMessage(Message message)
    {
        _messages.Add(message);
    }

    private string GenerateMessage(Message message)
    {
        return $"{_name} sends message: " + message.ToString();
    }
}