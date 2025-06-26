using Crm.Tenant.Data.Models.WorkOrder;
using Crm.Tenant.Data.Models.Quotation;
using Crm.Tenant.Data.Models.WorkOrder;
using CRM.Tenant.Service.Models.Requests.WorkOrder.Update;
using CRM.Tenant.Service.Models.Requests.Quotation;
using CRM.Tenant.Service.Models.Requests.WorkOrder.Create;
using Crm.Tenant.Data.Models.WorkOrder;
using CRM.Tenant.Service.Models.Requests.WorkOrder.Delete;
using Crm.Tenant.Data.Models.WorkOrder;

namespace CRM.Tenant.Service.Services.WorkOrderService
{
    public class WorkOrderService
    {
        WorkOrderFieldsService _workOrderFields;
        WorkOrderItemsService _workOrderItems;

        public WorkOrderService(WorkOrderFieldsService workOrderFields,
        WorkOrderItemsService workOrderItems)
        {
            _workOrderFields = workOrderFields;
            _workOrderItems = workOrderItems;
        }

        public async Task<object> Create(CreateWorkOrderRequest request)
        {
            WorkOrderFieldsModel? workOrderFields = await _workOrderFields.CreateAsync(request.workOrderFields);
            List<WorkOrderItemModel> workOrderItems = new List<WorkOrderItemModel>();

            if (workOrderFields != null && workOrderFields.Id != null)
            {

                foreach (var item in request.workOrderItems)
                {
                    item.WorkOrderId = workOrderFields.Id;
                    await _workOrderItems.CreateAsync(item);
                }
                return new
                {
                    workOrderFields.Id,
                };
            }
            return new { Message = "Failed to create work order." };
        }

        public async Task<object> Update(UpdateWorkOrderRequest request)
        {
            WorkOrderFieldsModel? workOrderFields = await _workOrderFields.UpdateAsync(request.workOrderFields);
            List<WorkOrderItemModel> workOrderItems = new List<WorkOrderItemModel>();

            if (workOrderFields != null && workOrderFields.Id != null)
            {
                foreach (var item in request.workOrderItems)
                {
                    item.WorkOrderId = workOrderFields.Id;
                    if(item.Id == null)
                    {
                        await _workOrderItems.CreateAsync(item);
                    }
                    else
                    {
                        await _workOrderItems.UpdateAsync(item);
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
            WorkOrderFieldsModel? workOrderFields = await _workOrderFields.UpdateAsync(request.workOrderFields);

            if (workOrderFields == null || workOrderFields.Id == null)
            {
                return new { Message = "Failed to delete work order fields." };
            }

            // Soft delete WorkOrderItems
            if (request.workOrderItems != null && request.workOrderItems.Any())
            {
                foreach (var item in request.workOrderItems)
                {
                    await _workOrderItems.UpdateAsync(item);
                }
            }
            return new { Message = "Work order deleted successfully." };
        }

        public async Task<List<WorkOrderModel>> Get()
        {
            List<WorkOrderModel> result = new List<WorkOrderModel>();
            List<WorkOrderFieldsModel> workOrderFields = await _workOrderFields.ReadAsync();
            List<WorkOrderItemModel> workOrderItems = await _workOrderItems.ReadAsync();
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

            WorkOrderFieldsModel? workOrder = _workOrderFields.GetById(id);
            List<WorkOrderItemModel> workOrderItems = await _workOrderItems.ReadAsync();
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
