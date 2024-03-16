using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.DestinationEntity.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.FiltersForAddresses;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;

public class MessengerAddressee : IAddressee
{
    private IMessenger _messenger;
    private IFilter _filter;
    private ILogger _logger;

    public MessengerAddressee(IMessenger messenger, IFilter? filter = null, ILogger? logger = null)
    {
        _messenger = messenger;
        if (messenger != null) AccessLevel = messenger.AccessLevel;
        _filter = filter ?? new ConsoleFilter();
        _logger = logger ?? new ConsoleLogger();
    }

    public int AccessLevel { get; }

    public void GetMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        if (!_filter.IsMessageAccessLevelAcceptable(message, AccessLevel)) return;
        _messenger.ReceiveMessage(message);

        string? logMe = message?.ToString();
        if (logMe is null) return;
        _logger.LogInformation(logMe);
    }

    public void ShowAllLogs()
    {
        _logger.WriteLogs();
    }

    public MessengerAddressee SetFilter(IFilter filter)
    {
        _filter = filter;
        return this;
    }

    public MessengerAddressee SetLogger(ILogger logger)
    {
        _logger = logger;
        return this;
    }
}