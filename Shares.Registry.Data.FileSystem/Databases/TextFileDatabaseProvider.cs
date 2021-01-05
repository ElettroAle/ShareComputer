
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
using Shares.Registry.Business.Tenant.Data.Interfaces;
using Shares.Registry.Business.Shares.Data.Interfaces;
using Shares.Registry.Business.CapitalGain.Data.TransferObjects;

namespace Shares.Registry.Data.FileSystem.Databases
{
    public class TextFileDatabaseProvider : ISharesDataReader, ISharesDataWriter
    {
        private readonly string DatabasePath;
        private readonly IMapper mapper;

        public TextFileDatabaseProvider(IConfiguration configuration, IMapper mapper, ITenantDataReader tenantDataReader)
        {
            this.mapper = mapper;
            AppSettings.PutConfigurationsInChache(configuration);
            DatabasePath = $"{AppDomain.CurrentDomain.BaseDirectory}{AppSettings.Instance.FileSystem.DatabasePath}\\{tenantDataReader.GetTenantId()}";
            if (!Directory.Exists(DatabasePath))
            {
                Directory.CreateDirectory(DatabasePath);
            }
        }

        #region Reader
        public async Task<IEnumerable<Share>> GetSharesAsync()
        {
            return await GetSharesFromFolderAsync(new AccessObjects.Share().GetTablePath(DatabasePath));
        }
        public async Task<IEnumerable<Share>> GetSharesAsync(string companyName, DateTime? from, DateTime? to)
        {
            if (from == null || string.IsNullOrWhiteSpace(companyName))
            {
                AccessObjects.Share share = new AccessObjects.Share() { Name = companyName };
                string path = share.GetTablePath(DatabasePath);
                return await GetSharesFromFolderAsync(path);
            }
            else
            {
                List<Task<IEnumerable<Share>>> tasks = new List<Task<IEnumerable<Share>>>();
                to ??= DateTime.UtcNow.Date;
                for (int i = 0; i < (to.Value-from.Value).TotalDays ; i++)
                {
                    AccessObjects.Share share = new AccessObjects.Share()
                    {
                        Name = companyName,
                        Timestamp = from.Value.AddDays(i)
                    };
                    string path = share.GetCompanyByDayPath(DatabasePath);
                    tasks.Add(GetSharesFromFolderAsync(path));
                }
                return (await Task.WhenAll(tasks)).SelectMany(x => x);
            }
        }
        #endregion

        #region Writer
        public async Task DeleteSharesAsync(IEnumerable<Share> shares = null)
        {
            if (!shares?.Any() ?? true)
            {
                await Task.Run(() =>
                {
                    string path = new AccessObjects.Share().GetTablePath(DatabasePath);
                    if (Directory.Exists(path)) Directory.Delete(path, true);
                });
            }
            else
            {
                await Task.WhenAll(
                    shares.Select(share => Task.Run(() => 
                    {
                        string sharePath = mapper.Map<Share, AccessObjects.Share>(share).GetCompanyByDayPath(DatabasePath);
                        if (Directory.Exists(sharePath)) Directory.Delete(sharePath, true);
                    })
                ));
            }
        }
        public async Task AddSharesAsync(IEnumerable<Share> sharePurchases)
        {
            IEnumerable<AccessObjects.Share> dataAccessSharesPurchases = sharePurchases
                .Select((sharePurchaseDTO) => {
                    AccessObjects.Share sharePurchaseDAO = mapper.Map<AccessObjects.Share>(sharePurchaseDTO);
                    return sharePurchaseDAO;
                });
            string tablePath = new AccessObjects.Share().GetTablePath(DatabasePath);
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

        #endregion
    }
}
