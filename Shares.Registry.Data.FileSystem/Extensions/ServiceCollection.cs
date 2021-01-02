using AutoMapper;

using Microsoft.Extensions.DependencyInjection;

using Shares.Registry.Business.Data.Interfaces;
using Shares.Registry.Data.FileSystem.Databases;
using Shares.Registry.Data.FileSystem.Mapping;

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddTextFileDatabase(this IServiceCollection services)
            => services
                .AddTextFileDatabaseWriter()
                .AddTextFileDatabaseReader();
        public static IServiceCollection AddTextFileDatabaseWriter(this IServiceCollection services)
            => services
                .AddTextFileDatabaseAutoMapper()
                .AddSingleton<IDataWriter, TextFileDatabase>();
        public static IServiceCollection AddTextFileDatabaseReader(this IServiceCollection services)
            => services
                .AddTextFileDatabaseAutoMapper()
                .AddSingleton<IDataReader, TextFileDatabase>();

        private static IServiceCollection AddTextFileDatabaseAutoMapper(this IServiceCollection services)
            => services
                .AddAutoMapper(typeof(TextFileDatabaseProfile));
    }
}
