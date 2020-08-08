using Shares.Registry.Abstractions.Mvvm.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Share.Registry.Database.FileSystem.Entities
{
    public abstract class Entity : IItem
    {
        public IContainer Container { get; set; }
        public object Id { get; set; }
        public virtual IEnumerable<Property> GetProperties()
            => GetType().GetProperties().Select(x => new Property(x.Name, x.GetValue(this)));
    }
}
