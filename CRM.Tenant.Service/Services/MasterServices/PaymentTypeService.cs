using AutoMapper;
using Crm.Tenant.Data;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Data.Repositories;
using CRM.Tenant.Service.Models.Requests.MasterRequests.PaymentType.CreatePaymentType;
using CRM.Tenant.Service.Services.PurchaseOrderService;
using CRM.Tenant.Service.Services.QuotationService;
using FluentValidation;

public class PaymentTypeService : BaseService<CreatePaymentTypeRequest, PaymentTypeModel>
{
    QuotationTermsService _quotationTermsService;
    PurchaseOrderTermsService _purchaseOrderTermsService;
    public PaymentTypeService(IMapper mapper, BaseRepository<PaymentTypeModel> repository, IValidator<CreatePaymentTypeRequest> validator, QuotationTermsService quotationService, PurchaseOrderTermsService purchaseOrderTermsService, IUnitOfWork unitOfWork)
        : base(mapper, repository, validator, unitOfWork)
    {
        _quotationTermsService = quotationService;
        _purchaseOrderTermsService = purchaseOrderTermsService;
    }

    public async override Task<bool> HasReferences(PaymentTypeModel entity)
    {
        if (await _quotationTermsService.ExistsAsync(q => q.PaymentId == entity.Id))
        {
            return true;
        }
        return await _purchaseOrderTermsService.ExistsAsync(p => p.PaymentId == entity.Id);
    }
}