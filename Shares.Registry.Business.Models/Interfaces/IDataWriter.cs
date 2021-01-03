using Shares.Registry.Business.Data.TransferObjects;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shares.Registry.Business.Data.Interfaces
{
    public interface IDataWriter
    {
        Task SaveSharesAsync(IEnumerable<SharePurchase> sharePurchases);
        Task DeleteAllSharesAsync();
    }
}
