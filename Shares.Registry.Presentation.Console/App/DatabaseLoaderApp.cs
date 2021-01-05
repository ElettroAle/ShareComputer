using Microsoft.Extensions.Logging;

using Shares.Registry.Business.Abstractions.Interfaces;
using Shares.Registry.Presentation.App;

using System;
using System.Threading.Tasks;

namespace Shares.Registry.Presentation.Console.App
{
    public class DatabaseLoaderApp : IApp
    {
        private readonly IImportService importService;
        private readonly ILogger logger;

        public DatabaseLoaderApp(IImportService importService, ILogger logger)
        {
            this.importService = importService;
            this.logger = logger;
        }

        public async Task RunAsync(object[] args)
        {
            logger.LogInformation("Press D to delete, any key to populate:\n");
            if (System.Console.ReadKey().Key != ConsoleKey.D)
            {
                logger.LogDebug("\nPopulating database using random objects");
                await importService.ImportAsync();
            }
            else 
            {
                logger.LogDebug("\nDeleting all database entries");
                await importService.Clean();
            }
            logger.LogDebug("Done");
        }
    }
}
