using Microsoft.Extensions.Logging;

using Shares.Registry.Business.Abstractions.Interfaces;
using Shares.Registry.Business.Data.Interfaces;
using Shares.Registry.Business.Data.TransferObjects;

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Shares.Registry.Business.Computer
{
    public class XmlComputeService : IComputeService
    {
        private readonly IDataReader sharesDatabase;
        private readonly ILogger logger;

        public XmlComputeService(IDataReader sharesDatabase, ILogger logger)
        {
            this.sharesDatabase = sharesDatabase;
            this.logger = logger;
        }

        public async Task<string> ComputeAsync() 
        {
            IEnumerable<SharePurchase> shares = await sharesDatabase.GetAllSharesAsync();
            return JsonSerializer.Serialize(shares);
        }
    }
}
