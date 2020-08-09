
using System;
using System.Collections.Generic;
using System.Text;

namespace Shares.Registry.Abstractions.Mvvm.Model
{
    public interface IItem
    {
        IEnumerable<Property> GetProperties();
        string Container { get; }
        object Id { get; }
    }
}
