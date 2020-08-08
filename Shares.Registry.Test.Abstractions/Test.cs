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
        protected MockManager MockManager { get; }
        public Test(FixtureContext testFixture) 
            => MockManager = testFixture.MockManager;
    }
}
