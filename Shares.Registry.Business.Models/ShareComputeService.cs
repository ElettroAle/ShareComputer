using Shares.Registry.Business.Abstractions;
using Shares.Registry.Business.Shares.Data.Interfaces;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shares.Registry.Business.Shares
{
    public class ShareComputeService : ISharesComputeService
    {
        private readonly ISharesDataReader sharesDataReader;
        private readonly ISharesDataWriter dataWriter;

        public ShareComputeService(ISharesDataReader sharesDataReader, ISharesDataWriter dataWriter)
        {
            this.sharesDataReader = sharesDataReader;
            this.dataWriter = dataWriter;
        }

        public Task<string> ComputeAsync()
        {
            // TODO: implementare
            throw new NotImplementedException();
        }
    }
}
