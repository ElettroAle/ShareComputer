using Shares.Registry.Presentation.App.Builder;
using Shares.Registry.EntryPoint.ConsoleApp.App;

using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Shares.Registry.Abstractions.Business.Services;
using Shares.Registry.Business.Providers.Services;

namespace Shares.Registry.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
            => await new DefaultAppBuilder()
                .ConfigureServiceProvider(serviceCollection => serviceCollection.AddSingleton<IComputeService, ComputeService>())
                .Build<MainApp>()
                .RunAsync(args);
    }
}
