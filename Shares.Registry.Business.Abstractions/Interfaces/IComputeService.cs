
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shares.Registry.Business.Abstractions.Interfaces
{
    public interface IComputeService
    {
        Task<string> ComputeAsync();
    }
}
