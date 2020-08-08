using System;
using System.Collections.Generic;
using System.Text;

using Bogus;

using Moq;

using Shares.Registry.Abstractions.Mvvm.Model;
using Shares.Registry.Abstractions.Mvvm.View;
using Shares.Registry.Abstractions.Mvvm.ViewModel;

namespace Shares.Registry.Test.Abstractions.Mock
{
    public class MockManager
    {
        public Mock<IView<object>> GetViewMock()
        {
            Mock<IView<object>> mock = new Mock<IView<object>>();
            mock.Setup(x => x.Show()).Callback(() => Console.WriteLine("Ok"));
            mock.SetupGet(x => x.Model).Returns(new object());
            return mock;
        }
        public Mock<IViewModel> GetViewModelMock()
        {
            Mock<IViewModel> mock = new Mock<IViewModel>();
            mock.Setup(x => x.GetView(It.IsAny<string>(), It.IsAny<object[]>())).Returns((string action, object[] args) => GetViewMock().Object);
            return mock;
        }
        public Mock<IContext> GetContextMock(bool hasContainers, bool hasItems)
        {
            Mock<IContext> mock = new Mock<IContext>();
            if (hasContainers)
            {
                var containerMock = GetMockContainer(!hasItems);
                mock.SetupGet(x => x.Containers).Returns(new List<IContainer>() { containerMock.Object });
            }
            return mock;
        }
        public Mock<IContainer> GetMockContainer(bool isEmpty)
        {
            Mock<IContainer> container = new Mock<IContainer>();
            container.SetupGet(x => x.Name).Returns("TestContainer");
            container.Setup(x => x.DoQuery()).Returns(() 
                => isEmpty ? null : new List<IItem>() { GetMockItem(true).Object });
            return container;
        }
        public Mock<IItem> GetMockItem(bool hasProperties)
        {
            Mock<IItem> item = new Mock<IItem>();
            item.SetupGet(x => x.Id).Returns(new object());
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
