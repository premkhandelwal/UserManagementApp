using AutoMapper;
using Crm.Tenant.Data.Models.WorkOrder;
using Crm.Tenant.Data.Repositories;
using Crm.Tenant.Data;
using FluentValidation;
using CRM.Tenant.Service.Models.Requests.WorkOrder.Create.CreateWorkOrderStatus;
using System.Security.Cryptography.X509Certificates;
using CRM.Tenant.Service.Models.Responses.WorkOrder;
using CRM.Tenant.Service.Models.Requests.WorkOrder.Update.UpdateWorkOrderStatus;
using Microsoft.EntityFrameworkCore;

namespace CRM.Tenant.Service.Services.WorkOrderService
{
    public class WorkOrderStatusService : BaseService<CreateWorkOrderStatusRequest, WorkOrderStatusModel>
    {
        public WorkOrderStatusService(IMapper mapper, BaseRepository<WorkOrderStatusModel> repository, IValidator<CreateWorkOrderStatusRequest> validator, IUnitOfWork unitOfWork)
            : base(mapper, repository, validator, unitOfWork)
        {
        }

        public async Task<WorkOrderStatusModel?> Update(UpdateWorkOrderStatusRequest updateWorkOrderStatusRequest)
        {
            if(updateWorkOrderStatusRequest.Id != null)
            {
                var existingRecordVersion = GetById((int)updateWorkOrderStatusRequest.Id)?.RecordVersion;
                if (existingRecordVersion != null && !existingRecordVersion.SequenceEqual(updateWorkOrderStatusRequest.RecordVersion))
                {
                    throw new DbUpdateConcurrencyException();
                }
                return await UpdateAsync(updateWorkOrderStatusRequest);
            }
            return null;
        }
        public async Task<List<WorkOrderStatusResponse>> GetWorkOrdersStatus(List<WorkOrderModel> workOrders)
        {
            List<WorkOrderStatusModel> workOrderStatuses = (await ReadAsync())
                                                             .OrderByDescending(w => w.ModifiedOn)
                                                             .ToList();
            List<WorkOrderStatusResponse> workOrderStatusResponse = new List<WorkOrderStatusResponse>();
            foreach (var workOrderStatus in workOrderStatuses)
            {
                var workOrder = workOrders.Where(wo => wo.workOrderFields.Id == workOrderStatus.WorkOrderId).FirstOrDefault();
                workOrderStatusResponse.Add(new WorkOrderStatusResponse 
                {
                    Id = workOrderStatus.Id,
                    PurchaseOrderNumber = workOrder?.workOrderFields.PurchaseOrderNumber,
                    WorkOrderNumber = workOrder?.workOrderFields.WorkOrderId,
                    WorkOrderCompanyId = workOrder?.workOrderFields.WorkOrderCompanyId,
                    WorkOrderId = workOrderStatus.WorkOrderId,
                    Remarks = workOrderStatus.Remarks,
                    OperationsUpdatedBy = workOrderStatus.OperationsUpdatedBy,
                    InvoiceUpdatedBy = workOrderStatus.InvoiceUpdatedBy,
                    StickerUpdatedBy = workOrderStatus.StickerUpdatedBy,
                    TcUpdatedBy = workOrderStatus.TcUpdatedBy,
                    RecordVersion = workOrderStatus.RecordVersion,
                    IsDeleted = workOrderStatus.IsDeleted,
                    AddedOn = workOrderStatus.AddedOn,
                    ModifiedOn = workOrderStatus.ModifiedOn
                });
            }
            return workOrderStatusResponse;
        }
    }
}