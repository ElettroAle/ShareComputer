using Shares.Registry.Presentation.App.Builder;

using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using Shares.Registry.Presentation.ConsoleApp.App;
using Shares.Registry.Business.Data.Interfaces;
using Shares.Registry.Presentation.App;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Shares.Registry.Data.Fake.Generators;
using Shares.Registry.Business.Importer.Interfaces;
using Shares.Registry.Business.Importer;

namespace Shares.Registry.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IAppBuilder appBuilder = new DefaultAppBuilder();

            // Database filler
            await appBuilder
                .ConfigureServiceProvider(serviceCollection => serviceCollection
                    .AddSingleton<IDataReader, FakeSharePurchaseGenerator>()
                    .AddTextFileDatabaseWriter()
                    .AddSingleton<IImportService, ImportService>())
                .Build<DummyDatabaseFillerApp>()
                .RunAsync(args);

            // Computer
            await appBuilder
                .ConfigureServiceProvider(serviceCollection => serviceCollection
                    .AddTextFileDatabaseReader())
                .Build<ComputeApp>()
                .RunAsync(args);
        }
    }
}
