
using System;

namespace Shares.Registry.Business.Data.TransferObjects
{
    public class SharePurchase
    {
        public string Name { get; set; }
        public int OperationType { get; set; }
        public DateTime Timestamp { get; set; }
        public int Quantity { get; set; }
        public decimal UnitValue { get; set; }
    }
}
