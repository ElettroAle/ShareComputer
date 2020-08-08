using Shares.Registry.Test.XUnit.Mvvm.Fixture;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;

namespace Shares.Registry.Test.XUnit.Mvvm.Tests.Model
{
    public class ContainerTest : Abstractions.Test
    {
        public ContainerTest(FixtureContext testFixture) : base(testFixture) { }

        [Fact]
        public void DoQuery() 
        {
            var container = MockManager.GetMockContainer(isEmpty: false).Object;
            Assert.True(container.DoQuery().Any());
        }
        [Fact]
        public void DoEmptyQuery()
        {
            var container = MockManager.GetMockContainer(isEmpty: true).Object;
            Assert.False(container.DoQuery().Any());
        }
    }
}
