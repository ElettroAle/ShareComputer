
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shares.Registry.Abstraction.Database.Structure
{
    public interface IContainer : IQueryable<IEntity>, IOrderedQueryable<IEntity>
    {
        string Name { get; }
    }
}
