﻿using Share.Registry.Database.Models.Containers;

using Shares.Registry.Abstraction.Database.Connections;
using Shares.Registry.Abstraction.Database.Structure;
using Shares.Registry.Layers.DataAccess.Models.Entities;

using System.Collections.Generic;

namespace Shares.Registry.DataAccess.Context
{
    /// <summary>
    /// Class used to design the no-sql database shape. Don't care about what type of client you'll use. It will be inject by the constructor unsing the <see cref="IClient"/> interface
    /// </summary>
    public sealed class NoSqlContext : IContext
    {
        public NoSqlContext(IClient client)
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