using AutoMapper;
using Crm.Api.Models.Quotation;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Data.Repositories;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Countries.CreateCountry;
using FluentValidation;

public class CountryService : BaseService<CreateCountryRequest, CountryModel>
{
    QuotationTermsService _quotationTermsService;
    public CountryService(IMapper mapper, BaseRepository<CountryModel> repository, IValidator<CreateCountryRequest> validator, QuotationTermsService quotationService)
        : base(mapper, repository, validator)
    {
        _quotationTermsService = quotationService;   
    }

    public async override Task<bool> HasReferences(CountryModel entity)
    {
        List<QuotationTermsModel> quotations = await _quotationTermsService.ReadAsync();
        return quotations.Any(q => q.CountryofOriginId == entity.Id);
    }
}