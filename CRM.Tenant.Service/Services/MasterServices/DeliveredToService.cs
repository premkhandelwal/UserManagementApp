using AutoMapper;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Data.Repositories;
using Crm.Tenant.Service.Models.Requests.DeliveredTo.CreateDeliveredTo;
using FluentValidation;

public class DeliveredToService : BaseService<CreateDeliveredToRequest, DeliveredToModel>
{
    public DeliveredToService(IMapper mapper, BaseRepository<DeliveredToModel> repository, IValidator<CreateDeliveredToRequest> validator)
        : base(mapper, repository, validator)
    {
    }
}