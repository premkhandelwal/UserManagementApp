using AutoMapper;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Data.Repositories;
using CRM.Tenant.Service.Models.Requests.MasterRequests.DeliveredTo.CreateDeliveredTo;
using CRM.Tenant.Service.Services.PurchaseOrderService;
using FluentValidation;

public class DeliveredToService : BaseService<CreateDeliveredToRequest, DeliveredToModel>
{
    QuotationTermsService _quotationTermsService;
    PurchaseOrderTermsService _purchaseOrderTermsService;
    public DeliveredToService(IMapper mapper, BaseRepository<DeliveredToModel> repository, IValidator<CreateDeliveredToRequest> validator, QuotationTermsService quotationService, PurchaseOrderTermsService purchaseOrderTermsService)
        : base(mapper, repository, validator)
    {
        _quotationTermsService = quotationService;
        _purchaseOrderTermsService = purchaseOrderTermsService;
    }

    public async override Task<bool> HasReferences(DeliveredToModel entity)
    {
        if (await _quotationTermsService.ExistsAsync(q => q.PackingTypeId == entity.Id))
        {
            return true;
        }
        return await _purchaseOrderTermsService.ExistsAsync(p => p.PackingTypeId == entity.Id);
    }
}