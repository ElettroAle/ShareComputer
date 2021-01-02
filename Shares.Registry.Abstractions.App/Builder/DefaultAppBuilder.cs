using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Shares.Registry.Presentation.App.Logging;

using System;
using System.Collections;
using System.Collections.Generic;

namespace Shares.Registry.Presentation.App.Builder
{
    public class DefaultAppBuilder : IAppBuilder
    {
        readonly IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
        public IServiceCollection ServiceCollection { get; private set; } = new ServiceCollection();

        public IApp Build<TApp>() where TApp : class, IApp
        {
            IServiceProvider serviceProvider = ServiceCollection
                .AddSingleton(x => configuration)
                .AddLogging()
                .AddSingleton<ILogger, ConsoleLogger>()
                .AddSingleton<TApp>()
                .BuildServiceProvider();
            serviceProvider
                .GetService<ILogger>()
                .LogDebug("Starting Application");
            return serviceProvider.GetService<IApp>();
        }

        public IAppBuilder ConfigureServiceProvider(Func<IServiceCollection, IServiceCollection> func)
        {
            ServiceCollection = func(ServiceCollection);
            return this;
        }
    }
}
