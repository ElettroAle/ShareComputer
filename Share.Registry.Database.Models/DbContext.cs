
using Share.Registry.Database.Models.Containers;

using Shares.Registry.Abstractions.Connections;
using Shares.Registry.Abstractions.Mvvm.Model;
using Shares.Registry.Mvvm.Models.Entities;

using System;
using System.Collections.Generic;
using System.Text;

namespace Share.Registry.Database.Models
{
    /// <summary>
    /// Class used to design the database shape. Don't care about what type of Database you'll use. It will be inject by the constructor unsing the <see cref="IDatabaseClient"/> interface
    /// </summary>
    public sealed class DbContext : IContext
    {
        public DbContext(IDatabaseClient client)
        {
            // Containers Initialization
            Containers = new List<IContainer>()
            {
                new Container<TableSharePurchase>()
            };
            this.client = client;
        }
        public IEnumerable<IContainer> Containers { get; }
        private readonly IDatabaseClient client;
        public IDatabaseClient Client => !client.IsOpen ? client.Open() : client;
        public bool IsOpen => client.IsOpen;
        public void Dispose() => Client.Dispose();
    }
}
