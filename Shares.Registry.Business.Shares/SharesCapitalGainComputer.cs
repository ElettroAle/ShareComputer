using Shares.Registry.Business.Abstractions;
using Shares.Registry.Business.CapitalGain.Data.TransferObjects;
using Shares.Registry.Business.Shares.Data.Enumerator;
using Shares.Registry.Business.Shares.Data.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shares.Registry.Business.CapitalGain
{
    public class SharesCapitalGainComputer : ICapitalGainComputer
    {
        private readonly ISharesDataReader sharesDataReader;
        private readonly ISharesDataWriter dataWriter;

        public SharesCapitalGainComputer(ISharesDataReader sharesDataReader, ISharesDataWriter dataWriter)
        {
            this.sharesDataReader = sharesDataReader;
            this.dataWriter = dataWriter;
        }
        public async Task ComputeAsync(int year, int month)
        {
            DateTime from = new DateTime(year, month, 1);
            DateTime to = from.AddMonths(1).AddDays(-1);
            IEnumerable<Share> shares = await sharesDataReader.GetSharesAsync(from, to);
            IEnumerable<IGrouping<string, Share>> saleGroups = shares.Where(x => x.OperationType == OperationType.Sale).GroupBy(x => x.Name);
            
            foreach (IGrouping<string, Share> saleGroup in saleGroups)
            {
                IEnumerable<Share> purchases = (await sharesDataReader.GetSharesAsync(saleGroup.Key, from, to)).Where(x => x.OperationType == OperationType.Purchase);
                while (saleGroup.Count() < purchases.Count() || from.Year <= 2018) 
                {
                    await sharesDataReader.GetSharesAsync(from, to);
                }
                if (saleGroup.Count() < purchases.Count())
                {
                    throw new Exception("Not enough purchases in database");
                }
                else 
                {
                    // TODO: fare il calcolo e presentare i risultati
                }
            }
            
        }
    }
}
