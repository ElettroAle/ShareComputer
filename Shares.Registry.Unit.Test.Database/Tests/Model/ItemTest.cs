
using System;
using System.Collections.Generic;

using Xunit;
using System.Linq;
using Shares.Registry.Abstraction.Database.Structure;
using Shares.Registry.Abstractions.Unit.Test.Fixture;

namespace Shares.Registry.Test.XUnit.Mvvm.Tests.Model
{
    public class ItemTest : Abstractions.Test
    {
        public ItemTest(FixtureContext testFixture) : base(testFixture) {}
        private IEntity DummyItem => TestFixture.GetDummyEntityInstance();

        [Fact]
        public void GetPropertiesFirstLoop() 
        {
            // Arrange
            Assert.True(CheckIsEmpty(DummyItem), $"The item was still empty. Check {nameof(FixtureContext)} and Tests order.");
            // Act & Assert
            Assert.True(GetPropertiesAct());
        }
        [Fact]
        public void GetPropertiesSecondLoop() 
        {
            // Arrange
            Assert.False(CheckIsEmpty(DummyItem));
            // Act & Assert
            Assert.True(GetPropertiesAct(), $"The item should be still filled. Check {nameof(FixtureContext)} and Tests order.");
        }

        private bool GetPropertiesAct()
        {
            // Act
            IEnumerable<Property> properties = TestFixture.GetDummyItemInstanceAndGenerateProperties().GetProperties();
            // Return for Assert
            return properties.Any() && properties.Select(x => x.Value).All(x => x != null);
        }
        private bool CheckIsEmpty(IEntity dummy)
            => String.IsNullOrWhiteSpace(dummy.ContainerKey);
    }
}
