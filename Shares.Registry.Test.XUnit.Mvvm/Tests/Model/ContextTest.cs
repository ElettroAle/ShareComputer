using Share.Registry.Database.Models;

using Shares.Registry.Abstractions.Mvvm.Model;
using Shares.Registry.Mvvm.Models;
using Shares.Registry.Test.Abstractions.Context;
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
            var database = MockManager.GetMockContext(true, "TestContainer").Object;
            Assert.True(database.Containers.Any());
            foreach (string containerName in database.Containers.Select(x => x.Name))
                Assert.True(database.GetContainer(containerName) != null);
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
        [Fact]
        public void CreateContext()
        {
            using var context = new DbContext(MockManager.GetMockDatabaseClient().Object);
            Assert.True(context.Containers.Any());
            Assert.False(context.IsOpen);
        }
        [Fact]
        public void OpenDbContext()
        {
            using var context = new DbContext(MockManager.GetMockDatabaseClient().Object);
            var _ = context.Client;
            Assert.True(context.IsOpen);
        }
        [Fact]
        public void DisposeContext()
        {
            var context = new DbContext(MockManager.GetMockDatabaseClient().Object);
            context.Dispose();
            Assert.False(context.IsOpen);
        }
        [Fact]
        public void GetContextFromFactory()
        {
            var context = new ContextFactory().GetContext(MockManager.GetMockDatabaseClient().Object);
            Assert.True(context != null);
        }
    }
}
