using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.DestinationEntity;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.FiltersForAddresses;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;

public class UserAddressee : IAddressee
{
    private User _user;
    private IFilter _filter;
    private ILogger _logger;

    public UserAddressee(User user, IFilter? filter = null, ILogger? logger = null)
    {
        _user = user;
        if (user != null) AccessLevel = user.AccessLevel;
        _filter = filter ?? new ConsoleFilter();
        _logger = logger ?? new ConsoleLogger();
    }

    public int AccessLevel { get; }

    public void GetMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        if (!_filter.IsMessageAccessLevelAcceptable(message, AccessLevel)) return;

        _user.ReceiveMessage(message);

        string? logMe = message.ToString();
        if (logMe is null) return;
        _logger.LogInformation(logMe);
    }

    public void ShowAllLogs()
    {
        _logger.WriteLogs();
    }

    public UserAddressee SetFilter(IFilter filter)
    {
        _filter = filter;
        return this;
    }

    public UserAddressee SetLogger(ILogger logger)
    {
        _logger = logger;
        return this;
    }
}