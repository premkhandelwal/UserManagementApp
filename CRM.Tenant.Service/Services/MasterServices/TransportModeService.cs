using AutoMapper;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Data.Repositories;
using Crm.Tenant.Service.Models.Requests.TransportMode.CreateTransportMode;
using FluentValidation;

public class TransportModeService : BaseService<CreateTransportModeRequest, TransportModeModel>
{
    public TransportModeService(IMapper mapper, BaseRepository<TransportModeModel> repository, IValidator<CreateTransportModeRequest> validator)
        : base(mapper, repository, validator)
    {
    }
}