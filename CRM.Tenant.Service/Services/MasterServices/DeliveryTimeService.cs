using AutoMapper;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Data.Repositories;
using Crm.Tenant.Service.Models.Requests.DeliveryTime.CreateDeliveryTime;
using FluentValidation;

public class DeliveryTimeService : BaseService<CreateDeliveryTimeRequest, DeliveryTimeModel>
{
    public DeliveryTimeService(IMapper mapper, BaseRepository<DeliveryTimeModel> repository, IValidator<CreateDeliveryTimeRequest> validator)
        : base(mapper, repository, validator)
    {
    }
}