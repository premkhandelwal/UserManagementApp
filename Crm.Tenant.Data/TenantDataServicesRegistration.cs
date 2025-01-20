using Crm.Tenant.Data.DbContexts;
using Crm.Tenant.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Crm.Tenant.Service
{
    public static class TenantDataServicesRegistration
    {
        public static void AddTenantDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ClientApplicationDbContext>(options =>
            {
                options.UseMySql(configuration.GetConnectionString("ClientConnectionString"), new MySqlServerVersion(new Version(8, 0, 31)));
            }, ServiceLifetime.Transient);

            services.AddTransient(typeof(BaseRepository<>));
        }
    }
}
