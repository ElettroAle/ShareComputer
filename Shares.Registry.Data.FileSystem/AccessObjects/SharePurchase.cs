using Shares.Registry.Business.Data.TransferObjects;
using Shares.Registry.Data.FileSystem.Interfaces;

using System;
using System.Collections.Generic;
using System.Text;

namespace Shares.Registry.Data.FileSystem.AccessObjects
{
    internal class SharePurchase : Business.Data.TransferObjects.SharePurchase, IFileSystemEntity
    {
        public string PartitionKey => this.Name;
        public string PrimaryKey => $"{this.Timestamp.Ticks}-{Guid.NewGuid()}";
    }
}