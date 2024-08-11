using AutoMapper;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Data.Repositories;
using Crm.Tenant.Service.Services.Models.Requests.Clients;
using CRM.Data.Models.Masters;
using CRM.Tenant.Service.Models.Requests.Clients.CreateClient;
using CRM.Tenant.Service.Models.Requests.Clients.DeleteClient;
using CRM.Tenant.Service.Models.Requests.Clients.UpdateClient;
using CRM.Tenant.Service.Models.Requests.Countries.CreateCountry;
using CRM.Tenant.Service.Models.Requests.Countries.DeleteCountry;
using CRM.Tenant.Service.Models.Requests.Countries.UpdateCountry;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CRM.Tenant.Service
{
    public static class TenantServicesRegistration
    {
        public static void AddTenantServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            RegisterScopedService<ClientModel, ClientService, CreateClientRequest, CreateClientValidationService<CreateClientRequest>>(services);
            RegisterScopedService<CountryModel, CountryService, CreateCountryRequest, CreateCountryValidationService<CreateCountryRequest>>(services);

        }

        private static void RegisterScopedService<TModel, TService, TRequest, TValidator>(IServiceCollection services)
           where TRequest : class
           where TValidator: class, IValidator<TRequest>
           where TModel: BaseModelClass
           where TService: BaseService<TRequest, TModel>
        {
            services.AddScoped<TService>();
            services.AddScoped<IValidator<TRequest>, TValidator>();
            services.AddScoped(
            provider => new BaseService<TRequest, TModel>(
               provider.GetRequiredService<IMapper>(),
                provider.GetRequiredService<BaseRepository<TModel>>(),
                provider.GetRequiredService<IValidator<TRequest>>()
            ));
        }
    }
}
