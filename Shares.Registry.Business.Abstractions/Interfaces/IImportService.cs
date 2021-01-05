
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shares.Registry.Business.Abstractions.Interfaces
{
    public interface IImportService
    {
        Task ImportAsync();
        Task Clean();
    }
}
