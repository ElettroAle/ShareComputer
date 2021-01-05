using Shares.Registry.Business.Abstractions.DataPlugins.Interfaces;

using System;
using System.Collections.Generic;
using System.Text;

namespace Shares.Registry.Data.Fake.Providers
{
    public class TestTenantService : ITenantDataReader
    {
        private const string tenantId = "ElettroAle";
        public string GetTenantId() => tenantId;
    }
}
