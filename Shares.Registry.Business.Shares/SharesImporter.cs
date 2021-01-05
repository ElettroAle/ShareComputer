using Microsoft.Extensions.Logging;

using Shares.Registry.Business.Abstractions;
using Shares.Registry.Business.CapitalGain.Data.TransferObjects;
using Shares.Registry.Business.Shares.Data.Interfaces;

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Shares.Registry.Business.CapitalGain
{
    public class SharesImporter : ISharesImporter
    {
        private readonly ISharesDataWriter dataWriter;
        private readonly ISharesDataReader dataReader;
        private readonly ILogger logger;

        public SharesImporter(ISharesDataWriter dataWriter, ISharesDataReader dataReader, ILogger logger)
        {
            this.dataWriter = dataWriter;
            this.dataReader = dataReader;
            this.logger = logger;
        }
        public async Task Clean() => await dataWriter.DeleteSharesAsync();
        public async Task ImportAsync()
        {
            var shares = await dataReader.GetSharesAsync();
            foreach (Share sharePurchase in shares)
            {
                logger.LogTrace($"{JsonSerializer.Serialize(sharePurchase)}");
            }
            await dataWriter.AddSharesAsync(shares);
        }
    }
}
