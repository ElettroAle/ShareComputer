using Shares.Registry.Abstractions.Connections;
using Shares.Registry.Abstractions.Mvvm.Model;
using Share.Registry.Database.Models;

using System;
using System.Collections.Generic;
using System.Text;

namespace Shares.Registry.Test.Abstractions.Context
{
    public class ContextFactory
    {
        public IContext GetContext(IDatabaseClient client) => new DbContext(client);
    }
}
