using AutoMapper;
using Crm.Admin.Service.Models;
using Crm.Tenant.Data.Models.PurchaseOrder;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Data.Models.Masters.PurchaseOrder;
using Crm.Tenant.Data.Models.Quotation;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Clients.CreateClient;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Clients.DeleteClient;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Clients.UpdateClient;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Countries.CreateCountry;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Countries.DeleteCountry;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Countries.UpdateCountry;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Currencies.CreateCurrency;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Currencies.DeleteCurrency;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Currencies.UpdateCurrency;
using CRM.Tenant.Service.Models.Requests.MasterRequests.DeliveredTo.CreateDeliveredTo;
using CRM.Tenant.Service.Models.Requests.MasterRequests.DeliveredTo.DeleteDeliveredTo;
using CRM.Tenant.Service.Models.Requests.MasterRequests.DeliveredTo.UpdateDeliveredTo;
using CRM.Tenant.Service.Models.Requests.MasterRequests.DeliveryTime.CreateDeliveryTime;
using CRM.Tenant.Service.Models.Requests.MasterRequests.DeliveryTime.DeleteDeliveryTime;
using CRM.Tenant.Service.Models.Requests.MasterRequests.DeliveryTime.UpdateDeliveryTime;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Material.CreateMaterial;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Material.DeleteMaterial;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Material.UpdateMaterial;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Member.CreateMember;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Member.DeleteMember;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Member.UpdateMember;
using CRM.Tenant.Service.Models.Requests.MasterRequests.MtcType.CreateMtcType;
using CRM.Tenant.Service.Models.Requests.MasterRequests.MtcType.DeleteMtcType;
using CRM.Tenant.Service.Models.Requests.MasterRequests.MtcType.UpdateMtcType;
using CRM.Tenant.Service.Models.Requests.MasterRequests.PaymentType.CreatePaymentType;
using CRM.Tenant.Service.Models.Requests.MasterRequests.PaymentType.DeletePaymentType;
using CRM.Tenant.Service.Models.Requests.MasterRequests.PaymentType.UpdatePaymentType;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Product.CreateProduct;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Product.DeleteProduct;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Product.UpdateProduct;
using CRM.Tenant.Service.Models.Requests.MasterRequests.PurchseOrder.Hsn.CreateHsn;
using CRM.Tenant.Service.Models.Requests.MasterRequests.PurchseOrder.Hsn.DeleteHsn;
using CRM.Tenant.Service.Models.Requests.MasterRequests.PurchseOrder.Hsn.UpdateHsn;
using CRM.Tenant.Service.Models.Requests.MasterRequests.PurchseOrder.Vendor.CreateVendor;
using CRM.Tenant.Service.Models.Requests.MasterRequests.PurchseOrder.Vendor.DeleteVendor;
using CRM.Tenant.Service.Models.Requests.MasterRequests.PurchseOrder.Vendor.UpdateVendor;
using CRM.Tenant.Service.Models.Requests.MasterRequests.PurchseOrder.VendorMember.CreateVendorMember;
using CRM.Tenant.Service.Models.Requests.MasterRequests.PurchseOrder.VendorMember.DeleteVendorMember;
using CRM.Tenant.Service.Models.Requests.MasterRequests.PurchseOrder.VendorMember.UpdateVendorMember;
using CRM.Tenant.Service.Models.Requests.MasterRequests.QuotationCloseReason.CreateQuotationCloseReason;
using CRM.Tenant.Service.Models.Requests.MasterRequests.QuotationCloseReason.DeleteQuotationCloseReason;
using CRM.Tenant.Service.Models.Requests.MasterRequests.QuotationCloseReason.UpdateQuotationCloseReason;
using CRM.Tenant.Service.Models.Requests.MasterRequests.TransportMode.CreateTransportMode;
using CRM.Tenant.Service.Models.Requests.MasterRequests.TransportMode.DeleteTransportMode;
using CRM.Tenant.Service.Models.Requests.MasterRequests.TransportMode.UpdateTransportMode;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Unit.CreateUnit;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Validity.CreateValidity;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Validity.DeleteValidity;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Validity.UpdateValidity;
using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Create.CreatePurchaseOrderFields;
using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Create.CreatePurchaseOrderItems;
using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Create.CreatePurchaseOrderTerms;
using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Update.UpdatePurchaseOrderFields;
using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Update.UpdatePurchaseOrderItems;
using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Update.UpdatePurchaseOrderTerms;
using CRM.Tenant.Service.Models.Requests.Quotation.QuotationFields.CreateQuotationFields;
using CRM.Tenant.Service.Models.Requests.Quotation.QuotationFields.CreateQuotationItems;
using CRM.Tenant.Service.Models.Requests.Quotation.QuotationFields.CreateQuotationTerms;
using CRM.Tenant.Service.Models.Requests.Quotation.Update.UpdateQuotationFields;
using CRM.Tenant.Service.Models.Requests.Quotation.Update.UpdateQuotationTerms;
using CRM.Tenant.Service.Models.Requests.QuotationFollowUp;
using CRM.Tenant.Service.Models.Requests.UserRequests;
using CRM.Tenant.Service.Models.Requests.QuotationFollowUp.UpdateQuotationItems;
using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Delete.DeletePurchaseOrderFields;
using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Delete.DeletePurchaseOrderItems;
using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Delete.DeletePurchaseOrderTerms;
using CRM.Tenant.Service.Models.Requests.Quotation.Delete.DeleteQuotationFields;
using CRM.Tenant.Service.Models.Requests.Quotation.Delete.DeleteQuotationItems;
using CRM.Tenant.Service.Models.Requests.Quotation.Delete.DeleteQuotationTerms;


namespace CRM.Tenant.Service.Profiles
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

            CreateMap<HsnModel, CreateHsnRequest>().ReverseMap();
            CreateMap<HsnModel, UpdateHsnRequest>().ReverseMap();
            CreateMap<HsnModel, DeleteHsnRequest>().ReverseMap();

            // Material mappings
            CreateMap<MaterialModel, CreateMaterialRequest>().ReverseMap();
            CreateMap<MaterialModel, UpdateMaterialRequest>().ReverseMap();
            CreateMap<MaterialModel, DeleteMaterialRequest>().ReverseMap();

            // Member mappings
            CreateMap<MemberModel, CreateMemberRequest>().ReverseMap();
            CreateMap<MemberModel, UpdateMemberRequest>().ReverseMap();
            CreateMap<MemberModel, DeleteMemberRequest>().ReverseMap();

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

            CreateMap<UnitModel, CreateUnitRequest>().ReverseMap();   

            // Validity mappings
            CreateMap<ValidityModel, CreateValidityRequest>().ReverseMap();
            CreateMap<ValidityModel, UpdateValidityRequest>().ReverseMap();
            CreateMap<ValidityModel, DeleteValidityRequest>().ReverseMap();

            CreateMap<QuotationFieldsModel, CreateQuotationFieldsRequest>().ReverseMap();
            CreateMap<QuotationItemModel, CreateQuotationItemsRequest>().ReverseMap();
            CreateMap<QuotationTermsModel, CreateQuotationTermsRequest>().ReverseMap();

            CreateMap<QuotationFieldsModel, UpdateQuotationFieldsRequest>().ReverseMap();
            CreateMap<QuotationItemModel, UpdateQuotationItemsRequest>().ReverseMap();
            CreateMap<QuotationTermsModel, UpdateQuotationTermsRequest>().ReverseMap();

            CreateMap<QuotationFollowUpModel, CreateQuotationFollowUpRequest>().ReverseMap();

            CreateMap<UserModel, CreateUserRequest>().ReverseMap();
            CreateMap<UserModel, UpdateUserRequest>().ReverseMap();

            CreateMap<VendorModel, CreateVendorRequest>().ReverseMap();
            CreateMap<VendorModel, UpdateVendorRequest>().ReverseMap();
            CreateMap<VendorModel, DeleteVendorRequest>().ReverseMap();

            CreateMap<VendorMemberModel, CreateVendorMemberRequest>().ReverseMap();
            CreateMap<VendorMemberModel, UpdateVendorMemberRequest>().ReverseMap();
            CreateMap<VendorMemberModel, DeleteVendorMemberRequest>().ReverseMap();

            CreateMap<PurchaseOrderFieldsModel, CreatePurchaseOrderFieldsRequest>().ReverseMap();
            CreateMap<PurchaseOrderItemModel, CreatePurchaseOrderItemsRequest>().ReverseMap();
            CreateMap<PurchaseOrderTermsModel, CreatePurchaseOrderTermsRequest>().ReverseMap();

            CreateMap<PurchaseOrderFieldsModel, UpdatePurchaseOrderFieldsRequest>().ReverseMap();
            CreateMap<PurchaseOrderItemModel, UpdatePurchaseOrderItemsRequest>().ReverseMap();
            CreateMap<PurchaseOrderTermsModel, UpdatePurchaseOrderTermsRequest>().ReverseMap();

            CreateMap<PurchaseOrderFieldsModel, DeletePurchaseOrderFieldsRequest>().ReverseMap();
            CreateMap<PurchaseOrderItemModel, DeletePurchaseOrderItemsRequest>().ReverseMap();
            CreateMap<PurchaseOrderTermsModel, DeletePurchaseOrderTermsRequest>().ReverseMap();

            CreateMap<QuotationFieldsModel, DeleteQuotationFieldsRequest>().ReverseMap();
            CreateMap<QuotationItemModel, DeleteQuotationItemsRequest>().ReverseMap();
            CreateMap<QuotationTermsModel, DeleteQuotationTermsRequest>().ReverseMap();
        }
    }
}


