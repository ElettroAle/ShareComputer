using Shares.Registry.Abstractions.Mvvm.Model;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Share.Registry.Database.Models.Containers
{
    /// <summary>
    /// Models the database container. Is a mix of IQuerable and IEnumerable. Honestly speaking, I don't know if i need it, probably a simple List is enough
    /// </summary>
    public class Container<TItem> : ICollection<TItem> where TItem : IItem, new()
    {
        private readonly ICollection<TItem> Items = new List<TItem>();
        private IQueryable<TItem> QuerableItems => Items.AsQueryable();
        public Container(string name = "")
        {
            ElementType = typeof(IItem);
            Name = string.IsNullOrWhiteSpace(name) ? ElementType.Name : name;
        }

        public string Name { get; set; }
        public Type ElementType { get; }
        public Expression Expression => QuerableItems.Expression;
        public IQueryProvider Provider => QuerableItems.Provider;
        public int Count => Items.Count;
        public bool IsReadOnly => Items.IsReadOnly;

        public void Add(TItem item) => Items.Add(item);
        public void Add(IItem item) => this.Add(item);
        public bool Remove(TItem item) => Items.Remove(item);
        public void Clear() => Items.Clear();
        public bool Contains(TItem item) => Items.Contains(item);
        public void CopyTo(TItem[] array, int arrayIndex) => Items.CopyTo(array, arrayIndex);
        public IEnumerator<TItem> GetEnumerator() => Items.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
