using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Data.Repositories;
using CRM.Tenant.Service.Models.Requests.MasterRequests.DeliveredTo.CreateDeliveredTo;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Currencies.CreateCurrency;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Countries.CreateCountry;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Validity.CreateValidity;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Product.CreateProduct;
using CRM.Tenant.Service.Models.Requests.MasterRequests.PaymentType.CreatePaymentType;
using CRM.Tenant.Service.Models.Requests.MasterRequests.TransportMode.CreateTransportMode;
using CRM.Tenant.Service.Models.Requests.MasterRequests.QuotationCloseReason.CreateQuotationCloseReason;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Clients.CreateClient;
using CRM.Tenant.Service.Models.Requests.MasterRequests.MtcType.CreateMtcType;
using CRM.Tenant.Service.Models.Requests.MasterRequests.DeliveryTime.CreateDeliveryTime;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Material.CreateMaterial;
using Crm.Tenant.Data.Models;
using CRM.Tenant.Service.Models.Requests.Quotation.QuotationFields.CreateQuotationFields;
using CRM.Tenant.Service.Models.Requests.Quotation.QuotationFields.CreateQuotationItems;
using CRM.Tenant.Service.Models.Requests.Quotation.QuotationFields.CreateQuotationTerms;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Member.CreateMember;
using CRM.Tenant.Service.Services.QuotationService;
using Crm.Tenant.Data.Models.Quotation;
using CRM.Tenant.Service.Models.Requests.QuotationFollowUp;
using Crm.Admin.Service.Models;
using CRM.Tenant.Service.Services;
using CRM.Tenant.Service.Models.Requests.UserRequests;
using CRM.Tenant.Service.Services.MasterServices;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Unit.CreateUnit;
using Crm.Tenant.Data.Models.Masters.PurchaseOrder;
using CRM.Tenant.Service.Models.Requests.MasterRequests.PurchseOrder.Hsn.CreateHsn;
using CRM.Tenant.Service.Services.MasterServices.PurchaseOrder;
using CRM.Tenant.Service.Models.Requests.MasterRequests.PurchseOrder.Vendor.CreateVendor;
using CRM.Tenant.Service.Models.Requests.MasterRequests.PurchseOrder.VendorMember.CreateVendorMember;
using CRM.Tenant.Service.Services.PurchaseOrderService;
using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Create.CreatePurchaseOrderFields;
using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Create.CreatePurchaseOrderItems;
using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Create.CreatePurchaseOrderTerms;
using Crm.Tenant.Data.Models.PurchaseOrder;

namespace Crm.Tenant.Service
{
    public static class TenantServicesRegistration
    {
        public static void AddTenantServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            RegisterScopedService<UserModel, UserService, CreateUserRequest, CreateUserValidationService<CreateUserRequest>>(services);
            RegisterScopedService<ClientModel, ClientService, CreateClientRequest, CreateClientValidationService<CreateClientRequest>>(services);
            RegisterScopedService<CountryModel, CountryService, CreateCountryRequest, CreateCountryValidationService<CreateCountryRequest>>(services);
            RegisterScopedService<CurrencyModel, CurrencyService, CreateCurrencyRequest, CreateCurrencyValidationService<CreateCurrencyRequest>>(services);
            RegisterScopedService<DeliveredToModel, DeliveredToService, CreateDeliveredToRequest, CreateDeliveredToValidationService<CreateDeliveredToRequest>>(services);
            RegisterScopedService<DeliveryTimeModel, DeliveryTimeService, CreateDeliveryTimeRequest, CreateDeliveryTimeValidationService<CreateDeliveryTimeRequest>>(services);
            RegisterScopedService<MaterialModel, MaterialService, CreateMaterialRequest, CreateMaterialValidationService<CreateMaterialRequest>>(services);
            RegisterScopedService<MemberModel, MemberService, CreateMemberRequest, CreateMemberValidationService<CreateMemberRequest>>(services);
            RegisterScopedService<MtcTypeModel, MtcTypeService, CreateMtcTypeRequest, CreateMtcTypeValidationService<CreateMtcTypeRequest>>(services);
            RegisterScopedService<PaymentTypeModel, PaymentTypeService, CreatePaymentTypeRequest, CreatePaymentTypeValidationService<CreatePaymentTypeRequest>>(services);
            RegisterScopedService<ProductModel, ProductService, CreateProductRequest, CreateProductValidationService<CreateProductRequest>>(services);
            RegisterScopedService<QuotationCloseReasonModel, QuotationCloseReasonService, CreateQuotationCloseReasonRequest, CreateQuotationCloseReasonValidationService<CreateQuotationCloseReasonRequest>>(services);
            RegisterScopedService<TransportModeModel, TransportModeService, CreateTransportModeRequest, CreateTransportModeValidationService<CreateTransportModeRequest>>(services);
            RegisterScopedService<ValidityModel, ValidityService, CreateValidityRequest, CreateValidityValidationService<CreateValidityRequest>>(services);
            RegisterScopedService<QuotationFieldsModel, QuotationFieldsService, CreateQuotationFieldsRequest, CreateQuotationFieldsValidationService<CreateQuotationFieldsRequest>>(services);
            RegisterScopedService<QuotationItemModel, QuotationItemsService, CreateQuotationItemsRequest, CreateQuotationItemsValidationService<CreateQuotationItemsRequest>>(services);
            RegisterScopedService<QuotationTermsModel, QuotationTermsService, CreateQuotationTermsRequest, CreateQuotationTermsValidationService<CreateQuotationTermsRequest>>(services);
            RegisterScopedService<QuotationFollowUpModel, QuotationFollowUpService, CreateQuotationFollowUpRequest, CreateQuotationFollowUpValidationService<CreateQuotationFollowUpRequest>>(services);
            RegisterScopedService<UnitModel, UnitService, CreateUnitRequest, CreateUnitValidationService<CreateUnitRequest>>(services);
            RegisterScopedService<HsnModel, HsnService, CreateHsnRequest, CreateHsnValidationService<CreateHsnRequest>>(services);
            RegisterScopedService<VendorModel, VendorService, CreateVendorRequest, CreateVendorValidationService<CreateVendorRequest>>(services);
            RegisterScopedService<VendorMemberModel, VendorMemberService, CreateVendorMemberRequest, CreateVendorMemberValidationService<CreateVendorMemberRequest>>(services);
            RegisterScopedService<PurchaseOrderFieldsModel, PurchaseOrderFieldsService, CreatePurchaseOrderFieldsRequest, CreatePurchaseOrderFieldsValidationService<CreatePurchaseOrderFieldsRequest>>(services);
            RegisterScopedService<PurchaseOrderItemModel, PurchaseOrderItemsService, CreatePurchaseOrderItemsRequest, CreatePurchaseOrderItemsValidationService<CreatePurchaseOrderItemsRequest>>(services);
            RegisterScopedService<PurchaseOrderTermsModel, PurchaseOrderTermsService, CreatePurchaseOrderTermsRequest, CreatePurchaseOrderTermsValidationService<CreatePurchaseOrderTermsRequest>>(services);

            services.AddScoped<QuotationService>();
            services.AddScoped<PurchaseOrderService>();

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
