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
        public static async Task WriteAsync<TFileSystemEntity>(this TFileSystemEntity fileSystemEntity, string tablePath) where TFileSystemEntity : IFileSystemEntity
        {
            string folder = fileSystemEntity.GetFolder(tablePath);
            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
            await File.WriteAllTextAsync(fileSystemEntity.GetFilePath(tablePath), JsonSerializer.Serialize(fileSystemEntity));
        }
        private static string GetFilePath(this IFileSystemEntity fileSystemEntity, string tablePath) 
            => $"{fileSystemEntity.GetFolder(tablePath)}/{fileSystemEntity.GetFileName()}";
        private static string GetFolder(this IFileSystemEntity fileSystemEntity, string tablePath) 
            => $"{tablePath}/{fileSystemEntity.PartitionKey}";
        private static string GetFileName(this IFileSystemEntity fileSystemKey)
            => $"{fileSystemKey.PrimaryKey}.json";
    }
}
