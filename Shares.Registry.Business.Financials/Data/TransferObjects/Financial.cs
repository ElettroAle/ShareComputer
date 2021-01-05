
using System;
using System.Collections.Generic;
using System.Text;

namespace Shares.Registry.Business.Financials.Data.TransferObjects
{
    public class Financial
    {
        public DateTime Timestamp { get; set; }
        public decimal Amount { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int Type { get; set; }
    }
}
