namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;

public interface IAddressee
{
    public int AccessLevel { get; }
    public void GetMessage(Message message);
}