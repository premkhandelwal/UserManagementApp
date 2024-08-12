using Crm.Admin.Service.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Admin.Service
{
    public static class AdminServicesRegistration
    {
        public static void AddAdminServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<AuthService>();
            services.AddScoped<IdentityService>();
        }
    }
}
