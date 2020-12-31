
using System;
using System.Collections.Generic;
using System.Text;

namespace Shares.Registry.Abstraction.Database.Structure
{
    public interface IEntity
    {
        IEnumerable<Property> GetProperties();
        /// <summary>
        /// Container name, it's the name of the container. For example, it should be the Azure Table Storage Partition Key
        /// </summary>
        string PartitionKey { get; }
        /// <summary>
        /// Primary Key of the item. For example, it should be the Azure Table Storage Row Key
        /// </summary>
        object PrimaryKey { get; }
    }
}
