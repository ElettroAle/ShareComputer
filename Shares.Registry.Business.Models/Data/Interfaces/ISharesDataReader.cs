using Shares.Registry.Business.Abstractions.DataPlugins.TransferObjects;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shares.Registry.Business.Shares.Data.Interfaces
{
    public interface ISharesDataReader
    {
        Task<IEnumerable<Share>> GetSharesAsync();
        Task<IEnumerable<Share>> GetSharesAsync(string shareName, DateTime? from, DateTime? to);
    }
}