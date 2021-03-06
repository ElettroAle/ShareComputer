﻿using Shares.Registry.Abstractions.Unit.Test.Fixture;
using Shares.Registry.Test.Abstractions.Mock;

using Xunit;

namespace Shares.Registry.Test.Abstractions
{
    [CollectionDefinition(nameof(FixtureContext))]
    public abstract class Test : ITest, ICollectionFixture<FixtureContext>
    {
        public FixtureContext TestFixture;
        public MockManager MockManager => TestFixture.MockManager;
        public Test(FixtureContext testFixture) => TestFixture = testFixture;
    }
}
