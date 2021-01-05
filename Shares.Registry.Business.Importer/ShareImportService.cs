using Microsoft.Extensions.Logging;

using Shares.Registry.Business.Abstractions.DataPlugins.Interfaces;
using Shares.Registry.Business.Abstractions.DataPlugins.TransferObjects;
using Shares.Registry.Business.Abstractions.Interfaces;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shares.Registry.Business.Shares
{
    public class ShareImportService : IImportService
    {
        private readonly ISharesDataWriter dataWriter;
        private readonly ISharesDataReader dataReader;
        private readonly ILogger logger;

        public ShareImportService(ISharesDataWriter dataWriter, ISharesDataReader dataReader, ILogger logger)
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
                logger.LogTrace($"{sharePurchase.Serialize()}");
            }
            await dataWriter.AddSharesAsync(shares);
        }
    }
}
