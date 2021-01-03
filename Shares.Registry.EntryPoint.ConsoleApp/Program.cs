using Shares.Registry.Presentation.App.Builder;

using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using Shares.Registry.Business.Data.Interfaces;
using Shares.Registry.Presentation.App;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Shares.Registry.Data.Fake.Generators;
using Shares.Registry.Business.Importer.Interfaces;
using Shares.Registry.Business.Importer;
using Shares.Registry.Business.Computer.Interfaces;
using Shares.Registry.Business.Computer;
using Microsoft.Extensions.Configuration;
using Shares.Registry.Presentation.Console.App;

namespace Shares.Registry.Presentation.Console
{
    class Program
    {
        static async Task Main(string[] args)
            => await new DefaultAppBuilder()
                .ConfigureServiceProvider(serviceCollection => serviceCollection
                    .AddTextFileDatabaseWriter()
                    .AddSingleton<IDataReader, FakeSharePurchaseGenerator>()
                    .AddSingleton<IImportService, ImportService>())
                .Build<DatabaseLoaderApp>()
                .RunAsync(args);
    }
}
