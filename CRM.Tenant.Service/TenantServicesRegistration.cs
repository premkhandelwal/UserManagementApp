using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Data.Repositories;
using Crm.Tenant.Service.Models.Requests.Clients.CreateClient;
using Crm.Tenant.Service.Models.Requests.Currencies.CreateCountry;
using Crm.Tenant.Service.Models.Requests.Currencies.CreateCurrency;
using Crm.Tenant.Service.Models.Requests.DeliveredTo.CreateDeliveredTo;
using Crm.Tenant.Service.Models.Requests.DeliveryTime.CreateDeliveryTime;
using Crm.Tenant.Service.Models.Requests.Material.CreateMaterial;
using Crm.Tenant.Service.Models.Requests.MtcType.CreateMtcType;
using Crm.Tenant.Service.Models.Requests.Product.CreateProduct;
using Crm.Tenant.Service.Models.Requests.QuotationCloseReason.CreateQuotationCloseReason;
using Crm.Tenant.Service.Models.Requests.TransportMode.CreateTransportMode;
using Crm.Tenant.Service.Models.Requests.Validity.CreateValidity;
using Crm.Tenant.Service.Models.Requests.PaymentType.CreatePaymentType;

namespace Crm.Tenant.Service
{
    public static class TenantServicesRegistration
    {
        public static void AddTenantServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            RegisterScopedService<ClientModel, ClientService, CreateClientRequest, CreateClientValidationService<CreateClientRequest>>(services);
            RegisterScopedService<CountryModel, CountryService, CreateCountryRequest, CreateCountryValidationService<CreateCountryRequest>>(services);
            RegisterScopedService<CurrencyModel, CurrencyService, CreateCurrencyRequest, CreateCurrencyValidationService<CreateCurrencyRequest>>(services);
            RegisterScopedService<DeliveredToModel, DeliveredToService, CreateDeliveredToRequest, CreateDeliveredToValidationService<CreateDeliveredToRequest>>(services);
            RegisterScopedService<DeliveryTimeModel, DeliveryTimeService, CreateDeliveryTimeRequest, CreateDeliveryTimeValidationService<CreateDeliveryTimeRequest>>(services);
            RegisterScopedService<MaterialModel, MaterialService, CreateMaterialRequest, CreateMaterialValidationService<CreateMaterialRequest>>(services);
            RegisterScopedService<MtcTypeModel, MtcTypeService, CreateMtcTypeRequest, CreateMtcTypeValidationService<CreateMtcTypeRequest>>(services);
            RegisterScopedService<PaymentTypeModel, PaymentTypeService, CreatePaymentTypeRequest, CreatePaymentTypeValidationService<CreatePaymentTypeRequest>>(services);
            RegisterScopedService<ProductModel, ProductService, CreateProductRequest, CreateProductValidationService<CreateProductRequest>>(services);
            RegisterScopedService<QuotationCloseReasonModel, QuotationCloseReasonService, CreateQuotationCloseReasonRequest, CreateQuotationCloseReasonValidationService<CreateQuotationCloseReasonRequest>>(services);
            RegisterScopedService<TransportModeModel, TransportModeService, CreateTransportModeRequest, CreateTransportModeValidationService<CreateTransportModeRequest>>(services);
            RegisterScopedService<ValidityModel, ValidityService, CreateValidityRequest, CreateValidityValidationService<CreateValidityRequest>>(services);
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
