using CRM.Tenant.Service.Models.Requests.WorkOrder.Create.CreateWorkOrderItems;

namespace CRM.Tenant.Service.Models.Requests.WorkOrder.Update.UpdateWorkOrderItems
{
    public class UpdateWorkOrderItemsRequest: CreateWorkOrderItemsRequest
    {
        public int? Id { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
