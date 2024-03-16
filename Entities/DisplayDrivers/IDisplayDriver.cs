namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.DisplayDrivers;

public interface IDisplayDriver
{
    public void ClearAllOutput();
    public void WriteText(string information);
}