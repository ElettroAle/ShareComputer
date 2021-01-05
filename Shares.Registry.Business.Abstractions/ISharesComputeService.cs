
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shares.Registry.Business.Abstractions
{
    public interface ISharesComputeService
    {
        Task<string> ComputeAsync();
    }
}
