using Shares.Registry.Business.Financials.Data.TransferObjects;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shares.Registry.Business.Financials.Data.Interfaces
{
    public interface IFinancialDataWriter
    {
        Task AddFinancialAsync(IEnumerable<Financial> financials);
        Task RemoveFinancials(IEnumerable<Financial> financials);
        Task RemoveFinancials(DateTime fron, DateTime to);
    }
}
