using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using Shares.Registry.Business.Computer.Interfaces;
using Shares.Registry.Presentation.App;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shares.Registry.Presentation.ConsoleApp.App
{
    class ComputeApp : IApp
    {
        private readonly ILogger logger;
        private readonly IComputeService computeService;

        public ComputeApp(IComputeService computeService, ILogger logger)
        {
            this.logger = logger;
            this.computeService = computeService;
        }
        public async Task RunAsync(object[] args)
        {
            // TODO: calcolare e presentare i risultati
            logger.LogInformation("Calculating Shares");
            var result = await computeService.ComputeAsync();
            logger.LogInformation($"Result = {result}");
        }
    }
}
