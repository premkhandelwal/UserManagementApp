using AutoMapper;
using Crm.Tenant.Data.Repositories;
using Crm.Tenant.Data;
using FluentValidation;
using CRM.Tenant.Service.Models.Requests.WorkOrder.Create.CreateWorkOrderItems;
using Crm.Tenant.Data.Models.WorkOrder;

namespace CRM.Tenant.Service.Services.WorkOrderService
{
    public class WorkOrderItemsService : BaseService<CreateWorkOrderItemsRequest, WorkOrderItemModel>
    {
        public WorkOrderItemsService(IMapper mapper, BaseRepository<WorkOrderItemModel> repository, IValidator<CreateWorkOrderItemsRequest> validator, IUnitOfWork unitOfWork)
            : base(mapper, repository, validator, unitOfWork)
        {
        }
    }
}
