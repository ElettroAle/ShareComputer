using Shares.Registry.Data.FileSystem.Interfaces;

using System;
using System.Collections.Generic;
using System.Text;

namespace Shares.Registry.Data.FileSystem.AccessObjects
{
    internal class Share : Business.Abstractions.DataPlugins.TransferObjects.Share, IFileSystemEntity
    {
        public string PartitionKey => this.Name;
        public string PrimaryKey => $"{this.Timestamp.Date:yyyyMMdd}\\{Guid.NewGuid()}";
    }
}