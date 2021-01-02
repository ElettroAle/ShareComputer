
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shares.Registry.Business.Computer.Interfaces
{
    public interface IComputeService
    {
        Task<double> ComputeAsync();
    }
}
