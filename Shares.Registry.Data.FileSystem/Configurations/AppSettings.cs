using Microsoft.Extensions.Configuration;

using Shares.Registry.Data.FileSystem.Configurations.Sections;

using System;
using System.Collections.Generic;
using System.Text;

namespace Shares.Registry.Business.Data.Configuration
{
    internal class AppSettings
    {
        public static AppSettings Instance { get; private set; }
        public static AppSettings PutConfigurationsInChache(IConfiguration configuration) => Instance = configuration.Get<AppSettings>();
        public FileSystemSection FileSystem { get; set; }
    }
}
