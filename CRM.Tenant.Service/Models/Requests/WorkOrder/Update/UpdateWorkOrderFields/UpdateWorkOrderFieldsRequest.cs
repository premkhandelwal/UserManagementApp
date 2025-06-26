
using CRM.Tenant.Service.Models.Requests.WorkOrder.Create.CreateWorkFields;

namespace CRM.Tenant.Service.Models.Requests.WorkOrder.Update.UpdateWorkOrderFields
{
    public class UpdateWorkOrderFieldsRequest : CreateWorkOrderFieldsRequest
    {
        public int? Id { get; set; }
    }
}
