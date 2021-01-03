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
        public async Task<IEnumerable<SharePurchase>> GetAllSharesAsync() => await Task.FromResult(CreateFakeDTOs());
        public async Task<IEnumerable<SharePurchase>> GetSharesAsync(string companyName) => await Task.FromResult(CreateFakeDTOs(companyNames: companyName));

        private IEnumerable<SharePurchase> CreateFakeDTOs(int numberOfItems = 0, params string[] companyNames) 
        {
            if (numberOfItems <= 0) numberOfItems = new Faker().Random.Int(10, 1000);
            if (companyNames == null || companyNames.Length <= 0) companyNames = GetCompanyNames();
            return new Faker<SharePurchase>()
                .RuleFor(dto => dto.Name, faker => companyNames[faker.Random.Int(0, companyNames.Length)])
                .RuleFor(dto => dto.OperationType, faker => faker.PickRandom<OperationType>())
                .RuleFor(dto => dto.Quantity, faker => faker.Random.Int(1, 500))
                .RuleFor(dto => dto.Timestamp, faker => faker.Date.Between(DateTime.UtcNow.AddDays(-100), DateTime.UtcNow))
                .RuleFor(dto => dto.UnitValue, faker => faker.Random.Decimal(0.1M, 100.0M))
            .Generate(numberOfItems);
        }
        private string[] GetCompanyNames(int numberOfCompanies = 3) 
        {
            string[] companyNames = new string[numberOfCompanies];
            Bogus.DataSets.Company company = new Faker().Company;
            for (int i = numberOfCompanies - 1; i >= 0; i--)
            {
                companyNames[i] = company.CompanyName(1);
            }
            return companyNames;
        } 
    }
}
