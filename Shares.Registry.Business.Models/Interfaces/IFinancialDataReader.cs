using Shares.Registry.Business.Abstractions.DataPlugins.TransferObjects;

using System;
using System.Collections.Generic;
using System.Text;

namespace Shares.Registry.Business.Abstractions.DataPlugins.Interfaces
{
    public interface IFinancialDataReader
    {
        public IEnumerable<Financial> GetBankRecords();
        public IEnumerable<Financial> GetBankRecords(DateTime from, DateTime to);
    }
}
