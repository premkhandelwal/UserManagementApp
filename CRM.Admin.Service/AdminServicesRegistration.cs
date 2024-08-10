using CRM.Admin.Service.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Admin.Service
{
    public static class AdminServicesRegistration
    {
        public static void AddTenantDataServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<AuthService>();
            services.AddScoped<IdentityService>();
        }
    }
}
