using Share.Registry.Database.Models;

using Shares.Registry.Abstractions.Mvvm.Model;
using Shares.Registry.Database.FileSystem;

using System;

namespace Shares.Registry.Models
{
    public static class DatabaseFactory
    {
        public static Context GetContext() => new FileSystemContext();
    }
}
