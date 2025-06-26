using CRM.Tenant.Service.Models.Requests.WorkOrder.Create.CreateWorkFields;
using CRM.Tenant.Service.Models.Requests.WorkOrder.Create.CreateWorkOrderItems;

namespace CRM.Tenant.Service.Models.Requests.WorkOrder.Create
{
    public class CreateWorkOrderRequest
    {
        public CreateWorkOrderFieldsRequest workOrderFields { get; set; } = new CreateWorkOrderFieldsRequest();

        public List<CreateWorkOrderItemsRequest> workOrderItems { get; set; } = new List<CreateWorkOrderItemsRequest>();
    }
}
