using Bogus;

using Share.Registry.Database.FileSystem.Entities;

using Shares.Registry.Abstraction.Database.Structure;
using Shares.Registry.Test.Abstractions.Mock;

using System;
using System.Collections.Generic;

namespace Shares.Registry.Abstractions.Unit.Test.Fixture
{
    public sealed class FixtureContext : IDisposable
    {
        private DummyItem dummyItem = null;
        public IEntity GetDummyEntityInstance() => dummyItem ??= new DummyItem();
        public IEntity GetDummyItemInstanceAndGenerateProperties() => (GetDummyEntityInstance() as DummyItem).GenerateProperties();
        public MockManager MockManager;
        public FixtureContext()
        {
            // Prepare the context for the Class Fixture
            MockManager = new MockManager();
        }
        public void Dispose()
        {
            // Clean context
        }
        private class DummyItem : Entity
        {
            public string StringProperty { get; private set; }
            public bool BoolProperty { get; private set; }
            public object ObjectProperty { get; private set; }

            public DummyItem GenerateProperties()
            {
                PartitionKey = Guid.NewGuid().ToString();
                PrimaryKey = new object();
                StringProperty = Guid.NewGuid().ToString();
                BoolProperty = new Faker().Random.Bool();
                ObjectProperty = new Faker().Random.CollectionItem(new List<object>
                {
                    new object(),
                    new Faker().Random.Uuid(),
                    new Faker().Random.Int()
                });
                return this;
            }
        }
    }
}
