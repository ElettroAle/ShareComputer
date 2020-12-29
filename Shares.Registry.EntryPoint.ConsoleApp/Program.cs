using Shares.Registry.Abstractions.App.Builder;
using Shares.Registry.EntryPoint.ConsoleApp.App;

using System.Threading.Tasks;

namespace Shares.Registry.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
            => await new DefaultAppBuilder()
                .ConfigureServiceProvider(args)
                .Build<MainApp>()
                .RunAsync();
    }
}
