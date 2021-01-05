
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shares.Registry.Business.Abstractions
{
    public interface ISharesImportService
    {
        Task ImportAsync();
        Task Clean();
    }
}
