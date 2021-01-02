using Shares.Registry.Business.Data.Interfaces;
using Shares.Registry.Business.Data.TransferObjects;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shares.Registry.Data.FileSystem.Generators
{
    public class SharePurchaseGenerator : IDataReader
    {
        public Task<IEnumerable<SharePurchase>> GetAllSharesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
