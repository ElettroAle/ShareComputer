using Microsoft.Extensions.Logging;

using Shares.Registry.Business.Importer.Interfaces;
using Shares.Registry.Presentation.App;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shares.Registry.Presentation.ConsoleApp.App
{
    public class DummyDatabaseFillerApp : IApp
    {
        private readonly IImportService importService;
        private readonly ILogger logger;

        public DummyDatabaseFillerApp(IImportService importService, ILogger logger)
        {
            this.importService = importService;
            this.logger = logger;
        }

        public async Task RunAsync(object[] args)
        {
            logger.LogInformation("Populating database using random objects");
            await importService.ImportSharesAsync();
            logger.LogInformation("Done");
        }
    }
}
