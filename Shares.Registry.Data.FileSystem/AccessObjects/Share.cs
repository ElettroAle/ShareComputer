using Shares.Registry.Data.FileSystem.Interfaces;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Shares.Registry.Data.FileSystem.AccessObjects
{
    internal class Share : Business.CapitalGain.Data.TransferObjects.Share, IFileSystemEntity
    {
        public string PartitionKey => $"{this.Name}{Path.DirectorySeparatorChar}{this.Timestamp.Date:yyyyMMdd}";
        public string PrimaryKey => Guid.NewGuid().ToString();

        public string GetCompanyPath(string databasePath)
            => $"{this.GetTablePath(databasePath)}\\{this.Name}";
        public string GetCompanyByDayPath(string databasePath)
            => $"{this.GetTablePath(databasePath)}\\{this.PartitionKey}";
    }
}