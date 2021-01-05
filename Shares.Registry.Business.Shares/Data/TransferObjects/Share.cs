using Shares.Registry.Business.Shares.Data.Enumerator;

using System;

namespace Shares.Registry.Business.CapitalGain.Data.TransferObjects
{
    public class Share
    {
        public string Name { get; set; }
        public OperationType OperationType { get; set; }
        public DateTime Timestamp { get; set; }
        public int Quantity { get; set; }
        public decimal UnitValue { get; set; }
    }
}
