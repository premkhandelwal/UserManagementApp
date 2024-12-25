using AutoMapper;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Data.Repositories;
using CRM.Tenant.Service.Models.Requests.MasterRequests.MtcType.CreateMtcType;
using CRM.Tenant.Service.Services.PurchaseOrderService;
using CRM.Tenant.Service.Services.QuotationService;
using FluentValidation;

public class MtcTypeService : BaseService<CreateMtcTypeRequest, MtcTypeModel>
{
    QuotationTermsService _quotationTermsService;
    PurchaseOrderTermsService _purchaseOrderTermsService;
    public MtcTypeService(IMapper mapper, BaseRepository<MtcTypeModel> repository, IValidator<CreateMtcTypeRequest> validator, QuotationTermsService quotationService, PurchaseOrderTermsService purchaseOrderTermsService)
        : base(mapper, repository, validator)
    {
        _quotationTermsService = quotationService;
        _purchaseOrderTermsService = purchaseOrderTermsService;
    }

    public async override Task<bool> HasReferences(MtcTypeModel entity)
    {
        if (await _quotationTermsService.ExistsAsync(q => q.MtcTypeId == entity.Id))
        {
            return true;
        }
        return await _purchaseOrderTermsService.ExistsAsync(p => p.MtcTypeId == entity.Id);
    }
}