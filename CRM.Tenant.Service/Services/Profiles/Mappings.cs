using AutoMapper;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Service.Models.Requests.Clients.CreateClient;
using Crm.Tenant.Service.Models.Requests.Clients.DeleteClient;
using Crm.Tenant.Service.Models.Requests.Clients.UpdateClient;
using Crm.Tenant.Service.Models.Requests.Currencies.CreateCountry;
using Crm.Tenant.Service.Models.Requests.Currencies.CreateCurrency;
using Crm.Tenant.Service.Models.Requests.Currencies.DeleteCountry;
using Crm.Tenant.Service.Models.Requests.Currencies.DeleteCurrency;
using Crm.Tenant.Service.Models.Requests.Currencies.UpdateCountry;
using Crm.Tenant.Service.Models.Requests.Currencies.UpdateCurrency;
using Crm.Tenant.Service.Models.Requests.DeliveredTo.CreateDeliveredTo;
using Crm.Tenant.Service.Models.Requests.DeliveredTo.DeleteDeliveredTo;
using Crm.Tenant.Service.Models.Requests.DeliveredTo.UpdateDeliveredTo;
using Crm.Tenant.Service.Models.Requests.DeliveryTime.CreateDeliveryTime;
using Crm.Tenant.Service.Models.Requests.DeliveryTime.DeleteDeliveryTime;
using Crm.Tenant.Service.Models.Requests.DeliveryTime.UpdateDeliveryTime;
using Crm.Tenant.Service.Models.Requests.Material.CreateMaterial;
using Crm.Tenant.Service.Models.Requests.Material.DeleteMaterial;
using Crm.Tenant.Service.Models.Requests.Material.UpdateMaterial;
using Crm.Tenant.Service.Models.Requests.MtcType.CreateMtcType;
using Crm.Tenant.Service.Models.Requests.MtcType.UpdateMtcType;
using Crm.Tenant.Service.Models.Requests.PaymentType.CreatePaymentType;
using Crm.Tenant.Service.Models.Requests.PaymentType.DeletePaymentType;
using Crm.Tenant.Service.Models.Requests.PaymentType.UpdatePaymentType;
using Crm.Tenant.Service.Models.Requests.Product.CreateProduct;
using Crm.Tenant.Service.Models.Requests.Product.DeleteProduct;
using Crm.Tenant.Service.Models.Requests.Product.UpdateProduct;
using Crm.Tenant.Service.Models.Requests.QuotationCloseReason.CreateQuotationCloseReason;
using Crm.Tenant.Service.Models.Requests.QuotationCloseReason.DeleteQuotationCloseReason;
using Crm.Tenant.Service.Models.Requests.QuotationCloseReason.UpdateQuotationCloseReason;
using Crm.Tenant.Service.Models.Requests.TransportMode.CreateTransportMode;
using Crm.Tenant.Service.Models.Requests.TransportMode.DeleteTransportMode;
using Crm.Tenant.Service.Models.Requests.TransportMode.UpdateTransportMode;
using Crm.Tenant.Service.Models.Requests.Validity.CreateValidity;
using Crm.Tenant.Service.Models.Requests.Validity.DeleteValidity;
using Crm.Tenant.Service.Models.Requests.Validity.UpdateValidity;


namespace Crm.Tenant.Service.Services.Profiles
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            // Client mappings
            CreateMap<ClientModel, CreateClientRequest>().ReverseMap();
            CreateMap<ClientModel, UpdateClientRequest>().ReverseMap();
            CreateMap<ClientModel, DeleteClientRequest>().ReverseMap();

            // Country mappings
            CreateMap<CountryModel, CreateCountryRequest>().ReverseMap();
            CreateMap<CountryModel, UpdateCountryRequest>().ReverseMap();
            CreateMap<CountryModel, DeleteCountryRequest>().ReverseMap();

            // Currency mappings
            CreateMap<CurrencyModel, CreateCurrencyRequest>().ReverseMap();
            CreateMap<CurrencyModel, UpdateCurrencyRequest>().ReverseMap();
            CreateMap<CurrencyModel, DeleteCurrencyRequest>().ReverseMap();

            // DeliveredTo mappings
            CreateMap<DeliveredToModel, CreateDeliveredToRequest>().ReverseMap();
            CreateMap<DeliveredToModel, UpdateDeliveredToRequest>().ReverseMap();
            CreateMap<DeliveredToModel, DeleteDeliveredToRequest>().ReverseMap();

            // DeliveryTime mappings
            CreateMap<DeliveryTimeModel, CreateDeliveryTimeRequest>().ReverseMap();
            CreateMap<DeliveryTimeModel, UpdateDeliveryTimeRequest>().ReverseMap();
            CreateMap<DeliveryTimeModel, DeleteDeliveryTimeRequest>().ReverseMap();

            // Material mappings
            CreateMap<MaterialModel, CreateMaterialRequest>().ReverseMap();
            CreateMap<MaterialModel, UpdateMaterialRequest>().ReverseMap();
            CreateMap<MaterialModel, DeleteMaterialRequest>().ReverseMap();

            // MtcType mappings
            CreateMap<MtcTypeModel, CreateMtcTypeRequest>().ReverseMap();
            CreateMap<MtcTypeModel, UpdateMtcTypeRequest>().ReverseMap();
            CreateMap<MtcTypeModel, DeleteMtcTypeRequest>().ReverseMap();


            // PaymentType mappings
            CreateMap<PaymentTypeModel, CreatePaymentTypeRequest>().ReverseMap();
            CreateMap<PaymentTypeModel, UpdatePaymentTypeRequest>().ReverseMap();
            CreateMap<PaymentTypeModel, DeletePaymentTypeRequest>().ReverseMap();

            // Product mappings
            CreateMap<ProductModel, CreateProductRequest>().ReverseMap();
            CreateMap<ProductModel, UpdateProductRequest>().ReverseMap();
            CreateMap<ProductModel, DeleteProductRequest>().ReverseMap();

            // QuotationCloseReason mappings
            CreateMap<QuotationCloseReasonModel, CreateQuotationCloseReasonRequest>().ReverseMap();
            CreateMap<QuotationCloseReasonModel, UpdateQuotationCloseReasonRequest>().ReverseMap();
            CreateMap<QuotationCloseReasonModel, DeleteQuotationCloseReasonRequest>().ReverseMap();

            // TransportMode mappings
            CreateMap<TransportModeModel, CreateTransportModeRequest>().ReverseMap();
            CreateMap<TransportModeModel, UpdateTransportModeRequest>().ReverseMap();
            CreateMap<TransportModeModel, DeleteTransportModeRequest>().ReverseMap();

            // Validity mappings
            CreateMap<ValidityModel, CreateValidityRequest>().ReverseMap();
            CreateMap<ValidityModel, UpdateValidityRequest>().ReverseMap();
            CreateMap<ValidityModel, DeleteValidityRequest>().ReverseMap();
        }
    }
}

