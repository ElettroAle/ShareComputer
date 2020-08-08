
using Share.Registry.Database.FileSystem.Entities;

using Shares.Registry.Abstractions.Enumerator;
using Shares.Registry.Abstractions.Mvvm.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shares.Registry.Mvvm.Models.Entities
{
    public class TableSharePurchase : Entity, IItem
    {
        public string Name { get; set; }
        public OperationType OperationType { get; set; }
        public DateTime Timestamp { get; set; }
        public int Quantity { get; set; }
        public decimal UnitValue { get; set; }
    }
}
