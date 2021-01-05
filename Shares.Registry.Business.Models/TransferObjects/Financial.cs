
using System;
using System.Collections.Generic;
using System.Text;

namespace Shares.Registry.Business.Abstractions.DataPlugins.TransferObjects
{
    public class Financial : DTO
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
