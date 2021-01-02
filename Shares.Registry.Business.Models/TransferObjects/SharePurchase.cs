
using Shares.Registry.Business.Data.Enumerator;

using System;

namespace Shares.Registry.Business.Data.TransferObjects
{
    public class SharePurchase
    {
        public string Name { get; set; }
        public OperationType OperationType { get; set; }
        public DateTime Timestamp { get; set; }
        public int Quantity { get; set; }
        public decimal UnitValue { get; set; }
    }
}
