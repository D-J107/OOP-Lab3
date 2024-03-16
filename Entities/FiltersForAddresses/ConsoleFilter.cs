namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.FiltersForAddresses;

public class ConsoleFilter : IFilter
{
    public bool IsMessageAccessLevelAcceptable(Message message, int addresseeAccessLevel)
    {
        return message != null && message.AccessLevel >= addresseeAccessLevel;
    }
}