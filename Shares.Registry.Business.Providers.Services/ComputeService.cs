using Shares.Registry.Business.Computer.Interfaces;
using Shares.Registry.Business.Data.Interfaces;
using Shares.Registry.Business.Data.TransferObjects;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shares.Registry.Business.Computer
{
    public class ComputeService : IComputeService
    {
        private readonly IDataReader sharesDatabase;
        public ComputeService(IDataReader sharesDatabase) => this.sharesDatabase = sharesDatabase;
        public async Task<double> ComputeAsync() 
        {
            IEnumerable<SharePurchase> shares = await sharesDatabase.GetAllSharesAsync();
            return 0.0D;
        }
    }
}
