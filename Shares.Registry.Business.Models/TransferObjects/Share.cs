using Shares.Registry.Business.Abstractions.DataPlugins.Enumerator;

using System;

namespace Shares.Registry.Business.Abstractions.DataPlugins.TransferObjects
{
    public class Share : DTO
    {
        public string Name { get; set; }
        public OperationType OperationType { get; set; }
        public DateTime Timestamp { get; set; }
        public int Quantity { get; set; }
        public decimal UnitValue { get; set; }
    }
}
