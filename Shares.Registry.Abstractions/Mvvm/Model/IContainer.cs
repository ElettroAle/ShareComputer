
using System;
using System.Collections.Generic;

namespace Shares.Registry.Abstractions.Mvvm.Model
{
    public interface IContainer
    {
        string Name { get; }
        IEnumerable<IItem> DoQuery(params object[] queryes);
    }
}
