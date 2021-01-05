using Shares.Registry.Business.Abstractions.DataPlugins.TransferObjects;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shares.Registry.Business.Shares.Data.Interfaces
{
    public interface ISharesDataWriter
    {
        Task AddSharesAsync(IEnumerable<Share> shares);
        Task DeleteSharesAsync(IEnumerable<Share> shares = null);
    }
}
