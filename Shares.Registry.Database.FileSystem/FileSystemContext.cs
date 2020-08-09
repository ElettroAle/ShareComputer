using Share.Registry.Database.Models;

using Shares.Registry.Abstractions.Mvvm.Model;

using System;
using System.Collections.Generic;

namespace Shares.Registry.Database.FileSystem
{
    public class FileSystemContext : Context
    {
        public FileSystemContext() 
        {
            // TODO: open connection to File System
        }
        public override void Dispose()
        {
            // TODO: close connectio to file System
        }
    }
}
