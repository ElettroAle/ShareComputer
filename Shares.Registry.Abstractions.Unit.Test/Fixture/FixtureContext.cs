using Bogus;

using Shares.Registry.Test.Abstractions.Mock;

using System;
using System.Collections.Generic;

namespace Shares.Registry.Abstractions.Unit.Test.Fixture
{
    public sealed class FixtureContext : IDisposable
    {
        public MockManager MockManager { get; }
        public FixtureContext()
        {
            // Prepare the context for the Class Fixture
            MockManager = new MockManager();
        }
        public void Dispose()
        {
            // Clean context
        }
    }
}
