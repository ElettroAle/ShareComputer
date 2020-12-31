using System;
using System.Collections.Generic;
using System.Linq;

using Bogus;

using Moq;

using Shares.Registry.Abstraction.Database.Connections;
using Shares.Registry.Abstraction.Database.Structure;

namespace Shares.Registry.Test.Abstractions.Mock
{
    public class MockManager
    {
#warning the MockManager is too confusing. I need to build objects in Fixture and flywheight them
        
        public Mock<IContext> GetMockContext(bool hasItems, params string[] containerNames)
        {
            Mock<IContext> mock = new Mock<IContext>();
            List<IContainer> containers = new List<IContainer>();
            foreach (string containerName in containerNames)
            {
                var containerMock = GetMockContainer(!hasItems, containerName);
                containers.Add(containerMock.Object);
            }
            mock.SetupGet(x => x.Containers).Returns(containers.Any() ? containers : null);
            mock.SetupGet(x => x.Client).Returns(GetMockDatabaseClient().Object);
            return mock;
        }
        private bool clientIsOpen = false;
        public Mock<IClient> GetMockDatabaseClient() 
        {
            Mock<IClient> mock = new Mock<IClient>();
            mock.Setup(x => x.Open()).Callback(() => { System.Diagnostics.Debug.WriteLine("CONTEXT OPEN"); clientIsOpen = true; }).Returns(mock.Object);
            mock.Setup(x => x.Close()).Callback(() => { System.Diagnostics.Debug.WriteLine("CONTEXT CLOSE"); clientIsOpen = false; });
            mock.SetupGet(x => x.IsOpen).Returns(() => clientIsOpen);
            return mock;
        }
        public Mock<IContainer> GetMockContainer(bool isEmpty, string containerName = "TestContainer")
        {
            Mock<IContainer> container = new Mock<IContainer>(MockBehavior.Loose);
            container.SetupGet(x => x.Name).Returns(containerName);
            IQueryable<IEntity> items = Enumerable.Repeat(GetMockItem(false, containerName).Object, isEmpty ? 0 : 3).AsQueryable();
            // IQuerable setup
            container.Setup(c => c.GetEnumerator()).Returns(() => items.GetEnumerator());
            container.Setup(r => r.Provider).Returns(items.Provider);
            container.Setup(r => r.ElementType).Returns(items.ElementType);
            container.Setup(r => r.Expression).Returns(items.Expression);
            return container;
        }
        public Mock<IEntity> GetMockItem(bool useFakeProperties, string containerName = null)
        {
            Mock<IEntity> item = new Mock<IEntity>();
            item.SetupGet(x => x.PrimaryKey).Returns(new object());
            item.SetupGet(x => x.PartitionKey).Returns(containerName ?? new Faker("en").Random.Word());
            item.Setup(x => x.GetProperties()).Returns(() => !useFakeProperties ? null : new List<Property>
            {
                GetRandomProperty(), GetRandomProperty(), GetRandomProperty(), GetRandomProperty()
            });
            return item;
        }
        private Property GetRandomProperty()
            => new Property(
                    Guid.NewGuid().ToString(),
                    new object()
            );
    }
}
