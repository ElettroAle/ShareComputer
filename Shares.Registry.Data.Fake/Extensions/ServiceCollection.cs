using AutoMapper;

using Shares.Registry.Business.Shares.Data.Interfaces;
using Shares.Registry.Data.Fake.Generators;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddFakeShareGenerator(this IServiceCollection services)
            => services
                .AddSingleton<ISharesDataReader, FakeSharesGenerator>();
    }
}
