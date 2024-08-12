using AutoMapper;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Data.Repositories;
using Crm.Tenant.Service.Models.Requests.Currencies.CreateCountry;
using FluentValidation;

public class CountryService : BaseService<CreateCountryRequest, CountryModel>
{
    public CountryService(IMapper mapper, BaseRepository<CountryModel> repository, IValidator<CreateCountryRequest> validator)
        : base(mapper, repository, validator)
    {
    }
}