using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Text;

namespace Shares.Registry.Presentation.App.Logging
{
    internal class LoggerProvider : ILoggerProvider
    {
        private readonly IConfiguration configuration;
        public LoggerProvider(IConfiguration configuration) => this.configuration = configuration;

        public ILogger CreateLogger(string categoryName) => new ConsoleLogger(configuration);

        public void Dispose()
        {

        }
    }
}
