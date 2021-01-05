using Shares.Registry.Business.Tenant.Data.Interfaces;

namespace Shares.Registry.Data.Fake.Providers
{
    public class TestTenantService : ITenantDataReader
    {
        private const string tenantId = "ElettroAle";
        public string GetTenantId() => tenantId;
    }
}
