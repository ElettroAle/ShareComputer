using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        private static readonly char[] separators = new[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar }; 
        public static async Task WriteAsync<TFileSystemEntity>(this TFileSystemEntity fileSystemEntity, string tablePath) where TFileSystemEntity : IFileSystemEntity
        {
            string folder = fileSystemEntity.GetFolder(tablePath);
            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
            await File.WriteAllTextAsync(fileSystemEntity.GetFilePath(tablePath), JsonSerializer.Serialize(fileSystemEntity));
        }
        private static string GetFilePath(this IFileSystemEntity fileSystemEntity, string tablePath) 
            => $"{fileSystemEntity.GetFolder(tablePath)}{Path.DirectorySeparatorChar}{fileSystemEntity.GetFileName()}";
        private static string GetFolder(this IFileSystemEntity fileSystemEntity, string tablePath) 
            => new StringBuilder(tablePath)
                .Append(Path.DirectorySeparatorChar)
                .Append(fileSystemEntity.PartitionKey)
                .Append(Path.DirectorySeparatorChar)
                .AppendJoin(Path.DirectorySeparatorChar, fileSystemEntity.PrimaryKey.Split(separators).SkipLast(1))
                .ToString();
        private static string GetFileName(this IFileSystemEntity fileSystemEntity)
        {
            string[] folderSegments = fileSystemEntity.PrimaryKey.Split(separators);
            return $"{folderSegments.Last()}.json";
        }
    }
}
