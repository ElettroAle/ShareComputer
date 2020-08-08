using Shares.Registry.Abstractions.Mvvm.Model;

using System;
using System.Collections.Generic;
using System.Text;

namespace Share.Registry.Database.FileSystem
{
    public abstract class Context : IContext
    {
        public IEnumerable<IContainer> Containers { get; set; }
        public abstract void Dispose();
    }
}
