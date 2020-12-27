
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shares.Registry.Abstractions.Mvvm.Model
{
    public interface IContainer : IQueryable<IItem>, IOrderedQueryable<IItem>
    {
        string Name { get; } 
    }
}
