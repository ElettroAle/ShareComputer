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
        private readonly IConfigurationBuilder ConfigurationBuilder = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
#if DEBUG
            .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
#endif
            .AddEnvironmentVariables();

        public IServiceCollection ServiceCollection { get; private set; } = new ServiceCollection();

        public IApp Build<TApp>() where TApp : class, IApp => ServiceCollection
            .AddSingleton<IConfiguration>(x => ConfigurationBuilder.Build())
            .AddLogging()
            .AddSingleton<ILogger, ConsoleLogger>()
            .AddSingleton<IApp, TApp>()
            .BuildServiceProvider().GetService<IApp>();

        public IAppBuilder ConfigureServiceProvider(Func<IServiceCollection, IServiceCollection> function)
        {
            ServiceCollection = function(ServiceCollection);
            return this;
        }
    }
}

