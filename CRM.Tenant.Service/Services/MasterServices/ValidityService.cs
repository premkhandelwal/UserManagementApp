using AutoMapper;
using Crm.Tenant.Data;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Data.Repositories;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Validity.CreateValidity;
using CRM.Tenant.Service.Services.PurchaseOrderService;
using CRM.Tenant.Service.Services.QuotationService;
using FluentValidation;

public class ValidityService : BaseService<CreateValidityRequest, ValidityModel>
{
    QuotationTermsService _quotationTermsService;
    PurchaseOrderTermsService _purchaseOrderTermsService;
    public ValidityService(IMapper mapper, BaseRepository<ValidityModel> repository, IValidator<CreateValidityRequest> validator, QuotationTermsService quotationTermsService, PurchaseOrderTermsService purchaseOrderTermsService, IUnitOfWork unitOfWork)
        : base(mapper, repository, validator, unitOfWork)
    {
        _quotationTermsService = quotationTermsService;
        _purchaseOrderTermsService = purchaseOrderTermsService;
    }

    public async override Task<bool> HasReferences(ValidityModel entity)
    {
        if (await _quotationTermsService.ExistsAsync(q => q.ValidityId == entity.Id))
        {
            return true;
        }
        return await _purchaseOrderTermsService.ExistsAsync(p => p.ValidityId == entity.Id);
    }
}