using Shares.Registry.Presentation.App.Builder;

using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using Shares.Registry.Presentation.App;
using Microsoft.Extensions.DependencyInjection.Extensions;

using Microsoft.Extensions.Configuration;
using Shares.Registry.Business.Importer.Interfaces;
using Shares.Registry.Business.Importer;
using Shares.Registry.Business.Computer.Interfaces;
using Shares.Registry.Business.Computer;
using Shares.Registry.Data.Fake.Generators;
using Shares.Registry.Business.Data.Interfaces;

namespace Shares.Registry.Presentation.Api
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IAppBuilder appBuilder = new DefaultAppBuilder();    
            await appBuilder.Build<ApiApp>().RunAsync(args);
        }
    }
}
