
using CRM.Tenant.Service.Models.Requests.WorkOrder.Create.CreateWorkFields;

namespace CRM.Tenant.Service.Models.Requests.WorkOrder.Delete.DeleteWorkOrderFields
{
    public class DeleteWorkOrderFieldsRequest: CreateWorkOrderFieldsRequest
    {
        public int? Id { get; set; }

        public bool IsDeleted = true;
    }
}
