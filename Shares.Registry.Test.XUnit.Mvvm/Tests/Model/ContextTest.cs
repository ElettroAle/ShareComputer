using Shares.Registry.Abstractions.Mvvm.Model;
using Shares.Registry.Test.XUnit.Mvvm.Fixture;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;

namespace Shares.Registry.Test.XUnit.Mvvm.Tests.Model
{
    public class ContextTest : Abstractions.Test
    {
        public ContextTest(FixtureContext testFixture) : base(testFixture) { }

        [Fact]
        public void GetContainers() 
        {
            var database = MockManager.GetContextMock(true, true).Object;
            Assert.True(database.Containers.Any());
            foreach (string containerName in database.Containers.Select(x => x.Name)) 
            {
                Assert.True(database.GetContainer(containerName) != null);
            }
        }
        [Fact]
        public void GetContainersFromEmptyDb()
        {
            var database = MockManager.GetContextMock(false, true).Object;
            Assert.False(database.Containers.Any());
        }
    }
}
