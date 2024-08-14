using AutoMapper;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Data.Repositories;
using CRM.Tenant.Service.Models.Requests.MasterRequests.DeliveryTime.CreateDeliveryTime;
using FluentValidation;

public class DeliveryTimeService : BaseService<CreateDeliveryTimeRequest, DeliveryTimeModel>
{
    public DeliveryTimeService(IMapper mapper, BaseRepository<DeliveryTimeModel> repository, IValidator<CreateDeliveryTimeRequest> validator)
        : base(mapper, repository, validator)
    {
    }
}