using Share.Registry.Database.FileSystem;

using Shares.Registry.Abstractions.Mvvm.Model;
using Shares.Registry.Test.Abstractions.Context;
using Shares.Registry.Test.Abstractions.Mock;

using System;
using System.Collections.Generic;
using System.Text;

using Xunit;

namespace Shares.Registry.Test.XUnit.Mvvm.Fixture
{
    public class FixtureContext : IDisposable
    {
        public MockManager MockManager;
        public ContextFactory ContextFactory;
        public FixtureContext()  
        {
            // Prepare the context for the Class Fixture
            MockManager = new MockManager();
            ContextFactory = new ContextFactory();
        }
        public void Dispose()
        {
            // Clean context
        }
    }
}
