using Crm.Tenant.Service.Services.Models.Requests.Clients;
using CRM.Tenant.Service.Services.MasterServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CRM.Tenant.Service
{
    public static class TenantServicesRegistration
    {
        public static void AddTenantServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<ClientValidationService>();
            services.AddScoped<ClientService>();

        }
    }
}
