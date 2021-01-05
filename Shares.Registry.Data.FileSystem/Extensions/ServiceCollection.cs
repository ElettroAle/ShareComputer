using AutoMapper;

using Shares.Registry.Business.Shares.Data.Interfaces;
using Shares.Registry.Data.FileSystem.Databases;
using Shares.Registry.Data.FileSystem.Mapping;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddTextFileDataAccessors(this IServiceCollection services)
            => services
                .AddTextFileDataWriter()
                .AddTextFileDataReader();
        public static IServiceCollection AddTextFileDataWriter(this IServiceCollection services)
            => services
                .AddTextFileDatabaseAutoMapper()
                .AddSingleton<ISharesDataWriter, TextFileDatabaseProvider>();
        public static IServiceCollection AddTextFileDataReader(this IServiceCollection services)
            => services
                .AddTextFileDatabaseAutoMapper()
                .AddSingleton<ISharesDataReader, TextFileDatabaseProvider>();

        private static IServiceCollection AddTextFileDatabaseAutoMapper(this IServiceCollection services)
            => services
                .AddAutoMapper(typeof(TextFileDatabaseProfile));
    }
}
