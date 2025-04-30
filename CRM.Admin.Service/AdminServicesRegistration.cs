using Crm.Admin.Service.Services;
using CRM.Admin.Service.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Crm.Admin.Service
{
    public static class AdminServicesRegistration
    {
        public static void AddAdminServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<TokenService>();
            services.AddScoped<AuthService>();
            services.AddScoped<IdentityService>();
            services.AddScoped<EmailService>();
            services.AddScoped<OtpService>();
            services.AddHostedService<OtpCleanupService>();
        }
    }
}
