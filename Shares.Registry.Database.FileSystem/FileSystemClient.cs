using Share.Registry.Database.Models;

using Shares.Registry.Abstractions.Connections;
using Shares.Registry.Abstractions.Mvvm.Model;

using System;
using System.Collections.Generic;

namespace Shares.Registry.Database.FileSystem
{
    public class FileSystemClient : IDatabaseClient
    {
        public bool IsOpen => throw new NotImplementedException();

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IDatabaseClient Open()
        {
            throw new NotImplementedException();
        }
    }
}
