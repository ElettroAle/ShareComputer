using Shares.Registry.EntryPoint.ConsoleApp.Abstractions;

using System;
using System.Collections.Generic;
using System.Text;

namespace Shares.Registry.EntryPoint.ConsoleApp.Runtime
{
    public interface IAppBuilder
    {
        IAppBuilder ConfigureServiceProvider(string[] args);
        IApp Build();
    }
}
