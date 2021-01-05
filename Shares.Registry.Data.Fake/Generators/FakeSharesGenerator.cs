using Bogus;

using Shares.Registry.Business.CapitalGain.Data.TransferObjects;
using Shares.Registry.Business.Shares.Data.Enumerator;
using Shares.Registry.Business.Shares.Data.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shares.Registry.Data.Fake.Generators
{
    public class FakeSharesGenerator : ISharesDataReader
    {
        public async Task<IEnumerable<Share>> GetSharesAsync() => await Task.FromResult(CreateFakeDTOs());

        public async Task<IEnumerable<Share>> GetSharesAsync(string companyName, DateTime? from, DateTime? to) 
            => await Task.FromResult(CreateFakeDTOs(from: from, to: to, companyNames: companyName));

        private IEnumerable<Share> CreateFakeDTOs(int numberOfItems = 0, DateTime? from = null, DateTime? to = null, params string[] companyNames) 
        {
            to ??= DateTime.Now;
            from ??= to.Value.AddDays(-100);
            if (numberOfItems <= 0) numberOfItems = new Faker().Random.Int(10, 1000);
            if (companyNames == null || companyNames.Length <= 0) companyNames = GetCompanyNames().Select(x => x.Replace(" ", "")).ToArray();
            return new Faker<Share>()
                .RuleFor(dto => dto.Name, faker => companyNames[faker.Random.Int(0, companyNames.Length-1)])
                .RuleFor(dto => dto.OperationType, faker => faker.PickRandom<OperationType>())
                .RuleFor(dto => dto.Quantity, faker => faker.Random.Int(1, 500))
                .RuleFor(dto => dto.Timestamp, faker => faker.Date.Between(from.Value, to.Value))
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
