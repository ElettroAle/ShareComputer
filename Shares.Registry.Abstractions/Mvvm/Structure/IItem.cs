
using System;
using System.Collections.Generic;
using System.Text;

namespace Shares.Registry.Abstractions.Mvvm.Model
{
    public interface IItem
    {
        IEnumerable<Property> GetProperties();
        /// <summary>
        /// Container name, it's the name of the container. For example, it should be the Azure Table Storage Partition Key
        /// </summary>
        string ContainerKey { get; }
        /// <summary>
        /// Primary Key of the item. For example, it should be the Azure Table Storage Row Key
        /// </summary>
        object Key { get; }
    }
}
