using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Bogus;

using Moq;

using Shares.Registry.Abstractions.Connections;
using Shares.Registry.Abstractions.Mvvm.Model;
using Shares.Registry.Abstractions.Mvvm.View;
using Shares.Registry.Abstractions.Mvvm.ViewModel;


namespace Shares.Registry.Test.Abstractions.Mock
{
    public class MockManager
    {
#warning the MockManager is too confusing. I need to build objects in Fixture and flywheight them
        public Mock<IView<object>> GetMockView()
        {
            Mock<IView<object>> mock = new Mock<IView<object>>();
            mock.Setup(x => x.Show()).Callback(() => Console.WriteLine("Ok"));
            mock.SetupGet(x => x.Model).Returns(new object());
            return mock;
        }
        public Mock<IViewModel> GetMockViewModel()
        {
            Mock<IViewModel> mock = new Mock<IViewModel>();
            mock.Setup(x => x.GetView(It.IsAny<string>(), It.IsAny<object[]>())).Returns((string action, object[] args) => GetMockView().Object);
            return mock;
        }
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
        public Mock<IDatabaseClient> GetMockDatabaseClient() 
        {
            Mock<IDatabaseClient> mock = new Mock<IDatabaseClient>();
            mock.SetupGet(x => x.IsOpen).Returns(false);
            mock.Setup(x => x.Open()).Callback(() => mock.SetupGet(x => x.IsOpen).Returns(true)).Returns(mock.Object);
            mock.Setup(x => x.Close()).Callback(() => mock.SetupGet(x => x.IsOpen).Returns(false));
            return mock;
        }
        public Mock<IContainer> GetMockContainer(bool isEmpty, string containerName = "TestContainer")
        {
            Mock<IContainer> container = new Mock<IContainer>(MockBehavior.Loose);
            container.SetupGet(x => x.Name).Returns(containerName);
            IQueryable<IItem> items = Enumerable.Repeat(GetMockItem(false, containerName).Object, isEmpty ? 0 : 3).AsQueryable();
            // IEnumerable setup
            container.Setup(c => c.Count).Returns(items.Count);
            container.Setup(c => c.GetEnumerator()).Returns(() => items.GetEnumerator());
            // IQuerable setup
            container.Setup(r => r.Provider).Returns(items.Provider);
            container.Setup(r => r.ElementType).Returns(items.ElementType);
            container.Setup(r => r.Expression).Returns(items.Expression);
            return container;
        }
        public Mock<IItem> GetMockItem(bool hasProperties, string containerName = null)
        {
            Mock<IItem> item = new Mock<IItem>();
            item.SetupGet(x => x.Key).Returns(new object());
            item.SetupGet(x => x.ContainerKey).Returns(containerName ?? new Faker("en").Random.Word());
            item.Setup(x => x.GetProperties()).Returns(() => !hasProperties ? null : new List<Property>
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
