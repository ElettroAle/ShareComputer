using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Shares.Registry.Presentation.App;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shares.Registry.Presentation.Api
{
    public class ApiApp : IApp
    {
        private readonly IConfiguration configuration;
        public ApiApp(IConfiguration configuration) => this.configuration = configuration;

        public async Task RunAsync(object[] args) => await CreateHostBuilder().Build().RunAsync();

        public IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(configuration => configuration.AddConfiguration(this.configuration))
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());

    }
}
