namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.FiltersForAddresses;

public interface IFilter
{
    public bool IsMessageAccessLevelAcceptable(Message message, int addresseeAccessLevel);
}