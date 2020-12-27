
using Share.Registry.Database.FileSystem.Entities;

using Shares.Registry.Abstraction.Database.Structure;

using System;

namespace Shares.Registry.Mvvm.Models.Entities
{
    public class TableSharePurchase : Entity, IEntity
    {
        public string Name { get; set; }
        public int OperationType { get; set; }
        public DateTime Timestamp { get; set; }
        public int Quantity { get; set; }
        public decimal UnitValue { get; set; }
    }
}
