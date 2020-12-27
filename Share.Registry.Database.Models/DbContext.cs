
using Share.Registry.Database.Models.Containers;

using Shares.Registry.Abstraction.Database.Connections;
using Shares.Registry.Abstraction.Database.Structure;
using Shares.Registry.Mvvm.Models.Entities;

using System.Collections.Generic;

namespace Share.Registry.Database.Models
{
    /// <summary>
    /// Class used to design the database shape. Don't care about what type of Database you'll use. It will be inject by the constructor unsing the <see cref="IDatabaseClient"/> interface
    /// </summary>
    public sealed class DbContext : IContext
    {
        public DbContext(IClient client)
        {
            // Containers Initialization
            Containers = new List<IContainer>()
            {
                new Container<TableSharePurchase>(client)
            };
            Client = client;
            client.Open();
        }
        /// <summary>
        /// The List of containers that models the database
        /// </summary>
        public IEnumerable<IContainer> Containers { get; }
        /// <summary>
        /// Gets the client. Opens it, if needed.
        /// </summary>
        public IClient Client { get; }
        /// <summary>
        /// Disposes the context and close the client.
        /// </summary>
        public void Dispose() => Client.Close();
    }
}
