using Shares.Registry.Abstraction.Database.Connections;
using Shares.Registry.Abstraction.Database.Structure;

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;

namespace Share.Registry.Database.Models.Containers
{
    /// <summary>
    /// Models the database container. It's a mix of IQuerable and IEnumerable interfaces. Honestly speaking, I don't know if i need it, probably a simple List is enough
    /// </summary>
    public class Container<TItem> : Shares.Registry.Abstraction.Database.Structure.IContainer where TItem : IEntity, new()
    {

        private IDataReader Reader { get; }
        public Container(IDataReader reader, string name = "")
        {
            Reader = reader;
            Name = string.IsNullOrWhiteSpace(name) ? ElementType.Name : name;
        }

        public string Name { get; }
        public Type ElementType => typeof(TItem);
        // TODO: assign expression
        public Expression Expression { get; private set; }
        public IQueryProvider Provider => Reader;

        public IEnumerator<IEntity> GetEnumerator() => (Provider.Execute<IEnumerable<IEntity>>(Expression)).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => (Provider.Execute<IEnumerable<TItem>>(Expression)).GetEnumerator();
    }
}
