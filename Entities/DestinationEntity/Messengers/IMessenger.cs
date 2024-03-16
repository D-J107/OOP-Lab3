namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.DestinationEntity.Messengers;

public interface IMessenger
{
    public int AccessLevel { get; }
    public void ShowAllMessages();
    public void ShowMessageByName(string header);
    public void ReceiveMessage(Message message);
}