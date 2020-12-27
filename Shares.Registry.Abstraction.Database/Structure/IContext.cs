
using Shares.Registry.Abstraction.Database.Connections;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shares.Registry.Abstraction.Database.Structure
{
    public interface IContext : IDisposable
    {
        IEnumerable<IContainer> Containers { get; }
        IClient Client { get; }
    }
    public static class IContextExtensions
    {
        public static IContainer GetContainer(this IContext context, string containerName = null) => context.Containers?.FirstOrDefault(x => containerName == null || x.Name == containerName) ?? null;
    }
}
