using Shares.Registry.Abstractions.Mvvm.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Share.Registry.Database.FileSystem.Entities
{
    public abstract class Entity : IItem
    {


        public object Id { get; set; }
        public string Container { get; set; }

        // TODO: trovare un modo più elegante che non sia la reflection
        IEnumerable<PropertyInfo> properties = null;
        public virtual IEnumerable<Property> GetProperties() 
        {
            if (properties != null) 
                properties = GetType().GetProperties();

            return properties.Select(x => new Property(x.Name, x.GetValue(this)));
        }
    }
}
