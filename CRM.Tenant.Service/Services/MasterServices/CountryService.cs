using AutoMapper;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Data.Repositories;
using CRM.Data.Models.Masters;
using CRM.Tenant.Service.Models.Requests.Clients.CreateClient;
using CRM.Tenant.Service.Models.Requests.Countries.CreateCountry;
using FluentValidation;

public class CountryService : BaseService<CreateCountryRequest, CountryModel>
{
    public CountryService(IMapper mapper, BaseRepository<CountryModel> repository, IValidator<CreateCountryRequest> validator)
        : base(mapper, repository, validator)
    {
    }
}