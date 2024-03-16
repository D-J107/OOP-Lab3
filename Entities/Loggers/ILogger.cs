namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Loggers;

public interface ILogger
{
    public void LogInformation(string text);
    public void WriteLogs();
}