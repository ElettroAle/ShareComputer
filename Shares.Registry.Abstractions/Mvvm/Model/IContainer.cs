
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shares.Registry.Abstractions.Mvvm.Model
{
    public interface IContainer : ICollection<IItem>, IQueryable<IItem>
    {
        string Name { get; } 
    }
}
