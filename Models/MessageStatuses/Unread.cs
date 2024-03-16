namespace Itmo.ObjectOrientedProgramming.Lab3.Models.MessageStatuses;

public class Unread : MessageStatus
{
    public Unread(string messageHeader)
        : base($"Message \"{messageHeader}\" has not been read yet.")
    {
    }
}