using Shares.Registry.EntryPoint.ConsoleApp.Builder;

using System;
using System.Threading.Tasks;

namespace Shares.Registry.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
            => await new DefaultAppBuilder().ConfigureServiceProvider(args).Build().RunAsync();

    }
}
