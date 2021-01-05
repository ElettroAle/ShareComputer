using Shares.Registry.Business.Financials.Data.TransferObjects;

using System;
using System.Collections.Generic;
using System.Text;

namespace Shares.Registry.Business.Financials.Data.Interfaces
{
    public interface IFinancialDataReader
    {
        public IEnumerable<Financial> GetBankRecords();
        public IEnumerable<Financial> GetBankRecords(DateTime from, DateTime to);
    }
}
