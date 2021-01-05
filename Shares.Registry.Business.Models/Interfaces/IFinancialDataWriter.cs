using Shares.Registry.Business.Abstractions.DataPlugins.TransferObjects;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shares.Registry.Business.Abstractions.DataPlugins.Interfaces
{
    public interface IFinancialDataWriter
    {
        Task AddFinancialAsync(IEnumerable<Financial> financials);
        Task RemoveFinancials(IEnumerable<Financial> financials);
        Task RemoveFinancials(DateTime fron, DateTime to);
    }
}
