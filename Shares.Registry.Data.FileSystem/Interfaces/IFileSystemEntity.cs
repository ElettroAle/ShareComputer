using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Shares.Registry.Data.FileSystem.Interfaces
{
    internal interface IFileSystemEntity
    {
        string PartitionKey { get; }
        string PrimaryKey { get; }
    }
    internal static class IFileSystemKeyExtensions
    {
        public static async Task WriteAsync(this IFileSystemEntity fileSystemKey, string tablePath) 
            => await File.WriteAllTextAsync(fileSystemKey.GetFilePath(tablePath), JsonSerializer.Serialize(fileSystemKey));

        private static string GetFilePath(this IFileSystemEntity fileSystemEntity, string tablePath) 
            => $"{tablePath}/{fileSystemEntity.PartitionKey}/{fileSystemEntity.GetFileName()}.json";
        private static string GetFileName(this IFileSystemEntity fileSystemKey)
            => $"{fileSystemKey.PrimaryKey}";
    }
}
