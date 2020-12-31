using Microsoft.Extensions.DependencyInjection;

using Shares.Registry.EntryPoint.ConsoleApp.Abstractions;

using System;
using System.Collections.Generic;
using System.Text;

namespace Shares.Registry.EntryPoint.ConsoleApp.Runtime
{
    public interface IAppBuilder
    {
        IApp Build<TApp>() where TApp : class, IApp;
        public IAppBuilder ConfigureServiceProvider(Func<IServiceCollection, IServiceCollection> func);
    }
}
