using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Shares.Registry.Abstractions.App.Logging;
using Shares.Registry.EntryPoint.ConsoleApp.Abstractions;
using Shares.Registry.EntryPoint.ConsoleApp.Runtime;

using System;

namespace Shares.Registry.Abstractions.App.Builder
{
    public class DefaultAppBuilder : IAppBuilder
    {
        readonly IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
        readonly IServiceCollection serviceCollection = new ServiceCollection();

        public IApp Build<TApp>() where TApp : class, IApp
        {
            IServiceProvider serviceProvider = serviceCollection
                .AddSingleton<TApp>()
                .BuildServiceProvider();
            serviceProvider
                .GetService<ILogger>()
                .LogDebug("Starting Application");
            return serviceProvider.GetService<IApp>();
        }
        public virtual IAppBuilder ConfigureServiceProvider(string[] args)
        {
            serviceCollection
                .AddSingleton(x => configuration)
                .AddLogging()
                .AddSingleton<ILogger, ConsoleLogger>();
            return this;
        }
    }
}
