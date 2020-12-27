using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Shares.Registry.EntryPoint.ConsoleApp.Abstractions;
using Shares.Registry.EntryPoint.ConsoleApp.App;
using Shares.Registry.EntryPoint.ConsoleApp.Logging;
using Shares.Registry.EntryPoint.ConsoleApp.Runtime;

using System;
using System.Collections.Generic;
using System.Text;

namespace Shares.Registry.EntryPoint.ConsoleApp.Builder
{
    public class DefaultAppBuilder : IAppBuilder
    {
        readonly IServiceCollection serviceCollection = new ServiceCollection();
        readonly IConfiguration configuration = new ConfigurationBuilder()
                //.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                //.AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

        public IApp Build() 
        {
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            serviceProvider.GetService<ILogger>().LogDebug("Starting Application");
            return serviceProvider.GetService<IApp>();
        }

        public IAppBuilder ConfigureServiceProvider(string[] args)
        {
            serviceCollection
                .AddLogging()
                .AddSingleton<ILogger, ConsoleLogger>()
                .AddSingleton<IApp, MainApp>();

            return this;
        }
    }
}
