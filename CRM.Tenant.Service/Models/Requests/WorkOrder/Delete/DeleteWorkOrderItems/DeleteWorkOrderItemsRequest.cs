using CRM.Tenant.Service.Models.Requests.WorkOrder.Create.CreateWorkOrderItems;

namespace CRM.Tenant.Service.Models.Requests.WorkOrder.Delete.DeleteWorkOrderItems
{
    public class DeleteWorkOrderItemsRequest: CreateWorkOrderItemsRequest
    {
        public int? Id { get; set; }

        public bool IsDeleted = true;
    }
}
