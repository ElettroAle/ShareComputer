using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using Shares.Registry.EntryPoint.ConsoleApp.Abstractions;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shares.Registry.EntryPoint.ConsoleApp.App
{
    class MainApp : IApp
    {
        private readonly ILogger logger; 
        public MainApp(ILogger logger) => this.logger = logger;
        public async Task RunAsync() => logger.LogInformation("Hello App");
    }
}
