
using System;
using System.Collections.Generic;
using System.Text;

namespace Shares.Registry.Abstraction.Database.Structure
{
    public class Property
    {
        public Property(string name, object value)
        {
            Name = name;
            Value = value;
        }
        public string Name { get; }
        public object Value { get; }
    }
}
