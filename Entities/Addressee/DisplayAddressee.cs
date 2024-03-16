using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.DestinationEntity;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.FiltersForAddresses;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;

public class DisplayAddressee : IAddressee
{
    private Display _display;
    private IFilter _filter;
    private ILogger _logger;

    public DisplayAddressee(Display display, IFilter? filter = null, ILogger? logger = null)
    {
        _display = display;
        if (display != null) AccessLevel = display.AccessLevel;
        _filter = filter ?? new ConsoleFilter();
        _logger = logger ?? new ConsoleLogger();
    }

    public int AccessLevel { get; }
    public void GetMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        if (!_filter.IsMessageAccessLevelAcceptable(message, AccessLevel)) return;

        _display.ReceiveMessage(message);

        string? logMe = message.ToString();
        if (logMe is null) return;
        _logger.LogInformation(logMe);
    }

    public void ShowAllLogs()
    {
        _logger.WriteLogs();
    }

    public DisplayAddressee SetFilter(IFilter filter)
    {
        _filter = filter;
        return this;
    }

    public DisplayAddressee SetLogger(ILogger logger)
    {
        _logger = logger;
        return this;
    }
}