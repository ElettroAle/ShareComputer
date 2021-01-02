using Shares.Registry.Business.Data.TransferObjects;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shares.Registry.Business.Data.Interfaces
{
    public interface IDataReader
    {
        Task<IEnumerable<SharePurchase>> GetAllSharesAsync();
    }
}