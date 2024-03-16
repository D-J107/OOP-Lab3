namespace Itmo.ObjectOrientedProgramming.Lab3.Models.MessageStatuses;

public class Read : MessageStatus
{
    public Read(string messageHeader)
        : base($"Message \"{messageHeader}\" has already been read.")
    {
    }
}