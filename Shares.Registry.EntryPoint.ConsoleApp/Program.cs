using Shares.Registry.Presentation.App.Builder;

using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using Shares.Registry.Presentation.ConsoleApp.App;
using Shares.Registry.Business.Computer;
using Shares.Registry.Business.Computer.Interfaces;
using Shares.Registry.Business.Data.Interfaces;
using Shares.Registry.Presentation.App;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Shares.Registry.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IAppBuilder appBuilder = new DefaultAppBuilder();

            await appBuilder
                .ConfigureServiceProvider(serviceCollection => serviceCollection
                    .AddSingleton<IDataReader, Data.FileSystem.Generators.SharePurchaseGenerator>()
                    .AddSingleton<IDataWriter, Data.FileSystem.Databases.TextFileDatabase>()
                    .AddSingleton<IComputeService, ComputeService>())
                .Build<DummyDatabaseFillerApp>().RunAsync(args);

            await appBuilder
                .ConfigureServiceProvider(serviceCollection => serviceCollection
                    .RemoveAll<IDataReader>()
                    .AddSingleton<IDataReader, Data.FileSystem.Databases.TextFileDatabase>())
                .Build<ComputeApp>().RunAsync(args);
        }
    }
}
