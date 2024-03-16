using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.DisplayDrivers;

public interface IColorfullDriver : IDisplayDriver
{
    public void SetColor(Color color);
}