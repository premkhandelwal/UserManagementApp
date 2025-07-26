using Crm.Tenant.Data.Models.WorkOrder;
using Crm.Tenant.Data.Models.Quotation;
using Crm.Tenant.Data.Models.WorkOrder;
using CRM.Tenant.Service.Models.Requests.WorkOrder.Update;
using CRM.Tenant.Service.Models.Requests.Quotation;
using CRM.Tenant.Service.Models.Requests.WorkOrder.Create;
using Crm.Tenant.Data.Models.WorkOrder;
using CRM.Tenant.Service.Models.Requests.WorkOrder.Delete;
using Crm.Tenant.Data.Models.WorkOrder;
using CRM.Tenant.Service.Models.Requests.WorkOrder.Create.CreateWorkOrderStatus;
using CRM.Tenant.Service.Models.Responses.WorkOrder;
using Microsoft.EntityFrameworkCore;

namespace CRM.Tenant.Service.Services.WorkOrderService
{
    public class WorkOrderService
    {
        WorkOrderFieldsService _workOrderFieldsService;
        WorkOrderItemsService _workOrderItemsService;
        WorkOrderStatusService _workOrderStatusService;

        public WorkOrderService(WorkOrderFieldsService workOrderFieldsService,
        WorkOrderItemsService workOrderItemsService, WorkOrderStatusService workOrderStatusService)
        {
            _workOrderFieldsService = workOrderFieldsService;
            _workOrderItemsService = workOrderItemsService;
            _workOrderStatusService = workOrderStatusService;
        }

        public async Task<CreateWorkOrderResponse> Create(CreateWorkOrderRequest request)
        {
            try
            {
                // Get all existing work orders
                var allWorkOrders = await _workOrderFieldsService.ReadAsync(true);

                // Find the highest numeric ID from WorkOrderId (e.g., "WO023" → 23)
                int lastNumber = allWorkOrders
                    .Select(w => w.WorkOrderId)
                    .Where(id => id != null && id.StartsWith("WO"))
                    .Select(id =>
                    {
                        string numberPart = id!.Substring(2); // Remove "WO"
                        return int.TryParse(numberPart, out int number) ? number : 0;
                    })
                    .DefaultIfEmpty(0)
                    .Max();

                // Pad with at least 3 digits, e.g., 001, 045, 999, 1000
                string newWorkOrderId = $"WO-{(lastNumber + 1).ToString("D3")}";

                request.workOrderFields.WorkOrderId = newWorkOrderId;

                // Create work order header
                WorkOrderFieldsModel? workOrderFields = await _workOrderFieldsService.CreateAsync(request.workOrderFields);

                if (workOrderFields == null || workOrderFields.Id == null)
                    throw new InvalidOperationException("Failed to create work order header.");

                // Create initial work order status
                CreateWorkOrderStatusRequest workOrderStatus = new CreateWorkOrderStatusRequest()
                {
                    WorkOrderId = (int)workOrderFields.Id,
                    AddedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                };
                await _workOrderStatusService.CreateAsync(workOrderStatus);

                // Create work order items
                foreach (var item in request.workOrderItems)
                {
                    item.WorkOrderId = workOrderFields.Id;
                    await _workOrderItemsService.CreateAsync(item);
                }

                return new CreateWorkOrderResponse
                {
                    Message = newWorkOrderId,
                };
            }
            catch (DbUpdateException ex) when (ex.InnerException?.Message.Contains("IX_WorkOrderFields_WorkOrderId") == true)
            {
                throw new InvalidOperationException("Work Order ID must be unique. A duplicate entry was detected.", ex);
            }
            catch (DbUpdateException ex)
            {
                throw new InvalidOperationException("A database error occurred while creating the work order.", ex);
            }
        }

        public async Task<object> Update(UpdateWorkOrderRequest request)
        {
            WorkOrderFieldsModel? workOrderFields = await _workOrderFieldsService.UpdateAsync(request.workOrderFields);
            List<WorkOrderItemModel> workOrderItems = new List<WorkOrderItemModel>();

            if (workOrderFields != null && workOrderFields.Id != null)
            {
                foreach (var item in request.workOrderItems)
                {
                    item.WorkOrderId = workOrderFields.Id;
                    if(item.Id == null)
                    {
                        await _workOrderItemsService.CreateAsync(item);
                    }
                    else
                    {
                        await _workOrderItemsService.UpdateAsync(item);
                    }
                }

                return new
                {
                    workOrderFields.WorkOrderId
                };
            }
            return new { Message = "Failed to update work order." };
        }

        public async Task<object> Delete(DeleteWorkOrderRequest request)
        {
            if (request.workOrderFields == null)
            {
                return new { Message = "Work order fields cannot be null." };
            }
            WorkOrderFieldsModel? workOrderFields = await _workOrderFieldsService.UpdateAsync(request.workOrderFields);

            if (workOrderFields == null || workOrderFields.Id == null)
            {
                return new { Message = "Failed to delete work order fields." };
            }

            // Soft delete WorkOrderItems
            if (request.workOrderItems != null && request.workOrderItems.Any())
            {
                foreach (var item in request.workOrderItems)
                {
                    await _workOrderItemsService.UpdateAsync(item);
                }
            }
            return new { Message = "Work order deleted successfully." };
        }

        public async Task<List<WorkOrderModel>> Get()
        {
            List<WorkOrderModel> result = new List<WorkOrderModel>();
            List<WorkOrderFieldsModel> workOrderFields = await _workOrderFieldsService.ReadAsync(fetchDeletedRecords: true);
            List<WorkOrderItemModel> workOrderItems = await _workOrderItemsService.ReadAsync(orderByModifiedOn: false);
            foreach (var workOrder in workOrderFields)
            {
                int? id = workOrder.Id;
                if (id != null)
                {
                    List<WorkOrderItemModel> qItems = workOrderItems.Where(item => item.WorkOrderId == id).ToList();
                    result.Add(new WorkOrderModel()
                    {
                        workOrderFields = workOrder,
                        workOrderItems = qItems,

                    });
                }
            }
            return result;
        }

        public async Task<WorkOrderModel?> GetWorkOrderById(int id)
        {
            WorkOrderModel result = new WorkOrderModel();

            WorkOrderFieldsModel? workOrder = _workOrderFieldsService.GetById(id);
            List<WorkOrderItemModel> workOrderItems = await _workOrderItemsService.ReadAsync(orderByModifiedOn: false);
            if (workOrder != null)
            {
                int? qId = workOrder.Id;
                if (qId != null)
                {
                    List<WorkOrderItemModel> qItems = workOrderItems.Where(item => item.WorkOrderId == qId).ToList();
                    return new WorkOrderModel()
                    {
                        workOrderFields = workOrder,
                        workOrderItems = qItems,
                    };
                }
            }
            return null;
        }
    }
}
