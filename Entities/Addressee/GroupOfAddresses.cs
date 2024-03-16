using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.FiltersForAddresses;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;

public class GroupOfAddresses : IAddressee
{
    private IList<IAddressee> _addresseesGroup;
    private IFilter _filter;
    private ILogger _logger;

    public GroupOfAddresses(IList<IAddressee> addressees, int accessLevel, IFilter? filter = null, ILogger? logger = null)
    {
        _addresseesGroup = addressees;
        AccessLevel = accessLevel;
        _filter = filter ?? new ConsoleFilter();
        _logger = logger ?? new ConsoleLogger();
    }

    public int AccessLevel { get; }

    public void GetMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        if (!_filter.IsMessageAccessLevelAcceptable(message, AccessLevel)) return;
        foreach (IAddressee currentAddresse in _addresseesGroup)
        {
            if (!_filter.IsMessageAccessLevelAcceptable(message, currentAddresse.AccessLevel)) continue;
            currentAddresse.GetMessage(message);
        }

        string? logMe = message?.ToString();
        if (logMe is null) return;
        _logger.LogInformation(logMe);
    }

    public void ShowAllLogs()
    {
        _logger.WriteLogs();
    }

    public GroupOfAddresses SetFilter(IFilter filter)
    {
        _filter = filter;
        return this;
    }

    public GroupOfAddresses SetLogger(ILogger logger)
    {
        _logger = logger;
        return this;
    }
}