using Shares.Registry.Test.Abstractions.Context;
using Shares.Registry.Test.Abstractions.Mock;
using Shares.Registry.Test.XUnit.Mvvm.Fixture;

using System;
using System.Collections.Generic;
using System.Text;

using Xunit;

namespace Shares.Registry.Test.Abstractions
{
    public abstract class Test : ITest, IClassFixture<FixtureContext>
    {
        public FixtureContext TestFixture;
        public MockManager MockManager => TestFixture.MockManager;
        public Test(FixtureContext testFixture) => TestFixture = testFixture;
    }
}
