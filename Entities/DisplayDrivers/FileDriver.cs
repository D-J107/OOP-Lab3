using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.DisplayDrivers;

public class FileDriver : IDisplayDriver
{
    private string _filePath = string.Empty;
    public void ClearAllOutput()
    {
        File.WriteAllText(_filePath, string.Empty);
    }

    public void SetFilePathForOutputWritingText(string filePath)
    {
        _filePath = filePath;
    }

    public void WriteText(string information)
    {
        File.WriteAllText(_filePath, information);
    }
}