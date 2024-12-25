using AutoMapper;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Data.Repositories;
using CRM.Tenant.Service.Models.Requests.MasterRequests.TransportMode.CreateTransportMode;
using CRM.Tenant.Service.Services.PurchaseOrderService;
using CRM.Tenant.Service.Services.QuotationService;
using FluentValidation;

public class TransportModeService : BaseService<CreateTransportModeRequest, TransportModeModel>
{
    DeliveredToService _deliveredToService;
    public TransportModeService(IMapper mapper, BaseRepository<TransportModeModel> repository, IValidator<CreateTransportModeRequest> validator, DeliveredToService deliveredToService)
        : base(mapper, repository, validator)
    {
        _deliveredToService = deliveredToService;
    }

    public async override Task<bool> HasReferences(TransportModeModel entity)
    {
        return await _deliveredToService.ExistsAsync(d => d.TransportModeId == entity.Id);
    }
}