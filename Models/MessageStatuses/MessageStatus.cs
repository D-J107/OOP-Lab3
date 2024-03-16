namespace Itmo.ObjectOrientedProgramming.Lab3.Models.MessageStatuses;

public abstract class MessageStatus
{
    protected MessageStatus(string information)
    {
        Information = information;
    }

    public string Information { get; }
}