using Shares.Registry.Test.XUnit.Mvvm.Fixture;

using System;
using System.Collections.Generic;
using System.Text;

using Xunit;
using System.Linq;

namespace Shares.Registry.Test.XUnit.Mvvm.Tests.Model
{
    public class ItemTest : Abstractions.Test
    {
        public ItemTest(FixtureContext testFixture) : base(testFixture) {}

        [Fact]
        public void GetProperties() 
        {
            IEnumerable<Registry.Abstractions.Mvvm.Model.Property> properties = MockManager.GetMockItem(true).Object.GetProperties();
            Assert.True(properties.Any());
            Assert.True(properties.Select(x => x.Value).All(x => x != null));
        }
    }
}
