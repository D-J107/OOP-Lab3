using System;
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.DisplayDrivers;

public class ConsoleDriver : IColorfullDriver
{
    private Color _color;

    public void ClearAllOutput()
    {
        Console.Clear();
    }

    public void SetColor(Color color)
    {
        _color = color;
    }

    public void WriteText(string information)
    {
        Crayon.Output.Rgb(_color.R, _color.G, _color.B).Text(information);
    }
}