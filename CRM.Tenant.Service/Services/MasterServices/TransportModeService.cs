using AutoMapper;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Data.Repositories;
using CRM.Tenant.Service.Models.Requests.MasterRequests.TransportMode.CreateTransportMode;
using FluentValidation;

public class TransportModeService : BaseService<CreateTransportModeRequest, TransportModeModel>
{
    public TransportModeService(IMapper mapper, BaseRepository<TransportModeModel> repository, IValidator<CreateTransportModeRequest> validator)
        : base(mapper, repository, validator)
    {
    }
}