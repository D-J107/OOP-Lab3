namespace Itmo.ObjectOrientedProgramming.Lab3.Models.MessageStatuses;

public class Missing : MessageStatus
{
    public Missing(string messageHeader)
        : base($"Message \"{messageHeader}\" deleted or missing by some errors.")
    {
    }
}