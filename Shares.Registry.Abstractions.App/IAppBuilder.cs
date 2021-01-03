using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Text;

namespace Shares.Registry.Presentation.App
{
    public interface IAppBuilder
    {
        IApp Build<TApp>() where TApp : class, IApp;
        public IAppBuilder ConfigureServiceProvider(Func<IServiceCollection, IServiceCollection> func);
    }
}
