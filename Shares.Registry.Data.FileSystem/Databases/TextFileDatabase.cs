using Shares.Registry.Business.Data.Interfaces;
using Shares.Registry.Business.Data.TransferObjects;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Shares.Registry.Data.FileSystem.Interfaces;
using AutoMapper;
using Shares.Registry.Business.Data.Configuration;
using Microsoft.Extensions.Configuration;

namespace Shares.Registry.Data.FileSystem.Databases
{
    public class TextFileDatabase : IDataReader, IDataWriter
    {
        private readonly string DatabasePath;
        private readonly IMapper mapper;
        public TextFileDatabase(IConfiguration configuration, IMapper mapper)
        {
            AppSettings.PutConfigurationsInChache(configuration);
            DatabasePath = $"{AppDomain.CurrentDomain.BaseDirectory}\\{AppSettings.Instance.FileSystem.DatabasePath}";
            if (!Directory.Exists(DatabasePath))
            {
                Directory.CreateDirectory(DatabasePath);
            }
            this.mapper = mapper;
        }
        public async Task<IEnumerable<SharePurchase>> GetAllSharesAsync() => (await Task.WhenAll(
            Directory
                .GetFiles(GetTablePath(nameof(AccessObjects.SharePurchase)), "*.json", SearchOption.AllDirectories)
                .Select(fileName
                    => File
                        .ReadAllTextAsync(fileName))))
                            .Select(file => JsonSerializer
                            .Deserialize<SharePurchase>(file));

        public async Task DeleteAllSharesAsync() 
            => await Task.Run(() => Directory.Delete(DatabasePath, true));
        
        public async Task SaveSharesAsync(IEnumerable<SharePurchase> sharePurchases)
        {
            IEnumerable<AccessObjects.SharePurchase> dataAccessSharesPurchases = sharePurchases
                .Select((sharePurchaseDTO) => {
                    AccessObjects.SharePurchase sharePurchaseDAO = mapper.Map<AccessObjects.SharePurchase>(sharePurchaseDTO);
                    return sharePurchaseDAO;
                });
            string tablePath = GetTablePath(nameof(AccessObjects.SharePurchase));
            IEnumerable<Task> tasks = dataAccessSharesPurchases.Select(dao => dao.WriteAsync(tablePath));
            await Task.WhenAll(tasks);
        }
        private string GetTablePath(string tableName) => $"{DatabasePath}\\{tableName}";
    }
}
