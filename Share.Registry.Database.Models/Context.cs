
using Shares.Registry.Abstractions.Mvvm.Model;

using System;
using System.Collections.Generic;
using System.Text;

namespace Share.Registry.Database.Models
{
    public abstract class Context : IContext
    {
        public abstract IEnumerable<IContainer> Containers { get; protected set; }
        public abstract void Dispose();

        // TODO: collegare le tabelle
    }
}
