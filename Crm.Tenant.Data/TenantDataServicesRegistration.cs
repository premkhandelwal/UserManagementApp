using Crm.Tenant.Data.DbContexts;
using Crm.Tenant.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace CRM.Tenant.Service
{
    public static class TenantDataServicesRegistration
    {
        public static void AddTenantDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ClientApplicationDbContext>();

            services.AddDbContext<ClientApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ClientConnectionString"));
            });

            services.AddScoped<ClientRepository>();
            services.AddScoped(typeof(BaseRepository<>));


        }
    }
}
