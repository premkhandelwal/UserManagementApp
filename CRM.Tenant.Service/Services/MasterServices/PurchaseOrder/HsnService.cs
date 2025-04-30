using AutoMapper;
using Crm.Tenant.Data;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Data.Models.Masters.PurchaseOrder;
using Crm.Tenant.Data.Repositories;
using CRM.Tenant.Service.Models.Requests.MasterRequests.PurchseOrder.Hsn.CreateHsn;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Unit.CreateUnit;
using CRM.Tenant.Service.Services.PurchaseOrderService;
using FluentValidation;

namespace CRM.Tenant.Service.Services.MasterServices.PurchaseOrder
{
    public class HsnService : BaseService<CreateHsnRequest, HsnModel>
    {
        PurchaseOrderItemsService _purchaseOrderItemsService;
        public HsnService(IMapper mapper, BaseRepository<HsnModel> repository, IValidator<CreateHsnRequest> validator, PurchaseOrderItemsService purchaseOrderItemsService, IUnitOfWork unitOfWork)
        : base(mapper, repository, validator, unitOfWork)
        {
            _purchaseOrderItemsService = purchaseOrderItemsService;
        }

        public async override Task<bool> HasReferences(HsnModel entity)
        {
            return await _purchaseOrderItemsService.ExistsAsync(p => p.Hsn == entity.Id);
        }
    }
}
