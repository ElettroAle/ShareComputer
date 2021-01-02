using Shares.Registry.Business.Data.Interfaces;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shares.Registry.Business.Importer
{
    public class ImportService : IImportService
    {
        private readonly IDataWriter dataWriter;
        private readonly IDataReader dataReader;

        public ImportService(IDataWriter dataWriter, IDataReader dataReader)
        {
            this.dataWriter = dataWriter;
            this.dataReader = dataReader;
        }
        public async Task ImportSharesAsync()
        {
            var shares = await dataReader.GetAllSharesAsync();
            await dataWriter.SaveSharesAsync(shares);
        }
    }
}
