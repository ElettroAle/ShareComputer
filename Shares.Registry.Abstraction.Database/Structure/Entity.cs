using Shares.Registry.Abstraction.Database.Structure;

using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Share.Registry.Database.FileSystem.Entities
{
    public abstract class Entity : IEntity
    {
        public object PrimaryKey { get; set; }
        public string PartitionKey { get; set; }

        // TODO: find a better way to get secondary properties
        IEnumerable<PropertyInfo> properties = null;
        public virtual IEnumerable<Property> GetProperties() 
        {
            if (properties == null) 
                properties = GetType().GetProperties();

            return properties.Select(x => new Property(x.Name, x.GetValue(this)));
        }
    }
}
