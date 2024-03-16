using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.OutputDevices;
using Itmo.ObjectOrientedProgramming.Lab3.Models.MessageStatuses;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.DestinationEntity;

public class User
{
    private string _name;
    private string _id;
    private IList<Message> _readMessages; // todo что делать с прочитанными сообщениями?
    private IList<Message> _unreadMessages;
    private IMessageShower _messageShower;

    public User(string name, int accessLevel, IMessageShower? messageShower = null)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentException("User must have a name!");
        if (accessLevel <= 0) throw new ArgumentException("Access level must be positive value!");
        _name = name;
        _id = Guid.NewGuid().ToString();
        _readMessages = new List<Message>();
        _unreadMessages = new List<Message>();
        AccessLevel = accessLevel;
        _messageShower = messageShower ?? new ConsoleShower();
    }

    public int AccessLevel { get; }

    public void SendMessage(IAddressee addressee, Message message)
    {
        ArgumentNullException.ThrowIfNull(addressee);
        ArgumentNullException.ThrowIfNull(message);
        if (message.AccessLevel > this.AccessLevel)
            throw new ArgumentException("Error! You access level is too low for such message!");
        addressee.GetMessage(message);
    }

    public void ViewAllUnreadMessages()
    {
        if (_unreadMessages.Count == 0)
        {
            _messageShower.ShowMessage($"Hello, {_name}, you dont have any unread messages!");
            return;
        }

        _messageShower.ShowMessage($"Hello, {_name}, you have next unread messages:");
        foreach (Message currentMessage in _unreadMessages)
        {
            _messageShower.ShowMessage(currentMessage.Header);
        }
    }

    public MessageStatus CheckMessageStatusByName(string header)
    {
        if (_unreadMessages.Any(currentMessage => currentMessage.Header == header))
        {
            return new Unread(header);
        }

        if (_readMessages.Any(currentMessage => currentMessage.Header == header))
        {
            return new Read(header);
        }

        return new Missing(header);
    }

    public void SetUnreadMessageStatusToReadByName(string messageName)
    {
        foreach (Message currentMessage in _unreadMessages.Where(currentMessage => currentMessage.Header == messageName))
        {
            _readMessages.Add(currentMessage);
            _unreadMessages.Remove(currentMessage);
            return;
        }

        if (_readMessages.Any(currentMessage => currentMessage.Header == messageName))
        {
            throw new ArgumentException($"Error! message \"{messageName}\" already read!");
        }

        throw new ArgumentException($"Error! Message \"{messageName}\" not found!");
    }

    public void ReadMessageByName(string messageName)
    {
        foreach (Message currentMessage in _unreadMessages.Where(currentMessage => currentMessage.Header == messageName))
        {
            _messageShower.ShowMessage(currentMessage.Body);
            return;
        }

        foreach (Message currentMessage in _readMessages.Where(currentMessage => currentMessage.Header == messageName))
        {
            _messageShower.ShowMessage(currentMessage.Body);
            return;
        }

        throw new ArgumentException($"Error! Message \"{messageName}\" not found!");
    }

    public User SetMessageShower(IMessageShower shower)
    {
        _messageShower = shower;
        return this;
    }

    internal void ReceiveMessage(Message message)
    {
        _unreadMessages.Add(message);
    }
}