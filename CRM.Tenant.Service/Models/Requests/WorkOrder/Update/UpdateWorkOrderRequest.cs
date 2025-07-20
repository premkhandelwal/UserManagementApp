using CRM.Tenant.Service.Models.Requests.WorkOrder.Update.UpdateWorkOrderFields;
using CRM.Tenant.Service.Models.Requests.WorkOrder.Update.UpdateWorkOrderItems;

namespace CRM.Tenant.Service.Models.Requests.WorkOrder.Update
{
    public class UpdateWorkOrderRequest
    {
        public UpdateWorkOrderFieldsRequest workOrderFields { get; set; } = new UpdateWorkOrderFieldsRequest();

        public List<UpdateWorkOrderItemsRequest> workOrderItems { get; set; } = new List<UpdateWorkOrderItemsRequest>();
    }
}
