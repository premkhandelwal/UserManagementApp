using AutoMapper;
using Crm.Tenant.Data;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Data.Models.PurchaseOrder;
using Crm.Tenant.Data.Models.Quotation;
using Crm.Tenant.Data.Repositories;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Countries.CreateCountry;
using CRM.Tenant.Service.Services.PurchaseOrderService;
using FluentValidation;

public class CountryService : BaseService<CreateCountryRequest, CountryModel>
{
    QuotationTermsService _quotationTermsService;
    PurchaseOrderTermsService _purchaseOrderTermsService;
    public CountryService(IMapper mapper, BaseRepository<CountryModel> repository, IValidator<CreateCountryRequest> validator, QuotationTermsService quotationService, PurchaseOrderTermsService purchaseOrderTermsService, IUnitOfWork unitOfWork)
        : base(mapper, repository, validator, unitOfWork)
    {
        _quotationTermsService = quotationService;
        _purchaseOrderTermsService = purchaseOrderTermsService;
    }

    public async override Task<bool> HasReferences(CountryModel entity)
    {
        if (await _quotationTermsService.ExistsAsync(q => q.CountryofOriginId == entity.Id))
        {
            return true;
        }
        return await _purchaseOrderTermsService.ExistsAsync(p => p.CountryofOriginId == entity.Id);
    }
}