using AutoMapper;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Data.Repositories;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Unit.CreateUnit;
using CRM.Tenant.Service.Services.PurchaseOrderService;
using FluentValidation;

namespace CRM.Tenant.Service.Services.MasterServices
{

    public class UnitService: BaseService<CreateUnitRequest, UnitModel>
    {
        QuotationItemsService _quotationItemsService;
        PurchaseOrderItemsService _purchaseOrderItemsService;
        public UnitService(IMapper mapper, BaseRepository<UnitModel> repository, IValidator<CreateUnitRequest> validator, QuotationItemsService quotationItemsService, PurchaseOrderItemsService purchaseOrderItemsService)
            : base(mapper, repository, validator)
        {
            _quotationItemsService = quotationItemsService;
            _purchaseOrderItemsService = purchaseOrderItemsService;
        }

        public async override Task<bool> HasReferences(UnitModel entity)
        {
            if (await _quotationItemsService.ExistsAsync(q => q.Unit == entity.UnitName))
            {
                return true;
            }
            return await _purchaseOrderItemsService.ExistsAsync(p => p.Unit == entity.UnitName);
        }
    }
}
