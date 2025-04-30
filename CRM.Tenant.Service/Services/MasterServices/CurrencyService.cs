using AutoMapper;
using Crm.Tenant.Data;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Data.Repositories;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Currencies.CreateCurrency;
using CRM.Tenant.Service.Services.PurchaseOrderService;
using FluentValidation;

public class CurrencyService : BaseService<CreateCurrencyRequest, CurrencyModel>
{
    QuotationTermsService _quotationTermsService;
    PurchaseOrderTermsService _purchaseOrderTermsService;
    public CurrencyService(IMapper mapper, BaseRepository<CurrencyModel> repository, IValidator<CreateCurrencyRequest> validator, QuotationTermsService quotationService, PurchaseOrderTermsService purchaseOrderTermsService, IUnitOfWork unitOfWork)
        : base(mapper, repository, validator, unitOfWork)
    {
        _quotationTermsService = quotationService;
        _purchaseOrderTermsService = purchaseOrderTermsService;
    }

    public async override Task<bool> HasReferences(CurrencyModel entity)
    {
        if (await _quotationTermsService.ExistsAsync(q => q.CurrencyId == entity.Id))
        {
            return true;
        }
        return await _purchaseOrderTermsService.ExistsAsync(p => p.CurrencyId == entity.Id);
    }
}