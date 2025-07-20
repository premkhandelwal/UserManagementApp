using CRM.Tenant.Service.Models.Requests.WorkOrder.Delete.DeleteWorkOrderFields;
using CRM.Tenant.Service.Models.Requests.WorkOrder.Delete.DeleteWorkOrderItems;

namespace CRM.Tenant.Service.Models.Requests.WorkOrder.Delete
{
    public class DeleteWorkOrderRequest
    {
        public DeleteWorkOrderFieldsRequest workOrderFields { get; set; } = new DeleteWorkOrderFieldsRequest();

        public List<DeleteWorkOrderItemsRequest> workOrderItems { get; set; } = new List<DeleteWorkOrderItemsRequest>();
    }
}
