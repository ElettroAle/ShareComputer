using Shares.Registry.Abstractions.Mvvm.Model;
using Shares.Registry.Database.FileSystem;

using System;
using System.Collections.Generic;
using System.Text;

namespace Shares.Registry.Test.Abstractions.Context
{
    public class ContextFactory
    {
        public IContext GetContext() => new FileSystemContext();
    }
}
