using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Text;

namespace Shares.Registry.EntryPoint.ConsoleApp.Logging
{
    class LoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new ConsoleLogger();
        }

        public void Dispose()
        {

        }
    }
}
