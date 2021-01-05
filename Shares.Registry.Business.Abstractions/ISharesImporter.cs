
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shares.Registry.Business.Abstractions
{
    public interface ISharesImporter
    {
        Task ImportAsync();
        Task Clean();
    }
}
