using Shares.Registry.Business.Abstractions.DataPlugins.Interfaces;
using Shares.Registry.Business.Abstractions.Interfaces;

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
        private readonly ITenantDataReader tenantDataReader;

        public ShareComputeService(ISharesDataReader sharesDataReader, ISharesDataWriter dataWriter, ITenantDataReader tenantDataReader)
        {
            this.sharesDataReader = sharesDataReader;
            this.dataWriter = dataWriter;
            this.tenantDataReader = tenantDataReader;
        }

        public async Task<string> ComputeAsync()
        {
            
        }
    }
}
