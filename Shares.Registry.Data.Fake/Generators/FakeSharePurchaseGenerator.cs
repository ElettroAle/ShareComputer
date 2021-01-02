using Bogus;

using Shares.Registry.Business.Data.Enumerator;
using Shares.Registry.Business.Data.Interfaces;
using Shares.Registry.Business.Data.TransferObjects;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shares.Registry.Data.Fake.Generators
{
    public class FakeSharePurchaseGenerator : IDataReader
    {
        public async Task<IEnumerable<SharePurchase>> GetAllSharesAsync()
        {
            return await Task.FromResult(CreateFakeDTOs(3));
        }
        private IEnumerable<SharePurchase> CreateFakeDTOs(int count) 
        {
            return new Faker<SharePurchase>()
                .RuleFor(dto => dto.Name, faker => faker.Company.CompanyName())
                .RuleFor(dto => dto.OperationType, faker => faker.PickRandom<OperationType>())
                .RuleFor(dto => dto.Quantity, faker => faker.Random.Int(1, 500))
                .RuleFor(dto => dto.Timestamp, faker => faker.Date.Between(DateTime.UtcNow.AddDays(-100), DateTime.UtcNow))
                .RuleFor(dto => dto.UnitValue, faker => faker.Random.Decimal(0.1M, 100.0M))
            .Generate(count);
        }
    }
}
