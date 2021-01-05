using Shares.Registry.Business.CapitalGain.Data.TransferObjects;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shares.Registry.Business.Shares.Data.Interfaces
{
    public interface ISharesDataReader
    {
        Task<IEnumerable<Share>> GetSharesAsync();
        Task<IEnumerable<Share>> GetSharesAsync(string shareName, DateTime? from, DateTime? to);
    }
    public static class ISharesDataReaderExtensions 
    {
        public static async Task<IEnumerable<Share>> GetSharesAsync(this ISharesDataReader sharesDataReader, DateTime from, DateTime to)
            => await sharesDataReader.GetSharesAsync(null, from, to);
    }
}