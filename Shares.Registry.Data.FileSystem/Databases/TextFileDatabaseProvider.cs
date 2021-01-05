
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Shares.Registry.Data.FileSystem.Interfaces;
using AutoMapper;
using Shares.Registry.Business.Data.Configuration;
using Microsoft.Extensions.Configuration;
using Shares.Registry.Business.Abstractions.DataPlugins.Interfaces;
using Shares.Registry.Business.Abstractions.DataPlugins.TransferObjects;

namespace Shares.Registry.Data.FileSystem.Databases
{
    public class TextFileDatabaseProvider : ISharesDataReader, ISharesDataWriter
    {
        private readonly string DatabasePath;
        private readonly IMapper mapper;
        private readonly ITenantDataReader tenantDataReader;

        public TextFileDatabaseProvider(IConfiguration configuration, IMapper mapper, ITenantDataReader tenantDataReader)
        {
            this.tenantDataReader = tenantDataReader;
            this.mapper = mapper;
            AppSettings.PutConfigurationsInChache(configuration);
            DatabasePath = $"{AppDomain.CurrentDomain.BaseDirectory}\\{AppSettings.Instance.FileSystem.DatabasePath}\\{tenantDataReader.GetTenantId()}";
            if (!Directory.Exists(DatabasePath))
            {
                Directory.CreateDirectory(DatabasePath);
            }
        }

        #region Reader
        public async Task<IEnumerable<Share>> GetSharesAsync() 
            => await GetSharesFromFolderAsync(GetTablePath(nameof(AccessObjects.Share)));
        public async Task<IEnumerable<Share>> GetSharesAsync(string companyName, DateTime? from, DateTime? to)
            // TODO: effettuare il controllo della data
            => await GetSharesFromFolderAsync(GetCompanyPath(nameof(AccessObjects.Share), companyName));
        #endregion

        #region Writer
        public async Task DeleteSharesAsync(IEnumerable<Share> shares = null)
        {
            if (!shares?.Any() ?? true)
            {
                await Task.Run(() => Directory.Delete(GetTablePath(nameof(AccessObjects.Share)), true));
            }
            else
            {
                await Task.WhenAll(shares
                    .Select(share => Task.Run(() => Directory.Delete(GetCompanyPath(nameof(AccessObjects.Share), share.Name), true))));
            }
        }
        public async Task AddSharesAsync(IEnumerable<Share> sharePurchases)
        {
            IEnumerable<AccessObjects.Share> dataAccessSharesPurchases = sharePurchases
                .Select((sharePurchaseDTO) => {
                    AccessObjects.Share sharePurchaseDAO = mapper.Map<AccessObjects.Share>(sharePurchaseDTO);
                    return sharePurchaseDAO;
                });
            string tablePath = GetTablePath(nameof(AccessObjects.Share));
            IEnumerable<Task> tasks = dataAccessSharesPurchases.Select(dao => dao.WriteAsync(tablePath));
            await Task.WhenAll(tasks);
        }
        #endregion

        #region Private
        private async Task<IEnumerable<Share>> GetSharesFromFolderAsync(string folderPath) 
            => (await Task.WhenAll(
                GetFileNamesFromFolder(folderPath)
                    .Select(fileName
                        => File.ReadAllTextAsync(fileName))))
            .Select(file => JsonSerializer
            .Deserialize<Share>(file));
        private string[] GetFileNamesFromFolder(string folderPath) => Directory.GetFiles(folderPath, "*.json", SearchOption.AllDirectories);

        private string GetTablePath(string tableName) => $"{DatabasePath}\\{tableName}";
        private string GetCompanyPath(string tableName, string partitionKey) => $"{GetTablePath(tableName)}\\{partitionKey}";
        #endregion
    }
}
