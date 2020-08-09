
using Shares.Registry.Abstractions.Mvvm.Model;
using Shares.Registry.Mvvm.Models.Entities;

using System;
using System.Collections.Generic;
using System.Text;

namespace Share.Registry.Database.Models
{
    /// <summary>
    /// Class used to design the database shape. Don't care about what type of Database you'll use
    /// </summary>
    public abstract class Context : IContext
    {
        protected Context()
        {
            // Containers Initialization
            Containers = new List<IContainer>() { };
        }

        public IEnumerable<IContainer> Containers { get; }
        public abstract void Dispose();
    }
}
