using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Topic
{
    private string _name;
    private IList<IAddressee> _adresses;

    public Topic(string name, IList<IAddressee> adresses)
    {
        _name = name;
        _adresses = adresses;
    }

    public void SendMessage(Message message)
    {
        foreach (IAddressee currentAddressee in _adresses)
        {
            currentAddressee.GetMessage(message);
        }
    }
}