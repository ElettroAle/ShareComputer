using Shares.Registry.Abstractions.Mvvm.Model;
using Shares.Registry.Models;
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
        public void GetContextFromFactory() 
        {
            Assert.True(DatabaseFactory.GetContext() != null);
        }

        [Fact]
        public void GetContainers() 
        {
            var database = MockManager.GetMockContext(true, "TestContainer").Object;
            Assert.True(database.Containers.Any());
            foreach (string containerName in database.Containers.Select(x => x.Name)) 
            {
                Assert.True(database.GetContainer(containerName) != null);
            }
        }
        [Fact]
        public void GetEmptyContainer()
        {
            var database = MockManager.GetMockContext(false, "TestContainers").Object;
            var container = database.GetContainer();
            Assert.True(container != null);
        }
        [Fact]
        public void TryGetContainersFromEmptyDbAndWillNot()
        {
            var database = MockManager.GetMockContext(false).Object;
            var container = database.GetContainer();
            Assert.False(container != null);
        }
    }
}
