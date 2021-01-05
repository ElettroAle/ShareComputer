using Shares.Registry.Presentation.App.Builder;

using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using Shares.Registry.Presentation.Console.App;
using Shares.Registry.Business.Abstractions.Interfaces;
using Shares.Registry.Business.Shares;
using Shares.Registry.Business.Abstractions.DataPlugins.Interfaces;
using Shares.Registry.Data.Fake.Providers;

namespace Shares.Registry.Presentation.Console
{
    class Program
    {
        static async Task Main(string[] args)
            => await new DefaultAppBuilder()
                .ConfigureServiceProvider(serviceCollection => serviceCollection
                    .AddSingleton<ITenantDataReader, TestTenantService>()
                    .AddFakeDataReader()
                    .AddTextFileDataWriter()
                    .AddSingleton<IImportService, ImportService>())
                .Build<DatabaseLoaderApp>()
                .RunAsync(args);
    }
}
