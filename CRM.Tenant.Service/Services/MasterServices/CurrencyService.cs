using AutoMapper;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Data.Repositories;
using Crm.Tenant.Service.Models.Requests.Currencies.CreateCurrency;
using FluentValidation;

public class CurrencyService : BaseService<CreateCurrencyRequest, CurrencyModel>
{
    public CurrencyService(IMapper mapper, BaseRepository<CurrencyModel> repository, IValidator<CreateCurrencyRequest> validator)
        : base(mapper, repository, validator)
    {
    }
}