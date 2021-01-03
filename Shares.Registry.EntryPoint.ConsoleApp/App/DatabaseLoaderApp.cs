using Microsoft.Extensions.Logging;

using Shares.Registry.Business.Data.Interfaces;
using Shares.Registry.Business.Importer.Interfaces;
using Shares.Registry.Presentation.App;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shares.Registry.Presentation.Console.App
{
    public class DatabaseLoaderApp : IApp
    {
        private readonly IImportService importService;
        private readonly IDataWriter dataWriter;
        private readonly ILogger logger;

        public DatabaseLoaderApp(IImportService importService, IDataWriter dataWriter, ILogger logger)
        {
            this.importService = importService;
            this.dataWriter = dataWriter;
            this.logger = logger;
        }

        public async Task RunAsync(object[] args)
        {
            logger.LogInformation("Press D to delete, any key to populate:\n");
            if (System.Console.ReadKey().Key != ConsoleKey.D)
            {
                logger.LogDebug("\nPopulating database using random objects");
                await importService.ImportSharesAsync();
            }
            else 
            {
                logger.LogDebug("\nDeleting all database entries");
                await dataWriter.DeleteAllSharesAsync();
            }
            logger.LogDebug("Done");
        }
    }
}
