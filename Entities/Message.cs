using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Message
{
    public Message(string header, string body, int accessLevel)
    {
        Header = header;
        Body = body;
        if (accessLevel <= 0) throw new ArgumentException("Message access level must be positive value!");
        AccessLevel = accessLevel;
    }

    public string Header { get; }
    public string Body { get; }
    public int AccessLevel { get; } // maybe int or enum

    public override string ToString()
    {
        return Body;
    }
}