using Shares.Registry.Presentation.App.Builder;

using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using Shares.Registry.Presentation.Console.App;
using Shares.Registry.Data.Fake.Providers;
using Shares.Registry.Business.Tenant.Data.Interfaces;
using Shares.Registry.Business.Abstractions;
using Shares.Registry.Business.CapitalGain;

namespace Shares.Registry.Presentation.Console
{
    class Program
    {
        static async Task Main(string[] args)
            => await new DefaultAppBuilder()
                .ConfigureServiceProvider(serviceCollection => serviceCollection
                    .AddSingleton<ITenantDataReader, TestTenantService>()
                    .AddFakeShareGenerator()
                    .AddTextFileDataWriter()
                    .AddSingleton<ISharesImporter, SharesImporter>())
                .Build<DatabaseLoaderApp>()
                .RunAsync(args);
    }
}
