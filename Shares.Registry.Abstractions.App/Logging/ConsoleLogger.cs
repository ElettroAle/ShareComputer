using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Text;

namespace Shares.Registry.Presentation.App.Logging
{
    internal class ConsoleLogger : ILogger
    {
        private readonly IConfiguration configuration;
        public ConsoleLogger(IConfiguration configuration) => this.configuration = configuration;

        public IDisposable BeginScope<TState>(TState state) => null;
        public bool IsEnabled(LogLevel logLevel) => true;
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            Console.ResetColor();
            switch (logLevel)
            {
                default:
                case LogLevel.Trace:
                case LogLevel.None:
                    break;
                case LogLevel.Debug:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                case LogLevel.Information:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case LogLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogLevel.Critical:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
            }
            if (exception != null) Console.WriteLine(exception.ToString());
            else Console.WriteLine(state.ToString());
            Console.ResetColor();
        }
    }
}
