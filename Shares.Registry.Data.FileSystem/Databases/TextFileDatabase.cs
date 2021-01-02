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

namespace Shares.Registry.Data.FileSystem.Databases
{
    public class TextFileDatabase : IDataReader, IDataWriter
    {
        private static readonly string DatabasePath = AppDomain.CurrentDomain.BaseDirectory + "\\database";
        private readonly IMapper mapper;
        static TextFileDatabase() 
        {
            if (!Directory.Exists(DatabasePath))
            {
                Directory.CreateDirectory(DatabasePath);
            }
        }
        public TextFileDatabase(IMapper mapper)
        {
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

        public async Task SaveSharesAsync(IEnumerable<SharePurchase> sharePurchases)
        {
            // todo: mapper
            IEnumerable<AccessObjects.SharePurchase> dataAccessSharesPurchases = sharePurchases
                .Select((sharePurchaseDTO) => {
                    AccessObjects.SharePurchase sharePurchaseDAO = mapper.Map<AccessObjects.SharePurchase>(sharePurchaseDTO);
                    return sharePurchaseDAO;
                });
            string tablePath = GetTablePath(nameof(AccessObjects.SharePurchase));
            IEnumerable<Task> tasks = dataAccessSharesPurchases.Select(dao => dao.WriteAsync(tablePath));
            await Task.WhenAll(tasks);
        }
        private static string GetTablePath(string tableName) => $"{DatabasePath}\\{tableName}";
    }
}
